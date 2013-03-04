namespace SmevUtils
{
    using System;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Text;
    using System.Xml;

    public class SmevServiceInspector : Attribute, IServiceBehavior, IDispatchMessageInspector
    {
        private X509Certificate2 serviceCert;
        private object serviceCertCriteria = ConfigurationManager.AppSettings["serviceCertCriteria"];
        private X509FindType findType = (X509FindType)Enum.Parse(typeof(X509FindType), ConfigurationManager.AppSettings["serviceCertFindType"].ToString(), true);
        private StoreName storeName = (StoreName)Enum.Parse(typeof(StoreName), ConfigurationManager.AppSettings["serviceCertStoreName"].ToString(), true);
        private StoreLocation storeLocation = (StoreLocation)Enum.Parse(typeof(StoreLocation), ConfigurationManager.AppSettings["serviceCertStoreLocation"].ToString(), true);

        public SmevServiceInspector()
        {
            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);

            //сертификат
            var coll = store.Certificates.Find(findType, serviceCertCriteria, true);

            if (coll.Count == 0)
            {
                throw new FileNotFoundException(string.Format("Сертификат сервера с признаком \"{0}\" не найден.", serviceCertCriteria));
            }
            serviceCert = coll[0];
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channel in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpoing in channel.Endpoints)
                {
                    endpoing.DispatchRuntime.MessageInspectors.Add(this);
                }
            }
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            ValidateMessage(ref request);
            return null;
        }

        private void ValidateMessage(ref Message request)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(request.ToString());
            var faultElements = xmlDocument.GetElementsByTagName("fault");
            if (faultElements.Count > 0)
            {
                var faultElement = faultElements[0];
                var faultMessage = faultElement.Attributes["faultMessage"].Value;
                var faultCode = faultElement.Attributes["faultCode"].Value;
                throw new FaultException(faultMessage, new FaultCode(faultCode, "http://smev.gosuslugi.ru/rev120315"));
            }
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var outgoingMessage = reply.ToString();
            var signedSoapMessage = Signer.SignMessage(outgoingMessage, "ep-ov", serviceCert);
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(signedSoapMessage));
            var reader = XmlReader.Create(ms);
            reply = Message.CreateMessage(reader, Int32.MaxValue, reply.Version);
        }
    }
}
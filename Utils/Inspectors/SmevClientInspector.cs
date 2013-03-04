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

    public class SmevClientInspector : Attribute, IServiceBehavior, IClientMessageInspector
    {
        private X509Certificate2 clientCert;
        private object clientCertCriteria = ConfigurationManager.AppSettings["clientCertCriteria"];
        private X509FindType findType = (X509FindType)Enum.Parse(typeof(X509FindType), ConfigurationManager.AppSettings["clientCertFindType"].ToString(), true);
        private StoreName storeName = (StoreName)Enum.Parse(typeof(StoreName), ConfigurationManager.AppSettings["clientCertStoreName"].ToString(), true);
        private StoreLocation storeLocation = (StoreLocation)Enum.Parse(typeof(StoreLocation), ConfigurationManager.AppSettings["clientCertStoreLocation"].ToString(), true);

        public SmevClientInspector()
        {
            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);

            //сертификат
            var coll = store.Certificates.Find(findType, clientCertCriteria, true);

            if (coll.Count == 0)
            {
                throw new FileNotFoundException(string.Format("Сертификат клиента с признаком \"{0}\" не найден", clientCertCriteria));
            }
            clientCert = coll[0];
        }

        public SmevClientInspector(string certificate)
        {
            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);

            //сертификат
            var coll = store.Certificates.Find(findType, certificate, true);

            if (coll.Count == 0)
            {
                throw new FileNotFoundException(string.Format("Сертификат клиента с признаком \"{0}\" не найден.", certificate));
            }
            clientCert = coll[0];
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var outgoingMessage = request.ToString();

            var doc = new XmlDocument();
            doc.LoadXml(outgoingMessage);

            var signedSoapMessage = Signer.SignMessage(outgoingMessage, "ep-ov", clientCert);

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(signedSoapMessage));
            var reader = XmlDictionaryReader.CreateTextReader(ms, new XmlDictionaryReaderQuotas());
            request = Message.CreateMessage(reader, Int32.MaxValue, request.Version);

            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Configuration;
using System.Text;
using System.Xml;

namespace Utils
{
    public class SmevServiceInspector : Attribute,
        IServiceBehavior,
        IDispatchMessageInspector
    {
        private X509Certificate2 serviceCert;

        public SmevServiceInspector()
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            //сертификат
            var coll = store.Certificates.Find(X509FindType.FindByThumbprint, ConfigurationManager.AppSettings["serverCert"], true);

            if (coll.Count == 0)
            {
                throw new FileNotFoundException(string.Format("Сертификат клиента не найден. Отпечаток {0}", ConfigurationManager.AppSettings["serverCert"]));
            }
            serviceCert = coll[0];
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            //Пусто
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            //Пусто
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channel
               in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpoing
                    in channel.Endpoints)
                {
                    endpoing
                        .DispatchRuntime
                        .MessageInspectors
                        .Add(this);
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

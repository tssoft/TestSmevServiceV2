using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace Utils
{
    public class SmevClientInspector : Attribute,
        IServiceBehavior,
        IClientMessageInspector
    {
        private X509Certificate2 serviceCert;

        public SmevClientInspector()
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            //сертификат
            var coll = store.Certificates.Find(X509FindType.FindByThumbprint, ConfigurationManager.AppSettings["clientCert"], true);

            if (coll.Count == 0)
            {
                throw new FileNotFoundException(string.Format("Сертификат клиента не найден. Отпечаток {0}", ConfigurationManager.AppSettings["serverCert"]));
            }
            serviceCert = coll[0];
        }

        public SmevClientInspector(string certificate)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            //сертификат
            var coll = store.Certificates.Find(X509FindType.FindByThumbprint, certificate, true);

            if (coll.Count == 0)
            {
                throw new FileNotFoundException(string.Format("Сертификат клиента не найден. Отпечаток {0}", certificate));
            }
            serviceCert = coll[0];
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            // Пусто
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            // Пусто
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            // Пусто
        }

        public void ApplyClientBehavior(
            ServiceEndpoint endpoint,
            ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var outgoingMessage = request.ToString();

            var doc = new XmlDocument();
            doc.LoadXml(outgoingMessage);

            var signedSoapMessage = Signer.SignMessage(outgoingMessage, "ep-ov", serviceCert);

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

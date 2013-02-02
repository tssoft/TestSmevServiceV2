using System;
using System.IO;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace Utils
{
    public class SmevServiceMessageEncoder : MessageEncoder
    {
        private const string Soap11Namespace = "http://schemas.xmlsoap.org/soap/envelope/";
        private string soapEnvelope =
            "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Header></s:Header><s:Body></s:Body></s:Envelope>";
        private readonly SmevServiceMessageEncoderFactory _factory;
        private readonly string _contentType;
        private readonly MessageEncoder _innerEncoder;

        private string LogPath { get; set; }

        public override string ContentType
        {
            get
            {
                return _contentType;
            }
        }

        public override string MediaType
        {
            get
            {
                return _factory.MediaType;
            }
        }

        public override MessageVersion MessageVersion
        {
            get
            {
                return _factory.MessageVersion;
            }
        }

        public SmevServiceMessageEncoder(SmevServiceMessageEncoderFactory factory)
        {
            _factory = factory;
            _innerEncoder = factory.InnerMessageFactory.Encoder;
            _contentType = _factory.MediaType;
            LogPath = _factory.LogPath;
        }

        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            var msgContents = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);
            var reader = XmlReader.Create(new MemoryStream(msgContents));
            var xmlDocument = new XmlDocument();
            xmlDocument.PreserveWhitespace = true;
            xmlDocument.Load(reader);
            
            LogMessage(xmlDocument, true);

            var nodeList = xmlDocument.GetElementsByTagName(
               "Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");

            // Хорошо бы проверять наличие именно подписей СМЭВ и ОВ
            if (nodeList.Count < 1)
            {
                return CreateErrorMessage(bufferManager, contentType, "SMEV-100008",
                                          "Не найдена подпись документа");
            }

            var xmlDocument2 = new XmlDocument();
            xmlDocument2.PreserveWhitespace = false;
            xmlDocument2.LoadXml(xmlDocument.OuterXml);

            // Проверяем подпись
            if (!(Signer.CheckSignature(xmlDocument) || Signer.CheckSignature(xmlDocument2)))
            {
                return CreateErrorMessage(bufferManager, contentType, "SMEV-100003",
                                          "Неверная ЭП сообщения");
            }

            var bytes = new UTF8Encoding().GetBytes(xmlDocument.OuterXml);
            var length = bytes.Length;
            var array = bufferManager.TakeBuffer(length);
            Array.Copy(bytes, 0, array, 0, length);
            buffer = new ArraySegment<byte>(array, 0, length);
            return _innerEncoder.ReadMessage(buffer, bufferManager, contentType);
        }

        private Message CreateErrorMessage(BufferManager bufferManager, string contentType, string faultCode, string message)
        {
            var doc = new XmlDocument();
            doc.LoadXml(soapEnvelope);
            var faultElement = doc.CreateElement("fault");
            var errorCodeAttribute = doc.CreateAttribute("faultCode");
            errorCodeAttribute.Value = faultCode;
            var errorMessageAttribute = doc.CreateAttribute("faultMessage");
            errorMessageAttribute.Value = message;
            faultElement.Attributes.Append(errorCodeAttribute);
            faultElement.Attributes.Append(errorMessageAttribute);

            XmlNode bodyElement;
            var bodyElements = doc.GetElementsByTagName("Body", Soap11Namespace);
            bodyElement = bodyElements[0];
            bodyElement.AppendChild(faultElement);
            return CreateMessage(doc, bufferManager, contentType);

        }

        private Message CreateMessage(XmlDocument xmlDocument, BufferManager bufferManager, string contentType)
        {
            var bytes = new UTF8Encoding().GetBytes(xmlDocument.InnerXml);
            var length = bytes.Length;
            const int destinationIndex = 0;
            var bufferSize = length + destinationIndex;
            var buffer4 = bufferManager.TakeBuffer(bufferSize);
            Array.Copy(bytes, 0, buffer4, destinationIndex, bufferSize);
            var buffer = new ArraySegment<byte>(buffer4, destinationIndex, bufferSize);
            return _innerEncoder.ReadMessage(buffer, bufferManager, contentType);
        }

        public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
        {
            return _innerEncoder.ReadMessage(stream, maxSizeOfHeaders, contentType);
        }

        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            var arraySegment = _innerEncoder.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
            var buffer1 = new byte[arraySegment.Count];
            Array.Copy(arraySegment.Array, arraySegment.Offset, buffer1, 0, buffer1.Length);
            var reader = XmlReader.Create(new MemoryStream(buffer1));
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(reader);
            var memoryStream = new MemoryStream();
            var w = XmlWriter.Create(memoryStream, new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Encoding = new UTF8Encoding(false)
            });
            xmlDocument.Save(w);
            LogMessage(xmlDocument, false);
            w.Flush();
            var buffer2 = memoryStream.GetBuffer();
            var num = (int)memoryStream.Position;
            memoryStream.Close();
            var bufferSize = num + messageOffset;
            var array = bufferManager.TakeBuffer(bufferSize);
            Array.Copy(buffer2, 0, array, messageOffset, num);
            return new ArraySegment<byte>(array, messageOffset, num);
        }

        public override void WriteMessage(Message message, Stream stream)
        {
            _innerEncoder.WriteMessage(message, stream);
        }

        private void LogMessage(XmlDocument doc, bool input)
        {
            try
            {
                var document = new XmlDocument();
                document.LoadXml(doc.OuterXml);

                var prefixOfNamespace = document.FirstChild.GetPrefixOfNamespace(Soap11Namespace);
                var body = document.GetElementsByTagName(prefixOfNamespace + ":Body", Soap11Namespace);
                if (body.Count == 0)
                {
                    body = document.GetElementsByTagName("body", Soap11Namespace);
                    if (body.Count == 0)
                    {
                        body = document.GetElementsByTagName("Body", Soap11Namespace);
                    }
                }
                if (body.Count != 0)
                {
                    var child = body[0].FirstChild;
                    SaveMessage(input,
                                doc.InnerXml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>",
                                                     ""), child.Name);
                }
                else
                {
                    var s = input ? "Request_" : "Responce_";
                    SaveMessage(input, doc.InnerXml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", ""), s);
                }
            }
            catch
            {
                var s = input ? "Request_" : "Responce_";
                SaveMessage(input, doc.InnerXml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", ""), s);
            }
            
        }

        private void SaveMessage(bool input, string message, string name)
        {
            var dir = LogPath + "\\" + DateTime.Now.ToString("yy.MM.dd");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            dir = dir + "\\";
            var now = DateTime.Now.ToString("HH.mm.ss.ffff_");
            var ending = input ? ".in.xml" : ".out.xml";
            try
            {
                var fileName = now + name + ending;
                File.WriteAllText(dir + fileName, message);
            }
            catch
            {
                try
                {
                    name = input ? "Request_" : "Responce_";
                    File.WriteAllText(dir + now + name + ".xml", message);
                }
                catch (Exception e)
                {
                    try
                    {
                        File.WriteAllText(dir + now + "_error" + ".txt", e.Message);
                    }
                    catch (Exception)
                    {
                        // Если уже ничего не помогло ничего и не пишем
                    }

                }

            }
        }
    }
}

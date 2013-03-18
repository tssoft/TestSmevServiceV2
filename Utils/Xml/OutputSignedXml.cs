namespace SmevUtils
{
    using System;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Xml;

    public class OutputSignedXml : SignedXml
    {
        public OutputSignedXml(XmlDocument document)
            : base(document)
        {
        }

        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            if (String.Compare(idValue, KeyInfo.Id, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return KeyInfo.GetXml();
            }

            XmlElement idElem = base.GetIdElement(document, idValue);

            if (idElem == null)
            {
                XmlNamespaceManager nsManager = new XmlNamespaceManager(document.NameTable);
                nsManager.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
                idElem = document.SelectSingleNode("//*[@wsu:Id=\"" + idValue + "\"]", nsManager) as XmlElement;
            }

            return idElem;
        }

        public void ComputeSignature(string prefix)
        {
            BuildDigestedReferences();
            var signingKey = SigningKey;
            if (signingKey == null)
            {
                throw new CryptographicException("Cryptography_Xml_LoadKeyFailed");
            }
            if (SignedInfo.SignatureMethod == null)
            {
                SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#gostr34102001-gostr3411";
            }
            var signatureDescription = CryptoConfig.CreateFromName(SignedInfo.SignatureMethod) as SignatureDescription;
            if (signatureDescription == null)
            {
                throw new CryptographicException("Cryptography_Xml_SignatureDescriptionNotCreated");
            }
            var digest = signatureDescription.CreateDigest();
            if (digest == null)
            {
                throw new CryptographicException("Cryptography_Xml_CreateHashAlgorithmFailed");
            }
            GetC14NDigest(digest, prefix);
            m_signature.SignatureValue = signatureDescription.CreateFormatter(signingKey).CreateSignature(digest);
        }

        public XmlElement GetXml(string prefix)
        {
            var xml = GetXml();
            SetPrefix(prefix, xml);
            return xml;
        }

        private void BuildDigestedReferences()
        {
            typeof(SignedXml).GetMethod("BuildDigestedReferences", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, new object[0]);
        }

        private byte[] GetC14NDigest(HashAlgorithm hash, string prefix)
        {
            var xmlDocument = new XmlDocument
                              {
                                  PreserveWhitespace = true
                              };
            var xml = SignedInfo.GetXml();
            xmlDocument.AppendChild(xmlDocument.ImportNode(xml, true));
            var canonicalizationMethodObject = SignedInfo.CanonicalizationMethodObject;
            SetPrefix(prefix, xmlDocument.DocumentElement);
            canonicalizationMethodObject.LoadInput(xmlDocument);
            return canonicalizationMethodObject.GetDigestedOutput(hash);
        }

        private void SetPrefix(string prefix, XmlNode node)
        {
            foreach (XmlNode node1 in node.ChildNodes)
            {
                SetPrefix(prefix, node1);
            }
            node.Prefix = prefix;
        }
    }
}
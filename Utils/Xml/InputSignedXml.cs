namespace SmevUtils
{
    using System;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Xml;

    public class InputSignedXml : SignedXml
    {
        public const string WSSecurityWSSENamespaceUrl =
            "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";

        public const string WSSecurityWSUNamespaceUrl =
            "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";

        public InputSignedXml(XmlDocument document)
            : base(document)
        {
        }

        public void ComputeSignature(string prefix)
        {
            BuildDigestedReferences();
            var description = CryptoConfig.CreateFromName(SignedInfo.SignatureMethod) as SignatureDescription;

            HashAlgorithm hash = description.CreateDigest();

            GetDigest(hash, prefix);
            m_signature.SignatureValue = description.CreateFormatter(SigningKey).CreateSignature(hash);
        }

        private void BuildDigestedReferences()
        {
            Type t = typeof(SignedXml);
            MethodInfo m = t.GetMethod("BuildDigestedReferences", BindingFlags.NonPublic | BindingFlags.Instance);
            m.Invoke(this, new object[] { });
        }

        private byte[] GetDigest(HashAlgorithm hash, string prefix)
        {
            XmlDocument document = new XmlDocument();
            document.PreserveWhitespace = true;

            XmlElement e = SignedInfo.GetXml();
            document.AppendChild(document.ImportNode(e, true));

            Transform canonicalizationMethodObject = SignedInfo.CanonicalizationMethodObject;
            SetPrefix(prefix, document);

            canonicalizationMethodObject.LoadInput(document);
            return canonicalizationMethodObject.GetDigestedOutput(hash);
        }

        private void SetPrefix(string prefix, XmlNode node)
        {
            foreach (XmlNode n in node.ChildNodes)
            {
                SetPrefix(prefix, n);
            }
            node.Prefix = prefix;
        }

        public XmlElement GetXml(string prefix)
        {
            XmlElement e = GetXml();
            SetPrefix(prefix, e);
            return e;
        }

        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
            nsmgr.AddNamespace("wsu", WSSecurityWSUNamespaceUrl);
            return document.SelectSingleNode("//*[@wsu:Id='" + idValue + "']", nsmgr) as XmlElement;
        }
    }
}
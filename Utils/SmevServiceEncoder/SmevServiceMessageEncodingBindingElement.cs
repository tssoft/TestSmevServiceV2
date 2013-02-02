using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

namespace Utils
{
    public sealed class SmevServiceMessageEncodingBindingElement : MessageEncodingBindingElement, IWsdlExportExtension
    {
        private readonly MessageVersion _vers = MessageVersion.CreateVersion(EnvelopeVersion.Soap11, AddressingVersion.None);
        private string _senderActor = "http://smev.gosuslugi.ru/actors/smev";
        private MessageEncodingBindingElement _innerBindingElement;

        public string LogPath { get; set; }

        public MessageEncodingBindingElement InnerMessageEncodingBindingElement
        {
            get
            {
                return _innerBindingElement;
            }
            set
            {
                _innerBindingElement = value;
            }
        }

        public string SenderActor
        {
            get
            {
                return _senderActor;
            }
            set
            {
                _senderActor = value;
            }
        }

        public override MessageVersion MessageVersion
        {
            get
            {
                return _innerBindingElement.MessageVersion;
            }
            set
            {
                _innerBindingElement.MessageVersion = value;
            }
        }

        public SmevServiceMessageEncodingBindingElement(string logPath, string sender)
            : this(new TextMessageEncodingBindingElement())
        {
            SenderActor = sender;
            LogPath = logPath;
        }

        public SmevServiceMessageEncodingBindingElement(string logPath)
            : this(new TextMessageEncodingBindingElement())
        {
            LogPath = logPath;
        }

        public SmevServiceMessageEncodingBindingElement(MessageEncodingBindingElement messageEncoderBindingElement)
        {
            _innerBindingElement = messageEncoderBindingElement;
            _innerBindingElement.MessageVersion = _vers;
        }

        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new SmevServiceMessageEncoderFactory("text/xml", "utf-8", _vers, _innerBindingElement.CreateMessageEncoderFactory(), LogPath, SenderActor);
        }

        public override BindingElement Clone()
        {
            return new SmevServiceMessageEncodingBindingElement(_innerBindingElement)
            {
                SenderActor = SenderActor,
                LogPath = LogPath
                
            };
        }

        public override T GetProperty<T>(BindingContext context)
        {
            return typeof(T) == typeof(XmlDictionaryReaderQuotas) ? _innerBindingElement.GetProperty<T>(context) : base.GetProperty<T>(context);
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            context.BindingParameters.Add(this);
            return context.BuildInnerChannelFactory<TChannel>();
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            context.BindingParameters.Add(this);
            return context.BuildInnerChannelListener<TChannel>();
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            context.BindingParameters.Add(this);
            return context.CanBuildInnerChannelListener<TChannel>();
        }

        public void ExportContract(WsdlExporter exporter, WsdlContractConversionContext context)
        {
            
        }

        public void ExportEndpoint(WsdlExporter exporter, WsdlEndpointConversionContext context)
        {
            ((IWsdlExportExtension)_innerBindingElement).ExportEndpoint(exporter, context);
        }
    }
}

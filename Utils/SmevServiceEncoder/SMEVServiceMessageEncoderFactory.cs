﻿namespace SmevUtils
{
    using System.ServiceModel.Channels;

    public class SmevServiceMessageEncoderFactory : MessageEncoderFactory
    {
        internal readonly string SenderActor = string.Empty;
        private readonly MessageEncoder _encoder;
        private readonly MessageVersion _version;
        private readonly string _mediaType;
        private readonly string _charSet;
        private readonly MessageEncoderFactory _innerMessageFactory;

        public string LogPath { get; set; }

        public override MessageEncoder Encoder
        {
            get
            {
                return _encoder;
            }
        }

        public override MessageVersion MessageVersion
        {
            get
            {
                return _version;
            }
        }

        internal MessageEncoderFactory InnerMessageFactory
        {
            get
            {
                return _innerMessageFactory;
            }
        }

        internal string MediaType
        {
            get
            {
                return _mediaType;
            }
        }

        internal string CharSet
        {
            get
            {
                return _charSet;
            }
        }

        internal SmevServiceMessageEncoderFactory(string mediaType, string charSet, MessageVersion version, MessageEncoderFactory messageFactory, string logPath, string senderActor)
        {
            _version = version;
            _mediaType = mediaType;
            _charSet = charSet;
            SenderActor = senderActor;
            _innerMessageFactory = messageFactory;
            LogPath = logPath;
            _encoder = new SmevServiceMessageEncoder(this);
        }
    }
}
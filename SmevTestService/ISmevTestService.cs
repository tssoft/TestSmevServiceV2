namespace SmevTestService
{
    using System.ServiceModel;

    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ISmevTestService" в коде и файле конфигурации.
    [ServiceContract(Namespace = "http://mustiksprogramming.blogspot.com/")]
    [XmlSerializerFormat]
    public interface ISmevTestService
    {
        [OperationContract]
        [XmlSerializerFormat]
        GetTestDataResponse GetData(GetTestData data);
    }

    /// <summary>
    /// Входящее сообщение GetPermit
    /// </summary>
    [MessageContract(WrapperName = "GetTestData")]
    [XmlSerializerFormat]
    public class GetTestData
    {
        [MessageHeader(Name = "Header", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public HeaderType Header;

        [MessageBodyMember(Name = "Message", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public MessageType Message;

        [MessageBodyMember(Name = "MessageData", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public MessageDataType MessageData;
    }

    /// <summary>
    /// Исходящее сообщение GetTestDataResponse
    /// </summary>
    [MessageContract(WrapperName = "GetTestDataResponse")]
    [XmlSerializerFormat]
    public class GetTestDataResponse
    {
        [MessageHeader(Name = "Header", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public HeaderType Header;

        [MessageBodyMember(Name = "Message", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public MessageType Message;

        [MessageBodyMember(Name = "MessageData", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public MessageDataType MessageData;
    }
}
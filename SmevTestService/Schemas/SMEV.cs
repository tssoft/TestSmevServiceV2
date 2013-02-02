// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.38967
//    <NameSpace>SMEV</NameSpace><Collection>Array</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net20</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace SmevTestService
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("Header", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class HeaderType {
        
        private string nodeIdField;
        
        private string messageIdField;
        
        private System.DateTime timeStampField;
        
        private MessageClassType messageClassField;
        
        private PacketIdType[] packetIdsField;
        
        private string actorField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string NodeId {
            get {
                return this.nodeIdField;
            }
            set {
                this.nodeIdField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MessageId {
            get {
                return this.messageIdField;
            }
            set {
                this.messageIdField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public System.DateTime TimeStamp {
            get {
                return this.timeStampField;
            }
            set {
                this.timeStampField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public MessageClassType MessageClass {
            get {
                return this.messageClassField;
            }
            set {
                this.messageClassField = value;
            }
        }
        
        [System.Xml.Serialization.XmlArrayAttribute(Order=4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Id", IsNullable=false)]
        public PacketIdType[] PacketIds {
            get {
                return this.packetIdsField;
            }
            set {
                this.packetIdsField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string actor {
            get {
                return this.actorField;
            }
            set {
                this.actorField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("MessageClass", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public enum MessageClassType {
        
        /// <remarks/>
        REQUEST,
        
        /// <remarks/>
        RESPONSE,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("Id", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class PacketIdType {
        
        private string messageIdField;
        
        private string subRequestNumberField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MessageId {
            get {
                return this.messageIdField;
            }
            set {
                this.messageIdField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SubRequestNumber {
            get {
                return this.subRequestNumberField;
            }
            set {
                this.subRequestNumberField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("BaseMessage", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class BaseMessageType {
        
        private MessageType messageField;
        
        private MessageDataType messageDataField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public MessageType Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public MessageDataType MessageData {
            get {
                return this.messageDataField;
            }
            set {
                this.messageDataField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("Message", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class MessageType {
        
        private orgExternalType senderField;
        
        private orgExternalType recipientField;
        
        private orgExternalType originatorField;
        
        private object itemField;
        
        private TypeCodeType typeCodeField;
        
        private StatusType statusField;
        
        private System.DateTime dateField;
        
        private string exchangeTypeField;
        
        private string requestIdRefField;
        
        private string originRequestIdRefField;
        
        private string serviceCodeField;
        
        private string caseNumberField;
        
        private SubMessageType[] subMessagesField;
        
        private string testMsgField;
        
        private string oKTMOField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public orgExternalType Sender {
            get {
                return this.senderField;
            }
            set {
                this.senderField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public orgExternalType Recipient {
            get {
                return this.recipientField;
            }
            set {
                this.recipientField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public orgExternalType Originator {
            get {
                return this.originatorField;
            }
            set {
                this.originatorField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("Service", typeof(ServiceType), Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("ServiceName", typeof(string), Order=3)]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public TypeCodeType TypeCode {
            get {
                return this.typeCodeField;
            }
            set {
                this.typeCodeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public StatusType Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public System.DateTime Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string ExchangeType {
            get {
                return this.exchangeTypeField;
            }
            set {
                this.exchangeTypeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string RequestIdRef {
            get {
                return this.requestIdRefField;
            }
            set {
                this.requestIdRefField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string OriginRequestIdRef {
            get {
                return this.originRequestIdRefField;
            }
            set {
                this.originRequestIdRefField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string ServiceCode {
            get {
                return this.serviceCodeField;
            }
            set {
                this.serviceCodeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string CaseNumber {
            get {
                return this.caseNumberField;
            }
            set {
                this.caseNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlArrayAttribute(Order=12)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SubMessage", IsNullable=false)]
        public SubMessageType[] SubMessages {
            get {
                return this.subMessagesField;
            }
            set {
                this.subMessagesField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string TestMsg {
            get {
                return this.testMsgField;
            }
            set {
                this.testMsgField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string OKTMO {
            get {
                return this.oKTMOField;
            }
            set {
                this.oKTMOField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("Sender", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class orgExternalType {
        
        private string codeField;
        
        private string nameField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("Service", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class ServiceType {
        
        private string mnemonicField;
        
        private string versionField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Mnemonic {
            get {
                return this.mnemonicField;
            }
            set {
                this.mnemonicField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("TypeCode", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public enum TypeCodeType {
        
        /// <remarks/>
        GSRV,
        
        /// <remarks/>
        GFNC,
        
        /// <remarks/>
        OTHR,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("Status", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public enum StatusType {
        
        /// <remarks/>
        REQUEST,
        
        /// <remarks/>
        RESULT,
        
        /// <remarks/>
        REJECT,
        
        /// <remarks/>
        INVALID,
        
        /// <remarks/>
        ACCEPT,
        
        /// <remarks/>
        PING,
        
        /// <remarks/>
        PROCESS,
        
        /// <remarks/>
        NOTIFY,
        
        /// <remarks/>
        FAILURE,
        
        /// <remarks/>
        CANCEL,
        
        /// <remarks/>
        STATE,
        
        /// <remarks/>
        PACKET,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("SubMessage", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class SubMessageType {
        
        private string subRequestNumberField;
        
        private StatusType statusField;
        
        private orgExternalType originatorField;
        
        private System.DateTime dateField;
        
        private string requestIdRefField;
        
        private string originRequestIdRefField;
        
        private string serviceCodeField;
        
        private string caseNumberField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SubRequestNumber {
            get {
                return this.subRequestNumberField;
            }
            set {
                this.subRequestNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public StatusType Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public orgExternalType Originator {
            get {
                return this.originatorField;
            }
            set {
                this.originatorField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public System.DateTime Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string RequestIdRef {
            get {
                return this.requestIdRefField;
            }
            set {
                this.requestIdRefField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string OriginRequestIdRef {
            get {
                return this.originRequestIdRefField;
            }
            set {
                this.originRequestIdRefField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string ServiceCode {
            get {
                return this.serviceCodeField;
            }
            set {
                this.serviceCodeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CaseNumber {
            get {
                return this.caseNumberField;
            }
            set {
                this.caseNumberField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("MessageData", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class MessageDataType {
        
        private AppDataType appDataField;
        
        private AppDocumentType appDocumentField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public AppDataType AppData {
            get {
                return this.appDataField;
            }
            set {
                this.appDataField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public AppDocumentType AppDocument {
            get {
                return this.appDocumentField;
            }
            set {
                this.appDocumentField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("AppData", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class AppDataType {
        
        private System.Xml.XmlElement[] anyField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=0)]
        public System.Xml.XmlElement[] Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("AppDocument", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class AppDocumentType {
        
        private string requestCodeField;
        
        private object[] itemsField;
        
        private ItemsChoiceType[] itemsElementNameField;
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string RequestCode {
            get {
                return this.requestCodeField;
            }
            set {
                this.requestCodeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("BinaryData", typeof(byte[]), DataType="base64Binary", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("DigestValue", typeof(byte[]), DataType="base64Binary", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("Reference", typeof(ReferenceType), Order=1)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order=2)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName {
            get {
                return this.itemsElementNameField;
            }
            set {
                this.itemsElementNameField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("Reference", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class ReferenceType {
        
        private Include includeField;
        
        private string[] textField;
        
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.w3.org/2004/08/xop/include", Order=0)]
        public Include Include {
            get {
                return this.includeField;
            }
            set {
                this.includeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3.org/2004/08/xop/include")]
    public partial class Include {
        
        private System.Xml.XmlElement[] anyField;
        
        private string hrefField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=0)]
        public System.Xml.XmlElement[] Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
        public string href {
            get {
                return this.hrefField;
            }
            set {
                this.hrefField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315", IncludeInSchema=false)]
    public enum ItemsChoiceType {
        
        /// <remarks/>
        BinaryData,
        
        /// <remarks/>
        DigestValue,
        
        /// <remarks/>
        Reference,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("SubMessages", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class SubMessagesType {
        
        private SubMessageType[] subMessageField;
        
        [System.Xml.Serialization.XmlElementAttribute("SubMessage", Order=0)]
        public SubMessageType[] SubMessage {
            get {
                return this.subMessageField;
            }
            set {
                this.subMessageField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("PacketIds", Namespace="http://smev.gosuslugi.ru/rev120315", IsNullable=false)]
    public partial class PacketIdsType {
        
        private PacketIdType[] idField;
        
        [System.Xml.Serialization.XmlElementAttribute("Id", Order=0)]
        public PacketIdType[] Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
}

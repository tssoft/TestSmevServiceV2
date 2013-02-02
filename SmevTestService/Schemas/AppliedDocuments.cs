// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.38967
//    <NameSpace>SMEV</NameSpace><Collection>Array</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net20</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------

using System.Xml;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/request/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute("AppliedDocuments", Namespace="http://smev.gosuslugi.ru/request/rev120315", IsNullable=false)]
    public partial class AppliedDocumentsType {
        
        [XmlNamespaceDeclarations] public XmlSerializerNamespaces _xsns;

        public AppliedDocumentsType()
        {
            _xsns = new XmlSerializerNamespaces(new[]
                                                    {
                                                        new XmlQualifiedName("smev",
                                                                             "http://smev.gosuslugi.ru/request/rev120315")
                                                    });
        }


        private AppliedDocumentType[] appliedDocumentField;
        
        [System.Xml.Serialization.XmlElementAttribute("AppliedDocument", Order=0)]
        public AppliedDocumentType[] AppliedDocument {
            get {
                return this.appliedDocumentField;
            }
            set {
                this.appliedDocumentField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.4.0.38968")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://smev.gosuslugi.ru/request/rev120315")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://smev.gosuslugi.ru/request/rev120315", IsNullable=true)]
    public partial class AppliedDocumentType {
        
        private string codeDocumentField;
        
        private string nameField;
        
        private string numberField;
        
        private string uRLField;
        
        private string typeField;
        
        private byte[] digestValueField;
        
        private string idField;
        
        

        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CodeDocument {
            get {
                return this.codeDocumentField;
            }
            set {
                this.codeDocumentField = value;
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
        
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string URL {
            get {
                return this.uRLField;
            }
            set {
                this.uRLField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=5)]
        public byte[] DigestValue {
            get {
                return this.digestValueField;
            }
            set {
                this.digestValueField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
        public string ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
}

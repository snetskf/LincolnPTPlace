﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
//  
 
namespace WebService.asmx {
    using System.ServiceModel;
    using System.Web.Services;
    using System.Xml.Serialization;
    using System.Web;
    using System.Xml;
    using System.Xml.Schema;
    using System.Web.Services.Protocols;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
   // [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.skf.com/oagis/9")]
  //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  //  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.skf.com/oagis/9", IsNullable = false)]
   [System.Serializable]
  [XmlRoot(ElementName = "gaiaWs",Namespace = "http://www.skf.com/oagis/9")]
    
    public   class gaiaWs {
       // [XmlNamespaceDeclarations]
        //public XmlSerializerNamespaces xmlns
        //{
        //    get
        //    {
        //        XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
        //        xsn.Add("skf9", "http://www.skf.com/oagis/9"); 

        //        return xsn;
        //    }
        //    set
        //    {
        //          /* needed for xml serialization */
        //    }
        //}

        private string xmlContentField;
        
        private string messageTypeField;
        
       // private string messageTypeVersionField;
        
      //  private string senderField;
        
      //  private string transactionIDField;
      

        private object sh;

        [XmlElement(Namespace = "http://www.skf.com/oagis/9")]
        //[XmlElement("xmlContent")]
        public object xmlContent
        {
            get
            {

                return sh;
                // return new System.Xml.XmlDocument().CreateCDataSection(sh as string);

            }
            set
            {
                this.sh = value;
            }
        }


        /// <remarks/>
        //public string xmlContent {
        //    get {
        //        return this.xmlContentField;
        //    }
        //    set {
        //        this.xmlContentField = value;
        //    }
        //} 
        /// <remarks/>
        [XmlElement(Namespace = "http://www.skf.com/oagis/9")]
        public string messageType {
            get {
                return this.messageTypeField;
            }
            set {
                this.messageTypeField = value;
            }
        }
     //   [XmlElement(Namespace = "http://www.skf.com/oagis/9")]
        /// <remarks/>
        //public string messageTypeVersion {
        //    get {
        //        return this.messageTypeVersionField;
        //    }
        //    set {
        //        this.messageTypeVersionField = value;
        //    }
        //}
        //[XmlElement(Namespace = "http://www.skf.com/oagis/9")]
        ///// <remarks/>
        //public string sender {
        //    get {
        //        return this.senderField;
        //    }
        //    set {
        //        this.senderField = value;
        //    }
        //}
        //[XmlElement(Namespace = "http://www.skf.com/oagis/9")]
        ///// <remarks/>
        //public string transactionID {
        //    get {
        //        return this.transactionIDField;
        //    }
        //    set {
        //        this.transactionIDField = value;
        //    }
        //}
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces x = new XmlSerializerNamespaces();
        public gaiaWs() {   x.Add("skf9", "http://www.skf.com/oagis/9"); }
    }
}

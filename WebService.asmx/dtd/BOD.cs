﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class NOUN {
    
    private string valueField;
    
    private string valueField1;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField1;
        }
        set {
            this.valueField1 = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class REVISION {
    
    private string valueField;
    
    private string valueField1;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField1;
        }
        set {
            this.valueField1 = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class USERAREA {
    
    private System.Xml.XmlNode[] anyField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlNode[] Any {
        get {
            return this.anyField;
        }
        set {
            this.anyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class VERB {
    
    private string valueField;
    
    private string valueField1;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField1;
        }
        set {
            this.valueField1 = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class BSR {
    
    private VERB vERBField;
    
    private NOUN nOUNField;
    
    private REVISION rEVISIONField;
    
    /// <remarks/>
    public VERB VERB {
        get {
            return this.vERBField;
        }
        set {
            this.vERBField = value;
        }
    }
    
    /// <remarks/>
    public NOUN NOUN {
        get {
            return this.nOUNField;
        }
        set {
            this.nOUNField = value;
        }
    }
    
    /// <remarks/>
    public REVISION REVISION {
        get {
            return this.rEVISIONField;
        }
        set {
            this.rEVISIONField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class CNTROLAREA {
    
    private BSR bSRField;
    
    private SENDER sENDERField;
    
    private DATETIME dATETIMEField;
    
    /// <remarks/>
    public BSR BSR {
        get {
            return this.bSRField;
        }
        set {
            this.bSRField = value;
        }
    }
    
    /// <remarks/>
    public SENDER SENDER {
        get {
            return this.sENDERField;
        }
        set {
            this.sENDERField = value;
        }
    }
    
    /// <remarks/>
    public DATETIME DATETIME {
        get {
            return this.dATETIMEField;
        }
        set {
            this.dATETIMEField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class SENDER {
    
    private string lOGICALIDField;
    
    private string cOMPONENTField;
    
    private string tASKField;
    
    private string rEFERENCEIDField;
    
    private string cONFIRMATIONField;
    
    private string lANGUAGEField;
    
    private string cODEPAGEField;
    
    private string aUTHIDField;
    
    /// <remarks/>
    public string LOGICALID {
        get {
            return this.lOGICALIDField;
        }
        set {
            this.lOGICALIDField = value;
        }
    }
    
    /// <remarks/>
    public string COMPONENT {
        get {
            return this.cOMPONENTField;
        }
        set {
            this.cOMPONENTField = value;
        }
    }
    
    /// <remarks/>
    public string TASK {
        get {
            return this.tASKField;
        }
        set {
            this.tASKField = value;
        }
    }
    
    /// <remarks/>
    public string REFERENCEID {
        get {
            return this.rEFERENCEIDField;
        }
        set {
            this.rEFERENCEIDField = value;
        }
    }
    
    /// <remarks/>
    public string CONFIRMATION {
        get {
            return this.cONFIRMATIONField;
        }
        set {
            this.cONFIRMATIONField = value;
        }
    }
    
    /// <remarks/>
    public string LANGUAGE {
        get {
            return this.lANGUAGEField;
        }
        set {
            this.lANGUAGEField = value;
        }
    }
    
    /// <remarks/>
    public string CODEPAGE {
        get {
            return this.cODEPAGEField;
        }
        set {
            this.cODEPAGEField = value;
        }
    }
    
    /// <remarks/>
    public string AUTHID {
        get {
            return this.aUTHIDField;
        }
        set {
            this.aUTHIDField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class DATETIME {
    
    private string yEARField;
    
    private string mONTHField;
    
    private string dAYField;
    
    private string hOURField;
    
    private string mINUTEField;
    
    private string sECONDField;
    
    private string sUBSECONDField;
    
    private string tIMEZONEField;
    
    private DATETIMEQualifier qualifierField;
    
    private DATETIMEType typeField;
    
    private bool typeFieldSpecified;
    
    private string indexField;
    
    /// <remarks/>
    public string YEAR {
        get {
            return this.yEARField;
        }
        set {
            this.yEARField = value;
        }
    }
    
    /// <remarks/>
    public string MONTH {
        get {
            return this.mONTHField;
        }
        set {
            this.mONTHField = value;
        }
    }
    
    /// <remarks/>
    public string DAY {
        get {
            return this.dAYField;
        }
        set {
            this.dAYField = value;
        }
    }
    
    /// <remarks/>
    public string HOUR {
        get {
            return this.hOURField;
        }
        set {
            this.hOURField = value;
        }
    }
    
    /// <remarks/>
    public string MINUTE {
        get {
            return this.mINUTEField;
        }
        set {
            this.mINUTEField = value;
        }
    }
    
    /// <remarks/>
    public string SECOND {
        get {
            return this.sECONDField;
        }
        set {
            this.sECONDField = value;
        }
    }
    
    /// <remarks/>
    public string SUBSECOND {
        get {
            return this.sUBSECONDField;
        }
        set {
            this.sUBSECONDField = value;
        }
    }
    
    /// <remarks/>
    public string TIMEZONE {
        get {
            return this.tIMEZONEField;
        }
        set {
            this.tIMEZONEField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public DATETIMEQualifier qualifier {
        get {
            return this.qualifierField;
        }
        set {
            this.qualifierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public DATETIMEType type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool typeSpecified {
        get {
            return this.typeFieldSpecified;
        }
        set {
            this.typeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string index {
        get {
            return this.indexField;
        }
        set {
            this.indexField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
public enum DATETIMEQualifier {
    
    /// <remarks/>
    ACCOUNTING,
    
    /// <remarks/>
    ACTEND,
    
    /// <remarks/>
    ACTSTART,
    
    /// <remarks/>
    APPREQ,
    
    /// <remarks/>
    APPROVAL,
    
    /// <remarks/>
    AVAILABLE,
    
    /// <remarks/>
    BKTEND,
    
    /// <remarks/>
    BKTSTART,
    
    /// <remarks/>
    CANCEL,
    
    /// <remarks/>
    CHANGEDATE,
    
    /// <remarks/>
    COMPDATE,
    
    /// <remarks/>
    CREATION,
    
    /// <remarks/>
    CUMULATIVE,
    
    /// <remarks/>
    DELIVACT,
    
    /// <remarks/>
    DELIVSCHED,
    
    /// <remarks/>
    DISCNT,
    
    /// <remarks/>
    DOCUMENT,
    
    /// <remarks/>
    DUE,
    
    /// <remarks/>
    EARLSTEFF,
    
    /// <remarks/>
    EARLSTSHIP,
    
    /// <remarks/>
    EFFECTIVE,
    
    /// <remarks/>
    ENGCHG,
    
    /// <remarks/>
    EXECFINISH,
    
    /// <remarks/>
    EXECSTART,
    
    /// <remarks/>
    EXPIRATION,
    
    /// <remarks/>
    FAILDATE,
    
    /// <remarks/>
    FORECASTF,
    
    /// <remarks/>
    FORECASTS,
    
    /// <remarks/>
    FROM,
    
    /// <remarks/>
    GENERATION,
    
    /// <remarks/>
    IMPL,
    
    /// <remarks/>
    INVOICE,
    
    /// <remarks/>
    LABORFINSH,
    
    /// <remarks/>
    LABORSTART,
    
    /// <remarks/>
    LASTUSED,
    
    /// <remarks/>
    LOADING,
    
    /// <remarks/>
    MATCHING,
    
    /// <remarks/>
    MSMENTDATE,
    
    /// <remarks/>
    NEEDDELV,
    
    /// <remarks/>
    OPFINISH,
    
    /// <remarks/>
    OPSTART,
    
    /// <remarks/>
    PAYEND,
    
    /// <remarks/>
    PLANEND,
    
    /// <remarks/>
    PLANSTART,
    
    /// <remarks/>
    PO,
    
    /// <remarks/>
    PROMDELV,
    
    /// <remarks/>
    PROMSHIP,
    
    /// <remarks/>
    PYMTTERM,
    
    /// <remarks/>
    RECEIVED,
    
    /// <remarks/>
    REPORTDATE,
    
    /// <remarks/>
    REPORTNGFN,
    
    /// <remarks/>
    REPORTNGST,
    
    /// <remarks/>
    REQUIRED,
    
    /// <remarks/>
    RESORCDWNF,
    
    /// <remarks/>
    RESORCDWNS,
    
    /// <remarks/>
    RSPDDATE,
    
    /// <remarks/>
    RSPDOCGEN,
    
    /// <remarks/>
    SCHEND,
    
    /// <remarks/>
    SCHSTART,
    
    /// <remarks/>
    SETUPFINSH,
    
    /// <remarks/>
    SETUPSTART,
    
    /// <remarks/>
    SHIP,
    
    /// <remarks/>
    SHIPSCHED,
    
    /// <remarks/>
    STATUSDATE,
    
    /// <remarks/>
    TEARDOWNF,
    
    /// <remarks/>
    TEARDOWNS,
    
    /// <remarks/>
    TO,
    
    /// <remarks/>
    OTHER,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("COLINX.CARDEXP")]
    COLINXCARDEXP,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("COLINX.REQUESTED")]
    COLINXREQUESTED,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
public enum DATETIMEType {
    
    /// <remarks/>
    T,
    
    /// <remarks/>
    F,
    
    /// <remarks/>
    OTHER,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class CONFIRM_BOD_003 {
    
    private CNTROLAREA cNTROLAREAField;
    
    private DATAAREA[] dATAAREAField;
    
    /// <remarks/>
    public CNTROLAREA CNTROLAREA {
        get {
            return this.cNTROLAREAField;
        }
        set {
            this.cNTROLAREAField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DATAAREA")]
    public DATAAREA[] DATAAREA {
        get {
            return this.dATAAREAField;
        }
        set {
            this.dATAAREAField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class DATAAREA {
    
    private CONFIRM_BOD cONFIRM_BODField;
    
    /// <remarks/>
    public CONFIRM_BOD CONFIRM_BOD {
        get {
            return this.cONFIRM_BODField;
        }
        set {
            this.cONFIRM_BODField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class CONFIRM_BOD {
    
    private CONFIRM cONFIRMField;
    
    /// <remarks/>
    public CONFIRM CONFIRM {
        get {
            return this.cONFIRMField;
        }
        set {
            this.cONFIRMField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class CONFIRM {
    
    private CNTROLAREA cNTROLAREAField;
    
    private string sTATUSLVLField;
    
    private string dESCRIPTNField;
    
    private string oRIGREFField;
    
    private USERAREA uSERAREAField;
    
    private CONFIRMMSG[] cONFIRMMSGField;
    
    /// <remarks/>
    public CNTROLAREA CNTROLAREA {
        get {
            return this.cNTROLAREAField;
        }
        set {
            this.cNTROLAREAField = value;
        }
    }
    
    /// <remarks/>
    public string STATUSLVL {
        get {
            return this.sTATUSLVLField;
        }
        set {
            this.sTATUSLVLField = value;
        }
    }
    
    /// <remarks/>
    public string DESCRIPTN {
        get {
            return this.dESCRIPTNField;
        }
        set {
            this.dESCRIPTNField = value;
        }
    }
    
    /// <remarks/>
    public string ORIGREF {
        get {
            return this.oRIGREFField;
        }
        set {
            this.oRIGREFField = value;
        }
    }
    
    /// <remarks/>
    public USERAREA USERAREA {
        get {
            return this.uSERAREAField;
        }
        set {
            this.uSERAREAField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CONFIRMMSG")]
    public CONFIRMMSG[] CONFIRMMSG {
        get {
            return this.cONFIRMMSGField;
        }
        set {
            this.cONFIRMMSGField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/colinx_confirm_bod_003")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/colinx_confirm_bod_003", IsNullable=false)]
public partial class CONFIRMMSG {
    
    private string dESCRIPTNField;
    
    private string rEASONCODEField;
    
    private USERAREA uSERAREAField;
    
    /// <remarks/>
    public string DESCRIPTN {
        get {
            return this.dESCRIPTNField;
        }
        set {
            this.dESCRIPTNField = value;
        }
    }
    
    /// <remarks/>
    public string REASONCODE {
        get {
            return this.rEASONCODEField;
        }
        set {
            this.rEASONCODEField = value;
        }
    }
    
    /// <remarks/>
    public USERAREA USERAREA {
        get {
            return this.uSERAREAField;
        }
        set {
            this.uSERAREAField = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XmlConfiguration;
using WebService.asmx.Classes;
using System.Xml.Linq;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml.Schema;
using WebService.asmx.Response;
using WebService.asmx.BOD;
using WebService.asmx.showPriceList;

namespace WebService.asmx
{

    /// <summary>
    /// Summary description for LincolnWeb
    /// </summary>
    [WebService(Namespace = "http://www.skf.com/oagis/9/")]

    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LincolnWeb : System.Web.Services.WebService
    {
        private readonly Encoding encoding;
        [WebMethod(EnableSession = true)]
        [return: XmlElement(Namespace = "http://www.skf.com/oagis/9/", IsNullable = true)]
        public XmlDocument GetHostPing(gaiaWs xmlstring)
        {
            string[] MessageTypeArray = new string[10];

            MessageTypeArray[0] = "XC27"; MessageTypeArray[1] = "XC29"; MessageTypeArray[2] = "XC31";
            MessageTypeArray[3] = "XC33"; MessageTypeArray[4] = "XC39"; MessageTypeArray[5] = "XC41";

            bool msgTyperesult = MessageTypeArray.Contains(xmlstring.messageType);

            var getshowshostpingresult = SHOW_HOSTPING_001(xmlstring.xmlContent, xmlstring.messageType, "", "", "0");


            gaiaWs g = new gaiaWs();

            var x = SerializeObjectToXml(getshowshostpingresult);

            if (getshowshostpingresult.CNTROLAREA == null)
            {
                var BOD = ConfirmBODHostPing(xmlstring.xmlContent, xmlstring.messageType, "", "", "0", "HostPing", Session["Errmsg"].ToString());
                x = SerializeObjectToXml(BOD);
                g.messageType = "XC41";
            }
            else
            {
                x = SerializeObjectToXml(getshowshostpingresult);
                g.messageType = "XC40";
            }

            XmlCDataSection xc;
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(x);
            xc = xdoc.CreateCDataSection(x);

            Content = x;
            g.xmlContent = CDataContent;
            var x1 = SerializeObjectToXml(g);

            g.messageType = "";
            XmlDocument dd = new XmlDocument();

            XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
            dd.InsertBefore(docNode, root);
            dd.AppendChild(docNode); dd.LoadXml(x1);

            return dd;
        }


        [WebMethod(EnableSession = true)]
        [return: XmlElement(Namespace = "http://www.skf.com/oagis/9/", IsNullable = true)]
        public XmlDocument GetListSalesOrder(gaiaWs xmlstring)
        {
            Session["Errmsg"] = "";
            var getlistsalesorderresult = SHOW_LISTSALESORDER_005(xmlstring.xmlContent, xmlstring.messageType, "", "", "0");

            gaiaWs g = new gaiaWs(); var x = "";

            if (getlistsalesorderresult.CNTROLAREA == null)
            {
                var BOD = ConfirmBODGetListSalesOrder(xmlstring.xmlContent, xmlstring.messageType, "", "", "0", "GetListSalesOrder", Session["Errmsg"].ToString());
                x = SerializeObjectToXml(BOD);
                g.messageType = "XC41";
            }
            else
            {
                x = SerializeObjectToXml(getlistsalesorderresult); g.messageType = "XC32";
            }

            XmlCDataSection xc;
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(x);
            xc = xdoc.CreateCDataSection(x);

            Content = x;
            g.xmlContent = CDataContent;


            var x1 = SerializeObjectToXml(g);

            g.messageType = "";
            //return g;
            XmlDocument dd = new XmlDocument();

            XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
            dd.InsertBefore(docNode, root);
            dd.AppendChild(docNode); dd.LoadXml(x1);

            return dd;
        }

        [WebMethod(EnableSession = true)]
        [return: XmlElement(Namespace = "http://www.skf.com/oagis/9/", IsNullable = true)]
        public XmlDocument GetSalesOrder(gaiaWs xmlstring)
        {
            Session["Errmsg"] = "";
            var getsalesorderresult = SHOW_SALESORDER_005(xmlstring.xmlContent, xmlstring.messageType, "", "", "0");

            gaiaWs g = new gaiaWs(); var x = "";

            if (getsalesorderresult.CNTROLAREA == null)
            {
                var BOD = ConfirmBODGetSalesOrder(xmlstring.xmlContent, xmlstring.messageType, "", "", "0", "GetSalesOrder", Session["Errmsg"].ToString());
                x = SerializeObjectToXml(BOD);
                g.messageType = "XC41";
            }
            else
            {
                x = SerializeObjectToXml(getsalesorderresult); g.messageType = "XC34";
            }

            XmlCDataSection xc;
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(x);
            xc = xdoc.CreateCDataSection(x);

            Content = x;
            g.xmlContent = CDataContent;


            var x1 = SerializeObjectToXml(g);

            g.messageType = "";
            //return g;
            XmlDocument dd = new XmlDocument();

            XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
            dd.InsertBefore(docNode, root);
            dd.AppendChild(docNode); dd.LoadXml(x1);

            return dd;
        }



        [WebMethod(EnableSession = true)]
        [return: XmlElement(Namespace = "http://www.skf.com/oagis/9/", IsNullable = true)]
        public XmlDocument ProcessPO(gaiaWs xmlstring)
        {
            Session["Errmsg"] = "";
            var getsalesorderresult = ACKNOWLEDGE_PO_006(xmlstring.xmlContent, xmlstring.messageType, "", "", "0");

            gaiaWs g = new gaiaWs(); var x = "";

            if (getsalesorderresult.CNTROLAREA == null)
            {
                var BOD = ConfirmBODAckPO(xmlstring.xmlContent, xmlstring.messageType, "", "", "0", "GetSalesOrder", Session["Errmsg"].ToString());
                x = SerializeObjectToXml(BOD);
                g.messageType = "XC41";
            }
            else
            {
                x = SerializeObjectToXml(getsalesorderresult); g.messageType = "XC30";
            }

            XmlCDataSection xc;
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(x);
            xc = xdoc.CreateCDataSection(x);

            Content = x;
            g.xmlContent = CDataContent;


            var x1 = SerializeObjectToXml(g);

            g.messageType = "";
            //return g;
            XmlDocument dd = new XmlDocument();

            XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
            dd.InsertBefore(docNode, root);
            dd.AppendChild(docNode); dd.LoadXml(x1);

            return dd;
        }

        public CONFIRM_BOD_003 ConfirmBODHostPing(object getxml, string MsgType, string MsgTypeVersion, string Sender, string TransID, string CallType, string ErrMsg = null)
        {
            var xmlstring = ((System.Xml.XmlNode[])getxml)[0].Value.ToString();

            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            XmlSerializer serializer = new XmlSerializer(typeof(GET_HOSTPING_001));


            var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment, IgnoreWhitespace = true, IgnoreComments = true };

            var sw = new StringReader(xmlstring);
            var sw1 = new StringReader(xmlstring);



            using (XmlTextReader reader1 = new XmlTextReader(sw))
            {
                reader1.DtdProcessing = DtdProcessing.Ignore;
                while (reader1.Read())
                {

                    switch (reader1.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            Console.Write("<" + reader1.Name);

                            Console.WriteLine(">");
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            Console.WriteLine(reader1.Value);
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.
                            Console.Write("</" + reader1.Name);
                            Console.WriteLine(">");
                            break;
                    }
                }
            }
            GET_HOSTPING_001 resultingMessage = (GET_HOSTPING_001)new XmlSerializer(typeof(GET_HOSTPING_001)).Deserialize(sw1);

            SHOW_HOSTPING_001 objshowhostping = new SHOW_HOSTPING_001();
            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;
            Guid Mainguid = Guid.NewGuid();
            var guid = Mainguid.ToString();
            //   var guid = new Guid();
            if (ErrMsg != "")
            {
                guid = ErrMsg;
            }
            else { guid = Mainguid.ToString(); }

            using (SqlConnection con = new SqlConnection(cs))
            {
                //   var guid = new Guid();

                SqlCommand SQLXMLHeader = new SqlCommand();
                SQLXMLHeader.Connection = con;
                con.Open();
                SQLXMLHeader.CommandText = "InsertXMLHeader";
                SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                SQLXMLHeader.ExecuteNonQuery();

                //control area
                SqlCommand SQLControlAra = new SqlCommand();
                SQLControlAra.Connection = con;
                SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                SQLControlAra.CommandType = CommandType.StoredProcedure;
                SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                SQLControlAra.Parameters["@TransId"].Value = TransID;
                SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                SQLControlAra.ExecuteNonQuery();


                //data area 
                SqlCommand SQLDataArea = new SqlCommand();
                SQLDataArea.Connection = con;

                SQLDataArea.CommandText = "SP_GetHostpingDataArea";
                SQLDataArea.CommandType = CommandType.StoredProcedure;

                SQLDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLDataArea.Parameters.Add("@DataArea_GetHostPing_ColinxHostid", SqlDbType.NVarChar, 50);
                SQLDataArea.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);

                for (int k = 0; k < resultingMessage.DATAAREA.Length; k++)
                {
                    SQLDataArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLDataArea.Parameters["@Tranid"].Value = TransID;
                    SQLDataArea.Parameters["@DataArea_GetHostPing_ColinxHostid"].Value = resultingMessage.DATAAREA[k].GETHOSTPING.COLINX_HOSTID.ToString(); ;
                    SQLDataArea.ExecuteNonQuery();

                }

                //return show host ping
                SqlCommand SQLShowControlArea = new SqlCommand();
                SQLShowControlArea.Connection = con;

                SQLShowControlArea.CommandText = "sp_ShowHostPingDataControlArea";
                SQLShowControlArea.CommandType = CommandType.StoredProcedure;

                SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                SQLShowControlArea.Parameters["@TransId"].Value = TransID;
                var x1 = new CONFIRM_BOD_003();
                var iserror = "N";

                using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                {

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr[1].ToString() == "BOD")
                            {
                                iserror = "Y";

                                x1 = new CONFIRM_BOD_003()
                                {
                                    CNTROLAREA = new BOD.CNTROLAREA()
                                    {
                                        BSR = new BOD.BSR()
                                        {
                                            VERB = new BOD.VERB() { Value = dr[0].ToString() },
                                            NOUN = new BOD.NOUN()
                                            {
                                                Value = dr[1].ToString()
                                            },
                                            REVISION = new BOD.REVISION() { Value = dr[2].ToString() }
                                        },
                                        SENDER = new BOD.SENDER()
                                        {
                                            LOGICALID = dr[3].ToString(),
                                            COMPONENT = dr[4].ToString(),
                                            TASK = dr[5].ToString(),
                                            REFERENCEID = dr[6].ToString(),
                                            CONFIRMATION = dr[7].ToString(),
                                            LANGUAGE = dr[8].ToString(),
                                            CODEPAGE = dr[9].ToString(),
                                            AUTHID = dr["Sender_Authid"].ToString()

                                        },
                                        DATETIME = new BOD.DATETIME()
                                        {
                                            qualifier = BOD.DATETIMEQualifier.CREATION,
                                            YEAR = dr[11].ToString(),
                                            MONTH = dr[12].ToString(),
                                            DAY = dr[13].ToString()
                                                                       ,
                                            HOUR = dr[14].ToString(),
                                            MINUTE = dr[15].ToString(),
                                            SECOND = dr[16].ToString(),
                                            SUBSECOND = dr[17].ToString(),
                                            TIMEZONE = dr[18].ToString()
                                        }
                                    }
                                };

                            }
                            else
                            {
                            }
                        }
                    }
                }


                //showhostping data area
                SqlCommand SQLShowDataArea = new SqlCommand();
                SQLShowDataArea.Connection = con;

                SQLShowDataArea.CommandText = "sp_ShowHostPingDataArea";
                SQLShowDataArea.CommandType = CommandType.StoredProcedure;

                SQLShowDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLShowDataArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLShowDataArea.Parameters["@GUID"].Value = guid.ToString();
                SQLShowDataArea.Parameters["@TransId"].Value = TransID;

                if (iserror == "Y")
                {

                    using (SqlDataReader drbod = SQLShowDataArea.ExecuteReader())
                    {
                        if (drbod.HasRows)
                        {
                            DataTable dt = new DataTable(); dt.Load(drbod);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                BOD.DATAAREA[] dx1 = new BOD.DATAAREA[1];
                                dx1[0] = new BOD.DATAAREA();
                                dx1[0].CONFIRM_BOD = new CONFIRM_BOD();
                                dx1[0].CONFIRM_BOD.CONFIRM = new CONFIRM();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA = new BOD.CNTROLAREA();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR = new BOD.BSR();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN = new BOD.NOUN();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN.Value = dt.Rows[i]["BSR_NOUN"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB = new BOD.VERB();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB.Value = dt.Rows[i]["BSR_Verb"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION = new BOD.REVISION();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION.Value = dt.Rows[i]["BSR_Revision"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER = new BOD.SENDER();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LOGICALID = dt.Rows[i]["Sender_LogicalId"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.COMPONENT = dt.Rows[i]["Sender_Component"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.TASK = dt.Rows[i]["Sender_Task"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.REFERENCEID = dt.Rows[i]["Sender_Referenceid"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CONFIRMATION = dt.Rows[i]["Sender_Confirmation"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LANGUAGE = dt.Rows[i]["Sender_Language"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CODEPAGE = dt.Rows[i]["Sender_Codepage"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.AUTHID = dt.Rows[i]["Sender_Authid"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME = new BOD.DATETIME();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.qualifier = BOD.DATETIMEQualifier.CREATION;
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.YEAR = dt.Rows[i]["DateTime_Year"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MONTH = dt.Rows[i]["DateTime_Month"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.DAY = dt.Rows[i]["DateTime_Day"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.HOUR = dt.Rows[i]["DateTime_Hour"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MINUTE = dt.Rows[i]["DateTime_Minute"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SECOND = dt.Rows[i]["DateTime_Second"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SUBSECOND = dt.Rows[i]["DateTime_Subsecond"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.TIMEZONE = dt.Rows[i]["DateTime_Timezone"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.STATUSLVL = dt.Rows[i]["StatusLVL"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.DESCRIPTN = dt.Rows[i]["Description"].ToString();
                                BOD.CONFIRMMSG cnmsg = new CONFIRMMSG();

                                cnmsg.DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                cnmsg.REASONCODE = dt.Rows[i]["ReasonCode"].ToString();

                                CONFIRMMSG[] d1 = new CONFIRMMSG[1];
                                d1[0] = new CONFIRMMSG();
                                d1[0].DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                d1[0].REASONCODE = dt.Rows[i]["ReasonCode"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CONFIRMMSG = d1;
                                x1.DATAAREA = dx1;
                            }

                        }
                    }
                }

                // return x;
                if (iserror == "Y")
                {
                    CONFIRM_BOD_003 cb = new CONFIRM_BOD_003();
                    var xbod = SerializeObjectToXml(x1);
                    XmlDocument dd = new XmlDocument();

                    XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
                    dd.InsertBefore(docNode, root);
                    dd.AppendChild(docNode); dd.LoadXml(xbod);
                    return x1;
                    // return dd;
                }
                else
                {
                    return x1;
                }

            }

        }

        public CONFIRM_BOD_003 ConfirmBODAckPO(object getxml, string MsgType, string MsgTypeVersion, string Sender, string TransID, string CallType, string ErrMsg = null)
        {
            var xmlstring = ((System.Xml.XmlNode[])getxml)[0].Value.ToString();


            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;
            var msg = checkxml(xmlstring, "ProcessPO");

            Guid guid = Guid.NewGuid();



            var getPOread = new StringReader(xmlstring.Trim());

            processpo.PROCESS_PO_006 resultingMessage = (processpo.PROCESS_PO_006)new XmlSerializer(typeof(processpo.PROCESS_PO_006)).Deserialize(getPOread);

            using (SqlConnection con = new SqlConnection(cs))
            {
                //   var guid = new Guid();

                SqlCommand SQLXMLHeader = new SqlCommand();
                SQLXMLHeader.Connection = con;
                con.Open();
                SQLXMLHeader.CommandText = "InsertXMLHeader";
                SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                SQLXMLHeader.ExecuteNonQuery();

                //control area
                SqlCommand SQLControlAra = new SqlCommand();
                SQLControlAra.Connection = con;
                SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                SQLControlAra.CommandType = CommandType.StoredProcedure;
                SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                SQLControlAra.Parameters["@TransId"].Value = TransID;
                SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                SQLControlAra.ExecuteNonQuery();

                SqlCommand SQLProcessPO = new SqlCommand();
                SQLProcessPO.Connection = con;
                SQLProcessPO.CommandText = "sp_InsertProcessPO";
                SQLProcessPO.CommandType = CommandType.StoredProcedure;
                SQLProcessPO.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLProcessPO.Parameters.Add("@POID", SqlDbType.NVarChar, 100);
                SQLProcessPO.Parameters.Add("@POType", SqlDbType.NVarChar, 50);
                SQLProcessPO.Parameters.Add("@Notes", SqlDbType.NVarChar, 500);
                SQLProcessPO.Parameters.Add("@AckRequest", SqlDbType.NVarChar, 5);
                SQLProcessPO.Parameters.Add("@OrdTransId", SqlDbType.NVarChar, 50);
                SQLProcessPO.Parameters.Add("@shipInstr_OrderType", SqlDbType.NVarChar, 20);
                SQLProcessPO.Parameters.Add("@ShipInstr_FrtBillType", SqlDbType.NVarChar, 30);
                SQLProcessPO.Parameters.Add("@ShipInstr_Deviateflg", SqlDbType.NVarChar, 5);
                SQLProcessPO.Parameters.Add("@ShipInstr_PartShip", SqlDbType.NVarChar, 5);
                SQLProcessPO.Parameters.Add("@Division", SqlDbType.NVarChar, 50);
                SQLProcessPO.Parameters.Add("@ShipInstr_FrtAccount", SqlDbType.NVarChar, 20);

                SQLProcessPO.Parameters["@GUID"].Value = guid.ToString();
                SQLProcessPO.Parameters["@POType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POTYPE ?? DBNull.Value;
                SQLProcessPO.Parameters["@POID"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POID ?? DBNull.Value;
                SQLProcessPO.Parameters["@Notes"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.NOTES ?? DBNull.Value;
                SQLProcessPO.Parameters["@AckRequest"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.ACKREQUEST ?? DBNull.Value;
                SQLProcessPO.Parameters["@OrdTransId"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_ORDTRANSID ?? DBNull.Value;
                SQLProcessPO.Parameters["@shipInstr_OrderType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_ORDERTYPE ?? DBNull.Value;
                SQLProcessPO.Parameters["@ShipInstr_FrtBillType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_FRTBILLTYPE ?? DBNull.Value;
                SQLProcessPO.Parameters["@ShipInstr_Deviateflg"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_DEVIATEFLG ?? DBNull.Value;
                SQLProcessPO.Parameters["@ShipInstr_PartShip"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_PARTSHIP ?? DBNull.Value;
                SQLProcessPO.Parameters["@Division"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_DIVISION ?? DBNull.Value;
                SQLProcessPO.Parameters["@ShipInstr_FrtAccount"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_FRTACCTNUM ?? DBNull.Value;

                SQLProcessPO.ExecuteNonQuery();
                //add partner//

                SqlCommand SQLPOPartner = new SqlCommand();
                SQLPOPartner.Connection = con;
                SQLPOPartner.CommandText = "sp_InsertPOPartner";
                SQLPOPartner.CommandType = CommandType.StoredProcedure;
                SQLPOPartner.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLPOPartner.Parameters.Add("@Partner", SqlDbType.NVarChar, 50);
                SQLPOPartner.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                SQLPOPartner.Parameters.Add("@PartnerType", SqlDbType.NVarChar, 20);
                SQLPOPartner.Parameters.Add("@AddrType", SqlDbType.NVarChar, 20);
                SQLPOPartner.Parameters.Add("@Addr1", SqlDbType.NVarChar, 100);
                SQLPOPartner.Parameters.Add("@Addr2", SqlDbType.NVarChar, 100);
                SQLPOPartner.Parameters.Add("@Addr3", SqlDbType.NVarChar, 100);
                SQLPOPartner.Parameters.Add("@City", SqlDbType.NVarChar, 50);
                SQLPOPartner.Parameters.Add("@Country", SqlDbType.NVarChar, 20);
                SQLPOPartner.Parameters.Add("@Description", SqlDbType.NVarChar, 100);
                SQLPOPartner.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 20);
                SQLPOPartner.Parameters.Add("@State", SqlDbType.NVarChar, 20);

                for (int i = 0; i < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER.Length; i++)
                {

                    if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS == null)
                    {
                        SQLPOPartner.Parameters["@GUID"].Value = guid.ToString();
                        SQLPOPartner.Parameters["@Partner"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRID ?? DBNull.Value;
                        SQLPOPartner.Parameters["@Name"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].NAME.Value ?? DBNull.Value;
                        SQLPOPartner.Parameters["@PartnerType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRTYPE ?? DBNull.Value;
                        SQLPOPartner.ExecuteNonQuery();
                    }

                    if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS != null)
                    {
                        for (int j = 0; j < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS.Length; j++)
                        {
                            SQLPOPartner.Parameters["@GUID"].Value = guid.ToString();
                            SQLPOPartner.Parameters["@Partner"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRID ?? DBNull.Value;
                            SQLPOPartner.Parameters["@Name"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].NAME.Value ?? DBNull.Value;
                            SQLPOPartner.Parameters["@PartnerType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRTYPE ?? DBNull.Value;

                            SQLPOPartner.Parameters["@AddrType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRTYPE ?? DBNull.Value;
                            if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE.Length >= 1)
                            {
                                if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[0] != null)
                                {
                                    SQLPOPartner.Parameters["@Addr1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[0].Value ?? DBNull.Value;
                                }
                                else { SQLPOPartner.Parameters["@Addr1"].Value = ""; }
                            }

                            if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE.Length >= 2)
                            {
                                if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[1] != null)
                                {
                                    SQLPOPartner.Parameters["@Addr2"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[1].Value ?? DBNull.Value;
                                }
                                else { SQLPOPartner.Parameters["@Addr2"].Value = ""; }
                            }
                            if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE.Length >= 3)
                            {
                                if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[2] != null)
                                {
                                    SQLPOPartner.Parameters["@Addr3"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[2].Value ?? DBNull.Value;
                                }
                                else { SQLPOPartner.Parameters["@Addr3"].Value = ""; }
                            }
                            SQLPOPartner.Parameters["@City"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].CITY ?? DBNull.Value;
                            SQLPOPartner.Parameters["@Country"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].COUNTRY ?? DBNull.Value;
                            SQLPOPartner.Parameters["@Description"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].DESCRIPTN ?? DBNull.Value;
                            SQLPOPartner.Parameters["@ZipCode"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].POSTALCODE ?? DBNull.Value;
                            SQLPOPartner.Parameters["@State"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].STATEPROVN ?? DBNull.Value;

                            SQLPOPartner.ExecuteNonQuery();
                        }
                    }
                }

                SqlCommand SQLPOContact = new SqlCommand();
                SQLPOContact.Connection = con;
                SQLPOContact.CommandText = "sp_InsertPOContact";
                SQLPOContact.CommandType = CommandType.StoredProcedure;
                SQLPOContact.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLPOContact.Parameters.Add("@Partner", SqlDbType.NVarChar, 50);
                SQLPOContact.Parameters.Add("@PartnerType", SqlDbType.NVarChar, 20);
                SQLPOContact.Parameters.Add("@Contact", SqlDbType.NVarChar, 100);
                SQLPOContact.Parameters.Add("@ContactType", SqlDbType.NVarChar, 30);
                SQLPOContact.Parameters.Add("@ContactEmail", SqlDbType.NVarChar, 100);
                SQLPOContact.Parameters.Add("@Phone", SqlDbType.NVarChar, 50);
                SQLPOContact.Parameters.Add("@Fax", SqlDbType.NVarChar, 50);
                SQLPOContact.Parameters.Add("@Name1", SqlDbType.NVarChar, 100);


                for (int i = 0; i < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER.Length; i++)
                {
                    if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT != null)
                    {
                        for (int j = 0; j < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT.Length; j++)
                        {
                            SQLPOContact.Parameters["@GUID"].Value = guid.ToString();
                            SQLPOContact.Parameters["@Partner"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRID ?? DBNull.Value;
                            SQLPOContact.Parameters["@PartnerType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRTYPE ?? DBNull.Value;
                            SQLPOContact.Parameters["@Contact"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].NAME.Value ?? DBNull.Value;
                            SQLPOContact.Parameters["@ContactType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].CONTCTTYPE ?? DBNull.Value;
                            SQLPOContact.Parameters["@ContactEmail"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].EMAIL ?? DBNull.Value;
                            SQLPOContact.Parameters["@Phone"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].TELEPHONE ?? DBNull.Value;
                            SQLPOContact.Parameters["@Fax"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].FAX ?? DBNull.Value;
                            SQLPOContact.Parameters["@Name1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].NAME1 ?? DBNull.Value;
                            SQLPOContact.ExecuteNonQuery();
                        }
                    }
                }

                //insert line
                SqlCommand SQLPOLine = new SqlCommand();
                SQLPOLine.Connection = con;
                SQLPOLine.CommandText = "sp_InsertPOLine";
                SQLPOLine.CommandType = CommandType.StoredProcedure;
                SQLPOLine.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLPOLine.Parameters.Add("@QtyQualifier", SqlDbType.NVarChar, 50);
                SQLPOLine.Parameters.Add("@Qty", SqlDbType.NVarChar, 10);
                SQLPOLine.Parameters.Add("@QtyDec", SqlDbType.NVarChar, 5);
                SQLPOLine.Parameters.Add("@QtySign", SqlDbType.NVarChar, 3);
                SQLPOLine.Parameters.Add("@QtyUOM", SqlDbType.NVarChar, 5);
                SQLPOLine.Parameters.Add("@DateQualifier1", SqlDbType.NVarChar, 50);
                SQLPOLine.Parameters.Add("@Year1", SqlDbType.NVarChar, 10);
                SQLPOLine.Parameters.Add("@Month1", SqlDbType.NVarChar, 3);
                SQLPOLine.Parameters.Add("@Day1", SqlDbType.NVarChar, 3);
                SQLPOLine.Parameters.Add("@DateQualifier2", SqlDbType.NVarChar, 50);
                SQLPOLine.Parameters.Add("@Year2", SqlDbType.NVarChar, 10);
                SQLPOLine.Parameters.Add("@Month2", SqlDbType.NVarChar, 3);
                SQLPOLine.Parameters.Add("@Day2", SqlDbType.NVarChar, 3);
                SQLPOLine.Parameters.Add("@DateQualifier3", SqlDbType.NVarChar, 50);
                SQLPOLine.Parameters.Add("@Year3", SqlDbType.NVarChar, 10);
                SQLPOLine.Parameters.Add("@Month3", SqlDbType.NVarChar, 3);
                SQLPOLine.Parameters.Add("@Day3", SqlDbType.NVarChar, 3);
                SQLPOLine.Parameters.Add("@LineNum", SqlDbType.NVarChar, 5);
                SQLPOLine.Parameters.Add("@Packing", SqlDbType.NVarChar, 10);
                SQLPOLine.Parameters.Add("@PartType", SqlDbType.NVarChar, 50);
                SQLPOLine.Parameters.Add("@PartNo", SqlDbType.NVarChar, 50);
                SQLPOLine.Parameters.Add("@PartClass", SqlDbType.NVarChar, 10);
                SQLPOLine.Parameters.Add("@PartKey", SqlDbType.NVarChar, 50);
                SQLPOLine.Parameters.Add("@PartQual", SqlDbType.NVarChar, 50);
                SQLPOLine.Parameters.Add("@SiteLevel", SqlDbType.NVarChar, 50);
                SQLPOLine.Parameters.Add("@ItemType", SqlDbType.NVarChar, 50);

                for (int i = 0; i < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN.Length; i++)
                {
                    for (int j = 0; j < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY.Length; j++)
                    {
                        SQLPOLine.Parameters["@GUID"].Value = guid.ToString();
                        SQLPOLine.Parameters["@QtyQualifier"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].qualifier ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@Qty"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].VALUE ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@QtyDec"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].NUMOFDEC ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@QtySign"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].SIGN ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@QtyUOM"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].UOM ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@DateQualifier1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].DATETIME.qualifier ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@Year1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].DATETIME.YEAR ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@Month1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].DATETIME.MONTH ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@Day1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].DATETIME.DAY ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@LineNum"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].POLINENUM ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@Packing"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PACKING ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@PartType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTTYPE ?? DBNull.Value; ;
                        SQLPOLine.Parameters["@PartNo"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTNO ?? DBNull.Value;
                        SQLPOLine.Parameters["@PartClass"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTCLASS ?? DBNull.Value;
                        SQLPOLine.Parameters["@PartKey"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTKEY ?? DBNull.Value;
                        SQLPOLine.Parameters["@PartQual"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTQUAL ?? DBNull.Value;
                        SQLPOLine.Parameters["@SiteLevel"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].POORDERLIN_USERAREA.SITELEVEL.Value ?? DBNull.Value;
                        SQLPOLine.Parameters["@ItemType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].POORDERLIN_USERAREA.ITEMTYPE ?? DBNull.Value;

                        SQLPOLine.ExecuteNonQuery();
                    }
                }
                //return data
                SqlCommand SQLShowControlArea = new SqlCommand();
                SQLShowControlArea.Connection = con;

                SQLShowControlArea.CommandText = "sp_AckPOControlArea";
                SQLShowControlArea.CommandType = CommandType.StoredProcedure;

                SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                SQLShowControlArea.Parameters["@TransId"].Value = TransID;
                var x1 = new CONFIRM_BOD_003();

                var iserror = "N";

                using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                {

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr[1].ToString() == "BOD")
                            {
                                iserror = "Y";

                                x1 = new CONFIRM_BOD_003()
                                {
                                    CNTROLAREA = new BOD.CNTROLAREA()
                                    {
                                        BSR = new BOD.BSR()
                                        {
                                            VERB = new BOD.VERB() { Value = dr[0].ToString() },
                                            NOUN = new BOD.NOUN()
                                            {
                                                Value = dr[1].ToString()
                                            },
                                            REVISION = new BOD.REVISION() { Value = dr[2].ToString() }
                                        },
                                        SENDER = new BOD.SENDER()
                                        {
                                            LOGICALID = dr[3].ToString(),
                                            COMPONENT = dr[4].ToString(),
                                            TASK = dr[5].ToString(),
                                            REFERENCEID = dr[6].ToString(),
                                            CONFIRMATION = dr[7].ToString(),
                                            LANGUAGE = dr[8].ToString(),
                                            CODEPAGE = dr[9].ToString(),
                                            AUTHID = dr["Sender_Authid"].ToString()

                                        },
                                        DATETIME = new BOD.DATETIME()
                                        {
                                            qualifier = BOD.DATETIMEQualifier.CREATION,
                                            YEAR = dr[11].ToString(),
                                            MONTH = dr[12].ToString(),
                                            DAY = dr[13].ToString()
                                                                       ,
                                            HOUR = dr[14].ToString(),
                                            MINUTE = dr[15].ToString(),
                                            SECOND = dr[16].ToString(),
                                            SUBSECOND = dr[17].ToString(),
                                            TIMEZONE = dr[18].ToString()
                                        }
                                    }
                                };


                            }
                            else { }
                        }
                    }
                }


                SqlCommand SQLAckPO = new SqlCommand();
                SQLAckPO.Connection = con;
                SQLAckPO.CommandText = "sp_ShowAckPODataArea";
                SQLAckPO.CommandType = CommandType.StoredProcedure;
                SQLAckPO.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLAckPO.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLAckPO.Parameters["@GUID"].Value = guid.ToString();
                SQLAckPO.Parameters["@TransId"].Value = "0";

                if (iserror == "Y")
                {

                    using (SqlDataReader drbod = SQLAckPO.ExecuteReader())
                    {
                        if (drbod.HasRows)
                        {
                            DataTable dt = new DataTable(); dt.Load(drbod);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                BOD.DATAAREA[] dx1 = new BOD.DATAAREA[1];
                                dx1[0] = new BOD.DATAAREA();
                                dx1[0].CONFIRM_BOD = new CONFIRM_BOD();
                                dx1[0].CONFIRM_BOD.CONFIRM = new CONFIRM();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA = new BOD.CNTROLAREA();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR = new BOD.BSR();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN = new BOD.NOUN();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN.Value = dt.Rows[i]["BSR_NOUN"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB = new BOD.VERB();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB.Value = dt.Rows[i]["BSR_Verb"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION = new BOD.REVISION();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION.Value = dt.Rows[i]["BSR_Revision"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER = new BOD.SENDER();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LOGICALID = dt.Rows[i]["Sender_LogicalId"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.COMPONENT = dt.Rows[i]["Sender_Component"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.TASK = dt.Rows[i]["Sender_Task"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.REFERENCEID = dt.Rows[i]["Sender_Referenceid"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CONFIRMATION = dt.Rows[i]["Sender_Confirmation"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LANGUAGE = dt.Rows[i]["Sender_Language"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CODEPAGE = dt.Rows[i]["Sender_Codepage"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.AUTHID = dt.Rows[i]["Sender_Authid"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME = new BOD.DATETIME();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.qualifier = BOD.DATETIMEQualifier.CREATION;
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.YEAR = dt.Rows[i]["DateTime_Year"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MONTH = dt.Rows[i]["DateTime_Month"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.DAY = dt.Rows[i]["DateTime_Day"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.HOUR = dt.Rows[i]["DateTime_Hour"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MINUTE = dt.Rows[i]["DateTime_Minute"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SECOND = dt.Rows[i]["DateTime_Second"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SUBSECOND = dt.Rows[i]["DateTime_Subsecond"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.TIMEZONE = dt.Rows[i]["DateTime_Timezone"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.STATUSLVL = dt.Rows[i]["StatusLVL"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.DESCRIPTN = dt.Rows[i]["Description"].ToString();
                                BOD.CONFIRMMSG cnmsg = new CONFIRMMSG();

                                cnmsg.DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                cnmsg.REASONCODE = dt.Rows[i]["ReasonCode"].ToString();

                                CONFIRMMSG[] d1 = new CONFIRMMSG[1];
                                d1[0] = new CONFIRMMSG();
                                d1[0].DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                d1[0].REASONCODE = dt.Rows[i]["ReasonCode"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CONFIRMMSG = d1;
                                x1.DATAAREA = dx1;
                            }

                        }
                    }
                }

                // return x;
                if (iserror == "Y")
                {
                    CONFIRM_BOD_003 cb = new CONFIRM_BOD_003();
                    var xbod = SerializeObjectToXml(x1);
                    XmlDocument dd = new XmlDocument();

                    XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
                    dd.InsertBefore(docNode, root);
                    dd.AppendChild(docNode); dd.LoadXml(xbod);
                    return x1;
                    // return dd;
                }
                else
                {
                    return x1;
                }
            }

        }
        public CONFIRM_BOD_003 ConfirmBODGetPriceList(object getpricelist, string MsgType, string MsgTypeVersion, string Sender, string TransID, string CallType, string ErrMsg = null)

        {
            SHOW_PRICELIST_002 sp = new SHOW_PRICELIST_002();

            var xmlstring = ((System.Xml.XmlNode[])getpricelist)[0].Value.ToString();

            var getpricelistread = new StringReader(xmlstring.Trim());


            getPriceList.GET_PRICELIST_002 resultingMessage = (getPriceList.GET_PRICELIST_002)new XmlSerializer(typeof(getPriceList.GET_PRICELIST_002)).Deserialize(getpricelistread);

            Guid Mainguid = Guid.NewGuid();
            var guid = Mainguid.ToString();
            //   var guid = new Guid();
            if (ErrMsg != "")
            {
                guid = ErrMsg;
            }
            else { guid = Mainguid.ToString(); }
            //Load data into sql
            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                //   var guid = new Guid();

                SqlCommand SQLXMLHeader = new SqlCommand();
                SQLXMLHeader.Connection = con;
                con.Open();
                SQLXMLHeader.CommandText = "InsertXMLHeader";
                SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                SQLXMLHeader.ExecuteNonQuery();

                //control area
                SqlCommand SQLControlAra = new SqlCommand();
                SQLControlAra.Connection = con;
                SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                SQLControlAra.CommandType = CommandType.StoredProcedure;
                SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                SQLControlAra.Parameters["@TransId"].Value = TransID;
                SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                SQLControlAra.ExecuteNonQuery();


                //data area
                SqlCommand SQLDataArea = new SqlCommand();
                SQLDataArea.Connection = con;

                SQLDataArea.CommandText = "sp_GetPricelistDataArea";
                SQLDataArea.CommandType = CommandType.StoredProcedure;

                SQLDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLDataArea.Parameters.Add("@Item", SqlDbType.NVarChar, 60);
                SQLDataArea.Parameters.Add("@Type", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@ItemKey", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@Qty", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@QtyDec", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@QtyUOM", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@Customer", SqlDbType.NVarChar, 50);
                SQLDataArea.Parameters.Add("@Currency", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@LineNum", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@Year", SqlDbType.NVarChar, 5);
                SQLDataArea.Parameters.Add("@Month", SqlDbType.NVarChar, 2);
                SQLDataArea.Parameters.Add("@Day", SqlDbType.NVarChar, 2);
                SQLDataArea.Parameters.Add("@Minute", SqlDbType.NVarChar, 2);
                SQLDataArea.Parameters.Add("@Second", SqlDbType.NVarChar, 2);
                SQLDataArea.Parameters.Add("@SubSecond", SqlDbType.NVarChar, 2);
                SQLDataArea.Parameters.Add("@TimeZone", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLDataArea.Parameters.Add("@DataArea", SqlDbType.Int);
                SQLDataArea.Parameters.Add("@PriceListLine", SqlDbType.Int);
                SQLDataArea.Parameters.Add("@PartRef", SqlDbType.Int);
                SQLDataArea.Parameters.Add("@PartClass", SqlDbType.NVarChar, 50);
                SQLDataArea.Parameters.Add("@PriceListId", SqlDbType.NVarChar, 50);
                SQLDataArea.Parameters.Add("@SiteLevel", SqlDbType.NVarChar, 50);
                for (int k = 0; k < resultingMessage.DATAAREA.Length; k++)
                {
                    for (int l = 0; l < resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE.Length; l++)
                    {
                        for (int m = 0; m < resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF.Length; m++)
                        {
                            SQLDataArea.Parameters["@GUID"].Value = guid.ToString();
                            SQLDataArea.Parameters["@TransId"].Value = (object)TransID ?? DBNull.Value;
                            SQLDataArea.Parameters["@Item"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF[m].PARTNO.ToString();
                            SQLDataArea.Parameters["@Type"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF[m].PARTTYPE.ToString();
                            SQLDataArea.Parameters["@ItemKey"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF[m].PARTKEY.ToString();
                            SQLDataArea.Parameters["@Qty"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.QUANTITY.VALUE.ToString();
                            SQLDataArea.Parameters["@QtyDec"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.QUANTITY.NUMOFDEC.ToString();
                            SQLDataArea.Parameters["@QtyUOM"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.QUANTITY.UOM.ToString();
                            SQLDataArea.Parameters["@Customer"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PARTNRID.ToString();
                            SQLDataArea.Parameters["@Currency"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.CURRENCY.ToString();
                            SQLDataArea.Parameters["@LineNum"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].LINENUM.ToString();
                            SQLDataArea.Parameters["@Year"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.YEAR.ToString();
                            SQLDataArea.Parameters["@Month"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.MONTH.ToString();
                            SQLDataArea.Parameters["@Day"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.DAY.ToString();
                            SQLDataArea.Parameters["@Minute"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.MINUTE.ToString();
                            SQLDataArea.Parameters["@Second"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.SECOND.ToString();
                            SQLDataArea.Parameters["@SubSecond"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.SUBSECOND.ToString();
                            SQLDataArea.Parameters["@TimeZone"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.TIMEZONE.ToString();
                            SQLDataArea.Parameters["@PriceListId"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRICELSTID.ToString();
                            SQLDataArea.Parameters["@PartClass"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF[m].PARTCLASS.ToString();
                            SQLDataArea.Parameters["@SiteLevel"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.SITELEVEL.ToString();

                            SQLDataArea.Parameters["@DataArea"].Value = k;
                            SQLDataArea.Parameters["@PriceListLine"].Value = l;
                            SQLDataArea.Parameters["@PartRef"].Value = m;

                            SQLDataArea.ExecuteNonQuery();
                        }
                    }
                }
                //return show price data
                SqlCommand SQLShowControlArea = new SqlCommand();
                SQLShowControlArea.Connection = con;

                SQLShowControlArea.CommandText = "sp_ShowPriceListDataControlArea";
                SQLShowControlArea.CommandType = CommandType.StoredProcedure;

                SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                SQLShowControlArea.Parameters["@TransId"].Value = TransID;
                //  SqlDataReader dr;
                //  dr = SQLShowControlArea.ExecuteReader();
                var x = new showPriceList.SHOW_PRICELIST_002();
                var x1 = new CONFIRM_BOD_003();
                var iserror = "N";

                using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                {

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr[1].ToString() == "BOD")
                            {
                                iserror = "Y";

                                x1 = new CONFIRM_BOD_003()
                                {
                                    CNTROLAREA = new BOD.CNTROLAREA()
                                    {
                                        BSR = new BOD.BSR()
                                        {
                                            VERB = new BOD.VERB() { Value = dr[0].ToString() },
                                            NOUN = new BOD.NOUN()
                                            {
                                                Value = dr[1].ToString()
                                            },
                                            REVISION = new BOD.REVISION() { Value = dr[2].ToString() }
                                        },
                                        SENDER = new BOD.SENDER()
                                        {
                                            LOGICALID = dr[3].ToString(),
                                            COMPONENT = dr[4].ToString(),
                                            TASK = dr[5].ToString(),
                                            REFERENCEID = dr[6].ToString(),
                                            CONFIRMATION = dr[7].ToString(),
                                            LANGUAGE = dr[8].ToString(),
                                            CODEPAGE = dr[9].ToString(),
                                            AUTHID = dr["Sender_Authid"].ToString()

                                        },
                                        DATETIME = new BOD.DATETIME()
                                        {
                                            qualifier = BOD.DATETIMEQualifier.CREATION,
                                            YEAR = dr[11].ToString(),
                                            MONTH = dr[12].ToString(),
                                            DAY = dr[13].ToString()
                                                                       ,
                                            HOUR = dr[14].ToString(),
                                            MINUTE = dr[15].ToString(),
                                            SECOND = dr[16].ToString(),
                                            SUBSECOND = dr[17].ToString(),
                                            TIMEZONE = dr[18].ToString()
                                        }
                                    }
                                };


                            }

                        }
                    }
                }
                //populate data area
                SqlCommand SQLShowPriceDataArea = new SqlCommand();
                SQLShowPriceDataArea.Connection = con;

                SQLShowPriceDataArea.CommandText = "sp_ShowGetPriceDataArea";
                SQLShowPriceDataArea.CommandType = CommandType.StoredProcedure;

                SQLShowPriceDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLShowPriceDataArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLShowPriceDataArea.Parameters["@GUID"].Value = guid.ToString();
                SQLShowPriceDataArea.Parameters["@TransId"].Value = TransID;

                if (iserror == "Y")
                {

                    using (SqlDataReader drbod = SQLShowPriceDataArea.ExecuteReader())
                    {
                        if (drbod.HasRows)
                        {
                            DataTable dt = new DataTable(); dt.Load(drbod);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                BOD.DATAAREA[] dx1 = new BOD.DATAAREA[1];
                                dx1[0] = new BOD.DATAAREA();
                                dx1[0].CONFIRM_BOD = new CONFIRM_BOD();
                                dx1[0].CONFIRM_BOD.CONFIRM = new CONFIRM();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA = new BOD.CNTROLAREA();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR = new BOD.BSR();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN = new BOD.NOUN();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN.Value = dt.Rows[i]["BSR_NOUN"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB = new BOD.VERB();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB.Value = dt.Rows[i]["BSR_Verb"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION = new BOD.REVISION();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION.Value = dt.Rows[i]["BSR_Revision"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER = new BOD.SENDER();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LOGICALID = dt.Rows[i]["Sender_LogicalId"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.COMPONENT = dt.Rows[i]["Sender_Component"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.TASK = dt.Rows[i]["Sender_Task"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.REFERENCEID = dt.Rows[i]["Sender_Referenceid"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CONFIRMATION = dt.Rows[i]["Sender_Confirmation"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LANGUAGE = dt.Rows[i]["Sender_Language"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CODEPAGE = dt.Rows[i]["Sender_Codepage"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.AUTHID = dt.Rows[i]["Sender_Authid"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME = new BOD.DATETIME();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.qualifier = BOD.DATETIMEQualifier.CREATION;
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.YEAR = dt.Rows[i]["DateTime_Year"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MONTH = dt.Rows[i]["DateTime_Month"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.DAY = dt.Rows[i]["DateTime_Day"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.HOUR = dt.Rows[i]["DateTime_Hour"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MINUTE = dt.Rows[i]["DateTime_Minute"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SECOND = dt.Rows[i]["DateTime_Second"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SUBSECOND = dt.Rows[i]["DateTime_Subsecond"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.TIMEZONE = dt.Rows[i]["DateTime_Timezone"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.STATUSLVL = dt.Rows[i]["StatusLVL"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.DESCRIPTN = dt.Rows[i]["Description"].ToString();
                                BOD.CONFIRMMSG cnmsg = new CONFIRMMSG();

                                cnmsg.DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                cnmsg.REASONCODE = dt.Rows[i]["ReasonCode"].ToString();

                                CONFIRMMSG[] d1 = new CONFIRMMSG[1];
                                d1[0] = new CONFIRMMSG();
                                d1[0].DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                d1[0].REASONCODE = dt.Rows[i]["ReasonCode"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CONFIRMMSG = d1;
                                x1.DATAAREA = dx1;
                            }

                        }
                    }
                }

                // return x;
                if (iserror == "Y")
                {
                    CONFIRM_BOD_003 cb = new CONFIRM_BOD_003();
                    var xbod = SerializeObjectToXml(x1);
                    XmlDocument dd = new XmlDocument();

                    XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
                    dd.InsertBefore(docNode, root);
                    dd.AppendChild(docNode); dd.LoadXml(xbod);
                    return x1;
                    // return dd;
                }
                else
                {
                    return x1;
                }
            }
        }
        public CONFIRM_BOD_003 ConfirmBODGetSalesOrder(object getxml, string MsgType, string MsgTypeVersion, string Sender, string TransID, string CallType, string ErrMsg = null)

        {
            var xmlstring = ((System.Xml.XmlNode[])getxml)[0].Value.ToString();
            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;

            Guid guid = Guid.NewGuid();

            var getsalesordread = new StringReader(xmlstring.Trim());

            getSalesOrder.GET_SALESORDER_005 resultingMessage = (getSalesOrder.GET_SALESORDER_005)new XmlSerializer(typeof(getSalesOrder.GET_SALESORDER_005)).Deserialize(getsalesordread);




            using (SqlConnection con = new SqlConnection(cs))
            {
                //   var guid = new Guid();

                SqlCommand SQLXMLHeader = new SqlCommand();
                SQLXMLHeader.Connection = con;
                con.Open();
                SQLXMLHeader.CommandText = "InsertXMLHeader";
                SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                SQLXMLHeader.ExecuteNonQuery();

                //control area
                SqlCommand SQLControlAra = new SqlCommand();
                SQLControlAra.Connection = con;
                SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                SQLControlAra.CommandType = CommandType.StoredProcedure;
                SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                SQLControlAra.Parameters["@TransId"].Value = TransID;
                SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                SQLControlAra.ExecuteNonQuery();


                //Data Area

                SqlCommand SQLDataArea = new SqlCommand();
                SQLDataArea.Connection = con;
                SQLDataArea.CommandText = "sp_GetSalesOrderDataArea";
                SQLDataArea.CommandType = CommandType.StoredProcedure;
                SQLDataArea.Parameters.Add("@Partner_Name", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@Partner_Id", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@Partner_Type", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@PageList_Element_SOLine", SqlDbType.NVarChar, 30);
                SQLDataArea.Parameters.Add("@PageSize_SOLine", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@PageRef_Name_Element_SOLine", SqlDbType.NVarChar, 20);

                SQLDataArea.Parameters.Add("@PageList_Element_Shipment", SqlDbType.NVarChar, 30);
                SQLDataArea.Parameters.Add("@PageSize_Shipment", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@PageRef_Name_Element_Shipment", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@SOID", SqlDbType.NVarChar, 30);
                SQLDataArea.Parameters.Add("@RefKey", SqlDbType.NVarChar, 200);
                SQLDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);

                SQLDataArea.Parameters["@Partner_Name"].Value = resultingMessage.DATAAREA[0].GET_SALESORDER.SOHEADER.PARTNER[0].NAME.Value;
                SQLDataArea.Parameters["@Partner_Id"].Value = resultingMessage.DATAAREA[0].GET_SALESORDER.SOHEADER.PARTNER[0].PARTNRID;
                SQLDataArea.Parameters["@Partner_Type"].Value = resultingMessage.DATAAREA[0].GET_SALESORDER.SOHEADER.PARTNER[0].PARTNRTYPE;

                if (resultingMessage.DATAAREA[0].PAGELIST.Length == 2)
                {
                    if (resultingMessage.DATAAREA[0].PAGELIST[0].element == "SOLINE")
                    {
                        SQLDataArea.Parameters["@PageList_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                        SQLDataArea.Parameters["@PageSize_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                        SQLDataArea.Parameters["@PageRef_Name_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name;
                        if (resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF != null)
                        {
                            SQLDataArea.Parameters["@RefKey"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF[0].Value;
                        }
                    }
                    if (resultingMessage.DATAAREA[0].PAGELIST[1].element == "SHIPMENT")
                    {
                        SQLDataArea.Parameters["@PageList_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].element;
                        SQLDataArea.Parameters["@PageSize_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGESIZE;
                        SQLDataArea.Parameters["@PageRef_Name_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGEREF[0].name;
                    }
                    if (resultingMessage.DATAAREA[0].PAGELIST[1].element == "SOLINE")
                    {
                        SQLDataArea.Parameters["@PageList_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].element;
                        SQLDataArea.Parameters["@PageSize_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGESIZE;
                        SQLDataArea.Parameters["@PageRef_Name_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGEREF[0].name;
                        if (resultingMessage.DATAAREA[0].PAGELIST[1].PAGEREF[0].REF != null)
                        {
                            SQLDataArea.Parameters["@RefKey"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGEREF[0].REF[0].Value;
                        }
                    }
                    if (resultingMessage.DATAAREA[0].PAGELIST[0].element == "SHIPMENT")
                    {
                        SQLDataArea.Parameters["@PageList_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                        SQLDataArea.Parameters["@PageSize_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                        SQLDataArea.Parameters["@PageRef_Name_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name;
                    }
                }
                if (resultingMessage.DATAAREA[0].PAGELIST.Length == 1)
                {
                    if (resultingMessage.DATAAREA[0].PAGELIST[0].element == "SHIPMENT")
                    {
                        SQLDataArea.Parameters["@PageList_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                        SQLDataArea.Parameters["@PageSize_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                        SQLDataArea.Parameters["@PageRef_Name_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name;
                    }
                    if (resultingMessage.DATAAREA[0].PAGELIST[0].element == "SOLINE")
                    {
                        SQLDataArea.Parameters["@PageList_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                        SQLDataArea.Parameters["@PageSize_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                        SQLDataArea.Parameters["@PageRef_Name_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name;
                        if (resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF != null)
                        {
                            SQLDataArea.Parameters["@RefKey"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF[0].Value;
                        }
                    }
                }
                SQLDataArea.Parameters["@SOID"].Value = resultingMessage.DATAAREA[0].GET_SALESORDER.SOHEADER.SALESORDID.ToString().Trim();
                SQLDataArea.Parameters["@GUID"].Value = guid.ToString();
                SQLDataArea.ExecuteNonQuery();



                //return list sales order
                SqlCommand SQLShowControlArea = new SqlCommand();
                SQLShowControlArea.Connection = con;

                SQLShowControlArea.CommandText = "sp_ShowSalesOrderDataControlArea";
                SQLShowControlArea.CommandType = CommandType.StoredProcedure;

                SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                SQLShowControlArea.Parameters["@TransId"].Value = TransID;
                //  SqlDataReader dr;
                //  dr = SQLShowControlArea.ExecuteReader();
                var x = new showsalesorder.SHOW_SALESORDER_005();
                var x1 = new CONFIRM_BOD_003();
                var iserror = "N";

                using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                {

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr[1].ToString() == "BOD")
                            {
                                iserror = "Y";

                                x1 = new CONFIRM_BOD_003()
                                {
                                    CNTROLAREA = new BOD.CNTROLAREA()
                                    {
                                        BSR = new BOD.BSR()
                                        {
                                            VERB = new BOD.VERB() { Value = dr[0].ToString() },
                                            NOUN = new BOD.NOUN()
                                            {
                                                Value = dr[1].ToString()
                                            },
                                            REVISION = new BOD.REVISION() { Value = dr[2].ToString() }
                                        },
                                        SENDER = new BOD.SENDER()
                                        {
                                            LOGICALID = dr[3].ToString(),
                                            COMPONENT = dr[4].ToString(),
                                            TASK = dr[5].ToString(),
                                            REFERENCEID = dr[6].ToString(),
                                            CONFIRMATION = dr[7].ToString(),
                                            LANGUAGE = dr[8].ToString(),
                                            CODEPAGE = dr[9].ToString(),
                                            AUTHID = dr["Sender_Authid"].ToString()

                                        },
                                        DATETIME = new BOD.DATETIME()
                                        {
                                            qualifier = BOD.DATETIMEQualifier.CREATION,
                                            YEAR = dr[11].ToString(),
                                            MONTH = dr[12].ToString(),
                                            DAY = dr[13].ToString()
                                                                       ,
                                            HOUR = dr[14].ToString(),
                                            MINUTE = dr[15].ToString(),
                                            SECOND = dr[16].ToString(),
                                            SUBSECOND = dr[17].ToString(),
                                            TIMEZONE = dr[18].ToString()
                                        }
                                    }
                                };

                            }
                            else
                            {
                            }
                        }
                    }
                }


                //populate data area
                SqlCommand SQLShowSalesOrder = new SqlCommand();
                SQLShowSalesOrder.Connection = con;

                SQLShowSalesOrder.CommandText = "sp_ShowOrderDataArea";
                SQLShowSalesOrder.CommandType = CommandType.StoredProcedure;

                SQLShowSalesOrder.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLShowSalesOrder.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLShowSalesOrder.Parameters.Add("@SO", SqlDbType.NVarChar, 20);
                SQLShowSalesOrder.Parameters["@GUID"].Value = guid.ToString();

                if (iserror == "Y")
                {

                    using (SqlDataReader drbod = SQLShowSalesOrder.ExecuteReader())
                    {
                        if (drbod.HasRows)
                        {
                            DataTable dt = new DataTable(); dt.Load(drbod);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                BOD.DATAAREA[] dx1 = new BOD.DATAAREA[1];
                                dx1[0] = new BOD.DATAAREA();
                                dx1[0].CONFIRM_BOD = new CONFIRM_BOD();
                                dx1[0].CONFIRM_BOD.CONFIRM = new CONFIRM();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA = new BOD.CNTROLAREA();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR = new BOD.BSR();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN = new BOD.NOUN();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN.Value = dt.Rows[i]["BSR_NOUN"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB = new BOD.VERB();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB.Value = dt.Rows[i]["BSR_Verb"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION = new BOD.REVISION();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION.Value = dt.Rows[i]["BSR_Revision"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER = new BOD.SENDER();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LOGICALID = dt.Rows[i]["Sender_LogicalId"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.COMPONENT = dt.Rows[i]["Sender_Component"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.TASK = dt.Rows[i]["Sender_Task"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.REFERENCEID = dt.Rows[i]["Sender_Referenceid"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CONFIRMATION = dt.Rows[i]["Sender_Confirmation"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LANGUAGE = dt.Rows[i]["Sender_Language"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CODEPAGE = dt.Rows[i]["Sender_Codepage"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.AUTHID = dt.Rows[i]["Sender_Authid"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME = new BOD.DATETIME();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.qualifier = BOD.DATETIMEQualifier.CREATION;
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.YEAR = dt.Rows[i]["DateTime_Year"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MONTH = dt.Rows[i]["DateTime_Month"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.DAY = dt.Rows[i]["DateTime_Day"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.HOUR = dt.Rows[i]["DateTime_Hour"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MINUTE = dt.Rows[i]["DateTime_Minute"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SECOND = dt.Rows[i]["DateTime_Second"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SUBSECOND = dt.Rows[i]["DateTime_Subsecond"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.TIMEZONE = dt.Rows[i]["DateTime_Timezone"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.STATUSLVL = dt.Rows[i]["StatusLVL"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.DESCRIPTN = dt.Rows[i]["Description"].ToString();
                                BOD.CONFIRMMSG cnmsg = new CONFIRMMSG();

                                cnmsg.DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                cnmsg.REASONCODE = dt.Rows[i]["ReasonCode"].ToString();

                                CONFIRMMSG[] d1 = new CONFIRMMSG[1];
                                d1[0] = new CONFIRMMSG();
                                d1[0].DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                d1[0].REASONCODE = dt.Rows[i]["ReasonCode"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CONFIRMMSG = d1;
                                x1.DATAAREA = dx1;
                            }

                        }
                    }
                }

                // return x;
                if (iserror == "Y")
                {
                    CONFIRM_BOD_003 cb = new CONFIRM_BOD_003();
                    var xbod = SerializeObjectToXml(x1);
                    XmlDocument dd = new XmlDocument();

                    XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
                    dd.InsertBefore(docNode, root);
                    dd.AppendChild(docNode); dd.LoadXml(xbod);
                    return x1;
                    // return dd;
                }
                else
                {
                    return x1;
                }
            }


        }

        public CONFIRM_BOD_003 ConfirmBODGetListSalesOrder(object getxml, string MsgType, string MsgTypeVersion, string Sender, string TransID, string CallType, string ErrMsg = null)

        {
            listSalesorder.LIST_SALESORDER_005 sp = new listSalesorder.LIST_SALESORDER_005();

            var xmlstring = ((System.Xml.XmlNode[])getxml)[0].Value.ToString();

            var getlistsalesorderread = new StringReader(xmlstring.Trim());


            getlistSalesorder.GETLIST_SALESORDER_005 resultingMessage = (getlistSalesorder.GETLIST_SALESORDER_005)new XmlSerializer(typeof(getlistSalesorder.GETLIST_SALESORDER_005)).Deserialize(getlistsalesorderread);


            //Load data into sql
            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                Guid Mainguid = Guid.NewGuid();
                var guid = Mainguid.ToString();
                //   var guid = new Guid();
                if (ErrMsg != "")
                {
                    guid = ErrMsg;
                }
                else { guid = Mainguid.ToString(); }

                SqlCommand SQLXMLHeader = new SqlCommand();
                SQLXMLHeader.Connection = con;
                con.Open();
                SQLXMLHeader.CommandText = "InsertXMLHeader";
                SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                SQLXMLHeader.ExecuteNonQuery();

                //control area
                SqlCommand SQLControlAra = new SqlCommand();
                SQLControlAra.Connection = con;
                SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                SQLControlAra.CommandType = CommandType.StoredProcedure;
                SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                SQLControlAra.Parameters["@TransId"].Value = TransID;
                SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                SQLControlAra.ExecuteNonQuery();
                //Data Area

                SqlCommand SQLDataArea = new SqlCommand();
                SQLDataArea.Connection = con;
                SQLDataArea.CommandText = "sp_GetListSalesOrderDataArea";
                SQLDataArea.CommandType = CommandType.StoredProcedure;
                SQLDataArea.Parameters.Add("@Colinx_Sortorder", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@Colinx_Translines", SqlDbType.NVarChar, 5);
                SQLDataArea.Parameters.Add("@Partner_Name", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@Partner_Id", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@Partner_Type", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@SOLine_PartType", SqlDbType.NVarChar, 30);
                SQLDataArea.Parameters.Add("@SOLine_PartNo", SqlDbType.NVarChar, 200);
                SQLDataArea.Parameters.Add("@SOLine_PartClass", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@SOLine_PartQual", SqlDbType.NVarChar, 30);
                SQLDataArea.Parameters.Add("@SOLineStatus", SqlDbType.NVarChar, 30);
                SQLDataArea.Parameters.Add("@PageList_Element", SqlDbType.NVarChar, 30);
                SQLDataArea.Parameters.Add("@PageSize", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@TotalSize", SqlDbType.NVarChar, 10);
                SQLDataArea.Parameters.Add("@PageRef_Name", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@PageRef_Ref", SqlDbType.NVarChar, 500);
                SQLDataArea.Parameters.Add("@FromDate_Year", SqlDbType.NVarChar, 5);
                SQLDataArea.Parameters.Add("@FromDate_Month", SqlDbType.NVarChar, 5);
                SQLDataArea.Parameters.Add("@FromDate_Day", SqlDbType.NVarChar, 3);
                SQLDataArea.Parameters.Add("@ToDate_Year", SqlDbType.NVarChar, 5);
                SQLDataArea.Parameters.Add("@ToDate_Month", SqlDbType.NVarChar, 3);
                SQLDataArea.Parameters.Add("@ToDate_Day", SqlDbType.NVarChar, 3);
                SQLDataArea.Parameters.Add("@SOID", SqlDbType.NVarChar, 30);
                SQLDataArea.Parameters.Add("@POID", SqlDbType.NVarChar, 100);
                SQLDataArea.Parameters.Add("@SOStatus", SqlDbType.NVarChar, 20);
                SQLDataArea.Parameters.Add("@OrdTransId", SqlDbType.NVarChar, 30);
                SQLDataArea.Parameters.Add("@TransID", SqlDbType.NVarChar, 60);
                SQLDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);

                SQLDataArea.Parameters["@Colinx_Sortorder"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SOHEADER_USERAREA.COLINX_SORTORDER;
                SQLDataArea.Parameters["@Colinx_Translines"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SOHEADER_USERAREA.COLINX_TRANSLINES;
                SQLDataArea.Parameters["@Partner_Name"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.PARTNER[0].NAME.Value;
                SQLDataArea.Parameters["@Partner_Id"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.PARTNER[0].PARTNRID;
                SQLDataArea.Parameters["@Partner_Type"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.PARTNER[0].PARTNRTYPE;
                SQLDataArea.Parameters["@SOStatus"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SOSTATUS;

                if (resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF != null)
                {
                    SQLDataArea.Parameters["@SOLine_PartType"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF[0].PARTTYPE;
                    SQLDataArea.Parameters["@SOLine_PartNo"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF[0].PARTNO;
                    SQLDataArea.Parameters["@SOLine_PartClass"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF[0].PARTCLASS;
                    SQLDataArea.Parameters["@SOLine_PartQual"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF[0].PARTQUAL;
                }

                SQLDataArea.Parameters["@SOLineStatus"].Value = (object)resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].SOLNSTATUS ?? DBNull.Value;
                SQLDataArea.Parameters["@PageList_Element"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                SQLDataArea.Parameters["@PageSize"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                SQLDataArea.Parameters["@TotalSize"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].TOTALSIZE;
                SQLDataArea.Parameters["@PageRef_Name"].Value = (object)resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name ?? DBNull.Value;
                if ((object)resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF == null) { SQLDataArea.Parameters["@PageRef_Ref"].Value = ""; }
                else
                {
                    SQLDataArea.Parameters["@PageRef_Ref"].Value = (object)resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF[0].Value ?? DBNull.Value;
                }
                if (resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.DATETIME != null)
                {
                    SQLDataArea.Parameters["@FromDate_Year"].Value = (object)resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.DATETIME.YEAR ?? DBNull.Value;
                    SQLDataArea.Parameters["@FromDate_Month"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.DATETIME.MONTH;
                    SQLDataArea.Parameters["@FromDate_Day"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.DATETIME.DAY;
                }
                if (resultingMessage.DATAAREA[0].GETLIST_SALESORDER1 != null)
                {
                    if (resultingMessage.DATAAREA[0].GETLIST_SALESORDER1.SOHEADER.DATETIME != null)
                    {
                        SQLDataArea.Parameters["@ToDate_Year"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER1.SOHEADER.DATETIME.YEAR;
                        SQLDataArea.Parameters["@ToDate_Month"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER1.SOHEADER.DATETIME.MONTH;
                        SQLDataArea.Parameters["@ToDate_Day"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER1.SOHEADER.DATETIME.DAY;
                    }
                }
                SQLDataArea.Parameters["@SOID"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SALESORDID;
                SQLDataArea.Parameters["@POID"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.POID;
                SQLDataArea.Parameters["@OrdTransId"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SOHEADER_USERAREA.COLINX_ORDTRANSID;
                SQLDataArea.Parameters["@TransID"].Value = TransID;
                SQLDataArea.Parameters["@GUID"].Value = guid.ToString();
                SQLDataArea.ExecuteNonQuery();


                listSalesorder.LIST_SALESORDER_005 ListSO = new listSalesorder.LIST_SALESORDER_005();



                //return show price data
                SqlCommand SQLShowControlArea = new SqlCommand();
                SQLShowControlArea.Connection = con;

                SQLShowControlArea.CommandText = "sp_ShowListSalesOrderDataControlArea";
                SQLShowControlArea.CommandType = CommandType.StoredProcedure;

                SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);

                SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                SQLShowControlArea.Parameters["@TransId"].Value = TransID;

                //  SqlDataReader dr;
                //  dr = SQLShowControlArea.ExecuteReader();
                var x = new showPriceList.SHOW_PRICELIST_002();
                var x1 = new CONFIRM_BOD_003();
                var iserror = "N";

                using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                {

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr[1].ToString() == "BOD")
                            {
                                iserror = "Y";

                                x1 = new CONFIRM_BOD_003()
                                {
                                    CNTROLAREA = new BOD.CNTROLAREA()
                                    {
                                        BSR = new BOD.BSR()
                                        {
                                            VERB = new BOD.VERB() { Value = dr[0].ToString() },
                                            NOUN = new BOD.NOUN()
                                            {
                                                Value = dr[1].ToString()
                                            },
                                            REVISION = new BOD.REVISION() { Value = dr[2].ToString() }
                                        },
                                        SENDER = new BOD.SENDER()
                                        {
                                            LOGICALID = dr[3].ToString(),
                                            COMPONENT = dr[4].ToString(),
                                            TASK = dr[5].ToString(),
                                            REFERENCEID = dr[6].ToString(),
                                            CONFIRMATION = dr[7].ToString(),
                                            LANGUAGE = dr[8].ToString(),
                                            CODEPAGE = dr[9].ToString(),
                                            AUTHID = dr["Sender_Authid"].ToString()

                                        },
                                        DATETIME = new BOD.DATETIME()
                                        {
                                            qualifier = BOD.DATETIMEQualifier.CREATION,
                                            YEAR = dr[11].ToString(),
                                            MONTH = dr[12].ToString(),
                                            DAY = dr[13].ToString()
                                                                       ,
                                            HOUR = dr[14].ToString(),
                                            MINUTE = dr[15].ToString(),
                                            SECOND = dr[16].ToString(),
                                            SUBSECOND = dr[17].ToString(),
                                            TIMEZONE = dr[18].ToString()
                                        }
                                    }
                                };


                            }

                        }
                    }
                }
                //populate data area
                SqlCommand SQLShowPriceDataArea = new SqlCommand();
                SQLShowPriceDataArea.Connection = con;

                SQLShowPriceDataArea.CommandText = "sp_ShowListOrderDataArea";
                SQLShowPriceDataArea.CommandType = CommandType.StoredProcedure;

                SQLShowPriceDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                SQLShowPriceDataArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                SQLShowPriceDataArea.Parameters["@GUID"].Value = guid.ToString();
                SQLShowPriceDataArea.Parameters["@TransId"].Value = TransID;

                if (iserror == "Y")
                {

                    using (SqlDataReader drbod = SQLShowPriceDataArea.ExecuteReader())
                    {
                        if (drbod.HasRows)
                        {
                            DataTable dt = new DataTable(); dt.Load(drbod);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                BOD.DATAAREA[] dx1 = new BOD.DATAAREA[1];
                                dx1[0] = new BOD.DATAAREA();
                                dx1[0].CONFIRM_BOD = new CONFIRM_BOD();
                                dx1[0].CONFIRM_BOD.CONFIRM = new CONFIRM();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA = new BOD.CNTROLAREA();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR = new BOD.BSR();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN = new BOD.NOUN();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.NOUN.Value = dt.Rows[i]["BSR_NOUN"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB = new BOD.VERB();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.VERB.Value = dt.Rows[i]["BSR_Verb"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION = new BOD.REVISION();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.BSR.REVISION.Value = dt.Rows[i]["BSR_Revision"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER = new BOD.SENDER();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LOGICALID = dt.Rows[i]["Sender_LogicalId"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.COMPONENT = dt.Rows[i]["Sender_Component"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.TASK = dt.Rows[i]["Sender_Task"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.REFERENCEID = dt.Rows[i]["Sender_Referenceid"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CONFIRMATION = dt.Rows[i]["Sender_Confirmation"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.LANGUAGE = dt.Rows[i]["Sender_Language"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.CODEPAGE = dt.Rows[i]["Sender_Codepage"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.SENDER.AUTHID = dt.Rows[i]["Sender_Authid"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME = new BOD.DATETIME();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.qualifier = BOD.DATETIMEQualifier.CREATION;
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.YEAR = dt.Rows[i]["DateTime_Year"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MONTH = dt.Rows[i]["DateTime_Month"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.DAY = dt.Rows[i]["DateTime_Day"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.HOUR = dt.Rows[i]["DateTime_Hour"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.MINUTE = dt.Rows[i]["DateTime_Minute"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SECOND = dt.Rows[i]["DateTime_Second"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.SUBSECOND = dt.Rows[i]["DateTime_Subsecond"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CNTROLAREA.DATETIME.TIMEZONE = dt.Rows[i]["DateTime_Timezone"].ToString();

                                dx1[0].CONFIRM_BOD.CONFIRM.STATUSLVL = dt.Rows[i]["StatusLVL"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.DESCRIPTN = dt.Rows[i]["Description"].ToString();
                                BOD.CONFIRMMSG cnmsg = new CONFIRMMSG();

                                cnmsg.DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                cnmsg.REASONCODE = dt.Rows[i]["ReasonCode"].ToString();

                                CONFIRMMSG[] d1 = new CONFIRMMSG[1];
                                d1[0] = new CONFIRMMSG();
                                d1[0].DESCRIPTN = dt.Rows[i]["ReasonCodeDescription"].ToString();
                                d1[0].REASONCODE = dt.Rows[i]["ReasonCode"].ToString();
                                dx1[0].CONFIRM_BOD.CONFIRM.CONFIRMMSG = d1;
                                x1.DATAAREA = dx1;
                            }

                        }
                    }
                }

                // return x;
                if (iserror == "Y")
                {
                    CONFIRM_BOD_003 cb = new CONFIRM_BOD_003();
                    var xbod = SerializeObjectToXml(x1);
                    XmlDocument dd = new XmlDocument();

                    XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
                    dd.InsertBefore(docNode, root);
                    dd.AppendChild(docNode); dd.LoadXml(xbod);
                    return x1;
                    // return dd;
                }
                else
                {
                    return x1;
                }
            }
        }


        [WebMethod(EnableSession = true)]
        [return: XmlElement(Namespace = "http://www.skf.com/oagis/9/", IsNullable = true)]
        public XmlDocument GetPriceList(gaiaWs xmlstring)
        {
            string[] MessageTypeArray = new string[10];

            MessageTypeArray[0] = "XC27"; MessageTypeArray[1] = "XC29"; MessageTypeArray[2] = "XC31";
            MessageTypeArray[3] = "XC33"; MessageTypeArray[4] = "XC39"; MessageTypeArray[5] = "XC41";

            bool msgTyperesult = MessageTypeArray.Contains(xmlstring.messageType);
            bool msgVersionresult = false;

            if (xmlstring.messageType == "XC39")
            { }


            var GetPriceList = SHOW_PRICELIST_002(xmlstring.xmlContent, xmlstring.messageType, "", "", "0");
            // var getshowshostpingresult = ConfirmBOD(xmlstring.xmlContent, xmlstring.messageType, "", "", "0");

            gaiaWs g = new gaiaWs();
            var x = "";
            if (GetPriceList.CNTROLAREA == null)
            {
                var BOD = ConfirmBODGetPriceList(xmlstring.xmlContent, xmlstring.messageType, "", "", "0", "GetPriceList", Session["Errmsg"].ToString());
                x = SerializeObjectToXml(BOD);
                g.messageType = "XC41";
            }
            else
            {

                x = SerializeObjectToXml(GetPriceList);
                g.messageType = "XC28";
            }

            XmlCDataSection xc;
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(x);
            xc = xdoc.CreateCDataSection(x);

            Content = x;
            g.xmlContent = CDataContent;
            //  g.messageType = "XC28";

            var x1 = SerializeObjectToXml(g);

            g.messageType = "";
            //return g;
            XmlDocument dd = new XmlDocument();

            XmlNode docNode = dd.CreateXmlDeclaration("1.0", "UTF-8", null); XmlElement root = dd.DocumentElement;
            dd.InsertBefore(docNode, root);
            dd.AppendChild(docNode); dd.LoadXml(x1);

            return dd;
        }



        [XmlIgnore]
        public string Content { get; set; }
        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(Content) };
            }
            set
            {
                if (value == null)
                {
                    Content = null;
                    return;
                }

                if (value.Length != 1)
                {
                    throw new InvalidOperationException(
                        String.Format(
                            "Invalid array length {0}", value.Length));
                }

                Content = value[0].Value;
            }
        }


        public static string SerializeObjectToXml<T>(T value)
        {
            if (value == null)
            {
                string serializedXml = $"<Error>In" + $"put Object is null</Error>";
                return serializedXml;
            }
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));


                //var memoryStream = new MemoryStream();
                //var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8);

                //    StringWriter stringWriter = new StringWriter() ; 
                StringUTF8 stringWriter = new StringUTF8();
                XmlWriter writer = XmlWriter.Create(stringWriter);

                xmlSerializer.Serialize(stringWriter, value);

                string serializedXml = stringWriter.ToString();

                writer.Close();
                return serializedXml;
            }
            catch (Exception ex)
            {
                string serializedXml = $"<Error>{ex.StackTrace}</Error>";
                return serializedXml;
            }
        }


        public static T Deserialize<T>(string xml)
        {
            return (T)new XmlSerializer(typeof(T))
                .Deserialize(new StringReader(xml));
        }


        public string CreateXML(Object YourClassObject)
        {
            XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 
                                                      // Initializes a new instance of the XmlDocument class.     

            //XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //ns.Add("", "http://www.skf.com/oagis/9/");


            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Encoding = Encoding.UTF8;

            // Then we can set our indenting options (this is, of course, optional).
            //xtw.Formatting = Formatting.Indented;

            // Now serialize our object.
            //xs.Serialize(xtw, myType, myType.Namespaces);

            XmlSerializer xmlSerializer = new XmlSerializer(YourClassObject.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                //   XmlTextWriter xtw = (XmlTextWriter)XmlTextWriter.Create(xmlStream, xws);

                xmlSerializer.Serialize(xmlStream, YourClassObject);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public acknowledgepo.ACKNOWLEDGE_PO_006 ACKNOWLEDGE_PO_006(object getPO, string MsgType, string MsgTypeVersion, string Sender, string TransID)
        {

            var xmlstring = ((System.Xml.XmlNode[])getPO)[0].Value.ToString();


            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;
            var msg = checkxml(xmlstring, "ProcessPO");

            Guid guid = Guid.NewGuid();


            if (msg.Trim() == "")
            {
                var getPOread = new StringReader(xmlstring.Trim());

                processpo.PROCESS_PO_006 resultingMessage = (processpo.PROCESS_PO_006)new XmlSerializer(typeof(processpo.PROCESS_PO_006)).Deserialize(getPOread);

                using (SqlConnection con = new SqlConnection(cs))
                {

                    //   var guid = new Guid();

                    SqlCommand SQLXMLHeader = new SqlCommand();
                    SQLXMLHeader.Connection = con;
                    con.Open();
                    SQLXMLHeader.CommandText = "InsertXMLHeader";
                    SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                    SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                    SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                    SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                    SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                    SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                    SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                    SQLXMLHeader.ExecuteNonQuery();

                    //control area
                    SqlCommand SQLControlAra = new SqlCommand();
                    SQLControlAra.Connection = con;
                    SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                    SQLControlAra.CommandType = CommandType.StoredProcedure;
                    SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                    SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                    SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                    SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                    SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                    SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                    SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                    SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                    SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                    SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                    SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                    SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                    SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                    SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                    SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                    SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                    SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                    SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                    SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                    SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                    SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                    SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                    SQLControlAra.Parameters["@TransId"].Value = TransID;
                    SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                    SQLControlAra.ExecuteNonQuery();

                    SqlCommand SQLProcessPO = new SqlCommand();
                    SQLProcessPO.Connection = con;
                    SQLProcessPO.CommandText = "sp_InsertProcessPO";
                    SQLProcessPO.CommandType = CommandType.StoredProcedure;
                    SQLProcessPO.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLProcessPO.Parameters.Add("@POID", SqlDbType.NVarChar, 100);
                    SQLProcessPO.Parameters.Add("@POType", SqlDbType.NVarChar, 50);
                    SQLProcessPO.Parameters.Add("@Notes", SqlDbType.NVarChar, 500);
                    SQLProcessPO.Parameters.Add("@AckRequest", SqlDbType.NVarChar, 5);
                    SQLProcessPO.Parameters.Add("@OrdTransId", SqlDbType.NVarChar, 50);
                    SQLProcessPO.Parameters.Add("@shipInstr_OrderType", SqlDbType.NVarChar, 20);
                    SQLProcessPO.Parameters.Add("@ShipInstr_FrtBillType", SqlDbType.NVarChar, 30);
                    SQLProcessPO.Parameters.Add("@ShipInstr_Deviateflg", SqlDbType.NVarChar, 5);
                    SQLProcessPO.Parameters.Add("@ShipInstr_PartShip", SqlDbType.NVarChar, 5);
                    SQLProcessPO.Parameters.Add("@Division", SqlDbType.NVarChar, 50);
                    SQLProcessPO.Parameters.Add("@ShipInstr_FrtAccount", SqlDbType.NVarChar, 50);

                    SQLProcessPO.Parameters["@GUID"].Value = guid.ToString();
                    SQLProcessPO.Parameters["@POType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POTYPE ?? DBNull.Value;
                    SQLProcessPO.Parameters["@POID"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POID ?? DBNull.Value;
                    SQLProcessPO.Parameters["@Notes"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.NOTES ?? DBNull.Value;
                    SQLProcessPO.Parameters["@AckRequest"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.ACKREQUEST ?? DBNull.Value;
                    SQLProcessPO.Parameters["@OrdTransId"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_ORDTRANSID ?? DBNull.Value;
                    SQLProcessPO.Parameters["@shipInstr_OrderType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_ORDERTYPE ?? DBNull.Value;
                    SQLProcessPO.Parameters["@ShipInstr_FrtBillType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_FRTBILLTYPE ?? DBNull.Value;
                    SQLProcessPO.Parameters["@ShipInstr_Deviateflg"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_DEVIATEFLG ?? DBNull.Value;
                    SQLProcessPO.Parameters["@ShipInstr_PartShip"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_PARTSHIP ?? DBNull.Value;
                    SQLProcessPO.Parameters["@Division"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_DIVISION ?? DBNull.Value;
                    SQLProcessPO.Parameters["@ShipInstr_FrtAccount"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.COLINX_SHIPINSTR.COLINX_FRTACCTNUM ?? DBNull.Value;

                    SQLProcessPO.ExecuteNonQuery();
                    //add partner//

                    SqlCommand SQLPOPartner = new SqlCommand();
                    SQLPOPartner.Connection = con;
                    SQLPOPartner.CommandText = "sp_InsertPOPartner";
                    SQLPOPartner.CommandType = CommandType.StoredProcedure;
                    SQLPOPartner.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLPOPartner.Parameters.Add("@Partner", SqlDbType.NVarChar, 50);
                    SQLPOPartner.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                    SQLPOPartner.Parameters.Add("@PartnerType", SqlDbType.NVarChar, 20);
                    SQLPOPartner.Parameters.Add("@AddrType", SqlDbType.NVarChar, 20);
                    SQLPOPartner.Parameters.Add("@Addr1", SqlDbType.NVarChar, 100);
                    SQLPOPartner.Parameters.Add("@Addr2", SqlDbType.NVarChar, 100);
                    SQLPOPartner.Parameters.Add("@Addr3", SqlDbType.NVarChar, 100);
                    SQLPOPartner.Parameters.Add("@City", SqlDbType.NVarChar, 50);
                    SQLPOPartner.Parameters.Add("@Country", SqlDbType.NVarChar, 20);
                    SQLPOPartner.Parameters.Add("@Description", SqlDbType.NVarChar, 100);
                    SQLPOPartner.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 20);
                    SQLPOPartner.Parameters.Add("@State", SqlDbType.NVarChar, 20);

                    if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR != null)
                    {
                        SqlCommand SQLInterimNote = new SqlCommand();
                        SQLInterimNote.CommandText = "sp_InterimNotes";
                        SQLInterimNote.Connection = con;
                        SQLInterimNote.CommandType = CommandType.StoredProcedure;
                        SQLInterimNote.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                        SQLInterimNote.Parameters.Add("@Note", SqlDbType.NVarChar, 300);
                        SQLInterimNote.Parameters.Add("@Note_Qualifier", SqlDbType.NVarChar, 20);
                        SQLInterimNote.Parameters.Add("@Note_Sequence", SqlDbType.Int);
                        SQLInterimNote.Parameters.Add("@Attention", SqlDbType.NVarChar, 300);
                        SQLInterimNote.Parameters.Add("@Attn_Qualifier", SqlDbType.NVarChar, 10);
                        SQLInterimNote.Parameters.Add("@Attn_Sequence", SqlDbType.Int);

                        if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.INTRMNOTES != null)
                        {

                            for (int hi = 0; hi < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.INTRMNOTES.Length; hi++)
                            {
                                SQLInterimNote.Parameters["@GUID"].Value = guid.ToString();
                                SQLInterimNote.Parameters["@Note"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.INTRMNOTES[hi].Value ?? DBNull.Value;
                                SQLInterimNote.Parameters["@Note_Qualifier"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.INTRMNOTES[hi].qualifier ?? DBNull.Value;
                                SQLInterimNote.Parameters["@Note_Sequence"].Value = hi;
                                SQLInterimNote.Parameters["@Attention"].Value = null;
                                SQLInterimNote.Parameters["@Attn_Qualifier"].Value = null;
                                SQLInterimNote.Parameters["@Attn_Sequence"].Value = null;
                                SQLInterimNote.ExecuteNonQuery();
                            }
                        }

                        if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.INTRMATTN != null)
                        {

                            for (int hi = 0; hi < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.INTRMATTN.Length; hi++)
                            {
                                SQLInterimNote.Parameters["@GUID"].Value = guid.ToString();
                                SQLInterimNote.Parameters["@Attention"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.INTRMATTN[hi].Value ?? DBNull.Value;
                                SQLInterimNote.Parameters["@Attn_Qualifier"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.INTRMATTN[hi].qualifier ?? DBNull.Value;
                                SQLInterimNote.Parameters["@Attn_Sequence"].Value = hi;
                                SQLInterimNote.Parameters["@Note"].Value = null;
                                SQLInterimNote.Parameters["@Note_Qualifier"].Value = null;
                                SQLInterimNote.Parameters["@Note_Sequence"].Value = null;
                                SQLInterimNote.ExecuteNonQuery();
                            }
                        }
                    }

                    if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR != null)
                    {
                        SqlCommand SQLInterimPartner = new SqlCommand();
                        SQLInterimPartner.CommandText = "sp_InsertPOPartner_Interim";
                        SQLInterimPartner.Connection = con;
                        SQLInterimPartner.CommandType = CommandType.StoredProcedure;
                        SQLInterimPartner.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                        SQLInterimPartner.Parameters.Add("@Partner", SqlDbType.NVarChar, 50);
                        SQLInterimPartner.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                        SQLInterimPartner.Parameters.Add("@PartnerType", SqlDbType.NVarChar, 20);
                        SQLInterimPartner.Parameters.Add("@AddrType", SqlDbType.NVarChar, 20);
                        SQLInterimPartner.Parameters.Add("@Addr1", SqlDbType.NVarChar, 100);
                        SQLInterimPartner.Parameters.Add("@Addr2", SqlDbType.NVarChar, 100);
                        SQLInterimPartner.Parameters.Add("@Addr3", SqlDbType.NVarChar, 100);
                        SQLInterimPartner.Parameters.Add("@City", SqlDbType.NVarChar, 50);
                        SQLInterimPartner.Parameters.Add("@Country", SqlDbType.NVarChar, 20);
                        SQLInterimPartner.Parameters.Add("@Description", SqlDbType.NVarChar, 100);
                        SQLInterimPartner.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 20);
                        SQLInterimPartner.Parameters.Add("@State", SqlDbType.NVarChar, 20);

                        if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS != null)
                        {
                            SQLInterimPartner.Parameters["@GUID"].Value = guid.ToString();
                            SQLInterimPartner.Parameters["@Partner"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.PARTNRID ?? DBNull.Value;
                            SQLInterimPartner.Parameters["@Name"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.NAME.Value ?? DBNull.Value;
                            SQLInterimPartner.Parameters["@PartnerType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.PARTNRTYPE ?? DBNull.Value;

                            if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].ADDRLINE.Length >= 1)
                            {
                                if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].ADDRLINE[0] != null)
                                {
                                    SQLInterimPartner.Parameters["@Addr1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].ADDRLINE[0].Value ?? DBNull.Value;
                                }
                                else { SQLInterimPartner.Parameters["@Addr1"].Value = ""; }
                            }

                            if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].ADDRLINE.Length >= 2)
                            {
                                if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].ADDRLINE[1] != null)
                                {
                                    SQLInterimPartner.Parameters["@Addr2"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].ADDRLINE[1].Value ?? DBNull.Value;
                                }
                                else { SQLInterimPartner.Parameters["@Addr2"].Value = ""; }
                            }
                            if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].ADDRLINE.Length >= 3)
                            {
                                if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].ADDRLINE[2] != null)
                                {
                                    SQLInterimPartner.Parameters["@Addr3"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].ADDRLINE[2].Value ?? DBNull.Value;
                                }
                                else { SQLInterimPartner.Parameters["@Addr3"].Value = ""; }
                            }

                            SQLInterimPartner.Parameters["@City"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].CITY ?? DBNull.Value;
                            SQLInterimPartner.Parameters["@Country"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].COUNTRY ?? DBNull.Value;
                            SQLInterimPartner.Parameters["@Description"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].DESCRIPTN ?? DBNull.Value;
                            SQLInterimPartner.Parameters["@ZipCode"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].POSTALCODE ?? DBNull.Value;
                            SQLInterimPartner.Parameters["@State"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.POORDERHDR_USERAREA.INTERIM_ADDR.PARTNER.ADDRESS[0].STATEPROVN ?? DBNull.Value;


                            SQLInterimPartner.ExecuteNonQuery();
                        }

                    }







                    for (int i = 0; i < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER.Length; i++)
                    {

                        if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS == null)
                        {
                            SQLPOPartner.Parameters["@GUID"].Value = guid.ToString();
                            SQLPOPartner.Parameters["@Partner"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRID ?? DBNull.Value;
                            SQLPOPartner.Parameters["@Name"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].NAME.Value ?? DBNull.Value;
                            SQLPOPartner.Parameters["@PartnerType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRTYPE ?? DBNull.Value;
                            SQLPOPartner.ExecuteNonQuery();
                        }


                        if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS != null)
                        {
                            for (int j = 0; j < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS.Length; j++)
                            {
                                SQLPOPartner.Parameters["@GUID"].Value = guid.ToString();
                                SQLPOPartner.Parameters["@Partner"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRID ?? DBNull.Value;
                                SQLPOPartner.Parameters["@Name"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].NAME.Value ?? DBNull.Value;
                                SQLPOPartner.Parameters["@PartnerType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRTYPE ?? DBNull.Value;

                                SQLPOPartner.Parameters["@AddrType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRTYPE ?? DBNull.Value;
                                if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE.Length >= 1)
                                {
                                    if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[0] != null)
                                    {
                                        SQLPOPartner.Parameters["@Addr1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[0].Value ?? DBNull.Value;
                                    }
                                    else { SQLPOPartner.Parameters["@Addr1"].Value = ""; }
                                }

                                if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE.Length >= 2)
                                {
                                    if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[1] != null)
                                    {
                                        SQLPOPartner.Parameters["@Addr2"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[1].Value ?? DBNull.Value;
                                    }
                                    else { SQLPOPartner.Parameters["@Addr2"].Value = ""; }
                                }
                                if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE.Length >= 3)
                                {
                                    if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[2] != null)
                                    {
                                        SQLPOPartner.Parameters["@Addr3"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].ADDRLINE[2].Value ?? DBNull.Value;
                                    }
                                    else { SQLPOPartner.Parameters["@Addr3"].Value = ""; }
                                }
                                SQLPOPartner.Parameters["@City"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].CITY ?? DBNull.Value;
                                SQLPOPartner.Parameters["@Country"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].COUNTRY ?? DBNull.Value;
                                SQLPOPartner.Parameters["@Description"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].DESCRIPTN ?? DBNull.Value;
                                SQLPOPartner.Parameters["@ZipCode"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].POSTALCODE ?? DBNull.Value;
                                SQLPOPartner.Parameters["@State"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].ADDRESS[j].STATEPROVN ?? DBNull.Value;

                                SQLPOPartner.ExecuteNonQuery();
                            }
                        }
                    }

                    SqlCommand SQLPOContact = new SqlCommand();
                    SQLPOContact.Connection = con;
                    SQLPOContact.CommandText = "sp_InsertPOContact";
                    SQLPOContact.CommandType = CommandType.StoredProcedure;
                    SQLPOContact.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLPOContact.Parameters.Add("@Partner", SqlDbType.NVarChar, 50);
                    SQLPOContact.Parameters.Add("@PartnerType", SqlDbType.NVarChar, 20);
                    SQLPOContact.Parameters.Add("@Contact", SqlDbType.NVarChar, 100);
                    SQLPOContact.Parameters.Add("@ContactType", SqlDbType.NVarChar, 30);
                    SQLPOContact.Parameters.Add("@ContactEmail", SqlDbType.NVarChar, 100);
                    SQLPOContact.Parameters.Add("@Phone", SqlDbType.NVarChar, 50);
                    SQLPOContact.Parameters.Add("@Fax", SqlDbType.NVarChar, 50);
                    SQLPOContact.Parameters.Add("@Name1", SqlDbType.NVarChar, 100);


                    for (int i = 0; i < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER.Length; i++)
                    {
                        if (resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT != null)
                        {
                            for (int j = 0; j < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT.Length; j++)
                            {
                                SQLPOContact.Parameters["@GUID"].Value = guid.ToString();
                                SQLPOContact.Parameters["@Partner"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRID ?? DBNull.Value;
                                SQLPOContact.Parameters["@PartnerType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].PARTNRTYPE ?? DBNull.Value;
                                SQLPOContact.Parameters["@Contact"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].NAME.Value ?? DBNull.Value;
                                SQLPOContact.Parameters["@ContactType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].CONTCTTYPE ?? DBNull.Value;
                                SQLPOContact.Parameters["@ContactEmail"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].EMAIL ?? DBNull.Value;
                                SQLPOContact.Parameters["@Phone"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].TELEPHONE ?? DBNull.Value;
                                SQLPOContact.Parameters["@Fax"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].FAX ?? DBNull.Value;
                                SQLPOContact.Parameters["@Name1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERHDR.PARTNER[i].CONTACT[j].NAME1 ?? DBNull.Value;
                                SQLPOContact.ExecuteNonQuery();
                            }
                        }
                    }

                    //insert line
                    SqlCommand SQLPOLine = new SqlCommand();
                    SQLPOLine.Connection = con;
                    SQLPOLine.CommandText = "sp_InsertPOLine";
                    SQLPOLine.CommandType = CommandType.StoredProcedure;
                    SQLPOLine.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLPOLine.Parameters.Add("@QtyQualifier", SqlDbType.NVarChar, 50);
                    SQLPOLine.Parameters.Add("@Qty", SqlDbType.NVarChar, 10);
                    SQLPOLine.Parameters.Add("@QtyDec", SqlDbType.NVarChar, 5);
                    SQLPOLine.Parameters.Add("@QtySign", SqlDbType.NVarChar, 3);
                    SQLPOLine.Parameters.Add("@QtyUOM", SqlDbType.NVarChar, 5);
                    SQLPOLine.Parameters.Add("@DateQualifier1", SqlDbType.NVarChar, 50);
                    SQLPOLine.Parameters.Add("@Year1", SqlDbType.NVarChar, 10);
                    SQLPOLine.Parameters.Add("@Month1", SqlDbType.NVarChar, 3);
                    SQLPOLine.Parameters.Add("@Day1", SqlDbType.NVarChar, 3);
                    SQLPOLine.Parameters.Add("@DateQualifier2", SqlDbType.NVarChar, 50);
                    SQLPOLine.Parameters.Add("@Year2", SqlDbType.NVarChar, 10);
                    SQLPOLine.Parameters.Add("@Month2", SqlDbType.NVarChar, 3);
                    SQLPOLine.Parameters.Add("@Day2", SqlDbType.NVarChar, 3);
                    SQLPOLine.Parameters.Add("@DateQualifier3", SqlDbType.NVarChar, 50);
                    SQLPOLine.Parameters.Add("@Year3", SqlDbType.NVarChar, 10);
                    SQLPOLine.Parameters.Add("@Month3", SqlDbType.NVarChar, 3);
                    SQLPOLine.Parameters.Add("@Day3", SqlDbType.NVarChar, 3);
                    SQLPOLine.Parameters.Add("@LineNum", SqlDbType.NVarChar, 5);
                    SQLPOLine.Parameters.Add("@Packing", SqlDbType.NVarChar, 10);
                    SQLPOLine.Parameters.Add("@PartType", SqlDbType.NVarChar, 50);
                    SQLPOLine.Parameters.Add("@PartNo", SqlDbType.NVarChar, 50);
                    SQLPOLine.Parameters.Add("@PartClass", SqlDbType.NVarChar, 10);
                    SQLPOLine.Parameters.Add("@PartKey", SqlDbType.NVarChar, 50);
                    SQLPOLine.Parameters.Add("@PartQual", SqlDbType.NVarChar, 50);
                    SQLPOLine.Parameters.Add("@SiteLevel", SqlDbType.NVarChar, 50);
                    SQLPOLine.Parameters.Add("@ItemType", SqlDbType.NVarChar, 50);

                    for (int i = 0; i < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN.Length; i++)
                    {
                        for (int j = 0; j < resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY.Length; j++)
                        {
                            SQLPOLine.Parameters["@GUID"].Value = guid.ToString();
                            SQLPOLine.Parameters["@QtyQualifier"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].qualifier ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@Qty"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].VALUE ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@QtyDec"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].NUMOFDEC ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@QtySign"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].SIGN ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@QtyUOM"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].QUANTITY[j].UOM ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@DateQualifier1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].DATETIME.qualifier ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@Year1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].DATETIME.YEAR ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@Month1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].DATETIME.MONTH ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@Day1"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].DATETIME.DAY ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@LineNum"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].POLINENUM ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@Packing"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PACKING ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@PartType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTTYPE ?? DBNull.Value; ;
                            SQLPOLine.Parameters["@PartNo"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTNO ?? DBNull.Value;
                            SQLPOLine.Parameters["@PartClass"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTCLASS ?? DBNull.Value;
                            SQLPOLine.Parameters["@PartKey"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTKEY ?? DBNull.Value;
                            SQLPOLine.Parameters["@PartQual"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].PARTREF[0].PARTQUAL ?? DBNull.Value;
                            SQLPOLine.Parameters["@SiteLevel"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].POORDERLIN_USERAREA.SITELEVEL.Value ?? DBNull.Value;
                            SQLPOLine.Parameters["@ItemType"].Value = (object)resultingMessage.DATAAREA[0].PROCESS_PO.POORDERLIN[i].POORDERLIN_USERAREA.ITEMTYPE ?? DBNull.Value;

                            SQLPOLine.ExecuteNonQuery();
                        }
                    }
                    //return data
                    SqlCommand SQLShowControlArea = new SqlCommand();
                    SQLShowControlArea.Connection = con;

                    SQLShowControlArea.CommandText = "sp_AckPOControlArea";
                    SQLShowControlArea.CommandType = CommandType.StoredProcedure;
                    SQLShowControlArea.CommandTimeout = 300;

                    SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLShowControlArea.Parameters["@TransId"].Value = TransID;
                    var x1 = new CONFIRM_BOD_003();
                    var x = new acknowledgepo.ACKNOWLEDGE_PO_006();
                    var iserror = "N";

                    using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr[1].ToString() == "BOD")
                                {
                                    iserror = "Y";

                                    x1 = new CONFIRM_BOD_003();

                                }
                                else
                                {

                                    x = new acknowledgepo.ACKNOWLEDGE_PO_006()
                                    {
                                        CNTROLAREA = new acknowledgepo.CNTROLAREA()
                                        {
                                            BSR = new acknowledgepo.BSR()
                                            {
                                                VERB = new acknowledgepo.VERB() { Value = dr[0].ToString() },
                                                NOUN = new acknowledgepo.NOUN()
                                                {
                                                    Value = dr[1].ToString()
                                                },
                                                REVISION = new acknowledgepo.REVISION() { Value = dr[2].ToString() }
                                            },
                                            SENDER = new acknowledgepo.SENDER()
                                            {
                                                LOGICALID = dr[3].ToString(),
                                                COMPONENT = dr[4].ToString(),
                                                TASK = dr[5].ToString(),
                                                REFERENCEID = dr[6].ToString(),
                                                CONFIRMATION = dr[7].ToString(),
                                                LANGUAGE = dr[8].ToString(),
                                                CODEPAGE = dr[9].ToString(),
                                                AUTHID = dr["Sender_Authid"].ToString()

                                            },
                                            DATETIME = new acknowledgepo.DATETIME()
                                            {
                                                qualifier = acknowledgepo.DATETIMEQualifier.CREATION,
                                                YEAR = dr[11].ToString(),
                                                MONTH = dr[12].ToString(),
                                                DAY = dr[13].ToString()
                                                                           ,
                                                HOUR = dr[14].ToString(),
                                                MINUTE = dr[15].ToString(),
                                                SECOND = dr[16].ToString(),
                                                SUBSECOND = dr[17].ToString(),
                                                TIMEZONE = dr[18].ToString()
                                            }
                                        }
                                    };
                                }
                            }
                        }
                    }


                    SqlCommand SQLAckPO = new SqlCommand();
                    SQLAckPO.Connection = con;
                    SQLAckPO.CommandText = "sp_ShowAckPODataArea";
                    SQLAckPO.CommandType = CommandType.StoredProcedure;
                    SQLAckPO.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLAckPO.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLAckPO.Parameters["@GUID"].Value = guid.ToString();
                    SQLAckPO.Parameters["@TransId"].Value = "0";


                    if (iserror == "Y")
                    {

                        using (SqlDataReader drbod = SQLAckPO.ExecuteReader())
                        {
                            if (drbod.HasRows)
                            {
                                DataTable dt = new DataTable(); dt.Load(drbod);
                                BOD.DATAAREA[] dx1 = new BOD.DATAAREA[1];
                                x1.DATAAREA = dx1;

                            }
                        }
                    }

                    else
                    {
                        SQLAckPO.CommandTimeout = 180;
                        using (SqlDataReader dr1 = SQLAckPO.ExecuteReader())
                        {
                            SQLAckPO.CommandTimeout = 180;
                            if (dr1.HasRows)
                            {
                                DataTable dt = new DataTable(); dt.Load(dr1);
                                acknowledgepo.DATAAREA[] d = new acknowledgepo.DATAAREA[1];

                                int maxpartner = 0; int maxpoline = 0;
                                acknowledgepo.PARTNER[] Partner = new acknowledgepo.PARTNER[Convert.ToInt32(dt.Rows[0]["MaxPartnerLine"].ToString())];
                                acknowledgepo.POORDERLIN[] poline = new acknowledgepo.POORDERLIN[Convert.ToInt32(dt.Rows[0]["MaxPOLine"].ToString())];

                                for (int o = 0; o < 1; o++)
                                {
                                    d[o] = new acknowledgepo.DATAAREA();

                                    for (int p = 0; p < dt.Rows.Count; p++)
                                    {
                                        if (dt.Rows[p]["Partnerid"].ToString() == "1")
                                        {

                                            acknowledgepo.PARTNER lspartner = new acknowledgepo.PARTNER();
                                            acknowledgepo.NAME name = new acknowledgepo.NAME();

                                            name.index = "1";
                                            name.Value = dt.Rows[p]["Name"].ToString().Trim();
                                            lspartner.NAME = name;

                                            lspartner.PARTNRID = dt.Rows[p]["Partner"].ToString().Trim();
                                            lspartner.PARTNRTYPE = dt.Rows[p]["PartnerType"].ToString().Trim();

                                            acknowledgepo.ADDRESS lspartadd = new acknowledgepo.ADDRESS();
                                            acknowledgepo.ADDRESS[] lspartaddarray = new acknowledgepo.ADDRESS[2];
                                            int maxaddr = 0; var partexist = "N";
                                            for (int k = 0; k < dt.Rows.Count; k++)
                                            {


                                                if (
                                                     dt.Rows[p]["Partner"].ToString().Trim() == dt.Rows[k]["Partner"].ToString().Trim() &&
                                                    dt.Rows[k]["Partnerid"].ToString().Trim() == "1"
                                                            && dt.Rows[p]["PartnerType"].ToString().Trim() == dt.Rows[k]["PartnerType"].ToString().Trim()
                                                            && dt.Rows[p]["PartnerType"].ToString().Trim() != "Carrier"

                                                            )
                                                { partexist = "N"; }
                                                if (
                                                    dt.Rows[p]["Partner"].ToString().Trim() == dt.Rows[k]["Partner"].ToString().Trim() &&
                                                   dt.Rows[k]["Addressid"].ToString().Trim() == "1"
                                                           && dt.Rows[p]["PartnerType"].ToString().Trim() == dt.Rows[k]["PartnerType"].ToString().Trim()
                                                           && dt.Rows[p]["PartnerType"].ToString().Trim() != "Carrier")
                                                { partexist = "N"; }
                                                else { partexist = "Y"; }

                                                if (dt.Rows[p]["PartnerType"].ToString().Trim() == "Carrier") { Partner[maxpartner] = lspartner; }

                                                if (partexist == "N")
                                                {
                                                    lspartaddarray[maxaddr] = new acknowledgepo.ADDRESS();
                                                    acknowledgepo.ADDRLINE lspartaddline = new acknowledgepo.ADDRLINE();
                                                    acknowledgepo.ADDRLINE[] lspartaddlinearray = new acknowledgepo.ADDRLINE[3];

                                                    acknowledgepo.CONTACT lspartcontact = new acknowledgepo.CONTACT();
                                                    acknowledgepo.CONTACT[] lspartcontactarray = new acknowledgepo.CONTACT[3];

                                                    acknowledgepo.TELEPHONE[] ph = new acknowledgepo.TELEPHONE[1];
                                                    acknowledgepo.FAX[] fax = new acknowledgepo.FAX[1];
                                                    acknowledgepo.NAME[] name1 = new acknowledgepo.NAME[1];

                                                    acknowledgepo.NAME nm = new acknowledgepo.NAME();
                                                    acknowledgepo.NAME nm1 = new acknowledgepo.NAME();


                                                    if (dt.Rows[k]["Contact"].ToString().Trim() != "")
                                                    {
                                                        lspartcontact = new acknowledgepo.CONTACT();
                                                        nm.index = "1";
                                                        nm.Value = dt.Rows[k]["Contact"].ToString().Trim();
                                                        lspartcontact.NAME = nm;
                                                        lspartcontact.CONTCTTYPE = dt.Rows[k]["ContactType"].ToString().Trim();
                                                        lspartcontact.EMAIL = dt.Rows[k]["ContactEmail"].ToString().Trim();

                                                        ph[0] = new acknowledgepo.TELEPHONE();
                                                        ph[0].Value = dt.Rows[k]["Phone"].ToString().Trim();
                                                        ph[0].index = "1";
                                                        lspartcontact.TELEPHONE = ph;

                                                        fax[0] = new acknowledgepo.FAX();
                                                        fax[0].Value = dt.Rows[k]["Fax"].ToString().Trim(); ;
                                                        fax[0].index = "1";
                                                        lspartcontact.FAX = fax;

                                                        name1[0] = new acknowledgepo.NAME();
                                                        name1[0].Value = dt.Rows[k]["Name1"].ToString().Trim();
                                                        name1[0].index = "2";
                                                        // lspartcontact.NAME1 = name1;

                                                        lspartcontactarray[0] = new acknowledgepo.CONTACT();
                                                        lspartcontactarray[0] = lspartcontact;
                                                    }

                                                    lspartaddline.index = "1";
                                                    lspartaddline.Value = dt.Rows[k]["Addr1"].ToString().Trim();
                                                    lspartaddlinearray[0] = new acknowledgepo.ADDRLINE();
                                                    lspartaddlinearray[0] = lspartaddline;

                                                    acknowledgepo.ADDRLINE lspartaddline1 = new acknowledgepo.ADDRLINE();
                                                    lspartaddline1.index = "2";
                                                    lspartaddline1.Value = dt.Rows[k]["Addr2"].ToString().Trim();
                                                    lspartaddlinearray[1] = new acknowledgepo.ADDRLINE();
                                                    lspartaddlinearray[1] = lspartaddline1;

                                                    acknowledgepo.ADDRLINE lspartaddline2 = new acknowledgepo.ADDRLINE();
                                                    lspartaddline2.index = "3";
                                                    lspartaddline2.Value = dt.Rows[k]["Addr3"].ToString();
                                                    lspartaddlinearray[2] = new acknowledgepo.ADDRLINE();
                                                    lspartaddlinearray[2] = lspartaddline2;

                                                    lspartaddarray[maxaddr] = new acknowledgepo.ADDRESS();
                                                    lspartaddarray[maxaddr].ADDRLINE = lspartaddlinearray;
                                                    lspartaddarray[maxaddr].ADDRTYPE = dt.Rows[k]["AddrType"].ToString().Trim();
                                                    lspartaddarray[maxaddr].CITY = dt.Rows[k]["City"].ToString().Trim();
                                                    lspartaddarray[maxaddr].POSTALCODE = dt.Rows[k]["ZipCode"].ToString().Trim();
                                                    lspartaddarray[maxaddr].STATEPROVN = dt.Rows[k]["State"].ToString().Trim();
                                                    lspartaddarray[maxaddr].COUNTRY = dt.Rows[k]["Country"].ToString().Trim();
                                                    lspartaddarray[maxaddr].DESCRIPTN = dt.Rows[k]["Description"].ToString().Trim();

                                                    if ("1" == dt.Rows[p]["Contactid"].ToString().Trim() && dt.Rows[p]["Contact"].ToString().Trim() != "")
                                                    {
                                                        lspartner.CONTACT = lspartcontactarray;
                                                    }
                                                    lspartner.ADDRESS = lspartaddarray;
                                                    Partner[maxpartner] = lspartner;
                                                    maxaddr++;

                                                }

                                            }
                                            maxpartner++;

                                        }

                                        if (dt.Rows[p]["Lineid"].ToString() == "1")
                                        {
                                            acknowledgepo.POORDERLIN pln = new acknowledgepo.POORDERLIN();
                                            acknowledgepo.QUANTITY shqty = new acknowledgepo.QUANTITY();
                                            shqty.NUMOFDEC = dt.Rows[p]["QtyDec"].ToString().Trim();
                                            shqty.VALUE = dt.Rows[p]["Qty"].ToString().Trim();
                                            shqty.SIGN = dt.Rows[p]["QtySign"].ToString().Trim();
                                            shqty.UOM = dt.Rows[p]["QtyUOM"].ToString().Trim();
                                            shqty.qualifier = acknowledgepo.QUANTITYQualifier.ORDERED;
                                            poline[maxpoline] = new acknowledgepo.POORDERLIN();

                                            acknowledgepo.DATETIME lsdt = new acknowledgepo.DATETIME();
                                            lsdt.qualifier = acknowledgepo.DATETIMEQualifier.NEEDDELV;
                                            lsdt.YEAR = dt.Rows[p]["Year1"].ToString().Trim();
                                            lsdt.MONTH = dt.Rows[p]["Month1"].ToString().Trim();
                                            lsdt.DAY = dt.Rows[p]["Day1"].ToString().Trim();
                                            lsdt.HOUR = "00";
                                            lsdt.MINUTE = "00";
                                            lsdt.SECOND = "00";
                                            lsdt.SUBSECOND = "0000";
                                            lsdt.TIMEZONE = dt.Rows[p]["TimeZone"].ToString();

                                            pln.POLINENUM = dt.Rows[p]["LineNum"].ToString().Trim();
                                            pln.PACKING = dt.Rows[p]["Packing"].ToString().Trim();

                                            acknowledgepo.PARTREF lspart = new acknowledgepo.PARTREF();
                                            lspart.PARTTYPE = dt.Rows[p]["PartType"].ToString().Trim();
                                            lspart.PARTNO = dt.Rows[p]["PartNo"].ToString().Trim();
                                            lspart.PARTKEY = dt.Rows[p]["PartKey"].ToString().Trim();
                                            lspart.PARTQUAL = dt.Rows[p]["PartQual"].ToString().Trim();
                                            lspart.PARTCLASS = dt.Rows[p]["PartClass"].ToString().Trim();

                                            acknowledgepo.POORDERLIN_USERAREA lsusr = new acknowledgepo.POORDERLIN_USERAREA();
                                            acknowledgepo.SITELEVEL site = new acknowledgepo.SITELEVEL();
                                            site.Value = dt.Rows[p]["SiteLevel"].ToString().Trim();
                                            site.index = dt.Rows[p]["SiteIndex"].ToString();
                                            lsusr.SITELEVEL = site;

                                            acknowledgepo.ACKLINE lsack = new acknowledgepo.ACKLINE();
                                            lsack.ACKCODE = dt.Rows[p]["LineAckCode"].ToString();

                                            poline[maxpoline].QUANTITY = shqty;
                                            poline[maxpoline].ACKLINE = lsack;
                                            poline[maxpoline].DATETIME = lsdt;
                                            acknowledgepo.PARTREF[] parray = new acknowledgepo.PARTREF[1];
                                            parray[0] = new acknowledgepo.PARTREF();
                                            parray[0] = lspart;
                                            poline[maxpoline].PARTREF = parray;
                                            poline[maxpoline].POLINENUM = dt.Rows[p]["LineNum"].ToString().Trim();
                                            poline[maxpoline].PACKING = dt.Rows[p]["Packing"].ToString().Trim();
                                            poline[maxpoline].POORDERLIN_USERAREA = lsusr;

                                            maxpoline++;
                                        }

                                        acknowledgepo.POORDERHDR hdr = new acknowledgepo.POORDERHDR();
                                        hdr.POID = dt.Rows[p]["POID"].ToString();
                                        hdr.POTYPE = dt.Rows[p]["POType"].ToString();
                                        hdr.NOTES = dt.Rows[p]["Notes"].ToString();
                                        hdr.ACKREQUEST = dt.Rows[p]["AckRequest"].ToString();
                                        hdr.PARTNER = Partner;
                                        acknowledgepo.ACKNOWLEDGE_PO ackpo = new acknowledgepo.ACKNOWLEDGE_PO();

                                        acknowledgepo.POORDERHDR_USERAREA pohrusr = new acknowledgepo.POORDERHDR_USERAREA();
                                        pohrusr.COLINX_ORDTRANSID = dt.Rows[p]["OrdTransId"].ToString();

                                        acknowledgepo.COLINX_SHIPINSTR shpinstr = new acknowledgepo.COLINX_SHIPINSTR();
                                        shpinstr.COLINX_ORDERTYPE = dt.Rows[p]["ShipInstr_OrderType"].ToString();
                                        shpinstr.COLINX_FRTBILLTYPE = dt.Rows[p]["ShipInstr_FrtBillType"].ToString();
                                        shpinstr.COLINX_DEVIATEFLG = dt.Rows[p]["ShipInstr_Deviateflg"].ToString();
                                        shpinstr.COLINX_PARTSHIP = dt.Rows[p]["ShipInstr_PartShip"].ToString();
                                        pohrusr.COLINX_SHIPINSTR = shpinstr;
                                        pohrusr.COLINX_DIVISION = dt.Rows[p]["Division"].ToString();
                                        shpinstr.COLINX_FRTACCTNUM = dt.Rows[p]["ShipInstr_FrtAcct"].ToString();
                                        hdr.POORDERHDR_USERAREA = pohrusr;

                                        acknowledgepo.ACKHEADER ackhr = new acknowledgepo.ACKHEADER();

                                        ackhr.ACKCODE = dt.Rows[p]["AckCode"].ToString();
                                        ackhr.DESCRIPTN = dt.Rows[p]["AckDesc"].ToString();
                                        ackhr.SALESORDID = dt.Rows[p]["SO"].ToString();
                                        hdr.ACKHEADER = ackhr;
                                        ackpo.POORDERHDR = hdr;

                                        d[0].ACKNOWLEDGE_PO = ackpo;



                                        d[0].ACKNOWLEDGE_PO = new acknowledgepo.ACKNOWLEDGE_PO();
                                        d[0].ACKNOWLEDGE_PO.POORDERHDR = new acknowledgepo.POORDERHDR();

                                        d[0].ACKNOWLEDGE_PO.POORDERHDR = hdr;
                                        d[0].ACKNOWLEDGE_PO.POORDERHDR.ACKHEADER = ackhr;
                                        d[0].ACKNOWLEDGE_PO.POORDERLIN = poline;
                                    }
                                    x.DATAAREA = d;
                                }
                            }

                        }

                    }
                    return x;
                }
            }
            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand SQLInvalidXml = new SqlCommand();
                    SQLInvalidXml.Connection = con;
                    con.Open();
                    SQLInvalidXml.CommandText = "sp_InvalidXML";
                    SQLInvalidXml.CommandType = CommandType.StoredProcedure;
                    SQLInvalidXml.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLInvalidXml.Parameters.Add("@GUIErr", SqlDbType.NVarChar, 4);
                    SQLInvalidXml.Parameters.Add("@GUImsg", SqlDbType.NVarChar, 5000);
                    SQLInvalidXml.Parameters["@GUID"].Value = guid.ToString();
                    SQLInvalidXml.Parameters["@GUIErr"].Value = "2516";
                    SQLInvalidXml.Parameters["@GUImsg"].Value = msg;
                    SQLInvalidXml.ExecuteNonQuery();
                    Session["Errmsg"] = guid;// msg;
                }

                var x = new acknowledgepo.ACKNOWLEDGE_PO_006();
                return x;
            }
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public SHOW_HOSTPING_001 SHOW_HOSTPING_001(object gethostping, string MsgType, string MsgTypeVersion, string Sender, string TransID)
        {

            var xmlstring = ((System.Xml.XmlNode[])gethostping)[0].Value.ToString();
            var Checkmsg = checkxml(xmlstring, "HostPing");
            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;
            Guid guid = Guid.NewGuid();

            if (Checkmsg.Trim() == "")
            {

                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList xmlnode;

                XmlSerializer serializer = new XmlSerializer(typeof(GET_HOSTPING_001));


                var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment, IgnoreWhitespace = true, IgnoreComments = true };

                var sw = new StringReader(xmlstring);
                var sw1 = new StringReader(xmlstring);



                using (XmlTextReader reader1 = new XmlTextReader(sw))
                {
                    reader1.DtdProcessing = DtdProcessing.Ignore;
                    while (reader1.Read())
                    {

                        switch (reader1.NodeType)
                        {
                            case XmlNodeType.Element: // The node is an element.
                                Console.Write("<" + reader1.Name);

                                Console.WriteLine(">");
                                break;
                            case XmlNodeType.Text: //Display the text in each element.
                                Console.WriteLine(reader1.Value);
                                break;
                            case XmlNodeType.EndElement: //Display the end of the element.
                                Console.Write("</" + reader1.Name);
                                Console.WriteLine(">");
                                break;
                        }
                    }
                }
                GET_HOSTPING_001 resultingMessage = (GET_HOSTPING_001)new XmlSerializer(typeof(GET_HOSTPING_001)).Deserialize(sw1);

                SHOW_HOSTPING_001 objshowhostping = new SHOW_HOSTPING_001();


                using (SqlConnection con = new SqlConnection(cs))
                {
                    //   var guid = new Guid();

                    SqlCommand SQLXMLHeader = new SqlCommand();
                    SQLXMLHeader.Connection = con;
                    con.Open();
                    SQLXMLHeader.CommandText = "InsertXMLHeader";
                    SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                    SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                    SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                    SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                    SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                    SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                    SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                    SQLXMLHeader.ExecuteNonQuery();

                    //control area
                    SqlCommand SQLControlAra = new SqlCommand();
                    SQLControlAra.Connection = con;
                    SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                    SQLControlAra.CommandType = CommandType.StoredProcedure;
                    SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                    SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                    SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                    SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                    SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                    SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                    SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                    SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                    SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                    SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                    SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                    SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                    SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                    SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                    SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                    SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                    SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                    SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                    SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                    SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                    SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                    SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                    SQLControlAra.Parameters["@TransId"].Value = TransID;
                    SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                    SQLControlAra.ExecuteNonQuery();


                    //data area 
                    SqlCommand SQLDataArea = new SqlCommand();
                    SQLDataArea.Connection = con;

                    SQLDataArea.CommandText = "SP_GetHostpingDataArea";
                    SQLDataArea.CommandType = CommandType.StoredProcedure;

                    SQLDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLDataArea.Parameters.Add("@DataArea_GetHostPing_ColinxHostid", SqlDbType.NVarChar, 50);
                    SQLDataArea.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);

                    for (int k = 0; k < resultingMessage.DATAAREA.Length; k++)
                    {
                        SQLDataArea.Parameters["@GUID"].Value = guid.ToString();
                        SQLDataArea.Parameters["@Tranid"].Value = TransID;
                        SQLDataArea.Parameters["@DataArea_GetHostPing_ColinxHostid"].Value = resultingMessage.DATAAREA[k].GETHOSTPING.COLINX_HOSTID.ToString(); ;
                        SQLDataArea.ExecuteNonQuery();

                    }

                    //return show host ping
                    SqlCommand SQLShowControlArea = new SqlCommand();
                    SQLShowControlArea.Connection = con;

                    SQLShowControlArea.CommandText = "sp_ShowHostPingDataControlArea";
                    SQLShowControlArea.CommandType = CommandType.StoredProcedure;

                    SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLShowControlArea.Parameters["@TransId"].Value = TransID;
                    //  SqlDataReader dr;
                    //  dr = SQLShowControlArea.ExecuteReader();
                    var x = new SHOW_HOSTPING_001();
                    using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                x = new SHOW_HOSTPING_001()
                                {
                                    CNTROLAREA = new WebService.asmx.Response.CNTROLAREA()
                                    {
                                        BSR = new WebService.asmx.Response.BSR()
                                        {
                                            VERB = new WebService.asmx.Response.VERB() { Value = dr[0].ToString() },
                                            NOUN = new WebService.asmx.Response.NOUN()
                                            {
                                                // value = dr[1].ToString(),
                                                Value = dr[1].ToString()
                                            },
                                            REVISION = new WebService.asmx.Response.REVISION() { Value = dr[2].ToString() }
                                        },
                                        SENDER = new WebService.asmx.Response.SENDER()
                                        {
                                            LOGICALID = dr[3].ToString(),
                                            COMPONENT = dr[4].ToString(),
                                            TASK = dr[5].ToString(),
                                            REFERENCEID = dr[6].ToString(),
                                            CONFIRMATION = dr[7].ToString(),
                                            LANGUAGE = dr[8].ToString(),
                                            CODEPAGE = dr[9].ToString(),
                                            AUTHID = dr[10].ToString()

                                        },
                                        DATETIME = new WebService.asmx.Response.DATETIME()
                                        {
                                            qualifier = Response.DATETIMEQualifier.CREATION,
                                            YEAR = dr[11].ToString(),
                                            MONTH = dr[12].ToString(),
                                            DAY = dr[13].ToString()
                                                                       ,
                                            HOUR = dr[14].ToString(),
                                            MINUTE = dr[15].ToString(),
                                            SECOND = dr[16].ToString(),
                                            SUBSECOND = dr[17].ToString(),
                                            TIMEZONE = dr[18].ToString()
                                        }
                                    }
                                };

                            }
                        }
                    }


                    //showhostping data area
                    SqlCommand SQLShowDataArea = new SqlCommand();
                    SQLShowDataArea.Connection = con;

                    SQLShowDataArea.CommandText = "sp_ShowHostPingDataArea";
                    SQLShowDataArea.CommandType = CommandType.StoredProcedure;

                    SQLShowDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLShowDataArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLShowDataArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLShowDataArea.Parameters["@TransId"].Value = TransID;


                    using (SqlDataReader dr1 = SQLShowDataArea.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr1);
                        int dcount = Convert.ToInt32(dt.Rows.Count.ToString());
                        WebService.asmx.Response.DATAAREA[] d = new WebService.asmx.Response.DATAAREA[dcount];
                        string[] msg = new string[dcount];
                        int ki = 1; int msgk = 0;
                        if (dt.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt.Rows.Count; k++)
                            {
                                if (Convert.ToInt32(dt.Rows[k][4]) == ki)
                                { d[ki - 1] = new WebService.asmx.Response.DATAAREA(); ki++; msgk = 0; }

                                msg[msgk] = dt.Rows[k][3].ToString();
                                SHOWHOSTPING sh = new SHOWHOSTPING();

                                sh.COLINX_HOSTID = dt.Rows[k][0].ToString();
                                sh.COLINX_MESSAGE = msg;
                                d[ki - 2].SHOWHOSTPING = sh;
                                msgk++;
                            }

                        }
                        x.DATAAREA = d; objshowhostping = x;
                    }
                    CONFIRM_BOD_003 cb = new CONFIRM_BOD_003();
                    WebService.asmx.BOD.DATAAREA bod = new WebService.asmx.BOD.DATAAREA();

                }
                return objshowhostping;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand SQLInvalidXml = new SqlCommand();
                    SQLInvalidXml.Connection = con;
                    con.Open();
                    SQLInvalidXml.CommandText = "sp_InvalidXML";
                    SQLInvalidXml.CommandType = CommandType.StoredProcedure;
                    SQLInvalidXml.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLInvalidXml.Parameters.Add("@GUIErr", SqlDbType.NVarChar, 4);
                    SQLInvalidXml.Parameters.Add("@GUImsg", SqlDbType.NVarChar, 5000);
                    SQLInvalidXml.Parameters["@GUID"].Value = guid.ToString();
                    SQLInvalidXml.Parameters["@GUIErr"].Value = "2516";
                    SQLInvalidXml.Parameters["@GUImsg"].Value = Checkmsg;
                    SQLInvalidXml.ExecuteNonQuery();
                    Session["Errmsg"] = guid;// msg;
                }

                var x = new SHOW_HOSTPING_001();
                return x;
            }
        }

        public SHOW_PRICELIST_002 SHOW_PRICELIST_002(object getpricelist, string MsgType, string MsgTypeVersion, string Sender, string TransID)

        {
            SHOW_PRICELIST_002 sp = new SHOW_PRICELIST_002();

            var xmlstring = ((System.Xml.XmlNode[])getpricelist)[0].Value.ToString();

            var getpricelistread = new StringReader(xmlstring.Trim());
            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;
            Guid guid = Guid.NewGuid();
            var Checkmsg = checkxml(xmlstring, "GetPriceList");


            if (Checkmsg.Trim() == "")
            {

                getPriceList.GET_PRICELIST_002 resultingMessage = (getPriceList.GET_PRICELIST_002)new XmlSerializer(typeof(getPriceList.GET_PRICELIST_002)).Deserialize(getpricelistread);

                //Load data into sql
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand SQLXMLHeader = new SqlCommand();
                    SQLXMLHeader.Connection = con;
                    con.Open();
                    SQLXMLHeader.CommandText = "InsertXMLHeader";
                    SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                    SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                    SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                    SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                    SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                    SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                    SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                    SQLXMLHeader.ExecuteNonQuery();

                    //control area
                    SqlCommand SQLControlAra = new SqlCommand();
                    SQLControlAra.Connection = con;
                    SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                    SQLControlAra.CommandType = CommandType.StoredProcedure;
                    SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                    SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                    SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                    SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                    SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                    SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                    SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                    SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                    SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                    SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                    SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                    SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                    SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                    SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                    SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                    SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                    SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                    SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                    SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                    SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                    SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                    SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                    SQLControlAra.Parameters["@TransId"].Value = TransID;
                    SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                    SQLControlAra.ExecuteNonQuery();


                    //data area
                    SqlCommand SQLDataArea = new SqlCommand();
                    SQLDataArea.Connection = con;

                    SQLDataArea.CommandText = "sp_GetPricelistDataArea";
                    SQLDataArea.CommandType = CommandType.StoredProcedure;

                    SQLDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLDataArea.Parameters.Add("@Item", SqlDbType.NVarChar, 500);
                    SQLDataArea.Parameters.Add("@Type", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@ItemKey", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@Qty", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@QtyDec", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@QtyUOM", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@Customer", SqlDbType.NVarChar, 50);
                    SQLDataArea.Parameters.Add("@PriceListId", SqlDbType.NVarChar, 50);
                    SQLDataArea.Parameters.Add("@Currency", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@LineNum", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@Year", SqlDbType.NVarChar, 5);
                    SQLDataArea.Parameters.Add("@Month", SqlDbType.NVarChar, 2);
                    SQLDataArea.Parameters.Add("@Day", SqlDbType.NVarChar, 2);
                    SQLDataArea.Parameters.Add("@Minute", SqlDbType.NVarChar, 2);
                    SQLDataArea.Parameters.Add("@Second", SqlDbType.NVarChar, 2);
                    SQLDataArea.Parameters.Add("@SubSecond", SqlDbType.NVarChar, 2);
                    SQLDataArea.Parameters.Add("@TimeZone", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLDataArea.Parameters.Add("@DataArea", SqlDbType.Int);
                    SQLDataArea.Parameters.Add("@PriceListLine", SqlDbType.Int);
                    SQLDataArea.Parameters.Add("@PartRef", SqlDbType.Int);
                    SQLDataArea.Parameters.Add("@PartClass", SqlDbType.NVarChar, 50);
                    SQLDataArea.Parameters.Add("@SiteLevel", SqlDbType.NVarChar, 50);

                    for (int k = 0; k < resultingMessage.DATAAREA.Length; k++)
                    {
                        for (int l = 0; l < resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE.Length; l++)
                        {
                            for (int m = 0; m < resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF.Length; m++)
                            {
                                SQLDataArea.Parameters["@GUID"].Value = guid.ToString();
                                SQLDataArea.Parameters["@TransId"].Value = (object)TransID ?? DBNull.Value;
                                SQLDataArea.Parameters["@Item"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF[m].PARTNO.ToString();
                                SQLDataArea.Parameters["@Type"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF[m].PARTTYPE.ToString();
                                SQLDataArea.Parameters["@ItemKey"].Value = (object)resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF[m].PARTKEY ?? DBNull.Value; ;
                                SQLDataArea.Parameters["@Qty"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.QUANTITY.VALUE.ToString();
                                SQLDataArea.Parameters["@QtyDec"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.QUANTITY.NUMOFDEC.ToString();
                                SQLDataArea.Parameters["@QtyUOM"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.QUANTITY.UOM.ToString();
                                SQLDataArea.Parameters["@Customer"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PARTNRID.ToString();
                                SQLDataArea.Parameters["@Currency"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.CURRENCY.ToString();
                                SQLDataArea.Parameters["@LineNum"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].LINENUM.ToString();
                                SQLDataArea.Parameters["@Year"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.YEAR.ToString();
                                SQLDataArea.Parameters["@Month"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.MONTH.ToString();
                                SQLDataArea.Parameters["@Day"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.DAY.ToString();
                                SQLDataArea.Parameters["@Minute"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.MINUTE.ToString();
                                SQLDataArea.Parameters["@Second"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.SECOND.ToString();
                                SQLDataArea.Parameters["@SubSecond"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.SUBSECOND.ToString();
                                SQLDataArea.Parameters["@TimeZone"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.DATETIME.TIMEZONE.ToString();
                                SQLDataArea.Parameters["@PriceListId"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRICELSTID.ToString();
                                SQLDataArea.Parameters["@PartClass"].Value = (object)resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PARTREF[m].PARTCLASS ?? DBNull.Value;
                                SQLDataArea.Parameters["@SiteLevel"].Value = resultingMessage.DATAAREA[k].GET_PRICELIST.PRICELIST.PRCLSTLINE[l].PRCLSTLINE_USERAREA.SITELEVEL.Value.ToString();

                                SQLDataArea.Parameters["@DataArea"].Value = k;
                                SQLDataArea.Parameters["@PriceListLine"].Value = l;
                                SQLDataArea.Parameters["@PartRef"].Value = m;

                                SQLDataArea.ExecuteNonQuery();
                            }
                        }
                    }
                    //return show price data
                    SqlCommand SQLShowControlArea = new SqlCommand();
                    SQLShowControlArea.Connection = con;

                    SQLShowControlArea.CommandText = "sp_ShowPriceListDataControlArea";
                    SQLShowControlArea.CommandType = CommandType.StoredProcedure;

                    SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLShowControlArea.Parameters["@TransId"].Value = TransID;
                    //  SqlDataReader dr;
                    //  dr = SQLShowControlArea.ExecuteReader();
                    var x = new showPriceList.SHOW_PRICELIST_002();
                    var x1 = new CONFIRM_BOD_003();
                    var iserror = "N";

                    using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr[1].ToString() == "BOD")
                                {
                                    iserror = "Y";

                                    x1 = new CONFIRM_BOD_003();

                                }
                                else
                                {

                                    x = new SHOW_PRICELIST_002()
                                    {
                                        CNTROLAREA = new showPriceList.CNTROLAREA()
                                        {
                                            BSR = new showPriceList.BSR()
                                            {
                                                VERB = new showPriceList.VERB() { Value = dr[0].ToString() },
                                                NOUN = new showPriceList.NOUN()
                                                {
                                                    Value = dr[1].ToString()
                                                },
                                                REVISION = new showPriceList.REVISION() { Value = dr[2].ToString() }
                                            },
                                            SENDER = new showPriceList.SENDER()
                                            {
                                                LOGICALID = dr[3].ToString(),
                                                COMPONENT = dr[4].ToString(),
                                                TASK = dr[5].ToString(),
                                                REFERENCEID = dr[6].ToString(),
                                                CONFIRMATION = dr[7].ToString(),
                                                LANGUAGE = dr[8].ToString(),
                                                CODEPAGE = dr[9].ToString(),
                                                AUTHID = dr["Sender_Authid"].ToString()

                                            },
                                            DATETIME = new showPriceList.DATETIME()
                                            {
                                                qualifier = showPriceList.DATETIMEQualifier.CREATION,
                                                YEAR = dr[11].ToString(),
                                                MONTH = dr[12].ToString(),
                                                DAY = dr[13].ToString()
                                                                           ,
                                                HOUR = dr[14].ToString(),
                                                MINUTE = dr[15].ToString(),
                                                SECOND = dr[16].ToString(),
                                                SUBSECOND = dr[17].ToString(),
                                                TIMEZONE = dr[18].ToString()
                                            }
                                        }
                                    };
                                }
                            }
                        }
                    }
                    //populate data area
                    SqlCommand SQLShowPriceDataArea = new SqlCommand();
                    SQLShowPriceDataArea.Connection = con;

                    SQLShowPriceDataArea.CommandText = "sp_ShowGetPriceDataArea";
                    SQLShowPriceDataArea.CommandType = CommandType.StoredProcedure;
                    SQLShowPriceDataArea.CommandTimeout = 0;
                    SQLShowPriceDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLShowPriceDataArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLShowPriceDataArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLShowPriceDataArea.Parameters["@TransId"].Value = TransID;

                    if (iserror == "Y")
                    {

                        using (SqlDataReader drbod = SQLShowPriceDataArea.ExecuteReader())
                        {
                            if (drbod.HasRows)
                            {
                                DataTable dt = new DataTable(); dt.Load(drbod);
                                BOD.DATAAREA[] dx1 = new BOD.DATAAREA[1];
                                x1.DATAAREA = dx1;

                            }
                        }
                    }
                    else
                    {


                        using (SqlDataReader dr1 = SQLShowPriceDataArea.ExecuteReader())
                        {
                            if (dr1.HasRows)
                            {
                                DataTable dt = new DataTable(); dt.Load(dr1);
                                showPriceList.DATAAREA[] d = new showPriceList.DATAAREA[Convert.ToInt16(dt.Rows[0]["MaxDataArea"].ToString())];

                                //showPriceList.PARTREF[] dpr = new showPriceList.PARTREF[Convert.ToInt16(dt.Rows[0]["MaxPartRef"].ToString())];
                                //   showPriceList.PARTREF[] dpr = new showPriceList.PARTREF[Convert.ToInt16(dt.Rows.Count.ToString())];

                                int partrefi = 0; int partline = 0;
                                //for (int n = 0; n < dt.Rows.Count; n++)
                                //{
                                for (int o = 0; o < Convert.ToInt16(dt.Rows[0]["MaxDataArea"].ToString()); o++)
                                {
                                    showPriceList.PRCLSTLINE[] dp = new showPriceList.PRCLSTLINE[Convert.ToInt16(dt.Rows[0]["MaxPriceListLine"].ToString())];
                                    d[o] = new showPriceList.DATAAREA();
                                    SHOW_PRICELIST sh = new SHOW_PRICELIST();
                                    d[o].SHOW_PRICELIST = sh;
                                    for (int p = 0; p < Convert.ToInt16(dt.Rows[0]["MaxPriceListLine"].ToString()); p++)
                                    {
                                        showPriceList.OPERAMT[] opr = new showPriceList.OPERAMT[dt.Rows.Count];
                                        showPriceList.QUANTITY[] qty = new showPriceList.QUANTITY[dt.Rows.Count];
                                        showPriceList.COLINX_PRODAVAIL[] prodavail = new showPriceList.COLINX_PRODAVAIL[dt.Rows.Count];
                                        showPriceList.PARTREF[] dpr = new showPriceList.PARTREF[Convert.ToInt16(dt.Rows.Count.ToString())];
                                        // showPriceList.WHSEDETAIL[] whs = new showPriceList.WHSEDETAIL[Convert.ToInt16(dt.Rows.Count.ToString())];
                                        showPriceList.WHSEDETAIL[] whs = new showPriceList.WHSEDETAIL[20];
                                        showPriceList.QUANTITY[] qtywhs = new showPriceList.QUANTITY[dt.Rows.Count];
                                        showPriceList.SITELEVEL[] stewhs = new showPriceList.SITELEVEL[dt.Rows.Count];
                                        showPriceList.DATETIME usrdt = new showPriceList.DATETIME();

                                        //if (o == Convert.ToInt16(dt.Rows[p]["PriceListLine"].ToString()))
                                        //{
                                        dp[p] = new PRCLSTLINE();


                                        d[o].SHOW_PRICELIST.PRICELIST = new PRICELIST();

                                        d[o].SHOW_PRICELIST.PRICELIST.PRCLSTLINE = dp;

                                        //for (int q = 0; q < Convert.ToInt16(dt.Rows.Count.ToString()); q++)
                                        //{
                                        //    opr[partrefi] = new OPERAMT();
                                        //    opr[partrefi].qualifier = OPERAMTQualifier.UNIT; opr[partrefi].type = OPERAMTType.T;
                                        //    opr[partrefi].VALUE = dt.Rows[q]["Price"].ToString();
                                        //    //opr[q] = new OPERAMT(); opr[q].qualifier = OPERAMTQualifier.UNIT; opr[q].type = OPERAMTType.T;
                                        //    //opr[q].VALUE = dt.Rows[o]["Price"].ToString();
                                        //}

                                        for (int r = 0; r < dt.Rows.Count; r++) //Convert.ToInt16(dt.Rows[0]["MaxPartRef"].ToString())
                                        {
                                            if (Convert.ToInt16(dt.Rows[r]["PriceListLine"].ToString()) == p)
                                            {

                                                opr[partrefi] = new OPERAMT();
                                                opr[partrefi].qualifier = OPERAMTQualifier.UNIT; opr[partrefi].type = OPERAMTType.T;
                                                opr[partrefi].VALUE = dt.Rows[r]["Price"].ToString();
                                                opr[partrefi].NUMOFDEC = dt.Rows[r]["OprDec"].ToString();
                                                opr[partrefi].SIGN = dt.Rows[r]["SignVal"].ToString();
                                                opr[partrefi].CURRENCY = dt.Rows[r]["CURRENCY"].ToString();
                                                opr[partrefi].UOM = dt.Rows[r]["OprUOM"].ToString();
                                                opr[partrefi].UOMVALUE = "1"; opr[partrefi].UOMNUMDEC = "0";

                                                dpr[partrefi] = new PARTREF();
                                                dpr[partrefi].PARTNO = dt.Rows[r]["Item"].ToString();
                                                dpr[partrefi].PARTKEY = dt.Rows[r]["ItemKey"].ToString();
                                                dpr[partrefi].PARTTYPE = dt.Rows[r]["type"].ToString();
                                                dpr[partrefi].PARTCLASS = dt.Rows[r]["PartClass"].ToString();

                                                dp[p].LINENUM = dt.Rows[r]["LineNum"].ToString();
                                                dp[p].PRCLSTLINE_USERAREA = new PRCLSTLINE_USERAREA();
                                                usrdt = new showPriceList.DATETIME();


                                                dp[p].PRCLSTLINE_USERAREA.COLINX_INSTOCK = dt.Rows[r]["COLINX_INSTOCK"].ToString();

                                               

                                                usrdt.YEAR = dt.Rows[r]["Year"].ToString();
                                                usrdt.MONTH = dt.Rows[r]["Month"].ToString();
                                                usrdt.DAY = dt.Rows[r]["Day"].ToString();
                                                usrdt.HOUR = dt.Rows[r]["Hr"].ToString();
                                                usrdt.MINUTE = dt.Rows[r]["Minute"].ToString();
                                                usrdt.SECOND = dt.Rows[r]["Second"].ToString();
                                                usrdt.SUBSECOND = dt.Rows[r]["SubSecond"].ToString();
                                                usrdt.TIMEZONE = dt.Rows[r]["TimeZone"].ToString();
                                                usrdt.qualifier = showPriceList.DATETIMEQualifier.REQUIRED;
                                                dp[p].PRCLSTLINE_USERAREA.DATETIME = usrdt;


                                                // dp[p].PRCLSTLINE_USERAREA = new PRCLSTLINE_USERAREA();
                                                qty[0] = new QUANTITY();
                                                qty[0].qualifier = QUANTITYQualifier.ORDERED;
                                                qty[0].SIGN = "+";
                                                qty[0].VALUE = dt.Rows[r]["Qty"].ToString();
                                                qty[0].NUMOFDEC = "0";
                                                qty[0].UOM = dt.Rows[r]["QtyUOM"].ToString();
                                                dp[p].PRCLSTLINE_USERAREA.COLINX_STATUS = new COLINX_STATUS();
                                                dp[p].PRCLSTLINE_USERAREA.COLINX_STATUS.REASONCODE = dt.Rows[r]["ReasonCode"].ToString();
                                                // dp[p].PRCLSTLINE_USERAREA.COLINX_STATUS.DESCRIPTN
                                                dp[p].PRCLSTLINE_USERAREA.QUANTITY = qty;
                                                dp[p].PRCLSTLINE_USERAREA.SITELEVEL = new SITELEVEL();
                                                dp[p].PRCLSTLINE_USERAREA.SITELEVEL.index = "1";// dt.Rows[r]["LineNum"].ToString();
                                                dp[p].PRCLSTLINE_USERAREA.SITELEVEL.Value = dt.Rows[r]["SiteLevelOuter"].ToString();
                                                //  dp[p].PRCLSTLINE_USERAREA.SITELEVEL.index = dt.Rows[r]["SiteLevel"].ToString();
                                                
                                                prodavail[0] = new COLINX_PRODAVAIL();
                                                prodavail[0].DEFAULTIND = "Y";
                                                prodavail[0].COLINX_SORTORDER = "1";
                                                
                                                //dp[p].PRCLSTLINE_USERAREA.COLINX_PRODAVAIL[0].QUANTITY[0].VALUE ="1";
                                                //dp[p].PRCLSTLINE_USERAREA.COLINX_PRODAVAIL[0].QUANTITY[0].NUMOFDEC = "0";
                                                //dp[p].PRCLSTLINE_USERAREA.COLINX_PRODAVAIL[0].QUANTITY[0].SIGN = "+";
                                                //dp[p].PRCLSTLINE_USERAREA.COLINX_PRODAVAIL[0].QUANTITY[0].UOM = "EA";
                                                //dp[p].PRCLSTLINE_USERAREA.COLINX_PRODAVAIL[0].QUANTITY[0].qualifier = QUANTITYQualifier.LOTSIZEMIN;

                                                prodavail[0].COLINX_SORTORDER = "1";
                                                qtywhs[0] = new QUANTITY(); stewhs[0] = new SITELEVEL();

                                                whs[0] = new WHSEDETAIL();
                                                qtywhs[0].qualifier = QUANTITYQualifier.AVAILABLE;
                                                qtywhs[0].VALUE = dt.Rows[r]["AvailQty"].ToString();
                                                qtywhs[0].NUMOFDEC = "0";
                                                qtywhs[0].SIGN = "+";
                                                qtywhs[0].UOM = "EA";
                                                whs[0].QUANTITY = qtywhs[0];
                                              
 
                                                stewhs[0].Value = dt.Rows[r]["SiteLevelInner"].ToString();
                                                stewhs[0].index = "1";
                                                whs[0].SITELEVEL = stewhs[0]; 

                                                whs[0].ORDERABLE = dt.Rows[r]["Orderable"].ToString();
                                                whs[0].PRIORITY = "Primary";
                                                whs[0].DEFAULTIND = "Y";

                                                if (dt.Rows[r]["Yrmypromise"].ToString() == "1900")
                                                {
                                                    whs[0].Item = dt.Rows[r]["Colinx_availDesc"].ToString();
                                                }
                                                else
                                                {

                                                    showPriceList.DATETIME availdt = new showPriceList.DATETIME();
                                                    availdt.YEAR = dt.Rows[r]["Yrmypromise"].ToString();
                                                    availdt.MONTH = dt.Rows[r]["Mthmypromise"].ToString();
                                                    availdt.DAY = dt.Rows[r]["Daymypromise"].ToString();
                                                    availdt.HOUR = "00";
                                                    availdt.MINUTE = "00";
                                                    availdt.SECOND = "00";
                                                    availdt.SUBSECOND = "00";
                                                    availdt.TIMEZONE = dt.Rows[r]["TimeZone"].ToString();
                                                    availdt.qualifier = showPriceList.DATETIMEQualifier.AVAILABLE; 
                                                    whs[0].Item = availdt;
                                                }


                                                int futurei = 0;
                                                //12/29/2020 additional future availibility breakdown warehousedetails//
                                                for (int k = 0; k < dt.Rows.Count; k++)  
                                                {
                                                    if (Convert.ToInt16(dt.Rows[k]["PASORT"].ToString()) > 0)
                                                    {
                                                        whs[futurei + 1] = new WHSEDETAIL();

                                                        showPriceList.QUANTITY[] qtywhsfuture = new showPriceList.QUANTITY[dt.Rows.Count];
                                                        showPriceList.SITELEVEL[] stewhsfuture = new showPriceList.SITELEVEL[dt.Rows.Count];
                                                        showPriceList.DATETIME usrdtfuture = new showPriceList.DATETIME();
                                                        qtywhsfuture[0] = new QUANTITY(); stewhsfuture[0] = new SITELEVEL();

                                                        qtywhsfuture[0].qualifier = QUANTITYQualifier.AVAILABLE;
                                                        qtywhsfuture[0].VALUE = dt.Rows[k]["AvailQty"].ToString();
                                                        qtywhsfuture[0].NUMOFDEC = "0";
                                                        qtywhsfuture[0].SIGN = "+";
                                                        qtywhsfuture[0].UOM = "EA";
                                                        whs[k + 1].QUANTITY = qtywhsfuture[0];


                                                        stewhsfuture[0].Value = dt.Rows[k]["SiteLevelInner"].ToString();
                                                        stewhsfuture[0].index = "1";
                                                        whs[futurei + 1].SITELEVEL = stewhs[0];

                                                        whs[futurei + 1].ORDERABLE = dt.Rows[k]["Orderable"].ToString();
                                                        whs[futurei + 1].PRIORITY = "Primary";
                                                        whs[futurei + 1].DEFAULTIND = "Y";

                                                        if (dt.Rows[k]["Yrmypromise"].ToString() == "1900")
                                                        {
                                                            whs[futurei + 1].Item = dt.Rows[k]["Colinx_availDesc"].ToString();
                                                        }
                                                        else
                                                        {

                                                            showPriceList.DATETIME availdtfuture = new showPriceList.DATETIME();
                                                            availdtfuture.YEAR = dt.Rows[k]["Yrmypromise"].ToString();
                                                            availdtfuture.MONTH = dt.Rows[k]["Mthmypromise"].ToString();
                                                            availdtfuture.DAY = dt.Rows[k]["Daymypromise"].ToString();
                                                            availdtfuture.HOUR = "00";
                                                            availdtfuture.MINUTE = "00";
                                                            availdtfuture.SECOND = "00";
                                                            availdtfuture.SUBSECOND = "00";
                                                            availdtfuture.TIMEZONE = dt.Rows[k]["TimeZone"].ToString();
                                                            availdtfuture.qualifier = showPriceList.DATETIMEQualifier.AVAILABLE;
                                                            whs[futurei + 1].Item = availdtfuture;
                                                        }
                                                        futurei++;
                                                    }
                                                }

                                                 ///////////////////////

                                                    prodavail[0].WHSEDETAIL = whs;
                                                

                                                if (dt.Rows[r]["ReasonCode"].ToString() == "0000")
                                                {
                                                    dp[p].PRCLSTLINE_USERAREA.COLINX_PRODAVAIL = prodavail;
                                                }
                                                if (dt.Rows[r]["ReasonCode"].ToString() == "0400")
                                                {
                                                    dp[p].PRCLSTLINE_USERAREA.COLINX_PRODAVAIL = prodavail;
                                                }
                                                if (dt.Rows[r]["ReasonCode"].ToString() == "0401")
                                                {
                                                    dp[p].PRCLSTLINE_USERAREA.COLINX_PRODAVAIL = prodavail;
                                                }
                                                if (dt.Rows[r]["ReasonCode"].ToString() == "0402")
                                                {
                                                    dp[p].PRCLSTLINE_USERAREA.COLINX_PRODAVAIL = prodavail;
                                                }

                                                d[o].SHOW_PRICELIST.PRICELIST.PARTNRID = dt.Rows[r]["Customer"].ToString();
                                                d[o].SHOW_PRICELIST.PRICELIST.CURRENCY = dt.Rows[r]["Currency"].ToString();
                                                d[o].SHOW_PRICELIST.PRICELIST.PRICELSTID = dt.Rows[r]["PriceListId"].ToString();
                                                partrefi++;
                                                
                                            }
                                        }

                                        dp[p].PARTREF = dpr;
                                        dp[p].OPERAMT = opr;
                                        // }
                                    }
                                    sh.PRICELIST.PRCLSTLINE = dp;

                                    d[o].SHOW_PRICELIST = sh;
                                }
                                x.DATAAREA = d;
                            }
                        }

                    }
                    // return x;
                    if (iserror == "Y")
                    {
                        return x;
                        // return dd;
                    }
                    else
                    {
                        return x;
                    }
                }
            }
            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand SQLInvalidXml = new SqlCommand();
                    SQLInvalidXml.Connection = con;
                    con.Open();
                    SQLInvalidXml.CommandText = "sp_InvalidXML";
                    SQLInvalidXml.CommandType = CommandType.StoredProcedure;
                    SQLInvalidXml.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLInvalidXml.Parameters.Add("@GUIErr", SqlDbType.NVarChar, 4);
                    SQLInvalidXml.Parameters.Add("@GUImsg", SqlDbType.NVarChar, 5000);
                    SQLInvalidXml.Parameters["@GUID"].Value = guid.ToString();
                    SQLInvalidXml.Parameters["@GUIErr"].Value = "2516";
                    SQLInvalidXml.Parameters["@GUImsg"].Value = Checkmsg;
                    SQLInvalidXml.ExecuteNonQuery();
                    Session["Errmsg"] = guid;// msg;
                }

                var x = new SHOW_PRICELIST_002();
                return x;
            }
        }

        public showsalesorder.SHOW_SALESORDER_005 SHOW_SALESORDER_005(object getsalesord, string MsgType, string MsgTypeVersion, string Sender, string TransID)
        {

            // getlistSalesorder.GETLIST_SALESORDER_005 sp = new getlistSalesorder.GETLIST_SALESORDER_005();

            var xmlstring = ((System.Xml.XmlNode[])getsalesord)[0].Value.ToString();
            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;
            var msg = checkxml(xmlstring, "GetSalesOrder");

            Guid guid = Guid.NewGuid();


            if (msg.Trim() == "")
            {
                var getsalesordread = new StringReader(xmlstring.Trim());

                getSalesOrder.GET_SALESORDER_005 resultingMessage = (getSalesOrder.GET_SALESORDER_005)new XmlSerializer(typeof(getSalesOrder.GET_SALESORDER_005)).Deserialize(getsalesordread);




                using (SqlConnection con = new SqlConnection(cs))
                {
                    //   var guid = new Guid();

                    SqlCommand SQLXMLHeader = new SqlCommand();
                    SQLXMLHeader.Connection = con;
                    con.Open();
                    SQLXMLHeader.CommandText = "InsertXMLHeader";
                    SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                    SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                    SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                    SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                    SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                    SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                    SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                    SQLXMLHeader.ExecuteNonQuery();

                    //control area
                    SqlCommand SQLControlAra = new SqlCommand();
                    SQLControlAra.Connection = con;
                    SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                    SQLControlAra.CommandType = CommandType.StoredProcedure;
                    SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                    SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                    SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                    SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                    SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                    SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                    SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                    SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                    SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                    SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                    SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                    SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                    SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                    SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                    SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                    SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                    SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                    SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                    SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                    SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                    SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                    SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                    SQLControlAra.Parameters["@TransId"].Value = TransID;
                    SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                    SQLControlAra.ExecuteNonQuery();


                    //Data Area

                    SqlCommand SQLDataArea = new SqlCommand();
                    SQLDataArea.Connection = con;
                    SQLDataArea.CommandText = "sp_GetSalesOrderDataArea";
                    SQLDataArea.CommandType = CommandType.StoredProcedure;
                    SQLDataArea.Parameters.Add("@Partner_Name", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@Partner_Id", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@Partner_Type", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@PageList_Element_SOLine", SqlDbType.NVarChar, 30);
                    SQLDataArea.Parameters.Add("@PageSize_SOLine", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@PageRef_Name_Element_SOLine", SqlDbType.NVarChar, 20);

                    SQLDataArea.Parameters.Add("@PageList_Element_Shipment", SqlDbType.NVarChar, 30);
                    SQLDataArea.Parameters.Add("@PageSize_Shipment", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@PageRef_Name_Element_Shipment", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@SOID", SqlDbType.NVarChar, 30);
                    SQLDataArea.Parameters.Add("@RefKey", SqlDbType.NVarChar, 200);
                    SQLDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);

                    SQLDataArea.Parameters["@Partner_Name"].Value = resultingMessage.DATAAREA[0].GET_SALESORDER.SOHEADER.PARTNER[0].NAME.Value;
                    SQLDataArea.Parameters["@Partner_Id"].Value = resultingMessage.DATAAREA[0].GET_SALESORDER.SOHEADER.PARTNER[0].PARTNRID;
                    SQLDataArea.Parameters["@Partner_Type"].Value = resultingMessage.DATAAREA[0].GET_SALESORDER.SOHEADER.PARTNER[0].PARTNRTYPE;

                    if (resultingMessage.DATAAREA[0].PAGELIST.Length == 2)
                    {
                        if (resultingMessage.DATAAREA[0].PAGELIST[0].element == "SOLINE")
                        {
                            SQLDataArea.Parameters["@PageList_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                            SQLDataArea.Parameters["@PageSize_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                            SQLDataArea.Parameters["@PageRef_Name_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name;
                            if (resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF != null)
                            {
                                SQLDataArea.Parameters["@RefKey"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF[0].Value;
                            }
                        }
                        if (resultingMessage.DATAAREA[0].PAGELIST[1].element == "SHIPMENT")
                        {
                            SQLDataArea.Parameters["@PageList_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].element;
                            SQLDataArea.Parameters["@PageSize_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGESIZE;
                            SQLDataArea.Parameters["@PageRef_Name_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGEREF[0].name;
                        }
                        if (resultingMessage.DATAAREA[0].PAGELIST[1].element == "SOLINE")
                        {
                            SQLDataArea.Parameters["@PageList_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].element;
                            SQLDataArea.Parameters["@PageSize_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGESIZE;
                            SQLDataArea.Parameters["@PageRef_Name_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGEREF[0].name;
                            if (resultingMessage.DATAAREA[0].PAGELIST[1].PAGEREF[0].REF != null)
                            {
                                SQLDataArea.Parameters["@RefKey"].Value = resultingMessage.DATAAREA[0].PAGELIST[1].PAGEREF[0].REF[0].Value;
                            }
                        }
                        if (resultingMessage.DATAAREA[0].PAGELIST[0].element == "SHIPMENT")
                        {
                            SQLDataArea.Parameters["@PageList_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                            SQLDataArea.Parameters["@PageSize_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                            SQLDataArea.Parameters["@PageRef_Name_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name;
                        }
                    }
                    if (resultingMessage.DATAAREA[0].PAGELIST.Length == 1)
                    {
                        if (resultingMessage.DATAAREA[0].PAGELIST[0].element == "SHIPMENT")
                        {
                            SQLDataArea.Parameters["@PageList_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                            SQLDataArea.Parameters["@PageSize_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                            SQLDataArea.Parameters["@PageRef_Name_Element_Shipment"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name;
                        }
                        if (resultingMessage.DATAAREA[0].PAGELIST[0].element == "SOLINE")
                        {
                            SQLDataArea.Parameters["@PageList_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                            SQLDataArea.Parameters["@PageSize_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                            SQLDataArea.Parameters["@PageRef_Name_Element_SOLine"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name;
                            if (resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF != null)
                            {
                                SQLDataArea.Parameters["@RefKey"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF[0].Value;
                            }
                        }
                    }
                    SQLDataArea.Parameters["@SOID"].Value = resultingMessage.DATAAREA[0].GET_SALESORDER.SOHEADER.SALESORDID.ToString().Trim();
                    SQLDataArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLDataArea.ExecuteNonQuery();



                    //return list sales order
                    SqlCommand SQLShowControlArea = new SqlCommand();
                    SQLShowControlArea.Connection = con;

                    SQLShowControlArea.CommandText = "sp_ShowSalesOrderDataControlArea";
                    SQLShowControlArea.CommandType = CommandType.StoredProcedure;

                    SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLShowControlArea.Parameters["@TransId"].Value = TransID;
                    //  SqlDataReader dr;
                    //  dr = SQLShowControlArea.ExecuteReader();
                    var x = new showsalesorder.SHOW_SALESORDER_005();
                    var x1 = new CONFIRM_BOD_003();
                    var iserror = "N";

                    using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr[1].ToString() == "BOD")
                                {
                                    iserror = "Y";

                                    x1 = new CONFIRM_BOD_003();

                                }
                                else
                                {

                                    x = new showsalesorder.SHOW_SALESORDER_005()
                                    {
                                        CNTROLAREA = new showsalesorder.CNTROLAREA()
                                        {
                                            BSR = new showsalesorder.BSR()
                                            {
                                                VERB = new showsalesorder.VERB() { Value = dr[0].ToString() },
                                                NOUN = new showsalesorder.NOUN()
                                                {
                                                    Value = dr[1].ToString()
                                                },
                                                REVISION = new showsalesorder.REVISION() { Value = dr[2].ToString() }
                                            },
                                            SENDER = new showsalesorder.SENDER()
                                            {
                                                LOGICALID = dr[3].ToString(),
                                                COMPONENT = dr[4].ToString(),
                                                TASK = dr[5].ToString(),
                                                REFERENCEID = dr[6].ToString(),
                                                CONFIRMATION = dr[7].ToString(),
                                                LANGUAGE = dr[8].ToString(),
                                                CODEPAGE = dr[9].ToString(),
                                                AUTHID = dr["Sender_Authid"].ToString()

                                            },
                                            DATETIME = new showsalesorder.DATETIME()
                                            {
                                                qualifier = showsalesorder.DATETIMEQualifier.CREATION,
                                                YEAR = dr[11].ToString(),
                                                MONTH = dr[12].ToString(),
                                                DAY = dr[13].ToString()
                                                                           ,
                                                HOUR = dr[14].ToString(),
                                                MINUTE = dr[15].ToString(),
                                                SECOND = dr[16].ToString(),
                                                SUBSECOND = dr[17].ToString(),
                                                TIMEZONE = dr[18].ToString()
                                            }
                                        }
                                    };
                                }
                            }
                        }
                    }


                    //populate data area
                    SqlCommand SQLShowSalesOrder = new SqlCommand();
                    SQLShowSalesOrder.Connection = con;

                    SQLShowSalesOrder.CommandText = "sp_ShowOrderDataArea";
                    SQLShowSalesOrder.CommandType = CommandType.StoredProcedure;

                    SQLShowSalesOrder.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLShowSalesOrder.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLShowSalesOrder.Parameters.Add("@SO", SqlDbType.NVarChar, 20);
                    SQLShowSalesOrder.Parameters["@GUID"].Value = guid.ToString();
                    SQLShowSalesOrder.Parameters["@TransId"].Value = "0";

                    if (iserror == "Y")
                    {

                        using (SqlDataReader drbod = SQLShowSalesOrder.ExecuteReader())
                        {
                            if (drbod.HasRows)
                            {
                                DataTable dt = new DataTable(); dt.Load(drbod);
                                BOD.DATAAREA[] dx1 = new BOD.DATAAREA[1];
                                x1.DATAAREA = dx1;

                            }
                        }
                    }
                    else
                    {


                        using (SqlDataReader dr1 = SQLShowSalesOrder.ExecuteReader())
                        {
                            if (dr1.HasRows)
                            {
                                DataTable dt = new DataTable(); dt.Load(dr1);
                                showsalesorder.DATAAREA[] d = new showsalesorder.DATAAREA[1];
                                int maxpartner = 0; int maxsoline = 0; int bolid = 0; int maxshipunit = 0;
                                showsalesorder.PARTNER[] Partner = new showsalesorder.PARTNER[Convert.ToInt32(dt.Rows[0]["MaxPartnerLine"].ToString())];
                                for (int o = 0; o < 1; o++)
                                {
                                    var pagesize = ""; var totalsize = ""; var pagerefnext = ""; var nextref = ""; var pagerefprev = ""; var prevref = "";
                                    d[o] = new showsalesorder.DATAAREA();
                                    showsalesorder.SOHEADER sh = new showsalesorder.SOHEADER();
                                    showsalesorder.SOLINE[] slarray = new showsalesorder.SOLINE[Convert.ToInt32(dt.Rows[0]["MaxSOLine"].ToString())];
                                    showsalesorder.COLINX_SHIPUNIT[] shuship = new showsalesorder.COLINX_SHIPUNIT[Convert.ToInt32(dt.Rows[0]["MaxSOLine"].ToString())];

                                    showsalesorder.SOHEADER_USERAREA shu = new showsalesorder.SOHEADER_USERAREA();
                                    showsalesorder.DOWNLOADABLE_RESOURCE[] shdl = new showsalesorder.DOWNLOADABLE_RESOURCE[Convert.ToInt32(dt.Rows[0]["MaxSOLine"].ToString())];
                                    showsalesorder.COLINX_SHIPMENT[] shCoshipmentarray = new showsalesorder.COLINX_SHIPMENT[Convert.ToInt32(dt.Rows[0]["MaxSOHeaderBOL"].ToString())];
                                    showsalesorder.COLINX_SHIPUNIT[] shBOLUnitarray = new showsalesorder.COLINX_SHIPUNIT[200];

                                    showsalesorder.OPERAMT shamt = new showsalesorder.OPERAMT();
                                    showsalesorder.OPERAMT[] shamtarray = new showsalesorder.OPERAMT[1];
                                    for (int p = 0; p < dt.Rows.Count; p++)
                                    {
                                        if (dt.Rows[p]["PPPartID"].ToString() == "1")
                                        {

                                            showsalesorder.PARTNER lspartner = new showsalesorder.PARTNER();
                                            showsalesorder.NAME name = new showsalesorder.NAME();

                                            name.index = "1";
                                            name.Value = dt.Rows[p]["PPNAME"].ToString().Trim();
                                            lspartner.NAME = name;

                                            lspartner.PARTNRID = dt.Rows[p]["PPPART"].ToString().Trim();
                                            lspartner.PARTNRTYPE = dt.Rows[p]["PPTYPE"].ToString().Trim();

                                            showsalesorder.ADDRESS lspartadd = new showsalesorder.ADDRESS();
                                            showsalesorder.ADDRESS[] lspartaddarray = new showsalesorder.ADDRESS[2];
                                            int maxaddr = 0; var partexist = "N";
                                            for (int k = 0; k < dt.Rows.Count; k++)
                                            {
                                                if (dt.Rows[k]["PPPartID"].ToString() == "1" && dt.Rows[p]["PPPART"].ToString().Trim() == dt.Rows[k]["PPPART"].ToString().Trim()
                                                   )
                                                {
                                                    for (int l = 0; l < maxpartner; l++)
                                                    {
                                                        if (Partner[l] != null)
                                                        {
                                                            if (Partner[l].PARTNRID.ToString() == dt.Rows[k]["PPPART"].ToString().Trim())
                                                            { partexist = "Y"; }
                                                        }
                                                    }
                                                    if (partexist == "N")
                                                    {
                                                        lspartaddarray[maxaddr] = new showsalesorder.ADDRESS();
                                                        showsalesorder.ADDRLINE lspartaddline = new showsalesorder.ADDRLINE();
                                                        showsalesorder.ADDRLINE[] lspartaddlinearray = new showsalesorder.ADDRLINE[3];

                                                        lspartaddline.index = "1";
                                                        lspartaddline.Value = dt.Rows[k]["PPADDR1"].ToString().Trim();
                                                        lspartaddlinearray[0] = new showsalesorder.ADDRLINE();
                                                        lspartaddlinearray[0] = lspartaddline;

                                                        showsalesorder.ADDRLINE lspartaddline1 = new showsalesorder.ADDRLINE();
                                                        lspartaddline1.index = "2";
                                                        lspartaddline1.Value = dt.Rows[k]["PPADDR2"].ToString().Trim();
                                                        lspartaddlinearray[1] = new showsalesorder.ADDRLINE();
                                                        lspartaddlinearray[1] = lspartaddline1;

                                                        showsalesorder.ADDRLINE lspartaddline2 = new showsalesorder.ADDRLINE();
                                                        lspartaddline2.index = "3";
                                                        lspartaddline2.Value = dt.Rows[k]["PPADDR3"].ToString();
                                                        lspartaddlinearray[2] = new showsalesorder.ADDRLINE();
                                                        lspartaddlinearray[2] = lspartaddline2;

                                                        lspartaddarray[maxaddr] = new showsalesorder.ADDRESS();
                                                        lspartaddarray[maxaddr].ADDRLINE = lspartaddlinearray;
                                                        lspartaddarray[maxaddr].ADDRTYPE = dt.Rows[k]["PPATYP"].ToString().Trim();
                                                        lspartaddarray[maxaddr].CITY = dt.Rows[k]["PPCTY1"].ToString().Trim();
                                                        lspartaddarray[maxaddr].POSTALCODE = dt.Rows[k]["PPADDZ"].ToString().Trim();
                                                        lspartaddarray[maxaddr].STATEPROVN = dt.Rows[k]["PPADDS"].ToString().Trim();
                                                        lspartaddarray[maxaddr].COUNTRY = dt.Rows[k]["PPCTR"].ToString().Trim();

                                                        lspartner.ADDRESS = lspartaddarray;
                                                        Partner[maxpartner] = lspartner;
                                                        maxaddr++;
                                                    }

                                                }
                                            }
                                            maxpartner++;


                                        }
                                        //  sh.PARTNER = Partner;

                                        showsalesorder.COLINX_SHIPINSTR shpinstr = new showsalesorder.COLINX_SHIPINSTR();


                                        showsalesorder.DATETIME lsdt = new showsalesorder.DATETIME();
                                        lsdt.qualifier = showsalesorder.DATETIMEQualifier.DOCUMENT;
                                        lsdt.YEAR = dt.Rows[p]["OrdYr"].ToString();
                                        lsdt.MONTH = dt.Rows[p]["OrdMth"].ToString();
                                        lsdt.DAY = dt.Rows[p]["OrdDay"].ToString();
                                        lsdt.HOUR = "00";
                                        lsdt.MINUTE = "00";
                                        lsdt.SECOND = "00";
                                        lsdt.SUBSECOND = "0000";
                                        lsdt.TIMEZONE = dt.Rows[p]["TimeZone"].ToString();


                                        if (dt.Rows[p]["SOLineID"].ToString() == "1")
                                        {
                                            showsalesorder.SOLINE sl = new showsalesorder.SOLINE();

                                            if (dt.Rows[p]["Detailguid"].ToString() != "")
                                            {
                                                showsalesorder.DATETIME[] sldtarray = new showsalesorder.DATETIME[4];

                                                showsalesorder.DATETIME sldt = new showsalesorder.DATETIME();
                                                sldt.qualifier = showsalesorder.DATETIMEQualifier.DOCUMENT;
                                                sldt.YEAR = dt.Rows[p]["DetailReqYr"].ToString();
                                                sldt.MONTH = dt.Rows[p]["DetailReqMth"].ToString();
                                                sldt.DAY = dt.Rows[p]["DetailReqDay"].ToString();
                                                sldt.HOUR = "00";
                                                sldt.MINUTE = "00";
                                                sldt.SECOND = "00";
                                                sldt.SUBSECOND = "0000";
                                                sldt.TIMEZONE = dt.Rows[p]["DetailTimeZone"].ToString();
                                                sldt.qualifier = showsalesorder.DATETIMEQualifier.REQUIRED;
                                                sldtarray[0] = sldt;

                                                showsalesorder.DATETIME sldtinv = new showsalesorder.DATETIME();
                                                sldtinv.qualifier = showsalesorder.DATETIMEQualifier.DOCUMENT;
                                                sldtinv.YEAR = dt.Rows[p]["InvYr"].ToString();
                                                sldtinv.MONTH = dt.Rows[p]["InvMth"].ToString();
                                                sldtinv.DAY = dt.Rows[p]["InvDay"].ToString();
                                                sldtinv.HOUR = "01";
                                                sldtinv.MINUTE = "00";
                                                sldtinv.SECOND = "00";
                                                sldtinv.SUBSECOND = "0000";
                                                sldtinv.TIMEZONE = dt.Rows[p]["DetailTimeZone"].ToString();
                                                sldtinv.qualifier = showsalesorder.DATETIMEQualifier.INVOICE;
                                                if (dt.Rows[p]["InvYr"].ToString() != "1900")
                                                { sldtarray[1] = sldtinv; }


                                                showsalesorder.DATETIME sldtprmdel = new showsalesorder.DATETIME();
                                                sldtprmdel.qualifier = showsalesorder.DATETIMEQualifier.DOCUMENT;
                                                sldtprmdel.YEAR = dt.Rows[p]["PrmDelYr"].ToString();
                                                sldtprmdel.MONTH = dt.Rows[p]["PrmDelMth"].ToString();
                                                sldtprmdel.DAY = dt.Rows[p]["PrmDelDay"].ToString();
                                                sldtprmdel.HOUR = "01";
                                                sldtprmdel.MINUTE = "00";
                                                sldtprmdel.SECOND = "00";
                                                sldtprmdel.SUBSECOND = "0000";
                                                sldtprmdel.TIMEZONE = dt.Rows[p]["DetailTimeZone"].ToString();
                                                sldtprmdel.qualifier = showsalesorder.DATETIMEQualifier.PROMDELV;
                                             
                                                if (dt.Rows[p]["PrmDelYr"].ToString() != "1900")
                                                {
                                                    sldtarray[2] = sldtprmdel;
                                                }

                                                showsalesorder.DATETIME sldtprmship = new showsalesorder.DATETIME();
                                                sldtprmship.qualifier = showsalesorder.DATETIMEQualifier.DOCUMENT;
                                                sldtprmship.YEAR = dt.Rows[p]["PrmShipYr"].ToString();
                                                sldtprmship.MONTH = dt.Rows[p]["PrmShipMth"].ToString();
                                                sldtprmship.DAY = dt.Rows[p]["PrmShipDay"].ToString();
                                                sldtprmship.HOUR = "1";
                                                sldtprmship.MINUTE = "00";
                                                sldtprmship.SECOND = "00";
                                                sldtprmship.SUBSECOND = "0000";
                                                sldtprmship.TIMEZONE = dt.Rows[p]["DetailTimeZone"].ToString();
                                                sldtprmship.qualifier = showsalesorder.DATETIMEQualifier.PROMSHIP;
                                                if (dt.Rows[p]["PrmShipYr"].ToString() != "1900")
                                                {
                                                    sldtarray[3] = sldtprmship;
                                                }

                                                sl.DATETIME = sldtarray;

                                                sl.DISTCENTER = dt.Rows[p]["DetailDC"].ToString();
                                                sl.SOLNSTATUS = dt.Rows[p]["DetailStatus"].ToString();
                                                sl.SOLINENUM = dt.Rows[p]["DetailLine"].ToString();

                                                showsalesorder.PARTREF[] slpartrefarray = new showsalesorder.PARTREF[1];
                                                showsalesorder.PARTREF slpartref = new showsalesorder.PARTREF();
                                                slpartref.PARTNO = dt.Rows[p]["DetailItem"].ToString().Trim();
                                                slpartref.PARTTYPE = dt.Rows[p]["DetailPartType"].ToString();
                                                slpartrefarray[0] = slpartref;
                                                sl.PARTREF = slpartrefarray;

                                                showsalesorder.QUANTITY[] sqlqtyarray = new showsalesorder.QUANTITY[1];
                                                showsalesorder.QUANTITY slqty = new showsalesorder.QUANTITY();
                                                slqty.VALUE = dt.Rows[p]["DetailOrdQty"].ToString().Trim();
                                                slqty.UOM = "EA";
                                                slqty.SIGN = "+";
                                                slqty.NUMOFDEC = "0";
                                                slqty.qualifier = showsalesorder.QUANTITYQualifier.ORDERED;
                                                sqlqtyarray[0] = slqty;
                                                sl.QUANTITY = sqlqtyarray;

                                                showsalesorder.SOLINE_USERAREA slu = new showsalesorder.SOLINE_USERAREA();
                                                showsalesorder.COLINX_SHIPUNIT[] sluship = new showsalesorder.COLINX_SHIPUNIT[1];
                                                sluship[0] = new showsalesorder.COLINX_SHIPUNIT();
                                                sluship[0].CARRIER = dt.Rows[p]["Carrier"].ToString().Trim();
                                                sluship[0].SHPUNITSEQ = dt.Rows[p]["ShipUnitSeq"].ToString().Trim();
                                                sluship[0].TRACKINGID = dt.Rows[p]["TrackingId"].ToString().Trim();



                                                slu.COLINX_SHIPUNIT = sluship;
                                                showsalesorder.DOWNLOADABLE_RESOURCE[] sld = new showsalesorder.DOWNLOADABLE_RESOURCE[1];
                                                sld[0] = new showsalesorder.DOWNLOADABLE_RESOURCE();
                                                sld[0].name = dt.Rows[p]["PLNAME"].ToString().Trim();

                                                //  sld[0].Value = dt.Rows[p]["PLRSRC"].ToString().Trim();
                                                slu.DOWNLOADABLE_RESOURCE = sld;
                                                showsalesorder.OPERAMT[] slopamt = new showsalesorder.OPERAMT[1];
                                                slopamt[0] = new showsalesorder.OPERAMT();
                                                slopamt[0].qualifier = showsalesorder.OPERAMTQualifier.UNIT;
                                                slopamt[0].type = showsalesorder.OPERAMTType.T;
                                                slopamt[0].VALUE = dt.Rows[p]["PLUPRC"].ToString().Trim();
                                                slopamt[0].NUMOFDEC = dt.Rows[p]["PLUPRCDec"].ToString().Trim();
                                                slopamt[0].SIGN = "+";
                                                slopamt[0].UOMVALUE = "1";
                                                slopamt[0].UOMNUMDEC = "0";
                                                slopamt[0].UOM = "EA";
                                                slopamt[0].CURRENCY = "USD";

                                                sl.SOLINE_USERAREA = slu;
                                                sl.OPERAMT = slopamt;
                                                slarray[maxsoline] = sl;
                                                shdl[maxsoline] = sld[0];
                                                maxsoline++;
                                            }
                                        }

                                        sh.POID = dt.Rows[p]["PO"].ToString();
                                        sh.SALESORDID = dt.Rows[p]["SO"].ToString();
                                        sh.SOSTATUS = dt.Rows[p]["Status"].ToString();

                                        //showsalesorder.SOHEADER_USERAREA shu = new showsalesorder.SOHEADER_USERAREA();
                                        shu.COLINX_ORDTRANSID = dt.Rows[p]["ColinxTransId"].ToString();
                                        shu.COLINX_SHIPINSTR = shpinstr;

                                        showsalesorder.QUANTITY shuqty = new showsalesorder.QUANTITY();
                                        shuqty.NUMOFDEC = dt.Rows[p]["OrdWeightDecimal"].ToString();
                                        shuqty.SIGN = dt.Rows[p]["OrdWeightSign"].ToString();
                                        shuqty.UOM = dt.Rows[p]["OrdWeightUOM"].ToString();
                                        shuqty.VALUE = dt.Rows[p]["OrdWeight"].ToString();
                                        shuqty.qualifier = showsalesorder.QUANTITYQualifier.TOTWEIGHT;

                                        shu.QUANTITY = shuqty;
                                        sh.SOHEADER_USERAREA = shu;


                                        sh.SOHEADER_USERAREA = new showsalesorder.SOHEADER_USERAREA();
                                        // sh.SOHEADER_USERAREA.COLINX_ORDTRANSID = dt.Rows[p]["ColinxTransId"].ToString();
                                        sh.SOHEADER_USERAREA = shu;
                                        sh.DATETIME = lsdt;

                                        //ls[p].SOHEADER = sh;
                                        //ls[p].SOLINE = slarray;

                                        pagesize = dt.Rows[p]["PageSize"].ToString();
                                        totalsize = dt.Rows[p]["TotalSize"].ToString();
                                        pagerefnext = dt.Rows[p]["PageRef_Next"].ToString();
                                        nextref = dt.Rows[p]["Next_Ref"].ToString();
                                        pagerefprev = dt.Rows[p]["PageRef_Prev"].ToString();
                                        prevref = dt.Rows[p]["Prev_Ref"].ToString();

                                        showsalesorder.COLINX_SHIPUNIT[] shluship = new showsalesorder.COLINX_SHIPUNIT[200];
                                        // showsalesorder.SOHEADER_USERAREA shu = new showsalesorder.SOHEADER_USERAREA();
                                        // shu.COLINX_SHIPMENT[0] = new showsalesorder.COLINX_SHIPMENT();
                                        if (dt.Rows[p]["SOHeaderBOLID"].ToString() == "1" && dt.Rows[p]["PSDOCI"].ToString() != "")
                                        {


                                            for (int k = 0; k < dt.Rows.Count; k++)
                                            {
                                                if (dt.Rows[k]["SOHeaderBOLUnitID"].ToString() == "1" && dt.Rows[k]["PSDOCI"].ToString() == dt.Rows[p]["PSDOCI"].ToString())
                                                {
                                                    shluship[maxshipunit] = new showsalesorder.COLINX_SHIPUNIT();
                                                    shluship[maxshipunit].SHPUNITSEQ = dt.Rows[k]["ShipUnitSeq"].ToString().Trim();
                                                    shluship[maxshipunit].TRACKINGID = dt.Rows[k]["TrackingId"].ToString().Trim();

                                                    //  shuship[maxsoline] = shluship[maxshipunit];
                                                    maxshipunit++;
                                                }
                                            }
                                            showsalesorder.COLINX_SHIPUNIT shuCoShipunit = new showsalesorder.COLINX_SHIPUNIT();
                                            //showsalesorder.COLINX_SHIPMENT[] shCoshipmentarray = new showsalesorder.COLINX_SHIPMENT[1];
                                            shCoshipmentarray[bolid] = new showsalesorder.COLINX_SHIPMENT();
                                            shCoshipmentarray[bolid].COLINX_SHIPUNIT = shluship;
                                            showsalesorder.QUANTITY shqty = new showsalesorder.QUANTITY();
                                            shqty.NUMOFDEC = "0";
                                            shqty.VALUE = dt.Rows[p]["BOLWeight"].ToString();
                                            shqty.SIGN = "+";
                                            shqty.UOM = "LB";
                                            shqty.qualifier = showsalesorder.QUANTITYQualifier.TOTWEIGHT;
                                            shCoshipmentarray[bolid].QUANTITY = shqty;
                                            shCoshipmentarray[bolid].DOCUMENTID = dt.Rows[p]["PSDOCI"].ToString();
                                            shCoshipmentarray[bolid].COLINX_BILOLADING = dt.Rows[p]["PSDOCI"].ToString();
                                            shCoshipmentarray[bolid].CARRIER = dt.Rows[p]["BOLCar"].ToString();

                                            showsalesorder.DATETIME shpdt = new showsalesorder.DATETIME();
                                            shpdt.qualifier = showsalesorder.DATETIMEQualifier.DOCUMENT;
                                            shpdt.YEAR = dt.Rows[p]["BOLYear"].ToString();
                                            shpdt.MONTH = dt.Rows[p]["BOLMonth"].ToString();
                                            shpdt.DAY = dt.Rows[p]["BOLDay"].ToString();
                                            shpdt.HOUR = "00";
                                            shpdt.MINUTE = "00";
                                            shpdt.SECOND = "00";
                                            shpdt.SUBSECOND = "0000";
                                            shpdt.TIMEZONE = dt.Rows[p]["BOLTimeZone"].ToString();
                                            shCoshipmentarray[bolid].DATETIME = shpdt;
                                            shCoshipmentarray[bolid].SHPUNITTOT = dt.Rows[p]["TotalUnitSeq"].ToString();
                                            shu.COLINX_SHIPMENT = shCoshipmentarray;
                                            bolid++;
                                        }

                                        shamt.NUMOFDEC = dt.Rows[p]["OrdOPERAmtDec"].ToString();
                                        shamt.CURRENCY = dt.Rows[p]["OrdOperAmtCur"].ToString();
                                        shamt.SIGN = "+";
                                        shamt.UOM = "EA";
                                        shamt.UOMNUMDEC = "0";
                                        shamt.UOMVALUE = "1";
                                        shamt.VALUE = dt.Rows[p]["OrdOperAmt"].ToString();
                                        shamt.qualifier = showsalesorder.OPERAMTQualifier.EXTENDED;
                                        shamt.type = showsalesorder.OPERAMTType.T;
                                        shamt.NUMOFDEC = dt.Rows[p]["OrdOPERAmtDec"].ToString();
                                        shamtarray[0] = shamt;
                                    }

                                    shu.DOWNLOADABLE_RESOURCE = shdl;
                                    sh.SOHEADER_USERAREA = shu;
                                    sh.OPERAMT = shamtarray;

                                    sh.PARTNER = Partner;
                                    d[0].SHOW_SALESORDER = new showsalesorder.SHOW_SALESORDER();
                                    d[0].SHOW_SALESORDER.SOLINE = slarray;
                                    d[o].SHOW_SALESORDER.SOHEADER = sh;

                                    showsalesorder.PAGELIST[] pgarray = new showsalesorder.PAGELIST[2];
                                    showsalesorder.PAGELIST pg = new showsalesorder.PAGELIST();

                                    pg.element = "SOLINE";
                                    pg.PAGESIZE = pagesize;
                                    pg.TOTALSIZE = totalsize;

                                    showsalesorder.PAGEREF[] pgrefarray = new showsalesorder.PAGEREF[2];
                                    showsalesorder.PAGEREF[] pgrefarraynext = new showsalesorder.PAGEREF[1];
                                    showsalesorder.PAGEREF pgrefnext = new showsalesorder.PAGEREF();
                                    showsalesorder.PAGEREF pgrefprev = new showsalesorder.PAGEREF();

                                    showsalesorder.REF[] refarraynext = new showsalesorder.REF[1];
                                    showsalesorder.REF[] refarrayprev = new showsalesorder.REF[1];
                                    showsalesorder.REF refernext = new showsalesorder.REF();
                                    showsalesorder.REF referprev = new showsalesorder.REF();

                                    pgrefnext.name = showsalesorder.PAGEREFName.NEXT;

                                    refernext.qualifier = pagerefnext;


                                    if (pagerefnext == "NEXT")
                                    {
                                        refernext.Value = nextref;
                                        refarraynext[0] = refernext;
                                        pgrefarraynext[0] = pgrefnext;
                                        pgrefarraynext[0].REF = refarraynext;
                                    }

                                    //prev ref 
                                    showsalesorder.PAGEREF[] pgrefarrayprev = new showsalesorder.PAGEREF[1];
                                    pgrefprev.name = showsalesorder.PAGEREFName.PREVIOUS;

                                    referprev.qualifier = pagerefprev;

                                    if (pagerefprev == "PREV")
                                    {
                                        referprev.Value = prevref;
                                        refarrayprev[0] = referprev;
                                        pgrefarrayprev[0] = pgrefprev;
                                        pgrefarrayprev[0].REF = refarrayprev;
                                    }

                                    //
                                    pgrefarray[0] = pgrefarraynext[0]; pgrefarray[1] = pgrefarrayprev[0];

                                    pg.PAGEREF = pgrefarray;

                                    pgarray[0] = pg;

                                    showsalesorder.PAGELIST pgShipment = new showsalesorder.PAGELIST();
                                    pgShipment.element = "SHIPMENT";
                                    pgShipment.TOTALSIZE = "100";
                                    pgShipment.PAGESIZE = "100";
                                    pgarray[1] = pgShipment;

                                    d[o].PAGELIST = pgarray;


                                }
                                x.DATAAREA = d;
                            }
                        }

                    }

                    return x;
                }
            }

            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand SQLInvalidXml = new SqlCommand();
                    SQLInvalidXml.Connection = con;
                    con.Open();
                    SQLInvalidXml.CommandText = "sp_InvalidXML";
                    SQLInvalidXml.CommandType = CommandType.StoredProcedure;
                    SQLInvalidXml.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLInvalidXml.Parameters.Add("@GUIErr", SqlDbType.NVarChar, 4);
                    SQLInvalidXml.Parameters.Add("@GUImsg", SqlDbType.NVarChar, 5000);
                    SQLInvalidXml.Parameters["@GUID"].Value = guid.ToString();
                    SQLInvalidXml.Parameters["@GUIErr"].Value = "2516";
                    SQLInvalidXml.Parameters["@GUImsg"].Value = msg;
                    SQLInvalidXml.ExecuteNonQuery();
                    Session["Errmsg"] = guid;// msg;
                }

                var x = new showsalesorder.SHOW_SALESORDER_005();
                return x;
            }

        }

        public listSalesorder.LIST_SALESORDER_005 SHOW_LISTSALESORDER_005(object getsalesord, string MsgType, string MsgTypeVersion, string Sender, string TransID)
        {

            // getlistSalesorder.GETLIST_SALESORDER_005 sp = new getlistSalesorder.GETLIST_SALESORDER_005();

            var xmlstring = ((System.Xml.XmlNode[])getsalesord)[0].Value.ToString();
            string cs = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;
            var msg = checkxml(xmlstring, "GetListSalesOrder");

            Guid guid = Guid.NewGuid();


            if (msg.Trim() == "")
            {
                var getsalesordread = new StringReader(xmlstring.Trim());

                getlistSalesorder.GETLIST_SALESORDER_005 resultingMessage = (getlistSalesorder.GETLIST_SALESORDER_005)new XmlSerializer(typeof(getlistSalesorder.GETLIST_SALESORDER_005)).Deserialize(getsalesordread);




                using (SqlConnection con = new SqlConnection(cs))
                {
                    //   var guid = new Guid();

                    SqlCommand SQLXMLHeader = new SqlCommand();
                    SQLXMLHeader.Connection = con;
                    con.Open();
                    SQLXMLHeader.CommandText = "InsertXMLHeader";
                    SQLXMLHeader.CommandType = CommandType.StoredProcedure;
                    SQLXMLHeader.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@Tranid", SqlDbType.NVarChar, 60);
                    SQLXMLHeader.Parameters.Add("@MessageType", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@MessageTypeVersion", SqlDbType.NVarChar, 10);
                    SQLXMLHeader.Parameters.Add("@Sender", SqlDbType.NVarChar, 20);

                    SQLXMLHeader.Parameters["@GUID"].Value = guid.ToString();
                    SQLXMLHeader.Parameters["@Tranid"].Value = TransID;
                    SQLXMLHeader.Parameters["@MessageType"].Value = MsgType;
                    SQLXMLHeader.Parameters["@MessageTypeVersion"].Value = MsgTypeVersion;
                    SQLXMLHeader.Parameters["@Sender"].Value = Sender;
                    SQLXMLHeader.ExecuteNonQuery();

                    //control area
                    SqlCommand SQLControlAra = new SqlCommand();
                    SQLControlAra.Connection = con;
                    SQLControlAra.CommandText = "sp_GetHostpingControlArea";
                    SQLControlAra.CommandType = CommandType.StoredProcedure;
                    SQLControlAra.Parameters.Add("@BSR_Verb", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_NOUN", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@BSR_Revision", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_LogicalId", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Component", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Task", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Referenceid", SqlDbType.NVarChar, 50);
                    SQLControlAra.Parameters.Add("@Sender_Confirmation", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Language", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Codepage", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@Sender_Authid", SqlDbType.NVarChar, 200);
                    SQLControlAra.Parameters.Add("@DateTime_Year", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Month", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Day", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Hour", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Minute", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Second", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Subsecond", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@DateTime_Timezone", SqlDbType.NVarChar, 10);
                    SQLControlAra.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLControlAra.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);


                    SQLControlAra.Parameters["@BSR_Verb"].Value = resultingMessage.CNTROLAREA.BSR.VERB.Value;
                    SQLControlAra.Parameters["@BSR_NOUN"].Value = resultingMessage.CNTROLAREA.BSR.NOUN.Value;
                    SQLControlAra.Parameters["@BSR_Revision"].Value = resultingMessage.CNTROLAREA.BSR.REVISION.Value;
                    SQLControlAra.Parameters["@Sender_LogicalId"].Value = resultingMessage.CNTROLAREA.SENDER.LOGICALID;
                    SQLControlAra.Parameters["@Sender_Component"].Value = resultingMessage.CNTROLAREA.SENDER.COMPONENT;
                    SQLControlAra.Parameters["@Sender_Task"].Value = resultingMessage.CNTROLAREA.SENDER.TASK;
                    SQLControlAra.Parameters["@Sender_Referenceid"].Value = resultingMessage.CNTROLAREA.SENDER.REFERENCEID;
                    SQLControlAra.Parameters["@Sender_Confirmation"].Value = resultingMessage.CNTROLAREA.SENDER.CONFIRMATION;
                    SQLControlAra.Parameters["@Sender_Language"].Value = resultingMessage.CNTROLAREA.SENDER.LANGUAGE;
                    SQLControlAra.Parameters["@Sender_Codepage"].Value = resultingMessage.CNTROLAREA.SENDER.CODEPAGE;
                    SQLControlAra.Parameters["@Sender_Authid"].Value = resultingMessage.CNTROLAREA.SENDER.AUTHID;
                    SQLControlAra.Parameters["@DateTime_Year"].Value = resultingMessage.CNTROLAREA.DATETIME.YEAR;
                    SQLControlAra.Parameters["@DateTime_Month"].Value = resultingMessage.CNTROLAREA.DATETIME.MONTH;
                    SQLControlAra.Parameters["@DateTime_Day"].Value = resultingMessage.CNTROLAREA.DATETIME.DAY;
                    SQLControlAra.Parameters["@DateTime_Hour"].Value = resultingMessage.CNTROLAREA.DATETIME.HOUR;
                    SQLControlAra.Parameters["@DateTime_Minute"].Value = resultingMessage.CNTROLAREA.DATETIME.MINUTE;
                    SQLControlAra.Parameters["@DateTime_Second"].Value = resultingMessage.CNTROLAREA.DATETIME.SECOND;
                    SQLControlAra.Parameters["@DateTime_Subsecond"].Value = resultingMessage.CNTROLAREA.DATETIME.SUBSECOND;
                    SQLControlAra.Parameters["@DateTime_Timezone"].Value = resultingMessage.CNTROLAREA.DATETIME.TIMEZONE;
                    SQLControlAra.Parameters["@TransId"].Value = TransID;
                    SQLControlAra.Parameters["@GUID"].Value = guid.ToString();
                    SQLControlAra.ExecuteNonQuery();


                    //Data Area

                    SqlCommand SQLDataArea = new SqlCommand();
                    SQLDataArea.Connection = con;
                    SQLDataArea.CommandText = "sp_GetListSalesOrderDataArea";
                    SQLDataArea.CommandType = CommandType.StoredProcedure;
                    SQLDataArea.Parameters.Add("@Colinx_Sortorder", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@Colinx_Translines", SqlDbType.NVarChar, 5);
                    SQLDataArea.Parameters.Add("@Partner_Name", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@Partner_Id", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@Partner_Type", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@SOLine_PartType", SqlDbType.NVarChar, 30);
                    SQLDataArea.Parameters.Add("@SOLine_PartNo", SqlDbType.NVarChar, 200);
                    SQLDataArea.Parameters.Add("@SOLine_PartClass", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@SOLine_PartQual", SqlDbType.NVarChar, 30);
                    SQLDataArea.Parameters.Add("@SOLineStatus", SqlDbType.NVarChar, 30);
                    SQLDataArea.Parameters.Add("@PageList_Element", SqlDbType.NVarChar, 30);
                    SQLDataArea.Parameters.Add("@PageSize", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@TotalSize", SqlDbType.NVarChar, 10);
                    SQLDataArea.Parameters.Add("@PageRef_Name", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@PageRef_Ref", SqlDbType.NVarChar, 500);
                    SQLDataArea.Parameters.Add("@FromDate_Year", SqlDbType.NVarChar, 5);
                    SQLDataArea.Parameters.Add("@FromDate_Month", SqlDbType.NVarChar, 5);
                    SQLDataArea.Parameters.Add("@FromDate_Day", SqlDbType.NVarChar, 3);
                    SQLDataArea.Parameters.Add("@ToDate_Year", SqlDbType.NVarChar, 5);
                    SQLDataArea.Parameters.Add("@ToDate_Month", SqlDbType.NVarChar, 3);
                    SQLDataArea.Parameters.Add("@ToDate_Day", SqlDbType.NVarChar, 3);
                    SQLDataArea.Parameters.Add("@SOID", SqlDbType.NVarChar, 30);
                    SQLDataArea.Parameters.Add("@POID", SqlDbType.NVarChar, 100);
                    SQLDataArea.Parameters.Add("@SOStatus", SqlDbType.NVarChar, 20);
                    SQLDataArea.Parameters.Add("@OrdTransId", SqlDbType.NVarChar, 30);
                    SQLDataArea.Parameters.Add("@TransID", SqlDbType.NVarChar, 60);
                    SQLDataArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);

                    SQLDataArea.Parameters["@Colinx_Sortorder"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SOHEADER_USERAREA.COLINX_SORTORDER;
                    SQLDataArea.Parameters["@Colinx_Translines"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SOHEADER_USERAREA.COLINX_TRANSLINES;
                    SQLDataArea.Parameters["@Partner_Name"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.PARTNER[0].NAME.Value;
                    SQLDataArea.Parameters["@Partner_Id"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.PARTNER[0].PARTNRID;
                    SQLDataArea.Parameters["@Partner_Type"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.PARTNER[0].PARTNRTYPE;
                    SQLDataArea.Parameters["@SOStatus"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SOSTATUS;

                    if (resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF != null)
                    {
                        SQLDataArea.Parameters["@SOLine_PartType"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF[0].PARTTYPE;
                        SQLDataArea.Parameters["@SOLine_PartNo"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF[0].PARTNO;
                        SQLDataArea.Parameters["@SOLine_PartClass"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF[0].PARTCLASS;
                        SQLDataArea.Parameters["@SOLine_PartQual"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].PARTREF[0].PARTQUAL;
                    }

                    SQLDataArea.Parameters["@SOLineStatus"].Value = (object)resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOLINE[0].SOLNSTATUS ?? DBNull.Value;
                    SQLDataArea.Parameters["@PageList_Element"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].element;
                    SQLDataArea.Parameters["@PageSize"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].PAGESIZE;
                    SQLDataArea.Parameters["@TotalSize"].Value = resultingMessage.DATAAREA[0].PAGELIST[0].TOTALSIZE;
                    SQLDataArea.Parameters["@PageRef_Name"].Value = (object)resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].name ?? DBNull.Value;
                    if ((object)resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF == null) { SQLDataArea.Parameters["@PageRef_Ref"].Value = ""; }
                    else
                    {
                        SQLDataArea.Parameters["@PageRef_Ref"].Value = (object)resultingMessage.DATAAREA[0].PAGELIST[0].PAGEREF[0].REF[0].Value ?? DBNull.Value;
                    }
                    if (resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.DATETIME != null)
                    {
                        SQLDataArea.Parameters["@FromDate_Year"].Value = (object)resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.DATETIME.YEAR ?? DBNull.Value;
                        SQLDataArea.Parameters["@FromDate_Month"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.DATETIME.MONTH;
                        SQLDataArea.Parameters["@FromDate_Day"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.DATETIME.DAY;
                    }
                    if (resultingMessage.DATAAREA[0].GETLIST_SALESORDER1 != null)
                    {
                        if (resultingMessage.DATAAREA[0].GETLIST_SALESORDER1.SOHEADER.DATETIME != null)
                        {
                            SQLDataArea.Parameters["@ToDate_Year"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER1.SOHEADER.DATETIME.YEAR;
                            SQLDataArea.Parameters["@ToDate_Month"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER1.SOHEADER.DATETIME.MONTH;
                            SQLDataArea.Parameters["@ToDate_Day"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER1.SOHEADER.DATETIME.DAY;
                        }
                    }
                    SQLDataArea.Parameters["@SOID"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SALESORDID;
                    SQLDataArea.Parameters["@POID"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.POID;
                    SQLDataArea.Parameters["@OrdTransId"].Value = resultingMessage.DATAAREA[0].GETLIST_SALESORDER.SOHEADER.SOHEADER_USERAREA.COLINX_ORDTRANSID;
                    SQLDataArea.Parameters["@TransID"].Value = TransID;
                    SQLDataArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLDataArea.ExecuteNonQuery();


                    listSalesorder.LIST_SALESORDER_005 ListSO = new listSalesorder.LIST_SALESORDER_005();

                    //return list sales order
                    SqlCommand SQLShowControlArea = new SqlCommand();
                    SQLShowControlArea.Connection = con;

                    SQLShowControlArea.CommandText = "sp_ShowListSalesOrderDataControlArea";
                    SQLShowControlArea.CommandType = CommandType.StoredProcedure;

                    SQLShowControlArea.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLShowControlArea.Parameters["@GUID"].Value = guid.ToString();
                    SQLShowControlArea.Parameters["@TransId"].Value = TransID;
                    //  SqlDataReader dr;
                    //  dr = SQLShowControlArea.ExecuteReader();
                    var x = new listSalesorder.LIST_SALESORDER_005();
                    var x1 = new CONFIRM_BOD_003();
                    var iserror = "N";

                    using (SqlDataReader dr = SQLShowControlArea.ExecuteReader())
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (dr[1].ToString() == "BOD")
                                {
                                    iserror = "Y";

                                    x1 = new CONFIRM_BOD_003();

                                }
                                else
                                {

                                    x = new listSalesorder.LIST_SALESORDER_005()
                                    {
                                        CNTROLAREA = new listSalesorder.CNTROLAREA()
                                        {
                                            BSR = new listSalesorder.BSR()
                                            {
                                                VERB = new listSalesorder.VERB() { Value = dr[0].ToString() },
                                                NOUN = new listSalesorder.NOUN()
                                                {
                                                    Value = dr[1].ToString()
                                                },
                                                REVISION = new listSalesorder.REVISION() { Value = dr[2].ToString() }
                                            },
                                            SENDER = new listSalesorder.SENDER()
                                            {
                                                LOGICALID = dr[3].ToString(),
                                                COMPONENT = dr[4].ToString(),
                                                TASK = dr[5].ToString(),
                                                REFERENCEID = dr[6].ToString(),
                                                CONFIRMATION = dr[7].ToString(),
                                                LANGUAGE = dr[8].ToString(),
                                                CODEPAGE = dr[9].ToString(),
                                                AUTHID = dr["Sender_Authid"].ToString()

                                            },
                                            DATETIME = new listSalesorder.DATETIME()
                                            {
                                                qualifier = listSalesorder.DATETIMEQualifier.CREATION,
                                                YEAR = dr[11].ToString(),
                                                MONTH = dr[12].ToString(),
                                                DAY = dr[13].ToString()
                                                                           ,
                                                HOUR = dr[14].ToString(),
                                                MINUTE = dr[15].ToString(),
                                                SECOND = dr[16].ToString(),
                                                SUBSECOND = dr[17].ToString(),
                                                TIMEZONE = dr[18].ToString()
                                            }
                                        }
                                    };
                                }
                            }
                        }
                    }


                    //populate data area
                    SqlCommand SQLShowListSalesOrder = new SqlCommand();
                    SQLShowListSalesOrder.Connection = con;

                    SQLShowListSalesOrder.CommandText = "Sp_showlistorderdataarea";
                    SQLShowListSalesOrder.CommandType = CommandType.StoredProcedure;
                    SQLShowListSalesOrder.CommandTimeout = 0;

                    SQLShowListSalesOrder.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLShowListSalesOrder.Parameters.Add("@TransId", SqlDbType.NVarChar, 60);
                    SQLShowListSalesOrder.Parameters["@GUID"].Value = guid.ToString();
                    SQLShowListSalesOrder.Parameters["@TransId"].Value = TransID;

                    if (iserror == "Y")
                    {

                        using (SqlDataReader drbod = SQLShowListSalesOrder.ExecuteReader())
                        {
                            if (drbod.HasRows)
                            {
                                DataTable dt = new DataTable(); dt.Load(drbod);
                                BOD.DATAAREA[] dx1 = new BOD.DATAAREA[1];
                                x1.DATAAREA = dx1;

                            }
                        }
                    }
                    else
                    {


                        using (SqlDataReader dr1 = SQLShowListSalesOrder.ExecuteReader())
                        {
                            if (dr1.HasRows)
                            {
                                DataTable dt = new DataTable(); dt.Load(dr1);
                                listSalesorder.DATAAREA[] d = new listSalesorder.DATAAREA[1];
                                listSalesorder.LIST_SALESORDER[] ls = new listSalesorder.LIST_SALESORDER[Convert.ToInt32(dt.Rows[0]["MaxHdr"].ToString())];
                                int lsmax = 0; int detailline = 0; int detailid = 1;

                                for (int o = 0; o < 1; o++)
                                {
                                    var pagesize = ""; var totalsize = ""; var pagerefnext = ""; var nextref = ""; var pagerefprev = ""; var prevref = "";
                                    d[o] = new listSalesorder.DATAAREA();



                                    for (int n = 0; n < dt.Rows.Count; n++)
                                    {
                                        if (detailid.ToString() == dt.Rows[n]["SOHdrDetailID"].ToString())
                                        {
                                            listSalesorder.SOLINE[] slarray = new listSalesorder.SOLINE[500];
                                            for (int p = 0; p < dt.Rows.Count; p++)
                                            {
                                                if (dt.Rows[p]["SOHdrDetailID"].ToString() == detailid.ToString())
                                                {
                                                    if (dt.Rows[p]["SOHdrID"].ToString() == "1")
                                                    {
                                                        ls[lsmax] = new listSalesorder.LIST_SALESORDER();
                                                        detailline = 0;

                                                    }

                                                    listSalesorder.DATETIME lsdt = new listSalesorder.DATETIME();
                                                    lsdt.qualifier = listSalesorder.DATETIMEQualifier.DOCUMENT;
                                                    lsdt.YEAR = dt.Rows[p]["OrdYr"].ToString();
                                                    lsdt.MONTH = dt.Rows[p]["OrdMth"].ToString();
                                                    lsdt.DAY = dt.Rows[p]["OrdDay"].ToString();
                                                    lsdt.HOUR = "00";
                                                    lsdt.MINUTE = "00";
                                                    lsdt.SECOND = "00";
                                                    lsdt.SUBSECOND = "0000";
                                                    lsdt.TIMEZONE = dt.Rows[p]["TimeZone"].ToString();

                                                    listSalesorder.SOHEADER sh = new listSalesorder.SOHEADER();
                                                    listSalesorder.SOLINE sl = new listSalesorder.SOLINE();

                                                    if (dt.Rows[p]["Detailguid"].ToString() != "")
                                                    {
                                                        listSalesorder.DATETIME sldt = new listSalesorder.DATETIME();
                                                        sldt.qualifier = listSalesorder.DATETIMEQualifier.DOCUMENT;
                                                        sldt.YEAR = dt.Rows[p]["DetailReqYr"].ToString();
                                                        sldt.MONTH = dt.Rows[p]["DetailReqMth"].ToString();
                                                        sldt.DAY = dt.Rows[p]["DetailReqDay"].ToString();
                                                        sldt.HOUR = "00";
                                                        sldt.MINUTE = "00";
                                                        sldt.SECOND = "00";
                                                        sldt.SUBSECOND = "0000";
                                                        sldt.TIMEZONE = dt.Rows[p]["DetailTimeZone"].ToString();
                                                        sldt.qualifier = listSalesorder.DATETIMEQualifier.REQUIRED;
                                                        listSalesorder.DATETIME[] sldtarray = new listSalesorder.DATETIME[1];
                                                        sldtarray[0] = sldt;
                                                        sl.DATETIME = sldtarray;
                                                        sl.DISTCENTER = dt.Rows[p]["DetailDC"].ToString();
                                                        sl.SOLNSTATUS = dt.Rows[p]["DetailStatus"].ToString().Trim();
                                                        sl.SOLINENUM = dt.Rows[p]["DetailLine"].ToString().Trim();

                                                        listSalesorder.PARTREF[] slpartrefarray = new listSalesorder.PARTREF[1];
                                                        listSalesorder.PARTREF slpartref = new listSalesorder.PARTREF();
                                                        slpartref.PARTNO = dt.Rows[p]["DetailItem"].ToString().Trim();
                                                        slpartref.PARTTYPE = dt.Rows[p]["DetailPartType"].ToString();
                                                        slpartrefarray[0] = slpartref;
                                                        sl.PARTREF = slpartrefarray;

                                                        listSalesorder.QUANTITY[] sqlqtyarray = new listSalesorder.QUANTITY[1];
                                                        listSalesorder.QUANTITY slqty = new listSalesorder.QUANTITY();
                                                        slqty.VALUE = dt.Rows[p]["DetailOrdQty"].ToString().Trim();
                                                        slqty.UOM = "EA";
                                                        slqty.SIGN = "+";
                                                        slqty.NUMOFDEC = "0";
                                                        slqty.qualifier = listSalesorder.QUANTITYQualifier.ORDERED;
                                                        sqlqtyarray[0] = slqty;
                                                        sl.QUANTITY = sqlqtyarray;

                                                        slarray[detailline] = sl;
                                                        detailline++;
                                                    }


                                                    sh.POID = dt.Rows[p]["PO"].ToString();
                                                    sh.SALESORDID = dt.Rows[p]["SO"].ToString();
                                                    sh.SOSTATUS = dt.Rows[p]["Status"].ToString();

                                                    listSalesorder.SOHEADER_USERAREA shu = new listSalesorder.SOHEADER_USERAREA();
                                                    shu.COLINX_ORDTRANSID = dt.Rows[p]["ColinxTransId"].ToString();

                                                    sh.SOHEADER_USERAREA = shu;

                                                    listSalesorder.PARTNER lspartner = new listSalesorder.PARTNER();
                                                    listSalesorder.NAME name = new listSalesorder.NAME();

                                                    name.index = "1";
                                                    name.Value = dt.Rows[p]["WWMLNM"].ToString();
                                                    lspartner.NAME = name;

                                                    lspartner.PARTNRID = dt.Rows[p]["PartnerID"].ToString();
                                                    lspartner.PARTNRTYPE = dt.Rows[p]["Partner_Type"].ToString();
                                                    listSalesorder.PARTNER[] shpartner = new listSalesorder.PARTNER[1];

                                                    shpartner[0] = lspartner;
                                                    sh.PARTNER = shpartner;

                                                    sh.SOHEADER_USERAREA = new listSalesorder.SOHEADER_USERAREA();
                                                    // sh.SOHEADER_USERAREA.COLINX_ORDTRANSID = dt.Rows[p]["ColinxTransId"].ToString();
                                                    sh.SOHEADER_USERAREA = shu;
                                                    sh.DATETIME = lsdt;

                                                    ls[lsmax].SOHEADER = sh;
                                                    ls[lsmax].SOLINE = slarray;

                                                    pagesize = dt.Rows[p]["PageSize"].ToString();
                                                    totalsize = dt.Rows[p]["TotalSize"].ToString();
                                                    pagerefnext = dt.Rows[p]["PageRef_Next"].ToString();
                                                    nextref = dt.Rows[p]["Next_Ref"].ToString();
                                                    pagerefprev = dt.Rows[p]["PageRef_Prev"].ToString();
                                                    prevref = dt.Rows[p]["Prev_Ref"].ToString();
                                                }

                                            }
                                            detailid++; lsmax++;
                                        }
                                    }
                                    d[o].LIST_SALESORDER = ls;

                                    listSalesorder.PAGELIST[] pgarray = new listSalesorder.PAGELIST[1];
                                    listSalesorder.PAGELIST pg = new listSalesorder.PAGELIST();

                                    pg.element = "RESULTS";
                                    pg.PAGESIZE = pagesize;
                                    pg.TOTALSIZE = totalsize;

                                    listSalesorder.PAGEREF[] pgrefarray = new listSalesorder.PAGEREF[2];
                                    listSalesorder.PAGEREF[] pgrefarraynext = new listSalesorder.PAGEREF[1];
                                    listSalesorder.PAGEREF pgrefnext = new listSalesorder.PAGEREF();
                                    listSalesorder.PAGEREF pgrefprev = new listSalesorder.PAGEREF();

                                    listSalesorder.REF[] refarraynext = new listSalesorder.REF[1];
                                    listSalesorder.REF[] refarrayprev = new listSalesorder.REF[1];
                                    listSalesorder.REF refernext = new listSalesorder.REF();
                                    listSalesorder.REF referprev = new listSalesorder.REF();

                                    pgrefnext.name = listSalesorder.PAGEREFName.NEXT;

                                    refernext.qualifier = pagerefnext;


                                    if (pagerefnext == "NEXT")
                                    {
                                        refernext.Value = nextref;
                                        refarraynext[0] = refernext;
                                        pgrefarraynext[0] = pgrefnext;
                                        pgrefarraynext[0].REF = refarraynext;
                                    }

                                    //prev ref 
                                    listSalesorder.PAGEREF[] pgrefarrayprev = new listSalesorder.PAGEREF[1];
                                    pgrefprev.name = listSalesorder.PAGEREFName.PREVIOUS;

                                    referprev.qualifier = pagerefprev;

                                    if (pagerefprev == "PREV")
                                    {
                                        referprev.Value = prevref;
                                        refarrayprev[0] = referprev;
                                        pgrefarrayprev[0] = pgrefprev;
                                        pgrefarrayprev[0].REF = refarrayprev;
                                    }

                                    //
                                    pgrefarray[0] = pgrefarraynext[0]; pgrefarray[1] = pgrefarrayprev[0];

                                    pg.PAGEREF = pgrefarray;

                                    pgarray[0] = pg;
                                    d[o].PAGELIST = pgarray;
                                }
                                x.DATAAREA = d;
                            }
                        }

                    }

                    return x;
                }
            }

            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand SQLInvalidXml = new SqlCommand();
                    SQLInvalidXml.Connection = con;
                    con.Open();
                    SQLInvalidXml.CommandText = "sp_InvalidXML";
                    SQLInvalidXml.CommandType = CommandType.StoredProcedure;
                    SQLInvalidXml.Parameters.Add("@GUID", SqlDbType.NVarChar, 60);
                    SQLInvalidXml.Parameters.Add("@GUIErr", SqlDbType.NVarChar, 4);
                    SQLInvalidXml.Parameters.Add("@GUImsg", SqlDbType.NVarChar, 5000);
                    SQLInvalidXml.Parameters["@GUID"].Value = guid.ToString();
                    SQLInvalidXml.Parameters["@GUIErr"].Value = "2516";
                    SQLInvalidXml.Parameters["@GUImsg"].Value = msg;
                    SQLInvalidXml.ExecuteNonQuery();
                    Session["Errmsg"] = guid;// msg;
                }

                var x = new listSalesorder.LIST_SALESORDER_005();
                return x;
            }
        }

        private string checkxml(string input, string type)
        {
            var messages = new StringBuilder();
            var settings = new XmlReaderSettings();
            XmlSchemaSet schemas = new XmlSchemaSet();
            if (type == "GetListSalesOrder")
            {
                schemas.Add(null, @"http://W2814/XSD/colinx_getlist_salesorder_005.xsd");
            }
            if (type == "GetSalesOrder")
            {
                schemas.Add(null, @"http://W2814/XSD/colinx_get_salesorder_005.xsd");
            }

            if (type == "ProcessPO")
            {
                schemas.Add(null, @"http://W2814/XSD/colinx_process_po_006.xsd");
            }

            if (type == "HostPing")
            {
                schemas.Add(null, @"http://W2814/XSD/getHost.xsd");
            }

            if (type == "GetPriceList")
            {
                schemas.Add(null, @"http://W2814/XSD/colinx_get_pricelist_002.xsd");
            }

            settings.ValidationEventHandler += (sender, args) => messages.AppendLine(args.Message);
            var reader = XmlReader.Create(new StringReader(input.Trim()), settings);

            settings.Schemas = schemas;
            settings.DtdProcessing = DtdProcessing.Ignore;
            settings.XmlResolver = null; // Doesn't help

            settings.ValidationType = ValidationType.Schema;
            //  settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            //  settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            // settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            settings.IgnoreWhitespace = true;
            XmlReader xmlReader = XmlReader.Create(new StringReader(input.Trim()), settings);
            while (xmlReader.Read()) ;

            if (messages.Length > 0)
            {
                Console.WriteLine("Document is not valid!");
                return messages.ToString();
            }
            else
                Console.WriteLine("Document is valid!"); return messages.ToString();
        }
    }
}

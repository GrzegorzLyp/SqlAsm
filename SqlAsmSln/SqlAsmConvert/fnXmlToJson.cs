using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString fnXmlToJson(SqlXml XmlSource, SqlBoolean OmitRoot)
    {
        XmlDocument xDoc = new XmlDocument();        
        xDoc.Load(XmlSource.CreateReader());
        return new SqlString(JsonConvert.SerializeXmlNode(xDoc, Newtonsoft.Json.Formatting.Indented, OmitRoot.Value));

    }
}

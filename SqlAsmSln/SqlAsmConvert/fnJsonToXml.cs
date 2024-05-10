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
    public static SqlXml fnJsonToXml(SqlString JsonString, SqlString RootName)
    {
        var xmlDocument = JsonConvert.DeserializeXmlNode(JsonString.Value, RootName.Value);
        return new SqlXml(new XmlNodeReader(xmlDocument));
    }
}

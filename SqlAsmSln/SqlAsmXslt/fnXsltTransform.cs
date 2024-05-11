using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlXml fnXsltTransform(SqlXml XmlToTransform, SqlXml XsltData)
    {
        XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
        MemoryStream stream = new MemoryStream();
        
        xslCompiledTransform.Load(XsltData.CreateReader());
        xslCompiledTransform.Transform(XmlToTransform.CreateReader(), null,XmlWriter.Create(stream));

        return new SqlXml(stream);
    }
}

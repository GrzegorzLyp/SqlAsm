using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBytes fnHttpGet(SqlString HttpUrl)
    {
        // possible usage with FTP

        byte[] result = null;

        using(WebClient webClient = new WebClient())
        {
            result = webClient.DownloadData(HttpUrl.Value);
        }

        return new SqlBytes(result);
    }
}

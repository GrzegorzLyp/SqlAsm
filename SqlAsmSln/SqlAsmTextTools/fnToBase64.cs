using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString fnToBase64(SqlBytes InputData)
    {
        return new SqlString (Convert.ToBase64String(InputData.Value));
    }
}

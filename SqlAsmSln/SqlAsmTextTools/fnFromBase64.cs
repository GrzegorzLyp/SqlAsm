using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBytes fnFromBase64(SqlString InputString)
    {
        return new SqlBytes (Convert.FromBase64String(InputString.Value));
    }
}

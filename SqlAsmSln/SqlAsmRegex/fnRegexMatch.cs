using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean fnRegexMatch(SqlChars InputString, SqlString RegexPattern)
    {
        return Regex.IsMatch(InputString.ToSqlString().Value, RegexPattern.Value);
    }
}

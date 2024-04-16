using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlChars fnRegexReplace(SqlChars InputString, SqlString RegexPattern, SqlString Replacement)
    {
        return new SqlChars(Regex.Replace(InputString.ToSqlString().Value, RegexPattern.Value, Replacement.Value));
    }
}

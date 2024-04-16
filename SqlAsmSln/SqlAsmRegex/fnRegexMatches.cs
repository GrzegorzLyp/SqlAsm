using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(FillRowMethodName = "fnRegexMatchesFillRow", TableDefinition = "Id int, Result nvarchar(max)")]
    public static IEnumerable fnRegexMatches(SqlChars InputString, SqlString RegexPattern)
    {
        return Regex.Matches(InputString.ToSqlString().Value, RegexPattern.Value);
    }

    public static void fnRegexMatchesFillRow(Object obj, out SqlInt32 Id, out SqlChars Result)
    {
        Match match = (Match)obj;
        Id = match.Index;
        Result = new SqlChars(match.Value);
    }
}

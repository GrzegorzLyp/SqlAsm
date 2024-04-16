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
    [Microsoft.SqlServer.Server.SqlFunction(FillRowMethodName = "fnRegexSplitFillRow", TableDefinition = "Id int, Result nvarchar(max)")]
    public static IEnumerable fnRegexSplit(SqlChars InputString, SqlString RegexPattern)
    {
        var splitResult = Regex.Split(InputString.ToSqlString().Value, RegexPattern.Value);

        var keyValues = new Dictionary<int, string>(splitResult.Length);
        int index = 0;

        foreach (var item in splitResult)
        {
            keyValues.Add(++index, item);
        }
        return keyValues;
    }

    public static void fnRegexSplitFillRow(Object obj, out SqlInt32 Id, out SqlChars Result)
    {
        KeyValuePair<int, string> valuePair = (KeyValuePair<int, string>)obj;
        Id = valuePair.Key;
        Result = new SqlChars(valuePair.Value);
    }
}

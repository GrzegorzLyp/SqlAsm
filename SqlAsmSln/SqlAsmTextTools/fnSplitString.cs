using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(FillRowMethodName ="fnStringSplitFillRow", TableDefinition = "Id int, Result nvarchar(max)")]
    public static IEnumerable fnSplitString(SqlChars InputString, SqlString SplitString)
    {
        var values = InputString.IsNull
                       ? new String[0]
                       : InputString.ToSqlString().Value.Split(new String[] { SplitString.Value }, StringSplitOptions.None);

        var keyValues = new Dictionary<int, string>(values.Length);
        int index = 0;

        foreach (var item in values)
        {
            keyValues.Add(++index, item);
        }
        return keyValues;
    }

    public static void fnStringSplitFillRow(Object obj, out SqlInt32 Id, out SqlChars Result)
    {
        KeyValuePair<int, string> valuePair = (KeyValuePair<int, string>)obj;
        Id = valuePair.Key;
        Result = new SqlChars(valuePair.Value);
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBytes fnConvertEncoding(SqlString SourceEncoding, 
                                              SqlString DestinationEncoding, 
                                              SqlBytes DataToConvert)
    {
        var result = Encoding.Convert(Encoding.GetEncoding(SourceEncoding.Value),
                                      Encoding.GetEncoding(DestinationEncoding.Value),
                                      DataToConvert.Value);

        return new SqlBytes (result);
    }
}

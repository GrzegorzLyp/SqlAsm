using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.IO.Compression;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBytes fnCompress(SqlBytes DataToCompress)
    {
        var memoryStream = new MemoryStream();
        var zipStream = new GZipStream(memoryStream, CompressionMode.Compress,true);
        var inputData = DataToCompress.Value;
        zipStream.Write(inputData, 0, inputData.Length);
        zipStream.Close();     
        return new SqlBytes(memoryStream.ToArray());
    }
}

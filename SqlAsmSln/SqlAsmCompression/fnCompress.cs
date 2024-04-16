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
        var memoryStream = new MemoryStream(DataToCompress.Value);
        var zipStream = new GZipStream(memoryStream, CompressionMode.Compress);
        var memoryStreamOut = new MemoryStream();
        
        zipStream.CopyTo(memoryStreamOut);
        return new SqlBytes(memoryStreamOut.ToArray());
    }
}

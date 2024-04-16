using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO.Compression;
using System.IO;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBytes fnDecompress(SqlBytes DataToDecompress)
    {
        var memoryStream = new MemoryStream(DataToDecompress.Value);
        var zipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
        var memoryStreamOut = new MemoryStream();

        zipStream.CopyTo(memoryStreamOut);
        return new SqlBytes(memoryStreamOut.ToArray());
    }
}

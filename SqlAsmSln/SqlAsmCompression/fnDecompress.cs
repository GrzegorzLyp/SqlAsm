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
        var memoryStream = new MemoryStream();
        var zipStream = new GZipStream(DataToDecompress.Stream, CompressionMode.Decompress);
        zipStream.CopyTo(memoryStream);
        return new SqlBytes(memoryStream.ToArray());
    }
}

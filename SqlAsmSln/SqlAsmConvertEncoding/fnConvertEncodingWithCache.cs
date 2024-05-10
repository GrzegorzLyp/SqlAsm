using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security;
using System.Text;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    static readonly ConcurrentDictionary<string, Encoding> encCache = new ConcurrentDictionary<string, Encoding>();

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBytes fnConvertEncodingWithCache(SqlString SourceEncoding,
                                                      SqlString DestinationEncoding,
                                                      SqlBytes DataToConvert)
    {
        string sEncoding = SourceEncoding.Value.ToLower();
        string dEncoding = DestinationEncoding.Value.ToLower();

        if (!encCache.TryGetValue(sEncoding, out Encoding srcEncoding))
        {
            srcEncoding = Encoding.GetEncoding(sEncoding);
            encCache.TryAdd(sEncoding, srcEncoding);            
        }

        if (!encCache.TryGetValue(dEncoding, out Encoding dstEncoding))
        {
            dstEncoding = Encoding.GetEncoding(dEncoding);
            encCache.TryAdd(dEncoding, dstEncoding);
        }

        var result = Encoding.Convert(srcEncoding,
                                      dstEncoding,
                                      DataToConvert.Value);

        return new SqlBytes(result);
    }
}

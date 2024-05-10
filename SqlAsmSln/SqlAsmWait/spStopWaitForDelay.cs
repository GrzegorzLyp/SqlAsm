using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void spStopWaitForDelay (SqlString WaitName)
    {
        if(waits.TryGetValue(WaitName.Value,out Thread thread))
        {
            thread?.Abort();
        }
    }
}

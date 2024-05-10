using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{

    static ConcurrentDictionary<string,Thread> waits = new ConcurrentDictionary<string,Thread>();

    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void spWaitForDelay (SqlString WaitName, SqlInt32 WaitTime)
    {
        if (waits.TryAdd(WaitName.Value, null))
        {
            var task = Task.Factory.StartNew(() =>
            {
                if (waits.TryUpdate(WaitName.Value, Thread.CurrentThread, null))
                {
                    Thread.Sleep(WaitTime.Value);
                }
            }, TaskCreationOptions.LongRunning);
            Task.WaitAny(task);
            waits.TryRemove(WaitName.Value, out Thread thread);
        }
        else
        {
            throw new Exception("Delay already initiated");
        }        
    }
}

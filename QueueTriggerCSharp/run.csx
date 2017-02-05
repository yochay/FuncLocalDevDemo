/*
 * 
 * NOTE - since this is a VS local demo, check functions.json 
 * if function is disabled or not to make sure VS get triggered on the Q item 
 * and not the Azure function
 * 
 */
using System;

public static void Run(string myQueueItem, TraceWriter log)
{
    log.Info($"C# Queue trigger function processed: {myQueueItem}");
}
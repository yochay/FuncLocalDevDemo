using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, IAsyncCollector<string>  outputQueueItem, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    string name = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
        .Value;

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Set name to query string or body data
    name = name ?? data?.name;

    if( string.IsNullOrEmpty(name) )
    {
        //return error
       return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");
    }
    //else

    //add to q sync
    //outputQueueItem = ("the parameter name =  " + name;

    //add to q async
    await outputQueueItem.AddAsync("the parameter name =  " + name);
    
    return req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
}

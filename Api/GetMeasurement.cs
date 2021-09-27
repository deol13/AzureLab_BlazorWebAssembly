using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api
{
    public static class GetMeasurement
    {
        [FunctionName("GetMeasurement")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [CosmosDB(databaseName: "IOT", collectionName: "Measurement", ConnectionStringSetting = "CosmosDB", SqlQuery = "SELECT * FROM c ORDER BY c._ts DESC")] IEnumerable<dynamic> cosmos,
            ILogger log)
        {
            return new OkObjectResult(cosmos);
        }
    }
}

using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Api.Models;

namespace Api
{
    public static class SaveData
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("SaveData")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "IotHubEndPoint", ConsumerGroup = "cosmos")]EventData message, 
            [CosmosDB(databaseName: "IOT", collectionName: "Measurement", CreateIfNotExists = true, ConnectionStringSetting = "CosmosDB")] out dynamic cosmos,
            ILogger log)
        {
            ////Way1
            //cosmos = Encoding.UTF8.GetString(message.Body.Array);


            ////Way2
            //var body = JsonConvert.DeserializeObject<dynamic>(Encoding.UTF8.GetString(message.Body.Array));

            //var payload = new
            //{
            //    deviceId = message.SystemProperties["iothub-connection-device-id"].ToString(),
            //    temperature = body.temperature,
            //    humidity = body.humidity,
            //    placement = body.placement,
            //    status = body.status
            //};

            //cosmos = payload;


            //Way3
            var data = JsonConvert.DeserializeObject<DhtMeasurement>(Encoding.UTF8.GetString(message.Body.Array));
            data.DeviceId = message.SystemProperties["iothub-connection-device-id"].ToString();

            cosmos = data;
        }
    }
}
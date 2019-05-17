using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.ReferenceData.Functions
{
    public static class Swagger
    {
        [FunctionName("Swagger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "referencedata/swagger.json")] HttpRequest req,
            ILogger log)
        {
            using (var client = new HttpClient())
            using (var response = await client.GetAsync("http://localhost:5000/swagger/v1/swagger.json"))
            using (var content = response.Content)
            {
                var json = await content.ReadAsStringAsync();
                var result = JObject.Parse(json);
                var url = req.GetDisplayUrl();
                if (req.Path.HasValue && !string.IsNullOrWhiteSpace(req.Path.Value)) url = url.Replace(req.Path, string.Empty);
                if (req.QueryString.HasValue && !string.IsNullOrWhiteSpace(req.QueryString.Value)) url = url.Replace(req.QueryString.Value, string.Empty);
                result.Add("servers", JToken.FromObject(new object[] { new { url }}));

                return new JsonResult(result);
            }
        }
    }
}
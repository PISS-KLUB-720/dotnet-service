using Newtonsoft.Json;

namespace TennisServe.Web.Models
{
    public class PredictResponseModel
    {
        [JsonProperty("position")]
        public string ServePosition { get; set; }
    }
}
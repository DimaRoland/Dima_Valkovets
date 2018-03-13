using Newtonsoft.Json;

namespace DataModel
{
    public class DataViewModel
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Posted")]
        public  string Posted { get; set; }
    }
}

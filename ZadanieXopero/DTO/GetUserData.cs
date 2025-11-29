using System.Text.Json.Serialization;

namespace ZadanieXopero.DTO
{
    public class GetUserData
    {
        public int id { get; set; }
        public string email { get; set; }
        [JsonPropertyName("first_name")]
        public string firstName { get; set; }
        [JsonPropertyName("last_name")]
        public string lastName { get; set; }
        public string avatar { get; set; }
    }
}

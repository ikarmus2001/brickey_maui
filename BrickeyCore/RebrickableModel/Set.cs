using System.Text.Json.Serialization;

namespace BrickeyCore.RebrickableModel
{
    public class Set
    {
        [JsonPropertyName("set_num")]
        public string Id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public int theme_id { get; set; }
        public int num_parts { get; set; }

        [JsonPropertyName("set_img_url")]
        public string imageURL { get; set; }

        [JsonPropertyName("set_url")]
        public string rebrickableURL { get; set; }
        public DateTime last_modified_dt { get; set; }

    }
}

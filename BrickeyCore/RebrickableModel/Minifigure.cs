using System.Text.Json.Serialization;

namespace BrickeyCore.RebrickableModel
{
    public class Minifigure
    {
        public string name { get; set; }

        public string set_num { get; set; }

        [JsonPropertyName("num_parts")]
        public int partsCount { get; set; }

        [JsonPropertyName("set_img_url")]
        public string imageURL { get; set; }

        [JsonPropertyName("set_url")]
        public string rebrickableURL { get; set; }

        public DateTime last_modified_dt { get; set; }
    }
}

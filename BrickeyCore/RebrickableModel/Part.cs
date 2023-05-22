using System.Text.Json.Serialization;

namespace BrickeyCore.RebrickableModel
{
    public class Part
    {
        [JsonPropertyName("part_num")]
        public string Id { get; set; }
        public string name { get; set; }
        public int part_cat_id { get; set; }

        [JsonPropertyName("part_url")]
        public string rebrickableURL { get; set; }

        [JsonPropertyName("part_img_url")]
        public string imageURL { get; set; }
        public PartExternal_Ids external_ids { get; set; }
        public string print_of { get; set; }
    }


    public class PartExternal_Ids
    {
        public string[] Brickset { get; set; }
        public string[] BrickLink { get; set; }
        public string[] BrickOwl { get; set; }
        public string[] LEGO { get; set; }
    }
}

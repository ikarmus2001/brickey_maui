using System.Text.Json.Serialization;

namespace BrickeyCore.RebrickableModel
{
    public class Minifigure
    {
        public required string name { get; set; }

        [JsonPropertyName("set_num")]
        public required string Id { get; set; }

        [JsonPropertyName("num_parts")]
        public required int partsCount { get; set; }

        [JsonPropertyName("set_img_url")]
        public string? imageURL { get; set; }

        [JsonPropertyName("set_url")]
        public required string rebrickableURL { get; set; }

        public required DateTime last_modified_dt { get; set; }
    }
}

/*
{
      "set_num": "fig-011726",
      "name": "Grogu / The Child (Baby Yoda) in Christmas Outfit",
      "num_parts": 2,
      "set_img_url": "https://cdn.rebrickable.com/media/sets/fig-011726/105165.jpg",
      "set_url": "https://rebrickable.com/minifigs/fig-011726/grogu-the-child-baby-yoda-in-christmas-outfit/",
      "last_modified_dt": "2021-12-14T02:38:38.867006Z"
}
*/
using System.Text.Json.Serialization;

namespace BrickeyCore.RebrickableModel
{
    public class Minifigure
    {
        public string name { get; set; }

        [JsonPropertyName("set_num")]
        public string Id { get; set; }

        [JsonPropertyName("num_parts")]
        public int partsCount { get; set; }

        [JsonPropertyName("set_img_url")]
        public string imageURL { get; set; }

        [JsonPropertyName("set_url")]
        public string rebrickableURL { get; set; }

        public DateTime last_modified_dt { get; set; }
    }
}

/*
{
  "count": 2,
  "next": null,
  "previous": null,
  "results": [
    {
      "set_num": "fig-010525",
      "name": "Grogu / The Child (Baby Yoda)",
      "num_parts": 2,
      "set_img_url": "https://cdn.rebrickable.com/media/sets/fig-010525/75011.jpg",
      "set_url": "https://rebrickable.com/minifigs/fig-010525/grogu-the-child-baby-yoda/",
      "last_modified_dt": "2021-12-14T02:38:54.400650Z"
    },
    {
      "set_num": "fig-011726",
      "name": "Grogu / The Child (Baby Yoda) in Christmas Outfit",
      "num_parts": 2,
      "set_img_url": "https://cdn.rebrickable.com/media/sets/fig-011726/105165.jpg",
      "set_url": "https://rebrickable.com/minifigs/fig-011726/grogu-the-child-baby-yoda-in-christmas-outfit/",
      "last_modified_dt": "2021-12-14T02:38:38.867006Z"
    }
  ]
}
/*
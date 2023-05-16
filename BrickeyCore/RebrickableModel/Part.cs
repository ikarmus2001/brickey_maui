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
        public External_Ids external_ids { get; set; }
        public string print_of { get; set; }
    }


    public class External_Ids
    {
        public Brickset Brickset { get; set; }
        public Bricklink BrickLink { get; set; }
        public Brickowl BrickOwl { get; set; }
        public LEGO LEGO { get; set; }
        public Peeron Peeron { get; set; }
        public Ldraw LDraw { get; set; }
    }

    public class Brickset
    {
        public int[] ext_ids { get; set; }
        public string[][] ext_descrs { get; set; }
    }

    public class Bricklink
    {
        public int[] ext_ids { get; set; }
        public string[][] ext_descrs { get; set; }
    }

    public class Brickowl
    {
        public int[] ext_ids { get; set; }
        public string[][] ext_descrs { get; set; }
    }

    public class LEGO
    {
        public int[] ext_ids { get; set; }
        public string[][] ext_descrs { get; set; }
    }

    public class Peeron
    {
        public object[] ext_ids { get; set; }
        public string[][] ext_descrs { get; set; }
    }

    public class Ldraw
    {
        public int[] ext_ids { get; set; }
        public string[][] ext_descrs { get; set; }
    }
}

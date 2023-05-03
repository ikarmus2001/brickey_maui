namespace BrickeyCore.RebrickableModel
{
    public class MinifiguresResponse
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public Minifigure[] results { get; set; }
    }

    public class Minifigure
    {
        public string set_num { get; set; }
        public string name { get; set; }
        public int num_parts { get; set; }
        public string set_img_url { get; set; }
        public string set_url { get; set; }
        public DateTime last_modified_dt { get; set; }
    }
}

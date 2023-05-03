namespace BrickeyCore.RebrickableModel
{
    public class MinifiguresResponse
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public Minifigure[] results { get; set; }
    }
}

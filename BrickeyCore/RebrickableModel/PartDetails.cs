namespace BrickeyCore.RebrickableModel
{
    public class PartDetails : Part
    {
        public int year_from { get; set; }
        public int year_to { get; set; }
        public object[] prints { get; set; }
        public object[] molds { get; set; }
        public object[] alternates { get; set; }

    }
}

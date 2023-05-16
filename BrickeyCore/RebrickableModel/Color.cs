namespace BrickeyCore.RebrickableModel;

public class Color
{
    public int id { get; set; }
    public string name { get; set; }
    public string rgb { get; set; }
    public bool is_trans { get; set; }
    public External_Ids external_ids { get; set; }
}
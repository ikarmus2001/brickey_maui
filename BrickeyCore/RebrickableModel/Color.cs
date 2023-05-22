namespace BrickeyCore.RebrickableModel;

public class Color
{
    public int id { get; set; }
    public string name { get; set; }
    public string rgb { get; set; }
    public bool is_trans { get; set; }
    public ColorExternal_Ids external_ids { get; set; }
}

public class ColorExternal_Ids
{
    public Brickset Brickset { get; set; }
    public BrickLink BrickLink { get; set; }
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

public class BrickLink
{
    public int[]? ext_ids { get; set; }
    public string[][]? ext_descrs { get; set; }
}

public class Brickowl
{
    public int[]? ext_ids { get; set; }
    public string[][] ext_descrs { get; set; }
}

public class LEGO
{
    public int[]? ext_ids { get; set; }
    public string[][] ext_descrs { get; set; }
}

public class Peeron
{
    public object[]? ext_ids { get; set; }
    public string[][] ext_descrs { get; set; }
}

public class Ldraw
{
    public int[] ext_ids { get; set; }
    public string[][] ext_descrs { get; set; }
}
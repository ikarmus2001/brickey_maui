namespace BrickeyCore.RebrickableModel
{
    public class PagedResponse<T>
    {
        public int count { get; set; }
        public string? next { get; set; }
        public string? previous { get; set; }
        public List<T> results { get; set; }
    }
}

namespace brickey_maui.Models
{
    public class QueryPageModel
    {
        public List<QueryElement> queryElements;
        public int count;
#nullable enable
        public string? next;
        public string? previous;
#nullable disable
    }
}

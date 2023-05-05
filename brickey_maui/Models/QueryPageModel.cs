namespace brickey_maui.Models
{
    internal class QueryPageModel
    {
        internal List<QueryElement> queryElements;
        internal int count;
        internal string? next;
        internal string? previous;
    }

    internal class QueryElement
    {
        internal Image thumbnail;
        internal string title;
        internal string description;
    }
}

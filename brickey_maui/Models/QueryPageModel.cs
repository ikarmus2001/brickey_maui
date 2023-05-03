namespace brickey_maui.Models
{
    internal class QueryPageModel<T>
    {
        internal List<T> queryElements;
        internal int count;
        internal string? next;
        internal string? previous;
    }
}

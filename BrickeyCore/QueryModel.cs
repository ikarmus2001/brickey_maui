namespace BrickeyCore
{
    public class QueryModel
    {
        public enum QueryType
        {
            Minifigure,
            Set,
            Part
        }

        public QueryType queryType;
        public Dictionary<string, string> parameters;
    }
}

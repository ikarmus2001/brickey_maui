namespace BrickeyCore
{
    public class QueryModel
    {
        public enum QueryType
        {
            MiniFigure,
            Set,
            Part
        }

        public QueryType queryType;
        public Dictionary<string, string> parameters;


        public QueryModel() { }
    }
}

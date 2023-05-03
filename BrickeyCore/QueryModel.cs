using BrickeyCore;

namespace brickey_maui.Models
{
    public class QueryModel
    {
        enum QueryType
        {
            MiniFigure,
            Set,
            Theme,
            All
        }

        Dictionary<string, string> parameters;
        QueryType queryType;

        object result;

        QueryModel(Dictionary<string, string> parameters)
        {
            this.parameters = parameters;
        }

        public async Task<List<object>> RetrieveDatabaseInfo()
        {
            switch (queryType)
            {
                case QueryType.MiniFigure:
                    var x = (await RebrickableApiWrapper.GetMinifigures(parameters["search"]));
                    goto default;
                case QueryType.Set:
                case QueryType.Theme:
                case QueryType.All:
                default:
                    break;
            }
            return new List<object>() { };
        }
    }
}

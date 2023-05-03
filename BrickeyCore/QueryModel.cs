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

        public async Task<object> RetrieveDatabaseInfo()
        {
            switch (queryType)
            {
                case QueryType.MiniFigure:
                    return (await RebrickableApiWrapper.GetMinifigure(parameters)).ToQueryPageModel();
            }
        }
    }
}

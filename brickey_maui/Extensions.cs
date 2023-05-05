using brickey_maui.Models;
using BrickeyCore.RebrickableModel;

namespace brickey_maui
{
    internal static class Extensions
    {
        internal static QueryPageModel ToQueryPageModel(this PagedResponse<Minifigure> prMinifigure)
        {
            return new QueryPageModel()
            {
                count = prMinifigure.count,
                next = prMinifigure.next,
                previous = prMinifigure.previous,
                queryElements = prMinifigure.results.ToQueryElement()
            };
        }

        internal static List<QueryElement> ToQueryElement(this List<Minifigure> mfs)
        {
            var result = new List<QueryElement>();
            foreach (Minifigure mf in mfs)
            {
                Image thumb = new()
                {
                    Source = ImageSource.FromUri(new Uri(mf.imageURL))
                };
                    
                result.Add(new QueryElement()
                {
                    title = mf.name,
                    description = mf.set_num,
                    thumbnail = thumb
                });
            }
            return result;
        }

        //internal static QueryPageModel ToQueryPageModel(this PagedResponse<Part> prPart)
        //{
        //    return new QueryPageModel()
        //    {
        //        count = prPart.count,
        //        next = prPart.next,
        //        previous = prPart.previous,
        //        queryElements = prPart.results.ToQueryElement()
        //    };
        //}

        //internal static QueryPageModel ToQueryPageModel(this PagedResponse<BrickeyCore.RebrickableModel.Set> prMinifigure)
        //{
        //    return new QueryPageModel()
        //    {
        //        count = ,
        //        next = ,
        //        previous = ,
        //        queryElements =
        //    };
        //}
    }
}

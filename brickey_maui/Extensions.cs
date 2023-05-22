using brickey_maui.Models;
using BrickeyCore.RebrickableModel;

namespace brickey_maui
{
    public static class Extensions
    {
        public static QueryPageModel ToQueryPageModel(this PagedResponse<Minifigure> prMinifigure)
        {
            return new QueryPageModel()
            {
                count = prMinifigure.count,
                next = prMinifigure.next,
                previous = prMinifigure.previous,
                queryElements = prMinifigure.results.ToQueryElement()
            };
        }

        public static List<QueryElement> ToQueryElement(this List<Minifigure> mfs)
        {
            var result = new List<QueryElement>();
            foreach (Minifigure mf in mfs)
            {       
                result.Add(new QueryElement()
                {
                    title = mf.name,
                    description = $"{mf.Id}",
                    id = mf.Id,
                    thumbnail = ImageSource.FromUri(new Uri(mf.imageURL ?? "https://cdn-icons-png.flaticon.com/512/1548/1548682.png"))
                });
            }
            return result;
        }

        public static QueryPageModel ToQueryPageModel(this PagedResponse<Part> prPart)
        {
            return new QueryPageModel()
            {
                count = prPart.count,
                next = prPart.next,
                previous = prPart.previous,
                queryElements = prPart.results.ToQueryElement()
            };
        }

        public static List<QueryElement> ToQueryElement(this List<Part> parts)
        {
            var result = new List<QueryElement>();
            foreach (Part p in parts)
            {
                result.Add(new QueryElement()
                {
                    title = p.name,
                    description = $"{p.Id}",
                    id = p.Id,
                    thumbnail = ImageSource.FromUri(new Uri(p.imageURL ?? "https://cdn-icons-png.flaticon.com/512/1548/1548682.png"))
                });
            }
            return result;
        }


        public static QueryPageModel ToQueryPageModel(this PagedResponse<Set> prSets)
        {
            return new QueryPageModel()
            {
                count = prSets.count,
                next = prSets.next,
                previous = prSets.previous,
                queryElements = prSets.results.ToQueryElement()
            };
        }

        public static List<QueryElement> ToQueryElement(this List<Set> sets)
        {
            var result = new List<QueryElement>();
            foreach (Set s in sets)
            {
                result.Add(new QueryElement()
                {
                    title = s.name,
                    description = $"{s.Id}",
                    id = s.Id,
                    thumbnail = ImageSource.FromUri(new Uri(s.imageURL ?? "https://cdn-icons-png.flaticon.com/512/1548/1548682.png"))
                });
            }
            return result;
        }
    }
}

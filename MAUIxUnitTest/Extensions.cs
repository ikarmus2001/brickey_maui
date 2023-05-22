using brickey_maui.Models;
using BrickeyCore.RebrickableModel;
using FluentAssertions;

namespace MAUIxUnitTest
{
    public class Extensions
    {
        [Fact]
        [Trait("Category", "Extensions")]
        public void ToQueryPageModel_Minifigure()
        {
            var inputCount = 95;
            var inputNext = "https://rebrickable.com/api/v3/lego/minifigs/?page=2&page_size=50&search=batman";
            string? inputPrevious = null;
            var minifig = new Minifigure()
            {
                Id = "fig-000010",
                name = "Batman, Dark Bluish Gray Suit, Black Cape and Cowl, Black Head, Dark Bluish Gray Legs, Small Batman Logo",
                partsCount = 5,
                imageURL = "https://cdn.rebrickable.com/media/sets/fig-000010/109968.jpg",
                rebrickableURL = "https://rebrickable.com/minifigs/fig-000010/batman-dark-bluish-gray-suit-black-cape-and-cowl-black-head-dark-bluish-gray-legs-small-batman-logo/",
                last_modified_dt = Convert.ToDateTime("2021-10-01T20:43:32.993669Z")
            };

            var inputMinifigs = new List<Minifigure> { minifig };

            var input = new PagedResponse<Minifigure>()
            {
                count = inputCount,
                next = inputNext,
                previous = inputPrevious,
                results = inputMinifigs
            };

            var expected = new QueryPageModel()
            {
                count = input.count,
                next = inputNext,
                previous = inputPrevious,
                queryElements = inputMinifigs.ToQueryElement()
            };

            var methodOutput = input.ToQueryPageModel();

            //Assert.Equal(methodOutput, expected);
            methodOutput.Should().BeEquivalentTo(expected, options => options.Excluding(o => o.queryElements[0].thumbnail)
                                                                             .Including(o => ((UriImageSource)o.queryElements[0].thumbnail).Uri));

        }
    }
}
using BrickeyCore.RebrickableModel;
using FluentAssertions;

namespace MAUIxUnitTest
{
    public class RebrickableApiWrapper
    {
        private async Task<bool> ApiSetup()
        {
            return await BrickeyCore.RebrickableApiWrapper.Setup("422ab08097aa1b996d957abbbeb46029", "ikarmus", "27RJ7R_DvzwKF_Pg");
        }

        [Fact]
        public async void GetMinifigureParts()
        {
            await ApiSetup();
            var mfId = "fig-012587";

            PagedResponse<PartOfSet> expected = new PagedResponse<PartOfSet>
            {
                count = 4,
                next = null,
                previous = null,
                results = new List<PartOfSet>
                {
                    new PartOfSet
                    {
                        id = 12390298,
                        inv_part_id = 12390298,
                        part = new Part
                        {
                            Id = "01675pr0001",
                            name = "Hair Long Braided Front, Loose Back with Trans-Light Blue Rings Print",
                        },
                        color = new BrickeyCore.RebrickableModel.Color
                        {

                        },
                        set_num = mfId,
                        quantity = 1,
                        is_spare = false,
                        element_id = "6390916",
                        num_sets = 1
                    }
                }
            };

            PagedResponse<PartOfSet> methodOutput;
            try
            {
                methodOutput = await BrickeyCore.RebrickableApiWrapper.GetMinifigureParts(mfId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            //methodOutput.Should().
        }
    }
}

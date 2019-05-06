using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace ClassLibrary.Tests
{
    public class MapTests
    {
        [Theory]
        // Should result in 0 locations in the map's collection of locations.
        [InlineData(-123)] 
        // Should result in 0 locations in the map's collection of locations.
        [InlineData(0)] 
        // Should result in 4 locations in the map's collection of locations.
        [InlineData(4)]
        // Should result in 16 locations in the map's collection of locations.
        // Since the map's grid is 4x4 thus total of 16 potential cells that
        // can be occupied by a location (that inherits from the Cell object).
        [InlineData(57)]
        public void TestNumberOfLocations(int numberOfLocations)
        {
            /* Under the condition that the number of cells is > 0
             * for my test case I've set this to 4, resulting in a
             * 4 * 4 map object. If this would be 0 or less than
             * the input number of locations.*/ 
            const int NUMBER_OF_CELLS = 4;
            const int CELLSIZE = 40;
            PictureBox EMPTY_PICTURE_BOX = new PictureBox();

            Map map = new Map(numberOfLocations, NUMBER_OF_CELLS, CELLSIZE, EMPTY_PICTURE_BOX);
            int locationCount = map.Locations.Count;
            // Number of locations is 0 or negative.
            if (numberOfLocations <= 0)
            {
                Assert.True(locationCount == 0);
            }
            else
            {
                // The number of locations is positive, but might exceed the 
                // number of cells in the map.
                if (numberOfLocations <= NUMBER_OF_CELLS * NUMBER_OF_CELLS)
                {
                    // Make sure the locationCoutn is equal to the input number of locations.
                    Assert.True(locationCount == numberOfLocations);
                }
                else
                {
                    // Make sure the number of locations the map holds is equal to the
                    // maximum possible, which is the 4x4 square or 16.
                    Assert.True(locationCount == NUMBER_OF_CELLS * NUMBER_OF_CELLS);
                }
            }
        }
    }
}

using System;
using System.Windows.Forms;
using Xunit;

namespace ClassLibrary.Tests
{
    public class MapTests
    {
        [Theory]
        // Should result in 0 locations in the map's collection of locations.
        [InlineData(-123, 4)] 
        // Should result in 0 locations in the map's collection of locations.
        [InlineData(0, 4)] 
        // Should result in 4 locations in the map's collection of locations.
        [InlineData(4, 4)]
        // Should result in 16 locations in the map's collection of locations.
        // Since the map's grid is 4x4 thus total of 16 potential cells that
        // can be occupied by a location (that inherits from the Cell object).
        [InlineData(57, 4)]
        // Should result in 0 locations in the map's collection of locations.
        [InlineData(4, 0)]
        // Should result in 0 locations in the map's collection of locations as the number of cells should be set to a 0x0 grid.
        [InlineData(4, -13)]
        // Should result in 0 locations in the map's collection of locations as the number of locations is < 0.
        [InlineData(-10, -13)]
        public void TestNumberOfLocations(int numberOfLocations, int numberOfCells)
        {
            const int CELLSIZE = 40;
            PictureBox EMPTY_PICTURE_BOX = new PictureBox();

            Map map = new Map(numberOfCells, CELLSIZE, EMPTY_PICTURE_BOX, numberOfLocations);
            int locationCount = map.Locations.Count;
            
            // Number of locations is 0 or negative.
            if (numberOfLocations <= 0 || numberOfCells < 0)
            {
                Assert.True(locationCount == 0);
            }
            else
            {
                // The number of locations is positive, but might exceed the 
                // number of cells in the map.
                if (numberOfLocations <= numberOfCells * numberOfCells)
                {
                    // Make sure the locationCount is equal to the input number of locations.
                    Assert.True(locationCount == numberOfLocations);
                }
                else
                {
                    // Make sure the number of locations the map holds is equal to the
                    // maximum possible, which is the 4x4 square or 16.
                    Assert.True(locationCount == numberOfCells * numberOfCells);
                }
            }
        }

        [Theory]
        // Should throw an ArgumentOutOfRangeException
        [InlineData(-1, 0)]
        // Should throw an ArgumentOutOfRangeException
        [InlineData(-1, -1)]
        // Should throw an ArgumentOutOfRangeException
        [InlineData(3, -100)]
        // Add a road between the Location itself, should result in location 0.
        [InlineData(0, 0)]
        // Add a road between the two Locations should result in a road where Road.vertex1 == map.Locations[1] and Road.vertex2 == map.Locations[2].
        [InlineData(1, 2)]
        // Add a road between the two Locations should result in a road where Road.vertex1 == map.Locations[3] and Road.vertex2 == map.Locations[1].
        [InlineData(3, 1)]
        // Should throw an ArgumentOutOfRangeException, since the number of locations is less than 12.
        [InlineData(1, 12)]
        public void TestCreateEdge(int source, int destination)
        {
            const int NUMBER_OF_LOCATIONS = 4;
            const int NUMBER_OF_CELLS = 4;
            const int CELLSIZE = 40;
            PictureBox EMPTY_PICTURE_BOX = new PictureBox();

            Map map = new Map(NUMBER_OF_CELLS, CELLSIZE, EMPTY_PICTURE_BOX, NUMBER_OF_LOCATIONS);

            if (source < 0 || destination < 0 || source > map.Locations.Count - 1 || destination > map.Locations.Count - 1)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => map.Edges.Add(new Road(map.Locations[source], map.Locations[destination])));
            }
            else
            {
                map.Edges.Add(new Road(map.Locations[source], map.Locations[destination]));
                Assert.True(map.Edges.Count == 1);
                Road edge = map.Edges[0]; // As the collection should only hold 1 edge.
                Assert.True(edge.Vertex1 == map.Locations[source] && edge.Vertex2 == map.Locations[destination]);
            }

        }
    }
}

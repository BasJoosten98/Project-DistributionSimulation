using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using Xunit;

namespace SimulationApplicationTests
{
    public class CellTests
    {
        [Fact]
        public void TestMaxDemand()
        {
            const int MAX_DEMAND = 200;

            const int NUMBER_OF_CELLS = 13;
            const int CELLSIZE = 40;
            PictureBox EMPTY_PICTURE_BOX = new PictureBox();
            Map map = new Map(NUMBER_OF_CELLS, CELLSIZE, EMPTY_PICTURE_BOX);

            int initialTestDemand = Cell.maxDemand + 4;
            for (int i = Cell.maxDemand + 1; i <= initialTestDemand; i++)
            {
                map.Locations[0].SetDemandGrow(i);
                Assert.Equal(i, Cell.maxDemand);
            }

            map.Locations[0].SetDemandGrow(MAX_DEMAND);
            Assert.Equal(MAX_DEMAND, Cell.maxDemand);

            map.Locations[0].SetDemandGrow(5);
            Assert.NotEqual(5, Cell.maxDemand);

            map.ReAssignMaxDemandAndGrowth();
            Assert.Equal(5, Cell.maxDemand);
        }

    }
}

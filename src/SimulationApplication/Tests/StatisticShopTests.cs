
using Xunit;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace SimulationApplicationTests
{
  
    public class StatisticShopTests
    {


        [Fact()]
        public void ZeroStockTime()
        {
            //initialize 3 shops with 0 stock
            PictureBox pictureBox = new PictureBox();
            Shop shop1 = new Shop(pictureBox,0,40);
            Shop shop2 = new Shop(pictureBox,0,40);
            Shop shop3 = new Shop(pictureBox,0,40);
            //make 3 statistics for shops in the same time for all three shops
            StatisticsShop temp1 = new StatisticsShop(1, shop1, shop1.Stock, 0, null);
            StatisticsShop temp2 = new StatisticsShop(1, shop2, shop2.Stock, 0, temp1);
            StatisticsShop temp3 = new StatisticsShop(1, shop3, shop3.Stock, 0, temp2);



            Assert.Equal(3, temp3.calculateZeroStockTime());
           

        }

        [Fact()]
        public void AverageStock()
        {
            //initialize 3 shops with 0 stock
            PictureBox pictureBox = new PictureBox();
            Shop shop1 = new Shop(pictureBox, 10, 40);
            Shop shop2 = new Shop(pictureBox, 10, 40);
            Shop shop3 = new Shop(pictureBox, 10, 40);
            //make 3 statistics for shops in the same time for all three shops
            StatisticsShop temp1 = new StatisticsShop(1, shop1, shop1.Stock, 0, null);
            StatisticsShop temp2 = new StatisticsShop(1, shop2, shop2.Stock, 0, temp1);
            StatisticsShop temp3 = new StatisticsShop(1, shop3, shop3.Stock, 0, temp2);



            Assert.Equal(10, temp3.calculateAverageStock());


        }

        [Fact()]
        public void AverageSold()
        {
            //initialize 3 shops with 0 stock
            PictureBox pictureBox = new PictureBox();
            Shop shop1 = new Shop(pictureBox, 20, 40);
            Shop shop2 = new Shop(pictureBox, 20, 40);
            Shop shop3 = new Shop(pictureBox, 20, 40);
            //make 3 statistics for shops in the same time for all three shops
            StatisticsShop temp1 = new StatisticsShop(1, shop1, shop1.Stock, 20, null);
            StatisticsShop temp2 = new StatisticsShop(1, shop2, shop2.Stock, 20, temp1);
            StatisticsShop temp3 = new StatisticsShop(1, shop3, shop3.Stock, 20, temp2);



            Assert.Equal(20, temp3.calculateAverageSold());


        }
    }
}

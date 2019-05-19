using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Cell
    {
        //Drawing fields
        public Color CellColor = Color.Black;
        public int CellLineWidth = 1;


        //Cell fields
        private static int maxDemand = 0; 
        private static int maxDemandGrow = 0;
        private static Random rand = new Random();

        private int demand; //Current demand of the cell
        private int demandGrow; //Demand grow per tick
        private List<ShopRadius> shopRadiuses = new List<ShopRadius>(); 

        public static int MaxDemand { get { return maxDemand; } }
        public static int MaxDemandGrow { get { return maxDemandGrow;  } }
        public int Demand { get { return this.demand; } }
        public int DemandGrow { get { return this.demandGrow; } }
        public static int CellSize { get; set; }
        public Index Index { get; set; }

        public Rectangle CellRectangle;

        public Cell(int columnNumber, int rowNumber, int demand)
        {
            Index = new Index(columnNumber, rowNumber);
            CellRectangle = new Rectangle(new Point(Index.Column * CellSize, Index.Row * CellSize), new Size(CellSize, CellSize));
            SetDemandGrow(demand);
        }
        public Cell(int columnNumber, int rowNumber) : this(columnNumber, rowNumber, 0)
        { }

        public void AddShopRadius(Shop s, int DemandPercentage) 
        {
            ShopRadius temp = new ShopRadius(s, DemandPercentage);
            foreach (ShopRadius sr in shopRadiuses)
            {
                if (sr.Shop == s)
                {
                    return;
                }
            }
            shopRadiuses.Add(temp);
        }
        public void RemoveShopRadius(Shop s) 
        {
            foreach(ShopRadius sr in shopRadiuses)
            {
                if(sr.Shop == s)
                {
                    shopRadiuses.Remove(sr);
                    break;
                }
            }
        }
        public void NextTick() 
        {
            //BUY FROM SHOPS
            List<ShopRadius> temp = new List<ShopRadius>();
            foreach(ShopRadius sr in shopRadiuses)
            {
                temp.Add(sr);
            }
            while(temp.Count > 0)
            {
                int r = rand.Next(0, temp.Count);
                demand -= temp[r].BuyFromShop(demand);
                temp.RemoveAt(r);
            }

            //APPLY DEMAND GROW
            demand += DemandGrow;
            if(demand > maxDemand)
            {
                maxDemand = demand;
            }
        }
        public virtual void ResetDrawFields()
        {
            CellColor = Color.Black;
            CellLineWidth = 1;
        }
        /// <summary>
        /// Set the demandGrow and demand of this cell
        /// </summary>
        /// <param name="Demand"></param>
        public void SetDemandGrow(int Demand)
        {
            this.demand = Demand;
            this.demandGrow = Demand;
            if(Demand > maxDemand)
            {
                maxDemand = Demand;
            }
            if(Demand > maxDemandGrow)
            {
                maxDemandGrow = Demand;
            }
        }
        
        /// <summary>
        ///     Get the HeatMap color of this cell
        /// </summary>
        /// <returns></returns>
        public Color GetHeatMapCellColor() 
        {
            double maxPercentage = (double)this.demand / maxDemand;
            Color heatColor;
            if(maxPercentage > 1)
            {
                throw new Exception("Percentage > 1 is not allowed");
            }
            if(maxPercentage >= 0.5) //green
            {
                double otherColors = 255 - Math.Floor((maxPercentage - 0.5) * 2 * 255); 
                heatColor = Color.FromArgb((int)otherColors, 255, (int)otherColors);
            }
            else if(maxPercentage >= 0) //red
            {
                double otherColors = 255 - Math.Floor((0.5 - maxPercentage) * 2 * 255);
                heatColor = Color.FromArgb(255, (int) otherColors, (int)otherColors);
            }
            else
            {
                throw new Exception("Negative percentage is not allowed");
            }
             
            return heatColor;
        }
    }
}

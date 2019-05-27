using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary
{
    public class Cell
    {
        //public int Id { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int Demand { get; set; }
        public int DemandGrowthPerTick { get; set; }

        //// Foreign Key
        public int MapId { get; set; }
        //public Map Map { get; set; }

        //Drawing fields
        [NotMapped]
        public Color CellColor = Color.Black;
        [NotMapped]
        public int CellLineWidth = 1;
        //Cell fields
        [NotMapped]
        private static int maxDemand = 0;
        [NotMapped]
        private static int maxDemandGrow = 0;
        [NotMapped]
        private static Random rand = new Random();
        [NotMapped]
        private List<ShopRadius> shopRadiuses = new List<ShopRadius>();
        [NotMapped]
        public static int MaxDemand { get { return maxDemand; } }
        [NotMapped]
        public static int MaxDemandGrow { get { return maxDemandGrow;  } }
        [NotMapped]
        public static int CellSize { get; set; }
        [NotMapped]
        public Index Index { get; set; }
        [NotMapped]
        public Rectangle CellRectangle;

        public Cell()
        { }

        public Cell(int columnNumber, int rowNumber, int demand)
        {
            Index = new Index(columnNumber, rowNumber);
            CellRectangle = new Rectangle(new Point(Index.Column * CellSize, Index.Row * CellSize), new Size(CellSize, CellSize));
            SetDemandGrow(demand);
            RowIndex = rowNumber;
            ColumnIndex = columnNumber;
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
        public void NextTick(int timeStamp) 
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
                Demand -= temp[r].BuyFromShop(Demand);
                temp.RemoveAt(r);
            }

            //APPLY DEMAND GROW
            Demand += DemandGrowthPerTick;
            if(Demand > maxDemand)
            {
                maxDemand = Demand;
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
        /// <param name="demand"></param>
        public void SetDemandGrow(int demand)
        {
            if(demand < 0) { throw new Exception("Demand must be greater than or equal to 0"); }
            Demand = demand;
            DemandGrowthPerTick = demand;

            if (demand > maxDemand)
            {
                maxDemand = demand;
            }
            if(demand > maxDemandGrow)
            {
                maxDemandGrow = demand;
            }
        }
        
        /// <summary>
        ///     Get the HeatMap color of this cell
        /// </summary>
        /// <returns></returns>
        public Color GetHeatMapCellColor() 
        {
            double maxPercentage = (double)this.Demand / maxDemand;
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

        public override string ToString()
        {
            return $"(r: {RowIndex}, c: {ColumnIndex})";
        }
    }
}

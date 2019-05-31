using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
	public abstract class Building
    {
        public PictureBox picBox; //picturebox that contains a picture of Warehouse or Shop
        public Building(PictureBox PicBox)
        {
            picBox = PicBox;
        }
        public Building()
        {
            
        }

        public abstract void Save(int mapId, int rowIndex, int columnIndex);

        public void Delete(int mapId, int rowIndex, int columnIndex)
        {
            string sql = "DELETE FROM BUILDINGS" +
                        $"WHERE MapId = '{mapId}'" +
                        $"AND RowIndex = '{rowIndex}'" +
                        $"AND ColumnIndex = '{columnIndex}';";
            Console.WriteLine("Deleting a Building");
            DataBase.ExecuteNonQuery(sql);
        }

        public static void DeleteAll(int mapId)
        {
            string sql = "DELETE FROM BUILDINGS" +
                        $" WHERE MapId = '{mapId}';";
            DataBase.ExecuteNonQuery(sql);
        }
	}
}

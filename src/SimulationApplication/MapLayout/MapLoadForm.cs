using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MapLayout
{
    public partial class MapLoadForm : Form
    {
        public MapLoadForm()
        {
            InitializeComponent();
            DisplayAvailableMaps();
        }

        private void DisplayAvailableMaps()
        {
            // Call a static method that will show all maps from db.
            string sql = "SELECT * FROM MAPS;";
            MySqlDataReader reader = DataBase.ExecuteReader(sql);
            try
            {
                while (reader.Read())
                {
                    LoadMapRecord record = new LoadMapRecord(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2]));
                    availableMapsListBox.Items.Add(record);
                }
            }
            catch (Exception ex)
            {
                DataBase.CloseConnection();
                Console.WriteLine(ex.Message);
            } 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для ThirdWindow.xaml
    /// </summary>
    public partial class ThirdWindow : Window
    {
        DBConnection db = new DBConnection();
        public ThirdWindow()
        {
            InitializeComponent();
        }

        private void Grid_Initialized(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            var currentDate = DateTime.Now;
            DataTable table = new DataTable();

            string request = $"SELECT Name_Event FROM Events WHERE Date_Event={currentDate.ToString("yyyy/mm/dd")}";
            
            SqlCommand comm = new SqlCommand(request, db.GetConnection());

            adapter.SelectCommand = comm;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                int a;
            }
        }
    }
}

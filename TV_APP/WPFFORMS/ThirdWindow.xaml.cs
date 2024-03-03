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
        //DBConnection db = new DBConnection();
        public ThirdWindow()
        {
            InitializeComponent();
        }

        private void Grid_Initialized(object sender, EventArgs e)
        {
            /*using (var db = new TVContext())
            {
                db.Configuration.ProxyCreationEnabled = false;

                var currentDate = DateTime.Now.ToString("yyyyMMdd");
                var found = db.Events.Any(x => x.Date_Event == currentDate);
                if (found)
                {

                    var eventName = db.Events.Where(x => x.Date_Event == currentDate);

                    newsLabel.Content = eventName.Select(x => x.Name_Event);
                }
                
            }
            /*
            db.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter();

            var currentDate = DateTime.Now;
            DataTable table = new DataTable();

            string request = $"SELECT Name_Event FROM Events WHERE Date_Event={currentDate.ToString("yyyyMMdd")}";
            
            SqlCommand comm = new SqlCommand(request, db.GetConnection());

            adapter.SelectCommand = comm;

            adapter.Fill(table);

            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                if (table.Rows.Count > 0)
                {
                    newsLabel.Content = reader["Name_Event"].ToString();
                }
            }

            db.CloseConnection();*/
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}

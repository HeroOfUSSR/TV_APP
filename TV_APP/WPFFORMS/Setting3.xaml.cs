using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
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
using System.Drawing;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для Setting3.xaml
    /// </summary>
    public partial class Setting3 : Window
    {
        DBConnection db = new DBConnection();

        static readonly ImageSourceConverter imageSourceConverter
            = new ImageSourceConverter();

        public Setting3()
        {
            InitializeComponent();
        }

        public void imageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.BMP; *.JPEG; *.PNG; *.TIFF)|*.BMP; *.JPEG; *.PNG; *.TIFF";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            imagePreview.Source = (ImageSource)imageSourceConverter.ConvertFrom(new Uri(openFileDialog.FileName));

           BitmapImage bitmapImage = openFileDialog;
        }

        private void imageButton2_Click(object sender, RoutedEventArgs e)
        {
            var eventName = nameEventTextbox.Text;
            var eventDate = dateEventPicker.SelectedDate;


            var eventImage = BufferFromImage(imagePreview.Source);
            db.OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter();

            var currentDate = DateTime.Now;
            DataTable table = new DataTable();

            string request = $"INSERT INTO Events (Name_Event, Date_Event, Picture_Event) VALUES () Events WHERE Date_Event={currentDate.ToString("yyyyMMdd")}";

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

            db.CloseConnection();
        }

        public byte[] BufferFromImage(BitmapImage imageSource)
        {
            Stream stream = imageSource.StreamSource;
            byte[] buffer = null;

            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }

            return buffer;
        }
    }
}

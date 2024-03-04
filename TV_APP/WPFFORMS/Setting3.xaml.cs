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
using TV_APP_Context.DBContext;
using TV_APP_Context.Models;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для Setting3.xaml
    /// </summary>
    public partial class Setting3 : Page
    {
        //DBConnection db = new DBConnection();

        static readonly ImageSourceConverter imageSourceConverter
            = new ImageSourceConverter();

        public Setting3()
        {
            InitializeComponent();
        }

        public void imageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.BMP; *.JPEG; *.PNG; *.TIFF; *.JPG)|*.BMP; *.JPEG; *.PNG; *.TIFF; *.JPG";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            imagePreview.Source = (ImageSource)imageSourceConverter.ConvertFrom(new Uri(openFileDialog.FileName));
        }

        private void imageButton2_Click(object sender, RoutedEventArgs e)
        {
            var newDate = dateEventPicker.SelectedDate;

            JpegBitmapEncoder encoderJpeg = new JpegBitmapEncoder();

            var eventImage = ImageSourceToBytes(encoderJpeg, imagePreview.Source);

            using (var db = new TV_dbContext())
            {
                Event newEvent = new Event
                {
                    NameEvent = nameEventTextbox.Text,
                    DateEvent = $"{newDate:yyyyMMdd}",
                    PictureEvent = eventImage,
            };
                db.Events.Add(newEvent);
                db.SaveChanges();
            }

            MessageBox.Show("Событие добавлено в базу данных", "Успешно", MessageBoxButton.OK);
        }

        public static byte[] ImageSourceToBytes(BitmapEncoder encoder, ImageSource imageSource)
        {
            byte[] bytes = null;
            var bitmapSource = imageSource as BitmapSource;

            if (bitmapSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    bytes = stream.ToArray();
                }
            }

            return bytes;
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TV_APP_Context.DBContext;
using TV_APP_Context.Models;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для Setting4.xaml
    /// </summary>
    public partial class Setting4 : Page
    {
        static readonly ImageSourceConverter imageSourceConverter
            = new ImageSourceConverter();
        public Setting4()
        {
            InitializeComponent();
        }

        private void imageButton2_Click(object sender, RoutedEventArgs e)
        {
            JpegBitmapEncoder encoderJpeg = new JpegBitmapEncoder();

            var factImage = Setting3.ImageSourceToBytes(encoderJpeg, imagePreview.Source);

            using (var db = new TV_dbContext())
            {
                Fact newFact = new Fact
                {
                    TitleFact = nameTextbox.Text,
                    DescFact = descTextbox.Text,
                    PictureFact = factImage
                };
                db.Facts.Add(newFact);
                db.SaveChanges();
            }

            MessageBox.Show("Запись добавлена в базу данных", "Успешно", MessageBoxButton.OK);
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.BMP; *.JPEG; *.PNG; *.TIFF; *.JPG)|*.BMP; *.JPEG; *.PNG; *.TIFF; *.JPG";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            imagePreview.Source = (ImageSource)imageSourceConverter.ConvertFrom(new Uri(openFileDialog.FileName));
        }
    }
}

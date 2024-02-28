using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для Setting3.xaml
    /// </summary>
    public partial class Setting3 : Window
    {

        static readonly ImageSourceConverter imageSourceConverter
            = new ImageSourceConverter();

        public Setting3()
        {
            InitializeComponent();
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.BMP; *.JPEG; *.PNG; *.TIFF)|*.BMP; *.JPEG; *.PNG; *.TIFF";
            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            imagePreview.Source = (ImageSource)imageSourceConverter.ConvertFrom(new Uri(openFileDialog.FileName));
        }
    }
}

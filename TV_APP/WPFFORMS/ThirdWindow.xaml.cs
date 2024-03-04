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
using TV_APP_Context.DBContext;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для ThirdWindow.xaml
    /// </summary>
    public partial class ThirdWindow : Window
    {
        static readonly ImageSourceConverter imageSourceConverter
            = new ImageSourceConverter();
        public ThirdWindow()
        {
            InitializeComponent();
        }

        private void Grid_Initialized(object sender, EventArgs e)
        {
            using (var db = new TV_dbContext())
            {

                var currentDate = DateTime.Now.ToString("yyyyMMdd");
                var found = db.Events.Any(x => x.DateEvent == currentDate);

                if (found)
                {
                    var eventName = db.Events.FirstOrDefault(x => x.DateEvent == currentDate);
                    newsLabel.Content = eventName.NameEvent;

                    if (eventName.PictureEvent != null)
                    {
                        newsImage.Source = (ImageSource)imageSourceConverter.ConvertFrom(eventName.PictureEvent);
                    }

                }
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var openSet = new SecondWindow();

            var settings = new Settings(openSet.Mypleer);
            settings.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

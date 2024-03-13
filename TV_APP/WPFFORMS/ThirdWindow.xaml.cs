using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
                var cultureInfo = new CultureInfo("ru-RU");
                var found = db.Events.Any(x => x.DateEvent == currentDate);

                Random random = new Random();

                var factRandom = random.Next(1, db.Facts.Max(x => x.IdFact));

                var factForDisplay = db.Facts.First(x => x.IdFact >= factRandom);


                factLabel.Text = factForDisplay.TitleFact;
                descLabel.Text = factForDisplay.DescFact;

                if (factForDisplay.PictureFact != null)
                {
                    factImage.Source = (ImageSource)imageSourceConverter.ConvertFrom(factForDisplay.PictureFact);
                }

                if (found)
                {
                    var eventName = db.Events.FirstOrDefault(x => x.DateEvent == currentDate);
                    newsLabel.Text = eventName.NameEvent;
                    dateLabel.Text = DateTime.ParseExact(eventName.DateEvent, "yyyyMMdd", null).ToString("dd MMMM");

                    if (eventName.PictureEvent != null)
                    {
                        newsImage.Source = (ImageSource)imageSourceConverter.ConvertFrom(eventName.PictureEvent);
                    }
                }
                else
                {
                    factRandom = random.Next(1, db.Facts.Max(x => x.IdFact));

                    factForDisplay = db.Facts.First(x => x.IdFact >= factRandom);


                    newsLabel.Text = factForDisplay.TitleFact;
                    dateLabel.Text = factForDisplay.DescFact;

                    if (factForDisplay.PictureFact != null)
                    {
                        newsImage.Source = (ImageSource)imageSourceConverter.ConvertFrom(factForDisplay.PictureFact);
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

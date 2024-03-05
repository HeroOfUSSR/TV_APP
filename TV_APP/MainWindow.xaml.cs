using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TV_APP.WPFFORMS;

namespace TV_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        public MainWindow()
        {
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                currentTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
                currentDateLabel.Content = DateTime.Now.ToString("dddd");
            }, Dispatcher);
        }

        private async void Grid_Initialized(object sender, EventArgs e)
        {
            var API_key = "ff1bad88f9167a7ca73c31ccdc382666";
            var lon = "30.2642";
            var lat = "59.8944";

            WebRequest request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API_key}&units=metric");

            request.Method = "POST";

            request.ContentType = "application/x-www-urlencoded";

            WebResponse response = await request.GetResponseAsync();

            string answer = string.Empty;

            using(Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s)) 
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            response.Close();

            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

            tempCurrentLabel.Content = $"{oW.main.temp}°C";

            //string filePath = $"C:/Users/student_orit/source/repos/TV_APP/TV_APP/Icons/{oW.weather[0].icon}.svg";
            //    //{oW.weather[0].icon}.svg";

            //using (StreamReader stream = new StreamReader(filePath))
            //{
            //    weatherImage.StreamSource = stream.BaseStream;
            //}

        }

        private void richText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newForm = new SecondWindow();
            newForm.Show();
        }

        
    }
}
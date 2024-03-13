using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TV_APP.WPFFORMS;
using TV_APP_Context.DBContext;

namespace TV_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public DispatcherTimer _timer;
        public MainWindow()
        {
            InitializeComponent();

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

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            response.Close();

            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

            tempCurrentLabel.Content = $"{Math.Round(oW.main.temp)}°C";

            string filePath = $"Icons/{oW.weather[0].icon}.svg";
            //{oW.weather[0].icon}.svg";

            using (StreamReader stream = new StreamReader(filePath))
            {
                weatherImage.StreamSource = stream.BaseStream;
            }
           
        }

        private void richText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var gigaNext = new GigaWindow();

            gigaNext.GigaFrame.Content = new SecondWindow();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            var gigaNext = new GigaWindow();

            gigaNext.GigaFrame.Content = new ThirdWindow();
        }
    }
}
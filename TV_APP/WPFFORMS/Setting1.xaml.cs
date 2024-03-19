using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TV_APP.OpenWeather;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для Setting1.xaml
    /// </summary>
    public partial class Setting1 : Page
    {
        public static string inputButton;
        public Setting1()
        {
            InitializeComponent();

            slide1.Text = Properties.Settings.Default.t1;
            slide2.Text = Properties.Settings.Default.t2;
            slide3.Text = Properties.Settings.Default.t3;
            GigaWindow.timerValue1 = Convert.ToInt32(slide1.Text);
            GigaWindow.timerValue2 = Convert.ToInt32(slide2.Text);
            GigaWindow.timerValue3 = Convert.ToInt32(slide3.Text);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.t1 = slide1.Text;
            Properties.Settings.Default.t2 = slide2.Text;
            Properties.Settings.Default.t3 = slide3.Text;
            Properties.Settings.Default.Save();

            GigaWindow.timerValue1 = Convert.ToInt32(slide1.Text);
            GigaWindow.timerValue2 = Convert.ToInt32(slide2.Text);
            GigaWindow.timerValue3 = Convert.ToInt32(slide3.Text);

            inputButton = hotkey.Text;
        }

    }
}

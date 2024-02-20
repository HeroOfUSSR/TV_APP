using System.Windows;
using TV_APP.WPFFORMS;

namespace TV_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow  secondWindow = new SecondWindow();
            secondWindow.Show();    
        }
    }
}
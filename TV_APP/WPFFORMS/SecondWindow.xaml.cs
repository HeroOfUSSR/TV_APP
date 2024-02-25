using System.Windows;
using System.Windows.Controls;


namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
       


            InitializeComponent();
            Mypleer.Play();

            Setting setting = new Setting(Mypleer);
            setting.Show();

        }

        

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting(Mypleer);
            setting.ShowDialog();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
          Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

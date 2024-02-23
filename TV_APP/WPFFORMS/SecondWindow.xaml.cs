using System.Windows;


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
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

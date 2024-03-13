using System.Windows;
using System.Windows.Controls;


namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Page
    {
       // private Setting setting;
        private Setting2 setting; 

        public SecondWindow()
        {
            InitializeComponent();
            setting = new Setting2(Mypleer);

            Settings settings = new Settings(Mypleer);
            settings.Show();

        }

        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Settings setting = new Settings(Mypleer);
            setting.ShowDialog();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
          Application.Current.Shutdown();
        }

        
        private void Mypleer_MediaEnded(object sender, RoutedEventArgs e)
        {
            var count = setting.VideoList.Items.Count;
            var index= setting.VideoList.SelectedIndex;
            if (index+1>=count)
            {
                index = -1;
            }
            setting.VideoList.SelectedIndex = index+1;
            setting.mediaElement.Play();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            var gigaNext = new GigaWindow();

            gigaNext.GigaFrame.Content = new MainWindow();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var gigaNext = new GigaWindow();

            gigaNext.GigaFrame.Content = new ThirdWindow();
        }
    }
}

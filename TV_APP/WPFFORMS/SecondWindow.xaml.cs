using System.Windows;
using System.Windows.Controls;
using TV_APP_Context.DBContext;


namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Page
    {
       // private Setting setting;
        private Setting2 setting;
        private int index;
        public SecondWindow()
        {
            InitializeComponent();
            setting = new Setting2(Mypleer);

            /*Settings settings = new Settings(Mypleer);
            settings.Show();*/

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
            /*
            var count = setting.VideoList.Items.Count;
            index = setting.VideoList.SelectedIndex;

            if (index<count)
            {
                setting.VideoList.SelectedIndex = index + 1;
            }

            setting.mediaElement.Play();
            setting.PlayVideo();*/
            var count = setting.VideoList.Items.Count;
            var index = setting.VideoList.SelectedIndex;
            if (index + 1 >= count)
            {
                index = -1;
            }
            setting.VideoList.SelectedIndex = index + 1;
            setting.mediaElement.Play();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
 
            index = setting.VideoList.SelectedIndex;
            setting.mediaElement.Play();
        }
    }
}

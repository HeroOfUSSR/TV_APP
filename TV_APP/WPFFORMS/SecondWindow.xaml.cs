using System.Windows;
using System.Windows.Controls;


namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private Setting setting;


        public SecondWindow()
        {
       


            InitializeComponent();
            setting = new Setting(Mypleer);
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

        
        private void Mypleer_MediaEnded(object sender, RoutedEventArgs e)
        {
            var count = setting.VideoList.Items.Count;
            var index= setting.VideoList.SelectedIndex;
            if (index+1>=count)
            {
                index = -1;
            }
            setting.VideoList.SelectedIndex = index+1;
         
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new ThirdWindow();
            newForm.Show();
        }
    }
}

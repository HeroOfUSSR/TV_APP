using System.Windows;
using System.Windows.Controls;
using TV_APP_Context.DBContext;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private Setting2 setting; 

        public SecondWindow()
        {
            setting = new Setting2(Mypleer);
            InitializeComponent();
            //DefaultVideo();
            //StartPlay();
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
        
        private void StartPlay()
        {
            setting.VideoList.SelectedIndex = 0;
            string mediaPath = setting.VideoList.SelectedItem.ToString();
            setting.mediaElement.Source = (new Uri(mediaPath));
            setting.mediaElement.Play();
        }

        private void DefaultVideo()
        {
            using (var db = new TV_dbContext())
            {
                if (!db.Videos.Any())
                {
                    MessageBox.Show("В базе данных отсутствуют видеоролики", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                else
                {
                    var count = db.Videos.Count();

                    for (int i = 0; i < count; i++)
                    {
                        setting.VideoList.SelectedIndex = i;

                        //byte[] mediaPath = File.ReadAllBytes(VideoList.SelectedItem.ToString());

                        var byteVideo = db.Videos.FirstOrDefault(x => x.IdVideo == i);

                        var addVideo = byteVideo.SourceVideo;

                        setting.VideoList.Items.Add(addVideo);

                    }
                }
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new ThirdWindow();
            newForm.Show();
        }
    }
}

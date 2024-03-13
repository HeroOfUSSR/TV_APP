using Microsoft.Win32;
using System.IO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TV_APP_Context.DBContext;
using TV_APP_Context.Models;
using System.Xml.Linq;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting2 : Page
    {
        //DBConnection db = new DBConnection();
        public MediaElement mediaElement { get; set;}

        public Setting2(MediaElement mediaElement)
        {
            InitializeComponent();
            this.mediaElement = mediaElement;

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VideoList.Items.RemoveAt(VideoList.SelectedIndex);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.avi;*.mp4;*.wmv)|*.avi;*.mp4;*.wmv";
           if (openFileDialog.ShowDialog() == false)
            {
                return;
            }
            mediaElement.Source = new Uri(openFileDialog.FileName);
            mediaElement.Play();
          
            var name = openFileDialog.FileName;
            VideoList.Items.Add(name);


        }

    

        private void VideoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            mediaElement.Stop();
            if (VideoList.SelectedItem == null)
            {
                return;
            }

            string mediaPath = VideoList.SelectedItem.ToString();
            mediaElement.Source = (new Uri(mediaPath));
            mediaElement.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (VideoList.Items.Count == 0)
            { 
                return;
            }
            else
            {
                var count = VideoList.Items.Count;

                for (int i = 0; i < count; i++)
                {
                    VideoList.SelectedIndex = i;

                    //byte[] mediaPath = File.ReadAllBytes(new Uri(VideoList.SelectedItem.ToString()));

                    string mediaPath = VideoList.SelectedItem.ToString();

                    //byte[] mediaPath = StreamFile(VideoList.SelectedItem.ToString());

                    using (var db = new TV_dbContext())
                    {
                        Video newVideo = new Video
                        {
                            IdVideo = i,
                            SourceVideo = mediaPath,
                        };

                        db.Videos.Add(newVideo);
                        db.SaveChanges();
                    }
                }
                MessageBox.Show("Плейлист загружен в базу данных", "Успешно", MessageBoxButton.OK);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
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
                        VideoList.SelectedIndex = i;

                        //byte[] mediaPath = File.ReadAllBytes(VideoList.SelectedItem.ToString());

                        var byteVideo = db.Videos.FirstOrDefault(x => x.IdVideo == i);

                        var addVideo = byteVideo.SourceVideo;

                        VideoList.Items.Add(addVideo);

                    }
                }
                MessageBox.Show("Плейлист из базы данных загружен", "Успешно", MessageBoxButton.OK);
            }
        }

        private byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            byte[] ImageData = new byte[fs.Length];

            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            fs.Close();
            return ImageData; 
        }

        Uri ByteArrToUri(byte[] arr)
        {
            return new Uri(Encoding.UTF8.GetString(arr));
        }
    }
}

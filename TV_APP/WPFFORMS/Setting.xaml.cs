using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public MediaElement mediaElement { get; set;}

        public Setting(MediaElement mediaElement)
        {
            InitializeComponent();
            this.mediaElement = mediaElement;  
           
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            VideoList.Items.Remove(VideoList.SelectedItem);
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
            ListBoxItem item = new ListBoxItem();
            var name = openFileDialog.FileName;
            item.Content = name;
            VideoList.Items.Add(item);


        }

        private void VideoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

          mediaElement.Stop();
          string mediaPath = ((ListBoxItem)VideoList.SelectedValue).Content.ToString();
          mediaElement.Source = (new Uri(mediaPath));
          mediaElement.Play();
        }
    }
}

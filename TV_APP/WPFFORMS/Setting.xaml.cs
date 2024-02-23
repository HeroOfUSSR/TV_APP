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
        public Setting()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            VideoList.Items.Remove(VideoList.SelectedItem);
        }

     

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
          
                fd.Filter = "MP3 Files (*.mp3)|*.mp3|MP4 File (*.mp4)|*.mp4|3GP File (*.3gp)|*.3gp|Audio File (*.wma)|*.wma|MOV File (*.mov)|*.mov|AVI File (*.avi)|*.avi|Flash Video(*.flv)|*.flv|Video File (*.wmv)|*.wmv|MPEG-2 File (*.mpeg)|*.mpeg|WebM Video (*.webm)|*.webm|All files (*.*)|*.*";
        
                fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
             
                fd.ShowDialog();
               
                string filename = fd.FileName;
                VideoList.Items.Add(filename);

            }
            catch (Exception e1)
            {
                System.Console.WriteLine("Error Text: " + e1.Message);
            }

            
        }
    }
}

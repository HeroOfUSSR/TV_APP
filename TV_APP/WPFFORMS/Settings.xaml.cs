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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        List<Page> forFrame = new List<Page>();

        public Settings(MediaElement player)
        {
            InitializeComponent();


            forFrame.Add(new Setting(player));
            //this.forFrame=new List<Page>();
            forFrame.Add(new Setting3());

            forFrame.Add(new Setting1());


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OptionFrame.Content = forFrame[2];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OptionFrame.Content = forFrame[0];
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OptionFrame.Content = forFrame[1];
        }
    }
}

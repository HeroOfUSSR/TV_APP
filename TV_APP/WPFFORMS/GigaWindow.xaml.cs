using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    /// Логика взаимодействия для GigaWindow.xaml
    /// </summary>
    public partial class GigaWindow : Window
    {
        public List<Page> windows { get; set; }
        public GigaWindow()
        {
            InitializeComponent();

            var test1 = new MainWindow();
            var test2 = new SecondWindow();
            var test3 = new ThirdWindow();

            windows = new List<Page>();

            windows.Add(test1);
            windows.Add(test2);
            windows.Add(test3);

            GigaFrame.Content = windows[0];

            var chepuha = new Setting1();

            if (chepuha.changeWindow == true)
            {
                GigaFrame.Content = windows[chepuha.index];
            }

            
        }
    }
}

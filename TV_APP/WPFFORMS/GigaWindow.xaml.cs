using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
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
        List<Page> gigaList = new List<Page>();

        public Setting1 options = new Setting1();

        public GigaWindow()
        {
            InitializeComponent();

            options.PageChanged += OnPageChanged;
            
        }

        public void OnPageChanged(object source, EventArgs e)
        {
            GigaFrame.Content = gigaList[options.index];
            options.changeWindow = !options.changeWindow;
        }

        private void Grid_Initialized(object sender, EventArgs e)
        {
            gigaList.Add(new MainWindow());
            gigaList.Add(new SecondWindow());
            gigaList.Add(new ThirdWindow());
            GigaFrame.Content = gigaList[2];
        }
    }
}

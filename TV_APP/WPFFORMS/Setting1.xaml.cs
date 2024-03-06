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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для Setting1.xaml
    /// </summary>
    public partial class Setting1 : Page
    {
        public DispatcherTimer Timer { get; set; }
        public List<TextBox> textBoxes { get; set; }

        private int index = 0;

        public Setting1()
        {
            InitializeComponent();


            texb1.Text = Properties.Settings.Default.t1;
            texb2.Text = Properties.Settings.Default.t2;
            texb3.Text = Properties.Settings.Default.t3;

            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromSeconds(1);

            textBoxes = new List<TextBox>();

            foreach (var item in LogicalTreeHelper.GetChildren(grid))
            {
                if (item is TextBox textBox)
                {
                    textBoxes.Add(textBox);
                }

            }

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (int.TryParse(textBoxes[index].Text, out var sec))
            {
                sec--;
                textBoxes[index].Text = sec.ToString();

                if (sec <= 0)
                {
                    index++;

                }
                if (index >= textBoxes.Count)
                {
                    Timer.Stop();

                    index = 0;

                    texb1.Text = Properties.Settings.Default.t1;
                    texb2.Text = Properties.Settings.Default.t2;
                    texb3.Text = Properties.Settings.Default.t3;


                    Timer.Start();
                }
               
            }
  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();

            Properties.Settings.Default.t1 = texb1.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.t2 = texb2.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.t3 = texb3.Text;
            Properties.Settings.Default.Save();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
        }
    }
}

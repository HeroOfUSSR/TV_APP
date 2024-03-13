using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TV_APP.OpenWeather;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для Setting1.xaml
    /// </summary>
    public partial class Setting1 : Page
    {
        public DispatcherTimer Timer { get; set; }
        public List<TextBox> textBoxes { get; set; }
        public List<Window> windows { get; set; }   

       
        private int index = 0;

        
        public Setting1()
        {
            InitializeComponent();

            var test1 = new MainWindow();
            var test2 = new SecondWindow();
            var test3 = new ThirdWindow();

            windows= new List<Window>();

            windows.Add(test1);
            windows.Add(test2);
            windows.Add(test3);

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
                    windows[index].Hide();

                    index++;

                   

                    if (index >= textBoxes.Count)
                    {
                        Timer.Stop();

                        index = 0;

                        texb1.Text = Properties.Settings.Default.t1;
                        texb2.Text = Properties.Settings.Default.t2;
                        texb3.Text = Properties.Settings.Default.t3;


                        Timer.Start();
                    }

                    windows[index].Show();
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

            if (index == 0)
            {
                windows[index].Show();
            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
        }

        private void texb1_TextChanged(object sender, TextChangedEventArgs e)
        {
           

        }
    }
}

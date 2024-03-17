using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;
using Key = System.Windows.Input.Key;

namespace TV_APP.WPFFORMS
{
    /// <summary>
    /// Логика взаимодействия для GigaWindow.xaml
    /// </summary>
    public partial class GigaWindow : Window
    {
        public static int timerValue1;
        public static int timerValue2;
        public static int timerValue3;
        public DispatcherTimer Timer { get; set; }

        List<Page> gigaList = new List<Page>();

        public int index = 0;

        private bool isTimer = false;

        private int timerTicking;

        public string hotkey = Setting1.inputButton;

        public GigaWindow()
        {
            InitializeComponent();

            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromSeconds(1);
        }


        public void Timer_Tick(object? sender, EventArgs e)
        {
            timerTicking--;

            if (timerTicking <= 0)
            {
                if (index<2) index++;
                else index = 0;

                GigaFrame.Content = gigaList[index];
                
                switch (index)
                {
                    case 0: timerTicking = timerValue1; break;
                    case 1: timerTicking = timerValue2; break;
                    case 2: timerTicking = timerValue3; break;
                }
                    
            }
        }

        public void GigaFrame_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

    private void Grid_Initialized(object sender, EventArgs e)
        {
            gigaList.Add(new MainWindow());
            gigaList.Add(new SecondWindow());
            gigaList.Add(new ThirdWindow());
            GigaFrame.Content = gigaList[index];
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //KeyConverter kCon = new KeyConverter();
            //Key thisKey = (Key)kCon.ConvertFrom(hotkey);

            if (e.Key == Key.Space)
            {
                isTimer = !isTimer;
                if (isTimer == true)
                {
                    switch (index)
                    {
                        case 0: timerTicking = timerValue1; break;
                        case 1: timerTicking = timerValue2; break;
                        case 2: timerTicking = timerValue3; break;
                    }

                    Timer.Start();
                }
                else Timer.Stop();
            }
        }

        private void OptionsClick(object sender, RoutedEventArgs e)
        {
            var openSet = new SecondWindow();

            var settings = new Settings(openSet.Mypleer);
            settings.Show();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {

        }

        private void PrevClick(object sender, RoutedEventArgs e)
        {

        }
    }
}

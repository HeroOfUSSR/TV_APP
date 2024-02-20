using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TV_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        public MainWindow()
        {
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                currentTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
                currentDateLabel.Content = DateTime.Now.ToString("dddd");
            }, Dispatcher);
            this.Loaded += new RoutedEventHandler(Clock_Loaded);
        }

        void Clock_Loaded(object sender, RoutedEventArgs e)
        {
            // set the datacontext to be today's date
            DateTime now = DateTime.Now;
            DataContext = now.Day.ToString();

            // then set up a timer to fire at the start of tomorrow, so that we can update
            // the datacontext
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(1, 0, 0, 0) - now.TimeOfDay;
            _timer.Tick += new EventHandler(OnDayChange);
            _timer.Start();

            // finally, seek the timeline, which assumes a beginning at midnight, to the appropriate
            // offset
            Storyboard sb = (Storyboard)PodClock.FindResource("sb");
            sb.Begin(PodClock, HandoffBehavior.SnapshotAndReplace, true);
            sb.Seek(PodClock, now.TimeOfDay, TimeSeekOrigin.BeginTime);
        }

        private void OnDayChange(object sender, EventArgs e)
        {
            // date has changed, update the datacontext to reflect today's date
            DateTime now = DateTime.Now;
            DataContext = now.Day.ToString();
            _timer.Interval = new TimeSpan(1, 0, 0, 0);
        }

    
    }
}
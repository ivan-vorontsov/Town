using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Town;
using Util;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly double WIDTH = 800;
        private static readonly double HEIGHT = 600;
        private static readonly int COLUMNS = 40;
        private static readonly int ROWS = 30;
        private static readonly double CAR_MX = 3;
        

        private readonly CanvasManager CM;
        private readonly Car car;
        private readonly Controller controller;

        Timer timer;
        DateTime previousTime;
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            MyCanvas.Width = WIDTH;
            MyCanvas.Height = HEIGHT;
            MyCanvas.Background = Brushes.Black;
            CM = CanvasManager.GetInstance();
            CM.SetSize(WIDTH, HEIGHT);
            CM.SetColumns(COLUMNS);
            CM.SetRows(ROWS);

            car = new Car(0,
                              0,
                              CM.GetXStep() * CAR_MX, Brushes.Blue);
            car.SetBlinking(true);
            CM.Add(car);
            var vehicle = new Vehicle_A(car);
            controller = new Controller(vehicle);
            timer = new Timer();
            timer.Interval = 1000 / 60;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            previousTime = DateTime.Now;

            this.KeyDown += MainWindow_KeyDown;

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
                controller.HandleRight();
            else if (e.Key == Key.Left)
                controller.HandleLeft();
            else if (e.Key == Key.Up)
                controller.HandleUp();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var currentTime = DateTime.Now;
            var delta = (currentTime - previousTime).TotalMilliseconds;
            previousTime = currentTime;
            delta /= 1000;

            try
            {
                Dispatcher.Invoke(() =>
                {
                    MyCanvas.Children.Clear();

                    car.Update(delta);
                    CM.Render(MyCanvas);
                });
            }
            catch { }
        }
    }
}

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
        private static readonly double CAR_MX = 0.5;

        private readonly CanvasManager CM;
        Car car;
        Car car2;
        Timer timer;
        DateTime previousTime;
        IList<IMultimoveabe> multimover;
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
            multimover = new List<IMultimoveabe>();

            var ringSquare = Ring.NewSquareRing(new Position(WIDTH / 2, HEIGHT / 2));
            var ringLShape = Ring.NewLShapeRing(new Position(100, 100), Brushes.Gray);
            var ringOShape = Ring.NewOShape(new Position(500, 500));

            CM.Add(ringSquare);
            CM.Add(ringLShape);
            CM.Add(ringOShape);

            car = new Car(0,
                              0,
                              CM.GetXStep() * 2, Brushes.Blue);
            car.SetBlinking(true);
            var light = new Light(0, 0, 10);
            var mover = new Mover(light);
            var circular = new Circular(mover);
            circular.GoRound(ringSquare);
            multimover.Add(circular);
            var directableMover = new DirectableMover(car);
            var directableCircular = new DirectableCircular(directableMover);
            directableCircular.GoRound(ringLShape);
            multimover.Add(directableCircular);

            car2 = new Car(0,
                              0,
                              CM.GetXStep() * 2, Brushes.Red);
            car2.SetBlinking(true);
            directableMover = new DirectableMover(car2);
            directableCircular = new DirectableCircular(directableMover);
            directableCircular.GoRound(ringOShape);
            multimover.Add(directableCircular);

            CM.Add(light);
            CM.Add(car);
            CM.Add(car2);
            timer = new Timer();
            timer.Interval = 1000 / 60;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            previousTime = DateTime.Now;
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
                    foreach (var x in multimover)
                    {
                        x.Update(delta);
                    }
                    car.Update(delta);
                    car2.Update(delta);
                    CM.Render(MyCanvas);
                });
            }
            catch { }
        }
    }
}

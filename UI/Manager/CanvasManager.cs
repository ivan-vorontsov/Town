using System;
using Util;

namespace Manager
{
    public class CanvasManager
    {
        private static readonly CanvasManager instance = new CanvasManager();
        private Size size;
        private int columns = 1;
        private int rows = 1;
        public static CanvasManager GetInstance()
        {
            return instance;
        }

        public List<IPaintable> Figures { get; } = new List<IPaintable>();

        public void Add(IPaintable figure)
        {
            Figures.Add(figure);
        }

        public double GetXStep()
        {
            return size.Width / columns;
        }

        public double GetYStep()
        {
            return size.Height / rows;
        }

        public void Remove(IMoveable figure)
        {
            Figures.Remove(figure);
        }

        public int GetColumns()
        {
            return columns;
        }

        public void SetColumns(int columns)
        {
            this.columns = columns;
        }

        public int GetRows()
        {
            return rows;
        }

        public void SetRows(int rows)
        {
            this.rows = rows;
        }

        public void Clear()
        {
            this.Figures.Clear();
        }

        public void SetSize(double x, double y)
        {
            this.size = new Size(x, y);
        }

        public void Render(Canvas canvas)
        {
            DrawGrid(canvas);
            foreach (var x in Figures) x.Paint(canvas);
        }

        private void DrawGrid(Canvas canvas)
        {
            for (double y = 0; y <= size.Height; y += GetYStep())
            {
                var line = new Line
                {
                    X1 = 0,
                    X2 = size.Width,
                    Y1 = 0,
                    Y2 = 0,
                    Stroke = Brushes.Yellow,
                    StrokeThickness = 1
                };
                Canvas.SetTop(line, y);
                Canvas.SetLeft(line, 0);
                canvas.Children.Add(line);
            }
            for (double x = 0; x <= size.Width; x += GetXStep())
            {
                var line = new Line
                {
                    X1 = 0,
                    X2 = 0,
                    Y1 = 0,
                    Y2 = size.Height,
                    Stroke = Brushes.Yellow,
                    StrokeThickness = 1
                };
                Canvas.SetLeft(line, x);
                Canvas.SetTop(line, 0);
                canvas.Children.Add(line);
            }
        }
    }
}

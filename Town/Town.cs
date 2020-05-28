using Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Town
{
    public class Town : IPaintable
    {
        private static readonly int COLUMN_COUNT = 10;
        private static readonly int ROW_COUNT = 10;
        private static readonly CanvasManager CM = CanvasManager.GetInstance();
        private static readonly Town SINGLETON = new Town(COLUMN_COUNT, ROW_COUNT);

        private double module = CM.GetXStep();

        private Component ground;
        private Component current;
        private int columnSize;
        private int rowSize;
        private int currentColumn;
        private int currentRow;

        public static Town GetInstance()
        {
            return SINGLETON;
        }

        private Town(int columnSize, int rowSize)
        {
            this.columnSize = columnSize;
            this.rowSize = rowSize;

            currentColumn = this.columnSize / 2;
            currentRow = this.rowSize / 2;

            ground = new Component
            {
                Subject = new Rectangle
                {
                    Width = 1,
                    Height = 1,
                    Fill = Brushes.Red
                },
                X = 0,
                Y = 0
            };
            current = new Component
            {
                Subject = new Rectangle
                {
                    Width = 1,
                    Height = 1,
                    Fill = Brushes.Green
                },
                X = 0,
                Y = 0
            };

            CM.Add(this);
        }

        public void SetCurrentAt(int column, int row)
        {
            currentColumn = column;
            currentRow = row;
        }

        public void Paint(Canvas canvas)
        {
            module = CM.GetXStep();
            int canvasColumns = CM.GetColumns();
            int canvasRows = CM.GetRows();
            int currColumn = canvasColumns / 2;
            int currRow = canvasRows / 2;
            double townX = (currColumn - currentColumn) * module;
            double townY = (currRow - currentRow) * module;
            ground.SetPostion(townX - module / 2, townY - module / 2);
            ground.SetSize(columnSize * module, rowSize * module);
            Canvas.SetLeft(ground.Subject, ground.X);
            Canvas.SetTop(ground.Subject, ground.Y);
            canvas.Children.Add(ground.Subject);

            current.SetPostion(currColumn * module - module / 2,
                                currRow * module - module / 2);
            current.SetSize(module, module);
            Canvas.SetLeft(current.Subject, current.X);
            Canvas.SetTop(current.Subject, current.Y);
            canvas.Children.Add(current.Subject);
        }
    }
}

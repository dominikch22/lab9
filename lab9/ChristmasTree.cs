using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    class ChristmasTree
    {
        public int X;
        public int Y;

        private Random Random;
        private Graphics Graphics;
        private PictureBox Canvas;
        private Bitmap Bitmap;


        public ChristmasTree(PictureBox canvas) {
            Canvas = canvas;
            Random = new Random();

            Bitmap = new Bitmap(canvas.Width, canvas.Height);
            Graphics = Graphics.FromImage(Bitmap);

        }

        public void drawTree(int x, int y) {
            DrawRectangle(x+350, 730, 100);
            DrawTriangle(x+200, 50, 300);
            DrawTriangle(x+150, 150, 400);
            DrawTriangle(x+100, 250, 500);

            DrawStart(x + 350, 60, 50, 7);

            DrawBaublesOnTree(100, 25);

            Canvas.Image = Bitmap;

        }

        public void DrawBaublesOnTree(int count, int size) {
            while (count > 0) {
                int x = Random.Next(Canvas.Width);
                int y = Random.Next(Canvas.Height);
                Point point = new Point(x, y);

                Color color = GetColorAtPoint(point);
                Color aa = Color.Green;
                if (color.ToArgb().Equals(Color.Green.ToArgb()))
                {
                    DrawBauble(x, y, size);
                    count--;
                }
            }
          
        }

        public void DrawBauble(int x, int y, int size) {
            Brush brush = new SolidBrush(Color.Red);
            Brush brushBlack = new SolidBrush(Color.Black);

            Graphics.FillRectangle(brushBlack, x, y, size/4, size/4);
            Graphics.FillEllipse(brush, x-size/2+2, y+size/5, size, size);


        }

        public void DrawRectangle(int x, int y, int length) {
            Brush fillBrush = new SolidBrush(Color.Brown);
            Rectangle rectangle = new Rectangle(x-length/2, y, length, length);

            Graphics.FillRectangle(fillBrush, rectangle);
        }

        public void DrawTriangle(int x, int y, int length)
        {
            Brush fillBrush = new SolidBrush(Color.Green);
            Point[] trianglePoints = {
                new Point(x, y + length),
                new Point(x + length / 2, y),
                new Point(x + length, y + length)
            };

            Graphics.FillPolygon(fillBrush, trianglePoints);

        }
        public Color GetColorAtPoint(Point point)
        {
           /* Bitmap bitmap = new Bitmap(Canvas.Width, Canvas.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Canvas.DrawToBitmap(bitmap, Canvas.ClientRectangle);
            }*/

            return Bitmap.GetPixel(point.X, point.Y);       
        }


        public void DrawStart(int x, int y, int length, int NumberOfPoints) {
            Brush fillBrush = new SolidBrush(Color.Yellow);

            Point[] starPoints = new Point[2 * NumberOfPoints];
            for (int i = 0; i < 2 * NumberOfPoints; i++)
            {
                double angle = i * 2 * Math.PI / (2 * NumberOfPoints);
                if (i % 2 == 0)
                {
                    starPoints[i] = new Point(
                        x + (int)(length * Math.Cos(angle)),
                        y + (int)(length * Math.Sin(angle))
                    );
                }
                else
                {
                    starPoints[i] = new Point(
                        x + (int)(length / 2 * Math.Cos(angle)),
                        y + (int)(length / 2 * Math.Sin(angle))
                    );
                }
            }

            Graphics.FillPolygon(fillBrush, starPoints);
        }
      

    }
}

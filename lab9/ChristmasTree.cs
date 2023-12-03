using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    class ChristmasTree
    {
        public int X;
        public int Y;
        public Color[] Colors = { Color.Red, Color.Blue, Color.LightPink, Color.Yellow, Color.Gold };

        public bool ifDrawStar;
        public bool ifDrawGifts;
        public bool ifDrawChains;
        public bool ifDrawBaubles;
        public bool ifDrawLamps;

        private Random Random;
        private Graphics Graphics;
        private PictureBox Canvas;
        private Bitmap Bitmap;
        private List<Point> LampPoints;
        private List<List<Point>> ChainPoints;
        private List<BaubleModel> BaublesPoints;

        private Thread AudioThread;
      




        public ChristmasTree(PictureBox canvas) {
            LampPoints = new List<Point>();
            ChainPoints = new List<List<Point>>();
            BaublesPoints = new List<BaubleModel>();

            Canvas = canvas;
            Random = new Random();

            Bitmap = new Bitmap(canvas.Width, canvas.Height);
            Graphics = Graphics.FromImage(Bitmap);

            ifDrawBaubles = true;
            ifDrawChains = true;
            ifDrawGifts = true;
            ifDrawLamps = true;
            ifDrawStar = true;

            AudioThread = new Thread(startRadioThread);

        }

        public void drawTree(int x, int y) {
            Bitmap = new Bitmap(Canvas.Width, Canvas.Height);
            Graphics = Graphics.FromImage(Bitmap);

            DrawRectangle(x+350, 730, 100);
            DrawTriangle(x+200, 50, 300);
            DrawTriangle(x+150, 150, 400);
            DrawTriangle(x+100, 250, 500);

            GetChainsPosition();
            getRandomLampPoints(100);
            getBaublesPoints(50, 25);

            if (ifDrawStar)
                DrawStart(x + 350, 60, 50, 7);

            if(ifDrawBaubles)
                DrawBaublesOnTree(50, 25);

            if(ifDrawLamps)
                DrawLamps();

            if(ifDrawChains)
                DrawChains();

            if (ifDrawGifts) {
                DrawGiftBox(x + 300, 800, 50, 50, Brushes.Red);
                DrawGiftBox(x + 200, 800, 70, 70, Brushes.Green);
                DrawGiftBox(x + 450, 800, 60, 60, Brushes.Pink);
            }



            Canvas.Image = Bitmap;

        }

        public void toggleAudio() {
            if (AudioThread.IsAlive)
            {
                try
                {
                    AudioThread.Abort();
                }
                catch { }
                

            }
            else {
                AudioThread = new Thread(startRadioThread);
                AudioThread.Start();

            }


        }

        public void updateLamps() {
            DrawLamps();
            Canvas.Image = Bitmap;
          
        }

        public void GetChainsPosition() {
            if (ChainPoints.Count > 1)
                return;

            for (int i = 0; i < 3; i++) {
                ChainPoints.Add(new List<Point>());

                for (int j = 0; j < 200; j++) {
                    int x = 0+ j*3;
                    int y = (int)(70 * Math.Sin((double)x/20+(double)i/2))+200+(i*200);
                    Point point = new Point(x, y);
                    Color color = GetColorAtPoint(point);
                    if (color.ToArgb().Equals(Color.Green.ToArgb()))
                        ChainPoints[i].Add(point);
                }
            }
        }

        public static void startRadioThread() {
            try
            {
                while (true) {
                    Random random = new Random();

                    int randomMusic = random.Next(1, 3);

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.ResourceManager.GetStream($"_{randomMusic}"));
                    player.PlaySync();
                }
               
               
            }
            catch (Exception ex)
            {
            }
        }

        public void DrawChains() {
            foreach (List<Point> points in ChainPoints) {
                Pen pen = new Pen(Color.Red, 4);
                for (int i = 0; i < points.Count - 1; i++)
                {
                    Graphics.DrawLine(pen, points[i], points[i + 1]);
                }

                foreach (Point point in points)
                {
                    Graphics.FillEllipse(Brushes.Red, point.X - 5, point.Y - 5, 10, 10);
                }
            }        
            
        }

        public void getBaublesPoints(int count, int size) {
            if (BaublesPoints.Count > 1)
                return;

            while (count > 0)
            {
                int x = Random.Next(Canvas.Width);
                int y = Random.Next(Canvas.Height);
                Point point = new Point(x, y);

                Color color = GetColorAtPoint(point);
                Color randomColor = Colors[Random.Next(Colors.Length - 1)];
                if (color.ToArgb().Equals(Color.Green.ToArgb()))
                {
                    BaubleModel bauble = new BaubleModel();
                    bauble.color = randomColor;
                    bauble.Point = point;
                    bauble.size = size;
                    BaublesPoints.Add(bauble);
                    count--;
                }
            }
        }

        public void DrawBaublesOnTree(int count, int size) {
            foreach (BaubleModel bauble in BaublesPoints) {
                DrawBauble(bauble.Point.X, bauble.Point.Y, bauble.size, bauble.color);

            }

           /* while (count > 0) {
                int x = Random.Next(Canvas.Width);
                int y = Random.Next(Canvas.Height);
                Point point = new Point(x, y);

                Color color = GetColorAtPoint(point);
                Color randomColor = Colors[Random.Next(Colors.Length-1)];
                if (color.ToArgb().Equals(Color.Green.ToArgb()))
                {
                    DrawBauble(x, y, size, randomColor);
                    count--;
                }
            }*/
          
        }

        public void getRandomLampPoints(int count) {
            if (LampPoints.Count > 1)
                return;

            while (count > 0)
            {
                int x = Random.Next(Canvas.Width);
                int y = Random.Next(Canvas.Height);
                Point point = new Point(x, y);

                Color color = GetColorAtPoint(point);
                if (color.ToArgb().Equals(Color.Green.ToArgb()))
                {
                    LampPoints.Add(point);
                    count--;
                }
            }
              
        }

        public void DrawLamps() {
            foreach (Point point in LampPoints) {
                int active = Random.Next(2);
                Brush brush;
                if(active == 1)
                    brush = new SolidBrush(Color.Yellow);
                else
                    brush = new SolidBrush(Color.Gray);
                Graphics.FillEllipse(brush, point.X, point.Y ,10, 10);

            }
        }

        public void DrawBauble(int x, int y, int size, Color color) {
            Brush brush = new SolidBrush(color);
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
         
            return Bitmap.GetPixel(point.X, point.Y);       
        }

        private void DrawGiftBox(int x, int y, int width, int height, Brush boxBrush)
        {
            Pen ribbonPen = new Pen(Color.Gray, 5);

            Graphics.FillRectangle(boxBrush, x, y, width, height);
            Graphics.DrawRectangle(ribbonPen, x, y, width, height);

            // Draw a ribbon on the gift box
            Graphics.DrawLine(ribbonPen, x, y, x + width, y + height);
            Graphics.DrawLine(ribbonPen, x + width, y, x, y + height);
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

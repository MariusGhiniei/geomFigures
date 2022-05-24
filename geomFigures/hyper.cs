using System;
using System.Drawing;
using System.Windows.Forms;

namespace geomFigures
{
    public partial class hyper : Form
    {
        Bitmap boxHyper = new Bitmap(1500, 1500);
        Graphics g;

        int center = 275;
        int X = 100/2;
        int Y = 100/2;
        int theta = -100;
        public hyper()
        {
            InitializeComponent();
        }

        private void Hyper_Load(object sender, EventArgs e)
        {

            g = Graphics.FromImage(boxHyper);
            pictureBox1.Image = boxHyper;

            timer1.Start();

        }

        private Point HyperDrawPos(int widthHyper, int heightHyper, Point origin, int t)
        {
            Point point = new Point((int)(origin.X + widthHyper * Math.Cosh(t * Math.PI / 180)),
                                    (int)(origin.Y + heightHyper * Math.Sinh(t * Math.PI / 180)));

            return point;
        }

        private Point HyperDrawNeg(int widthHyper, int heightHyper, Point origin, int t)
        {
            Point point = new Point((int)(origin.X - widthHyper * Math.Cosh(t * Math.PI / 180)),
                                    (int)(origin.Y + heightHyper * Math.Sinh(t * Math.PI / 180)));

            return point;
        }
        private void HyperTimer_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(boxHyper);

            Point O = new Point(center, center);
            int xPos = HyperDrawPos(X, Y, O, theta).X;
            int yPos = HyperDrawPos(X, Y, O, theta).Y;

            int xNeg = HyperDrawNeg(X, Y, O, theta).X;
            int yNeg = HyperDrawNeg(X, Y, O, theta).Y;

            g.FillRectangle(new SolidBrush(Color.Red), xPos, yPos, 10, 10);
            g.FillRectangle(new SolidBrush(Color.Blue), xNeg, yNeg, 10, 10);

            pictureBox1.Image = boxHyper;
            g.Dispose();

            if (theta == 100)
            {
                timer1.Stop();
            }
            else theta++;

        }
    }
}

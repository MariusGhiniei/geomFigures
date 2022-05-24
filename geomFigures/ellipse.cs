using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geomFigures
{
    public partial class ellipse : Form
    {
        Bitmap boxEllipse = new Bitmap(1000, 1000);
        Graphics g;

        //Set canvas
        int center = 1000 / 2;
        int radiusX = 1000/2 - 120; // center the figure in the pictureBox
        int radiusY = 1000/2 - 370;
        int theta = 0;

        public ellipse()
        {
            InitializeComponent();
        }

        private void ellipse_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(boxEllipse);
            pictureBox1.Image = boxEllipse;
    
            ellipseTimer.Start();
        }

        private Point EllipseDraw(int widthEllipse,int heightEllipse, Point origin, int t)
        {
            Point point = new Point((int)(origin.X + widthEllipse*Math.Cos(t*Math.PI/180)),
                                    (int)(origin.Y + heightEllipse*Math.Sin(t*Math.PI/180)));

            return point;
        }

        private void EllipseTimer_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(boxEllipse);

            Point O = new Point(center, center);
            int x = EllipseDraw(radiusX, radiusY, O, theta).X;
            int y = EllipseDraw(radiusX, radiusX, O, theta).Y;

            g.FillRectangle(new SolidBrush(Color.HotPink), x, y, 10, 10);

            pictureBox1.Image = boxEllipse;
            g.Dispose();

            if (theta == 360)
            {
                ellipseTimer.Stop();
            }
            else theta++;
        }
        

    } 
}

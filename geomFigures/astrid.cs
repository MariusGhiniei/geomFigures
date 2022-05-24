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
    public partial class astrid : Form
    {
        Bitmap boxAstrid = new Bitmap(1000, 1000);
        Graphics g;

        //Set canvas
        int center = 250;
        int radiusX = 100; // center the figure in the pictureBox
        int radiusY = 100;
        int theta = 0;

        public astrid()
        {
            InitializeComponent();
        }

        private void astrid_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(boxAstrid);
            pictureBox1.Image = boxAstrid;

            AstridTimer.Start();
        }

        private Point AstridDraw(int widthAstrid, int heightAstrid, Point origin, int t)
        {
            Point point = new Point((int)(origin.X + widthAstrid * Math.Pow(Math.Cos(t * Math.PI / 180) ,3)),
                                    (int)(origin.Y + heightAstrid * Math.Pow( Math.Sin(t * Math.PI / 180),3)));

            return point;
        }

        private void AstridTimer_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(boxAstrid);

            Point O = new Point(center +70, center-50);
            int x = AstridDraw(radiusX, radiusY, O, theta).X;
            int y = AstridDraw(radiusX, radiusX, O, theta).Y;

            g.FillRectangle(new SolidBrush(Color.Black), x, y, 10, 10);

            pictureBox1.Image = boxAstrid;
            g.Dispose();

            if (theta == 360)
            {
                AstridTimer.Stop();
            }
            else theta++;
        }


    }
}

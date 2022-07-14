using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageMath
{
    public partial class PolygonForm : Form
    {
        public Complex[] PolygonPoints { get; set; }
        Point latestPoint;
        List<Complex> newPoints;
        public PolygonForm(Bitmap bmp, Complex[] oldPolygonPoints)
        {
            
            InitializeComponent();
            PolygonPoints = oldPolygonPoints;
            pictureBox1.Image = bmp;
            newPoints = new List<Complex>(oldPolygonPoints);
            //DrawBorder(oldPolygonPoints);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PolygonPoints = newPoints.ToArray();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void GainBox_MouseMove(object sender, MouseEventArgs e)
        {
            //if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            //{
                using (Graphics g = pictureBox1.CreateGraphics())
                {

                    PictureBox thisBox = (sender as PictureBox);
                    Point pos = ((MouseEventArgs)e).Location;

                    Rectangle imagerect = PictureSize();
                    pos.Offset(-imagerect.X, -imagerect.Y); // pos = the position on the displayed picture
                    double x = Convert.ToDouble(pos.X - imagerect.Width / 2) * Math.PI * 2 / imagerect.Width;
                    double y = Convert.ToDouble(pos.Y - imagerect.Height / 2) * Math.PI * 2 / imagerect.Height;


                    List<Complex> withTestPoint = new List<Complex>(newPoints);
                    withTestPoint.Add(new Complex(x, y));
                    withTestPoint = (List<Complex>)withTestPoint.OrderBy(num => num.Phase).ToList();



                DrawBorder(withTestPoint);
                }
            //}
        }

        private void GainBox_MouseDown(object sender, MouseEventArgs me)
        {
            latestPoint = me.Location;

            PictureBox thisBox = (sender as PictureBox);
            Point pos = ((MouseEventArgs)me).Location;

            Rectangle imagerect = PictureSize();
                pos.Offset(-imagerect.X, -imagerect.Y); // pos = the position on the displayed picture
            double x = Convert.ToDouble(pos.X - imagerect.Width / 2) * Math.PI * 2 / imagerect.Width;
            double y = Convert.ToDouble(pos.Y - imagerect.Height / 2) * Math.PI * 2 / imagerect.Height;
            Complex clickPoint = new Complex(x, y);

            if ((me.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                newPoints.Add(clickPoint);
                newPoints = (List<Complex>)newPoints.OrderBy(num => num.Phase).ToList();

                DrawBorder(newPoints);
            }

            if ((me.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                double curPhase = clickPoint.Phase;
                int belowIndex = 0;
                bool indexFoundFlag = false;
                for (int i = newPoints.Count-1; i >= 0; i--)
                {
                    if (newPoints[i].Phase <= curPhase && !indexFoundFlag)
                    {
                        indexFoundFlag = true;
                        belowIndex = i;
                    }
                }
                int overIndex = (belowIndex + 1 + newPoints.Count) % newPoints.Count;

                double dstOver = distance(clickPoint, newPoints[overIndex]);
                double dstBelow = distance(clickPoint, newPoints[belowIndex]);

                int correctindex = 0;
                if (dstOver < dstBelow) // use dstOver
                {
                    correctindex = overIndex;
                }
                else
                {
                    correctindex = belowIndex;
                }
                newPoints.RemoveAt(correctindex);
                //newPoints = (List<Complex>)newPoints.OrderBy(num => num.Phase).ToList();

            }
        }

        double distance(Complex point1, Complex point2)
        {
            double realDst = point1.Real - point2.Real;
            double imDst = point1.Imaginary - point2.Imaginary;
            return Math.Sqrt(realDst * realDst + imDst * imDst);
        }
        Rectangle PictureSize()
        {
            // Remember the location where the button was pressed
            //latestPoint = me.Location;


            PictureBox thisBox = pictureBox1;// (sender as PictureBox);
            //Point pos = ((MouseEventArgs)me).Location;

            double picRatio = (double)thisBox.Image.Width / thisBox.Image.Height;
            double boxRatio = (double)thisBox.Width / thisBox.Height;

            //int dstFromLeft = 0;
            //int dstFromTop = 0;

            int displayPicHeight = 0;
            int displayPicWidth = 0;
            if (picRatio > boxRatio)
            { // too  low
                displayPicHeight = Convert.ToInt32(thisBox.Width / picRatio);
                displayPicWidth = thisBox.Width;
            }
            else
            { // too narrow
                displayPicWidth = Convert.ToInt32(thisBox.Height * picRatio);
                displayPicHeight = thisBox.Height;
            }
            int dstFromTop = (thisBox.Height - displayPicHeight) / 2;
            int dstFromLeft = (thisBox.Width - displayPicWidth) / 2;
            //pos.Offset(-dstFromLeft, -dstFromTop); // pos = the position on the displayed picture

            return new Rectangle(dstFromLeft, dstFromTop, displayPicWidth, displayPicHeight);
        }

        Point GetPixel(Rectangle imgSize, Complex pos)
        {
            double xPos = pos.Real + Math.PI;
            double yPos = pos.Imaginary + Math.PI;

            int x = Convert.ToInt32(xPos * imgSize.Width / (Math.PI * 2));
            int y = Convert.ToInt32(yPos * imgSize.Height / (Math.PI * 2));

            return new Point(x+imgSize.Left, y + imgSize.Top);


        }

        void DrawBorder(List<Complex> DrawPoints)
        {
            pictureBox1.Refresh();

            //DrawPoints = (List<Complex>)DrawPoints.OrderBy(x => x.Phase).ToList();

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                Rectangle picturesize = PictureSize();
                if (DrawPoints.Count >= 2)
                {
                    Point[] cornerPoints = new Point[DrawPoints.Count];
                    //
                    for (int i = 0; i < cornerPoints.Length; i++)
                    {
                        cornerPoints[i] = GetPixel(picturesize, DrawPoints[i]);
                    }
                    g.DrawPolygon(Pens.Red,cornerPoints);
                }
            }
            
            
        }

        Complex PointToComplex(Point point)
        {
            return new Complex(point.X, point.Y);
        }
        Point ComplexToPoint(Complex point)
        {
            return new Point(Convert.ToInt32(point.Real), Convert.ToInt32(point.Imaginary));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            newPoints.Clear();
            DrawBorder(newPoints);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
                DrawBorder(newPoints);
        }
    }
}

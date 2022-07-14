using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImageMath
{

    // Future work: 
    // Why doesnt the minuses here matter? :   -x*im(-1)+x
    // Add GetAngle funtion? To move to polar coordinates. (abs already exists)
    // Add IF function? 
    // List all available function types.

    public partial class Form1 : Form
    {
        
        static int noSectors;
        static int noRings;
        Node mathExpression;
        //static ArrayList cosValues;
        //static ArrayList sinValues;

        Bitmap bmpIn;

        //static float dr;
        //static float dTheta;

        static string inFileName;
        //static float cx, cy;

        static Rectangle srcRect;

        Bitmap myBmp;

        double time = 0;
        //Bitmap inputImg;
        //Complex[] Sortedcorners;
        Complex[] polygonCorners_array;
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnCalculate;
            polygonCorners_array = new Complex[4];
            polygonCorners_array[0] = new Complex(-1, 1);
            polygonCorners_array[1] = new Complex(1, 1);
            polygonCorners_array[2] = new Complex(1, -1);
            polygonCorners_array[3] = new Complex(-1, -1);


            //inFileName = Convert.ToString(@"C:\Users\bvtv\Downloads\test.png"); // Name of input file
            //bmpIn = (Bitmap)(Bitmap.FromFile(inFileName));
            ////if (File.Exists(inFileName)) MessageBox.Show("yes, exists");
            //picInput.Image = bmpIn;
            //System.Drawing.Image.FromHbitmap(bmpIn.GetHbitmap());
            //Image.FromFile(inFileName);






        }

        void LoadImage(string filePath)
        {
            //string path = @"C:\Users\bvtv\Desktop\Tree.jpg";
            //string path = @"C: \Users\bvtv\Desktop\TorgeirSpiral\DSC00090 - Copy.JPG";
            //string path = @"C: \Users\bvtv\Desktop\TorgeirSpiral";
            //C:\Users\bvtv\Desktop\Oldenbilder_Torgeir\image 17.jpg

            inFileName = Convert.ToString(filePath); // Name of input file
        //C: \Users\bvtv\Desktop\TorgeirSpiral
         bmpIn = (Bitmap)(Bitmap.FromFile(inFileName));
            picInput.Image = bmpIn;
        }
        void PrepareRectangle()
        {
            //try
            //{


                //inFileName = Convert.ToString(@"C:\Users\bvtv\Desktop\PolarTestImg\TestLandscape.png"); // Name of input file
                //string outFileName = Convert.ToString(@"C:\Users\bvtv\Downloads\test_pol.png"); // Name of output file
                


                // Read in the input image file
                //bmpIn = (Bitmap)(Bitmap.FromFile(inFileName));
            Bitmap curBmp = (Bitmap)picInput.Image;
            if (curBmp == null) 
            {
                //MessageBox.Show("No image loaded");
                throw new NullReferenceException("No Image Loaded");
            }
            noSectors = Convert.ToInt32(curBmp.Width); // Number of sectors
            noRings = Convert.ToInt32(curBmp.Height); // Number of rings
            srcRect = new Rectangle(0, 0, curBmp.Width, curBmp.Height);
            //myBmp = CreatePolarImage();
            //pictureBoxResult.Image = myBmp;
                //picInput.Image = bmpIn;

                

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    MessageBox.Show(e.Message);
            //}

        }
        Bitmap CreatePolarImage()
        {
            // In the Polar bitmap, 
            //    Width  = number of sectors
            //    Height = number of rings
            noSectors = (int)numOutputWidth.Value;
            noRings = (int)numOutputHeight.Value;

            Bitmap bmpOut = new Bitmap(noSectors, noRings, PixelFormat.Format24bppRgb);

            int i, j, j1, pixelsize = 3;
            int x, y;
            byte red = 0, green = 0, blue = 0;
            

            // Map the image
            Rectangle rectOut = new Rectangle(0, 0, bmpOut.Width, bmpOut.Height);
            BitmapData bmdOut = bmpOut.LockBits(rectOut, ImageLockMode.ReadWrite,
                bmpOut.PixelFormat);

            int inputWidth = bmpIn.Width;
            int inputHeight = bmpIn.Height;
            //double multiplier = track_multiplier.Value;

            unsafe
            {
                for (j = 0; j < noRings; ++j)  // for each row of output image
                {
                    double imaginary = Math.PI * (Convert.ToDouble(j * 2 - noRings) / noRings);  // mapping to +- PI

                    byte* row = (byte*)bmdOut.Scan0 + (j * bmdOut.Stride); //pointer to the address of the first pixel in a row.
                    for (i = 0; i < noSectors; ++i)  // for each pixel in the row
                    {
                        //int offset = 75;

                        
                        double real = Math.PI * (Convert.ToDouble(i * 2 - noSectors) / noSectors); // mapping to +- PI
                                                                                                   //txtShow.AppendText(imaginary.ToString() + "\n");



                        Complex result = mathExpression.Eval(new Complex(real, imaginary));
                        if (result.Magnitude < 20000)
                        {
                            
                            x = Convert.ToInt32((result.Real * inputWidth / 2)/Math.PI) + inputWidth / 2;
                            y = Convert.ToInt32((result.Imaginary * inputHeight / 2) / Math.PI) + inputHeight/2;
                        }
                        else
                        {
                            x = -1;
                            y = -1;
                        }
                        
                        

                        if (srcRect.Contains(x, y)) 
                        {
                            GetRGBVals(x, y, ref red, ref green, ref blue); // Gets the color in the source image
                        }
                        else
                        {
                            red = green = blue = 0;
                        }
                        j1 = i * pixelsize; // j1 indicates where in the row the current pixel is
                        row[j1] = blue;
                        row[j1 + 1] = green;
                        row[j1 + 2] = red;
                    }
                    UpdateStatus(100*j/noRings);
                }
            }
            bmpOut.UnlockBits(bmdOut);
            UpdateStatus(0);
            return bmpOut;
        }
        //Bitmap CreatePolarImage()
        //{
        //    // In the Polar bitmap, 
        //    //    Width  = number of sectors
        //    //    Height = number of rings
        //    Bitmap bmpOut = new Bitmap(noSectors, noRings, PixelFormat.Format24bppRgb);

        //    int i, j, j1, pixelsize = 3;
        //    int x, y;
        //    byte red = 0, green = 0, blue = 0;


        //    // Map the image
        //    Rectangle rectOut = new Rectangle(0, 0, bmpOut.Width, bmpOut.Height);
        //    BitmapData bmdOut = bmpOut.LockBits(rectOut, ImageLockMode.ReadWrite,
        //        bmpOut.PixelFormat);

        //    //double multiplier = track_multiplier.Value;

        //    unsafe
        //    {
        //        for (j = 0; j < noRings; ++j)
        //        {
        //            byte* row = (byte*)bmdOut.Scan0 + (j * bmdOut.Stride); //pointer to the address of the first pixel in a row.
        //            for (i = 0; i < noSectors; ++i)
        //            {
        //                //int offset = 75;

        //                double imaginary = Math.PI * (Convert.ToDouble(j * 2 - noRings) / noRings);
        //                double real = Math.PI * (Convert.ToDouble(i * 2 - noSectors) / noSectors);
        //                //txtShow.AppendText(imaginary.ToString() + "\n");



        //                Complex result = mathExpression.Eval(new Complex(real, imaginary));
        //                if (result.Magnitude < 20000)
        //                {

        //                    x = Convert.ToInt32((result.Real * noSectors / 2) / Math.PI) + noSectors / 2;
        //                    y = Convert.ToInt32((result.Imaginary * noRings / 2) / Math.PI) + noRings / 2;
        //                }
        //                else
        //                {
        //                    x = -1;
        //                    y = -1;
        //                }



        //                if (srcRect.Contains(x, y))
        //                {
        //                    GetRGBVals(x, y, ref red, ref green, ref blue); // Gets the color in the source image
        //                }
        //                else
        //                {
        //                    red = green = blue = 0;
        //                }
        //                j1 = i * pixelsize; // j1 indicates where in the row the current pixel is
        //                row[j1] = blue;
        //                row[j1 + 1] = green;
        //                row[j1 + 2] = red;
        //            }
        //            UpdateStatus(100 * j / noRings);
        //        }
        //    }
        //    bmpOut.UnlockBits(bmdOut);
        //    UpdateStatus(0);
        //    return bmpOut;
        //}

        private void UpdateStatus(int v)
        {
            //progressBar1.Value = v;
            toolStripProgressBar1.Value = v;
        }

        void GetRGBVals(int x, int y, ref byte red, ref byte green, ref byte blue)
        {
            Color c = bmpIn.GetPixel(x, y);
            red = c.R;
            green = c.G;
            blue = c.B;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalcNewImg();
        }

        void CalcNewImg()
        {
            try
            {
                string startvalue = numGifStart.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string expression = cmbExpression.Text.Replace("#", startvalue);
                mathExpression = Node.CreateNodeTree(expression, polygonCorners_array);
                
                PrepareRectangle();
                myBmp = CreatePolarImage();
                pictureBoxResult.Image = myBmp;


                txtError.Text = "";
                txtError.BackColor = Color.White;
                panError.Visible = false;
            }
            catch (NullReferenceException err)
            {
                MessageBox.Show(err.Message);
            }
            catch (Exception err)
            {
                txtError.Text = err.Message;
                txtError.BackColor = Color.Red;
                panError.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PrepareRectangle();
            myBmp = CreatePolarImage();
            pictureBoxResult.Image = myBmp;


            time += 1;
        }

        private void txtMathString_TextChanged(object sender, EventArgs e)
        {
            try
            {
                mathExpression = Node.CreateNodeTree(cmbExpression.Text, polygonCorners_array);
                //CreateImage();
                txtError.Text = "";
                txtError.BackColor = Color.White;
                panError.Visible = false;
            }
            catch (Exception err)
            {
                txtError.Text = err.Message;
                txtError.BackColor = Color.Red;
                panError.Visible = true;
            }
            
        }

        //private void picInput_Click(object sender, EventArgs me)
        //{
        //    //Rectangle rect = (sender as PictureBox).ClientSize;
        //    //MessageBox.Show(rect.ToString());

        //    PictureBox thisBox = (sender as PictureBox);
        //    Point pos = ((MouseEventArgs)me).Location;

        //    double picRatio = (double)thisBox.Image.Width / thisBox.Image.Height;
        //    double boxRatio = (double)thisBox.Width / thisBox.Height;

        //    //int dstFromLeft = 0;
        //    //int dstFromTop = 0;

        //    int displayPicHeight = 0;
        //    int displayPicWidth = 0;
        //    if (picRatio > boxRatio)
        //    { // too  low
        //        displayPicHeight = Convert.ToInt32(thisBox.Width / picRatio);
        //        displayPicWidth = thisBox.Width;
        //    }
        //    else
        //    { // too narrow
        //        displayPicWidth = Convert.ToInt32(thisBox.Height * picRatio);
        //        displayPicHeight = thisBox.Height;
        //    }
        //    int dstFromTop = (thisBox.Height - displayPicHeight) / 2;
        //    int dstFromLeft = (thisBox.Width - displayPicWidth) / 2;
        //    pos.Offset(-dstFromLeft, -dstFromTop); // pos = the position on the displayed picture


        //    // --- Convert image to 2Pi * 2PI --- //

        //    double x = Convert.ToDouble(pos.X - displayPicWidth / 2) * Math.PI * 2 / displayPicWidth;
        //    double y = Convert.ToDouble(pos.Y - displayPicHeight / 2) * Math.PI * 2 / displayPicHeight;

        //    polygonCorners.Add( new Complex(x, y) );




        //    //Point coordinates = me.Location;
        //    //MessageBox.Show(newPoint.ToString());
        //    //coordinates.Offset((sender as PictureBox).Location);
        //    //MessageBox.Show(coordinates.ToString());
        //    //throw new NotImplementedException("add point to array");

        //}

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    LoadImage(filePath);
                }
            }

        }

        

        private void btnEditPolygon_Click(object sender, EventArgs e)
        {
            if (!(bmpIn is null))
            {
                using (var form = new PolygonForm((Bitmap)picInput.Image, polygonCorners_array))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        polygonCorners_array = form.PolygonPoints;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

                SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fName = dialog.FileName;
                string[] dividedName = fName.Split('.');
                bool extensionOK = false;
                if (dividedName.Length > 1)
                {
                    if (dividedName.Last().Length > 1 && dividedName.Last().Length <= 4)
                    {
                        extensionOK = true;
                    }
                }

                if (!extensionOK)
                {
                    fName += ".jpg";
                }
                myBmp.Save(fName, ImageFormat.Jpeg);
            }
        }

        private void txtMathString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcNewImg();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(bmpIn is null))
            {
                numOutputHeight.Value = bmpIn.Height;
                numOutputWidth.Value = bmpIn.Width;
            }
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpMe helpForm = new HelpMe();
            helpForm.ShowDialog();


        }

        private void btnWriteGif_Click(object sender, EventArgs e)
        {

            
            double fps = Convert.ToDouble(numGifFps.Value);
            double duration = Convert.ToDouble(numGifDuration.Value);
            double start = Convert.ToDouble(numGifStart.Value);
            double end = Convert.ToDouble(numGifEnd.Value);

            int numFrames = (int)(fps*duration);
            double[] parametricT = new double[numFrames];
            parametricT[0] = start;
            double spacing = (end-start) / (numFrames);
            for (int i = 1; i < numFrames; i++)
            {
                parametricT[i] = parametricT[i - 1] + spacing;
            }


            // Check if the string contains "#"
            string expression = cmbExpression.Text;
            if(!expression.Contains("#"))
            {
                MessageBox.Show("The expression must contain this symbol: #");
                return;
            }

            // Test the expression:
            try
            {
                string test = expression.Replace("#", "0");
                Node.CreateNodeTree(test, polygonCorners_array);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
            

            // Select a filename
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Gif files (*.gif)|*.gif";
            string savePath = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                savePath = saveFileDialog.FileName;
            }
            else
            {
                return;
            }

            // Start producing the gif

            toolStripProgressBar2.Maximum = numFrames;
            using (GifWriter gw = new GifWriter(savePath, (int)(1000 / fps), 0))
            {
                try
                {
                    int i = 0;
                    foreach (double item in parametricT)
                    {
                        i++;
                        //toolStripStatusLabel1.Text = "Writing " + i + " of " + parametricT.Length + "...";
                        toolStripProgressBar2.Value = i;
                        this.Invalidate();

                        string expInjectedValue = expression.Replace("#", item.ToString(System.Globalization.CultureInfo.InvariantCulture));
                        


                        mathExpression = Node.CreateNodeTree(expInjectedValue, polygonCorners_array);
                        PrepareRectangle();
                        myBmp = CreatePolarImage();
                        gw.WriteFrame(myBmp);


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //toolStripStatusLabel1.Text = "";
                toolStripProgressBar2.Value = 0;
            }

        }

    }

    public abstract class Node
    {
        public abstract Complex Eval();
        public abstract Complex Eval(Complex x_value);
        public static Node CreateNodeTree(string str, Complex[] polygonPoints)
        {
            if (str.Length == 0)
            {

                return new NodeNumber(0);
            }
            else
            {
                List<string> nodeData = new List<string>();
                int typePeak = testCharType(str[0]);
                int prevCharType = -1;// testCharType(str[0]);
                if (typePeak == 1 || typePeak == 3) // forhindrer at den første bokstaven blir et eget symbol
                {
                    prevCharType = typePeak;
                }

                int startPos = 0;
                for (int i = 1; i < str.Length; i++)
                {
                    int charType = testCharType(str[i]);
                    if (charType != prevCharType)
                    {
                        //MessageBox.Show(str.Substring(startPos, i - startPos));
                        string element = str.Substring(startPos, i - startPos);
                        if (element[0] != ' ')
                        {
                            nodeData.Add(element);
                        }
                        startPos = i;
                    }
                    prevCharType = charType;
                    if (charType == 4 || charType == 5) prevCharType = -1;

                }
                string _element = str.Substring(startPos, str.Length - startPos);
                if (_element[0] != ' ')
                {
                    nodeData.Add(_element);
                }

                Node rootNode = new NodeBinary(nodeData, new List<string> { "0" }, (a, b) => a + b, polygonPoints);
                //MessageBox.Show(rootNode.Eval().ToString());
                return rootNode;
            }
        }

        static int testCharType(char testChar)
        {
            if (char.IsNumber(testChar) || testChar == '.') // number
            {
                return 1;
            }
            else if (testChar == '+' || testChar == '+' || testChar == '*' || testChar == '/') // operator
            {
                return 2;
            }
            else if (char.IsLetter(testChar)) // letter
            {
                return 3;
            }
            else if (testChar == '(') // startParentes
            {
                return 4;
            }
            else if (testChar == ')') // endParentes
            {
                return 5;
            }
            else if (testChar == ' ') // space
            {
                return 6;
            }
            else if (testChar == ',') return 7;
            else return 8;

        }

        public static Node recursiveParser(List<string> elements, Complex[] polygonPoints) // This method is called recursively, and adds nodes to the expression tree.
        {
            if (elements.Count == 0) // adds the number 0 when no element is given. It is used to convert "-1" to "0-1"
            {
                throw new FormatException("Missing value");
                //return new NodeNumber(0);
            }
            else if (elements.Count == 1) // one element has to be either a number or a variable.
            {
                if (char.IsNumber(elements[0][0]))
                {
                    return new NodeNumber(new Complex(double.Parse(elements[0], System.Globalization.CultureInfo.InvariantCulture),0));
                }
                else if (elements[0][0] == 'x')
                {
                    return new NodeVariable();
                }
            }

            int plusspos = PositionOfLastToken(elements, "+"); // First, look for all additions
            if (plusspos != -1)
            {
                return new NodeBinary(
                    elements.GetRange(0, plusspos), 
                    elements.GetRange(plusspos + 1, elements.Count - plusspos - 1), 
                    (a, b) => Complex.Add(a , b),
                    polygonPoints
                    );
            }

            int minuspos = PositionOfLastToken(elements, "-"); // Look for all subtractions
            if (minuspos == 0) // If the expression starts with minus, we do: "0 - expression" (We already know that there is no other add/subtract operations in the expression)
            {
                return new NodeBinary(
                    new List<string> { "0" },
                    elements.GetRange(minuspos + 1, elements.Count - minuspos - 1),
                    (a, b) => a - b,
                    polygonPoints
                    );
            }
            else if (minuspos != -1) // Create the subtraction nodes
            {
                return new NodeBinary(
                    elements.GetRange(0, minuspos), 
                    elements.GetRange(minuspos + 1, elements.Count - minuspos - 1), 
                    (a, b) => Complex.Subtract(a,b),
                    polygonPoints
                    );
            }

            int multpos = PositionOfLastToken(elements, "*"); // Look for all multiplications
            if (multpos != -1)
            {
                return new NodeBinary(
                    elements.GetRange(0, multpos), 
                    elements.GetRange(multpos + 1, elements.Count - multpos - 1), 
                    (a, b) => Complex.Multiply(a, b),
                    polygonPoints
                    );
            }

            int dividepos = PositionOfLastToken(elements, "/"); // look for all divisions
            if (dividepos != -1)
            {
                return new NodeBinary(
                    elements.GetRange(0, dividepos),
                    elements.GetRange(dividepos + 1, elements.Count - dividepos - 1),
                    (a, b) => Complex.Divide(a, b),
                    polygonPoints
                    );
            }


            if (elements[0] == "(" && elements[elements.Count - 1] == ")") // Look for pharentesis
            {
                return new NodeBinary(
                    elements.GetRange(1, elements.Count - 2), 
                    new List<string> { "0" }, 
                    (a, b) => Complex.Add(a, b),
                    polygonPoints
                    );
                //return recursiveParser(elements.GetRange(1, elements.Count - 2));
            }

            else if (elements.Count >= 3)
            {
                if (elements[1] == "(" && elements[elements.Count - 1] == ")" && char.IsLetter(elements[0][0])) // Look for functions
                {
                    if (elements[0].ToLower() == "exp")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3), 
                            new List<string> { "0" }, 
                            (a, b) => Complex.Exp(a),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "log")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3), 
                            new List<string> { "0" }, 
                            (a, b) => Complex.Log(a),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "abs")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3), 
                            new List<string> { "0" }, 
                            (a, b) => Complex.Abs(a),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "pi")
                    {
                        return new NodeNumber(Math.PI);
                    }
                    if (elements[0].ToLower() == "sin")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3), 
                            new List<string> { "0" }, 
                            (a, b) => Complex.Sin(a),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "cos")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3), 
                            new List<string> { "0" }, 
                            (a, b) => Complex.Cos(a),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "tan")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3), 
                            new List<string> { "0" }, 
                            (a, b) => Complex.Tan(a),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "sqrt")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3), 
                            new List<string> { "0" }, 
                            (a, b) => Complex.Sqrt(a),
                            polygonPoints
                            );
                    }

                    if (elements[0].ToLower() == "pow")
                    {
                        int commaPosition = PositionOfLastToken(elements, ",", 1);
                        if (commaPosition != -1)
                        {
                            return new NodeBinary(
                                elements.GetRange(2, commaPosition - 2),
                                elements.GetRange(commaPosition + 1, elements.Count - commaPosition - 2),
                                (a, b) => Complex.Pow(a, b),
                                polygonPoints
                                );
                        }
                    }
                    if (elements[0].ToLower() == "mod")
                    {
                        int commaPosition = PositionOfLastToken(elements, ",", 1);
                        if (commaPosition != -1)
                        {
                            
                            return new NodeBinary(
                                elements.GetRange(2, commaPosition - 2),
                                elements.GetRange(commaPosition + 1, elements.Count - commaPosition - 2),
                                (a, b) => new Complex(a.Real % b.Real, a.Imaginary),
                                polygonPoints
                                );
                        }
                    }
                    if (elements[0].ToLower() == "rotate")
                    {
                        int commaPosition = PositionOfLastToken(elements, ",", 1);
                        if (commaPosition != -1)
                        {
                            return new NodeBinary(
                                elements.GetRange(2, commaPosition - 2),
                                elements.GetRange(commaPosition + 1, elements.Count - commaPosition - 2),
                                (a, b) => Complex.FromPolarCoordinates(a.Magnitude, a.Phase+b.Real),
                                polygonPoints
                                );
                        }
                    }
                    if (elements[0].ToLower() == "skew")
                    {
                        int commaPosition = PositionOfLastToken(elements, ",", 1);
                        if (commaPosition != -1)
                        {
                            return new NodeBinary(
                                elements.GetRange(2, commaPosition - 2),
                                elements.GetRange(commaPosition + 1, elements.Count - commaPosition - 2),
                                (a, b) => new Complex(a.Real + a.Imaginary*b.Real/(Math.PI*2), a.Imaginary),
                                polygonPoints
                                );
                        }
                    }
                    if (elements[0].ToLower() == "mirror")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3),
                            new List<string> { "0" },
                            (a, b) => new Complex(Math.Abs(a.Real),a.Imaginary),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "im")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3),
                            new List<string> { "0" },
                            (a, b) => new Complex(0, a.Imaginary),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "real")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3),
                            new List<string> { "0" },
                            (a, b) => new Complex(a.Real, 0),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "swap")
                    {
                        return new NodeBinary(
                            elements.GetRange(2, elements.Count - 3),
                            new List<string> { "0" },
                            (a, b) => new Complex(a.Imaginary, a.Real),
                            polygonPoints
                            );
                    }
                    if (elements[0].ToLower() == "expmod")
                    {
                        int commaPosition = PositionOfLastToken(elements, ",", 1);
                        if (commaPosition != -1)
                        {

                            List<string> part_temp = elements.GetRange(2, commaPosition - 2);
                            List<string> _part3 = elements.GetRange(commaPosition + 1, elements.Count - commaPosition - 2);

                            int commaPosition_2 = PositionOfLastToken(part_temp, ",", 0);
                            if (commaPosition_2 != -1)
                            {

                                List<string> _part1 = part_temp.GetRange(0, commaPosition_2);
                                List<string> _part2 = part_temp.GetRange(commaPosition_2 + 1, part_temp.Count - commaPosition_2-1);


                                //Complex[] corners = new Complex[4];
                                //corners[0] = new Complex(-1, 1);
                                //corners[1] = new Complex(1, 1);
                                //corners[2] = new Complex(1, -1);
                                //corners[3] = new Complex(-1, -1);
                                //Complex[] Sortedcorners = corners.OrderBy(x => x.Phase).ToArray();


                                return new NodeExpMod(_part1, _part2, _part3, polygonPoints);
                                
                            }
                        }
                    }
                }

            }
            throw new FormatException("Unknown String format");
            //return new NodeNumber(0);

            
        }
        

        static int PositionOfLastToken(List<string> tokens, string token, int Correctparenthesislevel = 0)
        {
            int curpharenthesisLevel = 0;
            for (int i = tokens.Count - 1; i >= 0; i--) // loop through looking for * and /
            {
                if (tokens[i] == ")") curpharenthesisLevel++;
                else if (tokens[i] == "(") curpharenthesisLevel--;
                else if (curpharenthesisLevel == Correctparenthesislevel)
                {

                    if (tokens[i] == token)
                    {
                        return i;
                        //return recursiveParser(elements.GetRange(0, i)) * recursiveParser(elements.GetRange(i + 1, elements.Count - i - 1));
                    }

                }
            }
            if (curpharenthesisLevel != 0) throw new ArgumentException("Pharenthesis level error");
            return -1;
        }
    }

    class NodeNumber : Node
    {
        public NodeNumber(Complex number)
        {
            _number = number;
        }

        Complex _number;             // The number

        public override Complex Eval()
        {
            // Just return it.  Too easy.
            return _number;
        }
        public override Complex Eval(Complex x_value)
        {
            // Just return it.  Too easy.
            return _number;
        }
    }

    // NodeBinary for binary operations such as Add, Subtract etc...
    class NodeBinary : Node
    {
        // Constructor accepts the two nodes to be operated on and function
        // that performs the actual operation
        public NodeBinary(List<string> lhs, List<string> rhs, Func<Complex, Complex, Complex> op,Complex[] polygonPoints)
        {
            _op = op;

            nodeR = Node.recursiveParser(rhs, polygonPoints);
            nodeL = Node.recursiveParser(lhs, polygonPoints);
        }

        Func<Complex, Complex, Complex> _op;       // The callback operator
        Node nodeR, nodeL;
        public override Complex Eval()
        {
            // Evaluate both sides

            Complex result = _op(nodeL.Eval(), nodeR.Eval());
            // Evaluate and return
            return result;
        }
        public override Complex Eval(Complex x_value)
        {
            // Evaluate both sides

            Complex result = _op(nodeL.Eval(x_value), nodeR.Eval(x_value));
            // Evaluate and return
            return result;
        }
    }

    class NodeVariable : Node
    {

        public override Complex Eval(Complex input)
        {
            // Just return it.  Too easy.
            return input;
        }
        public override Complex Eval()
        {
            // Just return it.  Too easy.
            return 0;
        }
    }

    class NodeExpMod : Node
    {
        // Constructor accepts the two nodes to be operated on and function
        // that performs the actual operation
        public NodeExpMod(List<string> strPixel, List<string> strDivisor, List<string> strOffset, Complex[] polygonPoints)
        {
            
            divisor = Node.recursiveParser(strDivisor, polygonPoints);
            pixel = Node.recursiveParser(strPixel, polygonPoints);
            offset = Node.recursiveParser(strOffset, polygonPoints);
            this.Sortedcorners = polygonPoints.OrderBy(x => x.Phase).ToArray();
        }

        Complex[] Sortedcorners;
        Node divisor, pixel, offset;
        public override Complex Eval()
        {
            // Evaluate both sides
            Complex destPixel = pixel.Eval();
            Complex sourcePixel = Complex.Exp(destPixel);
            double angle = sourcePixel.Phase;
            Complex borderCrossing = FindIntersectionPoint(angle);
            Complex transformedBorder = Complex.Log(borderCrossing);

            if (destPixel.Real > transformedBorder.Real)
            {
                return destPixel;
            }
            else
            {
                return new Complex(0, 0);
            }
        }
        public override Complex Eval(Complex x_value)
        {
            // Evaluate both sides
            Complex destPixel = pixel.Eval(x_value);
            //destPixel = new Complex(destPixel.Real % 1, destPixel.Imaginary);

            Complex testSourcePixel = Complex.Exp(destPixel);
            double angle = testSourcePixel.Phase;
            Complex borderCrossing = FindIntersectionPoint(angle);
            Complex transformedBorder = Complex.Log(borderCrossing);

            //double xpos = (-transformedBorder.Real + destPixel.Real) % divisor.Eval(x_value).Real + transformedBorder.Real;
            //double xpos = (destPixel.Real) % divisor.Eval(x_value).Real;// + transformedBorder.Real;
            double xpos = (destPixel.Real - transformedBorder.Real) % divisor.Eval(x_value).Real + transformedBorder.Real + offset.Eval().Real;
            //if (destPixel.Real+0.01 > transformedBorder.Real && destPixel.Real - 0.01 < transformedBorder.Real)
            //{
            //    return testSourcePixel;
            //}
            //else
            //{
            //    return new Complex(0, 0);
            //}
            return Complex.Exp(new Complex(xpos, destPixel.Imaginary));
            
        }

        //public override Complex Eval(Complex x_value)
        //{
        //    // Evaluate both sides
        //    Complex destPixel = pixel.Eval(x_value);
        //    destPixel = new Complex(destPixel.Real % 1, destPixel.Imaginary);

        //    Complex testSourcePixel = Complex.Exp(destPixel);
        //    double angle = testSourcePixel.Phase;
        //    Complex borderCrossing = FindIntersectionPoint(angle);
        //    Complex transformedBorder = Complex.Log(borderCrossing);

        //    double xpos = (-transformedBorder.Real + destPixel.Real) % divisor.Eval(x_value).Real + transformedBorder.Real;

        //    return Complex.Exp(new Complex(xpos, destPixel.Imaginary));
        //    //return new Complex(sourcePixel.Real % 1,sourcePixel.Imaginary);
        //    if (destPixel.Real > transformedBorder.Real)
        //    {
        //        return testSourcePixel;
        //    }
        //    else
        //    {
        //        return new Complex(0, 0);
        //    }
        //}

        public Complex FindIntersectionPoint(double direction)
        {
            if (Math.Abs(direction) >= Math.PI)
            {
                direction = direction - Math.Sign(direction) * Math.PI * 2;
            }


            int index_above = 0;
            bool indexFoundFlag = false;
            for (int i = 0; i < Sortedcorners.Length; i++)
            {
                if (Sortedcorners[i].Phase > direction && !indexFoundFlag)
                {
                    indexFoundFlag = true;
                    index_above = i;
                }
            }
            int index_below = (index_above - 1 + Sortedcorners.Length) % (Sortedcorners.Length);


            // --- four points (two lines) --- //
            Complex boxLinePoint1 = Sortedcorners[index_below];
            Complex boxLinePoint2 = Sortedcorners[index_above];
            Complex rayCenter = new Complex(0, 0);
            Complex rayPoint = Complex.FromPolarCoordinates(1, direction);


            // --- intersection --- //
            double a1 = boxLinePoint2.Imaginary - boxLinePoint1.Imaginary;
            double b1 = boxLinePoint1.Real - boxLinePoint2.Real;
            double c1 = boxLinePoint2.Real * boxLinePoint1.Imaginary - boxLinePoint1.Real * boxLinePoint2.Imaginary;

            double a2 = rayPoint.Imaginary - rayCenter.Imaginary;
            double b2 = rayCenter.Real - rayPoint.Real;
            double c2 = rayPoint.Real * rayCenter.Imaginary - rayCenter.Real * rayPoint.Imaginary;

            double denom = a1 * b2 - a2 * b1;

            double x = (b1 * c2 - b2 * c1) / denom;
            double y = (a2 * c1 - a1 * c2) / denom;

            return new Complex(x, y);
        }
    }
}

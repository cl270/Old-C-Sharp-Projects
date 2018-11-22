using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using EVOL.NET;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;


namespace WindowsFormsApplication2
{
    public partial class Form6 : Form
    {
        public FilterInfoCollection FIC;
        public VideoCaptureDevice cam;
        public Form6()
        {
            InitializeComponent();
        }
        private static Form6 inst;
        public static Form6 instant
        {
            get
            {
                if (inst == null)
                {
                    inst = new Form6();
                }
                return inst;
            }
        }
        public UArm uarm;
        SqlConnection cnn;
        string connectionString = null;
        public double XCoor;
        public double YCoor;
        public double ZCoor;
        private void button1_Click(object sender, EventArgs e)
        {
            XCoor = uarm.findX();
            YCoor = uarm.findY();
            ZCoor = uarm.findZ();
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO KeyCoor(KeyNote) VALUES('" + comboBox1.Text + "')", cnn))
                {
                    cmd.Parameters.AddWithValue(comboBox1.Text, 1);
                    int rows = cmd.ExecuteNonQuery();
                }
                try
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE KeyCoor SET XCoor='" + XCoor + "' WHERE KeyNote='" + comboBox1.Text + "'", cnn))
                    {
                        int rows = cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("UPDATE KeyCoor SET YCoor='" + YCoor + "' WHERE KeyNote='" + comboBox1.Text + "'", cnn))
                    {
                        int rows = cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("UPDATE KeyCoor SET ZCoor='" + ZCoor + "' WHERE KeyNote='" + comboBox1.Text + "'", cnn))
                    {
                        int rows = cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Learn Suceeded: " + comboBox1.Text);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Insert (Step 2) Failed.");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Learning (Step 1) Failed");
            }

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                uarm = new UArm("COM4", false, 3800);
            }
            catch
            {
                MessageBox.Show("Unable to connect to uArm.");
            }
            try
            {
                connectionString = null;
                connectionString = "Server= G751\\SQLEXPRESS; Database= Piano; Integrated Security = SSPI; ";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
            }
            catch
            {
                MessageBox.Show("Cannot connect to SQL database");
            }
            FIC = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo WebCaptureDevice in FIC)
            {
                comboBox2.Items.Add(WebCaptureDevice.Name);
            }
            comboBox2.SelectedIndex = 0;
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
            label20.Text = "";
            label21.Text = "";
            label23.Text = "";
            label24.Text = "";
            label25.Text = "";
            label26.Text = "";
            RectangleF world_rect = new RectangleF(0, 0, pictureBox4.Width, pictureBox4.Height);
            PointF[] pts =
            {
                new PointF(0, pictureBox4.Height),
                new PointF(pictureBox4.Width, pictureBox4.Height),
                new PointF(0, 0),
            };
            DrawingTransform = new Matrix(world_rect, pts);
            InverseTransform = DrawingTransform.Clone();
            InverseTransform.Invert();
        }
        public double yprev;
        public double zprev;
        private void button2_Click(object sender, EventArgs e)
        {
            defaultposition();
            play("C3");
            play("Default");
            play("C3");
            play("Default");
            play("G3");
            play("Default");
            play("G3");
            play("Default");
            play("A4");
            play("Default");
            play("A4");
            play("Default");
            play("G3");
            play("Default");
            play("F3");
            play("Default");
            play("F3");
            play("Default");
            play("E3");
            play("Default");
            play("E3");
            play("Default");
            play("D3");
            play("Default");
            play("D3");
            play("Default");
            play("C3");
            play("Default");
            uarm.detachAll();
        }
        public void play(string note)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM KeyCoor WHERE KeyNote='" + note + "'", cnn);
                SqlDataReader Notes = null;
                Notes = cmd1.ExecuteReader();
                while (Notes.Read())
                {
                    XCoor = Convert.ToDouble(Notes["XCoor"]);
                    YCoor = Convert.ToDouble(Notes["YCoor"]);
                    ZCoor = Convert.ToDouble(Notes["ZCoor"]);
                }
                
                uarm.MoveToAtOnce(XCoor, YCoor, ZCoor);
                Notes.Close();
                Thread.Sleep(100);
            }
            catch (SqlException)
            {
                MessageBox.Show("Play Failed");
            }
        }
        public void defaultposition()
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM KeyCoor WHERE KeyNote='Default'", cnn);
                SqlDataReader Notes = null;
                Notes = cmd1.ExecuteReader();
                while (Notes.Read())
                {
                    XCoor = Convert.ToDouble(Notes["XCoor"].ToString());
                    YCoor = Convert.ToDouble(Notes["YCoor"].ToString());
                    ZCoor = Convert.ToDouble(Notes["ZCoor"].ToString());
                }
                uarm.MoveTo(XCoor, YCoor, ZCoor);
                yprev = YCoor;
                zprev = ZCoor;
                Notes.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Play Failed");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(FIC[comboBox2.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }
        public Bitmap bit;
        public int[,,] rgb = new int[1280,720,3];
        public double averageRed =0;
        public double averageGreen=0;
        public double averageBlue=0;
        
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            bit = (Bitmap)eventArgs.Frame.Clone();
            Bitmap bit2 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning)
                cam.Stop();
        }
        Bitmap myBitmap = new Bitmap(1280, 720);
        private void SetPixel()
        {
            Color c;
            for (int x = 0; x < myBitmap.Width; x++)
            {
                for (int y = 0; y < myBitmap.Height; y++)
                {
                    c = Color.FromArgb(Convert.ToInt32(rgb[x, y, 0]), Convert.ToInt32(rgb[x, y, 1]), Convert.ToInt32(rgb[x, y, 2]));
                    myBitmap.SetPixel(x, y, c);
                }
            }
            pictureBox3.Image = myBitmap;
        }
        public int mean;
        public double sigmared = 0;
        public double sigmagreen = 0;
        public double sigmablue = 0;
        private void button5_Click(object sender, EventArgs e)
        {
                int count = 0;
                Corner = new int [641,481];
                try
                {
                    cam.Stop();
                    for (int x = 0; x < bit.Width; x++)
                    {
                        for (int y = 0; y < bit.Height; y++)
                        {
                            Color pixelColor = bit.GetPixel(x, y);
                            rgb[x, y, 0] = pixelColor.R;
                            rgb[x, y, 1] = pixelColor.G;
                            rgb[x, y, 2] = pixelColor.B;
                            mean = (rgb[x, y, 0] + rgb[x, y, 0] + rgb[x, y, 0]) / 3;
                            if ((Math.Abs(rgb[x, y, 0] - mean) > 25 || Math.Abs(rgb[x, y, 1] - mean) > 25 || Math.Abs(rgb[x, y, 2] - mean) > 25) || mean < 50)
                            {
                                averageRed += Convert.ToDouble(rgb[x, y, 0]);
                                averageGreen += Convert.ToDouble(rgb[x, y, 1]);
                                averageBlue += Convert.ToDouble(rgb[x, y, 2]);
                                count++;
                            }
                        }
                    }
                    averageRed = averageRed / count;
                    averageGreen = averageGreen / count;
                    averageBlue = averageBlue / count;
                    label3.Text = averageRed.ToString();
                    label4.Text = averageGreen.ToString();
                    label5.Text = averageBlue.ToString();
                    Color c = Color.FromArgb(Convert.ToInt32(averageRed), Convert.ToInt32(averageGreen), Convert.ToInt32(averageBlue));
                    pictureBox2.BackColor = c;
                    SetPixel();
                    Gauss = new GaussianBlur(15, 5).Apply(bit);
                    pictureBox5.Image = Gauss;
                    FilterEdge(Gauss);
                    pictureBox4.Image = Edge;
                    vertices((Bitmap)pictureBox4.Image);
                    cam.Start();
                }
                catch
                {
                    MessageBox.Show("The Camera isn't on or error occured!");
                }

        }
        Bitmap Edge;
        Bitmap Gauss;
        public double[,] Edgearray = new double [1280,720];
        public void FilterEdge(Bitmap image)
        {
            Edge = new Bitmap(image.Width, image.Height);
            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                { 
                    Color cr = image.GetPixel(x + 1, y);
                    Color cl = image.GetPixel(x - 1, y);
                    Color cu = image.GetPixel(x, y - 1);
                    Color cd = image.GetPixel(x, y + 1);
                    Color clu = image.GetPixel(x - 1, y + 1);
                    Color cld = image.GetPixel(x - 1, y - 1);
                    Color cru = image.GetPixel(x + 1, y + 1);
                    Color crd = image.GetPixel(x + 1, y - 1);
                    double dx = cr.R - cl.R;
                    double dy = cd.R - cu.R;
                    double dx1 = cr.G - cr.G;
                    double dy1 = cd.G - cu.G;
                    double dx2 = cr.B - cr.B;
                    double dy2 = cd.B - cu.B;
                    double dd = clu.R - crd.R;
                    double dd1 = clu.G - crd.G;
                    double dd2 = clu.B - crd.B;
                    double ddd = cld.R - cru.R;
                    double ddd1 = cld.G - cru.G;
                    double ddd2 = cld.B - cru.B;
                    double power = Math.Sqrt((dx * dx+ dy * dy+ dx1 * dx1 + dy1 * dy1 + dx2 * dx2 + dy2 * dy2 + ddd * ddd + dd * dd+ dd1 * dd1 + dd2 * dd2 + ddd1 * ddd1 + ddd2 * ddd2) / 8);
                    if (power > 12.5)
                    {
                        Edge.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        Edge.SetPixel(x, y, Color.Black);
                    }
                }
            }
            
        }
        /*public double gaussred = 0;
        public double gaussgreen = 0;
        public double gaussblue = 0;
        public void GaussianFilter(double sigmared, double sigmagreen, double sigmablue)
        {
            Gauss = new Bitmap(bit.Width, bit.Height);
            double redkernel;
            double greenkernel;
            double bluekernel;
            Color c;
            Color sample;
            for (int x = 0; x < bit.Width; x++)
            {
                for (int y = 0; y < bit.Height; y++)
                {
                    double x1 = (x+1)-640;
                    double y1 = (y+1)-360;
                    gaussred += (1 / (2 * Math.PI * sigmared * sigmared)) * Math.Pow(Math.E, -(Math.Pow(x1, 2) + Math.Pow(y1, 2)) / (2 * Math.Pow(sigmared, 2)));
                    gaussgreen += (1 / (2 * Math.PI * sigmagreen * sigmagreen)) * Math.Pow(Math.E, -(Math.Pow(x1, 2) + Math.Pow(y1, 2)) / (2 * Math.Pow(sigmagreen, 2)));
                    gaussblue += (1 / (2 * Math.PI * sigmablue * sigmablue)) * Math.Pow(Math.E, -(Math.Pow(x1, 2) + Math.Pow(y1, 2)) / (2 * Math.Pow(sigmablue, 2)));
                    c = Color.FromArgb(Convert.ToInt32(gaussred), Convert.ToInt32(gaussgreen), Convert.ToInt32(gaussblue));
                    Gauss.SetPixel(x, y, c);
                }
            }
            redkernel = 1 / gaussred;
            greenkernel = 1 / gaussgreen;
            bluekernel = 1 / gaussblue;
            for (int x = 0; x < bit.Width; x++)
            {
                for (int y = 0; y < bit.Height; y++)
                {
                    sample = Gauss.GetPixel(x, y);
                    gaussred = sample.R * redkernel;
                    gaussgreen = sample.G * greenkernel;
                    gaussblue = sample.B * bluekernel;
                    c = Color.FromArgb(Convert.ToInt32(gaussred), Convert.ToInt32(gaussgreen), Convert.ToInt32(gaussblue));
                    Gauss.SetPixel(x, y, c);
                }
            }
        }*/
        public System.Drawing.Point coordinates;
        public System.Drawing.Point LeftC;
        public System.Drawing.Point RightC;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            coordinates = me.Location;
            if(radioButton1.Checked)
            {
                label17.Text = (coordinates.X*10/3).ToString()+", "+(coordinates.Y*10/3).ToString();
                LeftC = new System.Drawing.Point(coordinates.X, coordinates.Y);
            }
            if(radioButton2.Checked)
            {
                label18.Text = (coordinates.X*10/3).ToString() + ", " + (coordinates.Y*10/3).ToString();
                RightC = new System.Drawing.Point(coordinates.X , coordinates.Y );
            }
        }
        void Theflood(int x, int y, Color c)
        {
            int y1;
            int x1;
            for (x1 = x; x1 < Edge.Width; x1++)
            {
                if (Edge.GetPixel(x1, y).R == 0 && Edge.GetPixel(x1, y).G == 0 && Edge.GetPixel(x1, y).B == 0)
                {
                    for (y1 = y; y1 < Edge.Height; y1++)
                    {
                        if (Edge.GetPixel(x1, y1).R == 0 && Edge.GetPixel(x1, y1).G == 0 && Edge.GetPixel(x1, y1).B == 0)
                        {
                            Edge.SetPixel(x1, y1, c);
                        }
                        else
                            break;
                    }
                    for (y1 = y - 1; y1 > 0; y1--)
                    {
                        if (Edge.GetPixel(x1, y1).R == 0 && Edge.GetPixel(x, y1).G == 0 && Edge.GetPixel(x1, y1).B == 0)
                        {
                            Edge.SetPixel(x1, y1, c);
                        }
                        else
                            break;
                    }
                }
                else
                    break;
            }
            for (x1 = x-1; x1 > 0; x1--)
            {
                if (Edge.GetPixel(x1, y).R == 0 && Edge.GetPixel(x1, y).G == 0 && Edge.GetPixel(x1, y).B == 0)
                {
                    for (y1 = y; y1 < Edge.Height; y1++)
                    {
                        if (Edge.GetPixel(x1, y1).R == 0 && Edge.GetPixel(x1, y1).G == 0 && Edge.GetPixel(x1, y1).B == 0)
                        {
                            Edge.SetPixel(x1, y1, c);
                        }
                        else
                            break;
                    }
                    for (y1 = y - 1; y1 > 0; y1--)
                    {
                        if (Edge.GetPixel(x1, y1).R == 0 && Edge.GetPixel(x1, y1).G == 0 && Edge.GetPixel(x1, y1).B == 0)
                        {
                            Edge.SetPixel(x1, y1, c);
                        }
                        else
                            break;
                    }
                }
                else
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double LR=0;
            double LG=0;
            double LB=0;
            double RR=0;
            double RG=0;
            double RB=0;
            int countL=0;
            int countR=0;
            Theflood(LeftC.X, LeftC.Y, Color.Yellow);
            Theflood(RightC.X, RightC.Y, Color.Green);
            pictureBox4.Image = Edge;
            for(int x = 1; x<Edge.Width; x++)
            {
                for(int y=1; y<Edge.Height; y++)
                {
                    if(Edge.GetPixel(x,y).R == 0 && Edge.GetPixel(x, y).G == 128 && Edge.GetPixel(x, y).B == 0)
                    {
                        RR += myBitmap.GetPixel(x, y).R;
                        RG += myBitmap.GetPixel(x, y).G;
                        RB += myBitmap.GetPixel(x, y).B;
                        countR++;
                    }
                    if (Edge.GetPixel(x, y).R == 255 && Edge.GetPixel(x, y).G == 255 && Edge.GetPixel(x, y).B == 0)
                    {
                        LR += myBitmap.GetPixel(x, y).R;
                        LG += myBitmap.GetPixel(x, y).G;
                        LB += myBitmap.GetPixel(x, y).B;
                        countL++;
                    }
                }
            }
            RR = RR / countR;
            RG = RG / countR;
            RB = RB / countR;
            LR = LR / countL;
            LG = LG / countL;
            LB = LB / countL;
            label12.Text = RR.ToString();
            label11.Text = RG.ToString();
            label10.Text = RB.ToString();
            label21.Text = LR.ToString();
            label20.Text = LG.ToString();
            label19.Text = LB.ToString();
            pictureBox6.BackColor = Color.FromArgb(Convert.ToInt32(RR), Convert.ToInt32(RG), Convert.ToInt32(RB));
            pictureBox7.BackColor = Color.FromArgb(Convert.ToInt32(LR), Convert.ToInt32(LG), Convert.ToInt32(LB));
        }

        public int [,] Corner = new int [641,481];
        void vertices(Bitmap bitmap)
        {
            double count = 0;
            vertexlist.Clear();
            for (int x = 1; x < pictureBox4.Width; x++)
            {
                for (int y = 1; y < pictureBox4.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).R == 0 && bitmap.GetPixel(x, y).G == 0 && bitmap.GetPixel(x, y).B == 0)
                    {
                        if (((x < 4 && y < 4) || (x < 4 && y > pictureBox4.Height - 4) || (x > pictureBox4.Width - 4 && y < 4) || (x > pictureBox4.Width - 4 && y > pictureBox4.Height - 4)) == false)
                        {
                            if (x + 3 >= pictureBox4.Width || (bitmap.GetPixel(x + 3, y).R == 255 && bitmap.GetPixel(x + 3, y).G == 255 && bitmap.GetPixel(x + 3, y).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (x - 3 <= 0 || (bitmap.GetPixel(x - 3, y).R == 255 && bitmap.GetPixel(x - 3, y).G == 255 && bitmap.GetPixel(x - 3, y).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (y + 3 >= pictureBox4.Height || (bitmap.GetPixel(x, y + 3).R == 255 && bitmap.GetPixel(x, y + 3).G == 255 && bitmap.GetPixel(x, y + 3).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (y - 3 <= 0 || (bitmap.GetPixel(x, y - 3).R == 255 && bitmap.GetPixel(x, y - 3).G == 255 && bitmap.GetPixel(x, y - 3).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (x - 2 <= 0 || y + 1 >= pictureBox4.Height || (bitmap.GetPixel(x - 2, y + 1).R == 255 && bitmap.GetPixel(x - 2, y + 1).G == 255 && bitmap.GetPixel(x - 3, y + 1).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (x - 2 <= 0 || y - 1 <= 0 || (bitmap.GetPixel(x - 2, y - 1).R == 255 && bitmap.GetPixel(x - 2, y - 1).G == 255 && bitmap.GetPixel(x - 2, y - 1).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (x - 1 <= 0 || y + 2 >= pictureBox4.Height || (bitmap.GetPixel(x - 1, y + 2).R == 255 && bitmap.GetPixel(x - 1, y + 2).G == 255 && bitmap.GetPixel(x - 1, y + 2).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (x - 1 <= 0 || y - 2 <= 0 || (bitmap.GetPixel(x - 1, y - 2).R == 255 && bitmap.GetPixel(x - 1, y - 2).G == 255 && bitmap.GetPixel(x - 1, y - 2).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (x + 1 >= pictureBox4.Width || y + 2 >= pictureBox4.Height || (bitmap.GetPixel(x + 1, y + 2).R == 255 && bitmap.GetPixel(x + 1, y + 2).G == 255 && bitmap.GetPixel(x + 1, y + 2).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (x + 1 >= pictureBox4.Width || y - 2 <= 0 || (bitmap.GetPixel(x + 1, y - 2).R == 255 && bitmap.GetPixel(x + 1, y - 2).G == 255 && bitmap.GetPixel(x + 1, y - 2).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (x + 2 >= pictureBox4.Width || y + 1 >= pictureBox4.Height || (bitmap.GetPixel(x + 2, y + 1).R == 255 && bitmap.GetPixel(x + 2, y + 1).G == 255 && bitmap.GetPixel(x + 2, y + 1).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (x + 2 >= pictureBox4.Width || y - 1 <= 0 || (bitmap.GetPixel(x + 2, y - 1).R == 255 && bitmap.GetPixel(x + 2, y - 1).G == 255 && bitmap.GetPixel(x + 2, y - 1).B == 255))
                            {
                                Corner[x, y]++;
                            }
                            if (Corner[x, y] >= 6)
                            {
                                count++;
                                bitmap.SetPixel(x, y, Color.YellowGreen);
                                PointF[] pts = { new PointF(x, y) };
                                InverseTransform.TransformPoints(pts);
                                vertexlist.Add(pts[0]);
                            }
                        }
                    }
                }
            }
            //findtheparabola();
            //label24.Text = BestCoeffs[0].ToString();
            //label25.Text = BestCoeffs[1].ToString();
            //label26.Text = BestCoeffs[2].ToString();
            //int lx = 0;
            //int rx = 0;
            //for(double x = 1; x <= pictureBox8.Width; x++)
            //{
                //Invert parabola over x axis (ie -f(x)) since PictureBox y axis is inverted and return to positive
            //    double y = pictureBox8.Height-(BestCoeffs[2]*Math.Pow(x,2) + BestCoeffs[1]*x + BestCoeffs[0]);
            //    Gauss.SetPixel(Convert.ToInt32(x), Convert.ToInt32(y), Color.Blue);
            //    if(x == 96)
            //       lx = Convert.ToInt32(y);
            //   if(x == 288)
            //        rx = Convert.ToInt32(y);
            //}
            //LeftC = new System.Drawing.Point(96, lx);
            //RightC = new System.Drawing.Point(288, rx);
            //label17.Text = ("96, " + lx.ToString());
            //label18.Text = ("288, " + rx.ToString());
            pictureBox8.Image = bitmap;
        }
        private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        {
            System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

            for (int i = 0, n = points.Count; i < n; i++)
            {
                array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
            }

            return array;
        }
        public Bitmap invertbmp(Bitmap bmp)
        {
            Color c;
            for (int x = 1; x < bmp.Width; x++)
            {
                for (int y = 1; y < bmp.Height; y++)
                {
                    c = bmp.GetPixel(x, y);
                    c = Color.FromArgb(255 - c.R, 255 - c.G, 255-c.B);
                    bmp.SetPixel(x, y, c);
                }
            }
            return bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime Start = DateTime.Now;
            button5.PerformClick();
            button6.PerformClick();
            DateTime Stop = DateTime.Now;
            TimeSpan Elapsed = Stop - Start;
            label23.Text = ("Time Elapsed: " + Elapsed.TotalSeconds.ToString("0.00") + " seconds");
        }
        //Parabolic Fit code only Past this point
        public static List<PointF> vertexlist = new List<PointF>();
        public double[,] coefficient;
        public Matrix InverseTransform;
        public Matrix DrawingTransform;
        public static List<double> BestCoeffs;
        public void findtheparabola()
        {
            // Allocate space for (degree + 1) equations with 
            // (degree + 2) terms each (including the constant term).
            double[,] coeffs = new double[3, 4];

            // Calculate the coefficients for the equations.
            for (int j = 0; j <= 2; j++)
            {
                // Calculate the coefficients for the jth equation.

                // Calculate the constant term for this equation.
                coeffs[j, 3] = 0;
                for (int x = 0; x < vertexlist.Count; x++)
                {
                    coeffs[j, 3] -= Math.Pow(vertexlist[x].X, j) * vertexlist[x].Y;
                }

                // Calculate the other coefficients.
                for (int a_sub = 0; a_sub <= 2; a_sub++)
                {
                    // Calculate the dth coefficient.
                    coeffs[j, a_sub] = 0;
                    for (int x = 0; x < vertexlist.Count; x++)
                    {
                        coeffs[j, a_sub] -= Math.Pow(vertexlist[x].X, a_sub + j);
                    }
                }
            }

            // Solve the equations.
            double[] answer = GaussianElimination(coeffs);

            // Return the result converted into a List<double>.
            BestCoeffs = answer.ToList<double>();
        }
        private static double[] GaussianElimination(double[,] coeffs)
        {
            int max_equation = coeffs.GetUpperBound(0);
            int max_coeff = coeffs.GetUpperBound(1);
            for (int i = 0; i <= max_equation; i++)
            {
                // Use equation_coeffs[i, i] to eliminate the ith
                // coefficient in all of the other equations.

                // Find a row with non-zero ith coefficient.
                if (coeffs[i, i] == 0)
                {
                    for (int j = i + 1; j <= max_equation; j++)
                    {
                        // See if this one works.
                        if (coeffs[j, i] != 0)
                        {
                            // This one works. Swap equations i and j.
                            // This starts at k = i because all
                            // coefficients to the left are 0.
                            for (int k = i; k <= max_coeff; k++)
                            {
                                double temp = coeffs[i, k];
                                coeffs[i, k] = coeffs[j, k];
                                coeffs[j, k] = temp;
                            }
                            break;
                        }
                    }
                }

                // Make sure we found an equation with
                // a non-zero ith coefficient.
                double coeff_i_i = coeffs[i, i];
                if (coeff_i_i == 0)
                {
                    throw new ArithmeticException(String.Format(
                        "There is no unique solution for these points.",
                        coeffs.GetUpperBound(0) - 1));
                }

                // Normalize the ith equation.
                for (int j = i; j <= max_coeff; j++)
                {
                    coeffs[i, j] /= coeff_i_i;
                }

                // Use this equation value to zero out
                // the other equations' ith coefficients.
                for (int j = 0; j <= max_equation; j++)
                {
                    // Skip the ith equation.
                    if (j != i)
                    {
                        // Zero the jth equation's ith coefficient.
                        double coef_j_i = coeffs[j, i];
                        for (int d = 0; d <= max_coeff; d++)
                        {
                            coeffs[j, d] -= coeffs[i, d] * coef_j_i;
                        }
                    }
                }
            }

            // At this point, the ith equation contains
            // 2 non-zero entries:
            //      The ith entry which is 1
            //      The last entry coeffs[max_coeff]
            // This means Ai = equation_coef[max_coeff].
            double[] solution = new double[max_equation + 1];
            for (int i = 0; i <= max_equation; i++)
            {
                solution[i] = coeffs[i, max_coeff];
            }

            // Return the solution values.
            return solution;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            uarm.detachAll();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int count = 0;
            try
            {
                cam.Stop();
                for (int x = 0; x < bit.Width; x++)
                {
                    for (int y = 0; y < bit.Height; y++)
                    {
                        Color pixelColor = bit.GetPixel(x, y);
                        rgb[x, y, 0] = pixelColor.R;
                        rgb[x, y, 1] = pixelColor.G;
                        rgb[x, y, 2] = pixelColor.B;
                        mean = (rgb[x, y, 0] + rgb[x, y, 0] + rgb[x, y, 0]) / 3;
                        if ((Math.Abs(rgb[x, y, 0] - mean) > 25 || Math.Abs(rgb[x, y, 1] - mean) > 25 || Math.Abs(rgb[x, y, 2] - mean) > 25) || mean < 50)
                        {
                            averageRed += Convert.ToDouble(rgb[x, y, 0]);
                            averageGreen += Convert.ToDouble(rgb[x, y, 1]);
                            averageBlue += Convert.ToDouble(rgb[x, y, 2]);
                            count++;
                        }
                    }
                }
                averageRed = averageRed / count;
                averageGreen = averageGreen / count;
                averageBlue = averageBlue / count;
                label3.Text = averageRed.ToString();
                label4.Text = averageGreen.ToString();
                label5.Text = averageBlue.ToString();
                Color c = Color.FromArgb(Convert.ToInt32(averageRed), Convert.ToInt32(averageGreen), Convert.ToInt32(averageBlue));
                pictureBox2.BackColor = c;
                SetPixel();
                Gauss = new GaussianBlur(15, 5).Apply(bit);
                pictureBox5.Image = Gauss;
                FilterEdge(Gauss);
                pictureBox4.Image = Edge;
                vertices((Bitmap)pictureBox4.Image);
                cam.Start();
            }
            catch
            {
                MessageBox.Show("The Camera isn't on!");
            }
        }
    }
}

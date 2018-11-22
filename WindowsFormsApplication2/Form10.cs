using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows;
using System.Numerics;

namespace WindowsFormsApplication2
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private static Form10 inst;
        public static Form10 instant
        {
            get
            {
                if (inst == null || inst.IsDisposed == true)
                {
                    inst = new Form10();
                }
                return inst;
            }
        }
        public static double earthmass = 5.9722 * Math.Pow(10,24);
        public static double solmass = 333000 * earthmass;
        public static double mercurymass = 0.055 * earthmass;
        public static double venusmass = 0.815 * earthmass;
        public static double marsmass = 0.107 * earthmass;
        public static double jupitermass = 317.8 * earthmass;
        public static double saturnmass = 95.159 * earthmass;
        public static double uranusmass = 14.536 * earthmass;
        public static double neptunemass = 17.147 * earthmass;
        public static double kepler47staramass = solmass * 1.043;
        public static double kepler47starbmass = solmass * 0.362;
        public static double kepler47bmass = 8.5 * earthmass;
        public static double kepler47cmass = 20 * earthmass;
        public double [] massarray = new double[9];
        public double[] masskepler47array = new double[4];
        public double gravconstant = 6.674 * Math.Pow(10,-11);
        public Pen[] penarray = new Pen[9];
        public Pen[] penkeparray = new Pen[4];
        public double[] radiusarray = new double[9];
        public static Pen earthpen = new Pen(System.Drawing.Color.Aquamarine, 3);
        public static Pen mercurypen = new Pen(System.Drawing.Color.Brown, 3);
        public static Pen venuspen = new Pen(System.Drawing.Color.Coral, 3);
        public static Pen marspen = new Pen(System.Drawing.Color.Red, 3);
        public static Pen jupiterpen = new Pen(System.Drawing.Color.Orange, 3);
        public static Pen saturnpen = new Pen(System.Drawing.Color.PaleGoldenrod, 3);
        public static Pen uranuspen = new Pen(System.Drawing.Color.DarkSeaGreen, 3); 
        public static Pen neptunepen = new Pen(System.Drawing.Color.DarkBlue, 3);
        public static Pen solpen = new Pen(System.Drawing.Color.Yellow, 3);
        public static Pen kepcpen = new Pen(System.Drawing.Color.Green, 3);
        public static Pen kepbplanpen = new Pen(System.Drawing.Color.Blue, 3);
        public static Pen kepbstarpen = new Pen(System.Drawing.Color.Red, 3);
        public static Pen kepapen = new Pen(System.Drawing.Color.Yellow, 3);
        public static double[] screenjupsize = { 1.4507377777778 * Math.Pow(10, 9),  816.04 * Math.Pow(10, 6) };
        public static double[] screenfullsize = { 8071111111 , 4540000000};
        public double timesjup = 1000000;
        public double timesfull = 13000000;
        public double timeskep = 650000;
        public double[][] coords = new double[9][];
        public static double[] earthpos = { 0, 0 };
        public static double[] solpos = { 360, 640 };
        public static double[] mercurypos = { 0 , 0 };
        public static double[] venuspos = { 0, 0 };
        public static double[] marspos = { 0, 0 };
        public static double[] jupiterpos = { 0, 0 };
        public static double[] saturnpos = { 0, 0 };
        public static double[] uranuspos = { 0, 0 };
        public static double[] neptunepos = { 0, 0 };
        public static double[] keplerastarpos = { 0, 0 };
        public static double[] keplerbstarpos = { 0, 0 };
        public static double[] keplerbplanpos = { 0, 0 };
        public static double[] keplercplanpos = { 0, 0 };
        public Thread drawer;
        double xsin = Math.Sin(0);
        double ycos = Math.Cos(0);
        Graphics g;
        public Bitmap bmp;
        public double iterations = 0;
        public Label[] labelarray = new Label[9];
        public List<Gravity.GravObject> asteroids = new List<Gravity.GravObject>();
        public double asteroidmass = 100;
        public List<Color> asteroidcolor = new List<Color>();
        public bool resetbmp = false;
        public double track4 = 1;
        public bool zeroed = true;
        public bool ranvel = false;
        public bool waitbetweenturns = true;
        double mercurycircum = 2 * Math.PI * 57.9;
        double venuscircum = 2 * Math.PI * 108.2;
        double earthcircum = 2 * Math.PI * 149.6;
        double marscircum = 2 * Math.PI * 227.9;
        double jupitercircum = 2 * Math.PI * 778.3;
        double saturncircum = 2 * Math.PI * 1427;
        double uranuscircum = 2 * Math.PI * 2871;
        double neptunecircum = 2 * Math.PI * 4497.1;
        double keplerastarcircum = 2 * Math.PI * 123;
        double keplerbstarcircum = 2 * Math.PI * 12506382;
        double keplerbplancircum = 2 * Math.PI * 44221130.6;
        double keplercplancircum = 2 * Math.PI * 147952000;
        public bool iskep = false;
        public double[][] kepcoord = new double[4][];
        public double[] kepcprevpos = { 0, 0 };

        private void Form10_Load(object sender, EventArgs e)
        {
            radiusarray[0] = 695700;
            radiusarray[1] = 2479.7;
            radiusarray[2] = 6051.8;
            radiusarray[3] = 6371;
            radiusarray[4] = 3389.5;
            radiusarray[5] = 69911;
            radiusarray[6] = 58242;
            radiusarray[7] = 25362;
            radiusarray[8] = 24622;
            label21.Text = "0";
            label22.Text = "0";
            label24.Text = "0";
            label26.Text = "0";
            label28.Text = "0";
            label30.Text = "0";
            label32.Text = "0";
            label34.Text = "0";
            label36.Text = "0";
            labelarray[0] = label21;
            labelarray[1] = label22;
            labelarray[2] = label24;
            labelarray[3] = label26;
            labelarray[4] = label28;
            labelarray[5] = label30;
            labelarray[6] = label32;
            labelarray[7] = label34;
            labelarray[8] = label36;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromHwnd(pictureBox1.Handle);
            massarray[0] = solmass;
            massarray[1] = mercurymass;
            massarray[2] = venusmass;
            massarray[3] = earthmass;
            massarray[4] = marsmass;
            massarray[5] = jupitermass;
            massarray[6] = saturnmass;
            massarray[7] = uranusmass;
            massarray[8] = neptunemass;
            coords[0] = solpos;
            coords[1] = mercurypos;
            coords[2] = venuspos;
            coords[3] = earthpos;
            coords[4] = marspos;
            coords[5] = jupiterpos;
            coords[6] = saturnpos;
            coords[7] = uranuspos;
            coords[8] = neptunepos;
            kepcoord[0] = keplerastarpos;
            kepcoord[1] = keplerbstarpos;
            kepcoord[2] = keplerbplanpos;
            kepcoord[3] = keplercplanpos;
            penarray[0] = solpen;
            penarray[1] = mercurypen;
            penarray[2] = venuspen;
            penarray[3] = earthpen;
            penarray[4] = marspen;
            penarray[5] = jupiterpen;
            penarray[6] = saturnpen;
            penarray[7] = uranuspen;
            penarray[8] = neptunepen;
            penkeparray[0] = kepapen;
            penkeparray[1] = kepbstarpen;
            penkeparray[2] = kepbplanpen;
            penkeparray[3] = kepcpen;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp.SetPixel(640 ,360, Color.Yellow);
            bmp.SetPixel(641, 361, Color.Yellow);
            bmp.SetPixel(641, 360, Color.Yellow);
            bmp.SetPixel(641, 359, Color.Yellow);
            bmp.SetPixel(640, 361, Color.Yellow);
            bmp.SetPixel(640, 359, Color.Yellow);
            bmp.SetPixel(639, 359, Color.Yellow);
            bmp.SetPixel(639, 360, Color.Yellow);
            bmp.SetPixel(639, 361, Color.Yellow);
            double numasteroids = trackBar1.Value;
            checktrackbar();
            pictureBox1.Image = bmp;
            drawer = new Thread(simulation);
            drawer.Priority = ThreadPriority.Highest;
            drawer.IsBackground = true;
            drawer.Start();
        }
        void reset()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            if (radioButton1.Checked == false)
            {
                bmp.SetPixel(640, 360, Color.Yellow);
                bmp.SetPixel(641, 361, Color.Yellow);
                bmp.SetPixel(641, 360, Color.Yellow);
                bmp.SetPixel(641, 359, Color.Yellow);
                bmp.SetPixel(640, 361, Color.Yellow);
                bmp.SetPixel(640, 359, Color.Yellow);
                bmp.SetPixel(639, 359, Color.Yellow);
                bmp.SetPixel(639, 360, Color.Yellow);
                bmp.SetPixel(639, 361, Color.Yellow);
            }
            pictureBox1.Image = bmp;
        }
        public void simulation()
        {

            do
            {
                
                double hundred = 100;
                trackBar4.Invoke((MethodInvoker)delegate
                {
                    track4 = Convert.ToInt64(trackBar4.Value)/hundred;
                    iterations = iterations + (0.01*track4);
                });
                trackBar3.Invoke((MethodInvoker)delegate
                {
                    asteroidmass = trackBar3.Value;
                });
                if (iskep == false)
                {
                    mercurypos = orbit(mercurymass);
                    venuspos = orbit(venusmass);
                    earthpos = orbit(earthmass);
                    marspos = orbit(marsmass);
                    jupiterpos = orbit(jupitermass);
                    saturnpos = orbit(saturnmass);
                    uranuspos = orbit(uranusmass);
                    neptunepos = orbit(neptunemass);
                    coords[0] = solpos;
                    coords[1] = mercurypos;
                    coords[2] = venuspos;
                    coords[3] = earthpos;
                    coords[4] = marspos;
                    coords[5] = jupiterpos;
                    coords[6] = saturnpos;
                    coords[7] = uranuspos;
                    coords[8] = neptunepos;
                    for (int x = 1; x <= 8; x++)
                    {
                        drawPoint(coords[x], penarray[x], 1);
                    }
                }
                else
                {
                    keplerastarpos = orbit(kepler47staramass);
                    keplerbstarpos = orbit(kepler47starbmass);
                    keplerbplanpos = orbit(kepler47bmass);
                    keplercplanpos = orbit(kepler47cmass);
                    kepcoord[0] = keplerastarpos;
                    kepcoord[1] = keplerbstarpos;
                    kepcoord[2] = keplerbplanpos;
                    kepcoord[3] = keplercplanpos;
                    for (int x = 0; x <= 3; x++)
                    {
                        drawPoint(kepcoord[x], penkeparray[x], 1);
                    }
                }

                int counter = 0;
                checktrackbar();
                waitbetweenturns = false;
                foreach (Gravity.GravObject g in asteroids)
                {
                    try
                    {
                        g.Update(asteroidcolor[counter], track4);
                    }
                    finally
                    {
                        counter++;
                    }
                }
                waitbetweenturns = true;
                pictureBox1.Invoke((MethodInvoker)delegate
                {
                    pictureBox1.Image = bmp;
                });
                if (resetbmp)
                {
                    reset();
                    resetbmp = false;
                    label3.Invoke((MethodInvoker)delegate
                    {
                        label3.Text = "0";
                    });
                    label39.Invoke((MethodInvoker)delegate
                    {
                        label39.Text = "0";
                    });
                }
            } while (checkBox1.Checked);

        }

        public void checktrackbar()
        {
            trackBar1.Invoke((MethodInvoker)delegate
            {
                if (trackBar1.Value > asteroids.Count)
                {
                    for (int x = 1; x <= trackBar1.Value - asteroids.Count; x++)
                    {
                        Random s = new Random(Guid.NewGuid().GetHashCode());
                        Random t = new Random(Guid.NewGuid().GetHashCode());
                        Random randomGen = new Random(Guid.NewGuid().GetHashCode());
                        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                        KnownColor randomColorName = names[randomGen.Next(names.Length)];
                        Color randomColor = Color.FromKnownColor(randomColorName);
                        asteroidcolor.Add(randomColor);
                        asteroids.Add(new Gravity.GravObject(this, s.Next(1, 720), t.Next(1, 1280)));
                    }
                }
                else if (trackBar1.Value < asteroids.Count)
                {
                    int asteroidcountinitial = asteroids.Count;
                    for (int x = asteroidcountinitial; x > trackBar1.Value; x--)
                    {
                        asteroids.RemoveAt(x - 1);
                        asteroidcolor.RemoveAt(x - 1);
                    }
                }
            });
        }
        public double[] orbit(double planetmass)
        {
            double divider;
            if (radioButton3.Checked)
                divider = timesfull;
            else if (radioButton4.Checked)
                divider = timesjup;
            else
                divider = timeskep;
            label16.Invoke((MethodInvoker)delegate
            {
                label16.Text = Convert.ToInt32(iterations*10).ToString();
            });
            label3.Invoke((MethodInvoker)delegate
            {
                label3.Text = Convert.ToInt32(iterations * 10 * 365 / 250).ToString();
            });
            label39.Invoke((MethodInvoker)delegate
            {
                label39.Text = Convert.ToInt32(iterations * 10 / 250).ToString();
            });
            if (planetmass == mercurymass)
            {
                double semiminor = 57909050 * Math.Sqrt(1 - Math.Pow(0.20563, 2));
                double x = 640 + (semiminor * Math.Cos(iterations) / divider);
                double y = 360 + (69816900-46001200)/2/divider + (57909050 * Math.Sin(iterations) / divider);
                double[] pos = { y, x };
                return pos;
                
            }
            else if (planetmass == venusmass)
            {
                double semiminor = 108208000 * Math.Sqrt(1 - Math.Pow(0.006772, 2));
                double x = 640 + (semiminor  * Math.Cos(iterations * (35.02 / 47.87) * (mercurycircum / venuscircum)) / divider);
                double y = 360 + (108939000 - 107477000)/2/divider + (108208000  * Math.Sin(iterations * (35.02 / 47.87) * (mercurycircum / venuscircum)) / divider);
                double[] pos = { y, x };
                return pos;
            }
            else if (planetmass == earthmass)
            {
                double semiminor = 149598023 * Math.Sqrt(1 - Math.Pow(0.0167086, 2));
                double x = 640 + (semiminor * Math.Cos(iterations * (29.78 / 47.87) * (mercurycircum / earthcircum)) / divider);
                double y = 360 + (152100000 - 147095000)/ 2 / divider + (149598023 * Math.Sin(iterations * (29.78 / 47.87) * (mercurycircum / earthcircum)) / divider);
                double[] pos = { y, x };
                return pos;

            }
            else if (planetmass == marsmass)
            {
                double semiminor = 227939200 * Math.Sqrt(1 - Math.Pow(0.0934, 2));
                double x = 640 + (semiminor * Math.Cos(iterations * (24.077 / 47.87) * (mercurycircum / marscircum)) / divider);
                double y = 360 + (249200000 - 206700000)/ 2 / divider + (227939200 * Math.Sin(iterations * (24.077 / 47.87) * (mercurycircum / marscircum)) / divider);
                double[] pos = { y, x };
                return pos;
            }
            else if (planetmass == jupitermass)
            {
                double semiminor = 778299000 * Math.Sqrt(1 - Math.Pow(0.048498, 2));
                double x = 640 + (semiminor * Math.Cos(iterations * (13.07 / 47.87) * (mercurycircum / jupitercircum)) / divider);
                double y = 360 + (816040000 - 740550000) / 2 / divider + (778299000 * Math.Sin(iterations * (13.07 / 47.87) * (mercurycircum / jupitercircum)) / divider);
                double[] pos = { y, x };
                return pos;
            }
            else if (planetmass == saturnmass)
            {
                double semiminor = 1429390000 * Math.Sqrt(1 - Math.Pow(0.05555, 2));
                double x = 640 + (semiminor * Math.Cos(iterations * (9.69 / 47.87) * (mercurycircum / saturncircum)) / divider);
                double y = 360 + (1509000000 - 1350000000) / 2 / divider + (1429390000 * Math.Sin(iterations * (9.69 / 47.87) * (mercurycircum / saturncircum)) / divider);
                double[] pos = { y, x };
                return pos;
            }
            else if (planetmass == uranusmass)
            {
                double semiminor = 2875040000 * Math.Sqrt(1 - Math.Pow(0.046381, 2));
                double x = 640 + (semiminor * Math.Cos(iterations * (6.81 / 47.87) * (mercurycircum / uranuscircum)) / divider);
                double y = 360 + (3008000000 - 2742000000)/ 2 / divider + (2875040000 * Math.Sin(iterations * (6.81 / 47.87) * (mercurycircum / uranuscircum)) / divider);
                double[] pos = { y, x };
                return pos;
            }
            else if (planetmass == neptunemass)
            {
                double semiminor = 4504450000 * Math.Sqrt(1 - Math.Pow(0.009456, 2));
                double x = 640 + (semiminor * Math.Cos(iterations * (5.43 / 47.87) * (mercurycircum / neptunecircum)) / divider);
                double y = 360 + (4540000000 - 4460000000)/ 2 / divider + (4504450000 * Math.Sin(iterations * (5.43 / 47.87) * (mercurycircum / neptunecircum)) / divider);
                double[] pos = { y, x };
                return pos;
            }
            else if (planetmass == kepler47staramass)
            {
                double semimajor = 0.0836* 149598000 * (kepler47starbmass/(kepler47starbmass + kepler47staramass));
                double semiminor = semimajor * Math.Sqrt(1 - Math.Pow(0.0234, 2));
                double periapsis = semimajor * (1 - 0.0234);
                double apoapsis = semimajor * (1 + 0.0234);
                double x = 640 + (semiminor * Math.Cos(iterations * 12) / divider);
                double y = 360 + (apoapsis - periapsis) / 2 / divider + (semimajor * Math.Sin(iterations * 12) / divider);
                double[] pos = { y, x };
                return pos;
            }
            else if(planetmass == kepler47starbmass)
            {
                double semimajor = 0.0836 * 149598000 * (kepler47staramass / (kepler47starbmass + kepler47staramass));
                double semiminor = semimajor * Math.Sqrt(1 - Math.Pow(0.0234, 2));
                double periapsis = semimajor * (1 - 0.0234);
                double apoapsis = semimajor * (1 + 0.0234);
                double x = 640 - (semiminor * Math.Cos(iterations*12.5)/divider);
                double y = 360 - (apoapsis - periapsis) / 2 / divider - (semimajor * Math.Sin(iterations*12.5)/ divider);
                double[] pos = { y, x };
                return pos;
            }
            else if(planetmass == kepler47bmass)
            {
                double semimajor = 0.2956 * 149598000;
                double semiminor = semimajor * Math.Sqrt(1 - Math.Pow(0.035, 2));
                double periapsis = semimajor * (1 - 0.035);
                double apoapsis = semimajor * (1 + 0.035);
                double x = 640 + (semiminor * Math.Cos(iterations * (keplerbplancircum / keplerbstarcircum) / 2) / divider);
                double y = 360 + (apoapsis - periapsis) / 2 / divider + (semimajor * Math.Sin(iterations * (keplerbplancircum / keplerbstarcircum) / 2) / divider);
                double[] pos = { y, x };
                return pos;
            }
            else if(planetmass == kepler47cmass)
            {
                double semimajor = 0.989 * 149598000;
                double semiminor = semimajor * Math.Sqrt(1 - Math.Pow(0.411, 2));
                double periapsis = semimajor * (1 - 0.411);
                double apoapsis = semimajor * (1 + 0.411);
                double velocitymultiplier;
                double positionmultiplier;
                if (kepcprevpos[0] != 0)
                {
                    double distance = Math.Sqrt(Math.Pow(kepcprevpos[0] - 360, 2) + Math.Pow(kepcprevpos[1] - 640, 2));
                    velocitymultiplier = (Math.Sqrt(gravconstant * kepler47cmass * ((2 / distance) - (1 / semimajor)))) / 8700000;
                    positionmultiplier = (7357.37 * Math.Sqrt(((2.95905 * Math.Pow(10, 8)/distance)-1))*(distance-1.08854*Math.Pow(10,12))*Math.Atan((Math.Sqrt(((2.95905 * Math.Pow(10, 8) / distance) - 1)) * (distance - 1.08854 * Math.Pow(10, 12))) /(distance - 2.95905 * Math.Pow(10,8))))/(divider*8700000);
                }
                else
                {
                    velocitymultiplier = 1;
                    positionmultiplier = 1;
                }
                label41.Invoke((MethodInvoker)delegate
                {
                    label41.Text = velocitymultiplier.ToString();
                });
                label42.Invoke((MethodInvoker)delegate
                {
                    label42.Text = positionmultiplier.ToString();
                });
                double x = 640 + (semiminor * Math.Cos(iterations* (keplerbstarcircum / keplercplancircum)) / divider);
                double y = 360 + (apoapsis - periapsis) / 2 / divider + (semimajor * Math.Sin(iterations * (keplerbstarcircum / keplercplancircum)) / divider);
                double[] pos = { y, x };
                kepcprevpos = pos;
                return pos;
            }
            else
            {
                double[] sol = { 640, 360 };
                return sol;
            }
        }

        public void drawPoint(double[] planetpos, Pen pen, int which)
        {
            System.Drawing.Point currPoint = new System.Drawing.Point(Convert.ToInt32(planetpos[1]), Convert.ToInt32(planetpos[0]));
            double func = 0;
            double funcneg = 0;
            Color d = pen.Color;
            if (which == 1 && iskep == false)
            {
                int whichplanet = Array.IndexOf(coords, planetpos);
                double divider = 1;
                if(whichplanet == 1)
                {
                    divider = 2;
                }
                else if (whichplanet == 2)
                {
                    divider = 2* (35.02 / 47.87) * (mercurycircum / venuscircum);
                }
                else if (whichplanet == 3)
                {
                    divider = 2 * (29.78 / 47.87) * (mercurycircum / earthcircum);
                }
                else if (whichplanet == 4)
                {
                    divider = 2 * (24.077 / 47.87) * (mercurycircum / marscircum);
                }
                else if (whichplanet == 5)
                {
                    divider = 2 * (13.07 / 47.87) * (mercurycircum / jupitercircum);
                }
                else if (whichplanet == 6)
                {
                    divider = 2 * (9.69 / 47.87) * (mercurycircum / saturncircum);
                }
                else if (whichplanet == 7)
                {
                    divider = 2 * (6.81 / 47.87) * (mercurycircum / uranuscircum);
                }
                else if (whichplanet == 8)
                {
                    divider = 2 * (5.43 / 47.87) * (mercurycircum / neptunecircum);
                }

                trackBar4.Invoke((MethodInvoker)delegate
                {
                    func = -50 * Math.Cos(iterations / (Math.Log(trackBar4.Value))*divider) + 50;
                    funcneg = 50 * Math.Cos(iterations / (Math.Log(trackBar4.Value))*divider) - 50;
                });
                Color c = pen.Color;
                int r = c.R;
                int g = c.G;
                int b = c.B;
                if (c.R < 155)
                    r = c.R + Convert.ToInt32(func);
                else if (c.R > 99)
                    r = c.R + Convert.ToInt32(funcneg);
                if (c.G < 155)
                    g = c.G + Convert.ToInt32(func);
                else if (c.G > 99)
                    g = c.G + Convert.ToInt32(funcneg);
                if (c.B < 155)
                    b = c.B + Convert.ToInt32(func);
                else if (c.G > 99)
                    b = c.B + Convert.ToInt32(funcneg);
                d = Color.FromArgb(r, g, b);
                if (currPoint.X < 1280 && currPoint.Y < 720 && currPoint.X > 0 && currPoint.Y > 0)
                { 
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            bmp.SetPixel(currPoint.X + x, currPoint.Y + y, d);
                        }
                    }
                }

            }
            else if(which == 1 && iskep)
            {
                int whichplanet = Array.IndexOf(kepcoord, planetpos);
                double divider = 1;
                double semimajoraa = 0.0836 * 149598000 * (kepler47starbmass / (kepler47starbmass + kepler47staramass));
                double semimajorbb = 0.0836 * 149598000 * (kepler47staramass / (kepler47starbmass + kepler47staramass));
                double semimajorb = 0.2956 * 149598000;
                double semimajorc = 0.989 * 149598000;
                if (whichplanet == 0)
                {
                    divider = 2 * 12.5;
                }
                else if (whichplanet == 1)
                {
                    divider = 2 * 12.5 * semimajoraa/semimajorbb;
                }
                else if (whichplanet == 2)
                {
                    divider = 2 * 12.5 * 7.44837 / 49.514 * semimajoraa / semimajorb;
                }

                else if (whichplanet == 3)
                {
                    divider = 2 * 12.5 * 7.44837 / 303.158 * semimajoraa / semimajorc;
                }
                trackBar4.Invoke((MethodInvoker)delegate
                {
                    func = -50 * Math.Cos(iterations / (Math.Log(trackBar4.Value)) * divider) + 50;
                    funcneg = 50 * Math.Cos(iterations / (Math.Log(trackBar4.Value)) * divider) - 50;
                });
                Color c = pen.Color;
                int r = c.R;
                int g = c.G;
                int b = c.B;
                if (c.R < 155)
                    r = c.R + Convert.ToInt32(func);
                else if (c.R > 99)
                    r = c.R + Convert.ToInt32(funcneg);
                if (c.G < 155)
                    g = c.G + Convert.ToInt32(func);
                else if (c.G > 99)
                    g = c.G + Convert.ToInt32(funcneg);
                if (c.B < 155)
                    b = c.B + Convert.ToInt32(func);
                else if (c.G > 99)
                    b = c.B + Convert.ToInt32(funcneg);
                d = Color.FromArgb(r, g, b);
                if (currPoint.X < 1280 && currPoint.Y < 720 && currPoint.X > 0 && currPoint.Y > 0)
                {
                    if (whichplanet == 2 | whichplanet == 3)
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            for (int y = -1; y <= 1; y++)
                            {
                                bmp.SetPixel(currPoint.X + x, currPoint.Y + y, d);
                            }
                        }
                    }
                    if (whichplanet == 0 | whichplanet == 1)
                    {
                        for (int x = -2; x <= 2; x++)
                        {
                            for (int y = -2; y <= 2; y++)
                            {
                                bmp.SetPixel(currPoint.X + x, currPoint.Y + y, d);
                            }
                        }
                    }
                }

            }
            else
            {

                bmp.SetPixel(currPoint.X, currPoint.Y, d);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                drawer.Resume();
            }
            else
            {
                drawer.Suspend();
            }
        }
        public bool isfull = true;
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double hundred = 100;
            label10.Text = (Convert.ToInt64(trackBar4.Value)/hundred).ToString() + "x";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            resetbmp = true;
            isfull = false;
            iskep = false; 
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            resetbmp = true;
            isfull = true;
            iskep = false;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label5.Text = (trackBar3.Value * 1000).ToString();
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = (trackBar1.Value).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetbmp = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBar4.Value = 100;
            label10.Text = "1x";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trackBar4.Value = 2500;
            label10.Text = "25x";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trackBar4.Value = 10000;
            label10.Text = "100x";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.Elapsed += delegate { waitbetweenturns = true; };
            timer.AutoReset = false;
            timer.Start();
            SpinWait.SpinUntil(() => waitbetweenturns);
            if (trackBar1.Value < 343)
            {
                Random randomGen = new Random(Guid.NewGuid().GetHashCode());
                KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                KnownColor randomColorName = names[randomGen.Next(names.Length)];
                Color randomColor = Color.FromKnownColor(randomColorName);
                asteroidcolor.Add(randomColor);
                asteroids.Add(new Gravity.GravObject(this, MousePosition.Y - 80, MousePosition.X - 10));
                trackBar1.Value++;
                label4.Text = (Convert.ToInt32(label4.Text) + 1).ToString();
            }
            else
                MessageBox.Show("You've Reached the limit, can't add anymore asteroids.");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                resetbmp = true;
                iskep = true;
                isfull = false;
                trackBar4.Value = 100;
                label10.Text = "1x";
            }
        }
    }
}
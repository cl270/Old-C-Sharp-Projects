using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WindowsFormsApplication2
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private static Form9 inst;
        public static Form9 instant
        {
            get
            {
                if (inst == null || inst.IsDisposed == true)
                {
                    inst = new Form9();
                }
                return inst;
            }
        }
        public Bitmap maze;
        public int [,] mazearray = new int[25,25];
        public List<List<int>> mazewall = new List<List<int>>();
        public bool ismazedrawstart = false;
        int currx;
        int curry;
        private void Form9_Load(object sender, EventArgs e)
        {
            reset();
        }
        public void reset()
        {
            maze = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int y = 25; y <= 600; y = y + 25)
            {
                for (int x = 25; x <= 600; x++)
                {
                    maze.SetPixel(x, y, Color.Black);
                }
            }
            for (int x = 25; x <= 600; x = x + 25)
            {
                for (int y = 25; y <= 600; y++)
                {
                    maze.SetPixel(x, y, Color.Black);
                }
            }
            pictureBox1.Image = maze;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
            Random s = new Random(Guid.NewGuid().GetHashCode());
            Random t = new Random(Guid.NewGuid().GetHashCode());
            int initx = s.Next(1, 24);
            int inity = t.Next(1, 24);
            for(int x = -5; x<=4; x++)
            {
                for(int y = -5; y<=4; y++)
                {
                    maze.SetPixel((initx*25) + 13 + x, (inity*25) + 13 + y, Color.Green);
                }
            }
            //drawmaze(initx, inity);
            pictureBox1.Image = maze;
            ismazedrawstart = false;
        }
        public void drawmaze(int initx, int inity)
        {
            if (ismazedrawstart == false)
            {
                currx = initx;
                curry = inity;
                ismazedrawstart = true;
            }
            int direc;
            do
            {
                if(curry==1 && currx==1)
                {
                    direc = nextdir(2);

                }
                else if (curry == 1 && currx == 24)
                {
                    direc = nextdir(2);
                    if(direc == 1)
                    {

                    }
                }
                else if (curry == 24 && currx == 1)
                {
                    direc = nextdir(2);
                }
                else if (curry == 24 && currx == 24)
                {
                    direc = nextdir(2);
                }
                else if (curry == 24)
                {
                    direc = nextdir(3);
                }
                else if (curry == 1)
                {
                    direc = nextdir(3);
                }
                else if(currx == 24)
                {
                    direc = nextdir(3);
                }
                else if(currx == 1)
                {
                    direc = nextdir(3);
                }
                else
                {
                    direc = nextdir(4);
                }
            } while (drawingcomplete() == false);
        }
        public bool drawingcomplete()
        {
            foreach (List<int> box in mazewall)
            {
                if (box.Contains(0))
                    return false;
            }
            return true;
        }
        public int nextdir(int restrict)
        {
            Random u = new Random(Guid.NewGuid().GetHashCode());
            return u.Next(1, restrict);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

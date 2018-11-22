using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public int[] keeptrack = new int[11];
        public int[] possible = new int[10];
        public Form3()
        {
            InitializeComponent();
        }
        private static Form3 inst;
        public static Form3 instant
        {
            get
            {
                if (inst == null)
                {
                    inst = new Form3();
                }
                return inst;
            }
        }
        public void picturesload(string[] deck, int[] suite, int[] rank, string[] suitestring)
        {
            Label[] labarray = new Label[6];
            labarray[1] = label7;
            labarray[2] = label8;
            labarray[3] = label9;
            labarray[4] = label10;
            labarray[5] = label11;
            if (labarray[1].Text != "Hold")
            {
                pictureBox1.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[1] + "" + rank[1].ToString() + ".rle");
                label13.Text = deck[((suite[1] - 1) * 13) + rank[1] - 1];
            }
            if (labarray[2].Text != "Hold")
            {
                pictureBox2.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[2] + "" + rank[2].ToString() + ".rle");
                label14.Text = deck[((suite[2] - 1) * 13) + rank[2] - 1];
            }
            if (labarray[3].Text != "Hold")
            {
                pictureBox3.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[3] + "" + rank[3].ToString() + ".rle");
                label15.Text = deck[((suite[3] - 1) * 13) + rank[3] - 1];
            }
            if (labarray[4].Text != "Hold")
            {
                pictureBox4.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[4] + "" + rank[4].ToString() + ".rle");
                label16.Text = deck[((suite[4] - 1) * 13) + rank[4] - 1];
            }
            if (labarray[5].Text != "Hold")
            {
                pictureBox5.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[5] + "" + rank[5].ToString() + ".rle");
                label17.Text = deck[((suite[5] - 1) * 13) + rank[5] - 1];
            }
        }

        public void poker(int showpic)
        {
            int[,] deckcheck = new int[5, 14];
            int[] suite = new int[6];
            int[] rank = new int[6];
            int i = 1;
            string[] suitestring = new string[6];
            Label[] labarray = new Label[6];
            labarray[1] = label7;
            labarray[2] = label8;
            labarray[3] = label9;
            labarray[4] = label10;
            labarray[5] = label11;
            Label[] labarray2 = new Label[6];
            labarray2[1] = label13;
            labarray2[2] = label14;
            labarray2[3] = label15;
            labarray2[4] = label16;
            labarray2[5] = label17;
            int suitehold;
            int rankhold;
            string[] deck = new string[]
                { "Ace of Clubs", "2 of Clubs", "3 of Clubs", "4 of Clubs", "5 of Clubs", "6 of Clubs", "7 of Clubs", "8 of Clubs", "9 of Clubs", "10 of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",
                 "Ace of Diamonds", "2 of Diamonds", "3 of Diamonds", "4 of Diamonds", "5 of Diamonds", "6 of Diamonds", "7 of Diamonds", "8 of Diamonds", "9 of Diamonds", "10 of Diamonds", "Jack of Diamonds", "Queen of Diamonds", "King of Diamonds",
                 "Ace of Hearts", "2 of Hearts", "3 of Hearts", "4 of Hearts", "5 of Hearts", "6 of Hearts", "7 of Hearts", "8 of Hearts", "9 of Hearts", "10 of Hearts", "Jack of Hearts", "Queen of Hearts", "King of Hearts",
                 "Ace of Spades", "2 of Spades", "3 of Spades", "4 of Spades", "5 of Spades", "6 of Spades", "7 of Spades", "8 of Spades", "9 of Spades", "10 of Spades", "Jack of Spades", "Queen of Spades", "King of Spades"};
            while (i <= 5)
            {
                if (labarray[i].Text == "Hold")
                {
                    suitehold = (Array.IndexOf(deck, labarray2[i].Text)) / 13;
                    rankhold = (Array.IndexOf(deck, labarray2[i].Text)) % 13;
                    suite[i] = suitehold + 1;
                    rank[i] = rankhold + 1;
                    deckcheck[suite[i], rank[i]] = 1;
                }
                i++;
            }
            i = 1;
            while (i <= 5)
            {
                if (labarray[i].Text == "Hold" && deckcheck[suite[i], rank[i]] == 1)
                {
                    i++;
                    continue;
                }
                Random s = new Random(Guid.NewGuid().GetHashCode()); ;
                suite[i] = s.Next(1, 5);
                Random r = new Random(Guid.NewGuid().GetHashCode()); ;
                rank[i] = r.Next(1, 14);
                if (deckcheck[suite[i], rank[i]] == 0)
                {
                    deckcheck[suite[i], rank[i]] = 1;
                    if (suite[i] == 1)
                    {
                        suitestring[i] = "C";
                    }
                    else if (suite[i] == 2)
                    {
                        suitestring[i] = "D";
                    }
                    else if (suite[i] == 3)
                    {
                        suitestring[i] = "H";
                    }
                    else if (suite[i] == 4)
                    {
                        suitestring[i] = "S";
                    }
                    i++;
                }

            }
            int royalflushclub = deckcheck[1, 13] + deckcheck[1, 12] + deckcheck[1, 11] + deckcheck[1, 10] + deckcheck[1, 1];
            int royalflushdiamond = deckcheck[2, 13] + deckcheck[2, 12] + deckcheck[2, 11] + deckcheck[2, 10] + deckcheck[2, 1];
            int royalflushheart = deckcheck[3, 13] + deckcheck[3, 12] + deckcheck[3, 11] + deckcheck[3, 10] + deckcheck[3, 1];
            int royalflushspade = deckcheck[4, 13] + deckcheck[4, 12] + deckcheck[4, 11] + deckcheck[4, 10] + deckcheck[4, 1];
            int flushclub = 0;
            int flushdiamond = 0;
            int flushheart = 0;
            int flushspade = 0;
            int kind4 = 0;
            int kind3 = 0;
            int kind2 = 0;
            int kindfh = 0;
            int[] sum = new int[14];
            for (int n = 1; n <= 13; n++)
            {
                flushclub += deckcheck[1, n];
                flushdiamond += deckcheck[2, n];
                flushheart += deckcheck[3, n];
                flushspade += deckcheck[4, n];
                for (int p = 1; p <= 4; p++)
                {
                    sum[n] += deckcheck[p, n];
                }
            }
            if (sum.Contains(4))
            {
                kind4++;
            }
            else if (sum.Contains(3))
            {
                kind3++;
                if (sum.Contains(2))
                    kindfh++;
            }
            else if (sum.Contains(2))
            {
                kind2++;
                sum[Array.IndexOf(sum, 2)] = 0;
                if (sum.Contains(2))
                {
                    kind2++;
                }
            }
            int[] res = new int[37];
            int[] str = new int[10];
            int j = 0;
            for (int b = 0; b < deckcheck.Length; b++)
            {
                for (int k = 1; k <= 4; k++)
                {
                    if (b + 1 < 10)
                    {
                        res[j] = deckcheck[k, b] + deckcheck[k, b + 1] + deckcheck[k, b + 2] + deckcheck[k, b + 3] + deckcheck[k, b + 4];
                    }
                    j++;
                }
            }
            //
            if (showpic == 1)
            {
                picturesload(deck, suite, rank, suitestring);
                if (kindfh == 1)
                {
                    label18.Text = "Full House";
                }
                else if (kind2 == 1)
                {
                    label18.Text = "Two of a Kind";
                }
                else if (kind2 == 2)
                {
                    label18.Text = "Double Two of a Kind";
                }
                else if (kind3 == 1)
                {
                    label18.Text = "Three of a Kind";
                }
                else if (kind4 == 1)
                {
                    label18.Text = "Four of a Kind";
                }
                else if (royalflushspade == 5 | royalflushdiamond == 5 | royalflushheart == 5 | royalflushclub == 5)
                {
                    label18.Text = "Royal Flush";
                }
                else if (res.Contains(5))
                {
                    label18.Text = "Straight Flush";
                    flushclub = 0;
                    flushdiamond = 0;
                    flushheart = 0;
                    flushspade = 0;
                }
                else if (rank.Max() - rank.OrderBy(num => num).ElementAt(1) == 4)
                {
                    label18.Text = "Straight";
                }
                else if (flushclub == 5 | flushdiamond == 5 | flushheart == 5 | flushspade == 5)
                {
                    label18.Text = "Flush";
                }
                else
                {
                    label18.Text = "High Card";
                }
            }
            else if (showpic == 0)
            {

                if (kindfh == 1)
                {
                    keeptrack[5]++;
                }
                else if (kind2 == 1)
                {
                    keeptrack[2]++;
                }
                else if (kind2 == 2)
                {
                    keeptrack[6]++;
                }
                else if (kind3 == 1)
                {
                    keeptrack[3]++;
                }
                else if (kind4 == 1)
                {
                    keeptrack[4]++;
                }
                else if (royalflushspade == 5 | royalflushdiamond == 5 | royalflushheart == 5 | royalflushclub == 5)
                {
                    keeptrack[10]++;
                }
                else if (res.Contains(5))
                {
                    keeptrack[9]++;
                    flushclub = 0;
                    flushdiamond = 0;
                    flushheart = 0;
                    flushspade = 0;
                }
                else if (rank.Max() - rank.OrderBy(num => num).ElementAt(1) == 4)
                {
                    keeptrack[7]++;
                }
                else if (flushclub == 5 | flushdiamond == 5 | flushheart == 5 | flushspade == 5)
                {
                    keeptrack[8]++;
                }
                else
                {
                    keeptrack[1]++;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            poker(1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label7.Text != "Hold")
            {
                label7.Text = "Hold";
            }
            else
            {
                label7.Text = "";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (label8.Text != "Hold")
            {
                label8.Text = "Hold";
            }
            else
            {
                label8.Text = "";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (label9.Text != "Hold")
            {
                label9.Text = "Hold";
            }
            else
            {
                label9.Text = "";
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (label10.Text != "Hold")
            {
                label10.Text = "Hold";
            }
            else
            {
                label10.Text = "";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (label11.Text != "Hold")
            {
                label11.Text = "Hold";
            }
            else
            {
                label11.Text = "";
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { 
            int iterations = Int32.Parse(textBox3.Text);
            int counter = 1;
            Array.Clear(keeptrack, 0, keeptrack.Length);
            while (counter <= iterations)
            {
                poker(0);
                counter++;
            }
            //HC=1,P=2,3K=3,4K=4,FH=5,2P=6,S=7,F=8,SF=9,RF=10
            label19.Text = "High Cards:" + (keeptrack[1]).ToString() + " " + (decimal.Divide(keeptrack[1], iterations) * 100).ToString() + "%";
            label21.Text = "Pair:" + (keeptrack[2]).ToString() + " " + (decimal.Divide(keeptrack[2], iterations) * 100).ToString() + "%";
            label22.Text = "Three of a Kind:" + (keeptrack[3]).ToString() + " " + (decimal.Divide(keeptrack[3], iterations) * 100).ToString() + "%";
            label23.Text = "Four of a Kind:" + (keeptrack[4]).ToString() + " " + (decimal.Divide(keeptrack[4], iterations) * 100).ToString() + "%";
            label24.Text = "Full House:" + (keeptrack[5]).ToString() + " " + (decimal.Divide(keeptrack[5], iterations) * 100).ToString() + "%";
            label25.Text = "Double Pair:" + (keeptrack[6]).ToString() + " " + (decimal.Divide(keeptrack[6], iterations) * 100).ToString() + "%";
            label26.Text = "Straight:" + (keeptrack[7]).ToString() + " " + (decimal.Divide(keeptrack[7], iterations) * 100).ToString() + "%";
            label27.Text = "Flush:" + (keeptrack[8]).ToString() + " " + (decimal.Divide(keeptrack[8], iterations) * 100).ToString() + "%";
            label28.Text = "Straight Flush:" + (keeptrack[9]).ToString() + " " + (decimal.Divide(keeptrack[9], iterations) * 100).ToString() + "%";
            label29.Text = "Royal Flush:" + (keeptrack[10]).ToString() + " " + (decimal.Divide(keeptrack[10], iterations) * 100).ToString() + "%";
            label30.Text = "Total Hands:" + (iterations).ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\Back.rle");
            pictureBox2.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\Back.rle");
            pictureBox3.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\Back.rle");
            pictureBox4.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\Back.rle");
            pictureBox5.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\Back.rle");
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
            label21.Text = "";
            label22.Text = "";
            label23.Text = "";
            label24.Text = "";
            label25.Text = "";
            label26.Text = "";
            label27.Text = "";
            label28.Text = "";
            label29.Text = "";
            label30.Text = "";
            label31.Text = "";
        }
    }
}

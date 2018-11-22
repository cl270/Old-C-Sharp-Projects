using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form8 : Form
    {
        public int[] ohthehumanity = new int[27];
        public int[] ai1 = new int[27];
        public int[] ai2 = new int[27];
        public int[] ai3 = new int[27];
        public int[][] ai = new int[4][];
        public Label[] labarray;
        public Label[] labarray1;
        public Label[] labarray2;
        public Label[] labarray3;
        public Label[] labarray4;
        public PictureBox[] pbarray1;
        public PictureBox[] pbarray2;
        public int[,] deckcheck = new int[5, 14];
        public int[] rank = new int[53];
        public int playcardnumber = 0;
        public string previous;
        List<int> poolsuite = new List<int>();
        List<int> poolrank = new List<int>();
        List<int> oldpoolsuite = new List<int>();
        List<int> oldpoolrank = new List<int>();
        public string[] deck = new string[]
                { "Ace of Clubs", "2 of Clubs", "3 of Clubs", "4 of Clubs", "5 of Clubs", "6 of Clubs", "7 of Clubs", "8 of Clubs", "9 of Clubs", "10 of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",
                 "Ace of Diamonds", "2 of Diamonds", "3 of Diamonds", "4 of Diamonds", "5 of Diamonds", "6 of Diamonds", "7 of Diamonds", "8 of Diamonds", "9 of Diamonds", "10 of Diamonds", "Jack of Diamonds", "Queen of Diamonds", "King of Diamonds",
                 "Ace of Hearts", "2 of Hearts", "3 of Hearts", "4 of Hearts", "5 of Hearts", "6 of Hearts", "7 of Hearts", "8 of Hearts", "9 of Hearts", "10 of Hearts", "Jack of Hearts", "Queen of Hearts", "King of Hearts",
                 "Ace of Spades", "2 of Spades", "3 of Spades", "4 of Spades", "5 of Spades", "6 of Spades", "7 of Spades", "8 of Spades", "9 of Spades", "10 of Spades", "Jack of Spades", "Queen of Spades", "King of Spades"};
        public int[] sortsuite = new int[14];
        public int[] sortrank = new int[14];
        public bool gameended = false;
        public string[] suitestring = new string[53];
        public int turn;
        bool straightcheck = false;
        bool flushcheck = false;
        public int pass = 3;
        public double responsetime = 1;
        public int[] airank = new int[14];
        public int[] aisuite = new int[14];
        public bool[] aifirstturn = new bool[] { true, true, true };
        int[] moderank = new int[14];
        int[] straightsacrifice = new int[14];
        int[] modesuite = new int[5];
        int[] tally;
        int[][] aicardimportancearray = new int[4][];
        int[] cardimportance = new int[14];
        int[] cardimportance2 = new int[14];
        int[] cardimportance3 = new int[14];
        List<List<int[]>> listofarraysinlist = new List<List<int[]>>();
        List<int[]> arraysinlist = new List<int[]>();
        List<int[]> arraysinlist2 = new List<int[]>();
        List<int[]> arraysinlist3 = new List<int[]>();
        public Form8()
        {
            InitializeComponent();
        }
        private static Form8 inst;
        public static Form8 instant
        {
            get
            {
                if (inst == null || inst.IsDisposed == true)
                {
                    inst = new Form8();
                }
                return inst;
            }
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            label1.Text = "13";
            label2.Text = "13";
            label3.Text = "13";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
            label20.Text = "";
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
            label32.Text = "";
            label33.Text = "";
            label34.Text = "";
            label35.Text = "";
            label36.Text = "";
            label37.Text = "CPU #1 Cards Left:";
            label38.Text = "CPU #2 Cards Left:";
            label39.Text = "CPU #3 Cards Left:";
            label40.Text = "Turn";
            label41.Text = "Turn";
            label42.Text = "Turn";
            label43.Text = "Turn";
            label40.ForeColor = Color.FromArgb(255, 0, 0);
            label41.ForeColor = Color.FromArgb(255, 0, 0);
            label42.ForeColor = Color.FromArgb(255, 0, 0);
            label43.ForeColor = Color.FromArgb(255, 0, 0);
            label44.Text = "Played Card Display Time";
            label45.Text = "1.5 Seconds";
            pictureBox1.Image =  new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox2.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox3.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox4.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox5.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox6.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox7.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox8.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox9.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox10.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox11.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox12.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox13.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox14.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox15.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox16.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox17.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pictureBox18.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
            pass = 3;
            label46.Text = pass.ToString();
            listofarraysinlist.Add(arraysinlist);
            listofarraysinlist.Add(arraysinlist2);
            listofarraysinlist.Add(arraysinlist3);
            clearitout();
        }
        void clearitout()
        {
            labarray = new Label[14];
            labarray[1] = label4;
            labarray[2] = label5;
            labarray[3] = label6;
            labarray[4] = label7;
            labarray[5] = label8;
            labarray[6] = label9;
            labarray[7] = label10;
            labarray[8] = label11;
            labarray[9] = label12;
            labarray[10] = label13;
            labarray[11] = label14;
            labarray[12] = label15;
            labarray[13] = label16;
            labarray2 = new Label[14];
            labarray2[1] = label17;
            labarray2[2] = label18;
            labarray2[3] = label19;
            labarray2[4] = label20;
            labarray2[5] = label21;
            labarray2[6] = label22;
            labarray2[7] = label23;
            labarray2[8] = label24;
            labarray2[9] = label25;
            labarray2[10] = label26;
            labarray2[11] = label27;
            labarray2[12] = label28;
            labarray2[13] = label29;
            labarray3 = new Label[6];
            labarray3[1] = label31;
            labarray3[2] = label32;
            labarray3[3] = label33;
            labarray3[4] = label34;
            labarray3[5] = label35;
            pbarray1 = new PictureBox[14];
            pbarray1[1] = pictureBox1;
            pbarray1[2] = pictureBox2;
            pbarray1[3] = pictureBox3;
            pbarray1[4] = pictureBox4;
            pbarray1[5] = pictureBox5;
            pbarray1[6] = pictureBox6;
            pbarray1[7] = pictureBox7;
            pbarray1[8] = pictureBox8;
            pbarray1[9] = pictureBox9;
            pbarray1[10] = pictureBox10;
            pbarray1[11] = pictureBox11;
            pbarray1[12] = pictureBox12;
            pbarray1[13] = pictureBox13;
            pbarray2 = new PictureBox[6];
            pbarray2[1] = pictureBox14;
            pbarray2[2] = pictureBox15;
            pbarray2[3] = pictureBox16;
            pbarray2[4] = pictureBox17;
            pbarray2[5] = pictureBox18;
            aicardimportancearray[1] = cardimportance;
            aicardimportancearray[2] = cardimportance2;
            aicardimportancearray[3] = cardimportance3;
            labarray1 = new Label[4];
            labarray1[1] = label1;
            labarray1[2] = label2;
            labarray1[3] = label3;
        }

        public void sort()
        {

            if (radioButton1.Checked)
            {
                Array.Sort(sortsuite, sortrank);
                suiteinttostring(sortsuite, suitestring, 13);
                for (int x = 1; x <= 13; x++)
                {
                    ohthehumanity[2 * x - 1] = sortsuite[x];
                    ohthehumanity[2 * x] = sortrank[x];
                }
            }
            if (radioButton2.Checked)
            {
                Array.Sort(sortrank, sortsuite);
                suiteinttostring(sortsuite, suitestring, 13);
                for (int x = 1; x <= 13; x++)
                {
                    ohthehumanity[2 * x - 1] = sortsuite[x];
                    ohthehumanity[2 * x] = sortrank[x];

                }
            }
            picturesload(deck, sortsuite, sortrank, suitestring);
        }
        public void deal()
        {
            clearitout();
            deckcheck = new int[5, 14];
            int[] suite = new int[53];
            rank = new int[53];
            int i = 1;
            while (i <= 52)
            {
                Random s = new Random(Guid.NewGuid().GetHashCode()); ;
                suite[i] = s.Next(1, 5);
                Random r = new Random(Guid.NewGuid().GetHashCode()); ;
                rank[i] = r.Next(1, 14);
                if (deckcheck[suite[i], rank[i]] == 0)
                {
                    deckcheck[suite[i], rank[i]] = 1;
                    i++;
                }
            }

            for(int x = 1; x<=13; x++)
            {
                ai1[2 * x - 1] = suite[x+13];
                ai1[2 * x] = rank[x+13];
                ai2[2 * x - 1] = suite[x+26];
                ai2[2 * x] = rank[x+26];
                ai3[2 * x - 1] = suite[x+39];
                ai3[2 * x] = rank[x+39];
                sortrank[x] = rank[x];
                sortsuite[x] = suite[x];
            }
            ai[1] = ai1;
            ai[2] = ai2;
            ai[3] = ai3;
            sort();
            for(int x = 1; x<=52; x++)
            {
                if (checkBox1.Checked)
                    turn = 1;
                else if (suite[x] == 1 && rank[x] == 3)
                {
                    turn = (x / 13)+1;
                }
            }
            if (turn == 1)
                label40.Visible = true;
            else if (turn == 2)
            {
                label41.Visible = true;
                button1.Enabled = false;
                button2.Enabled = false;
                aiplayer(1);
            }
            else if (turn == 3)
            {
                label42.Visible = true;
                button1.Enabled = false;
                button2.Enabled = false;
                aiplayer(2);
            }
            else if (turn == 4)
            {
                label43.Visible = true;
                button1.Enabled = false;
                button2.Enabled = false;
                aiplayer(3);
            }

        }
        public void suiteinttostring(int [] suite, string [] suitestring, int descriptor)
        {

            for (int i = 1; i <= descriptor; i++)
            {
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
            }
        }
        public void picturesload(string[] deck, int[] suite, int[] rank, string[] suitestring)
        {
        
                pictureBox1.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[1] + "" + rank[1].ToString() + ".rle");
                label17.Text = deck[((suite[1] - 1) * 13) + rank[1] - 1];

                pictureBox2.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[2] + "" + rank[2].ToString() + ".rle");
                label18.Text = deck[((suite[2] - 1) * 13) + rank[2] - 1];

                pictureBox3.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[3] + "" + rank[3].ToString() + ".rle");
                label19.Text = deck[((suite[3] - 1) * 13) + rank[3] - 1];

                pictureBox4.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[4] + "" + rank[4].ToString() + ".rle");
                label20.Text = deck[((suite[4] - 1) * 13) + rank[4] - 1];

                pictureBox5.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[5] + "" + rank[5].ToString() + ".rle");
                label21.Text = deck[((suite[5] - 1) * 13) + rank[5] - 1];

                pictureBox6.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[6] + "" + rank[6].ToString() + ".rle");
                label22.Text = deck[((suite[6] - 1) * 13) + rank[6] - 1];

                pictureBox7.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[7] + "" + rank[7].ToString() + ".rle");
                label23.Text = deck[((suite[7] - 1) * 13) + rank[7] - 1];

                pictureBox8.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[8] + "" + rank[8].ToString() + ".rle");
                label24.Text = deck[((suite[8] - 1) * 13) + rank[8] - 1];

                pictureBox9.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[9] + "" + rank[9].ToString() + ".rle");
                label25.Text = deck[((suite[9] - 1) * 13) + rank[9] - 1];
            
                pictureBox10.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[10] + "" + rank[10].ToString() + ".rle");
                label26.Text = deck[((suite[10] - 1) * 13) + rank[10] - 1];

                pictureBox11.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[11] + "" + rank[11].ToString() + ".rle");
                label27.Text = deck[((suite[11] - 1) * 13) + rank[11] - 1];

                pictureBox12.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[12] + "" + rank[12].ToString() + ".rle");
                label28.Text = deck[((suite[12] - 1) * 13) + rank[12] - 1];

                pictureBox13.Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + suitestring[13] + "" + rank[13].ToString() + ".rle");
                label29.Text = deck[((suite[13] - 1) * 13) + rank[13] - 1];
            
        }
        public bool strflu = false;
        public bool validplay(List<int> poolrank, List<int> poolsuite, List<int> oldpoolrank, List<int> oldpoolsuite)
        {
            int[] modenew = new int[14];
            int[] modeold = new int[14];
            foreach (int x in poolrank)
            {
                modenew[x]++;
            }
            foreach (int x in oldpoolrank)
            {
                modeold[x]++;
            }
            poolrank.Sort();
            if (pass >= 3)
            {
                pass = 0;
                label46.Text = pass.ToString();
                return true;
            }
            if (poolsuite.Count() != oldpoolsuite.Count())
                return false;
            if (poolrank.Count() == 5)
            {
                if (poolrank[0] == poolrank[1] - 1 && poolrank[1] == poolrank[2] - 1 && poolrank[2] == poolrank[3] - 1 && poolrank[3] == poolrank[4] - 1 && poolsuite[0] == poolsuite[1] && poolsuite[2] == poolsuite[1] && poolsuite[2] == poolsuite[3] && poolsuite[3] == poolsuite[4])
                {
                    oldpoolrank.Sort();
                    if (oldpoolsuite.Min() == oldpoolsuite.Max() && (oldpoolrank.Max() - oldpoolrank.Min() == 4 || (oldpoolrank[0] == 1 && oldpoolrank[1] == 10 && oldpoolrank[2] == 11 && oldpoolrank[3] == 12 && oldpoolrank[4] == 13)))
                    {
                        if (poolsuite[0] > oldpoolsuite[0])
                        {
                            if (poolsuite.Contains(1) && poolsuite.Contains(13))
                                label36.Text = "Royal Flush";
                            else
                                label36.Text = "Straight Flush";
                            strflu = true;
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
            
            if (modenew.Max() > modeold.Max() && modenew.Max()==4 && strflu == false)
            {
                label36.Text = "Four of a Kind";
                return true;
            }

            if (oldpoolrank.Count() == poolrank.Count() && modeold.Max() != 4 && strflu == false)
            {
                if (poolrank.Count() == 1)
                {
                    if (poolrank[0] == oldpoolrank[0])
                    {
                        if (poolsuite[0] > oldpoolsuite[0])
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                    else if (poolrank[0] > oldpoolrank[0] && oldpoolrank[0] >= 3)
                    {
                        return true;

                    }
                    else if (poolrank[0] == 2)
                        return true;
                    else if (poolrank[0] == 1 && oldpoolrank[0] != 2)
                        return true;
                    else
                        return false; 
                }
                if (poolrank.Count() == 2 && poolrank[0] == poolrank[1])
                {
                    if (poolrank[0] == oldpoolrank[0] )
                    {
                        if (poolsuite.Contains(4))
                        {
                            label36.Text = "Pair";
                            return true;
                        }
                        else
                            return false;
                    }
                    else if ((poolrank[0] > oldpoolrank[0] && oldpoolrank[0] >= 3) || (poolrank[0] == 1 && oldpoolrank[0] != 2) || poolrank[0] == 2)
                    {
                        label36.Text = "Pair";
                        return true;
                    }

                    else
                        return false;
                }
                if (poolrank.Count() == 3 && (poolrank[0] == poolrank[1] && poolrank[1] == poolrank[2]))
                {
                    if ((poolrank[0] > oldpoolrank[0] && oldpoolrank[0] >= 3) || (poolrank[0] == 1 && oldpoolrank[0] != 2) || poolrank[0] == 2)
                    {
                        label36.Text = "Three of a Kind";
                        return true;
                    }
                    else
                        return false;
                }
                else if (poolrank.Count() == 5)
                {
                    if (modenew.Contains(3) && modenew.Contains(2))
                    {
                        if (modeold.Max() == 3 && modeold.Contains(2))
                        {
                            if (Array.IndexOf(modenew, 3) > Array.IndexOf(modeold, 3) || Array.IndexOf(modenew, 3) == 2 || Array.IndexOf(modenew, 3) == 1 && Array.IndexOf(modeold, 3) != 2)
                            {
                                label36.Text = "Full House";
                                return true;
                            }
                            else
                                return false;
                        }
                        else
                        {
                            label36.Text = "Full House";
                            return true;
                        }
                    }
                    else if (poolsuite[0] == poolsuite[1] && poolsuite[2] == poolsuite[1] && poolsuite[2] == poolsuite[3] && poolsuite[3] == poolsuite[4] && modeold.Max() != 3 && modeold.Min() != 2)
                    {
                        if (modeold.Max() == 3 && modeold.Min() == 2)
                        {
                            return false;
                        }
                        else if (oldpoolsuite[0] == oldpoolsuite[1] && oldpoolsuite[1] == oldpoolsuite[2] && oldpoolsuite[2] == oldpoolsuite[3] && oldpoolsuite[3] == oldpoolsuite[4])
                        {
                            if (poolsuite[0] > oldpoolsuite[0])
                            {
                                label36.Text = "Flush";
                                return true;
                            }
                            else if (poolsuite[0] == oldpoolsuite[0])
                            {
                                if (poolrank.Max() > oldpoolrank.Max())
                                {
                                    label36.Text = "Flush";
                                    return true;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else
                        {
                            label36.Text = "Flush";
                            return true;
                        }
                    }

                    else if (modeold.Max() != 3 && modeold.Min() != 2 && (oldpoolsuite[0] != oldpoolsuite[1] && oldpoolsuite[1] != oldpoolsuite[2] && oldpoolsuite[2] != oldpoolsuite[3] && oldpoolsuite[3] != oldpoolsuite[4]))
                    {
                        if (modeold.Max() == 3 && modeold.Min() == 2)
                        {
                            return false;
                        }
                        else if (oldpoolsuite[0] == oldpoolsuite[1] && oldpoolsuite[1] == oldpoolsuite[2] && oldpoolsuite[2] == oldpoolsuite[3] && oldpoolsuite[4] == oldpoolsuite[5])
                        {
                            return false;
                        }
                        else if (poolrank[0] == poolrank[1] - 1 && poolrank[1] == poolrank[2] - 1 && poolrank[2] == poolrank[3] - 1 && poolrank[3] == poolrank[4] - 1 || (poolrank.Contains(10) && poolrank.Contains(11)&& poolrank.Contains(12)& poolrank.Contains(13)&& poolrank.Contains(1)))
                        {
                            if (oldpoolrank[0] < poolrank[0])
                            {
                                label36.Text = "Straight";
                                return true;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            straightcheck = false;
            flushcheck = false;
            int count = 0;
            if (legitplay(ohthehumanity))
            {
                poolsuite.Clear();
                poolrank.Clear();
                for (int x = 1; x <= 13; x++)
                {
                    if (labarray[x].Text == "Play Card")
                    {
                        poolsuite.Add(ohthehumanity[2 * x - 1]);
                        poolrank.Add(ohthehumanity[2 * x]);
                        count++;
                    }
                }
                if (validplay(poolrank, poolsuite, oldpoolrank, oldpoolsuite))
                {
                    cleartable();
                    pass = 0;
                    label46.Text = pass.ToString();
                    for (int x = 1; x <= 13; x++)
                    {
                        if (labarray[x].Text == "Play Card")
                        {
                            ohthehumanity[2 * x - 1] = 0;
                            ohthehumanity[2 * x] = 0;
                            labarray[x].Text = "";
                            labarray2[x].Text = "";
                            pbarray1[x].Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\BACK.rle");
                        }
                    }

                    string[] privsuitestring = new string[poolsuite.Count + 1];
                    int[] poolsuite2 = new int[poolsuite.Count + 1];
                    for (int x = 1; x <= poolsuite.Count; x++)
                    {
                        poolsuite2[x] = poolsuite[x - 1];
                        suiteinttostring(poolsuite2, privsuitestring, poolsuite.Count());
                        pbarray2[x].Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + privsuitestring[x] + "" + poolrank[x - 1].ToString() + ".rle");
                        labarray3[x].Text = deck[((poolsuite[x - 1] - 1) * 13) + poolrank[x - 1] - 1];
                    }
                    if (ohthehumanity.Sum() == 0)
                    {
                        gameended = true;
                        DialogResult dialogResult = MessageBox.Show("Congratulations you Win! Play again?", "You're a Winner", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                            button3.PerformClick();
                        
                    }
                    else
                    {
                        oldpoolrank.Clear();
                        oldpoolsuite.Clear();
                        for (int x = 0; x < poolrank.Count(); x++)
                        {
                            oldpoolrank.Add(poolrank[x]);
                            oldpoolsuite.Add(poolsuite[x]);
                        }
                        await Task.Delay(Convert.ToInt32(responsetime * 1000));
                        turn++;
                        await next();
                    }
                }
                else
                    MessageBox.Show("Invalid Play");
            }
            else
            {
                MessageBox.Show("Invalid Play");
            }
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
        }
        public bool legitplay(int [] player)
        {
            List<int> play = new List <int>();
            for(int x = 1; x <= 13; x++)
            {
                if(labarray[x].Text == "Play Card")
                {
                    play.Add(player[2 * x - 1]);
                    play.Add(player[2 * x]);
                }
            }
            int count = play.Count();
            if (count == 2)
            {
                previous = "High Card";
                label30.Text = previous;
                return true;
            }
            if (count == 4)
            {
                if (play[1] == play[3])
                {
                    previous = "Pair";
                    label30.Text = previous;
                    return true;
                }
                else
                {
                    label30.Text = previous;
                    return false;
                }
            }
            if (count == 6)
            {
                if (play[1] == play[3] && play[3] == play[5])
                {
                    previous = "Three of a Kind";
                    label30.Text = previous;
                    return true;
                }
                else
                {
                    label30.Text = previous;
                    return false;
                }
            }

            if (count == 8)
            {
                    label30.Text = previous;
                    return false;
            }
            else if (count == 10)
            {
                List<int> straight = new List<int> { play[1], play[3], play[5], play[7], play[9] };
                List<int> flush = new List<int> { play[0], play[2], play[4], play[6], play[8] };
                straight.Sort();


                if ((straight[0] == straight[1] && straight[1] == straight[2] && straight[2] == straight[3]) || (straight[3] == straight[4] && straight[1] == straight[2] && straight[2] == straight[3]))
                {
                    previous = "Four of a Kind";
                    label30.Text = previous;
                    return true;
                }
                if (((straight[0] == straight[1] && straight[1] == straight[2] && straight[3] == straight[4]) || (straight[2] == straight[3] && straight[3] == straight[4] && straight[0] == straight[1])))
                {
                    previous = "Full House";
                    label30.Text = previous;
                    return true;
                }
                if (straight.Max() - straight.Min() == 4)
                    straightcheck = true;
                foreach (int x in flush)
                {
                    if (x == flush[0])
                        flushcheck = true;
                    else
                    {
                        flushcheck = false;
                        break;
                    }
                }
                straight.RemoveAt(0);
                if (straight.Max() - straight.Min() == 3 && straight.Max() == 13)
                {
                    straightcheck = true;
                }
                if (straightcheck && flushcheck && straight.Min() == 10 && straight.Max() == 13)
                {
                    previous = "Royal Flush";
                    label30.Text = previous;
                    return true;
                }
                if (straightcheck && flushcheck)
                {
                    previous = "Straight Flush";
                    label30.Text = previous;
                    return true;
                }
                if (flushcheck)
                {
                    previous = "Flush";
                    label30.Text = previous;
                    return true;
                }
                if (straightcheck)
                {
                    previous = "Straight";
                    label30.Text = previous;
                    return true;
                }
                else
                {
                    label30.Text = previous;
                    return false;
                }
            }
            else
            {
                label30.Text = "High Card";
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to start a new game?", "New Game", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                label1.Text = "13";
                label2.Text = "13";
                label3.Text = "13";
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
                label10.Text = "";
                label11.Text = "";
                label12.Text = "";
                label13.Text = "";
                label14.Text = "";
                label15.Text = "";
                label16.Text = "";
                label30.Text = "";
                label36.Text = "";
                cleartable();
                pass = 3;
                label46.Text = pass.ToString();
                straightcheck = false;
                flushcheck = false;
                List<int> poolsuite = new List<int>();
                List<int> poolrank = new List<int>();
                clearitout();
                label40.Visible = false;
                label41.Visible = false;
                label42.Visible = false;
                label43.Visible = false;
                aifirstturn = new bool[] { true, true, true};
                gameended = false;
                deal();
            }
        }

        void cleartable()
        {
            label31.Text = "";
            label32.Text = "";
            label33.Text = "";
            label34.Text = "";
            label35.Text = "";
            pictureBox14.Image = null;
            pictureBox14.Invalidate();
            pictureBox15.Image = null;
            pictureBox15.Invalidate();
            pictureBox16.Image = null;
            pictureBox16.Invalidate();
            pictureBox17.Image = null;
            pictureBox17.Invalidate();
            pictureBox18.Image = null;
            pictureBox18.Invalidate();
            playcardnumber = 0;
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            turn++;
            pass++;
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label46.Text = pass.ToString();
            await next();
        }

        public async void aiplayer(int whichone)
        {
            airank = new int[14];
            aisuite = new int[14];
            moderank = new int[14];
            modesuite = new int[14];
            straightsacrifice = new int[14];
            for (int x = 1; x <= 13; x++)
            {
                airank[x] = ai[whichone][2 * x];
                moderank[airank[x]]++;
                straightsacrifice[ai[whichone][2 * x]]++;
                aisuite[x] = ai[whichone][2 * x - 1];
                modesuite[aisuite[x]]++;
            }
            Array.Sort(airank, aisuite);
            if (aifirstturn[whichone - 1])
            {
                tally = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                List<int> twokind = new List<int>();
                List<int> threekind = new List<int>();
                List<int> fourkind = new List<int>();

                for (int x = 1; x <= 13; x++)
                {
                    if (moderank[x] == 4)
                    {
                        tally[7]++;
                        fourkind.Add(x);
                    }
                    if (moderank[x] == 3)
                    {
                        tally[3]++;
                        threekind.Add(x);
                    }
                    if (moderank[x] == 2)
                    {
                        tally[2]++;
                        twokind.Add(x);
                    }
                    if (moderank[x] == 1)
                    {
                        tally[1]++;
                    }
                }
                if (tally[3] < tally[2])
                {
                    tally[6] = tally[3];
                }
                if (tally[2] < tally[3])
                {
                    tally[6] = tally[2];
                }
                if (tally[2] == tally[3])
                {
                    if (tally[2] != 0)
                        tally[6] = tally[2];
                    else
                        tally[6] = 0;
                }
                for (int x = 1; x <= 4; x++)
                {
                    if (modesuite[x] >= 5)
                    {
                        tally[5]++;
                        if (modesuite[x] >= 10)
                        {
                            tally[5]++;
                        }
                    }
                }
                for (int x = 3; x <= 11; x++)
                {
                    if ((straightsacrifice[x - 2] > 0 && straightsacrifice[x - 1] > 0 && straightsacrifice[x] > 0 && straightsacrifice[x + 1] > 0 && straightsacrifice[x + 2] > 0) || (straightsacrifice[10] > 0 && straightsacrifice[11] > 0 && straightsacrifice[12] > 0 && straightsacrifice[13] > 0 && straightsacrifice[1] > 0))
                    {
                        tally[4]++;
                    }
                }
                for (int x = 3; x <= 11; x++)
                {
                    if ((straightsacrifice[x - 2] > 0 && straightsacrifice[x - 1] > 0 && straightsacrifice[x] > 0 && straightsacrifice[x + 1] > 0 && straightsacrifice[x + 2] > 0) && (aisuite[x - 2] == aisuite[x - 1] && aisuite[x - 1] == aisuite[x] && aisuite[x] == aisuite[x + 1] && aisuite[x + 1] == aisuite[x + 2]))
                    {
                        tally[8]++;
                    }
                }
                if ((straightsacrifice[10] > 0 && straightsacrifice[11] > 0 && straightsacrifice[12] > 0 && straightsacrifice[13] > 0 && straightsacrifice[1] > 0) && (aisuite[10] == aisuite[11] && aisuite[11] == aisuite[12] && aisuite[12] == aisuite[13] && aisuite[13] == aisuite[1]))
                    tally[9]++;
                handrankcardimportance(whichone);
                rerankarraybasedoncardimp(whichone);
                //listofarraysinlist[whichone - 1].Reverse();
                aifirstturn[whichone - 1] = false;
            }
            label47.Text = listofarraysinlist[whichone - 1].Count().ToString();
            for (int x = 0; x<= listofarraysinlist[whichone - 1].Count() - 1; x++)
            {
                poolsuite.Clear();
                poolrank.Clear();

                for (int y = 1; y <= listofarraysinlist[whichone - 1][x].Count() - 1; y++)
                {
                    poolsuite.Add(aisuite[listofarraysinlist[whichone - 1][x][y]]);
                    poolrank.Add(airank[listofarraysinlist[whichone - 1][x][y]]);
                }
                if(poolrank.Count == 4) //4kindexception
                {
                    poolsuite.Add(aisuite[listofarraysinlist[whichone - 1][x][listofarraysinlist[whichone - 1][x].Count() - 1]]);
                    poolrank.Add(airank[listofarraysinlist[whichone - 1][x][listofarraysinlist[whichone - 1][x].Count() - 1]]);
                }
                if (validplay(poolrank, poolsuite, oldpoolrank, oldpoolsuite))
                {

                    cleartable();
                    pass = 0;
                    label46.Text = pass.ToString();
                    int card = Convert.ToInt32(labarray1[whichone].Text);
                    card -= poolrank.Count();
                    labarray1[whichone].Text = card.ToString();
                    string[] privsuitestring = new string[poolsuite.Count + 1];
                    int[] poolsuite2 = new int[poolsuite.Count + 1];
                    for (int y = 1; y <= poolsuite.Count; y++)
                    {
                        poolsuite2[y] = poolsuite[y - 1];
                        suiteinttostring(poolsuite2, privsuitestring, poolsuite.Count());
                        pbarray2[y].Image = new Bitmap("C:\\Users\\Paul\\Documents\\Poker\\" + privsuitestring[y] + "" + poolrank[y-1].ToString() + ".rle");
                        labarray3[y].Text = deck[((poolsuite[y - 1] - 1) * 13) + poolrank[y - 1] - 1];
                    }
                    oldpoolrank.Clear();
                    oldpoolsuite.Clear();
                    for (int y = 0; y < poolrank.Count(); y++)
                    {
                        oldpoolrank.Add(poolrank[y]);
                        oldpoolsuite.Add(poolsuite[y]);
                    }
                    int a = 0;
                    int b = 0;
                    int c = 0;
                    int d = 0;
                    int e = 0;
                    if (poolrank.Count() == 1)
                        a = listofarraysinlist[whichone - 1][x][1];
                    if (poolrank.Count() == 2)
                    {
                        a = listofarraysinlist[whichone - 1][x][1];
                        b = listofarraysinlist[whichone - 1][x][2];
                    }
                    if (poolrank.Count() == 3)
                    {
                        a = listofarraysinlist[whichone - 1][x][1];
                        b = listofarraysinlist[whichone - 1][x][2];
                        c = listofarraysinlist[whichone - 1][x][3];
                    }
                    if (poolrank.Count() == 5)
                    {
                        a = listofarraysinlist[whichone - 1][x][1];
                        b = listofarraysinlist[whichone - 1][x][2];
                        c = listofarraysinlist[whichone - 1][x][3];
                        d = listofarraysinlist[whichone - 1][x][4];
                        e = listofarraysinlist[whichone - 1][x][5];
                    }
                    switch (listofarraysinlist[whichone - 1][x][0])
                    {
                        case 1:
                            foreach (int[] n in listofarraysinlist[whichone - 1].ToList())
                            {
                                if (containskipfirst(n, a))
                                {
                                    listofarraysinlist[whichone - 1].Remove(n);
                                }

                            }
                            break;
                        case 2:
                            foreach (int[] n in listofarraysinlist[whichone - 1].ToList())
                            {
                                if (containskipfirst(n, a) || containskipfirst(n, b))
                                {
                                    listofarraysinlist[whichone - 1].Remove(n);
                                }

                            }
                            break;
                        case 3:
                            foreach (int[] n in listofarraysinlist[whichone - 1].ToList())
                            {
                                if (containskipfirst(n, a) || containskipfirst(n, b) || containskipfirst(n, c))
                                {
                                    listofarraysinlist[whichone - 1].Remove(n);
                                }

                            }
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            foreach (int[] n in listofarraysinlist[whichone - 1].ToList())
                            {
                                if (containskipfirst(n, a) || containskipfirst(n, b) || containskipfirst(n, c) || containskipfirst(n, d) || containskipfirst(n, e))
                                {
                                    listofarraysinlist[whichone - 1].Remove(n);
                                }

                            }
                            break;
                    }
                    break;
                }
                else if (x == listofarraysinlist[whichone - 1].Count() - 1)
                {
                    pass++;
                    label46.Text = pass.ToString();
                }
            }
            await Task.Delay(Convert.ToInt32(responsetime * 1000));
            if (turn < 4)
                turn++;
            else
                turn = 1;
            await next();
        }
        public bool containskipfirst(int[]container, int look)
        {
            for(int x = 1; x<= container.Count()-1; x++)
            {
                if (container[x] == look)
                    return true;
            }
            return false;
        }
        public void rerankarraybasedoncardimp(int whichone)
        {
            int count = listofarraysinlist[whichone - 1].Count();
            int average;
            int[] scoreboard = new int [count];
            int[][] storage = new int[count][];
            int divider;
            for(int x = 0; x<=count-1; x++)
            {
                average = 0;
                if(listofarraysinlist[whichone - 1][x].Count() == 2)
                    divider = listofarraysinlist[whichone - 1][x].Count()-1;
                if (listofarraysinlist[whichone - 1][x].Count() == 3)
                    divider = listofarraysinlist[whichone - 1][x].Count();
                if (listofarraysinlist[whichone - 1][x].Count() == 4)
                    divider = listofarraysinlist[whichone - 1][x].Count()+1;
                else
                    divider = 2*(listofarraysinlist[whichone - 1][x].Count());
                foreach (int y in listofarraysinlist[whichone - 1][x])
                    {
                        average += aicardimportancearray[whichone][airank[y]];
                    }
                average /= divider;
                scoreboard[x] = average;
            }
            for(int x = 0; x<=count-1; x++)
            {
                storage[x] = listofarraysinlist[whichone - 1][x];
            }
            Array.Sort(scoreboard, storage);
            listofarraysinlist[whichone - 1].Clear();
            foreach (int[]x in storage)
            {
                listofarraysinlist[whichone - 1].Add(x);
            }
        }
        public void handrankcardimportance(int whichone)
        {
            for (int x = 9; x > 0; x--)
            {
                if (tally[x] > 0)
                {
                    switch (x)
                    {
                        case 9: //royal flush
                            int[]storage9 = new int[6];
                            storage9[0] = 9;
                            int[] storage92 = new int[6];
                            storage92[0] = 9;
                            bool switcher = true;
                            List<int> storage9list = new List<int>();
                            List<int> storage92list = new List<int>();
                            for (int y = 1; y<=4; y++)
                            {
                                List<int> suitelist = new List<int>();
                                foreach(int z in aisuite)
                                {
                                    if (z == y)
                                        suitelist.Add(z);
                                }
                                foreach(int z in suitelist)
                                {
                                    if(airank[z] == 10 || airank[z] == 11 || airank[z] == 12 || airank[z] == 13 || airank[z] == 1)
                                    {
                                        if (switcher)
                                        {
                                            storage9list.Add(z);
                                            storage9list.Sort();
                                            aicardimportancearray[whichone][airank[z]] += (13 * 100) + storage9list[z];
                                        }
                                        else
                                        {
                                            storage92list.Add(z);
                                            storage92list.Sort();
                                            aicardimportancearray[whichone][airank[z]] += (13 * 100) + storage92list[z];
                                        }
                                    }
                                }
                                if (storage9list.Count == 5)
                                    switcher = false;                                
                            }
                            for (int y = 1; y <= storage9list.Count(); y++)
                            {
                                storage9[y] = storage9list[y - 1];
                            }
                            listofarraysinlist[whichone - 1].Add(new int[] { 9, storage9[1], storage9[2], storage9[3], storage9[4], storage9[5] });
                            if (tally[9] == 2)
                            {
                                for (int y = 1; y <= storage92list.Count(); y++)
                                {
                                    storage92[y] = storage92list[y - 1];
                                }
                                listofarraysinlist[whichone - 1].Add(new int[] { 9, storage92[1], storage92[2], storage92[3], storage92[4], storage92[5] });
                            }
                            break;
                        case 8: //Straight Flush
                            int[] storage8 = new int[6];
                            storage8[0] = 8;
                            int[] storage82 = new int[6];
                            storage82[0] = 8;
                            bool switcher1 = true;
                            List<int> storage8list = new List<int>();
                            List<int> storage82list = new List<int>();
                            for (int y = 1; y <= 4; y++)
                            {
                                List<int> suitelist = new List<int>();
                                foreach (int z in aisuite)
                                {
                                    if (z == y)
                                        suitelist.Add(z);
                                }
                                foreach (int z in suitelist)
                                {
                                    if ((airank[z] == 10 || airank[z] == 11 || airank[z] == 12 || airank[z] == 13 || airank[z] == 1))
                                    {
                                        if (switcher1)
                                        {
                                            storage8list.Add(z);
                                            storage8list.Sort();
                                            aicardimportancearray[whichone][airank[z]] += (13 * 42) + storage8list[z];
                                        }
                                        else
                                        {
                                            storage82list.Add(z);
                                            storage82list.Sort();
                                            aicardimportancearray[whichone][airank[z]] += (13 * 42) + storage82list[z];
                                        }
                                    }
                                }
                                if (storage8list.Count == 5)
                                    switcher = false;
                            }
                            for (int y = 1; y <= storage8list.Count(); y++)
                            {
                                storage8[y] = storage8list[y - 1];
                            }
                            listofarraysinlist[whichone - 1].Add(new int[] { 8, storage8[1], storage8[2], storage8[3], storage8[4], storage8[5] });
                            if (tally[8] == 2)
                            {
                                for (int y = 1; y <= storage82list.Count(); y++)
                                {
                                    storage82[y] = storage82list[y - 1];
                                }
                                listofarraysinlist[whichone - 1].Add(new int[] { 8, storage82[1], storage82[2], storage82[3], storage82[4], storage82[5] });
                            }
                            break;
                        case 7: //4 of a Kind
                            int[] storage7 = IndexOfAll(4, moderank);
                            for (int y = storage7.Count()-1; y >= 1; y--)
                            {
                                int[] temp = IndexOfAll(storage7[y], airank);
                                listofarraysinlist[whichone-1].Add(new int[] { 7, temp[1], temp[2], temp[3], temp[4] });
                                if (storage7[y] >= 3)
                                {
                                    aicardimportancearray[whichone][temp[0]] += (13 * 24) + storage7[y];
                                    aicardimportancearray[whichone][temp[1]] += (13 * 24) + storage7[y];
                                    aicardimportancearray[whichone][temp[2]] += (13 * 24) + storage7[y];
                                    aicardimportancearray[whichone][temp[3]] += (13 * 24) + storage7[y];
                                }
                                else
                                {
                                    aicardimportancearray[whichone][temp[0]] += (13 * 25) + storage7[y];
                                    aicardimportancearray[whichone][temp[1]] += (13 * 25) + storage7[y];
                                    aicardimportancearray[whichone][temp[2]] += (13 * 25) + storage7[y];
                                    aicardimportancearray[whichone][temp[3]] += (13 * 25) + storage7[y];
                                }
                            }
                            break;
                        case 6: //Full house
                            for (int b = 1; b <= tally[6]; b++)
                            {
                                int[] storage63 = IndexOfAll(3, moderank);
                                List<int> temp = new List<int>();
                                for (int y = storage63.Count() - 1; y >= 1; y--)
                                {
                                    temp.Add(Array.IndexOf(airank, storage63[y]));
                                }
                                int[] storage62 = IndexOfAll(2, moderank);
                                List<int> temp1 = new List<int>(); 
                                for (int y = storage62.Count() - 1; y >= 1; y--)
                                {
                                    temp1.Add(Array.IndexOf(airank, storage62[y]));
                                }
                                if (tally[3] <= tally[2])
                                {
                                    foreach(int c in temp)
                                    {
                                        foreach (int d in temp1)
                                        {
                                            int[] storage6 = new int[6] { 6, c, c + 1, c + 2, d, d + 1 };
                                            listofarraysinlist[whichone-1].Add(storage6);
                                            if (airank[c] >= 3)
                                            {
                                                aicardimportancearray[whichone][c] += (13 * 12) + airank[c];
                                                aicardimportancearray[whichone][c+1] += (13 * 12) + airank[c];
                                                aicardimportancearray[whichone][c+2] += (13 * 12) + airank[c];
                                            }
                                            else if (airank[c] < 3)
                                            {
                                                aicardimportancearray[whichone][c] += (13 * 14) + airank[c];
                                                aicardimportancearray[whichone][c + 1] += (13 * 14) + airank[c];
                                                aicardimportancearray[whichone][c + 2] += (13 * 14) + airank[c];
                                            }
                                            if(airank[d] >= 3)
                                            {
                                                aicardimportancearray[whichone][d] += (13 * 12) + airank[d];
                                                aicardimportancearray[whichone][d + 1] += (13 * 12) + airank[d];
                                            }
                                            else if (airank[d] < 3)
                                            {
                                                aicardimportancearray[whichone][d] += (13 * 14) + airank[d];
                                                aicardimportancearray[whichone][d + 1] += (13 * 14) + airank[d];
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (int c in temp1)
                                    {
                                        foreach (int d in temp)
                                        {
                                            int[] storage6 = new int[6] { 6, d, d + 1 , d + 2, c, c + 1 };
                                            listofarraysinlist[whichone-1].Add(storage6);
                                            if (airank[d] >= 3)
                                            {
                                                aicardimportancearray[whichone][d] += (13 * 12) + airank[d];
                                                aicardimportancearray[whichone][d + 1] += (13 * 12) + airank[d];
                                                aicardimportancearray[whichone][d + 2] += (13 * 12) + airank[d];
                                            }
                                            else if (airank[d] < 3)
                                            {
                                                aicardimportancearray[whichone][d] += (13 * 14) + airank[d];
                                                aicardimportancearray[whichone][d + 1] += (13 * 14) + airank[d];
                                                aicardimportancearray[whichone][d + 2] += (13 * 14) + airank[d];
                                            }
                                            if (airank[c] >= 3)
                                            {
                                                aicardimportancearray[whichone][c] += (13 * 14) + airank[c];
                                                aicardimportancearray[whichone][c + 1] += (13 * 14) + airank[c];
                                            }
                                            else if (airank[c] < 3)
                                            {
                                                aicardimportancearray[whichone][c] += (13 * 14) + airank[c];
                                                aicardimportancearray[whichone][c + 1] += (13 * 14) + airank[c];
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 5: //Flush
                            List<int> storlist = new List<int>();
                            for(int y = 1; y<=4; y++)
                            {
                                int count = 0;
                                storlist.Clear();
                                for (int z = 1; z <= 13; z++)
                                {
                                    if(aisuite[z] == y)
                                    {
                                        count++;
                                        storlist.Add(z);
                                    }
                                }
                                if (storlist.Count >= 5)
                                { 
                                    for (int z = 0; z <= storlist.Count - 1; z++)
                                    {
                                        if(storlist[z] >=3)
                                            aicardimportancearray[whichone][storlist[z]] += (13 * 8) + airank[storlist[z]];
                                        else
                                            aicardimportancearray[whichone][storlist[z]] += (13 * 9) + airank[storlist[z]];
                                    }
                                }
                                int[] storage5;
                                switch (storlist.Count())
                                {
                                    case 5:
                                        storage5 = new int[6];
                                        storage5[0] = 5;
                                        for (int z = 0; z < 5; z++)
                                        {
                                            storage5[z + 1] = storlist[z];
                                        }
                                        listofarraysinlist[whichone-1].Add(storage5);
                                        break;
                                    case 6:
                                        for (int a = 0; a <= 1; a++)
                                        {
                                            storage5 = new int[6];
                                            storage5[0] = 5;
                                            for (int z = a; z <= a+4; z++)
                                            {
                                                storage5[z - a + 1] = storlist[z];
                                            }
                                            listofarraysinlist[whichone-1].Add(storage5);
                                        }
                                        break;
                                    case 7:
                                        for (int a = 0; a <= 2; a++)
                                        {
                                            storage5 = new int[6];
                                            storage5[0] = 5;
                                            for (int z = a; z <= a + 4; z++)
                                            {
                                                storage5[z - a + 1] = storlist[z];
                                            }
                                            listofarraysinlist[whichone-1].Add(storage5);
                                        }
                                        break;
                                    case 8:
                                        for (int a = 0; a <= 3; a++)
                                        {
                                            storage5 = new int[6];
                                            storage5[0] = 5;
                                            for (int z = a; z <= a + 4; z++)
                                            {
                                                storage5[z - a + 1] = storlist[z];
                                            }
                                            listofarraysinlist[whichone-1].Add(storage5);
                                        }
                                        break;
                                    case 9:
                                        for (int a = 0; a <= 4; a++)
                                        {
                                            storage5 = new int[6];
                                            storage5[0] = 5;
                                            for (int z = a; z <= a + 4; z++)
                                            {
                                                storage5[z - a + 1] = storlist[z];
                                            }
                                            listofarraysinlist[whichone-1].Add(storage5);
                                        }
                                        break;
                                    case 10:
                                        for (int a = 0; a <= 5; a++)
                                        {
                                            storage5 = new int[6];
                                            storage5[0] = 5;
                                            for (int z = a; z <= a + 4; z++)
                                            {
                                                storage5[z - a + 1] = storlist[z];
                                            }
                                            listofarraysinlist[whichone-1].Add(storage5);
                                        }
                                        break;
                                    case 11:
                                        for (int a = 0; a <= 6; a++)
                                        {
                                            storage5 = new int[6];
                                            storage5[0] = 5;
                                            for (int z = a; z <= a + 4; z++)
                                            {
                                                storage5[z - a + 1] = storlist[z];
                                            }
                                            listofarraysinlist[whichone-1].Add(storage5);
                                        }
                                        break;
                                    case 12:
                                        for (int a = 0; a <= 7; a++)
                                        {
                                            storage5 = new int[6];
                                            storage5[0] = 5;
                                            for (int z = a; z <= a + 4; z++)
                                            {
                                                storage5[z - a + 1] = storlist[z];
                                            }
                                            listofarraysinlist[whichone-1].Add(storage5);
                                        }
                                        break;
                                    case 13:
                                        for (int a = 0; a <= 8; a++)
                                        {
                                            storage5 = new int[6];
                                            storage5[0] = 5;
                                            for (int z = a; z <= a + 4; z++)
                                            {
                                                storage5[z-a+1] = storlist[z];
                                            }
                                            listofarraysinlist[whichone-1].Add(storage5);
                                        }
                                        break;
                                }
                            }
                            break;
                        case 4: //Straight   
                            List<int> storlist2 = new List<int>();
                            List<int> storlist2v2 = new List<int>();
                            List<int[]> listofstorage4s = new List<int[]>();
                            bool another = false;
                            List<int> tempstore = new List<int>();
                            int[] one = IndexOfAll(1, moderank);
                            int[] two = IndexOfAll(2, moderank);
                            int[] three = IndexOfAll(3, moderank);
                            int[] four = IndexOfAll(4, moderank);
                            for (int z = 1; z <= 13; z++)
                            {
                                if (one.Contains(z) || two.Contains(z) || three.Contains(z) || four.Contains(z))
                                {
                                    tempstore.Add(z);
                                    if(z == 13)
                                    {
                                        if (one.Contains(1) || two.Contains(1) || three.Contains(1) || four.Contains(1))
                                            tempstore.Add(1);
                                    }
                                    if (tempstore.Count >= 5 && another == false)
                                    {
                                        for(int a = 0; a<=tempstore.Count()-1; a++)
                                        {
                                            storlist2.Add(tempstore[a]);
                                        }
                                    }
                                    if (tempstore.Count >= 5 && another)
                                    { 
                                        for (int a = 0; a <= tempstore.Count()-1; a++)
                                        {
                                            storlist2v2.Add(tempstore[a]);
                                        }
                                    }
                                }
                                else
                                {
                                    tempstore.Clear();
                                    if (storlist2.Count() >= 5)
                                        another = true;
                                }
                            }
                            for (int a = 0; a <= storlist2.Count()-1; a++)
                            {
                                if (storlist2[a] >= 3)
                                {
                                    int[] numbers = IndexOfAll(storlist2[a], airank);
                                    foreach(int c in numbers)
                                    {
                                        aicardimportancearray[whichone][airank[c]] += (13 * 4) + airank[c];
                                    }
                                }
                                else
                                {
                                    int[] numbers = IndexOfAll(storlist2[a], airank);
                                    foreach (int c in numbers)
                                    {
                                        aicardimportancearray[whichone][airank[c]] += (13 * 5) + airank[c];
                                    }
                                }
                            }
                            for (int a = 0; a <= storlist2v2.Count()-1; a++)
                            {
                                if (storlist2v2[a] >= 3)
                                {
                                    int[] numbers = IndexOfAll(storlist2v2[a], airank);
                                    foreach (int c in numbers)
                                    {
                                        aicardimportancearray[whichone][airank[c]] += (13 * 4) + airank[c];
                                    }
                                }
                                else
                                {
                                    int[] numbers = IndexOfAll(storlist2v2[a], airank);
                                    foreach (int c in numbers)
                                    {
                                        aicardimportancearray[whichone][airank[c]] += (13 * 5) + airank[c];
                                    }
                                }
                            }
                            tempstore.Clear();
                            List<int[]> number = new List<int[]>();
                            List<int[]> number2 = new List<int[]>();
                            int numberpossibility = 1;
                            int number2possibility = 1;
                            if (storlist2v2.Count >= 5)
                            {
                                foreach (int y in storlist2v2)
                                {
                                    number2.Add(IndexOfAll(y, airank));
                                }
                                foreach (int[] y in number2)
                                {
                                    number2possibility *= y.Count() - 1;
                                }
                                if (numberpossibility == 1 && number2.Count() == 5)
                                    listofstorage4s.Add(new int[] { 4, number2[0][1], number2[1][1], number2[2][1], number2[3][1], number2[4][1] });
                                else if (number2possibility > 5 || number2.Count() > 5)
                                {
                                    for (int f = 0; f <= number2.Count - 6; f++)
                                    {
                                        for (int a = 1; a <= number2[f].Count() - 1; a++)
                                        {
                                            for (int b = 1; b <= number2[f + 1].Count() - 1; b++)
                                            {
                                                for (int c = 1; c <= number2[f + 2].Count() - 1; c++)
                                                {
                                                    for (int d = 1; d <= number2[f + 3].Count() - 1; d++)
                                                    {
                                                        for (int e = 1; e <= number2[f + 4].Count() - 1; e++)
                                                        {
                                                            listofstorage4s.Add(new int[] { 4, number2[f][a], number2[f + 1][b], number2[f + 2][c], number2[f + 3][d], number2[f + 4][e] });
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            for(int y = storlist2.Min(); y<=storlist2.Max(); y++)
                            {
                                number.Add(IndexOfAll(y, airank));
                                
                            }
                            foreach (int[] y in number)
                            {
                                numberpossibility *= y.Count() - 1;
                            }
                                for (int f = 0; f <= number.Count - 6; f++)
                                {
                                    for (int a = 1; a <= number[f].Count() - 1; a++)
                                    {
                                        for (int b = 1; b <= number[f + 1].Count() - 1; b++)
                                        {
                                            for (int c = 1; c <= number[f + 2].Count() - 1; c++)
                                            {
                                                for (int d = 1; d <= number[f + 3].Count() - 1; d++)
                                                {
                                                    for (int e = 1; e <= number[f + 4].Count() - 1; e++)
                                                    {
                                                        listofstorage4s.Add(new int[] { 4, number[f][a], number[f + 1][b], number[f + 2][c], number[f + 3][d], number[f + 4][e] });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            
                            foreach (int[] y in listofstorage4s)
                            {
                                listofarraysinlist[whichone-1].Add(y);
                            }
                            break;
                        case 3: //3kind
                            int[] storage3 = IndexOfAll(3, moderank);
                            for (int y = storage3.Count()-1; y >= 1; y--)
                            {
                                int[] temp = IndexOfAll(storage3[y], airank);
                                listofarraysinlist[whichone-1].Add(new int[] { 3, temp[1], temp[2], temp[3] });
                                if (storage3[y] >= 3)
                                {
                                    aicardimportancearray[whichone][temp[0]] += airank[storage3[y]];
                                    aicardimportancearray[whichone][temp[1]] += airank[storage3[y]];
                                    aicardimportancearray[whichone][temp[2]] += airank[storage3[y]];
                                }
                                else
                                {
                                    aicardimportancearray[whichone][temp[0]] += airank[storage3[y]];
                                    aicardimportancearray[whichone][temp[1]] += airank[storage3[y]];
                                    aicardimportancearray[whichone][temp[2]] += airank[storage3[y]];
                                }
                            }
                            break;
                        case 2: //2kind
                            int[] storage2 = IndexOfAll(2, moderank);
                            for (int y = storage2.Count()-1; y >= 1; y--)
                            {
                                int [] temp = IndexOfAll(storage2[y], airank);
                                listofarraysinlist[whichone-1].Add(new int[] { 2, temp[1], temp[2]});
                                if (storage2[y] >= 3)
                                {
                                    aicardimportancearray[whichone][temp[1]] += airank[storage2[y]];
                                    aicardimportancearray[whichone][temp[2]] += airank[storage2[y]];
                                }
                                else
                                {
                                    aicardimportancearray[whichone][temp[1]] += 13 + airank[storage2[y]];
                                    aicardimportancearray[whichone][temp[2]] += 13 + airank[storage2[y]];
                                }
                            }
                            break;
                        case 1: //Hi
                            for (int y = 13; y >= 1; y-- )
                            {
                                listofarraysinlist[whichone-1].Add(new int[] { 1, y });
                                if (y>=3)
                                    aicardimportancearray[whichone][y] += airank[y];
                                else
                                    aicardimportancearray[whichone][y] += airank[y] + 13;

                            }
                            break;
                    }
                }
            }
        }
        
        public int [] IndexOfAll(int whattosearch, int[]array)
        {
            List<int> storage = new List<int>();
            int[] storageint;
            for(int x = 0; x< array.Count(); x++)
            {
                if (array[x] == whattosearch)
                {
                    storage.Add(x);
                }
            }
            storageint = new int[storage.Count()+1];
            for(int x = 0; x < storage.Count(); x++)
            {
                storageint[x + 1] = storage[x];
            }

            return storageint;
            
        }

        public async Task next()
        {
            
            if (turn == 1)
            {
                if (gameended == false)
                {
                    label40.Visible = true;
                    label43.Visible = false;
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
            }
            else if (turn == 2)
            {
                if (gameended == false)
                {
                    label40.Visible = false;
                    label41.Visible = true;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    aiplayer(1);
                    if (labarray1[1].Text == "0")
                    {
                        gameended = true;
                        DialogResult dialogResult = MessageBox.Show("Congratulations you Lost! Winner: CPU #1 Play again?", "You Lost" , MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                            button3.PerformClick();
                    }
                }
            }
            else if (turn == 3)
            {
                if (gameended == false)
                {
                    label41.Visible = false;
                    label42.Visible = true;
                    aiplayer(2);
                    if (labarray1[2].Text == "0")
                    {
                        gameended = true;
                        DialogResult dialogResult = MessageBox.Show("Congratulations you Lost! Winner: CPU #2 Play again?", "You Lost", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                            button3.PerformClick();
                    }
                }
            }
            else if (turn == 4)
            {
                if (gameended == false)
                {
                    label42.Visible = false;
                    label43.Visible = true;
                    aiplayer(3);
                    if (labarray1[3].Text == "0")
                    {
                        gameended = true;
                        DialogResult dialogResult = MessageBox.Show("Congratulations you Lost! Winner: CPU #3 Play again?", "You Lost", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                            button3.PerformClick();
                    }
                }
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label4.Text != "Play Card")
                {
                    if (ohthehumanity[1] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label4.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label4.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label5.Text != "Play Card")
                {
                    if (ohthehumanity[3] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label5.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label5.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label6.Text != "Play Card")
                {
                    if (ohthehumanity[5] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label6.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label6.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label7.Text != "Play Card")
                {
                    if (ohthehumanity[7] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label7.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label7.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label8.Text != "Play Card")
                {
                    if (ohthehumanity[9] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label8.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label8.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label9.Text != "Play Card")
                {
                    if (ohthehumanity[11] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label9.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label9.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label10.Text != "Play Card")
                {
                    if (ohthehumanity[13] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label10.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label10.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label11.Text != "Play Card")
                {
                    if (ohthehumanity[15] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label11.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label11.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label12.Text != "Play Card")
                {
                    if (ohthehumanity[17] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label12.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label12.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label13.Text != "Play Card")
                {
                    if (ohthehumanity[19] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label13.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label13.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label14.Text != "Play Card")
                {
                    if (ohthehumanity[21] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label14.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label14.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label15.Text != "Play Card")
                {
                    if (ohthehumanity[23] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        playcardnumber++;
                        label15.Text = "Play Card";
                    }
                }
                else
                {
                    label15.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (gameended == false)
            {
                if (label16.Text != "Play Card")
                {
                    if (ohthehumanity[25] == 0)
                        MessageBox.Show("Card has already been played");
                    else if (playcardnumber == 5)
                        MessageBox.Show("Cannot put down more than 5 cards");
                    else
                    {
                        label16.Text = "Play Card";
                        playcardnumber++;
                    }
                }
                else
                {
                    label16.Text = "";
                    playcardnumber--;
                }
                legitplay(ohthehumanity);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sort();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sort();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            responsetime = Convert.ToDouble(trackBar1.Value) / 100;
            label45.Text = responsetime.ToString() + " Seconds";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 100;
            responsetime = 1;
            label45.Text = responsetime.ToString() + " Seconds";
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Cards may be played as singles or in groups of two, three or five (var. 1 and 8), in combinations which resemble poker hands. The leading card to a trick sets down the number of cards to be played; all the cards of a trick must contain the same number of cards. The highest ranking card is 2 instead of A. The combinations and their rankings are as follows.

            Single cards: Any card from the deck, ordered by rank with suit being the tie - breaker. (For instance, A♠ beats A♥, which beats K♠.)

            *Pairs: Any two cards of matching rank, ordered as with singular cards by the card of the higher suit. (A pair consisting of the K♠ and K♣ beats a pair consisting of K♥ and K♦.)
            *Triples: Three equal ranked cards, three twos are highest, then aces, kings, etc.down to three threes, which is the lowest triple.In some variations, a triple can only be played as part of a 5 - card hand.

            5 - card hand: There are five(var. 2) different valid 5 - card poker hands, ranking, from low to high, as follows (the same ranking as in poker):

            *Straight: Any 5 cards in a sequence (but not all of the same suit). Rank is determined by the value of the biggest card, with the suit used only as a tie - breaker.Therefore 3 - 4 - 5 - 6 - 7 < 2 - 3 - 4 - 5 - 6, since 2 is considered the largest card in the 2 - 3 - 4 - 5 - 6 straight.The largest straight is 10 - J - Q - K - A , while the smallest straight is 3 - 4 - 5 - 6 - 7.
            *Flush: Any 5 cards of the same suit(but not in a sequence). Determined by Suite, from lowest to highest (♣,♦,♥,♠) Rank is used to break ties.
            *Full House: a composite of a three - of - a - kind combination and a pair. Rank is determined by the value of the triple, regardless of the value of the pair.
            *Four of a kind +One card: Any set of 4 cards of the same rank, plus any 5th card. (A 4 of a kind cannot be played unless it is played as a 5 - card hand) Rank is determined by the value of the 4 card set, regardless of the value of the 5th card. It is also known as a poker. 
            *Straight Flush: A composite of the straight and flush: five cards in sequence in the same suit. Ranked the same as straights, suit being a tie-breaker. 
            ");
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"When it's your turn, click the cards you want to play and click the button ""Commit Hand"".
            Press pass if you want to and let the computer play out their turns.
            You can sort your hand by suite or rank at the bottom left
            New Game is self explanatory.
            The slider determines how long each computer turn takes - the longer it is, the longer you get to see the cards they put down, but slows the momentum of the game. 
            Check ""I want to go first."" for easy mode. The player that goes first has a slight advantage and is usually the player that is dealt the weakest card in the game - the three of clubs.
            ");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

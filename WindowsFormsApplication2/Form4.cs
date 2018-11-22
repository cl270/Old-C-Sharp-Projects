using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Collections;

namespace WindowsFormsApplication2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private static Form4 inst;
        public static Form4 instant
        {
            get
            {
                if (inst == null)
                {
                    inst = new Form4();
                }
                return inst;
            }
        }
        public int[] possible;
        private void Form4_Load(object sender, EventArgs e)
        {
            label34.Text = "";
            label35.Text = "";
            label36.Text = "";
            label37.Text = "";
            label38.Text = "3-: 0";
            label39.Text = "4: 0";
            label40.Text = "5: 0";
            label41.Text = "6: 0";
            label43.Text = "7+: 0";
            possible = new int[10] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        }

        public static int[] digitArr(int n)
        {
            if (n == 0) return new int[1] { 0 };

            var digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }
        public int[] guessaccuracy = new int[] { 0, 0, 0, 0 };
        public int digit;
        public int countguess = 0;
        public int[] previousvalue = new int[4] { 0, 0, 0, 0 };
        public int[] guess = new int[5];
        public int[] integerarr = new int[4];
        public int[] taken = new int[9];
        public int[] counter = new int[] { 0, 0, 0, 0, 0 };
        public int A;
        public int B;
        public int flag;
        public int[] flagarray = new int[4] { 0, 0, 0, 0 };
        public void ai()
        {
            List<int> trackzero = new List<int>();
            taken = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] track = new int[] { 0, 0, 0, 0 };
            int n = int.Parse(textBox4.Text);
            int[] digitarray = digitArr(n);
            int[] other = { 1, 2, 3 };
            int[] digitarray2 = { 0, 0 };
            int[] flagarraycopy = flagarray;

            flagarray = new int[4] { 0, 0, 0, 0 };
            integerarr = new int[] { digitarray[0], digitarray[1], digitarray[2], digitarray[3] };
            textBox4.ReadOnly = true;
            button7.Enabled = false;
            button9.Enabled = false;
            {
                if (guessaccuracy.Contains(2))
                {
                    if (guessaccuracy[0] == 2)
                    {
                        taken[guess[1] - 1] = 1;
                    }
                    if (guessaccuracy[1] == 1)
                    {
                        taken[guess[2] - 1] = 1;
                    }
                    if (guessaccuracy[2] == 2)
                    {
                        taken[guess[3] - 1] = 1;
                    }
                    if (guessaccuracy[3] == 2)
                    {
                        taken[guess[4] - 1] = 1;
                    }
                }
                if (guessaccuracy.Contains(1))
                {
                    if (guessaccuracy[0] == 1)
                    {
                        do
                        {
                            bdigit(possible);
                            guess[1] = digit;
                        } while (previousvalue[0] == digit);
                        taken[guess[1] - 1] = 1;
                        flagarray[0] = 1;
                    }
                    if (guessaccuracy[1] == 1)
                    {
                        do
                        {
                            bdigit(possible);
                            guess[2] = digit;
                        } while (previousvalue[1] == digit);
                        taken[guess[2] - 1] = 1;
                        flagarray[1] = 1;
                    }
                    if (guessaccuracy[2] == 1)
                    {
                        do
                        {
                            bdigit(possible);
                            guess[3] = digit;
                        } while (previousvalue[2] == digit);
                        taken[guess[3] - 1] = 1;
                        flagarray[2] = 1;
                    }
                    if (guessaccuracy[3] == 1)
                    {
                        do
                        {
                            bdigit(possible);
                            guess[4] = digit;
                        } while (previousvalue[3] == digit);
                        taken[guess[4] - 1] = 1;
                        flagarray[3] = 1;
                    }
                }
                if (guessaccuracy.Contains(0))
                {
                    if (guessaccuracy[0] == 0)
                    {
                        do
                        {
                            bdigit(possible);
                            guess[1] = digit;
                        } while (previousvalue[0] == digit);
                        taken[guess[1] - 1] = 1;
                    }
                    if (guessaccuracy[1] == 0)
                    {
                        do
                        {
                            bdigit(possible);
                            guess[2] = digit;
                        } while (previousvalue[1] == digit);
                        taken[guess[2] - 1] = 1;
                    }
                    if (guessaccuracy[2] == 0)
                    {
                        do
                        {
                            bdigit(possible);
                            guess[3] = digit;
                        } while (previousvalue[2] == digit);
                        taken[guess[3] - 1] = 1;
                    }
                    if (guessaccuracy[3] == 0)
                    {
                        do
                        {
                            bdigit(possible);
                            guess[4] = digit;
                        } while (previousvalue[3] == digit);
                        taken[guess[4] - 1] = 1;
                    }
                }
            }
            if (flagarray.Sum() >= 1)
            {
                shift(flagarray);
            }
            evaluate();
            A = 0;
            B = 0;
            for (int x = 0; x <= 3; x++)
            {
                if (guessaccuracy[x] == 2)
                {
                    A++;
                }
                else if (guessaccuracy[x] == 1)
                {
                    B++;
                }
            }
            countguess++;
            label34.Text = "Guess: " + guess[1].ToString() + guess[2].ToString() + guess[3].ToString() + guess[4].ToString();
            label35.Text = A.ToString() + "A " + B.ToString() + "B";
            label36.Text = "Total Guesses: " + countguess.ToString();
            previousvalue = new int[4] { guess[1], guess[2], guess[3], guess[4] };
            if (guessaccuracy.Average() == 2)
            {
                label37.Text = "4A, Correct Guess.";
                button5.Enabled = false;
                if (countguess <= 3)
                {
                    counter[0]++;
                    label38.Text = "3-: " + counter[0].ToString();
                }
                else if (countguess == 4)
                {
                    counter[1]++;
                    label39.Text = "4: " + counter[1].ToString();
                }
                else if (countguess == 5)
                {
                    counter[2]++;
                    label40.Text = "5: " + counter[2].ToString();
                }
                else if (countguess == 6)
                {
                    counter[3]++;
                    label41.Text = "6: " + counter[3].ToString();
                }
                else
                {
                    counter[4]++;
                    label43.Text = "7+: " + counter[4].ToString();
                }
            }
        }

        public void aiouter(int repeat)
        {

            if (repeat == 0)
                ai();
            else if (repeat > 0)
            {
                for (int p = 0; p < repeat; p++)
                {
                    while (guessaccuracy.Average() != 2)
                    {
                        ai();
                    }
                    reset();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            aiouter(0);
        }

        public void evaluate()
        {
            for (int x = 0; x <= 3; x++)
            {
                if (guess[x + 1] == integerarr[x])
                {
                    guessaccuracy[x] = 2;
                    possible[guess[x + 1]] = 1;
                }
                else if (integerarr.Contains(guess[x + 1]))
                {
                    guessaccuracy[x] = 1;
                }
                else if (integerarr.Contains(guess[x + 1]) == false)
                {
                    guessaccuracy[x] = 0;
                    possible[guess[x + 1]] = 1;
                }
            }
        }
        public void bdigit(int[] possible)
        {
            int counter = 0;
            digit = 0;
            flag = 0;
            Random randdigit = new Random(Guid.NewGuid().GetHashCode());
            while (possible[digit] == 1 || taken[digit - 1] == 1)
            {
                digit = randdigit.Next(1, 10);
                counter++;
                if (counter > 50)
                {
                    flag = 1;
                    while (taken[digit - 1] == 1)
                    {
                        digit = randdigit.Next(1, 10);
                    }
                    break;
                }
            }

        }
        public void generate()
        {
            taken = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] generator = new int[4];
            Random randdigit = new Random(Guid.NewGuid().GetHashCode());

            for (int x = 0; x <= 3; x++)
            {
                do
                {
                    generator[x] = randdigit.Next(1, 10);
                } while (taken[generator[x] - 1] == 1);
                taken[generator[x] - 1] = 1;
            }
            textBox4.Text = generator[0].ToString() + generator[1].ToString() + generator[2].ToString() + generator[3].ToString();
        }

        public void shift(int[] flagarray)
        {
            int firstb = 0;
            int secondb = 0;
            int thirdb = 0;
            int fourthb = 0;
            if (flagarray.Sum() >= 2)
            {
                firstb = guess[Array.IndexOf(flagarray, 1) + 1];
                flagarray[Array.IndexOf(flagarray, 1)] = 0;
                secondb = guess[Array.IndexOf(flagarray, 1) + 1];
                flagarray[Array.IndexOf(flagarray, 1)] = 0;
                if (flagarray.Sum() >= 3)
                {
                    thirdb = guess[Array.IndexOf(flagarray, 1) + 1];
                    flagarray[Array.IndexOf(flagarray, 1)] = 0;
                    if (flagarray.Sum() == 4)
                    {
                        fourthb = guess[Array.IndexOf(flagarray, 1) + 1];
                    }
                }
                if (flagarray.Sum() == 2)
                {
                    int temp = guess[Array.IndexOf(guess, firstb)];
                    guess[Array.IndexOf(guess, firstb)] = guess[Array.IndexOf(guess, secondb)];
                    guess[Array.IndexOf(guess, secondb)] = temp;
                }
                else if (flagarray.Sum() == 3)
                {
                    int temp = guess[Array.IndexOf(guess, firstb)];
                    guess[Array.IndexOf(guess, firstb)] = guess[Array.IndexOf(guess, secondb)];
                    guess[Array.IndexOf(guess, secondb)] = guess[Array.IndexOf(guess, thirdb)];
                    guess[Array.IndexOf(guess, thirdb)] = temp;
                }
                else if (flagarray.Sum() == 4)
                {
                    int temp = guess[Array.IndexOf(guess, firstb)];
                    guess[Array.IndexOf(guess, firstb)] = guess[Array.IndexOf(guess, secondb)];
                    guess[Array.IndexOf(guess, secondb)] = guess[Array.IndexOf(guess, thirdb)];
                    guess[Array.IndexOf(guess, thirdb)] = guess[Array.IndexOf(guess, fourthb)];
                    guess[Array.IndexOf(guess, fourthb)] = temp;
                }
            }

        }

        public void reset()
        {
            button7.Enabled = true;
            button5.Enabled = true;
            button9.Enabled = true;
            textBox4.ReadOnly = false;
            textBox4.Text = "1234";
            label34.Text = "";
            label35.Text = "";
            label36.Text = "";
            label37.Text = "";
            guessaccuracy = new int[] { 0, 0, 0, 0 };
            possible = new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            countguess = 0;
            generate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            generate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] tokenData = new byte[25];
            rng.GetNonZeroBytes(tokenData);
            int a = 1;
            if (tokenData[1] < (Byte)30)
            {
                a = 1;
            }
            if (tokenData[1] >= (Byte)30 && tokenData[1] < (Byte)60)
            {
                a = 2;
            }
            if (tokenData[1] >= (Byte)60 && tokenData[1] < (Byte)90)
            {
                a = 3;
            }
            if (tokenData[1] >= (Byte)90 && tokenData[1] < (Byte)120)
            {
                a = 4;
            }
            if (tokenData[1] >= (Byte)120 && tokenData[1] < (Byte)150)
            {
                a = 5;
            }
            if (tokenData[1] >= (Byte)150 && tokenData[1] < (Byte)180)
            {
                a = 6;
            }
            if (tokenData[1] >= (Byte)180 && tokenData[1] < (Byte)210)
            {
                a = 7;
            }
            if (tokenData[1] >= (Byte)210 && tokenData[1] < (Byte)240)
            {
                a = 8;
            }
            if (tokenData[1] >= (Byte)240 && tokenData[1] <= (Byte)255)
            {
                a = 9;
            }
            label44.Text = a.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int guesses = int.Parse(textBox5.Text);
            aiouter(guesses);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            counter = new int[] { 0, 0, 0, 0, 0 };
            label38.Text = "3-: 0";
            label39.Text = "4: 0";
            label40.Text = "5: 0";
            label41.Text = "6: 0";
            label43.Text = "7+: 0";
        }
    }
}

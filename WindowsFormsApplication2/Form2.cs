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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private static Form2 inst;
        public static Form2 instant
        {
            get
            {
                if (inst == null||inst.IsDisposed == true)
                {
                    inst = new Form2();
                }
                return inst;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double terms = double.Parse(textBox2.Text);
            double safe;
            double factorial;
            double n;
            double twon;
            double neg;
            n = 0;
            safe = 0;
            factorial = 1;
            neg = 1;
            twon = 1;
            while (n < terms)
            {
                safe = safe + (neg * ((Math.Pow(a, twon)) / factorial));
                n++;
                twon = (2 * n) + 1;
                factorial = factorial * twon * (twon - 1);
                neg *= -1;
            }
            label3.Text = safe.ToString();
            double realvalue;
            realvalue = Math.Sin(a);
            label6.Text = realvalue.ToString();
            n = 0;
            safe = 0;
            factorial = 1;
            neg = 1;
            twon = 1;
            do
            {
                safe = safe + (neg * ((Math.Pow(a, twon)) / factorial));
                n++;
                twon = (2 * n) + 1;
                factorial = factorial * twon * (twon - 1);
                neg *= -1;
            } while (n < terms);
            label5.Text = safe.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            int terms;
            double sum = 0.0;
            double fact = 1;
            double sign = 1;
            double po;
            double valu;
            terms = int.Parse(textBox2.Text);
            valu = double.Parse(textBox1.Text);
            for (i = 1; i <= terms; i += 2)
            {
                if (i > 1)
                {
                    fact = fact * i * (i - 1);
                }
                po = Math.Pow(valu, i);
                sum += (sign * po / fact);
                sign *= -1;

            }
            label4.Text = sum.ToString();
        }
    }
}

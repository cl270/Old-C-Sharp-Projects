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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void showform(Form frm)
        {
            frm.MdiParent = this;
            frm.Activate();
            if(frm.IsDisposed == true)
            {
                frm = new Form();
            }
            frm.Show();
        }

        private void taylorSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showform(Form2.instant);
        }

        private void pokerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showform(Form3.instant);
        }

        private void a4BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showform(Form4.instant);
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showform(Form5.instant);
        }

        private void robotPianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showform(Form6.instant);
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made 2015-16 Paul Lee");
        }

        private void textEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showform(Form7.instant);
        }

        private void bigTwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showform(Form8.instant);
        }

        private void robotArtistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showform(Form9.instant);
        }

        private void solarSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showform(Form10.instant);
        }
    }
    
    }



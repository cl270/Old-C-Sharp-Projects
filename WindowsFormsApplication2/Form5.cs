using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using EVOL.NET;

namespace WindowsFormsApplication2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private static Form5 inst;
        public static Form5 instant
        {
            get
            {
                if (inst == null)
                {
                    inst = new Form5();
                }
                return inst;
            }
        }
        DataGridView dgv = new DataGridView();
        static SqlConnection cnn;
        string connectionString = null;
        private void button11_Click(object sender, EventArgs e)
        {
            connectionString = null;
            //connectionString = "Server= " + textBox6.Text + "; Database= " + textBox7.Text + "; Integrated Security = SSPI; ";
            //connectionString = "Data Source= " + textBox6.Text + ";Initial Catalog= " + textBox7.Text + "; Persist Security Info = True;Integrated Security = true; ";
            connectionString = "server=DESKTOP-5FNNB3C\\SQLEXPRESS;" +
                                       "Trusted_Connection=yes;" +
                                       "database=Yelp; " +
                                       "connection timeout=30";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            try
            {

                refresh();
                MessageBox.Show("Connection Open ! ");
                button14.Visible = true;
                button15.Visible = true;
                button16.Visible = true;
                button17.Visible = true;
                button18.Visible = true;
                button19.Visible = true;
                button20.Visible = true;
                button21.Visible = true;
                dataGridView1.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;
                textBox15.Visible = true;
                textBox16.Visible = true;
                textBox17.Visible = true;
                textBox18.Visible = true;
                textBox19.Visible = true;
                textBox20.Visible = true;
                textBox21.Visible = true;
                label49.Visible = true;
                label50.Visible = true;
                label51.Visible = true;
                label52.Visible = true;
                label53.Visible = true;
                label54.Visible = true;
                label55.Visible = true;
                label56.Visible = true;
                label57.Visible = true;
                label58.Visible = true;
                label59.Visible = true;
                label60.Visible = true;
                label61.Visible = true;
                checkBox1.Visible = true;
                label62.Visible = true;
                textBox22.Visible = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Close();
                MessageBox.Show("Connection Closed ! ");
                textBox8.Visible = false;
                button13.Visible = false;
                label48.Visible = false;
                dataGridView1.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                label49.Visible = false;
                label50.Visible = false;
                label51.Visible = false;
                label52.Visible = false;
                label53.Visible = false;
                label54.Visible = false;
                label55.Visible = false;
                label56.Visible = false;
                label57.Visible = false;
                label58.Visible = false;
                label59.Visible = false;
                label60.Visible = false;
                label61.Visible = false;
                checkBox1.Visible = false;
                checkBox1.Checked = false;
                label62.Visible = false;
                textBox22.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Can't close connection because connection not open ! ");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                SqlCommand command = new SqlCommand(textBox8.Text, cnn);
                command.CommandType = CommandType.Text;
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                dataadapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Incorrect command syntax.");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string tb9 = textBox9.Text;
            string tb10 = textBox10.Text;
            string tb15 = textBox15.Text;
            string tb16 = textBox16.Text;
            UpdateTable(tb9, tb10, tb15, tb16);
            MessageBox.Show("Insert Suceeded.");
            refresh();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string tb9 = "";
            string tb10 = "";
            string tb15;
            string tb16;
            double buy;
            double sell;
            double fee;
            double profit = 0;
            double profitcounter = 0;
            double SBcounter = 0;
            double minuscounter = 0;
            for (int x = 1; x < dataGridView1.Rows.Count; x++)
            {
                try
                {
                    buy = Convert.ToDouble(dataGridView1.Rows[x].Cells["BuyPrice"].Value.ToString());
                    fee = Convert.ToDouble(dataGridView1.Rows[x].Cells["EbayPaypalFee"].Value.ToString());
                    sell = Convert.ToDouble(dataGridView1.Rows[x].Cells["SellPrice"].Value.ToString());
                }
                catch
                {
                    continue;
                }
                for (int y = 1; y <= 4; y++)
                {
                    if (y == 1)
                    {
                        tb10 = "Profit";
                        profit = (sell - buy) * (1 - fee);
                        profitcounter += profit;
                        tb9 = profit.ToString();
                    }
                    else if (y == 2)
                    {
                        tb10 = "ProfitPercentage";
                        tb9 = ((profit / buy) * 100).ToString();
                    }
                    else if (y == 3)
                    {
                        tb10 = "ShoppingBudget";
                        tb9 = (profit * 0.15).ToString();
                        SBcounter += (profit * 0.15);
                    }
                    else if (y == 4)
                    {
                        tb10 = "MinusEmployeeCost";
                        tb9 = (profit * 0.85).ToString();
                        minuscounter += (profit * 0.85);
                    }
                    tb15 = dataGridView1.Rows[x].Cells["ItemName"].Value.ToString();
                    tb16 = "ItemName";
                    UpdateTable(tb9, tb10, tb15, tb16);
                }
            }
            UpdateTable(profitcounter.ToString(), "Profit", "Sum", "ItemName");
            UpdateTable(SBcounter.ToString(), "ShoppingBudget", "Sum", "ItemName");
            UpdateTable(minuscounter.ToString(), "MinusEmployeeCost", "Sum", "ItemName");
            MessageBox.Show("Auto Profit Calculate Complete.");
            refresh();
        }

        public void refresh()
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            SqlCommand command = new SqlCommand("Select * from Yelp", cnn);
            command.CommandType = CommandType.Text;
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            dataadapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            refresh();
        }

        static void Insert(string tb13, string tb14)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EbayInventory(" + tb13 + ") VALUES('" + tb14 + "')", cnn))
                {
                    cmd.Parameters.AddWithValue(tb14, 1);
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Suceeded");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Insert Failed");
            }
        }

        static void UpdateTable(string tb9, string tb10, string tb15, string tb16)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE EbayInventory SET " + tb10 + "='" + tb9 + "' WHERE " + tb16 + "='" + tb15 + "'", cnn))
                {
                    int rows = cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("Insert Failed.");
            }
        }

        /*Find and Replace
        UPDATE hc_events
SET Title = REPLACE(Title, '&', 'and')
WHERE Title LIKE '%&%' 
*/

        static void Delete(string tb11, string tb12)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM EbayInventory WHERE " + tb12 + "='" + tb11 + "'", cnn))
                {
                    cmd.Parameters.AddWithValue("tb11", 1);
                    int rows = cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Delete Suceeded.");
            }
            catch (SqlException)
            {
                MessageBox.Show("Delete Failed.");
            }
        }
        public void Find(string tb17, string tb18)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                SqlCommand command = new SqlCommand("Select * from EbayInventory Where " + tb17 + " Like '%" + tb18 + "%'", cnn);
                command.CommandType = CommandType.Text;
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                dataadapter.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("F-F-Found!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Find Failed or Text does not exist in specified column.");
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            string tb11 = textBox11.Text;
            string tb12 = textBox12.Text;
            Delete(tb11, tb12);
            refresh();
        }



        private void button18_Click(object sender, EventArgs e)
        {
            string tb13 = textBox13.Text;
            string tb14 = textBox14.Text;
            Insert(tb13, tb14);
            refresh();
        }

        StringFormat strFormat; //Used to format the grid rows.
        List<int> arrColumnLefts = new List<int>();
        //ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        List<int> arrColumnWidths = new List<int>();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Credits to Life with .Net on codeproject.com
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString(textBox22.Text,
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString(textBox22.Text,
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " +
                                DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dataGridView1.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString(textBox22.Text,
                                new Font(new Font(dataGridView1.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }
        public int count = 0;
        public UArm uarm;
        private void button19_Click(object sender, EventArgs e)
        {

            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            //printDialog.UseEXDialog = true;


            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                try
                {

                    printDocument1.DefaultPageSettings.Landscape = true;
                    printDocument1.DocumentName = "Table Print";
                    printDocument1.Print();
                    GetPageCount(printDocument1);
                    Thread.Sleep(10000 + 5000 * count);
                    uarm = new UArm("COM4", false, 4000); // Argu1: port Num; Argu2: Debug Mode; Argu3: Delay time, default is 4000
                    for (int x = 1; x <= count; x++)
                    {
                        Armprint();
                        if (x < count)
                            Thread.Sleep(6000);
                    }
                }
                catch
                {
                    MessageBox.Show("Print Failed or Arm not Operable.");
                }
            }

        }

        public void Armprint()
        {
            uarm.MoveTo(-3.5, -16.47, 25.73);
            uarm.MoveTo(16.5, -0.83, 25.73);
            Thread.Sleep(500);
            uarm.MoveTo(16.5, -0.8, 21.3);
            uarm.PumpON();
            Thread.Sleep(500);
            uarm.MoveTo(-3.5, -16.47, 25.73);
            uarm.MoveTo(-21, -13.2, 10);
            uarm.PumpOFF();
            Thread.Sleep(500);
            uarm.MoveTo(-3.5, -16.47, 25.73);
            //Console.WriteLine(uarm.findX().ToString() + " " + uarm.findY().ToString() + " " + uarm.findZ().ToString());
            uarm.detachAll();
        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int GetPageCount(System.Drawing.Printing.PrintDocument printDocument)
        {

            printDocument.PrintController = new System.Drawing.Printing.PreviewPrintController();
            printDocument.PrintPage += (sender, e) => count++;
            printDocument.Print();
            return count;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            string tb17 = textBox17.Text;
            string tb18 = textBox18.Text;
            Find(tb17, tb18);
        }

        public void findrange(string tb19, string tb20, string tb21)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                SqlCommand command = new SqlCommand("Select * from EbayInventory Where " + tb19 + " between '" + tb20 + "' and '" + tb21 + "'", cnn);
                command.CommandType = CommandType.Text;
                SqlDataAdapter dataadapter = new SqlDataAdapter(command);
                dataadapter.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("F-F-Found!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Column not numeric or Invalid Range.");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string tb19 = textBox19.Text;
            string tb20 = textBox20.Text;
            string tb21 = textBox21.Text;
            findrange(tb19, tb20, tb21);
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox8.Visible = true;
                button13.Visible = true;
                label48.Visible = true;
            }
            else
            {
                textBox8.Visible = false;
                button13.Visible = false;
                label48.Visible = false;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}

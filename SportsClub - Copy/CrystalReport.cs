using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SportsClub
{
    public partial class CrystalReport : Form
    {
        //Saved for efficiency
        CrystalReport1 cr;
        CrystalReport2 cr2;
        public CrystalReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        /**
         * Tab 2
         * report of memebers table
         * showing their count (summarized)
         */
        private void button4_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.ReportSource = cr2;
        }

        /**
         * Tab 1
         * set our parameters
         * event type
         * start date
         * end date
         */
        private void button3_Click(object sender, EventArgs e)
        {
           
            cr.SetParameterValue(0, comboBox2.Text);
            cr.SetParameterValue(1, textBox1.Text);
            cr.SetParameterValue(2, textBox2.Text);

            crystalReportViewer1.ReportSource = cr;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /**
         * Form load
         * set my crystal reports
         */
        private void CrystalReport_Load(object sender, EventArgs e)
        {
            cr = new CrystalReport1();
            foreach (ParameterDiscreteValue v in cr.ParameterFields[0].DefaultValues)
                comboBox2.Items.Add(v.Value);

            cr2 = new CrystalReport2();
        }

        private void CrystalReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //logout
        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm admin = new AdminForm();
            admin.Show();
        }
    }
}

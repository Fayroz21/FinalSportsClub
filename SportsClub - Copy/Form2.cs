using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace SportsClub
{
    /**
     * Admin Form to Edit Tables
     */
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        //Connection Strung
        //DataAdapter
        //saved for efficiency 
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /**
         * Tab 1
         * Load Information button
         * Loading event table
         * Based on event type
         */
        private void button1_Click(object sender, EventArgs e)
        {
            //check if he didn't choose a type
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value");
                return;
            }
            String command1 = "select * from events where eventtype =: type";
            adapter = new OracleDataAdapter(command1, ordb);
            adapter.SelectCommand.Parameters.Add("type", comboBox1.SelectedItem.ToString());
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        /**
         * Tab 1
         * save what admin have done
         */
        private void button2_Click(object sender, EventArgs e)
        {
            
            builder = new OracleCommandBuilder(adapter);
            try
            {
                adapter.Update(ds.Tables[0]);
                MessageBox.Show("The Changes are updated successfully");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }


        //Date
        private void Form2_Load(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString();
            
        }

        /**
         * Tab 2
         * search button
         * by ID
         */
        private void searchBtn_Click(object sender, EventArgs e)
        {
            string cmdmemberData = "select memberid, fisrtname, lastname, phone_number, gender, city, streetname, username from member where memberid =:id";
            adapter = new OracleDataAdapter(cmdmemberData, ordb);
            adapter.SelectCommand.Parameters.Add("id", memberID_txt.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            memberGridView.DataSource = ds.Tables[0];
        }

        /**
         * Tab 2
         * update changes
         * 
         */
        private void updateChangesBtn_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("The Changes are updated successfully");
        }

        private void tabPage2_Click(object sender, EventArgs e){ }

        /**
         * Tab 2
         * view all member data
         */
        private void viewAll_Click(object sender, EventArgs e)
        {
            string membersInfo = "select * from member";
            adapter = new OracleDataAdapter(membersInfo, ordb);
            ds = new DataSet();
            adapter.Fill(ds);
            memberGridView.DataSource = ds.Tables[0];
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateLabel_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Log out
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}

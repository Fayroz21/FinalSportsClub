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
    public partial class LoginForm : Form
    {
        //String Connection
        string ordb = "data source=orcl; user id=hr; password=hr;";
        OracleConnection conn;

        //Admin class to retrieve its data
        AdminClass admin;

        //Saved For efficiency 
        //To know who is loging in
        //and which form he will Login
        string personType = " ";

        public LoginForm()
        {
            InitializeComponent();
            admin = new AdminClass();
        }

        /**
         * Form load f8unction
         */
        private void Admin_Load(object sender, EventArgs e)
        {
            //Open Connection
            conn = new OracleConnection(ordb);
            conn.Open();

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personType = "admin";
        }

        /**
         * Login Function 
         * For member and admin
         */
        private void btn_login_Click(object sender, EventArgs e)
        {
            //Check if the user didn't choose
            //a button from meniu strip
            if (personType == " ")
            {
                MessageBox.Show("You Have to Choose Where to Go");
                return;
            }

            //If admin.. check admin
            if (personType == "admin" || personType == "adminCrystal")
            {


                if (admin.login(txt_user.Text, Convert.ToInt32(txt_pass.Text)))
                {
                    MessageBox.Show("Welcome Admin!");
                    if (personType == "admin")
                    {
                        this.Hide();
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                    }
                    else
                    {
                        this.Hide();
                        CrystalReport cr = new CrystalReport();
                        cr.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Wrong User Name or Password! ");


                }
            }
            //If member..check member
            else
            {
                OracleCommand findUser = new OracleCommand();
                findUser.Connection = conn;
                findUser.CommandText = "select userName, password from member";
                findUser.CommandType = CommandType.Text;

                OracleDataReader dr = findUser.ExecuteReader();
                string name = txt_user.Text;
                int password = Convert.ToInt32(txt_pass.Text);
                bool user = false;

                
                while (dr.Read())
                {
                    
                    if (name == dr[0].ToString() && password == Convert.ToInt32(dr[1].ToString()))
                    {
                        MessageBox.Show("Welcome User!");
                        this.Hide();
                        MembersForm membersForm = new MembersForm();
                        membersForm.Show();
                        user = true;
                        break;
                    }
                   
                }
                if (!user)
                {
                    MessageBox.Show("Wrong Username and Password\nPlease Try Again");
                }
                dr.Close();
            }
        }

        
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personType = "user";
        }

        private void crystalReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void membersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personType = "adminCrystal";
        }

        private void eventsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personType = "adminCrystal";
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class LoginForm : Form
    {
        public bool check;

        PosDAO dao = new PosDAO();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            POS_Screen user = new POS_Screen();
            if (Username_txt.Text != string.Empty && Password_txt.Text != string.Empty)
            {
                CheckAccount();
                if (check == true)
                {
                    //hides the login form
                    this.Hide();
                 
                    //shows the user form
                    user.username = Username_txt.Text;
                    user.roleType = UserType_box.Text;
                    user.ShowDialog();
                    
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //close the application
        private void CancelBtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        
        public bool CheckAccount()
        {

            dao.getConnection();
            string query;
            int count = 0;



            try
            {
                using (SQLiteConnection con = new SQLiteConnection(dao.connectionString))
                {
                    con.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    //implemnt a checkbox for manager  and do if statment and and new query for an new table

                   
                    query = @"SELECT * FROM Employee WHERE username='" + Username_txt.Text + "' and password='" + Password_txt.Text + "' and role='" + UserType_box.Text + "'";
                    Console.WriteLine(query);
                   // query = @"SELECT * FROM Employee WHERE username='" + Username_txt.Text + "' and password='" + Password_txt.Text + "'";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    SQLiteDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        count++;

                    }
                    Console.WriteLine(count);

                    if (count == 1)
                    {
                        MessageBox.Show("Succesful Login!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        check = true;

                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        check = false;
                    }


                }//end using
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return check;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

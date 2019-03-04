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
    public partial class POS_Screen : Form
    {
        public bool check;
        public int productID;
        public string username, roleType;
        PosDAO dao = new PosDAO();
        public POS_Screen()
        {
            InitializeComponent();
          
        }
        public void CatogoryBtns(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            switch (B.Name)
            {

                case "Soft_drinksBtn":
                    General_groupBox.Visible = false;
                    SnacksBox.Visible = false;
                    Magzines_box.Visible = false;
                    Soft_drinkBox.Location = General_groupBox.Location;
                    Soft_drinkBox.AutoSize = true;
                    Fruits_GroupBox.Visible = false;
                    Alcohol_Groupbox.Visible = false;
                    Soft_drinkBox.Visible = true;
                break;
                case "GeneralBtn":
                    General_groupBox.Visible = true;
                    //General_groupBox.Location = General_groupBox.Location;
                    Soft_drinkBox.Visible = false;
                    Magzines_box.Visible = false;
                    Alcohol_Groupbox.Visible = false;
                    Fruits_GroupBox.Visible = false;
                    SnacksBox.Visible = false;

                    break;

                case "SnacksBtn":
                    General_groupBox.Visible = false;
                    Soft_drinkBox.Visible = false;
                    SnacksBox.Location = General_groupBox.Location;
                    SnacksBox.AutoSize = true;
                    Alcohol_Groupbox.Visible = false;
                    Magzines_box.Visible = false;
                    Fruits_GroupBox.Visible = false;
                    SnacksBox.Visible = true;
                    break;


                    
                case "MagazinesBtn":
                    General_groupBox.Visible = false;
                    Soft_drinkBox.Visible = false;
                    SnacksBox.Visible = false;
                    Fruits_GroupBox.Visible = false;
                    Alcohol_Groupbox.Visible = false;
                    Magzines_box.Location = General_groupBox.Location;
                    Magzines_box.AutoSize = true;
                    Magzines_box.Visible = true;


                    break;
                case "FruitBtn":
                    General_groupBox.Visible = false;
                    Soft_drinkBox.Visible = false;
                    SnacksBox.Visible = false;
                    Magzines_box.Visible = false; ;
                    Alcohol_Groupbox.Visible = false;
                    Fruits_GroupBox.AutoSize = true;
                    Fruits_GroupBox.Location = General_groupBox.Location;
                    Fruits_GroupBox.Visible = true;

                    break;
                case"AlcoholBtn":
                    General_groupBox.Visible = false;
                    Soft_drinkBox.Visible = false;
                    SnacksBox.Visible = false;
                    Magzines_box.Visible = false; ;
                    Fruits_GroupBox.Visible = false;
                    Alcohol_Groupbox.AutoSize = true;
                    Alcohol_Groupbox.Location = General_groupBox.Location;
                    Alcohol_Groupbox.Visible = true;
                    break;

            }
        }
      
        private void POS_Screen_Load(object sender, EventArgs e)
        {
            General_groupBox.AutoSize = true;
            loggedAs_Txt.Text = "Logged in as: " + username;
            roleType_Txt.Text = "Role: " + roleType;


        }

        public void  GetProduct(int id)
        {
            dao.getConnection();
            string query  = "select * FROM Stock WHERE ProductID = '"+id+"'";

            SQLiteConnection conn = new SQLiteConnection(dao.connectionString);
           SQLiteCommand cmd = new SQLiteCommand(query,conn);
           
            Console.WriteLine(query);
            SQLiteDataReader reader;

            DataTable item = new DataTable();
            

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    
                        string a = reader.GetValue(1).ToString();
                        string b = reader.GetValue(2).ToString();
                    
                    //adds the items to datagridview from database
                    var da = new SQLiteDataAdapter(query, conn);
                    da.Fill(item);
                    DataGrid_items.DataSource =item;

                       // DataGrid_items.Rows.Add(item);
                        Output_screen.Text = a + " £" + b;

                        Console.WriteLine(a);

                    }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        
       
        public void AllBtns(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            switch (B.Name) {
                //fruits
                case "appleBtn":
                    Output_screen.Clear();
                    productID = 29;
                    GetProduct(productID);
                break;
                case "BannanBtn":
                    Output_screen.Clear();
                    productID = 30;
                    GetProduct(productID);
                break;
               
                case "OrangeBtn":
                    Output_screen.Clear();
                    productID = 31;
                    GetProduct(productID);
                break;

                case "KiwiBtn":
                    Output_screen.Clear();
                    productID = 33;
                    GetProduct(productID);
                break;
                case "StrawberryBtn":
                    Output_screen.Clear();
                    productID = 34;
                    GetProduct(productID);
                 break;
                //Drinks
                case "CokeBtn":
                    Output_screen.Clear();
                    productID = 7;
                    GetProduct(productID);
                    break;
                 case "SevenUP_Btn":
                    Output_screen.Clear();
                    productID = 8;
                    GetProduct(productID);
                    break;

                case "FantaBtn":
                    Output_screen.Clear();
                    productID = 9;
                    GetProduct(productID);
                    break;

                case "DrpepperBtn":
                    Output_screen.Clear();
                    productID = 10;
                    GetProduct(productID);
                    break;
                    
                case "LiltBtn":
                    Output_screen.Clear();
                    productID = 11;
                    GetProduct(productID);
                    break;
                    
                case "RubiconBtn":
                    Output_screen.Clear();
                    productID = 12;
                    GetProduct(productID);
                    break;

                case "SpriteBtn":
                    Output_screen.Clear();
                    productID = 13;
                    GetProduct(productID);
                    break;
                    //pepsi needs adding to database
                case "PepsiBtn":
                    Output_screen.Clear();
                    productID = 00;
                    GetProduct(productID);
                    break;

                //Crisps
                case "C_onionBtn":
                    Output_screen.Clear();
                    productID = 20;
                    GetProduct(productID);
                    break;

                case "P_cocktailBtn":
                    Output_screen.Clear();
                    productID = 21;
                    GetProduct(productID);
                    break;
                case "S_saltBtn":
                    Output_screen.Clear();
                    productID = 22;
                    GetProduct(productID);
                    break;
                case "B_crispBtn":
                    Output_screen.Clear();
                    productID = 23;
                    GetProduct(productID);
                    break;
                case "Ck_crispBtn":
                    Output_screen.Clear();
                    productID = 24;
                    GetProduct(productID);
                    break;
                case "Bbq_crispBtn":
                    Output_screen.Clear();
                    productID = 25;
                    GetProduct(productID);
                    break;
                case "R_saltedBtn":
                    Output_screen.Clear();
                    productID = 26;
                    GetProduct(productID);
                    break;
                case "SC_crispBtn":
                    Output_screen.Clear();
                    productID = 27;
                    GetProduct(productID);
                    break;
                case "Ch_crispBtn":
                    Output_screen.Clear();
                    productID = 28;
                    GetProduct(productID);
                    break;




            }
        }

        private void EnquiryBtn_Click(object sender, EventArgs e)
        {

        }

    }
    }
    


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class loginScreen : Form
    {
        mainMenu main1 = new mainMenu();

        public static User user1 { get; set; }

   

        public loginScreen()
        {
            InitializeComponent();
            user1 = new User();

        }

        private void loginScreen_Load(object sender, EventArgs e)
        {
            namelbl.Visible = false;
            nametxt.Visible = false;
            emaillbl.Visible= false;
            emailtxt.Visible = false;
        }

        private void registerUser()
        {
            namelbl.Visible = true;
            nametxt.Visible = true;
            emaillbl.Visible = true;
            emailtxt.Visible = true;

         
                if ((userNametxt.Text != "") && ((passwordtxt.Text != "")))
                {
                    if ((nametxt.Text != "") && ((emailtxt.Text != "")))
                    {
                        string username = userNametxt.Text;
                        string password = passwordtxt.Text;
                        string email = emailtxt.Text;
                        string name = nametxt.Text;
                        System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                        if (expr.IsMatch(email))
                        {
                            user1.registerDetails(username, password,email,name);
                            namelbl.Visible = false;
                            nametxt.Visible = false;
                            emaillbl.Visible = false;
                            emailtxt.Visible = false;
                            passwordtxt.Text = "";

                           
                    }
                        else MessageBox.Show("Invalid Email, Please enter valid email");
                    }

                }
            else
                MessageBox.Show("Please make sure to fill in all fields");
        }

        private bool loginUser()
        {
            if ((userNametxt.Text != "") && ((passwordtxt.Text != "")))
            {
                user1.setUserName(userNametxt.Text);
                user1.setPassword(passwordtxt.Text);

                bool login = user1.validateDetails(user1.getusername(), user1.getPassword());
                if (login == true) { return true; }
            }
            return false;
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {

                            registerUser(); 
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            bool canLogin = loginUser();
            if (canLogin == true)
            {
                this.Hide();
                main1.Show();
            }
            

        }

     
    }
}


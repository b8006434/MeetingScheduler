using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MeetingApp
{
    public class User
    {

        private string username;   //var to store username inputted by user
        private string password;  //var to store password inputted by user
        private string email;     //var to store email inputted by user
        private string name;      //var to store name inputted by user
       



        public void setEmail(string newEmail)
        {
            email = newEmail; //function to set email outside the class
        }
        public string getEmail()
        {
            return email; //function to get email outside the class
        }
        public void setName(string newName)
        {
            name = newName; //function to set name outside the class
        }
        public string getName()
        {
            return name; //function to get email outside the class
        }
        public void setUserName(string newUsername)
        {
            username = newUsername; //function to set username outside the class
        }
        public void setPassword(string newPasssword)
        {
            password = newPasssword; //function to set password outside the class
        }
        public string getusername()
        {
            return username; //function to get username outside the class
        }
        public string getPassword()
        {
            return password; //function to get password outside the class
        }
        public bool validateDetails(string usernameSave, string passwordSave)
        {
            bool canLogin = false; //temp variable to return

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\database1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();  // establish connection to database and open the connection (database is included in the zip, you may need to change the url to your specific location)

            SqlCommand checkUser = new SqlCommand("Select usernameDatabase from login where usernameDatabase= @username", con);  //search username in database
            SqlCommand checkPassword = new SqlCommand("Select passwordDatabase from login where passwordDatabase= @password", con); //search password in database
            checkUser.Parameters.AddWithValue("@username", usernameSave); //add the username typed by user to sql command
            checkPassword.Parameters.AddWithValue("@password", passwordSave); //add the password typed by user to sql command
            var nId = checkUser.ExecuteScalar();  // execute the statement and save the outcome in value
            var nPass = checkPassword.ExecuteScalar(); // execute the statement and save the outcome in value
            if ((nId != null) && (nPass != null))  // if both username and password are right, let user login
            {
                MessageBox.Show("User has been validated");
                canLogin = true;
            }
            else  //else display a warning
            {
                MessageBox.Show("Username or password is wrong, try again");
                canLogin = false;
            }

            return canLogin;  // return value that determines if user is able to login 

        }
        public void registerDetails(string usernameSave, string passwordSave, string emailSave, string nameSave)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\database1.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open(); // connect to database and establish connection

            SqlCommand checkUser = new SqlCommand("Select usernameDatabase from login where usernameDatabase= @username", con); // statement to check if user exists
            checkUser.Parameters.AddWithValue("@Username", usernameSave); // value assigned to username to be searched in database
            var nId = checkUser.ExecuteScalar(); //execute the sql statement

            if (nId != null) // if user exists, display warning
            {
                MessageBox.Show("User Already Exists!");
            }
            else // else, register the user and save in database
            {
                username = usernameSave; // save username typed by user
                password = passwordSave; // save password typed by user
                SqlCommand cmd = new SqlCommand("insert into login values (@username, @password,@email,@name)", con); // statement to insert values into the table
                cmd.Parameters.AddWithValue("username", usernameSave); // insert username
                cmd.Parameters.AddWithValue("password", passwordSave); // insert password
                cmd.Parameters.AddWithValue("email", emailSave);    // insert email
                cmd.Parameters.AddWithValue("name", nameSave);      // insert name
                cmd.ExecuteNonQuery();   // execute the sql query
                MessageBox.Show("User " + username + " has been created!" + " Please login now"); // show a message to user confirming registration

            }






        }


        

        
    
    }
}


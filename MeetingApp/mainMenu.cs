using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace MeetingApp
{
    public partial class mainMenu : Form
    {
     private string user1PrefSet; //user1 preference set
     private string user1ExclSet; //user1 exclusion set
     private string user2PrefSet; //user2 preference set
     private string user2ExclSet; //user2 exclusion set
     private string user3PrefSet;//user3 preference set
     private string user3ExclSet;//user3 exclusion set
     private string user4PrefSet;//user4 preference set
     private string user4ExclSet;//user4 exclusion set
     private string fromSlot;    //from slot given by initiator
     private string toSlot;      //to slot given by initiator
     private string specEq;      //special equipment selected by initiator
     private string meetingRoom; //meeting room selected by initiator
     private bool user1InMeeting = false; //has user1 been deleted from meeting
     private bool user2InMeeting = false; //has user2 been deleted from meeting
     private bool user3InMeeting = false; //has user3 been deleted from meeting
     private bool user4InMeeting = false; //has user4 been deleted from meeting

        struct Slots
        {
          public int fromSlotint;
          public int toSlotint;
          public int user1ExclSetint;
          public int user1PrefSetint;
          public int user2PrefSetint;
          public int user2ExclSetint;
          public int user3PrefSetint;
          public int user3ExclSetint;
          public int user4PrefSetint;
          public int user4ExclSetint;
        }                   //struct to hold all the information about the slots

        Slots slots = new Slots();
        public mainMenu()
        {
            InitializeComponent();
        }

        private void MeetingApp_Load(object sender, EventArgs e)
        {
            //load the app with default data

            welcomelbl.Text = "Welcome " + loginScreen.user1.getusername();
            iniatortxt.Text = loginScreen.user1.getusername();

            user1lbl.Text = "Joe";
            user2lbl.Text = "Mehmet";
            user3lbl.Text = "Luqman";
            user4lbl.Text = "Pit";

            string[] slots = { "Slot 1", "Slot 2", "Slot 3", "Slot 4", "Slot 5" };
            string[] equipment = { "Equipment 1", "Equipment 2", "Equipment 3", "Equipment 4", };
            string[] meetingRoom = { "Room 1", "Room 2", "Room 3" };
            
            fromComboBox.DataSource = slots.ToList();
            toComboBox.DataSource = slots.ToList();
            specialuqcombobox.DataSource = equipment.ToList();
            roomcombobox.DataSource = meetingRoom.ToList();

            user1txt.Text = "Slot 3";
            user2txt.Text = "Slot 3";
            user3txt.Text = "Slot 2";
            user4txt.Text = "Slot 2";

            user1exclusionsetbox.Text = "Slot 1";
            user2exclusionsetbox.Text = "Slot 1";
            user3exclusionsetbox.Text = "Slot 4";
            user4exclusionsetbox.Text = "Slot 1";

            statustxtbox.Text = "Not Scheduled";


        }


        private bool isDataFilledIn()
        { //check that all the information has been filled in by the initator
            bool isData = false;

             user1PrefSet = user1txt.Text;
             user1ExclSet = user1exclusionsetbox.Text;
             user2PrefSet = user2txt.Text; ;
             user2ExclSet = user2exclusionsetbox.Text;;
             user3PrefSet = user3txt.Text; ;
             user3ExclSet = user3exclusionsetbox.Text;;
             user4PrefSet = user4txt.Text; ;
             user4ExclSet = user4exclusionsetbox.Text;;

            if (user1PrefSet != "")
            {
                if(user1ExclSet != "")
                {
                    if(user2PrefSet != "")
                    {
                        if (user2ExclSet != "")
                        {
                            if (user3PrefSet != "")
                            {
                                if (user3ExclSet != "")
                                {
                                    if (user4PrefSet != "")
                                    {
                                        if (user4ExclSet != "")
                                        {
                                            if(fromComboBox.SelectedItem != null)
                                            {
                                                fromSlot = fromComboBox.SelectedValue.ToString();
                                                if(toComboBox.SelectedItem != null)
                                                {
                                                    toSlot = toComboBox.SelectedValue.ToString();
                                                    isData = true;
                                                    if(specialuqcombobox.SelectedItem != null)
                                                    {
                                                        specEq = specialuqcombobox.SelectedValue.ToString();
                                                        if (roomcombobox.SelectedItem != null)
                                                        {
                                                            meetingRoom = roomcombobox.SelectedValue.ToString();
                                                        }
                                                    }
                                                    
                                                }
                                                else
                                                    errorstxtbox.Text=(loginScreen.user1.getusername() + ", please choose to slot");
                                            }
                                            else
                                                errorstxtbox.Text=(loginScreen.user1.getusername() + ", please choose from slot");

                                        }
                                        else
                                            errorstxtbox.Text=("Please enter user4 exclusion set");
                                    }
                                    else
                                        errorstxtbox.Text=("Please enter user4 preference set");
                                }
                                else
                                    errorstxtbox.Text=("Please enter user3 exclusion set");
                            }
                            else
                                errorstxtbox.Text=("Please enter user3 preference set");
                        }
                        else
                            errorstxtbox.Text=("Please enter user2 exclusion set");
                    }
                    else
                        errorstxtbox.Text=("Please enter user2 preferences set");
                }
                else
                    errorstxtbox.Text=("Please enter user1 exclusion set");
            }
            else
                errorstxtbox.Text = ("Please enter user1 preferences set");


            return isData;

        }

        private void convertSlotsToInteger()
        {
          // Retrieve the slot value, and store it as a number for easier manipulation   
            if (fromSlot != null)
            {
                if (fromSlot == "Slot 1")
                    slots.fromSlotint = 1;
                if (fromSlot == "Slot 2")
                    slots.fromSlotint = 2;
                if (fromSlot == "Slot 3")
                    slots.fromSlotint = 3;
                if (fromSlot == "Slot 4")
                    slots.fromSlotint = 4;
                if (fromSlot == "Slot 5")
                    slots.fromSlotint = 5;
            }
            if (toSlot != null)
            {
                if (toSlot == "Slot 1")
                    slots.toSlotint = 1;
                if (toSlot == "Slot 2")
                    slots.toSlotint = 2;
                if (toSlot == "Slot 3")
                    slots.toSlotint = 3;
                if (toSlot == "Slot 4")
                    slots.toSlotint = 4;
                if (toSlot == "Slot 5")
                    slots.toSlotint = 5;
            }
            if (user1PrefSet != null)
            {
                if (user1PrefSet == "Slot 1")
                    slots.user1PrefSetint = 1;
                if (user1PrefSet == "Slot 2")
                    slots.user1PrefSetint = 2;
                if (user1PrefSet == "Slot 3")
                    slots.user1PrefSetint = 3;
                if (user1PrefSet == "Slot 4")
                    slots.user1PrefSetint = 4;
                if (user1PrefSet == "Slot 5")
                    slots.user1PrefSetint = 5;
            }
            if (user1ExclSet != null)
            {
                if (user1ExclSet == "Slot 1")
                    slots.user1ExclSetint = 1;
                if (user1ExclSet == "Slot 2")
                    slots.user1ExclSetint = 2;
                if (user1ExclSet == "Slot 3")
                    slots.user1ExclSetint = 3;
                if (user1ExclSet == "Slot 4")
                    slots.user1ExclSetint = 4;
                if (user1ExclSet == "Slot 5")
                    slots.user1ExclSetint = 5;
            }
            if (user2PrefSet != null)
            {
                if (user2PrefSet == "Slot 1")
                    slots.user2PrefSetint = 1;
                if (user2PrefSet == "Slot 2")
                    slots.user2PrefSetint = 2;
                if (user2PrefSet == "Slot 3")
                    slots.user2PrefSetint = 3;
                if (user2PrefSet == "Slot 4")
                    slots.user2PrefSetint = 4;
                if (user2PrefSet == "Slot 5")
                    slots.user2PrefSetint = 5;
            }
            if (user2ExclSet != null)
            {
                if (user2ExclSet == "Slot 1")
                    slots.user2ExclSetint = 1;
                if (user2ExclSet == "Slot 2")
                    slots.user2ExclSetint = 2;
                if (user2ExclSet == "Slot 3")
                    slots.user2ExclSetint = 3;
                if (user2ExclSet == "Slot 4")
                    slots.user2ExclSetint = 4;
                if (user2ExclSet == "Slot 5")
                    slots.user2ExclSetint = 5;
            }
            if (user3PrefSet != null)
            {
                if (user3PrefSet == "Slot 1")
                    slots.user3PrefSetint = 1;
                if (user3PrefSet == "Slot 2")
                    slots.user3PrefSetint = 2;
                if (user3PrefSet == "Slot 3")
                    slots.user3PrefSetint = 3;
                if (user3PrefSet == "Slot 4")
                    slots.user3PrefSetint = 4;
                if (user3PrefSet == "Slot 5")
                    slots.user3PrefSetint = 5;
            }
            if (user3ExclSet != null)
            {
                if (user3ExclSet == "Slot 1")
                    slots.user3ExclSetint = 1;
                if (user3ExclSet == "Slot 2")
                    slots.user3ExclSetint = 2;
                if (user3ExclSet == "Slot 3")
                    slots.user3ExclSetint = 3;
                if (user3ExclSet == "Slot 4")
                    slots.user3ExclSetint = 4;
                if (user3ExclSet == "Slot 5")
                    slots.user3ExclSetint = 5;
            }
            if (user4PrefSet != null)
            {
                if (user4PrefSet == "Slot 1")
                    slots.user4PrefSetint = 1;
                if (user4PrefSet == "Slot 2")
                    slots.user4PrefSetint = 2;
                if (user4PrefSet == "Slot 3")
                    slots.user4PrefSetint = 3;
                if (user4PrefSet == "Slot 4")
                    slots.user4PrefSetint = 4;
                if (user4PrefSet == "Slot 5")
                    slots.user4PrefSetint = 5;
            }
            if (user4ExclSet != null)
            {
                if (user4ExclSet == "Slot 1")
                    slots.user4ExclSetint = 1;
                if (user4ExclSet == "Slot 2")
                    slots.user4ExclSetint = 2;
                if (user4ExclSet == "Slot 3")
                    slots.user4ExclSetint = 3;
                if (user4ExclSet == "Slot 4")
                    slots.user4ExclSetint = 4;
                if (user4ExclSet == "Slot 5")
                    slots.user4ExclSetint = 5;
            }
        }

        private bool checkIfSlotsMatch()
        {
            //check for conflicts between user given slotsa and initator given slots
            //if conflict arises, display which conflict and how to solve it to the user
            //if there is no conflitm display that the user fits into meeting succesfully

            convertSlotsToInteger();
            bool checkIfSlotsMatch = false;
            bool u1check = false;
            bool u2check = false;
            bool u3check = false;
            bool u4check = false;

            
            if ((slots.user1PrefSetint >= slots.fromSlotint) && ((slots.user1PrefSetint < slots.toSlotint)))
                {
                user1resulttxt.Text = "Success";
                u1check = true;
                }
            if((slots.user1PrefSetint > slots.fromSlotint) && ((slots.user1PrefSetint > slots.toSlotint)))
            {
                user1resulttxt.Text = "Chosen slots out of range, please extend your preference set";
            }
            if (slots.user1PrefSetint < slots.fromSlotint) {
                user1resulttxt.Text = "Extend your preference set, out of range"; }
            if (slots.user1PrefSetint > slots.toSlotint) {
                user1resulttxt.Text = "Change preference set to earlier slot"; }
            if(slots.user1PrefSetint == slots.toSlotint)
            {
                user1resulttxt.Text = "Success";
                u1check = true;
            }
            if (slots.user1PrefSetint == slots.user1ExclSetint)
            {
                user1resulttxt.Text = "Can't have same preference and exclustion sets";
                u1check = false;
            }

          
            if (slots.user2PrefSetint == slots.toSlotint)
            {
                user2resulttxt.Text = "Success";
                u2check = true;
            }
            if ((slots.user2PrefSetint >= slots.fromSlotint) && ((slots.user2PrefSetint < slots.toSlotint)))
            {
                user2resulttxt.Text = "Success";
                u2check = true;
            }
            if ((slots.user2PrefSetint > slots.fromSlotint) && ((slots.user2PrefSetint > slots.toSlotint)))
            {
                user2resulttxt.Text = "Chosen slots out of range, please extend your preference set";
            }
            if (slots.user2PrefSetint < slots.fromSlotint)
            {
                user2resulttxt.Text = "Extend your preference set, out of range";
            }
            if (slots.user2PrefSetint > slots.toSlotint)
            {
                user2resulttxt.Text = "Change preference set to earlier slot";
            }
            if (slots.user2PrefSetint == slots.user2ExclSetint)
            {
                user2resulttxt.Text = "Can't have same preference and exclustion sets";
                u2check = false;
            }

            
            if (slots.user3PrefSetint == slots.toSlotint)
            {
                user3resulttxt.Text = "Success";
                u3check = true;
            }
            if ((slots.user3PrefSetint >= slots.fromSlotint) && ((slots.user3PrefSetint < slots.toSlotint)))
            {
                user3resulttxt.Text = "Success";
                u3check = true;
            }
            if ((slots.user3PrefSetint > slots.fromSlotint) && ((slots.user3PrefSetint > slots.toSlotint)))
            {
                user3resulttxt.Text = "Chosen slots out of range, please extend your preference set";
            }
            if (slots.user3PrefSetint < slots.fromSlotint)
            {
                user3resulttxt.Text = "Extend your preference set, out of range";
            }
            if (slots.user3PrefSetint > slots.toSlotint)
            {
                user3resulttxt.Text = "Change preference set to earlier slot";
            }
            if (slots.user3PrefSetint == slots.user3ExclSetint)
            {
                user3resulttxt.Text = "Can't have same preference and exclustion sets";
                u3check = false;
            }


            
            if (slots.user4PrefSetint == slots.toSlotint)
            {
                user4resulttxt.Text = "Success";
                u4check = true;
            }
            if ((slots.user4PrefSetint >= slots.fromSlotint) && ((slots.user4PrefSetint < slots.toSlotint)))
            {
                user4resulttxt.Text = "Success";
                u4check = true;
            }
            if ((slots.user4PrefSetint > slots.fromSlotint) && ((slots.user4PrefSetint > slots.toSlotint)))
            {
                user4resulttxt.Text = "Chosen slots out of range, please extend your preference set";
            }
            if (slots.user4PrefSetint < slots.fromSlotint)
            {
                user4resulttxt.Text = "Extend your preference set, out of range";
            }
            if (slots.user4PrefSetint > slots.toSlotint)
            {
                user4resulttxt.Text = "Change preference set to earlier slot";
            }
            if (slots.user4PrefSetint == slots.user4ExclSetint)
            {
                user4resulttxt.Text = "Can't have same preference and exclustion sets";
                u4check = false;
            }

            if (u1check == true)
                if (u2check == true)
                    if (u3check == true)
                        if (u4check == true)
                            checkIfSlotsMatch = true;

            return checkIfSlotsMatch;
        }

        private int returnIdealMeetingDate()
        {
            //check that there is at least one user in the meeting
            //compute the meeting date for the user(s)

            if (checkIfSlotsMatch() == true)
            {
                if (checkUsersInMeeting() == true)
                {
                    if (user1InMeeting == true)
                    {
                        if(user2InMeeting == false)
                        {
                            if(user3InMeeting == false)
                            {
                                if(user4InMeeting == false)
                                {
                                    statustxtbox.Text = "Scheduled";
                                    errorstxtbox.Text = "";
                                    return slots.user1PrefSetint;
                                }
                                else
                                {
                                    if(slots.user1PrefSetint != slots.user4ExclSetint)
                                    {
                                        if(slots.user4ExclSetint != slots.user1PrefSetint)
                                        {
                                            statustxtbox.Text = "Scheduled";
                                            errorstxtbox.Text = "";
                                            return slots.user1PrefSetint;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (slots.user1PrefSetint != slots.user3ExclSetint)
                                {
                                    if (slots.user3ExclSetint != slots.user1PrefSetint)
                                    {
                                        statustxtbox.Text = "Scheduled";
                                        errorstxtbox.Text = "";
                                        return slots.user1PrefSetint;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (slots.user1PrefSetint != slots.user2ExclSetint)
                            {
                                if (slots.user2ExclSetint != slots.user1PrefSetint)
                                {
                                    statustxtbox.Text = "Scheduled";
                                    errorstxtbox.Text = "";
                                    return slots.user1PrefSetint;
                                }
                            }
                        }
                    }
                    if (user2InMeeting == true)
                    {
                        if (user1InMeeting == false)
                        {
                            if (user3InMeeting == false)
                            {
                                if (user4InMeeting == false)
                                {
                                    statustxtbox.Text = "Scheduled";
                                    errorstxtbox.Text = "";
                                    return slots.user3PrefSetint;
                                }
                                else
                                {
                                    if (slots.user2PrefSetint != slots.user4ExclSetint)
                                    {
                                        if (slots.user4ExclSetint != slots.user2PrefSetint)
                                        {
                                            statustxtbox.Text = "Scheduled";
                                            errorstxtbox.Text = "";
                                            return slots.user2PrefSetint;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (slots.user2PrefSetint != slots.user3ExclSetint)
                                {
                                    if (slots.user3ExclSetint != slots.user2PrefSetint)
                                    {
                                        statustxtbox.Text = "Scheduled";
                                        errorstxtbox.Text = "";
                                        return slots.user2PrefSetint;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (slots.user2PrefSetint != slots.user1ExclSetint)
                            {
                                if (slots.user1ExclSetint != slots.user2PrefSetint)
                                {
                                    statustxtbox.Text = "Scheduled";
                                    errorstxtbox.Text = "";
                                    return slots.user2PrefSetint;
                                }
                            }
                        }
                    }
                    if (user3InMeeting == true)
                    {
                        if (user1InMeeting == false)
                        {
                            if (user2InMeeting == false)
                            {
                                if (user4InMeeting == false)
                                {
                                    statustxtbox.Text = "Scheduled";
                                    errorstxtbox.Text = "";
                                    return slots.user3PrefSetint;
                                }
                                else
                                {
                                    if (slots.user3PrefSetint != slots.user4ExclSetint)
                                    {
                                        if (slots.user4ExclSetint != slots.user3PrefSetint)
                                        {
                                            statustxtbox.Text = "Scheduled";
                                            errorstxtbox.Text = "";
                                            return slots.user3PrefSetint;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (slots.user3PrefSetint != slots.user2ExclSetint)
                                {
                                    if (slots.user2ExclSetint != slots.user3PrefSetint)
                                    {
                                        statustxtbox.Text = "Scheduled";
                                        errorstxtbox.Text = "";
                                        return slots.user3PrefSetint;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (slots.user3PrefSetint != slots.user1ExclSetint)
                            {
                                if (slots.user1ExclSetint != slots.user3PrefSetint)
                                {
                                    statustxtbox.Text = "Scheduled";
                                    errorstxtbox.Text = "";
                                    return slots.user3PrefSetint;
                                }
                            }
                        }
                    }
                    if (user4InMeeting == true)
                    {
                        if (user1InMeeting == false)
                        {
                            if (user2InMeeting == false)
                            {
                                if (user3InMeeting == false)
                                {
                                    statustxtbox.Text = "Scheduled";
                                    errorstxtbox.Text = "";
                                    return slots.user4PrefSetint;
                                }
                                else
                                {
                                    if (slots.user4PrefSetint != slots.user3ExclSetint)
                                    {
                                        if (slots.user3ExclSetint != slots.user4PrefSetint)
                                        {
                                            statustxtbox.Text = "Scheduled";
                                            errorstxtbox.Text = "";
                                            return slots.user4PrefSetint;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (slots.user4PrefSetint != slots.user2ExclSetint)
                                {
                                    if (slots.user2ExclSetint != slots.user4PrefSetint)
                                    {
                                        statustxtbox.Text = "Scheduled";
                                        errorstxtbox.Text = "";
                                        return slots.user4PrefSetint;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (slots.user4PrefSetint != slots.user1ExclSetint)
                            {
                                if (slots.user1ExclSetint != slots.user4PrefSetint)
                                {
                                    statustxtbox.Text = "Scheduled";
                                    errorstxtbox.Text = "";
                                    return slots.user4PrefSetint;
                                }
                            }
                        }
                    }
                }
            }


            return 0;
        }

        private void setDetails()
        {
            //set all the meeting information here
            
            int meetingDate;
            isDataFilledIn();
            checkIfSlotsMatch();
            meetingDate = returnIdealMeetingDate();
            specialEqtxtbox.Text = specEq;
            meetingroomtxt.Text = meetingRoom;
            checkStatus();
            if (meetingDate != 0)
            {
                meetingdatetxtbox.Text = "Slot " + meetingDate.ToString();
            }
            
            


        }

        private void schedulemeetingbtn_Click(object sender, EventArgs e)
        {
            //if there is at least 1 user in the meeting, schedule it
            //otherwise show an error message
            if (checkUsersInMeeting() == true)
                setDetails();
            else
                MessageBox.Show("Can't create meeting with no users");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if delete user 1 button is clicked, check that the user is not important to the meeting
            // if user is important, show an error message, otherwise delete the user
            if(u1important.Checked == true)
            {
                
                MessageBox.Show("Can't delete an important user!");
            }
            else
            {
                u1important.Visible = false;
                user1lbl.Visible = false;
                user1preflbl.Visible = false;
                user1txt.Visible = false;
                exclusionsetlbl.Visible = false;
                user1exclusionsetbox.Visible = false;
                user1resultlbl.Visible = false;
                user1resulttxt.Visible = false;
                u1deletebttn.Visible = false;
            }
        }

        private void u2deletebttn_Click(object sender, EventArgs e)
        {
            //if delete user 2 button is clicked, check that the user is not important to the meeting
            // if user is important, show an error message, otherwise delete the user
            if (u2important.Checked == true)
            {

                MessageBox.Show("Can't delete an important user!");
            }
            else
            {
                u2important.Visible = false;
                user2lbl.Visible = false;
                user2preflbl.Visible = false;
                user2txt.Visible = false;
                exclusionsetlbluser2.Visible = false;
                user2exclusionsetbox.Visible = false;
                user2resultlbl.Visible = false;
                user2resulttxt.Visible = false;
                u2deletebttn.Visible = false;
            }
        }

        private void u3deletebttn_Click(object sender, EventArgs e)
        {
            //if delete user 3 button is clicked, check that the user is not important to the meeting
            // if user is important, show an error message, otherwise delete the user
            if (u3important.Checked == true)
            {

                MessageBox.Show("Can't delete an important user!");
            }
            else
            {
                u3important.Visible = false;
                user3lbl.Visible = false;
                user3preflbl.Visible = false;
                user3txt.Visible = false;
                exclusionsetlbluser3.Visible = false;
                user3exclusionsetbox.Visible = false;
                user3resultlbl.Visible = false;
                user3resulttxt.Visible = false;
                u3deletebttn.Visible = false;
            }
        }

        private void u4deletebttn_Click(object sender, EventArgs e)
        {
            //if delete user 4 button is clicked, check that the user is not important to the meeting
            // if user is important, show an error message, otherwise delete the user
            if (u4important.Checked == true)
            {

                MessageBox.Show("Can't delete an important user!");
            }
            else
            {
                u4important.Visible = false;
                user4lbl.Visible = false;
                user4preflbl.Visible = false;
                user4txt.Visible = false;
                exclusionsetlbluser4.Visible = false;
                user4exclusionsetbox.Visible = false;
                user4resultlbl.Visible = false;
                user4resulttxt.Visible = false;
                u4deletebttn.Visible = false;
            }
        }

        private bool checkUsersInMeeting()
        {
            //compute how many users there are in the meeting
            bool usersInMeeting = false;

            if(user1lbl.Visible == true)
            {
                user1InMeeting = true;
                if (user2lbl.Visible == true)
                {
                    user2InMeeting = true;
                    if (user3lbl.Visible == true)
                    {
                        user3InMeeting = true;
                        if (user4lbl.Visible == true)
                        {
                            user4InMeeting = true;
                            usersInMeeting = true;
                        }
                        else usersInMeeting = true;
                    }
                    else
                        usersInMeeting = true;
                }
                else
                    usersInMeeting = true;
            }
            if (user2lbl.Visible == true)
            {
                user2InMeeting = true;
                if (user1lbl.Visible == true)
                {
                    user1InMeeting = true;
                    if (user3lbl.Visible == true)
                    {
                        user3InMeeting = true;
                        if (user4lbl.Visible == true)
                        {
                            user4InMeeting = true;
                            usersInMeeting = true;
                        }
                        else usersInMeeting = true;
                    }
                    else
                        usersInMeeting = true;
                }
                else
                    usersInMeeting = true;
            }
            if (user3lbl.Visible == true)
            {
                user3InMeeting = true;
                if (user2lbl.Visible == true)
                {
                    user2InMeeting = true;
                    if (user1lbl.Visible == true)
                    {
                        user1InMeeting = true;
                        if (user4lbl.Visible == true)
                        {
                            user4InMeeting = true;
                            usersInMeeting = true;
                        }
                        else usersInMeeting = true;
                    }
                    else
                        usersInMeeting = true;
                }
                else
                    usersInMeeting = true;
            }
            if (user4lbl.Visible == true)
            {
                user4InMeeting = true;
                if (user2lbl.Visible == true)
                {
                    user2InMeeting = true;
                    if (user3lbl.Visible == true)
                    {
                        user3InMeeting = true;
                        if (user1lbl.Visible == true)
                        {
                            user1InMeeting = true;
                            usersInMeeting = true;
                        }
                        else usersInMeeting = true;
                    }
                    else
                        usersInMeeting = true;
                }
                else
                    usersInMeeting = true;
            }
            return usersInMeeting;
        }
           
        private void checkStatus()
        {
            //check what the status message should be, and set it
            if(user1resulttxt.Text == "Success")
            {
                if (user2resulttxt.Text == "Success")
                {
                    if (user3resulttxt.Text == "Success")
                    {
                        if (user4resulttxt.Text == "Success")
                        {
                            statustxtbox.Text = "Scheduled";
                        }
                        else
                            statustxtbox.Text = "Not Scheduled";
                    }
                    else
                        statustxtbox.Text = "Not Scheduled";
                }
                else
                    statustxtbox.Text = "Not Scheduled";
            }
            if (user2resulttxt.Text == "Success")
            {
                if (user1resulttxt.Text == "Success")
                {
                    if (user3resulttxt.Text == "Success")
                    {
                        if (user4resulttxt.Text == "Success")
                        {
                            statustxtbox.Text = "Scheduled";
                        }
                        else
                            statustxtbox.Text = "Not Scheduled";
                    }
                    else
                        statustxtbox.Text = "Not Scheduled";
                }
                else
                    statustxtbox.Text = "Not Scheduled";
            }
            if (user3resulttxt.Text == "Success")
            {
                if (user2resulttxt.Text == "Success")
                {
                    if (user1resulttxt.Text == "Success")
                    {
                        if (user4resulttxt.Text == "Success")
                        {
                            statustxtbox.Text = "Scheduled";
                        }
                        else
                            statustxtbox.Text = "Not Scheduled";
                    }
                    else
                        statustxtbox.Text = "Not Scheduled";
                }
                else
                    statustxtbox.Text = "Not Scheduled";
            }
            if (user4resulttxt.Text == "Success")
            {
                if (user2resulttxt.Text == "Success")
                {
                    if (user3resulttxt.Text == "Success")
                    {
                        if (user1resulttxt.Text == "Success")
                        {
                            statustxtbox.Text = "Scheduled";
                        }
                        else
                            statustxtbox.Text = "Not Scheduled";
                    }
                    else
                        statustxtbox.Text = "Not Scheduled";
                }
                else
                    statustxtbox.Text = "Not Scheduled";
            }
        }

        }
    }

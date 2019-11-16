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
     private string user1PrefSet;
     private string user1ExclSet;
     private string user2PrefSet;
     private string user2ExclSet;
     private string user3PrefSet;
     private string user3ExclSet;
     private string user4PrefSet;
     private string user4ExclSet;
     private string fromSlot;
     private string toSlot;
     private string specEq;

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
        }

        Slots slots = new Slots();
        public mainMenu()
        {
            InitializeComponent();
        }

        private void MeetingApp_Load(object sender, EventArgs e)
        {
            welcomelbl.Text = "Welcome " + loginScreen.user1.getusername();
            iniatortxt.Text = loginScreen.user1.getusername();

            user1lbl.Text = "Joe";
            user2lbl.Text = "Mehmet";
            user3lbl.Text = "Luqman";
            user4lbl.Text = "Pit";

            string[] slots = { "Slot 1", "Slot 2", "Slot 3", "Slot 4", "Slot 5" };
            string[] equipment = { "Equipment 1", "Equipment 2", "Equipment 3", "Equipment 4", };
            
            fromComboBox.DataSource = slots.ToList();
            toComboBox.DataSource = slots.ToList();
            specialuqcombobox.DataSource = equipment.ToList();

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
        {
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

            if (u1check == true)
                if (u2check == true)
                    if (u3check == true)
                        if (u4check == true)
                            checkIfSlotsMatch = true;

            return checkIfSlotsMatch;
        }

        private int returnIdealMeetingDate()
        {

            if (checkIfSlotsMatch() == true)
            {
                if (slots.user1PrefSetint != slots.user2ExclSetint)
                {
                    if (slots.user1PrefSetint != slots.user3ExclSetint)
                        if (slots.user1PrefSetint != slots.user4PrefSetint)
                        {
                            statustxtbox.Text = "Scheduled";
                            errorstxtbox.Text = "";
                            return slots.user1PrefSetint;
                        }
                }
                if (slots.user2PrefSetint != slots.user1ExclSetint)
                {
                    if (slots.user2PrefSetint != slots.user3ExclSetint)
                        if (slots.user2PrefSetint != slots.user4ExclSetint)
                        {
                            statustxtbox.Text = "Scheduled";
                            errorstxtbox.Text = "";
                            return slots.user2PrefSetint;
                        }
                }
                if (slots.user3PrefSetint != slots.user1ExclSetint)
                {
                    if (slots.user3PrefSetint != slots.user2ExclSetint)
                        if (slots.user3PrefSetint != slots.user4ExclSetint)
                        {
                            statustxtbox.Text = "Scheduled";
                            errorstxtbox.Text = "";
                            return slots.user3PrefSetint;
                        }

                }
                if (slots.user4PrefSetint != slots.user1ExclSetint)
                {
                    if (slots.user4PrefSetint != slots.user2ExclSetint)
                        if (slots.user4PrefSetint != slots.user3ExclSetint)
                        {
                            statustxtbox.Text = "Scheduled";
                            errorstxtbox.Text = "";
                            return slots.user4PrefSetint;
                        }
                    
                }
                
            }

            return 0;
        }

        private void setDetails()
        {
            int meetingDate;
            isDataFilledIn();
            checkIfSlotsMatch();
            meetingDate = returnIdealMeetingDate();
            meetingdatetxtbox.Text = meetingDate.ToString();
            specialEqtxtbox.Text = specEq;
            
            


        }

        private void schedulemeetingbtn_Click(object sender, EventArgs e)
        {

            setDetails();


        }
    }
}

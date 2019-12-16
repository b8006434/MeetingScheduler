# MeetingScheduler
The database used for the project is a local database, therefore when moving the project to another local machine, the code for the database attachment needs to change.
 
HOW TO CHANGE IT:

Extract the meetingApp.zip file.
Open the meetingApp folder, and subfolder with the same name.
Open the database folder.
Copy the path address url found in windows explorer.

Open the "User.cs" class.
Open the "validateDetails(string usernameSave, string passwordSave)" function.
Amend the following line, where you paste the copied path in the "PATH GOES HERE" below: 

SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=PATH GOES HERE\database1.mdf;Integrated Security=True;Connect Timeout=30");

Repeat the steps above for the "registerDetails(string usernameSave, string passwordSave, string emailSave, string nameSave)" function.

Open the "mainMenu.cs" class.
Repeat the steps above for the "saveMeetingInDtabase(int meetingDate1)" function.

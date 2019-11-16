namespace MeetingApp
{
    partial class loginScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userNametxt = new System.Windows.Forms.TextBox();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.userNamelbl = new System.Windows.Forms.Label();
            this.passwordlbl = new System.Windows.Forms.Label();
            this.loginbtn = new System.Windows.Forms.Button();
            this.registerbtn = new System.Windows.Forms.Button();
            this.namelbl = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.emaillbl = new System.Windows.Forms.Label();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userNametxt
            // 
            this.userNametxt.Location = new System.Drawing.Point(426, 167);
            this.userNametxt.Name = "userNametxt";
            this.userNametxt.Size = new System.Drawing.Size(100, 20);
            this.userNametxt.TabIndex = 0;
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(426, 193);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.PasswordChar = '*';
            this.passwordtxt.Size = new System.Drawing.Size(100, 20);
            this.passwordtxt.TabIndex = 1;
            // 
            // userNamelbl
            // 
            this.userNamelbl.AutoSize = true;
            this.userNamelbl.Location = new System.Drawing.Point(285, 167);
            this.userNamelbl.Name = "userNamelbl";
            this.userNamelbl.Size = new System.Drawing.Size(59, 13);
            this.userNamelbl.TabIndex = 2;
            this.userNamelbl.Text = "Username*";
            // 
            // passwordlbl
            // 
            this.passwordlbl.AutoSize = true;
            this.passwordlbl.Location = new System.Drawing.Point(285, 196);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(57, 13);
            this.passwordlbl.TabIndex = 3;
            this.passwordlbl.Text = "Password*";
            // 
            // loginbtn
            // 
            this.loginbtn.Location = new System.Drawing.Point(353, 307);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(75, 23);
            this.loginbtn.TabIndex = 4;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // registerbtn
            // 
            this.registerbtn.Location = new System.Drawing.Point(263, 307);
            this.registerbtn.Name = "registerbtn";
            this.registerbtn.Size = new System.Drawing.Size(75, 23);
            this.registerbtn.TabIndex = 5;
            this.registerbtn.Text = "Register";
            this.registerbtn.UseVisualStyleBackColor = true;
            this.registerbtn.Click += new System.EventHandler(this.registerbtn_Click);
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.Location = new System.Drawing.Point(285, 112);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(35, 13);
            this.namelbl.TabIndex = 6;
            this.namelbl.Text = "Name";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(426, 105);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(100, 20);
            this.nametxt.TabIndex = 7;
            // 
            // emaillbl
            // 
            this.emaillbl.AutoSize = true;
            this.emaillbl.Location = new System.Drawing.Point(285, 142);
            this.emaillbl.Name = "emaillbl";
            this.emaillbl.Size = new System.Drawing.Size(77, 13);
            this.emaillbl.TabIndex = 8;
            this.emaillbl.Text = "Email Address*";
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(426, 139);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(100, 20);
            this.emailtxt.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fields marked with * are required.";
            // 
            // loginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.emailtxt);
            this.Controls.Add(this.emaillbl);
            this.Controls.Add(this.nametxt);
            this.Controls.Add(this.namelbl);
            this.Controls.Add(this.registerbtn);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.passwordlbl);
            this.Controls.Add(this.userNamelbl);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.userNametxt);
            this.Name = "loginScreen";
            this.Text = "loginScreen";
            this.Load += new System.EventHandler(this.loginScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNametxt;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Label userNamelbl;
        private System.Windows.Forms.Label passwordlbl;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.Button registerbtn;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label emaillbl;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.Label label1;
    }
}

namespace Having_fun_project
{
    partial class user_login
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
            this.loginBtn = new System.Windows.Forms.Button();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userSignup = new System.Windows.Forms.Button();
            this.managerSignup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(41, 182);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(361, 57);
            this.loginBtn.TabIndex = 9;
            this.loginBtn.Text = "로그인";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(146, 125);
            this.txtPw.Name = "txtPw";
            this.txtPw.Size = new System.Drawing.Size(256, 25);
            this.txtPw.TabIndex = 8;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(146, 61);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(256, 25);
            this.txtid.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // userSignup
            // 
            this.userSignup.Font = new System.Drawing.Font("굴림", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userSignup.Location = new System.Drawing.Point(96, 277);
            this.userSignup.Name = "userSignup";
            this.userSignup.Size = new System.Drawing.Size(124, 57);
            this.userSignup.TabIndex = 10;
            this.userSignup.Text = "사용자 회원가입";
            this.userSignup.UseVisualStyleBackColor = true;
            this.userSignup.Click += new System.EventHandler(this.userSignup_Click);
            // 
            // managerSignup
            // 
            this.managerSignup.Location = new System.Drawing.Point(226, 276);
            this.managerSignup.Name = "managerSignup";
            this.managerSignup.Size = new System.Drawing.Size(125, 57);
            this.managerSignup.TabIndex = 11;
            this.managerSignup.Text = "소유주 회원가입";
            this.managerSignup.UseVisualStyleBackColor = true;
            this.managerSignup.Click += new System.EventHandler(this.managerSignup_Click);
            // 
            // user_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 352);
            this.Controls.Add(this.managerSignup);
            this.Controls.Add(this.userSignup);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "user_login";
            this.Text = "로그인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button userSignup;
        private System.Windows.Forms.Button managerSignup;
    }
}
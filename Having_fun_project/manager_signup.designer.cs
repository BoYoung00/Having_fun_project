
namespace Having_fun_project
{
    partial class manager_signup
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
            this.signUP = new System.Windows.Forms.Button();
            this.txtPw2 = new System.Windows.Forms.TextBox();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signUP
            // 
            this.signUP.Location = new System.Drawing.Point(74, 354);
            this.signUP.Name = "signUP";
            this.signUP.Size = new System.Drawing.Size(375, 53);
            this.signUP.TabIndex = 32;
            this.signUP.Text = "회원가입";
            this.signUP.UseVisualStyleBackColor = true;
            this.signUP.Click += new System.EventHandler(this.signUP_Click);
            // 
            // txtPw2
            // 
            this.txtPw2.Location = new System.Drawing.Point(203, 290);
            this.txtPw2.Name = "txtPw2";
            this.txtPw2.Size = new System.Drawing.Size(246, 25);
            this.txtPw2.TabIndex = 31;
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(203, 235);
            this.txtPw.Name = "txtPw";
            this.txtPw.Size = new System.Drawing.Size(246, 25);
            this.txtPw.TabIndex = 30;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(203, 171);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(246, 25);
            this.txtid.TabIndex = 29;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(203, 110);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(246, 25);
            this.txtPhone.TabIndex = 28;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(203, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 25);
            this.txtName.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "전화번호";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "시설 이름";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "PassWord";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "ID";
            // 
            // manager_signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.Controls.Add(this.signUP);
            this.Controls.Add(this.txtPw2);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "manager_signup";
            this.Text = "소유주 회원가입";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signUP;
        private System.Windows.Forms.TextBox txtPw2;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
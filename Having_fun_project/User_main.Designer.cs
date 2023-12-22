namespace Having_fun_project
{
    partial class User_main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.숙소예약하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.예약조회및별점ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.숙소예약하기ToolStripMenuItem,
            this.예약조회및별점ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1031, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 숙소예약하기ToolStripMenuItem
            // 
            this.숙소예약하기ToolStripMenuItem.Name = "숙소예약하기ToolStripMenuItem";
            this.숙소예약하기ToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.숙소예약하기ToolStripMenuItem.Text = "숙박예약하기";
            this.숙소예약하기ToolStripMenuItem.Click += new System.EventHandler(this.숙소예약하기ToolStripMenuItem_Click);
            // 
            // 예약조회및별점ToolStripMenuItem
            // 
            this.예약조회및별점ToolStripMenuItem.Name = "예약조회및별점ToolStripMenuItem";
            this.예약조회및별점ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.예약조회및별점ToolStripMenuItem.Text = "예약조회 및 별점주기";
            this.예약조회및별점ToolStripMenuItem.Click += new System.EventHandler(this.예약조회및별점ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // User_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 645);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "User_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "숙박예약";
            this.Load += new System.EventHandler(this.User_main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 숙소예약하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 예약조회및별점ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
    }
}
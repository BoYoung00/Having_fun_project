
namespace Having_fun_project
{
    partial class manager_checkin
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
            this.RoomUpdate = new System.Windows.Forms.Button();
            this.RoomPlus = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtRoomNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RoomDelete = new System.Windows.Forms.Button();
            this.RoomGrida = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.유형 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RoomGrida)).BeginInit();
            this.SuspendLayout();
            // 
            // RoomUpdate
            // 
            this.RoomUpdate.Location = new System.Drawing.Point(926, 426);
            this.RoomUpdate.Name = "RoomUpdate";
            this.RoomUpdate.Size = new System.Drawing.Size(95, 39);
            this.RoomUpdate.TabIndex = 27;
            this.RoomUpdate.Text = "수정";
            this.RoomUpdate.UseVisualStyleBackColor = true;
            this.RoomUpdate.Click += new System.EventHandler(this.RoomUpdate_Click);
            // 
            // RoomPlus
            // 
            this.RoomPlus.Location = new System.Drawing.Point(806, 426);
            this.RoomPlus.Name = "RoomPlus";
            this.RoomPlus.Size = new System.Drawing.Size(105, 39);
            this.RoomPlus.TabIndex = 26;
            this.RoomPlus.Text = "추가";
            this.RoomPlus.UseVisualStyleBackColor = true;
            this.RoomPlus.Click += new System.EventHandler(this.RoomPlus_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(961, 372);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(177, 25);
            this.txtPrice.TabIndex = 25;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(961, 325);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(177, 25);
            this.txtMax.TabIndex = 24;
            // 
            // txtRoomNum
            // 
            this.txtRoomNum.Location = new System.Drawing.Point(961, 275);
            this.txtRoomNum.Name = "txtRoomNum";
            this.txtRoomNum.Size = new System.Drawing.Size(177, 25);
            this.txtRoomNum.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(816, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "수용인원";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(816, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "시설 이름 + 호수";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(858, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "객실 정보 추가/수정/삭제";
            // 
            // RoomDelete
            // 
            this.RoomDelete.Location = new System.Drawing.Point(1038, 426);
            this.RoomDelete.Name = "RoomDelete";
            this.RoomDelete.Size = new System.Drawing.Size(100, 39);
            this.RoomDelete.TabIndex = 27;
            this.RoomDelete.Text = "삭제";
            this.RoomDelete.UseVisualStyleBackColor = true;
            this.RoomDelete.Click += new System.EventHandler(this.RoomDelete_Click);
            // 
            // RoomGrida
            // 
            this.RoomGrida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomGrida.Location = new System.Drawing.Point(25, 22);
            this.RoomGrida.Name = "RoomGrida";
            this.RoomGrida.RowHeadersWidth = 51;
            this.RoomGrida.RowTemplate.Height = 27;
            this.RoomGrida.Size = new System.Drawing.Size(769, 443);
            this.RoomGrida.TabIndex = 14;
            this.RoomGrida.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomGrid_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(816, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "가격";
            // 
            // txtAdr
            // 
            this.txtAdr.Location = new System.Drawing.Point(961, 189);
            this.txtAdr.Multiline = true;
            this.txtAdr.Name = "txtAdr";
            this.txtAdr.Size = new System.Drawing.Size(177, 70);
            this.txtAdr.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(816, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 35;
            this.label7.Text = "주소";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "호텔",
            "모텔",
            "펜션",
            "게스트하우스"});
            this.comboBox1.Location = new System.Drawing.Point(961, 140);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 23);
            this.comboBox1.TabIndex = 37;
            // 
            // 유형
            // 
            this.유형.AutoSize = true;
            this.유형.Location = new System.Drawing.Point(816, 144);
            this.유형.Name = "유형";
            this.유형.Size = new System.Drawing.Size(37, 15);
            this.유형.TabIndex = 38;
            this.유형.Text = "유형";
            // 
            // manager_checkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 489);
            this.Controls.Add(this.유형);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtAdr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RoomDelete);
            this.Controls.Add(this.RoomUpdate);
            this.Controls.Add(this.RoomPlus);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtRoomNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RoomGrida);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "manager_checkin";
            this.Text = "객실 정보";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.manager_checkin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RoomGrida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RoomUpdate;
        private System.Windows.Forms.Button RoomPlus;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtRoomNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RoomDelete;
        private System.Windows.Forms.DataGridView RoomGrida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAdr;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label 유형;
    }
}
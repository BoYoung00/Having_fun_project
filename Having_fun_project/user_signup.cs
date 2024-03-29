﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Having_fun_project
{
    public partial class user_signup : Form
    {
        public user_signup()
        {
            InitializeComponent();
        }

        private void signUP_Click(object sender, EventArgs e)
        {
            if(INSERTRow() > 0)
            {
                this.Close();
            }
        }

        private OracleConnection odpConn = new OracleConnection();

        private int INSERTRow()
        {
            string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = " + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER =" + "DEDICATED)(SERVICE_NAME = xe)) ); ";
            using (OracleConnection odpConn = new OracleConnection(connectionString))
            {
                odpConn.Open();
                String inid = txtid.Text.Trim();
                String inpw = txtPw.Text.Trim();
                String inName = txtName.Text.Trim();
                String inPhone = txtPhone.Text.Trim();
                string strqry = "INSERT INTO funUser (MemberID, UserName, UserPhoneNumber, UserPassword) VALUES ('" + inid + "', '" + inName + "', '" + inPhone + "', '" + inpw + "')";
                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

                if (txtPw.Text.Trim() == txtPw2.Text.Trim())
                {
                    int affectedRows = OraCmd.ExecuteNonQuery();
                    MessageBox.Show("회원가입이 성공적으로 완료되었습니다.");
                    return affectedRows;
                }
                else
                {
                    MessageBox.Show("비밀번호를 다시 확인해주세요.");
                    return 0;
                }
            }
        }

        private void user_signup_Load(object sender, EventArgs e)
        {

        }
    }
}

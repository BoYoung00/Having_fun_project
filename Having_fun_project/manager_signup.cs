using System;
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
    public partial class manager_signup : Form
    {
  
        public manager_signup()
        {
            InitializeComponent();
        }

        private void signUP_Click(object sender, EventArgs e)
        {
            INSERTRow();
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
                string strqry = "INSERT INTO Owner VALUES ('" + inid + "', '" + inName + "', '" + inpw + "', '" + inPhone + "')";
                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

                if (txtPw.Text.Trim() == txtPw2.Text.Trim())
                {
                    int affectedRows = OraCmd.ExecuteNonQuery();
                    MessageBox.Show("회원가입이 성공적으로 완료되었습니다.");
                    this.Close();
                    return affectedRows;
                    
                }
                else
                {
                    MessageBox.Show("비밀번호를 다시 확인해주세요.");
                    return 0;
                }
            }
        }

    }
}

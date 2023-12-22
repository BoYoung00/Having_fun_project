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
    public partial class user_login : Form
    {

        string loginID;
        string loginPw;

        public string GetLoginID { get { return loginID; }}
        public string GetLoginPw { get { return loginPw; }}

        public user_login()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtid.Text;
            string password = txtPw.Text;

            int countUser = User(id, password);
            int countOwner = Owner(id, password);


            if (countUser > 0)
            {
                loginID = id;
                loginPw = password;

                User_main manager_ = new User_main(this);
                manager_.ShowDialog();

            }
            else if (countOwner > 0)
            {
                loginID = id;
                loginPw = password;

                Manager_main manager_ = new Manager_main(this);
                manager_.ShowDialog();
            }
            else
            {
                MessageBox.Show("잘못된 사용자 이름 또는 비밀번호.");
            }
        }

        private void userSignup_Click(object sender, EventArgs e)
        {
            user_signup userSignupForm = new user_signup();
            userSignupForm.ShowDialog();
        }

        private void managerSignup_Click(object sender, EventArgs e)
        {
            manager_signup managerSignupForm = new manager_signup();
            managerSignupForm.ShowDialog();
        }

        private int User(string username, string password)
        {
            string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = " + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER =" + "DEDICATED)(SERVICE_NAME = xe)) ); ";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                // SQL Injection을 방지하기 위해 매개변수화된 쿼리를 사용하는 것이 좋습니다.
                string query1 = $"SELECT COUNT(*) FROM funUser WHERE MEMBERID = '{username}' AND UserPassword = '{password}'";

                using (OracleCommand command = new OracleCommand(query1, connection))
                {

                    connection.Open();
                    int userCount = Convert.ToInt32(command.ExecuteScalar()); // 사용자 수를 가져옵니다.

                    return userCount; // 사용자가 존재하면 true 반환
                }

               
            }
        }

        private int Owner(string username, string password)
        {
            string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = " + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER =" + "DEDICATED)(SERVICE_NAME = xe)) ); ";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string query2 = $"SELECT COUNT(*) FROM Owner WHERE OWNERID = '{username}' AND OwnerPassword = '{password}'";

                using (OracleCommand command = new OracleCommand(query2, connection))
                {
                    connection.Open();
                    int userCount = Convert.ToInt32(command.ExecuteScalar()); // 사용자 수를 가져옵니다.

                    return userCount; // 사용자가 존재하면 true 반환
                }


            }
        }



    }
}

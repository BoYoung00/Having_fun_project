using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Having_fun_project
{
    public partial class User_main : Form
    {
        // 로그인 상태
        string loginID;
        string loginPw;

        public string GetLoginID { get { return loginID; } }
        public string GetLoginPw { get { return loginPw; } }

        public User_main(user_login login)
        {
            InitializeComponent();
            loginID = login.GetLoginID;
            loginPw = login.GetLoginPw;
        }
        User_reserve userReserve;
        User_inquiry userInquiry;
        private void User_main_Load(object sender, EventArgs e)
        {
            userReserve = new User_reserve(this);
            userReserve.MdiParent = this;
            userReserve.Show();
        }

        private void 숙소예약하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(userReserve == null || userReserve.IsDisposed)
            {
                userReserve = new User_reserve(this);
                userReserve.MdiParent = this;
                userReserve.Show();
            }
        }

        private void 예약조회및별점ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(userInquiry == null || userInquiry.IsDisposed)
            {
                userInquiry = new User_inquiry(this);
                userInquiry.MdiParent = this;
                userInquiry.Show();
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class Manager_main : Form
    {
        manager_checkin _checkin;
        Manager_inquiry _inquiry;

        // 로그인 상태
        string loginID;
        string loginPw;

        public string GetLoginID { get { return loginID; } }
        public string GetLoginPw { get { return loginPw; } }

        public Manager_main(user_login login)
        {
            InitializeComponent();

            loginID = login.GetLoginID;
            loginPw = login.GetLoginPw;
        }
        private void 객실추가하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _checkin = new manager_checkin(this);
            _checkin.MdiParent = this;
            _checkin.Show();
        }

        private void 예약현황조회ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _inquiry = new Manager_inquiry(this);
            _inquiry.MdiParent = this;
            _inquiry.Show();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manager_main_Load(object sender, EventArgs e)
        { 
            _checkin = new manager_checkin(this);
            _checkin.MdiParent = this;
            _checkin.Show();
        }
    }
}

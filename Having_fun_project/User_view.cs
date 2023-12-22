using ADOForm;
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
    public partial class User_view : Form
    {
        DBClass dbc = new DBClass(); //*****DBClass 객체 생성
        public User_view()
        {
            InitializeComponent();
            dbc.DB_Open_funUser();//*
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbc.DS.Clear();
                dbc.DBAdapter.Fill(dbc.DS, "funUser");
                userGridView.DataSource = dbc.DS.Tables["funUser"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void User_view_Load(object sender, EventArgs e)
        {

        }
    }
}

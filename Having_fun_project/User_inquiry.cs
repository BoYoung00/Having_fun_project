using ADOForm;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace Having_fun_project
{
    public partial class User_inquiry : Form
    {
        DBClass dbc = new DBClass(); //DBClass 객체 생성
        string loginUser; // 로그인 되어 있는 유저ID
        private int intID; // 선택된 ReservationID (예약내역 번호)
        private long paymentID; // 선택된 PaymentID (결제번호)

        public int GetIntID { get { return intID; } }
        public long GetPaymentID { get { return paymentID; } }

        public User_inquiry(User_main login)
        {
            InitializeComponent();
            dbc.DB_Open_Reservation();
            loginUser = login.GetLoginID;
        }

        // 예약 조회하기
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                OracleConnection connection = new OracleConnection(connectionString);
                connection.Open();
                string sqlQuery = "SELECT R.ReservationID, R.RoomID, P.PaymentID, P.Amount, P.PaymentDate, P.PaymentMethod, R.CheckInDate, R.CheckOutDate " +
                                    "FROM Reservation R " +
                                    "INNER JOIN Payment P ON R.PaymentID = P.PaymentID " +
                                    "WHERE R.GuestID = '" + loginUser + "'"; // 로그인 한 유저의 예약 조회하기
                OracleDataAdapter adapter = new OracleDataAdapter(sqlQuery, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                // DataGridView 열 이름 변경 및 정보 보이기
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dataset.Tables[0];
                dataGridView1.Columns[0].HeaderText = "예약번호";
                dataGridView1.Columns[1].HeaderText = "객실이름";
                dataGridView1.Columns[2].HeaderText = "결제번호";
                dataGridView1.Columns[3].HeaderText = "가격";
                dataGridView1.Columns[4].HeaderText = "결제일자";
                dataGridView1.Columns[5].HeaderText = "결제방법";
                dataGridView1.Columns[6].HeaderText = "체크인";
                dataGridView1.Columns[7].HeaderText = "체크아웃";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 선택된 행의 예약번호 가져오기
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0) // 선택된 행이 없는 경우, 셀을 클릭하면서 행을 선택하는 경우
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows[selectedRowIndex].Selected = true;

                intID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ReservationID"].Value); // 예약번호
                paymentID = Convert.ToInt64(dataGridView1.Rows[selectedRowIndex].Cells["PaymentID"].Value); // 결제번호
            }
            else if(e.RowIndex >= 0) // 선택된 셀이 행 인덱스를 가진 경우
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView1.Rows[e.RowIndex].Selected = true;

                intID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ReservationID"].Value); // 예약번호
                paymentID = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["PaymentID"].Value); // 결제번호
            }
        }

        // 별점주러 가기 
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            User_inquiry_evaluation evaluation = new User_inquiry_evaluation(this);
            evaluation.ShowDialog();
            evaluation.Dispose();
        }
    }
}

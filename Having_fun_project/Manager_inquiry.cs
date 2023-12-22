using ADOForm;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Having_fun_project
{
    public partial class Manager_inquiry : Form
    {
        DBClass dbc = new DBClass(); //DBClass 객체 생성
        string loginId;
        string roomID;
        public Manager_inquiry(Manager_main login)
        {
            InitializeComponent();
            dbc.DB_Open_Reservation();
            loginId = login.GetLoginID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowFilteredReservation();
        }

        // 리스트뷰에 데이터 불러오기
        private void ShowFilteredReservation()
        {
            try
            {
                string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                OracleConnection connection = new OracleConnection(connectionString);
                connection.Open();
                string sqlQuery = "SELECT R.ReservationID, R.RoomID, R.GuestID, P.PaymentID, P.Amount, P.PaymentDate, P.PaymentMethod, R.CheckInDate, R.CheckOutDate " +
                                    "FROM Reservation R " +
                                    "INNER JOIN Payment P ON R.PaymentID = P.PaymentID " +
                                    "WHERE R.RoomID LIKE '%" + roomID + "%'"; // 로그인 된 소유자의 숙박시설이름으로 검색
                OracleDataAdapter adapter = new OracleDataAdapter(sqlQuery, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                // DataGridView 열 이름 변경 및 정보 보이기
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dataset.Tables[0];
                dataGridView1.Columns[0].HeaderText = "예약번호";
                dataGridView1.Columns[1].HeaderText = "객실이름";
                dataGridView1.Columns[2].HeaderText = "예약자 이름";
                dataGridView1.Columns[3].HeaderText = "결제번호";
                dataGridView1.Columns[4].HeaderText = "가격";
                dataGridView1.Columns[5].HeaderText = "결제일자";
                dataGridView1.Columns[6].HeaderText = "결제방법";
                dataGridView1.Columns[7].HeaderText = "체크인";
                dataGridView1.Columns[8].HeaderText = "체크아웃";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetAccommodationNameByOwnerID()
        {
            string accommodationName = string.Empty;
            try
            {
                string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                OracleConnection connection = new OracleConnection(connectionString);
                connection.Open();

                string sqlQuery = $"SELECT AccommodationName FROM Owner WHERE OwnerID = '{loginId}'";
                OracleCommand command = new OracleCommand(sqlQuery, connection);

                OracleDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    accommodationName = reader["AccommodationName"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return accommodationName;
        }

        // 로드
        private void Manager_inquiry_Load(object sender, EventArgs e)
        {
            roomID = GetAccommodationNameByOwnerID();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

using ADOForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Windows.Forms;

namespace Having_fun_project
{
    public partial class User_reserve : Form
    {
        string loginUser; // 로그인 되어 있는 유저ID
        DBClass dbc = new DBClass(); //DBClass 객체 생성
        string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";

        // 선택된 숙소정보
        string AccommodationID, type, address, grade, price;

        // 선택된 날짜
        DateTime selectedStartDate;
        DateTime selectedEndDate;

        // 결제정보
        string paymentMethod;
        string uniqueNumber; // 결제 고유번호

        // 정렬 라디오 버튼
        int orderBy;
        string sql = ""; // 검색

        public User_reserve(User_main login)
        {
            InitializeComponent();
            dbc.DB_Open_Accommodation();
            loginUser = login.GetLoginID;
        }

        // 폼 로드
        private void User_reserve_Load(object sender, EventArgs e)
        {
            // 콤보박스, 라디오 버튼 초기 설정
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            radioButton1.Checked = true;
        }

        // 정렬 (선택한 라디오 버튼 정보 저장하고 리스트뷰 새로고침)
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            orderBy = 1; // 평점 높은순
            ShowFilteredAccommodation(sql);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            orderBy = 2; // 평점 높은순
            ShowFilteredAccommodation(sql);
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            orderBy = 3; // 가격 높은순
            ShowFilteredAccommodation(sql);
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            orderBy = 4; // 가격 낮은순
            ShowFilteredAccommodation(sql);
        }

        // 날짜 선택
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedStartDate = monthCalendar1.SelectionStart;
            selectedEndDate = monthCalendar1.SelectionEnd;

            // 선택한 날짜를 텍스트박스에 표시
            textBox9.Text = selectedStartDate.ToShortDateString();
            textBox8.Text = selectedEndDate.ToShortDateString();
        }

        // 검색 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            // 선택한 카테고리 내에서 검색을 위해 sql문 업데이트
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "전체") {
                sql = "AccommodationID like '%" + textBox6.Text + "%' ";

            } else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "호텔") {   
                sql = "AccommodationID LIKE '%" + textBox6.Text + "%' AND AccommodationType = '호텔'";

            } else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "모텔") {  
                sql = "AccommodationID LIKE '%" + textBox6.Text + "%' AND AccommodationType = '모텔'";

            } else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "펜션") { 
                sql = "AccommodationID LIKE '%" + textBox6.Text + "%' AND AccommodationType = '펜션'";

            } else if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "게스트하우스") {
                sql = "AccommodationID LIKE '%" + textBox6.Text + "%' AND AccommodationType = '게스트하우스'";
            }
            ShowFilteredAccommodation(sql); // 리스트뷰로 데이터 불러오기
        }

        // 리스트뷰에 데이터 불러오기
        private void ShowFilteredAccommodation(String sql)
        {
            dbc.DS.Clear();
            dbc.DBAdapter.Fill(dbc.DS, "Accommodation");
            dbc.PhoneTable = dbc.DS.Tables["Accommodation"];

            DataRow[] ResultRows = dbc.PhoneTable.Select(sql);
            var sortedRows = ResultRows.OrderBy(row => row["Grade"]).ToArray();

            switch (orderBy) // 선택된 정렬에 따라 정렬하기
            {
                case 2: sortedRows = ResultRows.OrderBy(row => row["Grade"]).ToArray(); break;
                case 1: sortedRows = ResultRows.OrderByDescending(row => row["Grade"]).ToArray(); break;
                case 4: sortedRows = ResultRows.OrderBy(row => row["Price"]).ToArray(); break;
                case 3: sortedRows = ResultRows.OrderByDescending(row => row["Price"]).ToArray(); break;
            }
            listView1.Items.Clear();
            foreach (DataRow currRow in sortedRows) // 값 가져오기
            {
                ListViewItem item = new ListViewItem();
                item.Text = currRow["AccommodationType"].ToString();
                item.SubItems.Add(currRow["AccommodationID"].ToString());
                item.SubItems.Add(currRow["Address"].ToString());
                item.SubItems.Add(currRow["MaxOccupancy"].ToString());
                item.SubItems.Add(currRow["Grade"].ToString());
                item.SubItems.Add(currRow["Price"].ToString());
                listView1.Items.Add(item);
            }
        }

        // 행 선택
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // 행 선택한 값 가져오기
                int selectRow = listView1.SelectedItems[0].Index;
                AccommodationID = listView1.Items[selectRow].SubItems[1].Text;
                type = listView1.Items[selectRow].SubItems[0].Text;
                address = listView1.Items[selectRow].SubItems[2].Text;
                grade = listView1.Items[selectRow].SubItems[4].Text;
                price = listView1.Items[selectRow].SubItems[5].Text;

                // 선택된 정보 전역변수에 저장
                AName.Text = AccommodationID;
                AType.Text = type;
                AAddress.Text = address;
                AGrade.Text = grade;
                APrice.Text = price;

                textBox7.Text = price;
                DisplayAvailableDates();
            }
        }

        // 결제방법 선택
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "카드결제")
            {
                paymentMethod = "카드결제";
            }
            else if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "가상계좌")
            {
                paymentMethod = "가상계좌";

            }
            else if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "휴대폰")
            {
                paymentMethod = "휴대폰";
            }
        }

        // 달력에 예약가능한 날짜 표시 (굵은 글씨)
        private void DisplayAvailableDates()
        {
            // 예약 가능한 날짜 목록 가져오기
            List<char> availableDates = GetAvailableDates(AccommodationID, "2023-12");

            // 날짜 표시 시작
            monthCalendar1.RemoveAllBoldedDates();
            DateTime currentDate = new DateTime(2023, 12, 1); // 12월 1일부터 시작
            for (int i = 0; i < availableDates.Count; i++)
            {
                if (availableDates[i] == '0') // 값이 0이면 글자 굵게 표시
                {
                    monthCalendar1.AddBoldedDate(currentDate);
                }
                currentDate = currentDate.AddDays(1);
            }
            monthCalendar1.UpdateBoldedDates();
        }

        // DB에서 숙소에 따른 예약 가능한 날짜를 가져오는 메서드
        private List<char> GetAvailableDates(String roomId, String roomdate)
        {
            List<char> availabilityList = new List<char>();
            try
            {
                string commandString = "SELECT Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10, " +
                               "Day11, Day12, Day13, Day14, Day15, Day16, Day17, Day18, Day19, Day20, " +
                               "Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31 " +
                               "FROM RoomAvailability WHERE RoomID = '" + roomId + "' AND RoomDate = '" + roomdate + "'";

                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();

                DBAdapter.Fill(DS);

                // 각 날짜별 값을 List에 추가
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    foreach (var item in row.ItemArray)
                        availabilityList.Add(Convert.ToChar(item));
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            return availabilityList;
        }

        // 선택된 시작일과 종료일 사이의 날짜 목록을 가져오는 메서드
        private List<DateTime> GetDateRange()
        {
            List<DateTime> dateRange = new List<DateTime>();
            for (DateTime date = selectedStartDate; date <= selectedEndDate; date = date.AddDays(1))
            {
                dateRange.Add(date);
            }
            return dateRange;
        }

        // 예약하기 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AccommodationID) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(grade) 
                || string.IsNullOrEmpty(price) || selectedStartDate == DateTime.MinValue || selectedEndDate == DateTime.MinValue)
            {
                MessageBox.Show("숙소 또는 날짜를 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 선택된 날짜의 시작일과 종료일 사이에 이미 예약된 날짜가 있는지 확인
            List<DateTime> selectedDates = GetDateRange(); // 선택된 시작일과 종료일 사이의 날짜 목록 가져오기
            List<char> availableDates = GetAvailableDates(AccommodationID, "2023-12"); // 예약 가능한 일자 가져오기

            foreach (DateTime date in selectedDates)
            {
                int day = date.Day; // 선택된 날짜의 일자
                if (availableDates[day - 1] == '1') // 날짜가 '1'로 되어 있다면 이미 예약된 날짜임
                {
                    MessageBox.Show($"날짜 {date.ToShortDateString()}는 이미 예약되어 있습니다.");
                    return;
                }
            }
            int payment = DB_insert_Payment(); // 결제 정보 추가 함수
            int reservation = DB_insert_reservation(); // 예약내역 추가 함수
            int roomAvailability = DB_update_roomAvailability(); // 예약일자 현황 업데이트
            if (reservation == 1 && payment == 1 && roomAvailability > 0)
            {
                MessageBox.Show("예약에 성공하셨습니다.");
                ResetSelectedValues(); // 선택했던 모든 데이터 초기화 함수
            }
            else
            {
                MessageBox.Show("예약에 실패하셨습니다. 다시 시도해주세요.");
            }
        }

        // 결제정보 추가
        private int DB_insert_Payment()
        {
            GenerateUniqueNumericValue(); // 결제 고유번호 생성
            try
            {
                string commandString = $"INSERT INTO Payment (PaymentID, Amount, PaymentDate, PaymentMethod) " +
                                        $"VALUES('{uniqueNumber}', {price}, SYSDATE, '{paymentMethod}')";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    OracleCommand command = new OracleCommand(commandString, connection);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            return -1;
        }

        // 예약일자 현황 업데이트 (수정)
        private int DB_update_roomAvailability()
        {
            int startDay = selectedStartDate.Day;
            int endDay = selectedEndDate.Day;
            int updateCount = 0;
            try
            {
                for (int i = startDay; i <= endDay; i++)
                {
                    string commandString = $"UPDATE RoomAvailability SET Day{i}='1' WHERE RoomID='{AccommodationID}' AND RoomDate = '2023-12'";

                    using (OracleConnection connection = new OracleConnection(connectionString))
                    {
                        OracleCommand command = new OracleCommand(commandString, connection);
                        connection.Open();
                        updateCount = updateCount + command.ExecuteNonQuery();
                    } //using
                } // for
            } // try
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            return updateCount;
        } 

        // 예약정보 insert
        private int DB_insert_reservation()
        {
            try
            {
                string commandString = "INSERT INTO Reservation (ReservationID, RoomID, GuestID, PaymentID, CheckInDate, CheckOutDate) " +
                    $"VALUES (reservation_seq.NEXTVAL, '{AccommodationID}', '{loginUser}', {uniqueNumber}, TO_DATE('{selectedStartDate.ToString("yyyy-MM-dd")}', 'YYYY-MM-DD'), TO_DATE('{selectedEndDate.ToString("yyyy-MM-dd")}', 'YYYY-MM-DD'))";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    OracleCommand command = new OracleCommand(commandString, connection);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            return -1;
        }

        // 결제 고유번호 생성
        private void GenerateUniqueNumericValue()
        {
            DateTime now = DateTime.Now;
            uniqueNumber = now.ToString("yyyyMMddHHmmss");
        }

        // 초기화 함수
        private void ResetSelectedValues()
        {
            // 선택한 숙소 정보 초기화
            AccommodationID = string.Empty;
            type = string.Empty;
            address = string.Empty;
            grade = string.Empty;
            price = string.Empty;

            // 선택한 날짜 초기화
            selectedStartDate = DateTime.MinValue;
            selectedEndDate = DateTime.MinValue;

            // 달력 초기화
            monthCalendar1.RemoveAllBoldedDates();
            monthCalendar1.UpdateBoldedDates();

            // 결제 정보 초기화
            uniqueNumber = string.Empty;

            // UI 컨트롤 값 초기화
            AName.Text = string.Empty;
            AType.Text = string.Empty;
            AAddress.Text = string.Empty;
            AGrade.Text = string.Empty;
            APrice.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;

            // 선택한 예약 데이터 해제
            listView1.SelectedItems.Clear();
        }
    }
}

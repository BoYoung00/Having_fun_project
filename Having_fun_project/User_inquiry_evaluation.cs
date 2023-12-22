using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Having_fun_project
{
    public partial class User_inquiry_evaluation : Form
    {
        int countEvaluation; // 별점 테이블 존재 여부 (1:존재)
        float score; // 선택한 점수
        string roomId; // 객실 이름
        private OracleConnection odpConn = new OracleConnection();
        User_inquiry parent;

        public User_inquiry_evaluation(User_inquiry inquiry)
        {
            InitializeComponent();
            parent = inquiry;
        }

        // 로드
        private void User_inquiry_evaluation_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true; // 라디오 버튼 기본 1점 선택
            DB_Select_Reservation(); // 예약정보 가져오기
            DB_Count_Evaluation(); // 별점 정보 가져오기
        }

        // 등록 및 수정 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            // 만약 해당 id가 있는 별점 테이블이 있다면
            if (countEvaluation > 0) // 업데이트
            {
                if (DB_Update_Evaluation() > 0)
                {
                    MessageBox.Show("별점 수정이 완료되었습니다.");
                    UpdateAccommodationGrade(); // 숙박시설 평점 업데이트 함수
                    this.Close();
                    return;
                }
            }
            else // 추가
            {
                if (DB_Insert_Evaluation() > 0)
                {
                    MessageBox.Show("별점 등록이 완료되었습니다.");
                    UpdateAccommodationGrade(); // 숙박시설 평점 업데이트 함수
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("별점주기에 실패하셨습니다. 다시 시도해주세요.");
        }

        // 예약정보 가져오기
        private void DB_Select_Reservation()
        {
            odpConn.ConnectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe)));";
            odpConn.Open();

            string sqlQuery = "SELECT R.ReservationID, R.RoomID, P.Amount " +
                              "FROM Reservation R " +
                              "INNER JOIN Payment P ON R.PaymentID = P.PaymentID " +
                              "WHERE R.ReservationID = '" + parent.GetIntID + "'";

            OracleCommand OraCmd = new OracleCommand(sqlQuery, odpConn); 
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                textBox1.Text = Convert.ToString(odr.GetValue(0));
                textBox2.Text = Convert.ToString(odr.GetValue(1));
                textBox3.Text = Convert.ToString(odr.GetValue(2));

                roomId = Convert.ToString(odr.GetValue(1)); // 객실이름 저장
            }
            odr.Close();
            odpConn.Close();
        }

        // 별점 테이블 존재 여부 count
        private void DB_Count_Evaluation()
        {
            try // 선택한 행에 이미 별점을 준 테이블이 있는지 확인
            {
                odpConn.ConnectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe)));";
                odpConn.Open();

                string sqlQuery = "SELECT COUNT(*) FROM Evaluation " +
                                  $"WHERE ReservationID = {parent.GetIntID} " + // 부모 폼에서 받아온 정보로 검색
                                  $"AND PaymentID = {parent.GetPaymentID}";

                OracleCommand OraCmd = new OracleCommand(sqlQuery, odpConn);
                countEvaluation = Convert.ToInt32(OraCmd.ExecuteScalar()); // 존재하면 1 이상 반환 후 전역변수에 저장

                // 존재한다면 가져온 점수 textBox에 작성
                if(countEvaluation > 0) { textBox4.Text = DB_Select_Evaluation(); }  // 점수 가져오기 함수
                else { textBox4.Text = "미등록";  }

                odpConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 별점 테이블 조회 및 정보 가져오기
        private string DB_Select_Evaluation()
        {
            try
            {
                string sqlQuery = "SELECT Rating FROM Evaluation " +
                                  $"WHERE ReservationID = {parent.GetIntID} " +
                                  $"AND PaymentID = {parent.GetPaymentID}";

                OracleCommand OraCmd = new OracleCommand(sqlQuery, odpConn);
                OracleDataReader odr = OraCmd.ExecuteReader();
                while (odr.Read())
                {
                    return Convert.ToString(odr.GetValue(0));
                }
                odr.Close();
                odpConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        // 별점 테이블 행 추가
        private int DB_Insert_Evaluation()
        {
            try
            {
                odpConn.ConnectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe)));";
                odpConn.Open();
                string strqry = $"INSERT INTO Evaluation VALUES ({parent.GetIntID}, {parent.GetPaymentID}, {score})";

                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

                return OraCmd.ExecuteNonQuery(); //추가되는 행수 반환
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                odpConn.Close();
            }
            return -1;
        }

        // 별점 테이블 업데이트
        private int DB_Update_Evaluation()
        {
            try
            {
                odpConn.ConnectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe)));";
                odpConn.Open();
                string strqry = $"UPDATE  Evaluation SET Rating={score} " +
                                $"WHERE ReservationID ={parent.GetIntID} AND PaymentID={parent.GetPaymentID}";

                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
                return OraCmd.ExecuteNonQuery(); //업데이트되는 행수 반환
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            finally 
            { 
                odpConn.Close(); 
            }
            return -1;
        }

        // 숙박시설 평점 업데이트
        private void UpdateAccommodationGrade()
        {
            try
            {
                odpConn.ConnectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe)));";
                odpConn.Open();

                decimal updatedGrade = GetEvaluationCountByRoomID(); // 평균 별점 계산 함수
                string updateQuery = $"UPDATE Accommodation SET Grade = {updatedGrade} WHERE AccommodationID = '{roomId}'";

                OracleCommand updateCommand = new OracleCommand(updateQuery, odpConn);
                updateCommand.ExecuteNonQuery();

                odpConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 평균 별점 계산하기
        private decimal GetEvaluationCountByRoomID()
        {
            List<int> reservationIDs = new List<int>(); // 해당 RoomID를 가진 ReservationID를 저장할 리스트
            // 평가한 사람 수, 점수 합계
            int count = 0; decimal totalRating = 0;
            try
            {
                // 해당 RoomID를 가진 ReservationID 검색
                string sqlQuery = $"SELECT ReservationID FROM Reservation WHERE RoomID = '{roomId}'";
                OracleCommand command = new OracleCommand(sqlQuery, odpConn);

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reservationIDs.Add(reader.GetInt32(0)); // ReservationID를 리스트에 추가
                }
                reader.Close();
                // 각 ReservationID별 Evaluation 테이블의 개수 세고, 점수 합산하여 저장
                foreach (int reservationID in reservationIDs)
                {
                    string countQuery = $"SELECT COUNT(*) FROM Evaluation WHERE ReservationID = {reservationID}";
                    string totalRatingQuery = $"SELECT Rating FROM Evaluation WHERE ReservationID = {reservationID}";
                    OracleCommand countCommand = new OracleCommand(countQuery, odpConn);
                    OracleCommand totalRatingCommand = new OracleCommand(totalRatingQuery, odpConn);
                    count = count + Convert.ToInt32(countCommand.ExecuteScalar());
                    totalRating = totalRating + Convert.ToInt32(totalRatingCommand.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return totalRating / count;
        }


        // 종료 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 선택한 별점 점수
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            score = 1;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            score = 2;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            score = 3;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            score = 4;
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            score = 5;
        }
    }
}

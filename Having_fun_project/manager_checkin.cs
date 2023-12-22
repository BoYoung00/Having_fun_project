using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Having_fun_project
{
    public partial class manager_checkin : Form
    {
        DBClass2 dbc = new DBClass2(); //DBClass 객체 생성
        
        String login; // 로그인 아이디 저장

        string SelectedPK; // 선택한 행 PK
        string AccommodationID; // 선택한 행의 방+호수이름

        private void ClearTextBoxes()
        {
            txtAdr.Clear();
            txtRoomNum.Clear();
            txtMax.Clear();
            txtPrice.Clear();
        }
        public manager_checkin(Manager_main userLogin)
        {
            InitializeComponent();
            login = userLogin.GetLoginID; // user_login 클래스에서 loginID 가져옴
            dbc.DB_Open();
        }

        private void manager_checkin_Load(object sender, EventArgs e)
        {
            showDataGridView();
            Room_header();
        }

        //추가 버튼
        private void RoomPlus_Click(object sender, EventArgs e)
        {
            INSERTRow();
        }
        //수정 버튼
         private void RoomUpdate_Click(object sender, EventArgs e)
         {
            UPDATERow();
         }
        //삭제 버튼
        private void RoomDelete_Click(object sender, EventArgs e)
        {
            DELETERow();
        }

        //시설 정보 추가 
        private void INSERTRow()
        {
            try
            {
                dbc.AccommodationTable = dbc.DS.Tables["Accommodation"];//*
                DataRow newRow = dbc.AccommodationTable.NewRow();
                //string inName = OwnerGetDate(); //시설 이름 받아오기
                //int inRoomNum = Convert.ToInt32(txtRoomNum.Text.Trim());//객실호수
                //string inid =  inRoomNum; //방 아이디 고유번호 PK (시설이름+객실호수)

                newRow["AccommodationID"] = txtRoomNum.Text.Trim(); //방 아이디 고유번호 PK (시설이름+객실호수)
                newRow["AccommodationType"] = comboBox1.SelectedItem as string;
                newRow["OwnerID"] = login;
                newRow["Address"] = txtAdr.Text;
                newRow["Maxoccupancy"] = Convert.ToInt32(txtMax.Text.Trim());
                newRow["Grade"] = 0;
                newRow["Price"] = Convert.ToInt32(txtPrice.Text.Trim());

                AccommodationID = txtRoomNum.Text.Trim();

                dbc.AccommodationTable.Rows.Add(newRow);
                dbc.DBAdapter.Update(dbc.DS, "Accommodation");
                dbc.DS.AcceptChanges();//*
                ClearTextBoxes();  //*
                RoomGrida.DataSource = dbc.DS.Tables["Accommodation"].DefaultView;
                DB_insert_RoomAvailability(); // 예약현황 행 추가
                showDataGridView();
            }
            catch (DataException DE)
            {
                //MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                //MessageBox.Show(DE.Message);
            }
        }


        //시설 정보 삭제
        private void DELETERow()
        {
            try
            {
                dbc.AccommodationTable = dbc.DS.Tables["Accommodation"];//*
                DataColumn[] PrimaryKey = new DataColumn[1];
                PrimaryKey[0] = dbc.AccommodationTable.Columns["AccommodationID"];
                dbc.AccommodationTable.PrimaryKey = PrimaryKey;

                DataRow currRow = dbc.AccommodationTable.Rows.Find(SelectedPK);
                currRow.Delete();

                dbc.DBAdapter.Update(dbc.DS.GetChanges(DataRowState.Deleted), "Accommodation");
                RoomGrida.DataSource = dbc.DS.Tables["Accommodation"].DefaultView;
                DB_delete_RoomAvailability(); // 예약현황 행 삭제
                showDataGridView();
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

        // 수정
        private void UPDATERow()
        {
            try
            {
                dbc.AccommodationTable = dbc.DS.Tables["Accommodation"];
                DataColumn[] PrimaryKey = new DataColumn[1];
                PrimaryKey[0] = dbc.AccommodationTable.Columns["AccommodationID"];
                dbc.AccommodationTable.PrimaryKey = PrimaryKey;

                DataRow currRow = dbc.AccommodationTable.Rows.Find(SelectedPK);

                currRow.BeginEdit();
                currRow["AccommodationID"] = txtRoomNum.Text.Trim(); //시설이름+호수 (기본키)
                currRow["AccommodationType"] = comboBox1.SelectedItem; //카테고리
                currRow["OwnerID"] = login;
                currRow["Address"] = txtAdr.Text; //주소
                currRow["Maxoccupancy"] = txtMax.Text.Trim(); //수용인원
                currRow["Price"] = txtPrice.Text.Trim(); //가격
                currRow.EndEdit();

                DataSet UpdatedSet = dbc.DS.GetChanges(DataRowState.Modified);
                if (UpdatedSet.HasErrors)
                {
                    MessageBox.Show("변경된 데이터에 문제가 있습니다.");
                }
                else
                {
                    dbc.DBAdapter.Update(UpdatedSet, "Accommodation");
                    dbc.DS.AcceptChanges();
                }
                RoomGrida.DataSource = dbc.DS.Tables["Accommodation"].DefaultView;
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }

        }

        // 예약현황 추가
        private int DB_insert_RoomAvailability()
        {
            try
            {
                string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) )";
                string commandString = "INSERT INTO RoomAvailability (RoomID, RoomDate, Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10, Day11, Day12, Day13, Day14, Day15, Day16, Day17, Day18, Day19, Day20, Day21, Day22, Day23, Day24, Day25, Day26, Day27, Day28, Day29, Day30, Day31) " +
                    $"VALUES ('{AccommodationID}', '2023-12', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0')";

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

        // 예약현황 삭제
        private int DB_delete_RoomAvailability()
        {
            try
            {
                string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                string commandString = $"DELETE FROM RoomAvailability WHERE RoomID = '{AccommodationID}' AND RoomDate = '2023-12'";

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




        //데이터 새로고침
        private void showDataGridView()
        {
            try
            {
                dbc.DS.Clear();
                dbc.DBAdapter.SelectCommand = new OracleCommand($"SELECT * FROM Accommodation where OwnerID = '{login}'", dbc.DBAdapter.SelectCommand.Connection); // SelectCommand 초기화
                dbc.DBAdapter.Fill(dbc.DS, "Accommodation");
                RoomGrida.DataSource = dbc.DS.Tables["Accommodation"].DefaultView;
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



        //다른 폼에서 시설 이름 정보 받아오기
        private String OwnerGetDate()  //사용자 정의 함수
        {
            string accommodationName = "";
            try
            {
                string connectionString = "User Id=kims; Password=1234; Data Source=(DESCRIPTION = " + "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER =" + "DEDICATED)(SERVICE_NAME = xe)) ); ";
                OracleConnection connection = new OracleConnection(connectionString);
                string sql = $"SELECT AccommodationName FROM Owner WHERE OwnerID = '{login}'";
                OracleCommand command = new OracleCommand(sql, connection);
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    accommodationName = reader["AccommodationName"].ToString();
                }
                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("오류 발생: " + ex.Message);
            }
            return accommodationName;
        }


        public void Room_header()
        {
            RoomGrida.Columns[0].HeaderText = "호수";
            RoomGrida.Columns[1].HeaderText = "유형";
            RoomGrida.Columns[2].HeaderText = "소유자";
            RoomGrida.Columns[3].HeaderText = "주소";
            RoomGrida.Columns[4].HeaderText = "수용인원";
            RoomGrida.Columns[5].HeaderText = "별점";
            RoomGrida.Columns[6].HeaderText = "가격";

            RoomGrida.Columns[0].Width = 100;
            RoomGrida.Columns[1].Width = 100;
            RoomGrida.Columns[2].Width = 80;
            RoomGrida.Columns[3].Width = 120;
            RoomGrida.Columns[4].Width = 80;
            RoomGrida.Columns[5].Width = 60;
            RoomGrida.Columns[6].Width = 80;
        }

        private void RoomGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable AccommodationTable = dbc.DS.Tables["Accommodation"];
                if (e.RowIndex < 0)
                {
                    return;
                }
                else if (e.RowIndex > AccommodationTable.Rows.Count - 1)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }

                DataRow currRow = AccommodationTable.Rows[e.RowIndex];
                txtRoomNum.Text = currRow["accommodationID"].ToString();
                comboBox1.Text = currRow["accommodationType"].ToString(); 
                txtAdr.Text = currRow["Address"].ToString();
                txtMax.Text = currRow["Maxoccupancy"].ToString();
                txtPrice.Text = currRow["Price"].ToString();
                dbc.SelectedRowIndex = e.RowIndex;

                SelectedPK = currRow["accommodationID"].ToString();

                //MessageBox.Show(e.RowIndex + "," + currRow["accommodationID"].ToString() + "," + currRow["accommodationType"].ToString() + "," + currRow["Address"].ToString() + "," + currRow["Maxoccupancy"].ToString() + "," + currRow["Price"].ToString() );
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



        /*private void manager_checkin_Load_1(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }*/
    }
}


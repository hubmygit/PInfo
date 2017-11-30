﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PumpInfo
{
    public class ImpData
    {

        //receipt data
        public string date = "";
        public string time = "";
        public DateTime datetime = new DateTime();
        public string position = "";
        public Coordinates coordinates = new Coordinates();
        public double weight = 0.0;
        public double temp = 0.0;
        public double density = 0.0;
        public double volume = 0.0;
        public int vehicleNo = 0;

        //
        public bool accepted = false;        
        public int dataGridViewRowIndex;

        //extra data - manually added
        public string brand = "";
        public string dealer = "";
        public string address = "";
        public string product = "";
        public string pump = "";
        public string pumpVolume = "";

        public ImpData(string[] lines)
        {
            vehicleNo = Convert.ToInt32(lines[0]);
            date = csvDateToSqlDate(lines[1]);
            time = csvTimeToSqlTime(lines[2]);
            datetime = sqlDtToDatetime(lines[1], lines[2]);

            position = lines[3];
            coordinates = getLatLon(lines[3]);

            weight = ConvertStrToDouble(lines[4]);
            temp = ConvertStrToDouble(lines[5]);
            density = ConvertStrToDouble(lines[6]);
            volume = ConvertStrToDouble(lines[7]);
        }

        public void addExtraData(string Brand, string Dealer, string Address, string Product, string Pump, string PumpVolume)
        {
            accepted = true;

            brand = Brand;
            dealer = Dealer;
            address = Address;
            product = Product;
            pump = Pump;
            pumpVolume = PumpVolume;
        }

        public void copyExtraData(ImpData otherObj)
        {
            accepted = otherObj.accepted;

            brand = otherObj.brand;
            dealer = otherObj.dealer;
            address = otherObj.address;
            product = otherObj.product;
            pump = otherObj.pump;
            pumpVolume = otherObj.pumpVolume;
        }

        public void removeExtraData()
        {
            accepted = false;

            brand = "";
            dealer = "";
            address = "";
            product = "";
            pump = "";
            pumpVolume = "";
        }

        public string csvDateToSqlDate(string csvDate)
        {
            string ret = "";
            string[] splittedDate = csvDate.Split('/');

            if (splittedDate[0].Trim().Length == 1)
            {
                splittedDate[0] = "0" + splittedDate[0].Trim();
            }
            if (splittedDate[1].Trim().Length == 1)
            {
                splittedDate[1] = "0" + splittedDate[1].Trim();
            }

            ret = splittedDate[2] + "-" + splittedDate[0] + "-" + splittedDate[1];

            return ret;
        }

        public string csvTimeToSqlTime(string csvTime)
        {
            string ret = "";
            string[] splittedTime = csvTime.Split(':');

            if (splittedTime[0].Trim().Length == 1)
            {
                splittedTime[0] = "0" + splittedTime[0].Trim();
            }
            if (splittedTime[1].Trim().Length == 1)
            {
                splittedTime[1] = "0" + splittedTime[1].Trim();
            }

            ret = splittedTime[0].Trim() + ":" + splittedTime[1].Trim();

            return ret;
        }

        public DateTime sqlDtToDatetime(string date, string time)
        {
            string[] dt = date.Split('/');
            string[] tm = time.Split(':');
            DateTime ret = new DateTime(Convert.ToInt32(dt[2]), Convert.ToInt32(dt[0]), Convert.ToInt32(dt[1]), Convert.ToInt32(tm[0]), Convert.ToInt32(tm[1]), 0);

            return ret;
        }

        public Coordinates getLatLon(string position)
        {
            Coordinates ret = new Coordinates();
            string[] splittedPos = position.Trim().Split(' ');
            ret.latitude = splittedPos[0];
            ret.longitude = splittedPos[1];

            return ret;
        }

        public double ConvertStrToDouble(string str)
        {
            double ret = 0.0;

            ret = Convert.ToDouble(str.Replace(".", ","));

            return ret;
        }
    }

    public enum RecordAction { None,
                               Insert,
                               Update,
                               Delete }

    public class Coordinates
    {
        public string latitude = "0";
        public string longitude = "0";

        //public double!!!!
    }

    public class DbUtilities
    {
        //public List<ImpData> ImpDataList = new List<ImpData>();

        public string fileName;

        public DbUtilities()
        {
            //
        }

        public DbUtilities(string File_Name)
        {
            fileName = File_Name;
        }

        public List<ImpData> FillListFromReceipt()
        {
            string File_Name = fileName;

            List<ImpData> ret = new List<ImpData>();

            try
            {
                using (StreamReader sr = new StreamReader(File_Name))
                {
                    string[] lines = new string[8];
                    int cnt = 0;
                    while (true)
                    {
                        string line = sr.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        if (line.Trim().Length == 0)
                        {
                            continue;
                        }

                        if (cnt == 0 && line.IndexOf("#") > 0)
                        {
                            lines[0] = line.Substring(line.IndexOf("#") + 1, 1);
                        }
                        else if (cnt > 0 && line.IndexOf(":") > 0)
                        {
                            if (cnt == 1)
                            {
                                lines[1] = line.Substring(line.IndexOf(":") + 1).Trim();
                            }
                            else if (cnt == 2)
                            {
                                lines[2] = line.Substring(line.IndexOf(":") + 1).Trim();
                            }
                            else if (cnt == 3)
                            {
                                lines[3] = line.Substring(line.IndexOf(":") + 1).Trim();
                            }
                            else if (cnt == 4)
                            {
                                lines[4] = line.Substring(line.IndexOf(":") + 1, line.IndexOf("Kg") - (line.IndexOf(":") + 1)).Trim();
                            }
                            else if (cnt == 5)
                            {
                                lines[5] = line.Substring(line.IndexOf(":") + 1, (line.IndexOf("C") - 1) - (line.IndexOf(":") + 1)).Trim();
                            }
                            else if (cnt == 6)
                            {
                                lines[6] = line.Substring(line.IndexOf(":") + 1).Trim();
                            }
                            else if (cnt == 7)
                            {
                                lines[7] = line.Substring(line.IndexOf(":") + 1, line.IndexOf("L") - (line.IndexOf(":") + 1)).Trim();
                            }
                        }

                        cnt++;

                        if (cnt == 8)
                        {
                            ret.Add(new ImpData(lines));

                            cnt = 0;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File could not be read:" + ex.Message);
            }

            return ret;
        }

        public bool InsertReceiptLineDataIntoSQLiteTable(ImpData receiptData)
        {
            bool ret = false;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");

            string InsSt = "INSERT INTO [receiptData] ([VehicleNo], [Dt], [CooLong], [CooLat], [Weight], [Temp], [Density], [Volume], [Accepted]) VALUES " + 
                           "(@Dt, @CooLong, @CooLat, @Weight, @Temp, @Density, @Volume, @VehicleNo, @Accepted) ";
            try
            {
                sqlConn.Open();
                SQLiteCommand cmd = new SQLiteCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@VehicleNo", receiptData.vehicleNo);
                cmd.Parameters.AddWithValue("@Dt", receiptData.datetime);
                cmd.Parameters.AddWithValue("@CooLong", receiptData.coordinates.longitude);
                cmd.Parameters.AddWithValue("@CooLat", receiptData.coordinates.latitude);
                cmd.Parameters.AddWithValue("@Weight", receiptData.weight);
                cmd.Parameters.AddWithValue("@Temp", receiptData.temp);
                cmd.Parameters.AddWithValue("@Density", receiptData.density);
                cmd.Parameters.AddWithValue("@Volume", receiptData.volume);
                cmd.Parameters.AddWithValue("@Accepted", receiptData.accepted);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            sqlConn.Close();

            return ret;
        }

        public bool InsertReceiptAllDataIntoSQLiteTable(List<ImpData> ImpDataList)
        {
            bool ret = true;

            foreach (ImpData thisLine in ImpDataList)
            {
                if (!InsertReceiptLineDataIntoSQLiteTable(thisLine))
                {
                    ret = false;
                }
            }

            return ret;
        }

        public List<ImpData> GetDataNotExistsInSQLiteTable(List<ImpData> ImpDataList)
        {
            List<ImpData> ret = new List<ImpData>();
            int RowIndex = 0;
            foreach (ImpData thisLine in ImpDataList)
            {
                if (!ExistsInSQLiteTable(thisLine))
                {
                    thisLine.dataGridViewRowIndex = RowIndex;
                    ret.Add(thisLine);

                    RowIndex++;
                }
            }

            return ret;
        }

        //public List<object[]> ImpDataListToGridViewRowList(List<ImpData> objList)
        //{
        //    List<object[]> ret = new List<object[]>();

        //    foreach (ImpData thisObj in objList)
        //    {
        //        ret.Add(ImpDataToGridViewRow(thisObj));
        //    }

        //    return ret;
        //}
        //public object[] ImpDataToGridViewRow(ImpData obj)
        //{
        //    //object[] ret = new object[] { false, obj.vehicleNo, obj.date, obj.time, ... };
        //    object[] ret = new object[] { obj.dataGridViewRowIndex, obj.accepted, obj.vehicleNo, obj.datetime.ToString("dd.MM.yyyy"),
        //                                  obj.time, obj.coordinates.latitude, obj.coordinates.longitude, obj.weight,
        //                                  obj.temp, obj.density, obj.volume };

        //    return ret;
        //}

        public bool ExistsInSQLiteTable(ImpData receiptData)
        {
            bool ret = false;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");
            SQLiteCommand cmd = new SQLiteCommand("SELECT Id FROM [receiptData] " + 
                "WHERE [VehicleNo] = @VehicleNo AND [Dt] = @Dt AND [CooLong] = @CooLong AND [CooLat] = @CooLat AND [Weight] = @Weight ", sqlConn);

            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@VehicleNo", receiptData.vehicleNo);
                cmd.Parameters.AddWithValue("@Dt", receiptData.datetime);
                cmd.Parameters.AddWithValue("@CooLong", receiptData.coordinates.longitude);
                cmd.Parameters.AddWithValue("@CooLat", receiptData.coordinates.latitude);
                cmd.Parameters.AddWithValue("@Weight", receiptData.weight);

                SQLiteDataReader reader = cmd.ExecuteReader();
                
                if(reader.Read())
                {
                    //string Id = reader["Id"].ToString();
                    ret = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

    }

    public static class SQLiteDBInfo
    {
        static SQLiteDBInfo()
        {
            dbFile = Application.StartupPath + "\\DBs\\PumpInfo.db"; 
        }

        public static string dbFile { get; set; }
    }

    public static class GridViewUtils
    {
        public static int getItemIndex(DataGridView dgv, int rowIndex)
        {
            //int ret = Convert.ToInt32(dgv.Rows[rowIndex].Cells[0].Value);
            int ret = Convert.ToInt32(dgv.Rows[rowIndex].Cells["Index"].Value);

            return ret;
        }

        public static void ShowDataToDataGridView(DataGridView dgv, List<object[]> objList)
        {
            dgv.Rows.Clear();

            foreach (object[] thisObj in objList)
            {
                dgv.Rows.Add(thisObj);
            }
        }

        public static void RefreshCheckBoxesToDataGridView(DataGridView dgv, List<ImpData> objList)
        {
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                dgv["Accepted", dgvRow.Index].Value = objList.Find(i=>i.dataGridViewRowIndex == dgvRow.Index).accepted;
            }
        }

        public static void ShowObjToDataGridView(DataGridView dgv, object[] obj)
        {
            dgv.Rows.Clear();
            
            dgv.Rows.Add(obj);
        }

        public static List<object[]> ImpDataListToGridViewRowList(List<ImpData> objList)
        {
            List<object[]> ret = new List<object[]>();

            foreach (ImpData thisObj in objList)
            {
                ret.Add(ImpDataToGridViewRow(thisObj));
            }

            return ret;
        }

        public static object[] ImpDataToGridViewRow(ImpData obj)
        {
            //object[] ret = new object[] { false, obj.vehicleNo, obj.date, obj.time, ... };
            object[] ret = new object[] { obj.dataGridViewRowIndex, obj.accepted, obj.vehicleNo, obj.datetime.ToString("dd.MM.yyyy"),
                                          obj.time, obj.coordinates.latitude, obj.coordinates.longitude, obj.weight,
                                          obj.temp, obj.density, obj.volume };

            return ret;
        }

    }
}

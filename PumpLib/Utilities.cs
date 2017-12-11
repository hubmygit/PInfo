﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Web.Script.Serialization;
using System.Data.SqlClient;

namespace PumpLib
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
        //public string brand = "";
        public Brand brand = new Brand();
        public string dealer = "";
        public string address = "";
        //public string product = "";
        public Product product = new Product();
        public string pump = "";
        public double pumpVolume = 0.0;
        public int geostationId = 0;

        //data to json -> to MSSQL
        public int receiptDataId = 0;
        public int processedGroupId = 0;
        public int exportedGroupId = 0;
        public int extraDataId = 0;
        public string strDt = "";

        public ImpData()
        {
            //
        }
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

        //public void addExtraData(string Brand, string Dealer, string Address, string Product, string Pump, string PumpVolume)
        public void addExtraData(Brand Brand, string Dealer, string Address, Product Product, string Pump, double PumpVolume)
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

            //brand = "";
            brand = new Brand();
            dealer = "";
            address = "";
            //product = "";
            product = new Product();
            pump = "";
            pumpVolume = 0.0;
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

    public enum RecordAction
    {
        None,
        Insert,
        Update,
        Delete
    }

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

        public bool InsertReceiptLineDataIntoSQLiteTable(ImpData receiptData, int processedId)
        {
            bool ret = false;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");

            string InsSt = "INSERT INTO [receiptData] ([VehicleNo], [Dt], [CooLong], [CooLat], [Weight], [Temp], [Density], [Volume], [Accepted], [ProcessedGroupId]) VALUES " +
                           "(@VehicleNo, @Dt, @CooLong, @CooLat, @Weight, @Temp, @Density, @Volume, @Accepted, @ProcessedGroupId) ";
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
                cmd.Parameters.AddWithValue("@ProcessedGroupId", processedId);

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

        public int GetMaxReceiptId()
        {
            int ret = -1;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");
            string SelectSt = "SELECT max(Id) as Id FROM [receiptData] ";
            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public bool InsertExtraLineDataIntoSQLiteTable(ImpData extraData, int receiptId)
        {
            bool ret = false;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");

            string InsSt = "INSERT INTO [extraData] ([ReceiptDataId], [BrandId], [Dealer], [Address], [ProductId], [Pump], [PumpVolume]) VALUES " +
                           "(@ReceiptDataId, @BrandId, @Dealer, @Address, @ProductId, @Pump, @PumpVolume) ";
            try
            {
                sqlConn.Open();
                SQLiteCommand cmd = new SQLiteCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@ReceiptDataId", receiptId);
                cmd.Parameters.AddWithValue("@BrandId", extraData.brand.Id);
                cmd.Parameters.AddWithValue("@Dealer", extraData.dealer);
                cmd.Parameters.AddWithValue("@Address", extraData.address);
                cmd.Parameters.AddWithValue("@ProductId", extraData.product.Id);
                cmd.Parameters.AddWithValue("@Pump", extraData.pump);
                cmd.Parameters.AddWithValue("@PumpVolume", extraData.pumpVolume);

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

        public int GetMaxProcessedGroupId()
        {
            int ret = 0;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");
            string SelectSt = "SELECT ifnull(max(Id), 0) as Id FROM [ProcessedGroup] ";
            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public int GetMaxExportedGroupId()
        {
            int ret = 0;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");
            string SelectSt = "SELECT ifnull(max(Id), 0) as Id FROM [ExportedGroup] ";
            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public int GetMaxReceiptData_ExportedGroupId()
        {
            int maxId = -1;
            int currentId = -1;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");
            string SelectSt = "SELECT ifnull(ExportedGroupId, 0) as Id, count(*) as cnt " +
                              "FROM [receiptData] GROUP BY ExportedGroupId ORDER BY ExportedGroupId ";

            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    currentId = Convert.ToInt32(reader["Id"].ToString());
                    if (currentId == 0) //null records
                    {
                        return 0;
                    }

                    if (maxId < currentId)
                    {
                        maxId = currentId;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return maxId;
        }

        public bool InsertProcessedGroupLineIntoSQLiteTable()
        {
            bool ret = false;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");

            string InsSt = "INSERT INTO [ProcessedGroup] ([Dt]) VALUES (datetime('now', 'localtime')) ";
            try
            {
                sqlConn.Open();
                SQLiteCommand cmd = new SQLiteCommand(InsSt, sqlConn);
                
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

        public bool InsertExportedGroupLineIntoSQLiteTable(string Filename)
        {
            bool ret = false;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");

            string InsSt = "INSERT INTO [ExportedGroup] ([Dt], [Filename]) VALUES (datetime('now', 'localtime'), @Filename) ";
            try
            {
                sqlConn.Open();
                SQLiteCommand cmd = new SQLiteCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Filename", Filename);

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

            int ProcessedGroupId = 0;

            if (ImpDataList.Count > 0)
            {
                if (!InsertProcessedGroupLineIntoSQLiteTable()) //insert new id
                {
                    return false;
                }
                ProcessedGroupId = GetMaxProcessedGroupId(); //get last (max) id
                if (ProcessedGroupId <= 0)
                {
                    return false;
                }

            }

            foreach (ImpData thisLine in ImpDataList)
            {
                if (InsertReceiptLineDataIntoSQLiteTable(thisLine, ProcessedGroupId))
                {
                    if (thisLine.accepted)
                    {
                        int receiptId = GetMaxReceiptId();
                        if (receiptId == -1)
                        {
                            //MessageBox.Show("Δε βρέθηκε Id Κύριας Εγγραφής!\r\nΗμ/νία-Ώρα εγγραφής: " + thisLine.datetime.ToString("dd.MM.yyyy hh:mm:ss"));
                            MessageBox.Show("Δε βρέθηκε καταχωρημένη κύρια Εγγραφή!");
                            ret = false;
                            continue;
                        }

                        if (!InsertExtraLineDataIntoSQLiteTable(thisLine, receiptId))
                        {
                            MessageBox.Show("Αποτυχία καταχώρησης συμπληρωματικών πληροφοριών! \r\nId Κύριας Εγγραφής: " + receiptId.ToString());
                        }
                    }
                }
                else
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

                if (reader.Read())
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

        public List<ImpData> ReceiptDataLines_To_ObjectList(int ExportedGroupId, int nextExportedGroupId_if_null)
        {
            List<ImpData> ret = new List<ImpData>();

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");
            SQLiteCommand cmd = new SQLiteCommand("SELECT RD.Id, RD.VehicleNo, datetime(RD.Dt) as Dt, RD.CooLong, RD.CooLat, RD.Weight, RD.Temp, RD.Density, RD.Volume, " +
                                                  "RD.Accepted, ifnull(RD.ProcessedGroupId,0) as ProcessedGroupId, ifnull(RD.ExportedGroupId,0) as ExportedGroupId, " +
                                                  "ifnull(ED.Id,0) as EDId, ED.ReceiptDataId, ED.BrandId, ED.Dealer, ED.Address, ED.ProductId, ED.Pump, ED.PumpVolume, ED.GeostationId " +
                " FROM [receiptData] RD left outer join [extraData] ED on RD.Id = ED.ReceiptDataId " +
                " WHERE ifnull(RD.[ExportedGroupId], 0) = @ExportedGroupId ", sqlConn);

            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@ExportedGroupId", ExportedGroupId);
                
                SQLiteDataReader reader = cmd.ExecuteReader();

                if (ExportedGroupId == 0)
                {
                    ExportedGroupId = nextExportedGroupId_if_null;
                }

                while (reader.Read())
                {
                    ImpData objLine = new ImpData() { receiptDataId = Convert.ToInt32(reader["Id"].ToString()),
                        vehicleNo = Convert.ToInt32(reader["VehicleNo"].ToString()),
                        //datetime = Convert.ToDateTime(reader["Dt"].ToString()),
                        strDt = reader["Dt"].ToString(),
                        coordinates = new Coordinates() { longitude = reader["CooLong"].ToString(), latitude = reader["CooLat"].ToString() },
                        weight = Convert.ToDouble(reader["Weight"].ToString()),
                        temp = Convert.ToDouble(reader["Temp"].ToString()),
                        density = Convert.ToDouble(reader["Density"].ToString()),
                        volume = Convert.ToDouble(reader["Volume"].ToString()),
                        accepted = Convert.ToBoolean(Convert.ToInt32(reader["Accepted"].ToString())),
                        processedGroupId = Convert.ToInt32(reader["ProcessedGroupId"].ToString()),
                        //exportedGroupId = Convert.ToInt32(reader["ExportedGroupId"].ToString())
                        exportedGroupId = ExportedGroupId
                    };

                    if (Convert.ToInt32(reader["EDId"].ToString()) > 0) //has extra data
                    {
                        objLine.extraDataId = Convert.ToInt32(reader["EDId"].ToString());
                        objLine.brand = new Brand() { Id = Convert.ToInt32(reader["BrandId"].ToString()) };
                        objLine.dealer = reader["Dealer"].ToString();
                        objLine.address = reader["Address"].ToString();
                        objLine.product = new Product() { Id = Convert.ToInt32(reader["ProductId"].ToString()) };
                        objLine.pump = reader["Pump"].ToString();
                        objLine.pumpVolume = Convert.ToDouble(reader["PumpVolume"].ToString());
                        objLine.geostationId = Convert.ToInt32(reader["GeostationId"].ToString());
                    }

                    ret.Add(objLine);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public bool UpdateReceiptData_ExportedGroupId(int nextExportedGroupId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SQLiteDBInfo.dbFile);
            string UpdSt = "UPDATE [receiptData] SET ExportedGroupId = " + (nextExportedGroupId + 1).ToString() + " WHERE ifnull(ExportedGroupId,0) = 0 ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);
                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public bool ObjectList_To_SQLServerReceiptDataLines(List<ImpData> ObjectList, string FileToImport)
        {
            bool ret = true;

            foreach (ImpData thisObj in ObjectList)
            {
                if (ObjectData_To_SQLServerReceiptDataLines(thisObj, FileToImport) == false)
                {
                    ret = false;
                }
                else
                {
                    //extra data
                    if (thisObj.extraDataId > 0)
                    {
                        if (ObjectData_To_SQLServerExtraDataLines(thisObj, FileToImport) == false)
                        {
                            ret = false;
                        }
                    }
                }
            }
            
            return ret;
        }

        public bool ObjectData_To_SQLServerReceiptDataLines(ImpData obj, string FileToImport)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string InsSt = "INSERT INTO [dbo].[receiptData] (Id, VehicleNo, Dt, CooLong, CooLat, Weight, Temp, Density, Volume, Accepted, ProcessedGroupId, ExportedGroupId, ImpFilename) " +
                           " VALUES (@Id, @VehicleNo, @Dt, @CooLong, @CooLat, @Weight, @Temp, @Density, @Volume, @Accepted, @ProcessedGroupId, @ExportedGroupId, @ImpFilename ) ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", obj.receiptDataId);
                cmd.Parameters.AddWithValue("@VehicleNo", obj.vehicleNo);
                cmd.Parameters.AddWithValue("@Dt", obj.strDt); //????????
                cmd.Parameters.AddWithValue("@CooLong", obj.coordinates.longitude);
                cmd.Parameters.AddWithValue("@CooLat", obj.coordinates.latitude);
                cmd.Parameters.AddWithValue("@Weight", obj.weight);
                cmd.Parameters.AddWithValue("@Temp", obj.temp);
                cmd.Parameters.AddWithValue("@Density", obj.density);
                cmd.Parameters.AddWithValue("@Volume", obj.volume);
                cmd.Parameters.AddWithValue("@Accepted", obj.accepted);
                cmd.Parameters.AddWithValue("@ProcessedGroupId", obj.processedGroupId);
                cmd.Parameters.AddWithValue("@ExportedGroupId", obj.exportedGroupId);
                cmd.Parameters.AddWithValue("@ImpFilename", FileToImport);

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


        public bool ObjectData_To_SQLServerExtraDataLines(ImpData obj, string FileToImport)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string InsSt = "INSERT INTO [dbo].[extraData] (Id, ReceiptDataId, BrandId, Dealer, Address, ProductId, Pump, PumpVolume, GeostationId) " +
                        " VALUES (@Id, @ReceiptDataId, @BrandId, @Dealer, @Address, @ProductId, @Pump, @PumpVolume, @GeostationId ) ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", obj.extraDataId);
                cmd.Parameters.AddWithValue("@ReceiptDataId", obj.receiptDataId);
                cmd.Parameters.AddWithValue("@BrandId", obj.brand.Id);
                cmd.Parameters.AddWithValue("@Dealer", obj.dealer);
                cmd.Parameters.AddWithValue("@Address", obj.address);
                cmd.Parameters.AddWithValue("@ProductId", obj.product.Id);
                cmd.Parameters.AddWithValue("@Pump", obj.pump);
                cmd.Parameters.AddWithValue("@PumpVolume", obj.pumpVolume);
                cmd.Parameters.AddWithValue("@GeostationId", obj.geostationId);

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

        public string ObjectListToJson(List<ImpData> ObjectList)
        {
            //one object to json and back
            //string json = new JavaScriptSerializer().Serialize(ObjectList[0]);
            //ImpData desObj = new JavaScriptSerializer().Deserialize<ImpData>(json);
            
            //object list to json and back
            //**object list to json**
            string jsonAll = new JavaScriptSerializer().Serialize(ObjectList);

            //**json to object list**
            //List<ImpData> desObjAll = new JavaScriptSerializer().Deserialize<List<ImpData>>(jsonAll);
            
            return jsonAll;
        }

        public List<ImpData> JsonToObjectList(string jsonFile)
        {
            List<ImpData> desObjAll = new JavaScriptSerializer().Deserialize<List<ImpData>>(jsonFile);

            return desObjAll;
        }

        public void createJsonFile(string Path, string jsonData)
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.Write(jsonData);
            }
        }

        public string createJsonFile(string jsonData)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Text files (*.txt)|*.txt";
            sfd.Filter = "JSON files (*.json)|*.json";
            DialogResult result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
                filename = sfd.FileName;
                createJsonFile(sfd.FileName, jsonData);
            }

            return filename;
        }

        public string getAllDataFromJsonFile(string Path)
        {
            string ret = "";

            using (StreamReader sr = new StreamReader(Path))
            {
                ret = sr.ReadToEnd();
            }

            return ret;
        }


        public string getAllDataFromJsonFile()
        {
            string ret = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON files (*.json)|*.json";
            DialogResult result = ofd.ShowDialog();

            string json_Path = ofd.FileName;
            if (json_Path.Trim() == "" || result != DialogResult.OK)
            {
                return ret;
            }

            ret = getAllDataFromJsonFile(json_Path);

            return ret;
        }

        public static List<Brand> GetBrandsList()
        {
            List<Brand> ret = new List<Brand>();

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");
            string SelectSt = "SELECT Id, Name FROM [Brand] ORDER BY Name ";
            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Brand() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<ComboboxItem> GetBrandsComboboxItemsList(List<Brand> Brands)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Brand br in Brands)
            {
                ret.Add(new ComboboxItem() { Value = br, Text = br.Name });
            }

            return ret;
        }

        public static Brand getComboboxItem_Brand(ComboBox cb)
        {
            Brand ret = ((Brand)((ComboboxItem)cb.SelectedItem).Value);

            return ret;
        }

        public static List<Product> GetProductsList()
        {
            List<Product> ret = new List<Product>();

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + SQLiteDBInfo.dbFile + ";Version=3;");
            string SelectSt = "SELECT Id, Name FROM [Product] ORDER BY Name ";
            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Product() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }
        public static List<ComboboxItem> GetProductsComboboxItemsList(List<Product> Products)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Product pr in Products)
            {
                ret.Add(new ComboboxItem() { Value = pr, Text = pr.Name });
            }

            return ret;
        }

        public static Product getComboboxItem_Product(ComboBox cb)
        {
            Product ret = ((Product)((ComboboxItem)cb.SelectedItem).Value);

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

    public static class SqlDBInfo
    {
        static SqlDBInfo()
        {
            //default values
            string server = "protokolSrv";
            string database = "PumpInfo"; 
            string username = "GramUser"; 
            string password = "111111"; 
            connectionString = "Persist Security Info=False; User ID=" + username + "; Password=" + password + "; Initial Catalog=" + database + "; Server=" + server;
        }

        public static string connectionString { get; set; }
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
                dgv["Accepted", dgvRow.Index].Value = objList.Find(i => i.dataGridViewRowIndex == dgvRow.Index).accepted;
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

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand()
        {
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Product()
        {
        }
    }

}
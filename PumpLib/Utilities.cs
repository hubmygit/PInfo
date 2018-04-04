using System;
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
        public int sampleNo = 0;
        public string remarks = "";
        
        public int geostationId = 0;
        public Coordinates realCoordinates = new Coordinates();

        //data to json -> to MSSQL
        public int receiptDataId = 0;
        public int processedGroupId = 0;
        public int exportedGroupId = 0;
        public int extraDataId = 0;
        public string strDt = "";

        public int machineNo = 0;
        public string productGroup = "";

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
        public void addExtraData(Brand Brand, string Dealer, string Address, Product Product, string Pump, double PumpVolume, int SampleNo, string Remarks, int GeostationId, Coordinates RealCoordinates)
        {
            accepted = true;

            brand = Brand;
            dealer = Dealer;
            address = Address;
            product = Product;
            pump = Pump;
            pumpVolume = PumpVolume;
            sampleNo = SampleNo;
            remarks = Remarks;
            geostationId = GeostationId;
            realCoordinates = RealCoordinates;
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
            sampleNo = otherObj.sampleNo;
            remarks = otherObj.remarks;
            geostationId = otherObj.geostationId;
            realCoordinates = otherObj.realCoordinates;
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
            sampleNo = 0;
            remarks = "";
            geostationId = 0;
            realCoordinates = new Coordinates();
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

            ret = Convert.ToDouble(str.Replace(".", ",").Replace("-", "0"));

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

        public bool automaticMode = false;

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

            int records = 0;
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
                            records++;

                            cnt = 0;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record: " + records.ToString() + ".\r\nFile could not be read: " + ex.Message);
            }

            return ret;
        }
        
        public bool InsertReceiptLineDataIntoSQLiteTable(ImpData receiptData, int processedId)
        {
            bool ret = false;

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);

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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);

            string InsSt = "INSERT INTO [extraData] ([ReceiptDataId], [BrandId], [Dealer], [Address], [ProductId], [Pump], [PumpVolume], [SampleNo], [Remarks], [GeostationId], [CooLong], [CooLat]) VALUES " +
                           "(@ReceiptDataId, @BrandId, @Dealer, @Address, @ProductId, @Pump, @PumpVolume, @SampleNo, @Remarks, @GeostationId, @CooLong, @CooLat) ";
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
                cmd.Parameters.AddWithValue("@SampleNo", extraData.sampleNo);
                cmd.Parameters.AddWithValue("@Remarks", extraData.remarks);
                cmd.Parameters.AddWithValue("@GeostationId", extraData.geostationId);
                cmd.Parameters.AddWithValue("@CooLong", extraData.realCoordinates.longitude);
                cmd.Parameters.AddWithValue("@CooLat", extraData.realCoordinates.latitude);

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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
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
                sqlConn.Close();
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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
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
                sqlConn.Close();
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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
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
                        maxId = 0;
                        break;
                        //return 0;
                    }

                    if (maxId < currentId)
                    {
                        maxId = currentId;
                    }
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return maxId;
        }

        public int CountReceiptData_ExportedGroupId()
        {
            int cnt = 0;

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
            string SelectSt = "SELECT count(*) as cnt " +
                              "FROM [receiptData] WHERE ifnull(ExportedGroupId, 0) = 0 ";

            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cnt = Convert.ToInt32(reader["cnt"].ToString());
                    
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return cnt;
        }

        public bool InsertProcessedGroupLineIntoSQLiteTable()
        {
            bool ret = false;

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);

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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);

            string InsSt = "INSERT INTO [ExportedGroup] ([Dt], [Filename]) VALUES (datetime('now', 'localtime'), @Filename) ";
            try
            {
                sqlConn.Open();
                SQLiteCommand cmd = new SQLiteCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@Filename", Filename);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                ret = true;

                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }




            //sqlConn.Open();

            //using (var cmd = new SQLiteCommand(InsSt, sqlConn))
            //using (var transaction = sqlConn.BeginTransaction())
            //{
            //    cmd.Parameters.AddWithValue("@Filename", Filename);
            //    cmd.CommandType = CommandType.Text;

            //    cmd.ExecuteNonQuery();

            //    transaction.Commit();

            //    ret = true;
            //}



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
                thisLine.processedGroupId = ProcessedGroupId;

                if (InsertReceiptLineDataIntoSQLiteTable(thisLine, ProcessedGroupId))
                {
                    if (thisLine.accepted)
                    {
                        int receiptId = GetMaxReceiptId();
                        if (receiptId == -1)
                        {
                            //MessageBox.Show("Δε βρέθηκε Id Κύριας Εγγραφής!\r\nΗμ/νία-Ώρα εγγραφής: " + thisLine.datetime.ToString("dd.MM.yyyy HH:mm:ss"));
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
        
        public List<ImpData> GetDataNotExistsInSQLSrvTable(List<ImpData> ImpDataList)
        {
            List<ImpData> ret = new List<ImpData>();
            int RowIndex = 0;

            List<Brand> brands = GetSqlBrandsList(automaticMode);
            List<Product> products = GetSqlProductsList(automaticMode);

            foreach (ImpData thisLine in ImpDataList)
            {
                if (!ExistsInSQLSrvTable(thisLine))
                {
                    thisLine.dataGridViewRowIndex = RowIndex;

                    //add other vars needed...
                    thisLine.date = thisLine.strDt.Substring(0, 10);//csvDateToSqlDate(lines[1]);
                    thisLine.time = thisLine.strDt.Substring(11, 5);//csvTimeToSqlTime(lines[2]);
                    thisLine.datetime = Convert.ToDateTime(thisLine.strDt);//sqlDtToDatetime(lines[1], lines[2]);
                    thisLine.position = thisLine.coordinates.latitude + " " + thisLine.coordinates.longitude;//lines[3];

                    if (thisLine.brand.Id > 0)
                    {
                        thisLine.brand.Name = brands.Find(i => i.Id == thisLine.brand.Id).Name;
                    }

                    if (thisLine.product.Id > 0)
                    {
                        thisLine.product.Name = products.Find(i => i.Id == thisLine.product.Id).Name;
                    }

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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
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
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public bool ExistsInSQLSrvTable(ImpData receiptData)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT Id, Accepted FROM [dbo].[receiptData] " +
                "WHERE [VehicleNo] = @VehicleNo AND [Dt] = @Dt AND [CooLong] = @CooLong AND [CooLat] = @CooLat AND [Weight] = @Weight ", sqlConn);

            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@VehicleNo", receiptData.vehicleNo);
                cmd.Parameters.AddWithValue("@Dt", receiptData.strDt); 
                cmd.Parameters.AddWithValue("@CooLong", receiptData.coordinates.longitude);
                cmd.Parameters.AddWithValue("@CooLat", receiptData.coordinates.latitude);
                cmd.Parameters.AddWithValue("@Weight", receiptData.weight);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //string Id = reader["Id"].ToString();
                    
                    ret = true;

                    if (receiptData.accepted)
                    {
                        if (reader["Accepted"].ToString() == "1")
                        {
                            ret = false;
                        }
                    }
                }

                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

        public List<ImpData> ReceiptDataLines_To_ObjectList(int ExportedGroupId, int nextExportedGroupId_if_null)
        {
            int ExpGrId = ExportedGroupId;
            List<ImpData> ret = new List<ImpData>();

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
            SQLiteCommand cmd = new SQLiteCommand("SELECT RD.Id, RD.VehicleNo, datetime(RD.Dt) as Dt, RD.CooLong, RD.CooLat, RD.Weight, RD.Temp, RD.Density, RD.Volume, " +
                                                  "RD.Accepted, ifnull(RD.ProcessedGroupId,0) as ProcessedGroupId, ifnull(RD.ExportedGroupId,0) as ExportedGroupId, " +
                                                  "ifnull(ED.Id,0) as EDId, ED.ReceiptDataId, ED.BrandId, ED.Dealer, ED.Address, ED.ProductId, ED.Pump, ED.PumpVolume, " +
                                                  "ifnull(ED.SampleNo,0) as SampleNo, ED.Remarks, ifnull(ED.GeostationId,0) as GeostationId, " + 
                                                  "ED.CooLong as RealCooLong, ED.CooLat as RealCooLat " +
                " FROM [receiptData] RD left outer join [extraData] ED on RD.Id = ED.ReceiptDataId " +
                " WHERE ifnull(RD.[ExportedGroupId], 0) = @ExportedGroupId ", sqlConn);

            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@ExportedGroupId", ExportedGroupId);
                
                SQLiteDataReader reader = cmd.ExecuteReader();

                if (ExportedGroupId == 0)
                {
                    ExpGrId = nextExportedGroupId_if_null;
                }

                int machNo = getInstId();

                while (reader.Read())
                {
                    ImpData objLine = new ImpData()
                    {   receiptDataId = Convert.ToInt32(reader["Id"].ToString()),
                        vehicleNo = Convert.ToInt32(reader["VehicleNo"].ToString()),
                        datetime = Convert.ToDateTime(reader["Dt"].ToString()), //????????????
                        strDt = reader["Dt"].ToString(),
                        coordinates = new Coordinates() { longitude = reader["CooLong"].ToString().Replace(",","."), latitude = reader["CooLat"].ToString().Replace(",", ".") },
                        weight = Convert.ToDouble(reader["Weight"].ToString()),
                        temp = Convert.ToDouble(reader["Temp"].ToString()),
                        density = Convert.ToDouble(reader["Density"].ToString()),
                        volume = Convert.ToDouble(reader["Volume"].ToString()),
                        accepted = Convert.ToBoolean(Convert.ToInt32(reader["Accepted"].ToString())),
                        processedGroupId = Convert.ToInt32(reader["ProcessedGroupId"].ToString()),
                        //exportedGroupId = Convert.ToInt32(reader["ExportedGroupId"].ToString())
                        exportedGroupId = ExpGrId,
                        machineNo = machNo
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
                        objLine.sampleNo = Convert.ToInt32(reader["SampleNo"].ToString());
                        objLine.remarks = reader["Remarks"].ToString();
                        objLine.geostationId = Convert.ToInt32(reader["GeostationId"].ToString());
                        objLine.realCoordinates = new Coordinates() { longitude = reader["RealCooLong"].ToString().Replace(",", "."), latitude = reader["RealCooLat"].ToString().Replace(",", ".") };
                    }

                    ret.Add(objLine);
                }

                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public List<ImpData> ReceiptDBLines_To_ObjectList()
        {
            List<ImpData> ret = new List<ImpData>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT RD.Id, RD.VehicleNo, RD.Dt, RD.CooLong, RD.CooLat, RD.Weight, RD.Temp, RD.Density, RD.Volume, " +
                                            "isnull(RD.Accepted,0) as Accepted, isnull(RD.ProcessedGroupId,0) as ProcessedGroupId, isnull(RD.ExportedGroupId,0) as ExportedGroupId, " +
                                            "isnull(ED.Id,0) as EDId, ED.ReceiptDataId, ED.BrandId, B.Name as BName, ED.Dealer, ED.Address, ED.ProductId, P.Name as PName, ED.Pump, ED.PumpVolume, " +
                                            "isnull(ED.SampleNo,0) as SampleNo, isnull(RD.MachineNo,0) as MachineNo, ED.Remarks, isnull(ED.GeostationId,0) as GeostationId, " +
                                            "ED.CooLong as RealCooLong, ED.CooLat as RealCooLat, PG.Name as ProductGroup " +
                                            //" ,SV.Address as GeoAddr1, SV.Address2 as GeoAddr2, SV.Address3 as GeoAddr3, SV.[Postal-Code] as PostalCode, SV.Country, SV.Latitude as GeoLat, SV.Longitude as GeoLong, SV.UpdDate as GeoDt, SV.Comp_Name " + 
                                            " FROM [dbo].[receiptData] RD left outer join " +
                                            "[dbo].[extraData] ED on RD.Id = ED.ReceiptDataId left outer join " +
                                            "[dbo].[brand] B on B.id = ED.BrandId left outer join " +
                                            "[dbo].[product] P on P.id = ED.ProductId " + //left outer join " +
                                            //"[dbo].[Station_View] SV on SV.id = ED.GeostationId " +
                                            "left outer join [dbo].[Vehicles] V on RD.VehicleNo = V.Id left outer join " + 
                                            " ProductGroup PG on V.ProductGroupId = PG.Id " +
                                            " WHERE isnull(RD.Accepted, 0) = 1 " +
                                            " ORDER BY RD.Dt DESC ", sqlConn);
                        
            //SELECT count(SF.*) FROM [dbo].[SampleFiles] SF WHERE SF.ExtraDataId = ED.Id

            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ImpData objLine = new ImpData()
                    {
                        receiptDataId = Convert.ToInt32(reader["Id"].ToString()),
                        vehicleNo = Convert.ToInt32(reader["VehicleNo"].ToString()),

                        datetime = Convert.ToDateTime(reader["Dt"].ToString()),
                        strDt = reader["Dt"].ToString(),
                        date = Convert.ToDateTime(reader["Dt"].ToString()).ToString("dd.MM.yyyy"),
                        time = Convert.ToDateTime(reader["Dt"].ToString()).ToString("HH:mm"),
                        coordinates = new Coordinates() { longitude = reader["CooLong"].ToString().Replace(",", "."), latitude = reader["CooLat"].ToString().Replace(",", ".") },
                        weight = Convert.ToDouble(reader["Weight"].ToString()),
                        temp = Convert.ToDouble(reader["Temp"].ToString()),
                        density = Convert.ToDouble(reader["Density"].ToString()),
                        volume = Convert.ToDouble(reader["Volume"].ToString()),
                        accepted = Convert.ToBoolean(reader["Accepted"].ToString()),
                        processedGroupId = Convert.ToInt32(reader["ProcessedGroupId"].ToString()),
                        exportedGroupId = Convert.ToInt32(reader["ExportedGroupId"].ToString()),
                        machineNo = Convert.ToInt32(reader["MachineNo"].ToString()),
                        productGroup = reader["ProductGroup"].ToString()
                    };

                    if (Convert.ToInt32(reader["EDId"].ToString()) > 0) //has extra data
                    {
                        objLine.extraDataId = Convert.ToInt32(reader["EDId"].ToString());
                        objLine.brand = new Brand() { Id = Convert.ToInt32(reader["BrandId"].ToString()), Name = reader["BName"].ToString() }; 
                        objLine.dealer = reader["Dealer"].ToString();
                        objLine.address = reader["Address"].ToString();
                        objLine.product = new Product() { Id = Convert.ToInt32(reader["ProductId"].ToString()), Name = reader["PName"].ToString() }; 
                        objLine.pump = reader["Pump"].ToString();
                        objLine.pumpVolume = Convert.ToDouble(reader["PumpVolume"].ToString());
                        objLine.sampleNo = Convert.ToInt32(reader["SampleNo"].ToString());
                        objLine.remarks = reader["Remarks"].ToString();
                        objLine.geostationId = Convert.ToInt32(reader["GeostationId"].ToString());
                        objLine.realCoordinates = new Coordinates() { longitude = reader["RealCooLong"].ToString().Replace(",", "."), latitude = reader["RealCooLat"].ToString().Replace(",", ".") };
                    }
                                        
                        //brand Name -> constructor...new Brand(int id) --id = BrandId / name = DbUtilities.GetBrandsList()                         
                        
                    

                    ret.Add(objLine);
                }

                reader.Close();
                sqlConn.Close();
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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
            string UpdSt = "UPDATE [receiptData] SET ExportedGroupId = " + nextExportedGroupId.ToString() + " WHERE ifnull(ExportedGroupId,0) = 0 ";
            try
            {
                sqlConn.Open();
                SQLiteCommand cmd = new SQLiteCommand(UpdSt, sqlConn);
                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }

                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            
            return ret;
        }

        public bool ObjectList_To_SQLServerReceiptDataLines(List<ImpData> ObjectList, int ImportedGroupId)
        {
            bool ret = true;

            foreach (ImpData thisObj in ObjectList)
            {
                if (ObjectData_To_SQLServerReceiptDataLines(thisObj, ImportedGroupId) == false)
                {
                    ret = false;
                }
                else
                {
                    //extra data
                    if (thisObj.extraDataId > 0)
                    {
                        if (ObjectData_To_SQLServerExtraDataLines(thisObj) == false)
                        {
                            ret = false;
                        }
                    }
                }
            }
            
            return ret;
        }

        public bool ObjectData_To_SQLServerReceiptDataLines(ImpData obj, int ImportedGroupId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string InsSt = "INSERT INTO [dbo].[receiptData] (ClientId, VehicleNo, Dt, CooLong, CooLat, Weight, Temp, Density, Volume, Accepted, ProcessedGroupId, ExportedGroupId, ImportedGroupId, MachineNo) " +
                           " VALUES (@ClientId, @VehicleNo, @Dt, @CooLong, @CooLat, @Weight, @Temp, @Density, @Volume, @Accepted, @ProcessedGroupId, @ExportedGroupId, @ImportedGroupId, @MachineNo ) ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@ClientId", obj.receiptDataId);
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
                cmd.Parameters.AddWithValue("@ImportedGroupId", ImportedGroupId);
                cmd.Parameters.AddWithValue("@MachineNo", obj.machineNo);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                
                ret = true;
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
                
                Output.WriteToFile(ex.Message, true);
            }

            sqlConn.Close();

            return ret;
        }

        public int getSQLReceiptDataId(int ClientReceiptDataId, int MachineNo)
        {
            int ret = -1;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id FROM [dbo].[receiptData] WHERE ClientId = @ClientReceiptDataId and MachineNo = @MachineNo ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);

            cmd.Parameters.AddWithValue("@ClientReceiptDataId", ClientReceiptDataId);
            cmd.Parameters.AddWithValue("@MachineNo", MachineNo);

            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
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

        public List<VehicleTrace> Get_VehicleTrace_Data(List<int> ProcessGroupIds)
        {
            List<VehicleTrace> ret = new List<VehicleTrace>();

            string ProcGroupIds = String.Join(",", ProcessGroupIds);

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
            string SelectSt = "SELECT Id, ProcessedGroupId, MachineNo, VehicleNo, DtYear, DtMonth, Km FROM [VehicleTrace] WHERE ProcessedGroupId IN ( " + ProcGroupIds + " ) ";

            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new VehicleTrace()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        ProcessedGroupId = Convert.ToInt32(reader["ProcessedGroupId"].ToString()),
                        MachineNo = Convert.ToInt32(reader["MachineNo"].ToString()),
                        VehicleNo = Convert.ToInt32(reader["VehicleNo"].ToString()),
                        DtYear = Convert.ToInt32(reader["DtYear"].ToString()),
                        DtMonth = Convert.ToInt32(reader["DtMonth"].ToString()),
                        Km = Convert.ToInt32(reader["Km"].ToString())
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public List<Station> Get_Station_Data(DateTime fromDate, DateTime toDate)
        {
            List<Station> ret = new List<Station>();

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBMap.connectionString);
            string SelectSt = "SELECT Id, UpdDate, Current_Rec, Comp_Name, Company_Id FROM Station_TimeDependData WHERE UpdDate >= @fromDate and UpdDate <= @toDate ";

            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);

            try
            {
                sqlConn.Open();

                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Station()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        //UpdDate = Convert.ToDateTime(reader["UpdDate"].ToString()),
                        UpdDate = Convert.ToDateTime(reader["UpdDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss.000"),
                        Current_Rec = Convert.ToBoolean(reader["Current_Rec"].ToString()),
                        Comp_Name = reader["Comp_Name"].ToString(),
                        Company_Id = Convert.ToInt32(reader["Company_Id"].ToString())
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public bool ObjectData_To_SQLServerExtraDataLines(ImpData obj)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string InsSt = "INSERT INTO [dbo].[extraData] (ReceiptDataId, ClientId, ClientReceiptDataId, BrandId, Dealer, Address, ProductId, Pump, PumpVolume, SampleNo, Remarks, GeostationId, CooLong, CooLat) " +
                        " VALUES (@ReceiptDataId, @ClientId, @ClientReceiptDataId, @BrandId, @Dealer, @Address, @ProductId, @Pump, @PumpVolume, @SampleNo, @Remarks, @GeostationId, @CooLong, @CooLat ) ";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@ReceiptDataId", getSQLReceiptDataId(obj.receiptDataId, obj.machineNo));
                cmd.Parameters.AddWithValue("@ClientId", obj.extraDataId);
                cmd.Parameters.AddWithValue("@ClientReceiptDataId", obj.receiptDataId);
                cmd.Parameters.AddWithValue("@BrandId", obj.brand.Id);
                cmd.Parameters.AddWithValue("@Dealer", obj.dealer);
                cmd.Parameters.AddWithValue("@Address", obj.address);
                cmd.Parameters.AddWithValue("@ProductId", obj.product.Id);
                cmd.Parameters.AddWithValue("@Pump", obj.pump);
                cmd.Parameters.AddWithValue("@PumpVolume", obj.pumpVolume);
                cmd.Parameters.AddWithValue("@SampleNo", obj.sampleNo);
                cmd.Parameters.AddWithValue("@Remarks", obj.remarks);
                cmd.Parameters.AddWithValue("@GeostationId", obj.geostationId);
                cmd.Parameters.AddWithValue("@CooLong", obj.realCoordinates.longitude);
                cmd.Parameters.AddWithValue("@CooLat", obj.realCoordinates.latitude);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
                
                Output.WriteToFile(ex.Message, true);
            }

            sqlConn.Close();

            return ret;
        }

        private bool InertIntoTable_VehicleTrace(VehicleTrace vehicleTrace) //INSERT [dbo].[VehicleTrace]
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[VehicleTrace] (ClientId, ProcessedGroupId, MachineNo, VehicleNo, DtYear, DtMonth, Km) VALUES " +
                           "(@ClientId, @ProcessedGroupId, @MachineNo, @VehicleNo, @DtYear, @DtMonth, @Km) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@ClientId", vehicleTrace.Id);
                cmd.Parameters.AddWithValue("@ProcessedGroupId", vehicleTrace.ProcessedGroupId);
                cmd.Parameters.AddWithValue("@MachineNo", vehicleTrace.MachineNo);
                cmd.Parameters.AddWithValue("@VehicleNo", vehicleTrace.VehicleNo);
                cmd.Parameters.AddWithValue("@DtYear", vehicleTrace.DtYear);
                cmd.Parameters.AddWithValue("@DtMonth", vehicleTrace.DtMonth);
                cmd.Parameters.AddWithValue("@Km", vehicleTrace.Km);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
                Output.WriteToFile(ex.Message, true);
            }
            sqlConn.Close();

            return ret;
        }

        public bool Insert_List_Into_VehicleTrace(List<VehicleTrace> objList)
        {
            bool ret = true;

            foreach (VehicleTrace thisVTObj in objList)
            {
                if (!InertIntoTable_VehicleTrace(thisVTObj))
                {
                    ret = false;
                }
            }

            return ret;
        }
        
        private bool UpdateTable_Station_TimeDependData(int Id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string UpdSt = "UPDATE [dbo].[Station_TimeDependData] SET Current_Rec = 0 WHERE Id = @Id";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", Id);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }

                Output.WriteToFile(ex.Message, true);
            }

            sqlConn.Close();

            return ret;
        }

        private bool InsertIntoTable_Station_TimeDependData(Station station) //INSERT [dbo].[Station_TimeDependData]
        {   
            bool ret = false;
            
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Station_TimeDependData] (Id, UpdDate, Current_Rec, Comp_Name, Company_Id) VALUES " +
                           "(@Id, @UpdDate, @Current_Rec, @Comp_Name, @Company_Id) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@Id", station.Id);
                cmd.Parameters.AddWithValue("@UpdDate", station.UpdDate);
                cmd.Parameters.AddWithValue("@Current_Rec", station.Current_Rec);
                cmd.Parameters.AddWithValue("@Comp_Name", station.Comp_Name);
                cmd.Parameters.AddWithValue("@Company_Id", station.Company_Id);

                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
                Output.WriteToFile(ex.Message, true);
            }
            sqlConn.Close();
            
            return ret;
        }

        private bool NewDataInto_Station_TimeDependData(Station station)
        {
            bool ret = true;

            if (!UpdateTable_Station_TimeDependData(station.Id))
            {
                ret = false;
            }
            
            if (!InsertIntoTable_Station_TimeDependData(station))
            {
                ret = false;
            }

            return ret;
        }

        public bool Insert_List_Into_Station(List<Station> objList)
        {
            bool ret = true;

            foreach (Station thisStationObj in objList)
            {
                if (!NewDataInto_Station_TimeDependData(thisStationObj))
                {
                    ret = false;
                }
            }

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

        public string ObjectListToJson(ImpData_And_VehicleTrace obj)
        {
            string jsonAll = "";

            try
            {
                jsonAll = new JavaScriptSerializer().Serialize(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            return jsonAll;
        }

        public List<ImpData> JsonToObjectList(string jsonFile)
        {
            List<ImpData> desObjAll = new JavaScriptSerializer().Deserialize<List<ImpData>>(jsonFile);

            return desObjAll;
        }

        public ImpData_And_VehicleTrace JsonToMultipleObject(string jsonFile)
        {
            ImpData_And_VehicleTrace desObjAll = new ImpData_And_VehicleTrace();
            try
            {
                desObjAll = new JavaScriptSerializer().Deserialize<ImpData_And_VehicleTrace>(jsonFile);
                //new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(1514757600000).AddHours(+2)
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }

                Output.WriteToFile(ex.Message, true);                                
            }
            return desObjAll;
        }

        public T stringToGenericObject<T>(string jsonFile)
        {
            T desObjAll = new JavaScriptSerializer().Deserialize<T>(jsonFile);

            return desObjAll;
        }

        public void createJsonFile(string Path, string jsonData)
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.Write(jsonData);

                MessageBox.Show("Δημιουργήθηκε το αρχείο: [" + Path + "]");
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

        public string createDefaultJsonFileInSelectedFolder(string jsonData)
        {
            string filename = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                filename = fbd.SelectedPath;
                filename += "\\instId_datetime.json";

                createJsonFile(filename, jsonData);
            }

            return filename;
        }

        public int getInstId()
        {
            int ret = 0;

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
            string SelectSt = "SELECT MachineNo From [Inst] ";
            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["MachineNo"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public string createDefaultJsonFile(string jsonData)
        {
            string dt = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            int machineNo = getInstId(); 

            string filename = Application.StartupPath + "\\Exports\\PumpInfo_" + machineNo.ToString() + "_" + dt + ".json";

            createJsonFile(filename, jsonData);
            
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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
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
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<Brand> GetSqlBrandsList(bool autoMode = false)
        {
            List<Brand> ret = new List<Brand>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Brand] ORDER BY Name ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Brand() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                if (!autoMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }  
            }

            return ret;
        }

        public static List<PostalCode> GetSqlPostalCodesList()
        {
            List<PostalCode> ret = new List<PostalCode>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [TK] as PostalCode, [TK_NoSpace] as TK_NoSpace, [Geo_Nomos.Name] as Nomos, [Geo_Perioxh.Name] as Perioxi FROM [PumpInfo].[dbo].[V_All_TK] ORDER BY [TK_NoSpace] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new PostalCode() { TK = reader["PostalCode"].ToString(), TK_NoSpace = reader["TK_NoSpace"].ToString(), Nomos = reader["Nomos"].ToString(), Perioxi = reader["Perioxi"].ToString() });
                }
                reader.Close();
                sqlConn.Close();
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

        public static List<ComboboxItem> GetPostalCodesComboboxItemsList(List<PostalCode> PostalCodes)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (PostalCode pk in PostalCodes)
            {
                ret.Add(new ComboboxItem() { Value = pk, Text = pk.TK });
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

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
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
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<Product> GetProductsList(int VehicleNo)
        {
            List<Product> ret = new List<Product>();

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
            string SelectSt = "SELECT P.Id, P.Name FROM [Product] P LEFT OUTER JOIN [Vehicles] V ON P.ProductGroupId = V.ProductGroupId WHERE V.Id = @VehicleNo";
            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                cmd.Parameters.AddWithValue("@VehicleNo", VehicleNo);

                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Product() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<Product> GetSqlProductsList(bool autoMode = false)
        {
            List<Product> ret = new List<Product>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Id, Name FROM [dbo].[Product] ORDER BY Name ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Product() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                if (!autoMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
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

        public static List<Vehicle> GetSqlVehiclesList()
        {
            List<Vehicle> ret = new List<Vehicle>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT V.Id, P.Name, V.Consumption FROM [dbo].[Vehicles] V LEFT OUTER JOIN [dbo].[ProductGroup] P ON V.ProductGroupId = P.Id ORDER BY V.Id ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new Vehicle() { Id = Convert.ToInt32(reader["Id"].ToString()), ProductGroupName = reader["Name"].ToString(), Consumption = Convert.ToInt32(reader["Consumption"].ToString()) });
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<ComboboxItem> GetVehiclesComboboxItemsList(List<Vehicle> Vehicles)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (Vehicle v in Vehicles)
            {
                ret.Add(new ComboboxItem() { Value = v, Text = v.Id.ToString() + ". " + v.ProductGroupName });
            }

            return ret;
        }

        public static Vehicle getComboboxItem_Vehicle(ComboBox cb)
        {
            Vehicle ret = ((Vehicle)((ComboboxItem)cb.SelectedItem).Value);

            return ret;
        }

        public static List<int> GetSqlVehicleTraceYearList(int VehicleNo)
        {
            List<int> ret = new List<int>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT DISTINCT DtYear FROM [dbo].[vehicleTrace] WHERE DtMonth > 0 and VehicleNo = @VehicleNo ORDER BY DtYear DESC ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                cmd.Parameters.AddWithValue("@VehicleNo", VehicleNo);
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add( Convert.ToInt32(reader["DtYear"].ToString()) );
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<ComboboxItem> GetVehicleTraceYearsComboboxItemsList(List<int> VehicleTraceYears)
        {
            List<ComboboxItem> ret = new List<ComboboxItem>();

            foreach (int vty in VehicleTraceYears)
            {
                ret.Add(new ComboboxItem() { Value = vty, Text = vty.ToString() });
            }

            return ret;
        }

        public static int getComboboxItem_VehicleTraceYear(ComboBox cb)
        {
            int ret = ((int)((ComboboxItem)cb.SelectedItem).Value);

            return ret;
        }

        public bool InsertImportedFileIntoTable(string fileName, byte[] fileBytes, RowsCounter rowsCounter, bool manually) 
        {
            bool ret = false;

            if (fileName == null)
            {
                Output.WriteToFile("Empty File Name.", true);
                return ret;
            }

            if (fileBytes == null)
            {
                Output.WriteToFile("Empty File Bytes.", true);
                return ret;
            }

            if (fileName.Trim().Length > 0 && fileBytes.Length > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "INSERT INTO [dbo].[ImportedGroup] (Dt, FileName, FileCont, Manually, FileRows, FileAccRows, FileNAccRows, ToSaveRows, " +
                                                                  "ToSaveAccRows, ToSaveNAccRows, VehicleTraceRows, StationsUpdRows) " +
                               "VALUES (getdate(), @FileName, @FileCont, @Manually, @FileRows, @FileAccRows, @FileNAccRows, @ToSaveRows, " +
                                       "@ToSaveAccRows, @ToSaveNAccRows, @VehicleTraceRows, @StationsUpdRows) ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@FileName", fileName); 
                    cmd.Parameters.Add("@FileCont", SqlDbType.VarBinary).Value = fileBytes;
                    cmd.Parameters.AddWithValue("@Manually", Convert.ToInt32(manually));
                    cmd.Parameters.AddWithValue("@FileRows", Convert.ToInt32(rowsCounter.fileRows));
                    cmd.Parameters.AddWithValue("@FileAccRows", Convert.ToInt32(rowsCounter.fileAccRows));
                    cmd.Parameters.AddWithValue("@FileNAccRows", Convert.ToInt32(rowsCounter.fileNAccRows));
                    cmd.Parameters.AddWithValue("@ToSaveRows", Convert.ToInt32(rowsCounter.toSaveRows));
                    cmd.Parameters.AddWithValue("@ToSaveAccRows", Convert.ToInt32(rowsCounter.toSaveAccRows));
                    cmd.Parameters.AddWithValue("@ToSaveNAccRows", Convert.ToInt32(rowsCounter.toSaveNAccRows));
                    cmd.Parameters.AddWithValue("@VehicleTraceRows", Convert.ToInt32(rowsCounter.vehicleTraceRows));
                    cmd.Parameters.AddWithValue("@StationsUpdRows", Convert.ToInt32(rowsCounter.stationsUpdRows));

                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception ex)
                {
                    if (!automaticMode)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                    }

                    Output.WriteToFile("(" + fileName + " ) " + ex.Message, true);
                }
            }

            return ret;
        }


        public int getMaxImportedGroupId(string fileName)
        {
            int ret = -1;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT max(Id) as Id FROM [dbo].[ImportedGroup] WHERE FileName = @FileName ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);

            cmd.Parameters.AddWithValue("@FileName", fileName);

            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
                
                Output.WriteToFile(ex.Message, true);
            }

            return ret;
        }


        public bool update_ImportedGroup_Table(int Id)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string UpdSt = "UPDATE [dbo].[ImportedGroup] SET SUCCESS = 1 WHERE Id = @Id";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", Id);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
                
                Output.WriteToFile(ex.Message, true);
            }

            sqlConn.Close();

            return ret;
        }

        public bool update_ImportedGroup_Counters(int Id, RowsCounter rowsCounter)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string UpdSt = "UPDATE [dbo].[ImportedGroup] " +
                "SET FileRows = @FileRows, FileAccRows = @FileAccRows, FileNAccRows = @FileNAccRows, " +
                "ToSaveRows = @ToSaveRows, ToSaveAccRows = @ToSaveAccRows, ToSaveNAccRows = @ToSaveNAccRows, " +
                "VehicleTraceRows = @VehicleTraceRows " + 
                "WHERE Id = @Id";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@FileRows", Convert.ToInt32(rowsCounter.fileRows));
                cmd.Parameters.AddWithValue("@FileAccRows", Convert.ToInt32(rowsCounter.fileAccRows));
                cmd.Parameters.AddWithValue("@FileNAccRows", Convert.ToInt32(rowsCounter.fileNAccRows));
                cmd.Parameters.AddWithValue("@ToSaveRows", Convert.ToInt32(rowsCounter.toSaveRows));
                cmd.Parameters.AddWithValue("@ToSaveAccRows", Convert.ToInt32(rowsCounter.toSaveAccRows));
                cmd.Parameters.AddWithValue("@ToSaveNAccRows", Convert.ToInt32(rowsCounter.toSaveNAccRows));
                cmd.Parameters.AddWithValue("@VehicleTraceRows", Convert.ToInt32(rowsCounter.vehicleTraceRows));

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ret = true;
            }
            catch (Exception ex)
            {
                if (!automaticMode)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
                
                Output.WriteToFile(ex.Message, true);
            }

            sqlConn.Close();

            return ret;
        }

        public bool InsertInto_VehicleTrace(ImpData obj, int Km)
        {
            bool ret = false;

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);

            string InsSt = "INSERT INTO [VehicleTrace] (ProcessedGroupId, MachineNo, VehicleNo, DtYear, DtMonth, Km, InsDt) VALUES " +
                           "(@ProcessedGroupId, @MachineNo, @VehicleNo, @DtYear, @DtMonth, @Km, datetime('now', 'localtime'))";
            try
            {
                sqlConn.Open();
                SQLiteCommand cmd = new SQLiteCommand(InsSt, sqlConn);

                cmd.Parameters.AddWithValue("@ProcessedGroupId", obj.processedGroupId);
                cmd.Parameters.AddWithValue("@MachineNo", obj.machineNo);
                cmd.Parameters.AddWithValue("@VehicleNo", obj.vehicleNo);
                cmd.Parameters.AddWithValue("@DtYear", obj.datetime.Year);
                cmd.Parameters.AddWithValue("@DtMonth", obj.datetime.Month);
                cmd.Parameters.AddWithValue("@Km", Km);               

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


        public List<Consumption> getVehicleTraceData(int vehicleNo, int year, int month)
        {
            List<Consumption> ret = new List<Consumption>();

            string yyyymm = year.ToString();
            if (month < 10)
            {
                yyyymm += "0";
            }
            yyyymm += month.ToString();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            //string SelectSt = "select Dt, DtYear, DtMonth, Km, Vol, RealVol from " +
            //                  "( " +
            //                  "SELECT top(1) P.Dt, DtYear, DtMonth, Km, 0 as Vol, 0 as RealVol  " +
            //                  "FROM [dbo].[vehicleTrace] V left outer join " +
            //                  "     [dbo].[ProcessedGroup] P on V.ProcessedGroupId = P.Id left outer join " +
            //                  "     [dbo].[receiptData] R on V.ProcessedGroupId = R.ProcessedGroupId and R.Accepted = 1 left outer join " +
            //                  "     [dbo].[extraData] E on R.Id = E.ReceiptDataId " +
            //                  "WHERE V.VehicleNo = @VehicleNo and convert(varchar, DtYear) + case when DtMonth < 10 then '0' + convert(varchar, DtMonth) else convert(varchar, DtMonth) end < @yyyymm " +
            //                  "ORDER BY convert(varchar, DtYear) + case when DtMonth < 10 then '0' + convert(varchar, DtMonth) else convert(varchar, DtMonth) end desc, Km desc " +
            //                  ")w " +
            //                  "union " +
            //                  "select * from  " +
            //                  "( " +
            //                  "SELECT top(1) P.Dt, DtYear, DtMonth, Km, sum(R.Volume) as Vol, sum(E.PumpVolume) as RealVol " +
            //                  "FROM [dbo].[vehicleTrace] V left outer join " +
            //                  "     [dbo].[ProcessedGroup] P on V.ProcessedGroupId = P.Id left outer join " +
            //                  "     [dbo].[receiptData] R on V.ProcessedGroupId = R.ProcessedGroupId and R.Accepted = 1 left outer join " +
            //                  "     [dbo].[extraData] E on R.Id = E.ReceiptDataId " +
            //                  "WHERE V.VehicleNo = @VehicleNo and DtYear = @year and DtMonth = @month " +
            //                  "GROUP BY P.Dt, DtYear, DtMonth, Km " +
            //                  "ORDER BY Km desc " +
            //                  ")q " +
            //                  "order by Km asc ";

            string SelectSt = "select Dt, DtYear, DtMonth, Km " +
                              "from ( " +

                              "SELECT top(1) " +
                              " (select max(Dt) from [PumpInfo].[dbo].[receiptData] R where R.accepted = 1 and R.ProcessedGroupId = V.ProcessedGroupId and " +
                              "  R.VehicleNo = V.VehicleNo and R.MachineNo = V.MachineNo and year(R.dt) = V.DtYear and month(R.dt) = V.DtMonth) as Dt, " +
                              " DtYear, DtMonth, Km " +
                              "FROM [dbo].[vehicleTrace] V " +
                              "WHERE V.VehicleNo = @VehicleNo and convert(varchar, DtYear) + case when DtMonth < 10 then '0' + convert(varchar, DtMonth) else convert(varchar, DtMonth) end < @yyyymm " +
                              "ORDER BY convert(varchar, DtYear) + case when DtMonth < 10 then '0' + convert(varchar, DtMonth) else convert(varchar, DtMonth) end desc, Km desc " +

                              ")w " +

                              "union " +

                              "select Dt, DtYear, DtMonth, Km " +
                              "from ( " +

                              "SELECT top(1) " +
                              " (select max(Dt) from [PumpInfo].[dbo].[receiptData] R where R.accepted = 1 and R.VehicleNo = V.VehicleNo and " +
                              "  year(R.dt) = V.DtYear and month(R.dt) = V.DtMonth) as Dt, " +
                              " DtYear, DtMonth, Km " +
                              "FROM [dbo].[vehicleTrace] V " +
                              "WHERE V.VehicleNo = @VehicleNo and DtYear = @year and DtMonth = @month " +
                              "ORDER BY Km desc " +

                              ")q " +
                              "order by Km asc ";

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);

            cmd.Parameters.AddWithValue("@VehicleNo", vehicleNo);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@yyyymm", yyyymm);

            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //ret.Add(new string[] { reader["Dt"].ToString(), Convert.ToInt32(reader["DtYear"].ToString()), Convert.ToInt32(reader["DtMonth"].ToString()),
                    //    Convert.ToInt32(reader["Km"].ToString()), Convert.ToDouble(reader["Vol"].ToString()), Convert.ToDouble(reader["RealVol"].ToString()) });

                    //ret.Add(new string[] { reader["Dt"].ToString(), reader["DtYear"].ToString(), reader["DtMonth"].ToString(),
                    //    reader["Km"].ToString(), reader["Vol"].ToString(), reader["RealVol"].ToString() });

                    ret.Add(new Consumption()
                    {
                        MaxDt = Convert.ToDateTime(reader["Dt"].ToString()),
                        Year = Convert.ToInt32(reader["DtYear"].ToString()),
                        Month = Convert.ToInt32(reader["DtMonth"].ToString()),
                        Km = Convert.ToInt32(reader["Km"].ToString())
                    });

                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            if (ret.Count <= 1)
            {
                return ret;
            }

            SqlConnection sqlConn2 = new SqlConnection(SqlDBInfo.connectionString);
            SelectSt = "SELECT min(R.Dt) as MinDt, max(R.Dt) as MaxDt, sum(R.Volume) as ControllerVolume, sum(E.PumpVolume) as PumpVolume " +
                       "FROM receiptData R left outer join extraData E on R.Id = E.receiptDataId " +
                       "WHERE year(R.Dt) = @year and month(R.Dt) = @month and R.Accepted = 1 and VehicleNo = @VehicleNo ";

            SqlCommand cmd2 = new SqlCommand(SelectSt, sqlConn2);

            cmd2.Parameters.AddWithValue("@VehicleNo", vehicleNo);
            cmd2.Parameters.AddWithValue("@year", year);
            cmd2.Parameters.AddWithValue("@month", month);

            try
            {
                sqlConn2.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    ret[1].MinDt = Convert.ToDateTime(reader2["MinDt"].ToString());
                    ret[1].PumpVolume = Convert.ToDouble(reader2["PumpVolume"].ToString());
                    ret[1].ControllerVolume = Convert.ToDouble(reader2["ControllerVolume"].ToString());
                }
                reader2.Close();
                sqlConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public bool update_extraData_geostationId(int ExtraDataId, int GeostationId)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string UpdSt = "UPDATE [dbo].[extraData] SET geostationId = @geostationId WHERE Id = @Id";

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(UpdSt, sqlConn);

                cmd.Parameters.AddWithValue("@geostationId", GeostationId);
                cmd.Parameters.AddWithValue("@Id", ExtraDataId);
                
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

        public static Coordinates GetGeostationLatLong(int GeostationId)
        {
            Coordinates ret = new Coordinates();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT Latitude, Longitude FROM [dbo].[Station_View] WHERE id = " + GeostationId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret.latitude = reader["Latitude"].ToString();
                    ret.longitude = reader["Longitude"].ToString();
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static int GetStation_GeoDataNextId()
        {
            int ret = 1;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT isnull(max(id), 0) + 1 as NextId from [dbo].[Station_GeoData] ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["NextId"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static int GetStationCompaniesId(int BrandId)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT isnull(Id, 0) as Id FROM [dbo].[Station_Companies] WHERE Other_Id = " + BrandId.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToInt32(reader["Id"].ToString());
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static string GetSplittedField(string field, char[] separator, int splittedFieldNo) //splittedFieldNo: ZeroBased
        {
            string ret = "";
                        
            string[] SplittedFieldArray = field.Split(separator);

            if (splittedFieldNo < SplittedFieldArray.Length)
            {
                ret = SplittedFieldArray[splittedFieldNo];
            }
            
            return ret;
        }



        /*
        public static void Migration()
        {
            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);

            string st = " select DENSE_RANK() OVER (ORDER BY Dt asc, CooLong, CooLat, [realweight]) AS Id " + //ClientId, " + //--ReceiptDataId --ClientId --ClientReceiptId
            "vehicle as VehicleNo, Dt,  isnull(CooLong, '00.0000') as CooLong, isnull(CooLat, '00.0000') as CooLat, " + //--CooLong --CooLat
            "isnull(RealWeight, 0.0) as [Weight], isnull(RealTemp, 0.0) as Temp, isnull(RealDensity, 0.0) as Density, RealVolume as Volume, " +
            //-----
            "BrandId, Dealer, [Address], ProductId, Pump, Volume as PumpVolume, Remarks, GeostationId " +
            "from [dbo].[MigrationTable] ";
            
            SqlCommand cmd = new SqlCommand(st, sqlConn);

            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //ins1
                    SqlConnection sqlConn1 = new SqlConnection(SqlDBInfo.connectionString);
                    string InsSt1 = "INSERT INTO [dbo].[receiptData] (ClientId, VehicleNo, Dt, CooLong, CooLat, Weight, Temp, Density, Volume, Accepted, ProcessedGroupId, ExportedGroupId, ImportedGroupId, MachineNo, InsDate) " +
                           " VALUES (@ClientId, @VehicleNo, @Dt, @CooLong, @CooLat, @Weight, @Temp, @Density, @Volume, 1, 0, 0, 0, 0, '2018-01-01 00:00:00.000' ) ";
                    
                    //ins2
                    SqlConnection sqlConn2 = new SqlConnection(SqlDBInfo.connectionString);
                    string InsSt2 = "INSERT INTO [dbo].[extraData] (ReceiptDataId, ClientId, ClientReceiptDataId, BrandId, Dealer, Address, ProductId, Pump, PumpVolume, SampleNo, Remarks, GeostationId, CooLong, CooLat) " +
                        " VALUES (@ReceiptDataId, @ClientId, @ClientReceiptDataId, @BrandId, @Dealer, @Address, @ProductId, @Pump, @PumpVolume, 0, @Remarks, @GeostationId, @CooLong, @CooLat ) ";

                    try
                    {
                        sqlConn1.Open();
                        SqlCommand cmd1 = new SqlCommand(InsSt1, sqlConn1);
                        sqlConn2.Open();
                        SqlCommand cmd2 = new SqlCommand(InsSt2, sqlConn2);

                        //cmd1.Parameters.AddWithValue("@ClientId", Convert.ToInt32(reader["Id"].ToString()));
                        //cmd1.Parameters.AddWithValue("@VehicleNo", obj.vehicleNo);
                        //cmd1.Parameters.AddWithValue("@Dt", obj.strDt); //????????
                        //cmd1.Parameters.AddWithValue("@CooLong", obj.coordinates.longitude);
                        //cmd1.Parameters.AddWithValue("@CooLat", obj.coordinates.latitude);
                        //cmd1.Parameters.AddWithValue("@Weight", obj.weight);
                        //cmd1.Parameters.AddWithValue("@Temp", obj.temp);
                        //cmd1.Parameters.AddWithValue("@Density", obj.density);
                        //cmd1.Parameters.AddWithValue("@Volume", obj.volume);
                        //cmd1.Parameters.AddWithValue("@Accepted", obj.accepted);
                        //cmd1.Parameters.AddWithValue("@ProcessedGroupId", obj.processedGroupId);
                        //cmd1.Parameters.AddWithValue("@ExportedGroupId", obj.exportedGroupId);
                        //cmd1.Parameters.AddWithValue("@ImportedGroupId", ImportedGroupId);
                        //cmd1.Parameters.AddWithValue("@MachineNo", obj.machineNo);
                        ///////////////////////////////////////////////////////////////
                        //cmd2Parameters.AddWithValue("@ReceiptDataId", Convert.ToInt32(reader["Id"].ToString()));
                        //cmd2Parameters.AddWithValue("@ClientId", Convert.ToInt32(reader["Id"].ToString()));
                        //cmd2Parameters.AddWithValue("@ClientReceiptDataId", Convert.ToInt32(reader["Id"].ToString()));
                        //cmd2Parameters.AddWithValue("@BrandId", obj.brand.Id);
                        //cmd2Parameters.AddWithValue("@Dealer", obj.dealer);
                        //cmd2Parameters.AddWithValue("@Address", obj.address);
                        //cmd2Parameters.AddWithValue("@ProductId", obj.product.Id);
                        //cmd2Parameters.AddWithValue("@Pump", obj.pump);
                        //cmd2Parameters.AddWithValue("@PumpVolume", obj.pumpVolume);
                        //cmd2Parameters.AddWithValue("@SampleNo", obj.sampleNo);
                        //cmd2Parameters.AddWithValue("@Remarks", obj.remarks);
                        //cmd2Parameters.AddWithValue("@GeostationId", obj.geostationId);
                        //cmd2Parameters.AddWithValue("@CooLong", obj.realCoordinates.longitude);
                        //cmd2.Parameters.AddWithValue("@CooLat", obj.realCoordinates.latitude);

                        cmd1.CommandType = CommandType.Text;
                        cmd1.ExecuteNonQuery();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                    }

                    sqlConn1.Close();
                    sqlConn2.Close();
                }

                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }
        */


        public static List<ImpData> ArchivedData()
        {
            List<ImpData> ret = new List<ImpData>();

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);

            string SelectSt = "SELECT R.Id, R.Accepted, R.VehicleNo, datetime(R.Dt) as Dt, B.Name as Brand, E.Dealer, E.Address, " + 
            "ifnull(E.GeostationId,0) as GeostationId, P.Name as Product, " +
            "R.Weight, R.Temp, R.Density, R.Volume, E.Pump, ifnull(E.PumpVolume,0) as PumpVolume, ifnull(E.SampleNo,0) as SampleNo, E.Remarks " +
            "FROM receiptData R left outer join " +
            "extraData E on R.Id = E.ReceiptDataId left outer join " +
            "Brand B on E.BrandId = B.Id left outer join " +
            "Product P on E.ProductId = P.Id " +
            "ORDER BY R.Dt desc, R.Id ";

            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //ret.Add(new object[]
                    //{                        
                    //    Convert.ToInt32(reader["Id"].ToString()),
                    //    Convert.ToBoolean(Convert.ToInt32(reader["Accepted"].ToString())),
                    //    reader["VehicleNo"].ToString(),
                    //    Convert.ToDateTime(reader["Dt"].ToString()).ToString("dd.MM.yyyy HH:mm"),
                    //    reader["Brand"].ToString(),
                    //    reader["Dealer"].ToString(),
                    //    reader["Address"].ToString(),
                    //    Convert.ToInt32(reader["GeostationId"].ToString()),
                    //    reader["Product"].ToString(),
                    //    Convert.ToDouble(reader["Weight"].ToString()),
                    //    Convert.ToDouble(reader["Temp"].ToString()),
                    //    Convert.ToDouble(reader["Density"].ToString()),
                    //    Convert.ToDouble(reader["Volume"].ToString()),
                    //    reader["Pump"].ToString(),
                    //    Convert.ToDouble(reader["PumpVolume"].ToString()),
                    //    Convert.ToInt32(reader["SampleNo"].ToString()),
                    //    reader["Remarks"].ToString()
                    //});

                    ImpData objLine = new ImpData()
                    {
                        receiptDataId = Convert.ToInt32(reader["Id"].ToString()),
                        accepted = Convert.ToBoolean(Convert.ToInt32(reader["Accepted"].ToString())),
                        vehicleNo = Convert.ToInt32(reader["VehicleNo"].ToString()),
                        strDt = Convert.ToDateTime(reader["Dt"].ToString()).ToString("dd.MM.yyyy HH:mm"),
                        brand = new Brand() { Name = reader["Brand"].ToString() },
                        dealer = reader["Dealer"].ToString(),
                        address = reader["Address"].ToString(),
                        geostationId = Convert.ToInt32(reader["GeostationId"].ToString()),
                        product = new Product() { Name = reader["Product"].ToString() },
                        weight = Convert.ToDouble(reader["Weight"].ToString()),
                        temp = Convert.ToDouble(reader["Temp"].ToString()),
                        density = Convert.ToDouble(reader["Density"].ToString()),
                        volume = Convert.ToDouble(reader["Volume"].ToString()),
                        pump = reader["Pump"].ToString(),
                        pumpVolume = Convert.ToDouble(reader["PumpVolume"].ToString()),
                        sampleNo = Convert.ToInt32(reader["SampleNo"].ToString()),
                        remarks = reader["Remarks"].ToString(),

                        datetime = Convert.ToDateTime(reader["Dt"].ToString())
                    };

                    ret.Add(objLine);
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static List<ArchivedData> ArchivedSyncData()
        {
            List<ArchivedData> ret = new List<ArchivedData>();

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBArch.connectionString);

            string SelectSt = "SELECT VehicleNo, Product, Driver, datetime(Dt) as Dt, Brand, Dealer, Address, Weight, Temp, Density, Volume, " +
                "ifnull(PumpVolume,0) as PumpVolume, VolDiff, ifnull(GeostationId,0) as GeostationId, ifnull(SampleNo,0) as SampleNo, Remarks " +
                "FROM [Arch] ";

            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ArchivedData objLine = new ArchivedData
                    {
                        VehicleNo = Convert.ToInt32(reader["VehicleNo"].ToString()),
                        Product = reader["Product"].ToString(),
                        Driver = reader["Driver"].ToString(),
                        Dt = Convert.ToDateTime(reader["Dt"].ToString()),
                        Brand = reader["Brand"].ToString(),
                        Dealer = reader["Dealer"].ToString(),
                        Address = reader["Address"].ToString(),
                        Weight = Convert.ToDouble(reader["Weight"].ToString()),
                        Temp = Convert.ToDouble(reader["Temp"].ToString()),
                        Density = Convert.ToDouble(reader["Density"].ToString()),
                        Volume = Convert.ToDouble(reader["Volume"].ToString()),
                        PumpVolume = Convert.ToDouble(reader["PumpVolume"].ToString()),
                        VolDiff = Convert.ToDouble(reader["VolDiff"].ToString()),
                        GeostationId = Convert.ToInt32(reader["GeostationId"].ToString()),
                        SampleNo = Convert.ToInt32(reader["SampleNo"].ToString()),
                        Remarks = reader["Remarks"].ToString()
                    };

                    ret.Add(objLine);
                }
                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        public static bool insert_into_StationGeoData(Station_GeoData data)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Station_GeoData] (Id, Address, Address2, Address3, [Postal-Code], Country, Latitude, Longitude, Active) VALUES " +
                           "(@Id, @Address, @Address2, @Address3, @PostalCode, @Country, @Latitude, @Longitude, @Active) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@Id", data.Id);
                cmd.Parameters.AddWithValue("@Address", data.Address);
                cmd.Parameters.AddWithValue("@Address2", data.Address2);
                cmd.Parameters.AddWithValue("@Address3", data.Address3);
                cmd.Parameters.AddWithValue("@PostalCode", data.PostalCode);
                cmd.Parameters.AddWithValue("@Country", data.Country);
                cmd.Parameters.AddWithValue("@Latitude", data.Latitude); //.ToString().Replace(",", "."));
                cmd.Parameters.AddWithValue("@Longitude", data.Longitude); //.ToString().Replace(",", "."));
                cmd.Parameters.AddWithValue("@Active", data.Active);
                
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
            sqlConn.Close();

            return ret;
        }

        public static bool insert_into_StationTimeDependData(Station_TimeDependData data)
        {
            bool ret = false;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string InsSt = "INSERT INTO [dbo].[Station_TimeDependData] (Id, UpdDate, Current_Rec, Comp_Name, Company_Id) VALUES " +
                           "(@Id, getdate(), @Current_Rec, @Comp_Name, @Company_Id) ";
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                cmd.Parameters.AddWithValue("@Id", data.Id);
                cmd.Parameters.AddWithValue("@Current_Rec", data.Current_Rec);
                cmd.Parameters.AddWithValue("@Comp_Name", data.Comp_Name);
                cmd.Parameters.AddWithValue("@Company_Id", data.Company_Id);

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
            sqlConn.Close();

            return ret;
        }

        public List<Station_GeoData> GetDataFrom_Station_GeoData()
        {
            List<Station_GeoData> station_GeoData_List = new List<Station_GeoData>();

            SqlConnection sqlConn1 = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT id, Address, Address2, Address3, [Postal-Code] as PostalCode, Country, Latitude, Longitude, Active FROM [dbo].[Station_GeoData] ORDER BY id ";
            SqlCommand cmd1 = new SqlCommand(SelectSt, sqlConn1);
            try
            {
                sqlConn1.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    station_GeoData_List.Add(new Station_GeoData()
                    {
                        Id = Convert.ToInt32(reader1["id"].ToString()),
                        Address = reader1["Address"].ToString(),
                        Address2 = reader1["Address2"].ToString(),
                        Address3 = reader1["Address3"].ToString(),
                        PostalCode = reader1["PostalCode"].ToString(),
                        Country = reader1["Country"].ToString(),
                        Latitude = (float)Conversions.stringToDouble(reader1["Latitude"].ToString()),
                        Longitude = (float)Conversions.stringToDouble(reader1["Longitude"].ToString()),
                        Active = Convert.ToInt32(reader1["Active"].ToString())
                    });
                }
                reader1.Close();
                sqlConn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            return station_GeoData_List;
        }

        public List<Station_TimeDependData> GetDataFrom_Station_TimeDependData()
        {
            List<Station_TimeDependData> station_TimeDependData_List = new List<Station_TimeDependData>();

            SqlConnection sqlConn1 = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT id, Comp_Name, Company_id FROM [dbo].[Station_TimeDependData] WHERE Current_Rec = 1 ORDER BY id ";
            SqlCommand cmd1 = new SqlCommand(SelectSt, sqlConn1);
            try
            {
                sqlConn1.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    station_TimeDependData_List.Add(new Station_TimeDependData()
                    {
                         Id = Convert.ToInt32(reader1["id"].ToString()),
                         Current_Rec = 1,
                         Comp_Name = reader1["Comp_Name"].ToString(),
                         Company_Id = Convert.ToInt32(reader1["Company_id"].ToString())
                    });
                }
                reader1.Close();
                sqlConn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            return station_TimeDependData_List;
        }

        public List<ArchivedData> Get_Archived_Data()
        {
            List<ArchivedData> ArchivedData_List = new List<ArchivedData>();

            SqlConnection sqlConn1 = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT R.VehicleNo, P.Name as Product, case when R.MachineNo = 1 then 'Βασίλης' when R.MachineNo = 2 then 'Ιωσήφ' else 'Auto' end as Driver, " +
                "R.Dt, B.Name as Brand, E.Dealer, E.Address, isnull(R.Weight, 0) as Weight, isnull(R.Temp, 0) as Temp, isnull(R.Density, 0) as Density, isnull(R.Volume, 0) as Volume, isnull(E.PumpVolume, 0) as PumpVolume, " +
                "convert(decimal(18, 5), round((isnull(R.Volume, 0) - isnull(E.PumpVolume, 0)) / isnull(R.Volume, 0) * 100.0, 5)) as VolDiff, isnull(E.GeostationId, 0) as GeostationId, isnull(E.SampleNo, 0) as SampleNo, E.Remarks " +
                "FROM receiptData R left outer join extraData E on R.Id = E.receiptDataId left outer join Brand B on B.Id = E.BrandId left outer join  Product P on P.Id = E.ProductId " +
                "WHERE R.Accepted = 1 ORDER BY Dt desc ";
            SqlCommand cmd1 = new SqlCommand(SelectSt, sqlConn1);

            try
            {
                sqlConn1.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    ArchivedData_List.Add(new ArchivedData()
                    {
                        VehicleNo = Convert.ToInt32(reader1["VehicleNo"].ToString()),
                        Product = reader1["Product"].ToString(),
                        Driver = reader1["Driver"].ToString(),
                        Dt = Convert.ToDateTime(reader1["Dt"].ToString()),
                        Brand = reader1["Brand"].ToString(),
                        Dealer = reader1["Dealer"].ToString(),
                        Address = reader1["Address"].ToString(),
                        Weight = Convert.ToDouble(reader1["Weight"].ToString()),
                        Temp = Convert.ToDouble(reader1["Temp"].ToString()),
                        Density = Convert.ToDouble(reader1["Density"].ToString()),
                        Volume = Convert.ToDouble(reader1["Volume"].ToString()),
                        PumpVolume = Convert.ToDouble(reader1["PumpVolume"].ToString()),
                        VolDiff = Convert.ToDouble(reader1["VolDiff"].ToString()),
                        GeostationId = Convert.ToInt32(reader1["GeostationId"].ToString()),
                        SampleNo = Convert.ToInt32(reader1["SampleNo"].ToString()),
                        Remarks = reader1["Remarks"].ToString()
                    });
                }
                reader1.Close();
                sqlConn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ArchivedData_List;
        }

        bool DataTo_Station_GeoData(string dbFile, List<Station_GeoData> station_GeoData_List)
        {
            bool ret = true;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            SQLiteTransaction tran = null;
            try
            {
                sqlConn.Open();

                SQLiteCommand cmd = new SQLiteCommand(sqlConn);
                tran = sqlConn.BeginTransaction();
                cmd.Transaction = tran;

                foreach (Station_GeoData station in station_GeoData_List)
                {
                    string InsSt = "INSERT INTO [Station_GeoData] (id, Address, Address2, Address3, [Postal-Code], Country, Latitude, Longitude, Active) VALUES " +
                           "(@id, @Address, @Address2, @Address3, @PostalCode, @Country, @Latitude, @Longitude, @Active) ";

                    cmd.CommandText = InsSt;
                    //SQLiteCommand cmd = new SQLiteCommand(InsSt, sqlConn);

                    cmd.Parameters.AddWithValue("@id", station.Id);
                    cmd.Parameters.AddWithValue("@Address", station.Address);
                    cmd.Parameters.AddWithValue("@Address2", station.Address2);
                    cmd.Parameters.AddWithValue("@Address3", station.Address3);
                    cmd.Parameters.AddWithValue("@PostalCode", station.PostalCode);
                    cmd.Parameters.AddWithValue("@Country", station.Country);
                    cmd.Parameters.AddWithValue("@Latitude", station.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", station.Longitude);
                    cmd.Parameters.AddWithValue("@Active", station.Active);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                ret = false;
            }

            sqlConn.Close();

            return ret;
        }

        bool DataTo_Station_TimeDependData(string dbFile, List<Station_TimeDependData> station_TimeDependData_List)
        {
            bool ret = true;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            SQLiteTransaction tran = null;
            try
            {
                sqlConn.Open();

                SQLiteCommand cmd = new SQLiteCommand(sqlConn);
                tran = sqlConn.BeginTransaction();
                cmd.Transaction = tran;

                foreach (Station_TimeDependData station in station_TimeDependData_List)
                {
                    string InsSt = "INSERT INTO [Station_TimeDependData] (id, UpdDate, Current_Rec, Comp_Name, Company_id) VALUES " +
                           "(@id, @UpdDate, @Current_Rec, @Comp_Name, @Company_id) ";

                    cmd.CommandText = InsSt;
                    //SQLiteCommand cmd = new SQLiteCommand(InsSt, sqlConn);

                    cmd.Parameters.AddWithValue("@id", station.Id);
                    cmd.Parameters.AddWithValue("@UpdDate", "2018-01-01 00:00:00.000");
                    cmd.Parameters.AddWithValue("@Current_Rec", station.Current_Rec);
                    cmd.Parameters.AddWithValue("@Comp_Name", station.Comp_Name);
                    cmd.Parameters.AddWithValue("@Company_id", station.Company_Id);                    

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                ret = false;
            }

            sqlConn.Close();

            return ret;
        }

        bool DataTo_Archived(string dbFile, List<ArchivedData> ArchivedData_List)
        {
            bool ret = true;

            SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            SQLiteTransaction tran = null;
            try
            {
                sqlConn.Open();

                SQLiteCommand cmd = new SQLiteCommand(sqlConn);
                tran = sqlConn.BeginTransaction();
                cmd.Transaction = tran;

                foreach (ArchivedData thisRec in ArchivedData_List)
                {
                    string InsSt = "INSERT INTO [Arch] (VehicleNo, Product, Driver, Dt, Brand, Dealer, Address, Weight, Temp, Density, Volume, PumpVolume, VolDiff, GeostationId, SampleNo, Remarks) VALUES " +
                           "(@VehicleNo, @Product, @Driver, @Dt, @Brand, @Dealer, @Address, @Weight, @Temp, @Density, @Volume, @PumpVolume, @VolDiff, @GeostationId, @SampleNo, @Remarks) ";

                    cmd.CommandText = InsSt;
                    //SQLiteCommand cmd = new SQLiteCommand(InsSt, sqlConn);

                    cmd.Parameters.AddWithValue("@VehicleNo", thisRec.VehicleNo);
                    cmd.Parameters.AddWithValue("@Product", thisRec.Product);
                    cmd.Parameters.AddWithValue("@Driver", thisRec.Driver);
                    cmd.Parameters.AddWithValue("@Dt", thisRec.Dt);
                    cmd.Parameters.AddWithValue("@Brand", thisRec.Brand);
                    cmd.Parameters.AddWithValue("@Dealer", thisRec.Dealer);
                    cmd.Parameters.AddWithValue("@Address", thisRec.Address);
                    cmd.Parameters.AddWithValue("@Weight", thisRec.Weight);
                    cmd.Parameters.AddWithValue("@Temp", thisRec.Temp);
                    cmd.Parameters.AddWithValue("@Density", thisRec.Density);
                    cmd.Parameters.AddWithValue("@Volume", thisRec.Volume);
                    cmd.Parameters.AddWithValue("@PumpVolume", thisRec.PumpVolume);
                    cmd.Parameters.AddWithValue("@VolDiff", thisRec.VolDiff);
                    cmd.Parameters.AddWithValue("@GeostationId", thisRec.GeostationId);
                    cmd.Parameters.AddWithValue("@SampleNo", thisRec.SampleNo);
                    cmd.Parameters.AddWithValue("@Remarks", thisRec.Remarks);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                ret = false;
            }

            sqlConn.Close();

            return ret;
        }

        public void ExportDB_Geostation()
        {
            //------------------- copy paste empty db 
            string Source = Application.StartupPath + "\\EmptyDBs\\StationGeoData.db";
            string Destination = Application.StartupPath + "\\ExportedDBs\\StationGeoData.db";
            try
            {
                System.IO.File.Copy(Source, Destination, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //------------------- select from sql server

            List<Station_GeoData> station_GeoData_List = GetDataFrom_Station_GeoData();

            List<Station_TimeDependData> station_TimeDependData_List = GetDataFrom_Station_TimeDependData();

            //------------------- insert into sqlite

            bool Step1 = DataTo_Station_GeoData(Destination, station_GeoData_List);

            bool Step2 = DataTo_Station_TimeDependData(Destination, station_TimeDependData_List);

            if (Step1 == true && Step2 == true)
            {
                MessageBox.Show("Η βάση των πρατηρίων δημιουργήθηκε επιτυχώς [" + Destination + "].");
            }
            else
            {
                MessageBox.Show("Η διαδικασία ολοκληρώθηκε με σφάλματα!\r\nΠαρακαλώ προσπαθήστε ξανά...");
            }

        }

        public void ExportDB_Archived()
        {
            //------------------- copy paste empty db 
            string Source = Application.StartupPath + "\\EmptyDBs\\Archived.db";
            string Destination = Application.StartupPath + "\\ExportedDBs\\Archived.db";
            try
            {
                System.IO.File.Copy(Source, Destination, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //------------------- select from sql server

            List<ArchivedData> ArchivedData_List = Get_Archived_Data();

            //------------------- insert into sqlite

            bool Step1 = DataTo_Archived(Destination, ArchivedData_List);

            if (Step1 == true)
            {
                MessageBox.Show("Η βάση των επισκέψεων δημιουργήθηκε επιτυχώς [" + Destination + "].");
            }
            else
            {
                MessageBox.Show("Η διαδικασία ολοκληρώθηκε με σφάλματα!\r\nΠαρακαλώ προσπαθήστε ξανά...");
            }

        }

    }
    

    public static class SQLiteDBInfo
    {
        static SQLiteDBInfo()
        {
            string dbFile = Application.StartupPath + "\\DBs\\PumpInfo.db";
            connectionString = "Data Source=" + dbFile + ";Version=3;";
        }

        //public static string dbFile { get; set; }
        public static string connectionString { get; set; }
    }

    public static class SQLiteDBMap
    {
        static SQLiteDBMap()
        {
            //string dbFile = Application.StartupPath + "\\DBs\\Stationsdb.db";
            string dbFile = Application.StartupPath + "\\DBs\\StationGeoData.db";
            connectionString = "Data Source=" + dbFile + ";Version=3;";
        }

        //public static string dbFile { get; set; }
        public static string connectionString { get; set; }
    }

    public static class SQLiteDBArch
    {
        static SQLiteDBArch()
        {
            //string dbFile = Application.StartupPath + "\\DBs\\Stationsdb.db";
            string dbFile = Application.StartupPath + "\\DBs\\Archived.db";
            connectionString = "Data Source=" + dbFile + ";Version=3;";
        }

        //public static string dbFile { get; set; }
        public static string connectionString { get; set; }
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

    public static class MapsApi
    {
        static MapsApi()
        {
            key = "AIzaSyCxAKDi4ZgokHWCYK_5sQ8Dg-nlcLT2myo";
        }
        public static string key { get; set; }
    }

    public static class NetworkConnections
    {
        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        System.IO.Stream stream = client.OpenRead("http://clients3.google.com/generate_204");
                        //var content = client.DownloadString("http://clients3.google.com/generate_204");

                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
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

        public static List<object[]> ImpDataListToGridViewRowList(List<ImpData> objList, bool extraCalcColumns = false)
        {
            List<object[]> ret = new List<object[]>();

            foreach (ImpData thisObj in objList)
            {
                if (extraCalcColumns)
                {
                    ret.Add(ImpDataToGridViewRow(thisObj, extraCalcColumns));//
                }
                else
                {
                    ret.Add(ImpDataToGridViewRow(thisObj));
                }
            }

            return ret;
        }

        public static List<object[]> DBDataToGridViewRowList(List<ImpData> objList)
        {
            List<object[]> ret = new List<object[]>();

            foreach (ImpData thisObj in objList)
            {
                ret.Add(DBDataToGridViewRow(thisObj));
            }

            return ret;
        }

        public static object[] DBDataToGridViewRow(ImpData obj)
        {
            object[] ret = new object[] { obj.receiptDataId, obj.extraDataId, obj.accepted, obj.vehicleNo, obj.datetime.ToString("dd.MM.yyyy"),
                                          obj.time, obj.coordinates.latitude, obj.coordinates.longitude, obj.weight,
                                          obj.temp, obj.density, obj.volume };

            double percDiff = 0.0;
            if (obj.volume > 0.0 && obj.pumpVolume > 0.0)
            {
                percDiff = (obj.volume - obj.pumpVolume) / obj.volume;
                percDiff = percDiff * 100.0; //??
                percDiff = Math.Round(percDiff, 5);
            }

            ret = new object[] { obj.receiptDataId, obj.extraDataId, obj.accepted, obj.vehicleNo, obj.datetime.ToString("dd.MM.yyyy"),
                                 obj.time, obj.coordinates.latitude, obj.coordinates.longitude, obj.weight,
                                 obj.temp, obj.density, obj.volume, percDiff,
                                 obj.brand.Name, obj.dealer, obj.address, obj.product.Name, obj.pump, obj.pumpVolume, obj.sampleNo, obj.remarks, obj.machineNo,
                                 obj.geostationId, obj.realCoordinates.latitude, obj.realCoordinates.longitude, obj.productGroup };

            return ret;
        }

        public static object[] ImpDataToGridViewRow(ImpData obj, bool extraCalcColumns = false)
        {
            //object[] ret = new object[] { false, obj.vehicleNo, obj.date, obj.time, ... };
            object[] ret = new object[] { obj.dataGridViewRowIndex, obj.accepted, obj.vehicleNo, obj.datetime.ToString("dd.MM.yyyy"),
                                          obj.time, obj.coordinates.latitude, obj.coordinates.longitude, obj.weight,
                                          obj.temp, obj.density, obj.volume };

            if (extraCalcColumns)
            {                
                double percDiff = 0.0;
                if (obj.volume > 0.0 && obj.pumpVolume > 0.0)
                {
                    percDiff = (obj.volume - obj.pumpVolume) / obj.volume;
                    percDiff = percDiff * 100.0; //??
                    percDiff = Math.Round(percDiff, 5);
                }

                ret = new object[] { obj.dataGridViewRowIndex, obj.accepted, obj.vehicleNo, obj.datetime.ToString("dd.MM.yyyy"),
                                     obj.time, obj.coordinates.latitude, obj.coordinates.longitude, obj.weight,
                                     obj.temp, obj.density, obj.volume, percDiff,
                                     obj.brand.Name, obj.dealer, obj.address, obj.product.Name, obj.pump, obj.pumpVolume, obj.sampleNo, obj.remarks, obj.machineNo,
                                     obj.geostationId, obj.realCoordinates.latitude, obj.realCoordinates.longitude };
            }
            
            return ret;
        }

        //public static List<object[]> ArchivedDataToObjectList(List<ImpData> objList)
        //{
        //    List<object[]> ret = new List<object[]>();

        //    foreach (ImpData thisObj in objList)
        //    {                
        //        ret.Add(new object[] { thisObj.receiptDataId, thisObj.accepted, thisObj.vehicleNo, thisObj.strDt,
        //            thisObj.brand.Name , thisObj.dealer, thisObj.address, thisObj.geostationId, thisObj.product.Name,
        //            thisObj.weight, thisObj.temp, thisObj.density, thisObj.volume, thisObj.pump, thisObj.pumpVolume,
        //            thisObj.sampleNo, thisObj.remarks });
        //    }

        //    return ret;
        //}

        public static List<object[]> ArchivedDataToObjectList(List<ArchivedData> objList)
        {
            List<object[]> ret = new List<object[]>();

            foreach (ArchivedData thisObj in objList)
            {
                ret.Add(new object[] { thisObj.VehicleNo, thisObj.Product, thisObj.Driver, thisObj.Dt.ToString("dd.MM.yyyy HH:mm"), thisObj.Brand, thisObj.Dealer, thisObj.Address,
                    thisObj.Weight, thisObj.Temp, thisObj.Density, thisObj.Volume, thisObj.PumpVolume, thisObj.VolDiff,
                    thisObj.GeostationId, thisObj.SampleNo, thisObj.Remarks });
            }

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

    public class Vehicle
    {
        public int Id { get; set; }
        public string ProductGroupName { get; set; }
        public int Consumption { get; set; }

        public Vehicle()
        {
        }
    }

    public static class Output
    {
        public static void WriteToFile(string text, bool error = false)
        {
            //string filename = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US"));

            using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Logs\\Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true))
            {
                if (text.IndexOf("STARTING...") >= 0)
                {
                    sw.WriteLine("");
                }

                if (error)
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyyMMdd_HHmmss") + " ERROR! " + text);
                }
                else
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyyMMdd_HHmmss") + " " + text);
                }

            }
        }
    }

    public static class Config
    {
        public static double MaxVolumeDiffPerc()
        {
            double ret = 0.0;

            SQLiteConnection sqlConn = new SQLiteConnection(SQLiteDBInfo.connectionString);
            string SelectSt = "SELECT RealValue FROM [Config] WHERE Name = 'Max_Volume_Diff_Perc'";
            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ret = Convert.ToDouble(reader["RealValue"].ToString());
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

    public class RowsCounter
    {
        public int fileRows { get; set; }
        public int toSaveRows { get; set; }
        public int fileAccRows { get; set; }
        public int fileNAccRows { get; set; }
        public int toSaveAccRows { get; set; }
        public int toSaveNAccRows { get; set; }
        public int vehicleTraceRows { get; set; }
        public int stationsUpdRows { get; set; }

        public void Clear()
        {
            fileRows = 0;
            toSaveRows = 0;
            fileAccRows = 0;
            fileNAccRows = 0;
            toSaveAccRows = 0;
            toSaveNAccRows = 0;
            vehicleTraceRows = 0;
            stationsUpdRows = 0;
        }
    }

    public class VehicleTrace
    {
        public VehicleTrace()
        {
        }

        public int Id { get; set; }
        public int ProcessedGroupId { get; set; }
        public int MachineNo { get; set; }
        public int VehicleNo { get; set; }
        public int DtYear { get; set; }
        public int DtMonth { get; set; }
        public int Km { get; set; }
        //public DateTime InsDt { get; set; }
    }

    public class Station
    {
        public int Id { get; set; }
        //public DateTime UpdDate { get; set; } //convert ????????
        public string UpdDate { get; set; }
        public bool Current_Rec { get; set; } //check 0,1 or 1,2 ????????
        public string Comp_Name { get; set; }
        public int Company_Id { get; set; }
    }

    public class ImpData_And_VehicleTrace
    {
        public List<ImpData> impData = new List<ImpData>();

        public List<VehicleTrace> vehicleTrace = new List<VehicleTrace>();

        public List<Station> stationData = new List<Station>();
    }

    public static class Conversions
    {
        public static double stringToDouble(string param)
        {
            double ret = 0;

            String DecSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (DecSep == ",")
            {
                param = param.Replace('.', ',');
            }
            else
            {
                param = param.Replace(',', '.');
            }

            ret = Convert.ToDouble(param);

            return ret;
        }
    }
    public class Station_GeoData
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Active { get; set; }
    }


    public class Station_TimeDependData
    {
        public int Id { get; set; }
        public int Current_Rec { get; set; }
        public string Comp_Name { get; set; }
        public int Company_Id { get; set; }
    }

    public class ArchivedData
    {
        public int VehicleNo { get; set; }
        public string Product { get; set; }
        public string Driver { get; set; }
        public DateTime Dt { get; set; }
        public string Brand { get; set; }
        public string Dealer { get; set; }
        public string Address { get; set; }
        public double Weight { get; set; }
        public double Temp { get; set; }
        public double Density { get; set; }
        public double Volume { get; set; }
        public double PumpVolume { get; set; }
        public double VolDiff { get; set; }
        public int GeostationId { get; set; }
        public int SampleNo { get; set; }
        public string Remarks { get; set; }
    }

    public class PostalCode
    {
        public string TK { get; set; }
        public string TK_NoSpace { get; set; }
        public string Nomos { get; set; }
        public string Perioxi { get; set; }

        public PostalCode()
        {
        }
    }

    public class Consumption
    {
        public DateTime MinDt { get; set; }
        public DateTime MaxDt { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Km { get; set; }
        public double ControllerVolume { get; set; }
        public double PumpVolume { get; set; }
    }

    //public class MapFormParams
    //{
    //    public double latitude { get; set; }
    //    public double longitude { get; set; }
    //    public int radius { get; set; }
    //    public string connectionString { get; set; }
    //    public string apiKey { get; set; }
    //    public bool existsInternetConnection { get; set; }        
    //}

    //public class MapFormGeoData
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public string address { get; set; }
    //}

    //--> Google Geocoding classes
    public class GeoCoding
    {
        public Results[] results;
        public string status;
    }

    public class Results
    {
        public Address_components[] address_components;
        public string formatted_address;
        public Geometry geometry;
        public string place_id;
        public string[] types;
    }

    public class Address_components
    {
        public string long_name;
        public string short_name;
        public string[] types;
    }

    public class Geometry
    {
        public Location location;
        public string location_type;
        public Viewport viewport;
        public Viewport bounds;
    }

    public class Location
    {
        public string lat;
        public string lng;
    }

    public class Viewport
    {
        public Location northeast;
        public Location southwest;

    }
    //<-- Google Geocoding classes
}

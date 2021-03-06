﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using PumpLib;
using Microsoft.Exchange.WebServices.Data;

namespace PumpAnalysis
{
    public partial class frmPumpAnalysis : Form
    {
        public frmPumpAnalysis()
        {
            InitializeComponent();          
        }

        public List<ImpData> objList = new List<ImpData>();
        public string json_filename;
        public string json_path;
        byte[] fileBytes;
        RowsCounter counters = new RowsCounter();

        // VehicleTrace -->
        public List<VehicleTrace> vtObjList = new List<VehicleTrace>();
        // VehicleTrace <--
        public List<Station> stationsObjList = new List<Station>();

        private void btnImport_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON files (*.json)|*.json";
            DialogResult result = ofd.ShowDialog();

            json_path = ofd.FileName;
            if (json_path.Trim() == "" || result != DialogResult.OK)
            {
                return;
            }

            //init
            lblImpFile.Text = "Αρχείο: -";
            objList.Clear();
            vtObjList.Clear();
            stationsObjList.Clear();
            dgvReceiptData.Rows.Clear();
            json_filename = "";
            //json_path = "";
            if (fileBytes != null)
            {
                Array.Clear(fileBytes, 0, fileBytes.Length);
            }
            counters.Clear();

            Output.WriteToFile("***** STARTING... *****");
            Output.WriteToFile("-- Import Function --");

            Output.WriteToFile("Filename: " + json_path);

            string read_data = dbu.getAllDataFromJsonFile(json_path);

            if (read_data.Trim() == "")
            {
                Output.WriteToFile("Empty file!");
                return;
            }

            //get byte[] ready to import into table

            // VehicleTrace -->
            ImpData_And_VehicleTrace AllData = dbu.JsonToMultipleObject(read_data);
            List<ImpData> DataToMigrateNew = AllData.impData;
            List<VehicleTrace> VehicleTraceToMigrate = AllData.vehicleTrace;
            vtObjList = VehicleTraceToMigrate;
            List<Station> StationToMigrate = AllData.stationData;
            stationsObjList = StationToMigrate;
            // VehicleTrace <--

            List <ImpData> DataToMigrate = dbu.JsonToObjectList(read_data);

            // VehicleTrace -->
            DataToMigrate = DataToMigrateNew;
            // VehicleTrace <--

            counters.fileRows = DataToMigrate.Count;
            counters.fileAccRows = DataToMigrate.Count(i => i.accepted == true);
            counters.fileNAccRows = DataToMigrate.Count(i => i.accepted == false);
            
            Output.WriteToFile("Rows in file: " + counters.fileRows.ToString());
            Output.WriteToFile("File - Accepted=true Rows: " + counters.fileAccRows.ToString() + ", Accepted=false Rows: " + counters.fileNAccRows.ToString());
            
            objList = dbu.GetDataNotExistsInSQLSrvTable(DataToMigrate);

            counters.toSaveRows = objList.Count;
            Output.WriteToFile("Rows to save: " + objList.Count.ToString());

            json_filename = json_path.Substring(json_path.LastIndexOf("\\") + 1);

            //get file contents as byte[]
            fileBytes = System.IO.File.ReadAllBytes(json_path);

            if (objList.Count > 0)
            {
                counters.toSaveAccRows = objList.Count(i => i.accepted == true);
                counters.toSaveNAccRows = objList.Count(i => i.accepted == false);

                Output.WriteToFile("To save - Accepted=true Rows: " + counters.toSaveAccRows.ToString() + ", Accepted=false Rows: " + counters.toSaveNAccRows.ToString());

                counters.vehicleTraceRows = vtObjList.Count;
                counters.stationsUpdRows = stationsObjList.Count;

                List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList, true);

                GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
                
                lblImpFile.Text = "Αρχείο: " + json_filename;
                
            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς επεξεργασία! \r\n" +
                                "Παρακαλώ μετακινήστε στο φάκελο αρχειοθέτησης το αρχείο " + json_path + ".");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();

            Output.WriteToFile("-- Save Function --");

            if (json_filename == null || fileBytes == null)
            {
                Output.WriteToFile("No File to save.", true);
                MessageBox.Show("Δεν έχετε επιλέξει αρχείο προς αποθήκευση!");
                return;
            }


            //import the whole file into sql DB table - imported group
            bool success = dbu.InsertImportedFileIntoTable(json_filename, fileBytes, counters, true);
            if (!success)
            {
                MessageBox.Show("Προσοχή! Σφάλμα κατά την καταχώρηση του αρχείου " + json_filename);
                return;
            }
            Output.WriteToFile("Saved file: " + json_filename);
            
            if (objList.Count > 0)
            {
                //get max id 
                int ImportedGroupId = dbu.getMaxImportedGroupId(json_filename);
                if (ImportedGroupId <= 0) //error: -1 (& 0 -> id starts from 1...)
                {
                    MessageBox.Show("Προσοχή! Σφάλμα κατά την εύρεση του καταχωρημένου αρχείου.");
                    return;
                }
                Output.WriteToFile("ImportedGroupId: " + ImportedGroupId.ToString());

                bool insSuccess = dbu.ObjectList_To_SQLServerReceiptDataLines(objList, ImportedGroupId);

                try
                {
                    System.IO.File.Move(json_path, Application.StartupPath + "\\Archive\\" + json_filename);
                    Output.WriteToFile("File moved to 'Archive' folder");
                }
                catch (Exception ex)
                {
                    Output.WriteToFile(ex.Message, true);
                    insSuccess = false;
                }

                // VehicleTrace -->
                //insert into dbo.VehicleTrace
                Output.WriteToFile("Inserting Vehicle Trace data into Database. " + vtObjList.Count.ToString() + "records.");
                dbu.Insert_List_Into_VehicleTrace(vtObjList);
                // VehicleTrace <--

                Output.WriteToFile("Inserting Stations data into Database. " + stationsObjList.Count.ToString() + "records.");
                dbu.Insert_List_Into_Station(stationsObjList);

                if (insSuccess)
                {
                    dbu.update_ImportedGroup_Table(ImportedGroupId);

                    MessageBox.Show("Η καταχώρηση ολοκληρώθηκε επιτυχώς!");
                    Output.WriteToFile("***** FINISHED... *****");
                }
                else
                {
                    MessageBox.Show("Η καταχώρηση ολοκληρώθηκε με σφάλματα!");
                    Output.WriteToFile("***** FINISHED WITH ERRORS... *****");
                }

                //refresh? / close form?
                dgvReceiptData.Rows.Clear();
                objList.Clear();
                vtObjList.Clear();
                stationsObjList.Clear();
                Array.Clear(fileBytes, 0, fileBytes.Length);
                lblImpFile.Text = "Αρχείο: -";
                json_filename = "";
                counters.Clear();

            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς καταχώρηση!");
            }
        }

        private void AutomaticProcedure()
        {
            Output.WriteToFile("***** STARTING... *****");

            //get all json files from folder
            string targetDirectory = Application.StartupPath + "\\Import";
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.json");

            Output.WriteToFile(fileEntries.Length + " file(s) found.");

            int cnt = 0;

            foreach (string fileName in fileEntries)
            {
                cnt++;
                Output.WriteToFile("Starting - File " + cnt.ToString() + "/" + fileEntries.Length);

                //init
                lblImpFile.Text = "Αρχείο: -";
                objList.Clear();
                vtObjList.Clear();
                stationsObjList.Clear();
                json_filename = "";
                if (fileBytes != null)
                {
                    Array.Clear(fileBytes, 0, fileBytes.Length);
                }
                counters.Clear();

                DbUtilities dbu = new DbUtilities();
                dbu.automaticMode = true;

                json_path = fileName;
                Output.WriteToFile("Filename: " + json_path);

                string read_data = dbu.getAllDataFromJsonFile(json_path);
                //get file contents as byte[]
                fileBytes = System.IO.File.ReadAllBytes(json_path);

                json_filename = json_path.Substring(json_path.LastIndexOf("\\") + 1);

                //import the whole file into sql DB table - imported group
                bool success = dbu.InsertImportedFileIntoTable(json_filename, fileBytes, counters, false);
                Output.WriteToFile("Saved file: " + json_filename);

                try
                {
                    System.IO.File.Move(json_path, Application.StartupPath + "\\Archive\\" + json_filename);
                    Output.WriteToFile("File moved to 'Archive' folder");
                }
                catch (Exception ex)
                {
                    Output.WriteToFile(ex.Message, true);
                }

                if (!success)
                {
                    continue;
                }
                
                if (read_data.Trim() == "")
                {
                    Output.WriteToFile("Empty file!");
                    continue;
                }

                //get max id 
                int ImportedGroupId = dbu.getMaxImportedGroupId(json_filename);
                if (ImportedGroupId <= 0) //error: -1 (& 0 -> id starts from 1...)
                {
                    continue;
                }
                Output.WriteToFile("ImportedGroupId: " + ImportedGroupId.ToString());

                // VehicleTrace -->
                ImpData_And_VehicleTrace AllData = dbu.JsonToMultipleObject(read_data);
                List<ImpData> DataToMigrateNew = AllData.impData;
                List<VehicleTrace> VehicleTraceToMigrate = AllData.vehicleTrace;
                vtObjList = VehicleTraceToMigrate;
                List<Station> StationToMigrate = AllData.stationData;
                stationsObjList = StationToMigrate;

                // VehicleTrace <--

                //List<ImpData> DataToMigrate = dbu.JsonToObjectList(read_data);

                // VehicleTrace -->
                List<ImpData> DataToMigrate = DataToMigrateNew;
                // VehicleTrace <--

                counters.fileRows = DataToMigrate.Count;
                counters.fileAccRows = DataToMigrate.Count(i => i.accepted == true);
                counters.fileNAccRows = DataToMigrate.Count(i => i.accepted == false);
                Output.WriteToFile("Rows in file: " + counters.fileRows.ToString());
                Output.WriteToFile("File - Accepted=true Rows: " + counters.fileAccRows.ToString() + ", Accepted=false Rows: " + counters.fileNAccRows.ToString());

                objList = dbu.GetDataNotExistsInSQLSrvTable(DataToMigrate);

                counters.toSaveRows = objList.Count;
                Output.WriteToFile("Rows to save: " + objList.Count.ToString());

                if (objList.Count > 0)
                {
                    counters.toSaveAccRows = objList.Count(i => i.accepted == true);
                    counters.toSaveNAccRows = objList.Count(i => i.accepted == false);
                }
                Output.WriteToFile("To save - Accepted=true Rows: " + counters.toSaveAccRows.ToString() + ", Accepted=false Rows: " + counters.toSaveNAccRows.ToString());

                counters.vehicleTraceRows = vtObjList.Count;
                counters.stationsUpdRows = stationsObjList.Count;

                bool result = dbu.update_ImportedGroup_Counters(ImportedGroupId, counters);
                Output.WriteToFile("Counters updated.");

                if (objList.Count <= 0)
                {
                    continue;
                }
                
                lblImpFile.Text = "Αρχείο: " + json_filename;
                
                bool insSuccess = dbu.ObjectList_To_SQLServerReceiptDataLines(objList, ImportedGroupId);

                // VehicleTrace -->
                //insert into dbo.VehicleTrace
                Output.WriteToFile("Inserting Vehicle Trace data into Database. " + vtObjList.Count.ToString() + " records.");
                dbu.Insert_List_Into_VehicleTrace(vtObjList);
                // VehicleTrace <--

                Output.WriteToFile("Inserting Stations data into Database. " + stationsObjList.Count.ToString() + " records.");
                dbu.Insert_List_Into_Station(stationsObjList);

                if (insSuccess)
                {
                    dbu.update_ImportedGroup_Table(ImportedGroupId);
                }

                Output.WriteToFile("Finished - File " + cnt.ToString() + "/" + fileEntries.Length);

                objList.Clear();
                vtObjList.Clear();
                stationsObjList.Clear();
                Array.Clear(fileBytes, 0, fileBytes.Length);
                lblImpFile.Text = "Αρχείο: -";
                json_filename = "";
                counters.Clear();                
            }

            Output.WriteToFile("***** FINISHED... *****");

        }

        private void geocodingTest()
        {
            DbUtilities d = new DbUtilities();
            string geo_json_data = d.getAllDataFromJsonFile(@"C:\Users\hkylidis\Desktop\rev_geocoding_el.json");

            GeoCoding a = d.stringToGenericObject<GeoCoding>(geo_json_data);
            if (a.status.ToUpper() == "OK")
            {
                string areaLevel1 = a.results.Where(i => i.types.Contains("administrative_area_level_1")).FirstOrDefault().address_components.Where(i => i.types.Contains("administrative_area_level_1")).FirstOrDefault().long_name;
                string areaLevel2 = a.results.Where(i => i.types.Contains("administrative_area_level_2")).FirstOrDefault().address_components.Where(i => i.types.Contains("administrative_area_level_2")).FirstOrDefault().long_name;
                string areaLevel3 = a.results.Where(i => i.types.Contains("administrative_area_level_3")).FirstOrDefault().address_components.Where(i => i.types.Contains("administrative_area_level_3")).FirstOrDefault().long_name;
                string areaLevel4 = a.results.Where(i => i.types.Contains("administrative_area_level_4")).FirstOrDefault().address_components.Where(i => i.types.Contains("administrative_area_level_4")).FirstOrDefault().long_name;
            }
            
        }

        private void frmPumpAnalysis_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "AUTO") > 0)
            {
                AutomaticProcedure();

                Application.Exit();
            }

            if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "SENDDBS") > 0)
            {
                ExportDBs();

                SendDBsToEachDriver();

                Application.Exit();
            }

            if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "RECEIVEATT") > 0)
            {
                ReceiveEmailAttachments();

                Application.Exit();
            }
        }

        private void ReceiveEmailAttachments()
        {
            Output.WriteToFile("===== IMPORT ATTACHMENTS... =====");
            EmailParams emailParams = new EmailParams(true);

            ExchangeService service = new ExchangeService();

            try
            {
                service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            }
            catch (Exception ex)
            {
                Output.WriteToFile("ERROR:" + ex.Message);
            }

            //service.AutodiscoverUrl("pumpinfo@moh.gr");
            //service.AutodiscoverUrl(emailParams.EmailAddress);
            //Output.WriteToFile("a");
            //service.Url = new Uri("https://wmath.moh.gr/EWS/Exchange.asmx");
            //Output.WriteToFile("b");
            //service.Credentials = new WebCredentials("moh\\pumpinfo", "password here");
            //service.Credentials = new WebCredentials("pumpinfo", "password here", "moh");
            service.Credentials = new WebCredentials(emailParams.UserName, emailParams.Password, emailParams.Domain);
            service.AutodiscoverUrl(emailParams.EmailAddress);

            ItemView view = new ItemView(20);
            view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending);

            string querystring = "HasAttachments:true Kind:email IsRead:false";

            FindItemsResults<Item> results = service.FindItems(WellKnownFolderName.Inbox, querystring, view);
            
            foreach (EmailMessage email in results)
            {
                if (email.IsRead == false)
                {
                    //MessageBox.Show(email.Subject); //to log file...
                    email.Load();
                    foreach (var att in email.Attachments)
                    {
                        FileAttachment fileAttachment = (FileAttachment)att;

                        Output.WriteToFile("Attachment file: " + fileAttachment.Name);

                        //MessageBox.Show(fileAttachment.Name); //to log file...
                        //fileAttachment.Load("C:\\Tests\\" + fileAttachment.Name);
                        fileAttachment.Load(Application.StartupPath + "\\Import\\" + fileAttachment.Name);
                    }
                    email.IsRead = true;
                    email.Update(ConflictResolutionMode.AlwaysOverwrite);
                }
            }
            Output.WriteToFile("===== PROCEDURE COMPLETED... =====");
        }

        private void ExportDBs()
        {
            Output.WriteToFile("===== EXPORT DBS... =====");

            DbUtilities dbu = new DbUtilities();

            Output.WriteToFile("StationGeoData.db");
            dbu.ExportDB_Geostation(Application.StartupPath.Replace("PumpAnalysis", "PumpData"));
            //System.Threading.Thread.Sleep(5000); //5 sec
            Output.WriteToFile("Archived.db");
            dbu.ExportDB_Archived(Application.StartupPath.Replace("PumpAnalysis", "PumpData"));
            //System.Threading.Thread.Sleep(5000); //5 sec
            Output.WriteToFile("===== DBS EXPORTED... =====");
        }

        private void SendDBsToEachDriver()
        {
            List<Machines> machines = DbUtilities.GetSqlMachinesList().Where(i => i.Email != null && i.Email.Trim().Length > 0).ToList();

            EmailParams emailParams = new EmailParams(true);

            foreach (Machines driver in machines)
            {
                SendExportedDBsByEmail(driver.Email, emailParams); 
            }
        }

        /*private void SendExportedDBsByEmail_ori(string MailTo, EmailParams emailParams) 
        {
            Output.WriteToFile("===== SENDING MAIL... =====");
            Output.WriteToFile("To: " + MailTo);

            string targetDirectory = Application.StartupPath.Replace("PumpAnalysis", "PumpData") + "\\ExportedDBs\\";


            string Archived_db_file = targetDirectory + "Archived.db"; //@"C:\Repos\PumpInfo\PumpData\bin\Debug\ExportedDBs\Archived.db";
            string StationGeoData_db_file = targetDirectory + "StationGeoData.db"; //@"C:\Repos\PumpInfo\PumpData\bin\Debug\ExportedDBs\StationGeoData.db";

            //System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("pumpinfo@moh.gr", MailTo, "Συγχρονισμός Βάσεων - DBs Synchronization",
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(emailParams.EmailAddress, MailTo, "Συγχρονισμός Βάσεων - DBs Synchronization",
                "Χρησιμοποιείστε τα συνημμένα αρχεία για να συγχρονίσετε τη βάση σας. \r\n" +
                "Πατήστε το κουμπί 'Sync', επιλέξτε 'Πρατήρια' επιλέγοντας το αρχείο 'StationGeoData.db' και 'Επισκέψεις' επιλέγοντας το αρχείο 'Archived.db' \r\n\r\n" +
                "Use attachments to synchronize your database. \r\n" +
                "Click the button 'Sync', then button 'Pratiria' and select file 'StationGeoData.db' and click the button 'Episkepseis' and select the file 'Archived.db' ");
            //System.Net.Mail.Attachment data = new System.Net.Mail.Attachment(file, System.Net.Mime.MediaTypeNames.Application.Octet);
            //message.Attachments.Add(data);
            try
            {
                System.Net.Mail.Attachment att_Archived_db = new System.Net.Mail.Attachment(Archived_db_file, System.Net.Mime.MediaTypeNames.Application.Octet);
                System.Net.Mail.Attachment att_StationGeoData_db = new System.Net.Mail.Attachment(StationGeoData_db_file, System.Net.Mime.MediaTypeNames.Application.Octet);
                message.Attachments.Add(att_Archived_db);
                message.Attachments.Add(att_StationGeoData_db);
            }
            catch (Exception exAtt)
            {
                Output.WriteToFile("Exception occured: " + exAtt.Message + " \r\n " + exAtt.ToString());
                return;
            }

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            client.Host = emailParams.SmtpClientHost; //"wmath.moh.gr";
            //client.Credentials = new System.Net.NetworkCredential("pumpinfo", "password here");
            client.Credentials = new System.Net.NetworkCredential(emailParams.UserName, emailParams.Password, emailParams.Domain);

            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Exception occured: " + ex.Message + " \r\n {0}", ex.ToString());
                Output.WriteToFile("Exception occured: " + ex.Message + " \r\n " + ex.ToString());
            }

            Output.WriteToFile("===== MAIL SENT... =====");

        }
        */

        private void SendExportedDBsByEmail(string MailTo, EmailParams emailParams)
        {
            Output.WriteToFile("===== SENDING MAIL... =====");
            Output.WriteToFile("To: " + MailTo);

            ExchangeService service = new ExchangeService();

            try
            {
                service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            }
            catch (Exception ex)
            {
                Output.WriteToFile("ERROR:" + ex.Message);
            }


            service.Credentials = new WebCredentials(emailParams.UserName, emailParams.Password, emailParams.Domain);
            service.AutodiscoverUrl(emailParams.EmailAddress);

            string targetDirectory = Application.StartupPath.Replace("PumpAnalysis", "PumpData") + "\\ExportedDBs\\";


            string Archived_db_file = targetDirectory + "Archived.db"; //@"C:\Repos\PumpInfo\PumpData\bin\Debug\ExportedDBs\Archived.db";
            string StationGeoData_db_file = targetDirectory + "StationGeoData.db"; //@"C:\Repos\PumpInfo\PumpData\bin\Debug\ExportedDBs\StationGeoData.db";

            String subject = "Συγχρονισμός Βάσεων - DBs Synchronization";
            String body = "Χρησιμοποιείστε τα συνημμένα αρχεία για να συγχρονίσετε τη βάση σας. \r\n" +
                "Πατήστε το κουμπί 'Sync', επιλέξτε 'Πρατήρια' επιλέγοντας το αρχείο 'StationGeoData.db' και 'Επισκέψεις' επιλέγοντας το αρχείο 'Archived.db' \r\n\r\n" +
                "Use attachments to synchronize your database. \r\n" +
                "Click the button 'Sync', then button 'Pratiria' and select file 'StationGeoData.db' and click the button 'Episkepseis' and select the file 'Archived.db' ";

            EmailMessage email = new EmailMessage(service);
            email.Subject = subject;
            email.Body = new MessageBody(BodyType.Text, body);
            email.ToRecipients.Add(MailTo);

            try
            {
                email.Attachments.AddFileAttachment(Archived_db_file);
                email.Attachments.AddFileAttachment(StationGeoData_db_file);
                
            }
            catch (Exception exAtt)
            {
                Output.WriteToFile("Exception occured: " + exAtt.Message + " \r\n " + exAtt.ToString());
                return;
            }
            
            try
            {
                email.Send();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Exception occured: " + ex.Message + " \r\n {0}", ex.ToString());
                Output.WriteToFile("Exception occured: " + ex.Message + " \r\n " + ex.ToString());
            }

            Output.WriteToFile("===== MAIL SENT... =====");

        }
    }

    
}


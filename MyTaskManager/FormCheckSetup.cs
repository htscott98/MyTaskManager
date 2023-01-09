using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace MyTaskManager
{
    public partial class FormCheckSetup : Form
    {
        public FormCheckSetup()
        {
            InitializeComponent();
        }

        private void FormCheckSetup_Load(object sender, EventArgs e)
        {
            this.Text = GlobalCode.GetApplicationName();
            CheckSoftwareRequirements();

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckSoftwareRequirements()
        {

            try
            {

                using (SqlConnection connection = Connection.InitServerConnection())
                {
                    try
                    {
                        connection.Open();
                        CheckBoxSQLStudio.Checked = true;
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        CheckBoxSQLStudio.Checked = false;
                        return;
                    }
                }

                    string sql = "select * from sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitServerConnection(), sql);

                foreach (DataRow row in dt.Rows)
                {
                    if (row["name"].ToString() == "MyTaskManager")
                    {
                        CheckBoxSQLDatabase.Checked = true;
                        break;
                    }
                }

                if (CheckBoxSQLDatabase.Checked == false)
                {
                    FailedTests();
                    return;
                }

                string filePath = @"C:\MyTaskManager\OpenedFiles\";

                if (Directory.Exists(filePath) == true)
                {
                    CheckBoxFileDirectory.Checked = true;
                }
                else
                {
                    CheckBoxFileDirectory.Checked = false;
                }

                //Projects, Statuses, Activity

                sql = "SELECT * FROM Sys.Tables ORDER BY Name ASC";
                dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), sql);

                bool projectsLocated = false;
                bool statusesLocated = false;
                bool activityLocated = false;
                bool attachmentsLocated = false;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["name"].ToString() == "Tasks")
                    {
                        projectsLocated = true;
                    }

                    if (row["name"].ToString() == "Statuses")
                    {
                        statusesLocated = true;
                    }

                    if (row["name"].ToString() == "Activity")
                    {
                        activityLocated = true;
                    }

                    if (row["name"].ToString() == "Attachments")
                    {
                        attachmentsLocated = true;
                    }

                }

                if (projectsLocated == true && statusesLocated == true && activityLocated == true && attachmentsLocated == true)
                {
                    CheckBoxSQLTables.Checked = true;
                }


                if (CheckBoxSQLStudio.Checked == true && CheckBoxSQLDatabase.Checked == true && CheckBoxSQLTables.Checked == true && CheckBoxFileDirectory.Checked == true)
                {
                    PassedTests();
                }
                else
                {
                    FailedTests();
                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void BuildSoftwareRequirements()
        {
            try
            {

                CheckSoftwareRequirements();

                if (CheckBoxSQLStudio.Checked == false)
                {
                    if(GlobalCode.ShowMSGBox("Please install a SQL Server with default properties." + Environment.NewLine + Environment.NewLine + "Would you like to go there now?", MessageBoxIcon.Information, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo("https://www.microsoft.com/en-us/sql-server/sql-server-downloads") { UseShellExecute = true });
                        return;
                    }
                    else
                    {
                        return;
                    }
                }


                if (CheckBoxSQLDatabase.Checked == false)
                {
                    string sql = "CREATE DATABASE MyTaskManager;";
                    bool dbCreated = Execute.ExecuteStatementReturnBool(Connection.InitServerConnection(), sql);

                    sql = "select * from sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
                    DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitServerConnection(), sql);

                    bool createdDB = false;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["name"].ToString() == "MyTaskManager")
                        {
                            createdDB = true;
                        }
                    }

                    if (createdDB == false)
                    {
                        GlobalCode.ShowMSGBox("Unable to create database MyTaskManager. Try again or contact the developer.", MessageBoxIcon.Error);
                        return;
                    }


                }

                if (CheckBoxFileDirectory.Checked == false)
                {
                    string filePath = @"C:\MyTaskManager\OpenedFiles\";
                    Directory.CreateDirectory(filePath);
                }


                if (CheckBoxSQLTables.Checked == false)
                {
                    string username = Environment.UserName;

                    string sql = "";

                    sql = "SELECT * FROM Sys.Tables ORDER BY Name ASC";
                    DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), sql);

                    bool projectsLocated = false;
                    bool statusesLocated = false;
                    bool activityLocated = false;
                    bool attachmentsLocated = false;

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["name"].ToString() == "Tasks")
                        {
                            projectsLocated = true;
                        }

                        if (row["name"].ToString() == "Statuses")
                        {
                            statusesLocated = true;
                        }

                        if (row["name"].ToString() == "Activity")
                        {
                            activityLocated = true;
                        }

                        if (row["name"].ToString() == "Attachments")
                        {
                            attachmentsLocated = true;
                        }

                    }

                    sql = "";

                    if (attachmentsLocated == false)
                    {
                        sql = "CREATE PROCEDURE [dbo].[InsertFile] (@TaskID int, @Name varchar(200), @Attachment VarBinary(MAX), @UploadedTimestamp datetime) AS BEGIN INSERT INTO Attachments (TaskID, Name, Attachment, UploadedTimestamp) VALUES (@TaskID, @Name, @Attachment, @UploadedTimestamp) END";
                        Execute.ExecuteStatementReturnBool(Connection.InitMyTaskManagerConnection(), sql);
                        sql = "ALTER PROCEDURE [dbo].[InsertFile] (@TaskID int, @Name varchar(200),  @Attachment VarBinary(MAX), @UploadedTimestamp datetime) AS BEGIN INSERT INTO Attachments (TaskID, Name, Attachment, UploadedTimestamp) VALUES (@TaskID, @Name, @Attachment, @UploadedTimestamp) END";
                        Execute.ExecuteStatementReturnBool(Connection.InitMyTaskManagerConnection(), sql);
                        sql = "CREATE TABLE Attachments (ID int IDENTITY(1,1) PRIMARY KEY, TaskID int NOT NULL, Name varchar(200), Attachment VarBinary(MAX) NOT NULL, UploadedTimestamp datetime NOT NULL);";
                    }

                    if (projectsLocated == false)
                    {
                        sql += "CREATE TABLE Tasks (ID int IDENTITY(1,1) PRIMARY KEY, TaskName varchar(200) NOT NULL, StatusID int, LastUpdated datetime NOT NULL, DisplayOrder int NOT NULL, Enabled bit NOT NULL);"; //Projects
                    }

                    if (statusesLocated == false)
                    {
                        sql += "CREATE TABLE Statuses (ID int IDENTITY(1,1) PRIMARY KEY, StatusName varchar(200) NOT NULL, DisplayOrder int NOT NULL);"; //Statuses
                    }

                    if (activityLocated == false)
                    {
                        sql += "CREATE TABLE Activity (ID int IDENTITY(1,1) PRIMARY KEY, ActivityName varchar(5000), TaskID int, ActivityTimestamp datetime NOT NULL);";
                    }
                    

                    dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), sql);



                }

                
                CheckSoftwareRequirements();

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void ButtonRunSetup_Click(object sender, EventArgs e)
        {
            BuildSoftwareRequirements();
        }

        private void PassedTests()
        {
            ButtonRunSetup.Enabled = false;
            ButtonNext.Enabled = true;
        }

        private void FailedTests()
        {
            ButtonRunSetup.Enabled = true;
            ButtonNext.Enabled = false;
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            CheckSoftwareRequirements();
            this.Visible = false;
            FormMain f = new FormMain();
            f.Show();

        }

        private void FormCheckSetup_Shown(object sender, EventArgs e)
        {
            if (CheckBoxSQLStudio.Checked == true && CheckBoxSQLDatabase.Checked == true && CheckBoxSQLTables.Checked == true && CheckBoxFileDirectory.Checked == true)
            {
                ButtonNext_Click(null, null);
            }
        }
    }
}
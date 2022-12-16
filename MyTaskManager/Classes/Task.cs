using System;
using System.Data;
using System.Collections.Generic;
using MyTaskManager;
using System.Windows.Forms;

namespace MyTaskManager
{

    public class Task
    {

        #region " Declarations "

        private int _ID;
        private string _TaskName;
        private int _StatusID;
        private DateTime _LastUpdated;
        private int _DisplayOrder;
        private bool _Enabled;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public string TaskName { get { return _TaskName; } set { _TaskName = value; } }
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }
        public DateTime LastUpdated { get { return _LastUpdated; } set { _LastUpdated = value; } }
        public int DisplayOrder { get { return _DisplayOrder; } set { _DisplayOrder = value; } }
        public bool Enabled { get { return _Enabled; } set { _Enabled = value; } }

        #endregion

        #region " Constructors "

        public Task()
        {
            _ID = 0;
            _TaskName = string.Empty;
            _StatusID = 0;
            _LastUpdated = Convert.ToDateTime("1/1/1900");
            _DisplayOrder = 0;
            _Enabled = false;
        }

        public Task(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _TaskName = row["TaskName"].ToString();
            _StatusID = Convert.ToInt32(row["StatusID"].ToString());
            _LastUpdated = Convert.ToDateTime(row["LastUpdated"].ToString());
            _DisplayOrder = Convert.ToInt32(row["DisplayOrder"].ToString());
            _Enabled = Convert.ToBoolean(row["Enabled"].ToString());
        }

        public Task(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _TaskName = row.Cells["TaskName"].Value.ToString();
            _StatusID = Convert.ToInt32(row.Cells["StatusID"].Value.ToString());
            _LastUpdated = Convert.ToDateTime(row.Cells["LastUpdated"].Value.ToString());
            _DisplayOrder = Convert.ToInt32(row.Cells["DisplayOrder"].Value.ToString());
            _Enabled = Convert.ToBoolean(row.Cells["Enabled"].Value.ToString());
        }

        #endregion

        #region " Overrides "

        public override string ToString()
        {
            return "";
        }

        #endregion

        #region " Private Methods "

        private static string GetSQLSelect()
        {
            string strReturnValue;
            strReturnValue = " SELECT ID, TaskName, StatusID, LastUpdated, DisplayOrder, Enabled ";
            return strReturnValue;
        }

        #endregion

        #region " Public Methods "

        public static DataTable GetDataTable()
        {
            string strSQL = "";
            DataTable dt = null;

            try
            {
                strSQL = GetSQLSelect() +
                "FROM Tasks";

                dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

            }
            catch (Exception ex)
            {
                
            }

            return dt;
        }

        public static List<Task> GetListOfObjects()
        {
            List<Task> objList = new List<Task>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM Tasks";

                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Task obj = new Task(r);

                        if (obj != null)
                            objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return objList;
        }

        public static List<Task> GetListOfObjectsByStatusID(string statusID)
        {
            List<Task> objList = new List<Task>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM Tasks " +
                "WHERE StatusID = '" + statusID + "' AND Enabled = 1" +
                "ORDER BY DisplayOrder ASC";

                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Task obj = new Task(r);

                        if (obj != null)
                            objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return objList;
        }

        public static List<Task> GetListOfDisabledObjects()
        {
            List<Task> objList = new List<Task>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM Tasks " +
                "WHERE Enabled = 0" +
                "ORDER BY DisplayOrder ASC";

                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Task obj = new Task(r);

                        if (obj != null)
                            objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return objList;
        }

        public static Task GetObjectByID(string id)
        {
            Task obj = new Task();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM Tasks " +
                "WHERE ID = '" + id + "'";

                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        obj = new Task(r);

                        if (obj != null)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return obj;
        }

        public bool InsertRecord()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@TaskName", _TaskName);
                keyValuePairs.Add("@StatusID", _StatusID.ToString());
                keyValuePairs.Add("@LastUpdated", _LastUpdated.ToString());
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder.ToString());
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                strSQL = "INSERT INTO Tasks (" +
                "TaskName,StatusID,LastUpdated,DisplayOrder,Enabled)" +
                " VALUES (@TaskName,@StatusID,@LastUpdated,@DisplayOrder,@Enabled)";
                b = Execute.ExecuteStatementReturnBool(Connection.InitMyTaskManagerConnection(), strSQL, keyValuePairs);
            }


            catch (Exception ex)
            {
                

                b = false;
            }

            return b;
        }

        public bool UpdateRecord()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ID", _ID.ToString());
                keyValuePairs.Add("@TaskName", _TaskName);
                keyValuePairs.Add("@StatusID", _StatusID.ToString());
                keyValuePairs.Add("@LastUpdated", _LastUpdated.ToString());
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder.ToString());
                keyValuePairs.Add("@Enabled", _Enabled.ToString());
                strSQL = "UPDATE Tasks " +
                "SET TaskName=@TaskName, StatusID=@StatusID, LastUpdated=@LastUpdated, DisplayOrder=@DisplayOrder, " +
                "Enabled=@Enabled " +
                "WHERE ID = @ID ";

                b = Execute.ExecuteStatementReturnBool(Connection.InitMyTaskManagerConnection(), strSQL, keyValuePairs);

            }
            catch (Exception ex)
            {
                

                b = false;
            }

            return b;
        }

        public bool UpdateDisplayOrder()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ID", _ID.ToString());
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder.ToString());
                strSQL = "UPDATE Tasks " +
                "SET DisplayOrder=@DisplayOrder " +
                "WHERE ID = @ID ";

                b = Execute.ExecuteStatementReturnBool(Connection.InitMyTaskManagerConnection(), strSQL, keyValuePairs);

            }
            catch (Exception ex)
            {
                

                b = false;
            }

            return b;
        }

        public bool UpdateTaskList()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ID", _ID.ToString());
                keyValuePairs.Add("@StatusID", _StatusID.ToString());
                strSQL = "UPDATE Tasks " +
                "SET StatusID=@StatusID " +
                "WHERE ID = @ID ";

                b = Execute.ExecuteStatementReturnBool(Connection.InitMyTaskManagerConnection(), strSQL, keyValuePairs);

            }
            catch (Exception ex)
            {
                

                b = false;
            }

            return b;
        }

        public bool DeleteRecord()
        {
            string strSQL = "";
            bool b = false;

            try
            {
                strSQL = "DELETE FROM Tasks " +
                 "WHERE ID = " + _ID;

                b = Execute.ExecuteStatementReturnBool(Connection.InitMyTaskManagerConnection(), strSQL);

            }
            catch (Exception ex)
            {
                
            }

            return b;
        }
        #endregion

    }

}
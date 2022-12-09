using System;
using System.Data;
using System.Collections.Generic;
using MyTaskManager;
using System.Windows.Forms;

namespace MyTaskManager
{

    public class Activity
    {

        #region " Declarations "

        private int _ID;
        private string _ActivityName;
        private int _TaskID;
        private DateTime _ActivityTimestamp;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public string ActivityName { get { return _ActivityName; } set { _ActivityName = value; } }
        public int TaskID { get { return _TaskID; } set { _TaskID = value; } }
        public DateTime ActivityTimestamp { get { return _ActivityTimestamp; } set { _ActivityTimestamp = value; } }

        #endregion

        #region " Constructors "

        public Activity()
        {
            _ID = 0;
            _ActivityName = string.Empty;
            _TaskID = 0;
            _ActivityTimestamp = Convert.ToDateTime("1/1/1900");
        }

        public Activity(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _ActivityName = row["ActivityName"].ToString();
            _TaskID = Convert.ToInt32(row["TaskID"].ToString());
            _ActivityTimestamp = Convert.ToDateTime(row["ActivityTimestamp"].ToString());
        }

        public Activity(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _ActivityName = row.Cells["ActivityName"].Value.ToString();
            _TaskID = Convert.ToInt32(row.Cells["TaskID"].Value.ToString());
            _ActivityTimestamp = Convert.ToDateTime(row.Cells["ActivityTimestamp"].Value.ToString());
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
            strReturnValue = " SELECT ID, ActivityName, TaskID, ActivityTimestamp ";
            return strReturnValue;
        }

        #endregion

        #region " Public Methods "

        public static List<Activity> GetListOfObjectsByTaskID(string taskID)
        {
            List<Activity> objList = new List<Activity>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM Activity " +
                "WHERE TaskID = '" + taskID + "' " +
                "ORDER BY ActivityTimestamp DESC";

                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Activity obj = new Activity(r);

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

        public bool InsertRecord()
        {
            string strSQL = "";
            bool b = false;
            try
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                keyValuePairs.Add("@ActivityName", _ActivityName);
                keyValuePairs.Add("@TaskID", _TaskID.ToString());
                keyValuePairs.Add("@ActivityTimestamp", _ActivityTimestamp.ToString());
                strSQL = "INSERT INTO Activity (" +
                "ActivityName,TaskID,ActivityTimestamp)" +
                " VALUES (@ActivityName,@TaskID,@ActivityTimestamp)";
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
                keyValuePairs.Add("@ActivityName", _ActivityName);
                keyValuePairs.Add("@TaskID", _TaskID.ToString());
                keyValuePairs.Add("@ActivityTimestamp", _ActivityTimestamp.ToString());
                strSQL = "UPDATE Activity " +
                "SET ActivityName=@ActivityName, TaskID=@TaskID, ActivityTimestamp=@ActivityTimestamp " +
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
                strSQL = "DELETE FROM Activity " +
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
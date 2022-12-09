using System;
using System.Data;
using System.Collections.Generic;
using MyTaskManager;
using System.Windows.Forms;

namespace MyTaskManager
{

    public class Status
    {

        #region " Declarations "

        private int _ID;
        private string _StatusName;
        private int _DisplayOrder;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public string StatusName { get { return _StatusName; } set { _StatusName = value; } }
        public int DisplayOrder { get { return _DisplayOrder; } set { _DisplayOrder = value; } }

        #endregion

        #region " Constructors "

        public Status()
        {
            _ID = 0;
            _StatusName = string.Empty;
            _DisplayOrder = 0;
        }

        public Status(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _StatusName = row["StatusName"].ToString();
            _DisplayOrder = Convert.ToInt32(row["DisplayOrder"].ToString());
        }

        public Status(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _StatusName = row.Cells["StatusName"].Value.ToString();
            _DisplayOrder = Convert.ToInt32(row.Cells["DisplayOrder"].Value.ToString());
        }

        #endregion

        #region " Overrides "

        public override string ToString()
        {
            return _StatusName;
        }

        #endregion

        #region " Private Methods "

        private static string GetSQLSelect()
        {
            string strReturnValue;
            strReturnValue = " SELECT ID, StatusName, DisplayOrder ";
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
                "FROM Statuses " +
                "ORDER BY DisplayOrder ASC";

                dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

            }
            catch (Exception ex)
            {
                
            }

            return dt;
        }

        public static List<Status> GetListOfObjects()
        {
            List<Status> objList = new List<Status>();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM Statuses " +
                "ORDER BY DisplayOrder ASC";

                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Status obj = new Status(r);

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

        public static Status GetObjectByID(string id)
        {
            Status obj = new Status();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM Statuses " +
                "WHERE ID = '" + id + "'";

                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        obj = new Status(r);

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

                keyValuePairs.Add("@StatusName", _StatusName);
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder.ToString());
                strSQL = "INSERT INTO Statuses (" +
                "StatusName,DisplayOrder)" +
                " VALUES (@StatusName,@DisplayOrder)";
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
                keyValuePairs.Add("@StatusName", _StatusName);
                keyValuePairs.Add("@DisplayOrder", _DisplayOrder.ToString());
                strSQL = "UPDATE Statuses " +
                "SET StatusName=@StatusName, DisplayOrder=@DisplayOrder " +
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
                strSQL = "DELETE FROM Statuses " +
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
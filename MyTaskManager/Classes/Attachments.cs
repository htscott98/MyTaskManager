using System;
using System.Data;
using System.Collections.Generic;
using MyTaskManager;
using System.Windows.Forms;

namespace MyTaskManager
{

    public class Attachments
    {

        #region " Declarations "

        private int _ID;
        private int _TaskID;
        private string _Name;
        private byte[] _Attachment;
        private DateTime _UploadedTimestamp;

        #endregion

        #region " Properties "

        public int ID { get { return _ID; } set { _ID = value; } }
        public int TaskID { get { return _TaskID; } set { _TaskID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public byte[] Attachment { get { return _Attachment; } set { _Attachment = value; } }
        public DateTime UploadedTimestamp { get { return _UploadedTimestamp; } set { _UploadedTimestamp = value; } }

        #endregion

        #region " Constructors "

        public Attachments()
        {
            _ID = 0;
            _TaskID = 0;
            _Name = string.Empty;
            _Attachment = null;
            _UploadedTimestamp = Convert.ToDateTime("1/1/1900");
        }

        public Attachments(DataRow row)
        {
            _ID = Convert.ToInt32(row["ID"].ToString());
            _TaskID = Convert.ToInt32(row["TaskID"].ToString());
            _Name = row["Name"].ToString();
            _Attachment = (byte[])row["Attachment"];
            _UploadedTimestamp = Convert.ToDateTime(row["UploadedTimestamp"].ToString());
        }

        public Attachments(DataGridViewRow row)
        {
            _ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            _TaskID = Convert.ToInt32(row.Cells["TaskID"].Value.ToString());
            _Name = row.Cells["Name"].Value.ToString();
            _Attachment = (byte[])row.Cells["Attachment"].Value;
            _UploadedTimestamp = Convert.ToDateTime(row.Cells["UploadedTimestamp"].Value.ToString());
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
            strReturnValue = " SELECT ID, TaskID, Name, Attachment, UploadedTimestamp ";
            return strReturnValue;
        }

        #endregion

        #region " Public Methods "

        public static DataTable GetDataTableByTaskID(string taskID)
        {
            string strSQL = "";
            DataTable dt = null;

            try
            {
                strSQL = GetSQLSelect() +
                "FROM Attachments " +
                "WHERE TaskID = '" + taskID + "' " +
                "ORDER BY UploadedTimestamp DESC";

                dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

            }
            catch (Exception ex)
            {
                
            }

            return dt;
        }

        public static Attachments GetObjectByID(string id)
        {
            Attachments obj = new Attachments();
            string strSQL = "";
            try
            {
                strSQL = GetSQLSelect() +
                "FROM Attachments " +
                "WHERE ID = '" + id + "'";

                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), strSQL);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        obj = new Attachments(r);

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


        public bool DeleteRecord()
        {
            string strSQL = "";
            bool b = false;

            try
            {
                strSQL = "DELETE FROM Attachments " +
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
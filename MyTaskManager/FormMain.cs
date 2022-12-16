using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTaskManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = GlobalCode.GetApplicationName();
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            try
            {

                DataGridViewProjects.DataSource = null;

                string sql = "SELECT Tasks.ID,TaskName AS Task,Statuses.StatusName AS Status,LastUpdated AS Updated " +
                    "FROM MyTaskManager.dbo.Tasks " +
                    "LEFT OUTER JOIN Statuses ON Statuses.ID = Tasks.StatusID " +
                    "WHERE TaskName LIKE '%" + TextBoxSearch.Text + "%' AND Tasks.Enabled = '" + CheckBoxEnabled.Checked + "' " +
                    "ORDER BY Tasks.DisplayOrder ASC";

                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataGridViewProjects.DataSource = dt;
                    SetDisplayProperties();

                }
                LabelRowCount.Text = DataGridViewProjects.Rows.Count.ToString();


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void SetDisplayProperties()
        {
            this.DataGridViewProjects.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.DataGridViewProjects.AllowUserToAddRows = false;
            this.DataGridViewProjects.AllowUserToDeleteRows = false;
            this.DataGridViewProjects.AllowUserToResizeRows = false;
            this.DataGridViewProjects.AllowUserToOrderColumns = true;
            this.DataGridViewProjects.MultiSelect = true;
            this.DataGridViewProjects.ReadOnly = true;
            this.DataGridViewProjects.RowHeadersVisible = false;
            this.DataGridViewProjects.AllowUserToResizeColumns = true;
            this.DataGridViewProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewProjects.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.DataGridViewProjects.Columns["ID"].Visible = false;


        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void DataGridViewProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = DataGridViewProjects.SelectedRows[0].Cells["ID"].Value.ToString();

                if (string.IsNullOrEmpty(id) == true)
                {
                    return;
                }

                Task task = Task.GetObjectByID(id);

                if (task != null && task.ID != 0)
                {
                    FormTask f = new FormTask();
                    f.newTask = false;
                    f.selectedTask = task;
                    f.ShowDialog();
                    PopulateGrid();
                }


            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void ButtonNewProject_Click(object sender, EventArgs e)
        {
            FormTask f = new FormTask();
            f.newTask = true;
            f.selectedTask = null;
            f.ShowDialog();
            PopulateGrid();
        }

        private void CheckBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void ButtonManageStatuses_Click(object sender, EventArgs e)
        {
            FormManageStatuses f = new FormManageStatuses();
            f.ShowDialog();
            PopulateGrid();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonExportData_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridViewProjects.Rows.Count == 0)
                {
                    GlobalCode.ShowMSGBox("No data to export.", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                    return;
                }

                DataGridViewProjects.MultiSelect = true;
                DataGridViewProjects.SelectAll();
                DataObject dataObj = DataGridViewProjects.GetClipboardContent();
                DataGridViewProjects.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                if (dataObj != null)
                {
                    Clipboard.SetDataObject(dataObj);
                }

                Type officeType = Type.GetTypeFromProgID("Excel.Application");
                if (officeType == null)
                {
                    GlobalCode.ShowMSGBox("Microsoft Excel does not exist on this machine.", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                }
                else
                {
                    Microsoft.Office.Interop.Excel.Application xlexcel;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlexcel = new Microsoft.Office.Interop.Excel.Application();
                    xlexcel.Visible = true;
                    xlWorkBook = xlexcel.Workbooks.Add(misValue);
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    if (CheckBoxEnabled.Checked == true)
                    {
                        xlWorkSheet.Name = "Enabled Tasks";
                    }
                    else
                    {
                        xlWorkSheet.Name = "Disabled Tasks";
                    }


                    Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                    CR.Select();
                    xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                    DataGridViewProjects.ClearSelection();
                    xlWorkSheet.Columns.AutoFit();


                }
            }
            catch (Exception ex)
            {

            }

        }

    }
}

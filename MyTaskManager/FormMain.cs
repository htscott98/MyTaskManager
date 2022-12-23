using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

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

                FlowLayoutPanelLists.Controls.Clear();

                if (Status.GetListOfObjects().Count == 0)
                {
                    return;
                }


                if (CheckBoxEnabled.Checked == false)
                {
                    FlowLayoutPanel layoutPanel = new FlowLayoutPanel();
                    layoutPanel.Margin = new Padding(0, 0, 0, 0);
                    layoutPanel.Padding = new Padding(0);
                    layoutPanel.BackColor = Color.Transparent;
                    int height = FlowLayoutPanelLists.Height;
                    layoutPanel.Size = new Size(FlowLayoutPanelLists.Width / 3, height);
                    layoutPanel.BorderStyle = BorderStyle.FixedSingle;
                    layoutPanel.HorizontalScroll.Visible = false;
                    layoutPanel.HorizontalScroll.Enabled = false;
                    layoutPanel.AllowDrop = true;
                    layoutPanel.HorizontalScroll.Maximum = 0;
                    layoutPanel.AutoScroll = true;
                    layoutPanel.Anchor = AnchorStyles.Left;
                    layoutPanel.Anchor = AnchorStyles.Top;
                    layoutPanel.Anchor = AnchorStyles.Bottom;

                    FlowLayoutPanelLists.Controls.Add(layoutPanel);

                    Label layoutPanelHeader = new Label();
                    layoutPanelHeader.Text = "Disabled Tasks";
                    layoutPanelHeader.Width = Convert.ToInt32(layoutPanel.Width * .750);
                    layoutPanelHeader.Font = new Font("Arial", 12, FontStyle.Bold);
                    layoutPanelHeader.Margin = new Padding(0, 5, 0, 5);
                    layoutPanel.Controls.Add(layoutPanelHeader);

                    List<Task> allTasks = allTasks = Task.GetListOfDisabledObjects();

                    foreach (Task task in allTasks)
                    {
                        FlowLayoutPanel taskLayout = new FlowLayoutPanel();
                        taskLayout.Margin = new Padding(4, 2, 0, 2);
                        taskLayout.Padding = new Padding(0);
                        taskLayout.BackColor = SystemColors.ControlLight;
                        taskLayout.BorderStyle = BorderStyle.FixedSingle;
                        taskLayout.Name = task.ID.ToString();
                        //height = taskLayout.Height;
                        taskLayout.MinimumSize = new Size(Convert.ToInt32(Math.Round(layoutPanel.Width * .95, 0, MidpointRounding.ToZero)), 0);
                        taskLayout.MaximumSize = new Size(Convert.ToInt32(Math.Round(layoutPanel.Width * .95, 0, MidpointRounding.ToZero)), 0);
                        taskLayout.AutoSize = true;
                        taskLayout.HorizontalScroll.Enabled = false;

                        layoutPanel.Controls.Add(taskLayout);


                        Label taskheaderLabel = new Label();
                        taskheaderLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                        taskheaderLabel.Text = task.TaskName;
                        taskheaderLabel.BorderStyle = BorderStyle.None;
                        height = taskheaderLabel.Height;
                        taskheaderLabel.Size = new Size(taskLayout.Width, height);
                        taskheaderLabel.Padding = new Padding(0);
                        taskheaderLabel.Margin = new Padding(0, 5, 0, 5);
                        taskheaderLabel.Name = task.ID.ToString();
                        taskheaderLabel.TextAlign = ContentAlignment.MiddleLeft;
                        taskheaderLabel.AutoSize = true;
                        taskheaderLabel.MouseDown += ParentDrag;

                        taskLayout.Controls.Add(taskheaderLabel);
                        taskLayout.SetFlowBreak(taskheaderLabel, true);

                        Button newAttachmentButton = new Button();
                        newAttachmentButton.Text = "New File";
                        newAttachmentButton.FlatAppearance.BorderSize = 0;
                        newAttachmentButton.FlatStyle = FlatStyle.Flat;
                        height = 30;
                        newAttachmentButton.Size = new Size((taskLayout.Width / 3), height);
                        newAttachmentButton.Margin = new Padding(0);
                        newAttachmentButton.Padding = new Padding(0);
                        newAttachmentButton.ForeColor = Color.Red;
                        newAttachmentButton.Name = task.ID.ToString();
                        newAttachmentButton.Click += AddAttachment;

                        taskLayout.Controls.Add(newAttachmentButton);


                        Button newActivityButton = new Button();
                        newActivityButton.Text = "New Activity";
                        newActivityButton.FlatAppearance.BorderSize = 0;
                        newActivityButton.FlatStyle = FlatStyle.Flat;
                        height = 30;
                        newActivityButton.Size = new Size((taskLayout.Width / 3), height);
                        newActivityButton.Margin = new Padding(0);
                        newActivityButton.Padding = new Padding(0);
                        newActivityButton.ForeColor = Color.Blue;
                        newActivityButton.Name = task.ID.ToString();
                        newActivityButton.Click += AddActivity;

                        taskLayout.Controls.Add(newActivityButton);

                        Button editTaskButton = new Button();
                        editTaskButton.Text = "View Task";
                        editTaskButton.FlatAppearance.BorderSize = 0;
                        editTaskButton.FlatStyle = FlatStyle.Flat;
                        height = 30;
                        editTaskButton.Size = new Size((taskLayout.Width / 3) - 1, height);
                        editTaskButton.Margin = new Padding(0);
                        editTaskButton.Padding = new Padding(0);
                        editTaskButton.ForeColor = Color.Green;
                        editTaskButton.Name = task.ID.ToString();
                        editTaskButton.Click += EditTask;

                        taskLayout.Controls.Add(editTaskButton);
                        taskLayout.SetFlowBreak(editTaskButton, true);

                        Label layoutUpdated = new Label();
                        layoutUpdated.Text = "Last Updated: " + task.LastUpdated.ToString();
                        layoutUpdated.Width = Convert.ToInt32(layoutPanel.Width);
                        layoutUpdated.Font = new Font("Arial", 9, FontStyle.Bold);
                        layoutUpdated.Margin = new Padding(0, 0, 0, 0);
                        layoutUpdated.Padding = new Padding(0);
                        layoutUpdated.BackColor = Color.LightGray;
                        layoutUpdated.TextAlign = ContentAlignment.MiddleLeft;

                        taskLayout.Controls.Add(layoutUpdated);



                    }
                }
                else
                {



                    List<Status> allStatuses = Status.GetListOfObjects();

                    foreach (Status status in allStatuses)
                    {
                        FlowLayoutPanel layoutPanel = new FlowLayoutPanel();
                        layoutPanel.Margin = new Padding(0, 0, 0, 0);
                        layoutPanel.Padding = new Padding(0);
                        layoutPanel.BackColor = Color.Transparent;
                        int height = FlowLayoutPanelLists.Height;
                        layoutPanel.Name = status.ID.ToString();
                        layoutPanel.Size = new Size(FlowLayoutPanelLists.Width / 3, height);
                        layoutPanel.BorderStyle = BorderStyle.FixedSingle;
                        layoutPanel.HorizontalScroll.Visible = false;
                        layoutPanel.HorizontalScroll.Enabled = false;
                        layoutPanel.AllowDrop = true;
                        layoutPanel.HorizontalScroll.Maximum = 0;
                        layoutPanel.AutoScroll = true;
                        layoutPanel.Anchor = AnchorStyles.Left;
                        layoutPanel.Anchor = AnchorStyles.Top;
                        layoutPanel.Anchor = AnchorStyles.Bottom;
                        layoutPanel.DragLeave += LayoutPanel_DragLeave;
                        layoutPanel.DragDrop += LayoutPanel_DragDrop;
                        layoutPanel.DragEnter += LayoutPanel_DragEnter;
                        layoutPanel.DragOver += LayoutPanel_DragOver;

                        FlowLayoutPanelLists.Controls.Add(layoutPanel);

                        Label layoutPanelHeader = new Label();
                        layoutPanelHeader.Text = status.StatusName;
                        layoutPanelHeader.Width = Convert.ToInt32(layoutPanel.Width * .750);
                        layoutPanelHeader.Font = new Font("Arial", 12, FontStyle.Bold);
                        layoutPanelHeader.Margin = new Padding(0, 5, 0, 5);

                        layoutPanel.Controls.Add(layoutPanelHeader);

                        List<Task> allTasks = allTasks = Task.GetListOfObjectsByStatusID(status.ID.ToString());

                        foreach (Task task in allTasks)
                        {
                            FlowLayoutPanel taskLayout = new FlowLayoutPanel();
                            taskLayout.Margin = new Padding(4, 2, 0, 2);
                            taskLayout.Padding = new Padding(0);
                            taskLayout.BackColor = SystemColors.ControlLight;
                            taskLayout.BorderStyle = BorderStyle.FixedSingle;
                            taskLayout.Name = task.ID.ToString();
                            //height = taskLayout.Height;
                            taskLayout.MinimumSize = new Size(Convert.ToInt32(Math.Round(layoutPanel.Width * .95, 0, MidpointRounding.ToZero)), 0);
                            taskLayout.MaximumSize = new Size(Convert.ToInt32(Math.Round(layoutPanel.Width * .95, 0, MidpointRounding.ToZero)), 0);
                            taskLayout.AutoSize = true;
                            taskLayout.HorizontalScroll.Enabled = false;
                            taskLayout.MouseDown += TaskLayout_MouseDown;

                            layoutPanel.Controls.Add(taskLayout);


                            Label taskheaderLabel = new Label();
                            taskheaderLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                            taskheaderLabel.Text = task.TaskName;
                            taskheaderLabel.BorderStyle = BorderStyle.None;
                            height = taskheaderLabel.Height;
                            taskheaderLabel.Size = new Size(taskLayout.Width, height);
                            taskheaderLabel.Padding = new Padding(0);
                            taskheaderLabel.Margin = new Padding(0, 5, 0, 5);
                            taskheaderLabel.Name = task.ID.ToString();
                            taskheaderLabel.TextAlign = ContentAlignment.MiddleLeft;
                            taskheaderLabel.AutoSize = true;
                            taskheaderLabel.MouseDown += ParentDrag;

                            taskLayout.Controls.Add(taskheaderLabel);
                            taskLayout.SetFlowBreak(taskheaderLabel, true);

                            Button newAttachmentButton = new Button();
                            newAttachmentButton.Text = "New File";
                            newAttachmentButton.FlatAppearance.BorderSize = 0;
                            newAttachmentButton.FlatStyle = FlatStyle.Flat;
                            height = 30;
                            newAttachmentButton.Size = new Size((taskLayout.Width / 3), height);
                            newAttachmentButton.Margin = new Padding(0);
                            newAttachmentButton.Padding = new Padding(0);
                            newAttachmentButton.ForeColor = Color.Red;
                            newAttachmentButton.Name = task.ID.ToString();
                            newAttachmentButton.Click += AddAttachment;

                            taskLayout.Controls.Add(newAttachmentButton);


                            Button newActivityButton = new Button();
                            newActivityButton.Text = "New Activity";
                            newActivityButton.FlatAppearance.BorderSize = 0;
                            newActivityButton.FlatStyle = FlatStyle.Flat;
                            height = 30;
                            newActivityButton.Size = new Size((taskLayout.Width / 3), height);
                            newActivityButton.Margin = new Padding(0);
                            newActivityButton.Padding = new Padding(0);
                            newActivityButton.ForeColor = Color.Blue;
                            newActivityButton.Name = task.ID.ToString();
                            newActivityButton.Click += AddActivity;

                            taskLayout.Controls.Add(newActivityButton);

                            Button editTaskButton = new Button();
                            editTaskButton.Text = "View Task";
                            editTaskButton.FlatAppearance.BorderSize = 0;
                            editTaskButton.FlatStyle = FlatStyle.Flat;
                            height = 30;
                            editTaskButton.Size = new Size((taskLayout.Width / 3) - 1, height);
                            editTaskButton.Margin = new Padding(0);
                            editTaskButton.Padding = new Padding(0);
                            editTaskButton.ForeColor = Color.Green;
                            editTaskButton.Name = task.ID.ToString();
                            editTaskButton.Click += EditTask;

                            taskLayout.Controls.Add(editTaskButton);
                            taskLayout.SetFlowBreak(editTaskButton, true);


                            Label layoutUpdated = new Label();
                            layoutUpdated.Text = "Last Updated: " + task.LastUpdated.ToString();
                            layoutUpdated.Width = Convert.ToInt32(layoutPanel.Width);
                            layoutUpdated.Font = new Font("Arial", 9, FontStyle.Bold);
                            layoutUpdated.Margin = new Padding(0, 0, 0, 0);
                            layoutUpdated.Padding = new Padding(0);
                            layoutUpdated.BackColor = Color.LightGray;
                            layoutUpdated.TextAlign = ContentAlignment.MiddleLeft;

                            taskLayout.Controls.Add(layoutUpdated);


                        }



                    }
                }



            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void AddAttachment(object? sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;

                if (control == null)
                {
                    return;
                }

                Task task = new Task();
                task = Task.GetObjectByID(control.Name);

                FormNewAttachment attachment = new FormNewAttachment();
                attachment.selectedTask = task;
                attachment.ShowDialog();
                PopulateGrid();


            }
            catch (Exception ex)
            {

            }
        }

        private void LayoutPanel_DragOver(object? sender, DragEventArgs e)
        {
            Control control = sender as Control;
            control.BackColor = Color.LightBlue;
            e.Effect = DragDropEffects.Copy;
        }

        private void LayoutPanel_DragEnter(object? sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void LayoutPanel_DragDrop(object? sender, DragEventArgs e)
        {
            try
            {
                MyWrapper wrapper = (MyWrapper)e.Data.GetData(typeof(MyWrapper));

                Control list = sender as Control;
                string listID = list.Name;

                list.Controls.Add(wrapper.Control);

                Point p = list.PointToClient(new Point(e.X, e.Y));
                var item = list.GetChildAtPoint(p);
                var index = list.Controls.GetChildIndex(item, false);

                if (index <= 0)
                {
                    index = 1;
                }

                list.Controls.SetChildIndex(wrapper.Control, index);

                foreach (Control control in list.Controls)
                {
                    if (list.Controls.IndexOf(control) == 0)
                    {
                        continue;
                    }

                    Task taskPosition = new Task();
                    taskPosition.ID = Convert.ToInt32(control.Name);
                    taskPosition.DisplayOrder = list.Controls.IndexOf(control);
                    taskPosition.UpdateDisplayOrder();
                }


                string taskID = wrapper.Control.Name;

                Task task = new Task();
                task.ID = Convert.ToInt32(taskID);
                task.StatusID = Convert.ToInt32(listID);
                task.UpdateTaskList();

                PopulateGrid();






            }
            catch (Exception ex)
            {

            }
        }

        private void LayoutPanel_DragLeave(object? sender, EventArgs e)
        {
            Control control = sender as Control;
            control.BackColor = SystemColors.Control;
        }

        private void ParentDrag(object? sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            control.DoDragDrop(new MyWrapper(control.Parent), DragDropEffects.All);
        }

        internal partial class MyWrapper
        {
            private Control _control;

            public MyWrapper(Control control)
            {
                _control = control;
            }

            public Control Control
            {
                get
                {
                    return _control;
                }
            }
        }

        private void TaskLayout_MouseDown(object? sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            control.DoDragDrop(new MyWrapper(control), DragDropEffects.All);
        }



        private void EditTask(object? sender, EventArgs e)
        {
            try
            {
                Control sent = sender as Control;

                Task taskTask = Task.GetObjectByID(sent.Name);

                if (taskTask == null)
                {
                    return;
                }

                FormTask f = new FormTask();
                f.selectedTask = taskTask;
                f.ShowDialog();
                PopulateGrid();

            }
            catch (Exception ex)
            {

            }
        }

        private void AddActivity(object? sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;

                if (control == null)
                {
                    return;
                }

                Task task = new Task();
                task = Task.GetObjectByID(control.Name);

                FormNewActivity activity = new FormNewActivity();
                activity.selectedTask = task;
                activity.ShowDialog();
                PopulateGrid();


            }
            catch (Exception ex)
            {

            }
        }

        private void ButtonNewProject_Click(object sender, EventArgs e)
        {
            if (Status.GetListOfObjects().Count == 0)
            {
                GlobalCode.ShowMSGBox("You must create a status before adding a task.", MessageBoxIcon.Warning);
                return;
            }


            FormTask f = new FormTask();
            f.newTask = true;
            f.selectedTask = null;
            f.ShowDialog();
            PopulateGrid();
        }

        private void CheckBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxEnabled.Checked == true)
            {
                ButtonExportData.Enabled = true;
            }
            else
            {
                ButtonExportData.Enabled = false;
            }


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
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = null;


            try
            {
                



                string sql = "SELECT TaskName AS Task, Statuses.StatusName AS Status, LastUpdated " +
                    "FROM Tasks " +
                    "INNER JOIN Statuses ON Statuses.ID = Tasks.StatusID " +
                    "WHERE Enabled = 1 " +
                    "ORDER BY LastUpdated DESC";


                DataTable dt = Execute.ExecuteSelectReturnDT(Connection.InitMyTaskManagerConnection(), sql);

                if (dt == null || dt.Rows.Count == 0)
                {
                    GlobalCode.ShowMSGBox("No active projects to export.", MessageBoxIcon.Warning);
                    return;
                }

                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = "Enabled Projects";

                int rowIndex = 1;

                foreach (DataRow dr in dt.Rows)
                {
                    int colIndex = 1;

                    if (rowIndex == 1)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {

                            excelSheet.Cells[rowIndex, colIndex].Value = col.ColumnName;

                            colIndex++;

                        }

                        rowIndex++;
                        colIndex = 1;

                    }

                    foreach (DataColumn col in dt.Columns)
                    {

                        string fieldValue = dr[col].ToString();
                        excelSheet.Cells[rowIndex, colIndex].Value = fieldValue;

                        colIndex++;

                    }

                    rowIndex++;

                }


                excelSheet.Columns.AutoFit();

                string fileName = @"C:\MyTaskManager\OpenedFiles\ProjectExport_" + DateTime.Now.ToString("MMddyyyy") + ".xlsx";
                excelworkBook.SaveAs(fileName);
                excelworkBook.Close(0);
                excel.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelworkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

                Process.Start(new ProcessStartInfo(fileName) {UseShellExecute = true });

            }
            catch (Exception ex)
            {
                excelworkBook.Close(0);
                excel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelworkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);


                excelworkBook.Close(0);
                excel.Quit();
                GlobalCode.ExceptionMessageBox();
            }
        }
    }
}

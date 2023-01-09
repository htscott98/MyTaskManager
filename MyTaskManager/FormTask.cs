using System.Data;


namespace MyTaskManager
{
    public partial class FormTask : Form
    {

        public bool newTask;
        public Task selectedTask;

        public FormTask()
        {
            InitializeComponent();
        }

        private void FormProject_Load(object sender, EventArgs e)
        {
            this.Text = GlobalCode.GetApplicationName();
            PopulateStatuses();

            if (newTask == true)
            {
                ButtonNewActivity.Enabled = false;
                ButtonNewAttachment.Enabled = false;
            }
            else
            {
                if (selectedTask == null || selectedTask.ID == 0)
                {
                    this.Close();
                }

                PopulateTaskInfo();
                PopulateActivity();
                PopulateAttachments();

            }


        }

        private void PopulateStatuses()
        {
            try
            {
                ComboBoxStatus.Items.Clear();

                List<Status> allStatuses = Status.GetListOfObjects();

                ComboBoxStatus.Items.Add("");

                foreach (Status status in allStatuses)
                {
                    ComboBoxStatus.Items.Add(status);
                }

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void PopulateTaskInfo()
        {
            try
            {
                TextBoxTask.Text = selectedTask.TaskName;

                if (selectedTask.StatusID != 0)
                {
                    Status currentStatus = Status.GetObjectByID(selectedTask.StatusID.ToString());

                    ComboBoxStatus.Text = currentStatus.StatusName;
                }

                TextBoxLastUpdated.Text = selectedTask.LastUpdated.ToString();
                CheckBoxEnabled.Checked= selectedTask.Enabled;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void PopulateActivity()
        {
            try
            {
                List<Activity> allActivity = Activity.GetListOfObjectsByTaskID(selectedTask.ID.ToString());

                RichTextBoxActivity.Clear();

                foreach (Activity activity in allActivity)
                {

                    RichTextBoxActivity.SelectionFont = new Font(RichTextBoxActivity.Font.Name, 12, FontStyle.Bold);
                    RichTextBoxActivity.AppendText(activity.ActivityTimestamp.ToString() + "\n");
                    RichTextBoxActivity.SelectionFont = new Font(RichTextBoxActivity.Font.Name, 10, FontStyle.Regular);
                    RichTextBoxActivity.AppendText(activity.ActivityName + "\n\n");
                }

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (TextBoxTask.Text == "" || ComboBoxStatus.Text == "")
                {
                    GlobalCode.ShowMSGBox("Verify you have entered a task, display order, and status.", MessageBoxIcon.Warning);
                    return;
                }


                if (newTask == true)
                {
                    Task task = new Task();
                    task.TaskName = TextBoxTask.Text;

                    if (ComboBoxStatus.Text == "")
                    {
                        task.StatusID = 0;
                    }
                    else
                    {

                        Status currentStatus = (Status)ComboBoxStatus.SelectedItem;
                        task.StatusID = currentStatus.ID;
                    }

                    task.DisplayOrder = 0;
                    task.LastUpdated = DateTime.Now;
                    task.Enabled = CheckBoxEnabled.Checked;

                    if (task.InsertRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully.");
                        newTask = false;
                        selectedTask = Task.GetObjectByID(task.ID.ToString());
                        PopulateTaskInfo();
                        ButtonNewActivity.Enabled = true;
                        ButtonNewAttachment.Enabled = true;
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Unable to save data.", MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    selectedTask.TaskName = TextBoxTask.Text;

                    if (ComboBoxStatus.Text == "")
                    {
                        selectedTask.StatusID = 0;
                    }
                    else
                    {

                        Status currentStatus = (Status)ComboBoxStatus.SelectedItem;
                        selectedTask.StatusID = currentStatus.ID;
                    }

                    selectedTask.DisplayOrder = selectedTask.DisplayOrder;
                    selectedTask.LastUpdated = DateTime.Now;
                    selectedTask.Enabled = CheckBoxEnabled.Checked;

                    if (selectedTask.UpdateRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully.");
                        this.Close();
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Unable to save data.", MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void PopulateAttachments()
        {
            try
            {
                DataGridViewAttachments.DataSource = null;
                DataTable dt = Attachments.GetDataTableByTaskID(selectedTask.ID.ToString());

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataGridViewAttachments.DataSource = dt;
                    SetDisplayProperties();


                }


   




            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void SetDisplayProperties()
        {
            this.DataGridViewAttachments.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.DataGridViewAttachments.AllowUserToAddRows = false;
            this.DataGridViewAttachments.AllowUserToDeleteRows = false;
            this.DataGridViewAttachments.AllowUserToResizeRows = false;
            this.DataGridViewAttachments.AllowUserToOrderColumns = true;
            this.DataGridViewAttachments.MultiSelect = true;
            this.DataGridViewAttachments.ReadOnly = true;
            this.DataGridViewAttachments.RowHeadersVisible = false;
            this.DataGridViewAttachments.AllowUserToResizeColumns = true;
            this.DataGridViewAttachments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewAttachments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewAttachments.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.DataGridViewAttachments.Columns["ID"].Visible = false;
            this.DataGridViewAttachments.Columns["TaskID"].Visible = false;
            this.DataGridViewAttachments.Columns["Attachment"].Visible = false;
        }

        private void ButtonNewActivity_Click(object sender, EventArgs e)
        {
            FormNewActivity f = new FormNewActivity();
            f.selectedTask = selectedTask;
            f.ShowDialog();
            PopulateTaskInfo();
            PopulateActivity();
        }

        private void ButtonNewAttachment_Click(object sender, EventArgs e)
        {
            FormNewAttachment f = new FormNewAttachment();
            f.selectedTask = selectedTask;
            f.ShowDialog();
            PopulateAttachments();
        }

        private void DataGridViewAttachments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridViewAttachments.SelectedRows.Count == 0)
                {
                    return;
                }

                string id = DataGridViewAttachments.SelectedRows[0].Cells["ID"].Value.ToString();

                if (string.IsNullOrEmpty(id) == true)
                {
                    return;
                }

                Attachments o = Attachments.GetObjectByID(id);

                if (o == null || o.ID == 0)
                {
                    return;
                }

                byte[] buffer = (byte[])o.Attachment;

                string filePath = @"C:\MyTaskManager\OpenedFiles\";
                string fileName = o.Name;
                File.WriteAllBytes(filePath + fileName, buffer);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath + fileName) { UseShellExecute = true });



            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void DataGridViewAttachments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (DataGridViewAttachments.SelectedRows.Count == 0)
                {
                    return;
                }

                if (e.Button != MouseButtons.Right)
                {
                    return;
                }

                string id = DataGridViewAttachments.SelectedRows[0].Cells["ID"].Value.ToString();

                if (string.IsNullOrEmpty(id) == true)
                {
                    return;
                }

                Attachments o = Attachments.GetObjectByID(id);

                if (GlobalCode.ShowMSGBox("Would you like to delete the file " + o.Name + "?", MessageBoxIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                if (o.DeleteRecord() == true)
                {
                    PopulateAttachments();
                }
                else
                {
                    GlobalCode.ShowMSGBox("Unable to delete file. Try again or contact the developer.", MessageBoxIcon.Error);
                }



            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void MenuItemFileBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                if (RichTextBoxActivity.SelectedText == null)
                {
                    return;
                }

                string startLocation = RichTextBoxActivity.SelectedText.Trim();

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(startLocation) { UseShellExecute = true });


            }
            catch (Exception ex)
            {
                GlobalCode.ShowMSGBox("Unable to open location. Verify that you have selected a valid path.", MessageBoxIcon.Error);
            }
        }
    }
}

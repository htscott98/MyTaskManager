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
            }
            else
            {
                if (selectedTask == null || selectedTask.ID == 0)
                {
                    this.Close();
                }

                PopulateTaskInfo();
                PopulateActivity();

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

                TextBoxDisplayOrder.Text = selectedTask.DisplayOrder.ToString();
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

                if (TextBoxTask.Text == "" || TextBoxDisplayOrder.Text == "")
                {
                    GlobalCode.ShowMSGBox("Verify you have entered a task and display order.", MessageBoxIcon.Warning);
                    return;
                }

                int testorder;

                if (int.TryParse(TextBoxDisplayOrder.Text, out testorder) == false)
                {
                    GlobalCode.ShowMSGBox("Verify that display order is numeric only");
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

                    task.DisplayOrder = Convert.ToInt32(TextBoxDisplayOrder.Text);
                    task.LastUpdated = DateTime.Now;
                    task.Enabled = CheckBoxEnabled.Checked;

                    if (task.InsertRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully.");
                        newTask = false;
                        selectedTask = task;
                        PopulateTaskInfo();
                        ButtonNewActivity.Enabled = true;
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

                    selectedTask.DisplayOrder = Convert.ToInt32(TextBoxDisplayOrder.Text);
                    selectedTask.LastUpdated = DateTime.Now;
                    selectedTask.Enabled = CheckBoxEnabled.Checked;

                    if (selectedTask.UpdateRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully.");
                        newTask = false;
                        PopulateTaskInfo();
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

        private void ButtonNewActivity_Click(object sender, EventArgs e)
        {
            FormNewActivity f = new FormNewActivity();
            f.selectedTask = selectedTask;
            f.ShowDialog();
            PopulateTaskInfo();
            PopulateActivity();
        }
    }
}

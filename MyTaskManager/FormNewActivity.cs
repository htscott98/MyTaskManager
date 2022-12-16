namespace MyTaskManager
{
    public partial class FormNewActivity : Form
    {

        public Task selectedTask;


        public FormNewActivity()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxActivity.Text == "")
                {
                    GlobalCode.ShowMSGBox("Verify you have entered text to save.", MessageBoxIcon.Warning);
                    return;
                }

                Activity o = new Activity();
                o.TaskID = selectedTask.ID;
                o.ActivityName = TextBoxActivity.Text;
                o.ActivityTimestamp = DateTime.Now;

                if (o.InsertRecord() == true)
                {
                    selectedTask.LastUpdated = DateTime.Now;

                    if (selectedTask.UpdateRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully.");
                        this.Close();
                    }

                }
                else
                {
                    GlobalCode.ShowMSGBox("Unable to save data. Try again or contact the developer.");
                    return;
                }


            }
            catch
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void FormNewActivity_Load(object sender, EventArgs e)
        {
            this.Text = GlobalCode.GetApplicationName();

            if (selectedTask == null || selectedTask.ID == 0)
            {
                this.Close();
            }

            LabelSelectedTask.Text = selectedTask.TaskName;


        }
    }
}

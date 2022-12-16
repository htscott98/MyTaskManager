using System.Data;

namespace MyTaskManager
{
    public partial class FormManageStatuses : Form
    {

        public bool newStatus;

        public FormManageStatuses()
        {
            InitializeComponent();
        }

        private void FormManageStatuses_Load(object sender, EventArgs e)
        {
            this.Text = GlobalCode.GetApplicationName();

            DisableControls();
            PopulateGrid();

        }

        private void PopulateGrid()
        {
            try
            {
                DataGridViewStatuses.DataSource = null;
                DataTable dt = Status.GetDataTable();
                DataGridViewStatuses.DataSource = dt;
                SetDisplayProperties();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void SetDisplayProperties()
        {
            this.DataGridViewStatuses.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.DataGridViewStatuses.AllowUserToAddRows = false;
            this.DataGridViewStatuses.AllowUserToDeleteRows = false;
            this.DataGridViewStatuses.AllowUserToResizeRows = false;
            this.DataGridViewStatuses.AllowUserToOrderColumns = true;
            this.DataGridViewStatuses.MultiSelect = true;
            this.DataGridViewStatuses.ReadOnly = true;
            this.DataGridViewStatuses.RowHeadersVisible = false;
            this.DataGridViewStatuses.AllowUserToResizeColumns = true;
            this.DataGridViewStatuses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewStatuses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewStatuses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.DataGridViewStatuses.Columns["ID"].Visible = false;

        }

        private void DisableControls()
        {
            TextBoxStatus.Enabled = false;
            TextBoxStatus.Text = "";
            TextBoxDisplayOrder.Enabled = false;
            TextBoxDisplayOrder.Text = "";
            ButtonCancel.Enabled = false;
            ButtonSave.Enabled = false;
        }

        private void EnableControls()
        {
            TextBoxStatus.Enabled = true;
            TextBoxDisplayOrder.Enabled = true;
            ButtonCancel.Enabled = true;
            ButtonSave.Enabled = true;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DisableControls();
        }

        private void ButtonNewStatus_Click(object sender, EventArgs e)
        {
            DisableControls();
            EnableControls();

            newStatus = true;

        }

        private void DataGridViewStatuses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridViewStatuses.SelectedRows.Count == 0)
                {
                    return;
                }

                string id = DataGridViewStatuses.SelectedRows[0].Cells["ID"].Value.ToString();

                if (string.IsNullOrEmpty(id) == true)
                {
                    return;
                }

                newStatus = false;
                Status o = Status.GetObjectByID(id);

                if (o == null || o.ID == 0)
                {
                    return;
                }

                EnableControls();
                TextBoxStatus.Text = o.StatusName;
                TextBoxDisplayOrder.Text = o.DisplayOrder.ToString();

            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (TextBoxStatus.Text == "" || TextBoxDisplayOrder.Text == "")
                {
                    GlobalCode.ShowMSGBox("Verify you have entered a status and display order", MessageBoxIcon.Warning);
                    return;
                }

                int testorder;

                if (int.TryParse(TextBoxDisplayOrder.Text, out testorder) == false)
                {
                    GlobalCode.ShowMSGBox("Verify that display order is numeric only");
                    return;
                }

                if (newStatus == true)
                {
                    Status o = new Status();
                    o.StatusName = TextBoxStatus.Text;
                    o.DisplayOrder = Convert.ToInt32(TextBoxDisplayOrder.Text);

                    if (o.InsertRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully");
                        DisableControls();
                        PopulateGrid();
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Unable to save data. Try again or contact the developer.", MessageBoxIcon.Error);
                        return;
                    }

                }
                else
                {
                    Status o = Status.GetObjectByID(DataGridViewStatuses.SelectedRows[0].Cells["ID"].Value.ToString());
                    o.StatusName = TextBoxStatus.Text;
                    o.DisplayOrder = Convert.ToInt32(TextBoxDisplayOrder.Text);

                    if (o.UpdateRecord() == true)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully");
                        DisableControls();
                        PopulateGrid();
                    }
                    else
                    {
                        GlobalCode.ShowMSGBox("Unable to save data. Try again or contact the developer.", MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionMessageBox();
            }
        }
    }
}

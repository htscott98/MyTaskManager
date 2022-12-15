using Microsoft.Data.SqlClient;
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
    public partial class FormNewAttachment : Form
    {

        public Task selectedTask;

        public FormNewAttachment()
        {
            InitializeComponent();
        }

        private void FormNewAttachment_Load(object sender, EventArgs e)
        {
            this.Text = GlobalCode.GetApplicationName();

            if (selectedTask == null)
            {
                this.Close();
            }

        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxFile.Text))
                {
                    return;
                }

                FileInfo fi = new FileInfo(TextBoxFile.Text);
                var data = File.ReadAllBytes(TextBoxFile.Text);

                using (var conn = new SqlConnection("Server=localhost; Database=MyTaskManager; Trusted_Connection=True; Encrypt=false;"))
                using (var command = new SqlCommand("InsertFile", conn)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    command.Parameters.Add(new SqlParameter("@TaskID", selectedTask.ID));
                    command.Parameters.Add(new SqlParameter("@Name", fi.Name));
                    command.Parameters.Add(new SqlParameter("@Attachment", data));
                    command.Parameters.Add(new SqlParameter("@UploadedTimestamp", DateTime.Now));

                    conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                    {
                        GlobalCode.ShowMSGBox("Data has been saved successfully.");
                        this.Close();
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

        private void ButtonFindFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult result = openFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                string fileName = openFile.FileName;

                if (string.IsNullOrEmpty(fileName) == false)
                {
                    TextBoxFile.Text = fileName;
                }
            }
        }
    }
}

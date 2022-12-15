namespace MyTaskManager
{
    partial class FormNewAttachment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonFindFile = new System.Windows.Forms.Button();
            this.ButtonUpload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxFile
            // 
            this.TextBoxFile.Enabled = false;
            this.TextBoxFile.Location = new System.Drawing.Point(12, 35);
            this.TextBoxFile.Name = "TextBoxFile";
            this.TextBoxFile.Size = new System.Drawing.Size(279, 25);
            this.TextBoxFile.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "File";
            // 
            // ButtonFindFile
            // 
            this.ButtonFindFile.Location = new System.Drawing.Point(297, 28);
            this.ButtonFindFile.Name = "ButtonFindFile";
            this.ButtonFindFile.Size = new System.Drawing.Size(75, 32);
            this.ButtonFindFile.TabIndex = 2;
            this.ButtonFindFile.Text = "Find";
            this.ButtonFindFile.UseVisualStyleBackColor = true;
            this.ButtonFindFile.Click += new System.EventHandler(this.ButtonFindFile_Click);
            // 
            // ButtonUpload
            // 
            this.ButtonUpload.Location = new System.Drawing.Point(130, 91);
            this.ButtonUpload.Name = "ButtonUpload";
            this.ButtonUpload.Size = new System.Drawing.Size(124, 32);
            this.ButtonUpload.TabIndex = 3;
            this.ButtonUpload.Text = "Upload File";
            this.ButtonUpload.UseVisualStyleBackColor = true;
            this.ButtonUpload.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // FormNewAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.ButtonUpload);
            this.Controls.Add(this.ButtonFindFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxFile);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "FormNewAttachment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormNewAttachment";
            this.Load += new System.EventHandler(this.FormNewAttachment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TextBoxFile;
        private Label label1;
        private Button ButtonFindFile;
        private Button ButtonUpload;
    }
}
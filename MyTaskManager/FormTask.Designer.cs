namespace MyTaskManager
{
    partial class FormTask
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
            this.components = new System.ComponentModel.Container();
            this.RichTextBoxActivity = new System.Windows.Forms.RichTextBox();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemFileBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonNewActivity = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxTask = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxLastUpdated = new System.Windows.Forms.TextBox();
            this.CheckBoxEnabled = new System.Windows.Forms.CheckBox();
            this.DataGridViewAttachments = new System.Windows.Forms.DataGridView();
            this.ButtonNewAttachment = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAttachments)).BeginInit();
            this.SuspendLayout();
            // 
            // RichTextBoxActivity
            // 
            this.RichTextBoxActivity.ContextMenuStrip = this.MenuStrip;
            this.RichTextBoxActivity.DetectUrls = false;
            this.RichTextBoxActivity.Location = new System.Drawing.Point(323, 32);
            this.RichTextBoxActivity.Name = "RichTextBoxActivity";
            this.RichTextBoxActivity.ReadOnly = true;
            this.RichTextBoxActivity.Size = new System.Drawing.Size(323, 379);
            this.RichTextBoxActivity.TabIndex = 0;
            this.RichTextBoxActivity.TabStop = false;
            this.RichTextBoxActivity.Text = "";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFileBrowser});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(153, 26);
            // 
            // MenuItemFileBrowser
            // 
            this.MenuItemFileBrowser.Name = "MenuItemFileBrowser";
            this.MenuItemFileBrowser.Size = new System.Drawing.Size(152, 22);
            this.MenuItemFileBrowser.Text = "Open Location";
            this.MenuItemFileBrowser.Click += new System.EventHandler(this.MenuItemFileBrowser_Click);
            // 
            // ButtonNewActivity
            // 
            this.ButtonNewActivity.Location = new System.Drawing.Point(501, 417);
            this.ButtonNewActivity.Name = "ButtonNewActivity";
            this.ButtonNewActivity.Size = new System.Drawing.Size(145, 32);
            this.ButtonNewActivity.TabIndex = 6;
            this.ButtonNewActivity.Text = "New Activity";
            this.ButtonNewActivity.UseVisualStyleBackColor = true;
            this.ButtonNewActivity.Click += new System.EventHandler(this.ButtonNewActivity_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Task";
            // 
            // TextBoxTask
            // 
            this.TextBoxTask.Location = new System.Drawing.Point(12, 32);
            this.TextBoxTask.Multiline = true;
            this.TextBoxTask.Name = "TextBoxTask";
            this.TextBoxTask.Size = new System.Drawing.Size(305, 283);
            this.TextBoxTask.TabIndex = 1;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(172, 417);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(145, 32);
            this.ButtonSave.TabIndex = 5;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(12, 417);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(145, 32);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status";
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Location = new System.Drawing.Point(12, 338);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(305, 25);
            this.ComboBoxStatus.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Last Updated";
            // 
            // TextBoxLastUpdated
            // 
            this.TextBoxLastUpdated.Location = new System.Drawing.Point(12, 386);
            this.TextBoxLastUpdated.Name = "TextBoxLastUpdated";
            this.TextBoxLastUpdated.ReadOnly = true;
            this.TextBoxLastUpdated.Size = new System.Drawing.Size(225, 25);
            this.TextBoxLastUpdated.TabIndex = 10;
            this.TextBoxLastUpdated.TabStop = false;
            // 
            // CheckBoxEnabled
            // 
            this.CheckBoxEnabled.AutoSize = true;
            this.CheckBoxEnabled.Location = new System.Drawing.Point(243, 388);
            this.CheckBoxEnabled.Name = "CheckBoxEnabled";
            this.CheckBoxEnabled.Size = new System.Drawing.Size(74, 21);
            this.CheckBoxEnabled.TabIndex = 4;
            this.CheckBoxEnabled.Text = "Enabled";
            this.CheckBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // DataGridViewAttachments
            // 
            this.DataGridViewAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAttachments.Location = new System.Drawing.Point(652, 32);
            this.DataGridViewAttachments.Name = "DataGridViewAttachments";
            this.DataGridViewAttachments.RowTemplate.Height = 25;
            this.DataGridViewAttachments.Size = new System.Drawing.Size(320, 377);
            this.DataGridViewAttachments.TabIndex = 12;
            this.DataGridViewAttachments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAttachments_CellDoubleClick);
            this.DataGridViewAttachments.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewAttachments_CellMouseClick);
            // 
            // ButtonNewAttachment
            // 
            this.ButtonNewAttachment.Location = new System.Drawing.Point(827, 417);
            this.ButtonNewAttachment.Name = "ButtonNewAttachment";
            this.ButtonNewAttachment.Size = new System.Drawing.Size(145, 32);
            this.ButtonNewAttachment.TabIndex = 13;
            this.ButtonNewAttachment.Text = "New File";
            this.ButtonNewAttachment.UseVisualStyleBackColor = true;
            this.ButtonNewAttachment.Click += new System.EventHandler(this.ButtonNewAttachment_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(652, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Files";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Activity";
            // 
            // FormTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ButtonNewAttachment);
            this.Controls.Add(this.DataGridViewAttachments);
            this.Controls.Add(this.CheckBoxEnabled);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxLastUpdated);
            this.Controls.Add(this.ComboBoxStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.TextBoxTask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonNewActivity);
            this.Controls.Add(this.RichTextBoxActivity);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FormTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormShowProject";
            this.Load += new System.EventHandler(this.FormProject_Load);
            this.MenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAttachments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox RichTextBoxActivity;
        private Button ButtonNewActivity;
        private Label label1;
        private TextBox TextBoxTask;
        private Button ButtonSave;
        private Button ButtonCancel;
        private Label label2;
        private ComboBox ComboBoxStatus;
        private Label label4;
        private TextBox TextBoxLastUpdated;
        private CheckBox CheckBoxEnabled;
        private DataGridView DataGridViewAttachments;
        private Button ButtonNewAttachment;
        private ContextMenuStrip MenuStrip;
        private ToolStripMenuItem MenuItemFileBrowser;
        private Label label5;
        private Label label6;
    }
}
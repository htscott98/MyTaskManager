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
            this.RichTextBoxActivity = new System.Windows.Forms.RichTextBox();
            this.ButtonNewActivity = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxTask = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.TextBoxDisplayOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxLastUpdated = new System.Windows.Forms.TextBox();
            this.CheckBoxEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // RichTextBoxActivity
            // 
            this.RichTextBoxActivity.Location = new System.Drawing.Point(323, 12);
            this.RichTextBoxActivity.Name = "RichTextBoxActivity";
            this.RichTextBoxActivity.ReadOnly = true;
            this.RichTextBoxActivity.Size = new System.Drawing.Size(449, 399);
            this.RichTextBoxActivity.TabIndex = 0;
            this.RichTextBoxActivity.TabStop = false;
            this.RichTextBoxActivity.Text = "";
            // 
            // ButtonNewActivity
            // 
            this.ButtonNewActivity.Location = new System.Drawing.Point(627, 417);
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
            this.TextBoxTask.Size = new System.Drawing.Size(305, 128);
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
            this.label2.Location = new System.Drawing.Point(12, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status";
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Location = new System.Drawing.Point(12, 183);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(305, 25);
            this.ComboBoxStatus.TabIndex = 2;
            // 
            // TextBoxDisplayOrder
            // 
            this.TextBoxDisplayOrder.Location = new System.Drawing.Point(12, 231);
            this.TextBoxDisplayOrder.Name = "TextBoxDisplayOrder";
            this.TextBoxDisplayOrder.Size = new System.Drawing.Size(305, 25);
            this.TextBoxDisplayOrder.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Display Order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Last Updated";
            // 
            // TextBoxLastUpdated
            // 
            this.TextBoxLastUpdated.Location = new System.Drawing.Point(12, 279);
            this.TextBoxLastUpdated.Name = "TextBoxLastUpdated";
            this.TextBoxLastUpdated.ReadOnly = true;
            this.TextBoxLastUpdated.Size = new System.Drawing.Size(305, 25);
            this.TextBoxLastUpdated.TabIndex = 10;
            this.TextBoxLastUpdated.TabStop = false;
            // 
            // CheckBoxEnabled
            // 
            this.CheckBoxEnabled.AutoSize = true;
            this.CheckBoxEnabled.Location = new System.Drawing.Point(12, 310);
            this.CheckBoxEnabled.Name = "CheckBoxEnabled";
            this.CheckBoxEnabled.Size = new System.Drawing.Size(74, 21);
            this.CheckBoxEnabled.TabIndex = 4;
            this.CheckBoxEnabled.Text = "Enabled";
            this.CheckBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // FormTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CheckBoxEnabled);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxLastUpdated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxDisplayOrder);
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
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormShowProject";
            this.Load += new System.EventHandler(this.FormProject_Load);
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
        private TextBox TextBoxDisplayOrder;
        private Label label3;
        private Label label4;
        private TextBox TextBoxLastUpdated;
        private CheckBox CheckBoxEnabled;
    }
}
namespace MyTaskManager
{
    partial class FormManageStatuses
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
            this.DataGridViewStatuses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxStatus = new System.Windows.Forms.TextBox();
            this.TextBoxDisplayOrder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonNewStatus = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStatuses)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewStatuses
            // 
            this.DataGridViewStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewStatuses.Location = new System.Drawing.Point(12, 12);
            this.DataGridViewStatuses.Name = "DataGridViewStatuses";
            this.DataGridViewStatuses.RowTemplate.Height = 25;
            this.DataGridViewStatuses.Size = new System.Drawing.Size(296, 199);
            this.DataGridViewStatuses.TabIndex = 0;
            this.DataGridViewStatuses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewStatuses_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status";
            // 
            // TextBoxStatus
            // 
            this.TextBoxStatus.Location = new System.Drawing.Point(314, 32);
            this.TextBoxStatus.Name = "TextBoxStatus";
            this.TextBoxStatus.Size = new System.Drawing.Size(258, 25);
            this.TextBoxStatus.TabIndex = 2;
            // 
            // TextBoxDisplayOrder
            // 
            this.TextBoxDisplayOrder.Location = new System.Drawing.Point(314, 80);
            this.TextBoxDisplayOrder.Name = "TextBoxDisplayOrder";
            this.TextBoxDisplayOrder.Size = new System.Drawing.Size(258, 25);
            this.TextBoxDisplayOrder.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Display Order";
            // 
            // ButtonNewStatus
            // 
            this.ButtonNewStatus.Location = new System.Drawing.Point(184, 217);
            this.ButtonNewStatus.Name = "ButtonNewStatus";
            this.ButtonNewStatus.Size = new System.Drawing.Size(124, 32);
            this.ButtonNewStatus.TabIndex = 6;
            this.ButtonNewStatus.Text = "New Status";
            this.ButtonNewStatus.UseVisualStyleBackColor = true;
            this.ButtonNewStatus.Click += new System.EventHandler(this.ButtonNewStatus_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(444, 111);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(124, 32);
            this.ButtonSave.TabIndex = 7;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(314, 111);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(124, 32);
            this.ButtonCancel.TabIndex = 8;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormManageStatuses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonNewStatus);
            this.Controls.Add(this.TextBoxDisplayOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridViewStatuses);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "FormManageStatuses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormManageStatuses";
            this.Load += new System.EventHandler(this.FormManageStatuses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStatuses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView DataGridViewStatuses;
        private Label label1;
        private TextBox TextBoxStatus;
        private TextBox TextBoxDisplayOrder;
        private Label label2;
        private Button ButtonNewStatus;
        private Button ButtonSave;
        private Button ButtonCancel;
    }
}
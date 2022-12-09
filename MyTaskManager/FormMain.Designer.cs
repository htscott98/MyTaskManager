namespace MyTaskManager
{
    partial class FormMain
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
            this.DataGridViewProjects = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.LabelRowCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonNewProject = new System.Windows.Forms.Button();
            this.ButtonManageStatuses = new System.Windows.Forms.Button();
            this.CheckBoxEnabled = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewProjects
            // 
            this.DataGridViewProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewProjects.Location = new System.Drawing.Point(12, 60);
            this.DataGridViewProjects.Name = "DataGridViewProjects";
            this.DataGridViewProjects.RowTemplate.Height = 25;
            this.DataGridViewProjects.Size = new System.Drawing.Size(760, 351);
            this.DataGridViewProjects.TabIndex = 0;
            this.DataGridViewProjects.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewProjects_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Location = new System.Drawing.Point(12, 29);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(399, 25);
            this.TextBoxSearch.TabIndex = 2;
            this.TextBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            // 
            // LabelRowCount
            // 
            this.LabelRowCount.AutoSize = true;
            this.LabelRowCount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelRowCount.Location = new System.Drawing.Point(12, 417);
            this.LabelRowCount.Name = "LabelRowCount";
            this.LabelRowCount.Size = new System.Drawing.Size(19, 18);
            this.LabelRowCount.TabIndex = 3;
            this.LabelRowCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(617, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Double click to open task";
            // 
            // ButtonNewProject
            // 
            this.ButtonNewProject.Location = new System.Drawing.Point(643, 417);
            this.ButtonNewProject.Name = "ButtonNewProject";
            this.ButtonNewProject.Size = new System.Drawing.Size(129, 32);
            this.ButtonNewProject.TabIndex = 5;
            this.ButtonNewProject.Text = "New Task";
            this.ButtonNewProject.UseVisualStyleBackColor = true;
            this.ButtonNewProject.Click += new System.EventHandler(this.ButtonNewProject_Click);
            // 
            // ButtonManageStatuses
            // 
            this.ButtonManageStatuses.Location = new System.Drawing.Point(508, 417);
            this.ButtonManageStatuses.Name = "ButtonManageStatuses";
            this.ButtonManageStatuses.Size = new System.Drawing.Size(129, 32);
            this.ButtonManageStatuses.TabIndex = 6;
            this.ButtonManageStatuses.Text = "Manage Statuses";
            this.ButtonManageStatuses.UseVisualStyleBackColor = true;
            this.ButtonManageStatuses.Click += new System.EventHandler(this.ButtonManageStatuses_Click);
            // 
            // CheckBoxEnabled
            // 
            this.CheckBoxEnabled.AutoSize = true;
            this.CheckBoxEnabled.Checked = true;
            this.CheckBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxEnabled.Location = new System.Drawing.Point(417, 33);
            this.CheckBoxEnabled.Name = "CheckBoxEnabled";
            this.CheckBoxEnabled.Size = new System.Drawing.Size(74, 21);
            this.CheckBoxEnabled.TabIndex = 7;
            this.CheckBoxEnabled.Text = "Enabled";
            this.CheckBoxEnabled.UseVisualStyleBackColor = true;
            this.CheckBoxEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxEnabled_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CheckBoxEnabled);
            this.Controls.Add(this.ButtonManageStatuses);
            this.Controls.Add(this.ButtonNewProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LabelRowCount);
            this.Controls.Add(this.TextBoxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridViewProjects);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView DataGridViewProjects;
        private Label label1;
        private TextBox TextBoxSearch;
        private Label LabelRowCount;
        private Label label2;
        private Button ButtonNewProject;
        private Button ButtonManageStatuses;
        private CheckBox CheckBoxEnabled;
    }
}
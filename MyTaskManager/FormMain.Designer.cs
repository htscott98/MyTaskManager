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
            this.ButtonNewProject = new System.Windows.Forms.Button();
            this.ButtonManageStatuses = new System.Windows.Forms.Button();
            this.FlowLayoutPanelLists = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // ButtonNewProject
            // 
            this.ButtonNewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNewProject.Location = new System.Drawing.Point(843, 12);
            this.ButtonNewProject.Name = "ButtonNewProject";
            this.ButtonNewProject.Size = new System.Drawing.Size(129, 32);
            this.ButtonNewProject.TabIndex = 5;
            this.ButtonNewProject.Text = "New Task";
            this.ButtonNewProject.UseVisualStyleBackColor = true;
            this.ButtonNewProject.Click += new System.EventHandler(this.ButtonNewProject_Click);
            // 
            // ButtonManageStatuses
            // 
            this.ButtonManageStatuses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonManageStatuses.Location = new System.Drawing.Point(708, 12);
            this.ButtonManageStatuses.Name = "ButtonManageStatuses";
            this.ButtonManageStatuses.Size = new System.Drawing.Size(129, 32);
            this.ButtonManageStatuses.TabIndex = 6;
            this.ButtonManageStatuses.Text = "Manage Statuses";
            this.ButtonManageStatuses.UseVisualStyleBackColor = true;
            this.ButtonManageStatuses.Click += new System.EventHandler(this.ButtonManageStatuses_Click);
            // 
            // FlowLayoutPanelLists
            // 
            this.FlowLayoutPanelLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowLayoutPanelLists.AutoScroll = true;
            this.FlowLayoutPanelLists.Location = new System.Drawing.Point(12, 50);
            this.FlowLayoutPanelLists.Name = "FlowLayoutPanelLists";
            this.FlowLayoutPanelLists.Size = new System.Drawing.Size(960, 699);
            this.FlowLayoutPanelLists.TabIndex = 9;
            this.FlowLayoutPanelLists.WrapContents = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.FlowLayoutPanelLists);
            this.Controls.Add(this.ButtonManageStatuses);
            this.Controls.Add(this.ButtonNewProject);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Button ButtonNewProject;
        private Button ButtonManageStatuses;
        private FlowLayoutPanel FlowLayoutPanelLists;
    }
}
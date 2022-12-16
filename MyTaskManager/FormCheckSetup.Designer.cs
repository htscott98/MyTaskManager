namespace MyTaskManager
{
    partial class FormCheckSetup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckSetup));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.CheckBoxSQLStudio = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckBoxSQLTables = new System.Windows.Forms.CheckBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonRunSetup = new System.Windows.Forms.Button();
            this.CheckBoxSQLDatabase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(131, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "MyTaskManager - Setup";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(460, 143);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(356, 417);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(116, 32);
            this.ButtonNext.TabIndex = 3;
            this.ButtonNext.Text = "Next";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // CheckBoxSQLStudio
            // 
            this.CheckBoxSQLStudio.AutoCheck = false;
            this.CheckBoxSQLStudio.AutoSize = true;
            this.CheckBoxSQLStudio.Location = new System.Drawing.Point(36, 223);
            this.CheckBoxSQLStudio.Name = "CheckBoxSQLStudio";
            this.CheckBoxSQLStudio.Size = new System.Drawing.Size(412, 21);
            this.CheckBoxSQLStudio.TabIndex = 4;
            this.CheckBoxSQLStudio.Text = "Install Microsoft SQL Server Management Studio (default location)";
            this.CheckBoxSQLStudio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(177, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Requirements";
            // 
            // CheckBoxSQLTables
            // 
            this.CheckBoxSQLTables.AutoCheck = false;
            this.CheckBoxSQLTables.AutoSize = true;
            this.CheckBoxSQLTables.Location = new System.Drawing.Point(127, 277);
            this.CheckBoxSQLTables.Name = "CheckBoxSQLTables";
            this.CheckBoxSQLTables.Size = new System.Drawing.Size(231, 21);
            this.CheckBoxSQLTables.TabIndex = 6;
            this.CheckBoxSQLTables.Text = "Create MyTaskManager SQL tables";
            this.CheckBoxSQLTables.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(12, 417);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(116, 32);
            this.ButtonCancel.TabIndex = 8;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonRunSetup
            // 
            this.ButtonRunSetup.Location = new System.Drawing.Point(184, 304);
            this.ButtonRunSetup.Name = "ButtonRunSetup";
            this.ButtonRunSetup.Size = new System.Drawing.Size(116, 32);
            this.ButtonRunSetup.TabIndex = 9;
            this.ButtonRunSetup.Text = "Run Setup";
            this.ButtonRunSetup.UseVisualStyleBackColor = true;
            this.ButtonRunSetup.Click += new System.EventHandler(this.ButtonRunSetup_Click);
            // 
            // CheckBoxSQLDatabase
            // 
            this.CheckBoxSQLDatabase.AutoCheck = false;
            this.CheckBoxSQLDatabase.AutoSize = true;
            this.CheckBoxSQLDatabase.Location = new System.Drawing.Point(117, 250);
            this.CheckBoxSQLDatabase.Name = "CheckBoxSQLDatabase";
            this.CheckBoxSQLDatabase.Size = new System.Drawing.Size(250, 21);
            this.CheckBoxSQLDatabase.TabIndex = 10;
            this.CheckBoxSQLDatabase.Text = "Create MyTaskManager SQL database";
            this.CheckBoxSQLDatabase.UseVisualStyleBackColor = true;
            // 
            // FormCheckSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.CheckBoxSQLDatabase);
            this.Controls.Add(this.ButtonRunSetup);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.CheckBoxSQLTables);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CheckBoxSQLStudio);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "FormCheckSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormCheckSetup_Load);
            this.Shown += new System.EventHandler(this.FormCheckSetup_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Button ButtonNext;
        private CheckBox CheckBoxSQLStudio;
        private Label label3;
        private CheckBox CheckBoxSQLTables;
        private Button ButtonCancel;
        private Button ButtonRunSetup;
        private CheckBox CheckBoxSQLDatabase;
    }
}
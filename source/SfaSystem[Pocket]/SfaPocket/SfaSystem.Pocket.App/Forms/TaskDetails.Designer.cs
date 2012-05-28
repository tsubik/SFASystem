namespace SFASystem.Pocket.App
{
    partial class TaskDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDateExecuted = new System.Windows.Forms.Label();
            this.chxApproved = new System.Windows.Forms.CheckBox();
            this.lblAssignedBy = new System.Windows.Forms.Label();
            this.btnDeleguj = new System.Windows.Forms.Button();
            this.panelDeleguj = new System.Windows.Forms.Panel();
            this.selectEmployee = new SFASystem.Pocket.App.Controls.SelectEmployee();
            this.label12 = new System.Windows.Forms.Label();
            this.btnZamknijDeleguj = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.selectTaskStatus = new SFASystem.Pocket.App.Controls.SelectTaskStatus();
            this.panelDeleguj.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Nazwa: ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Opis: ";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblName.Location = new System.Drawing.Point(57, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(183, 20);
            this.lblName.Text = "[Nazwa zadania]";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDescription.Location = new System.Drawing.Point(57, 52);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(177, 66);
            this.lblDescription.Text = "[Opis zadania]";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(3, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "Utworzył:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCreatedBy.Location = new System.Drawing.Point(57, 118);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(183, 20);
            this.lblCreatedBy.Text = "[Utworzono przez]";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDateCreated.Location = new System.Drawing.Point(57, 131);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(163, 20);
            this.lblDateCreated.Text = "dnia [Data utworzenia]";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(3, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.Text = "Przydzielił:";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label11.Location = new System.Drawing.Point(3, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.Text = "Status: ";
            // 
            // lblDateExecuted
            // 
            this.lblDateExecuted.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblDateExecuted.Location = new System.Drawing.Point(152, 29);
            this.lblDateExecuted.Name = "lblDateExecuted";
            this.lblDateExecuted.Size = new System.Drawing.Size(85, 20);
            this.lblDateExecuted.Text = "dnia [Data ukończenia]";
            this.lblDateExecuted.Visible = false;
            // 
            // chxApproved
            // 
            this.chxApproved.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chxApproved.Location = new System.Drawing.Point(3, 165);
            this.chxApproved.Name = "chxApproved";
            this.chxApproved.Size = new System.Drawing.Size(128, 20);
            this.chxApproved.TabIndex = 18;
            this.chxApproved.Text = "Potwierdzone";
            // 
            // lblAssignedBy
            // 
            this.lblAssignedBy.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblAssignedBy.Location = new System.Drawing.Point(57, 151);
            this.lblAssignedBy.Name = "lblAssignedBy";
            this.lblAssignedBy.Size = new System.Drawing.Size(146, 20);
            this.lblAssignedBy.Text = "[Przydzielone przez]";
            // 
            // btnDeleguj
            // 
            this.btnDeleguj.Location = new System.Drawing.Point(6, 191);
            this.btnDeleguj.Name = "btnDeleguj";
            this.btnDeleguj.Size = new System.Drawing.Size(112, 20);
            this.btnDeleguj.TabIndex = 22;
            this.btnDeleguj.Text = "Deleguj zadanie";
            this.btnDeleguj.Click += new System.EventHandler(this.btnDeleguj_Click);
            // 
            // panelDeleguj
            // 
            this.panelDeleguj.Controls.Add(this.selectEmployee);
            this.panelDeleguj.Controls.Add(this.label12);
            this.panelDeleguj.Controls.Add(this.btnZamknijDeleguj);
            this.panelDeleguj.Location = new System.Drawing.Point(3, 217);
            this.panelDeleguj.Name = "panelDeleguj";
            this.panelDeleguj.Size = new System.Drawing.Size(234, 48);
            this.panelDeleguj.Visible = false;
            // 
            // selectEmployee
            // 
            this.selectEmployee.Location = new System.Drawing.Point(3, 18);
            this.selectEmployee.Name = "selectEmployee";
            this.selectEmployee.Size = new System.Drawing.Size(171, 22);
            this.selectEmployee.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label12.Location = new System.Drawing.Point(3, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 19);
            this.label12.Text = "Przydziel do: ";
            // 
            // btnZamknijDeleguj
            // 
            this.btnZamknijDeleguj.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnZamknijDeleguj.Location = new System.Drawing.Point(214, 3);
            this.btnZamknijDeleguj.Name = "btnZamknijDeleguj";
            this.btnZamknijDeleguj.Size = new System.Drawing.Size(17, 19);
            this.btnZamknijDeleguj.TabIndex = 23;
            this.btnZamknijDeleguj.Text = "x";
            this.btnZamknijDeleguj.Click += new System.EventHandler(this.btnZamknijDeleguj_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 20);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Zapisz zmiany";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // selectTaskStatus
            // 
            this.selectTaskStatus.Location = new System.Drawing.Point(57, 29);
            this.selectTaskStatus.Name = "selectTaskStatus";
            this.selectTaskStatus.Size = new System.Drawing.Size(89, 20);
            this.selectTaskStatus.TabIndex = 37;
            // 
            // TaskDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.selectTaskStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelDeleguj);
            this.Controls.Add(this.btnDeleguj);
            this.Controls.Add(this.lblAssignedBy);
            this.Controls.Add(this.chxApproved);
            this.Controls.Add(this.lblDateExecuted);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblDateCreated);
            this.Controls.Add(this.lblCreatedBy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "TaskDetails";
            this.Text = "Szczegóły zadania";
            this.panelDeleguj.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDateExecuted;
        private System.Windows.Forms.CheckBox chxApproved;
        private System.Windows.Forms.Label lblAssignedBy;
        private System.Windows.Forms.Button btnDeleguj;
        private System.Windows.Forms.Panel panelDeleguj;
        private System.Windows.Forms.Button btnZamknijDeleguj;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
        private SFASystem.Pocket.App.Controls.SelectEmployee selectEmployee;
        private SFASystem.Pocket.App.Controls.SelectTaskStatus selectTaskStatus;
    }
}
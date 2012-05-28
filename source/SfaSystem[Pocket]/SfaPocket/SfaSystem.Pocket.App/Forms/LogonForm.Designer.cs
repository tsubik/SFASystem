namespace SFASystem.Pocket.App
{
    partial class LogonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogonForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSynchronizacja = new System.Windows.Forms.Button();
            this.loginControl1 = new SFASystem.Pocket.App.Controls.LoginControl();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 72);
            // 
            // btnSynchronizacja
            // 
            this.btnSynchronizacja.Location = new System.Drawing.Point(12, 226);
            this.btnSynchronizacja.Name = "btnSynchronizacja";
            this.btnSynchronizacja.Size = new System.Drawing.Size(107, 20);
            this.btnSynchronizacja.TabIndex = 3;
            this.btnSynchronizacja.Text = "Synchronizacja";
            this.btnSynchronizacja.Click += new System.EventHandler(this.btnSynchronizacja_Click);
            // 
            // loginControl1
            // 
            this.loginControl1.Location = new System.Drawing.Point(12, 110);
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.Size = new System.Drawing.Size(215, 100);
            this.loginControl1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.Text = "Logowanie do systemu";
            // 
            // LogonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSynchronizacja);
            this.Controls.Add(this.loginControl1);
            this.Controls.Add(this.pictureBox1);
            this.Menu = this.mainMenu1;
            this.Name = "LogonForm";
            this.Text = "Logowanie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private SFASystem.Pocket.App.Controls.LoginControl loginControl1;
        private System.Windows.Forms.Button btnSynchronizacja;
        private System.Windows.Forms.Label label1;
    }
}
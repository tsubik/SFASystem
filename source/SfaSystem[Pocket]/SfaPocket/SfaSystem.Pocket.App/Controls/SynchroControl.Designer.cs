namespace SFASystem.Pocket.App.Controls
{
    partial class SynchroControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSynchroMessage = new System.Windows.Forms.Label();
            this.synchroProgress = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSynchroMessage
            // 
            this.lblSynchroMessage.Location = new System.Drawing.Point(3, 0);
            this.lblSynchroMessage.Name = "lblSynchroMessage";
            this.lblSynchroMessage.Size = new System.Drawing.Size(189, 20);
            this.lblSynchroMessage.Text = "Synchronizacja. Proszę czekać...";
            // 
            // synchroProgress
            // 
            this.synchroProgress.Location = new System.Drawing.Point(3, 23);
            this.synchroProgress.Name = "synchroProgress";
            this.synchroProgress.Size = new System.Drawing.Size(189, 20);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 49);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 20);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SynchroControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.synchroProgress);
            this.Controls.Add(this.lblSynchroMessage);
            this.Name = "SynchroControl";
            this.Size = new System.Drawing.Size(196, 70);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSynchroMessage;
        private System.Windows.Forms.ProgressBar synchroProgress;
        private System.Windows.Forms.Button btnCancel;
    }
}

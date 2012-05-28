namespace SFASystem.Pocket.App.Controls
{
    partial class ctrlCustomerFacility
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblUlica = new System.Windows.Forms.Label();
            this.lblMiasto = new System.Windows.Forms.Label();
            this.lblKraj = new System.Windows.Forms.Label();
            this.lblKod = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnZamów = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(220, 17);
            this.lblName.Text = "label1";
            // 
            // lblRegion
            // 
            this.lblRegion.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblRegion.Location = new System.Drawing.Point(3, 17);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(188, 14);
            this.lblRegion.Text = "Region: ";
            // 
            // lblUlica
            // 
            this.lblUlica.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblUlica.Location = new System.Drawing.Point(3, 31);
            this.lblUlica.Name = "lblUlica";
            this.lblUlica.Size = new System.Drawing.Size(202, 15);
            this.lblUlica.Text = "Ulica: ";
            // 
            // lblMiasto
            // 
            this.lblMiasto.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblMiasto.Location = new System.Drawing.Point(66, 46);
            this.lblMiasto.Name = "lblMiasto";
            this.lblMiasto.Size = new System.Drawing.Size(139, 14);
            this.lblMiasto.Text = "Miasto: ";
            // 
            // lblKraj
            // 
            this.lblKraj.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblKraj.Location = new System.Drawing.Point(3, 61);
            this.lblKraj.Name = "lblKraj";
            this.lblKraj.Size = new System.Drawing.Size(110, 14);
            this.lblKraj.Text = "Kraj: ";
            // 
            // lblKod
            // 
            this.lblKod.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblKod.Location = new System.Drawing.Point(3, 46);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(64, 15);
            this.lblKod.Text = "Kod: ";
            // 
            // btnDetails
            // 
            this.btnDetails.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btnDetails.Location = new System.Drawing.Point(170, 61);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(44, 20);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "Detale";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnZamów
            // 
            this.btnZamów.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btnZamów.Location = new System.Drawing.Point(106, 61);
            this.btnZamów.Name = "btnZamów";
            this.btnZamów.Size = new System.Drawing.Size(58, 20);
            this.btnZamów.TabIndex = 13;
            this.btnZamów.Text = "Zamów dla";
            this.btnZamów.Click += new System.EventHandler(this.btnZamów_Click);
            // 
            // ctrlCustomerFacility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnZamów);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lblKod);
            this.Controls.Add(this.lblKraj);
            this.Controls.Add(this.lblMiasto);
            this.Controls.Add(this.lblUlica);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.lblName);
            this.Name = "ctrlCustomerFacility";
            this.Size = new System.Drawing.Size(217, 88);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblUlica;
        private System.Windows.Forms.Label lblMiasto;
        private System.Windows.Forms.Label lblKraj;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnZamów;
    }
}

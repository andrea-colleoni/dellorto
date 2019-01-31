namespace DesktopWinForms
{
    partial class fmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctStation2 = new DesktopWinForms.ctStation();
            this.ctStation1 = new DesktopWinForms.ctStation();
            this.ctStation3 = new DesktopWinForms.ctStation();
            this.SuspendLayout();
            // 
            // ctStation2
            // 
            this.ctStation2.Location = new System.Drawing.Point(12, 268);
            this.ctStation2.Name = "ctStation2";
            this.ctStation2.Size = new System.Drawing.Size(600, 250);
            this.ctStation2.Station = null;
            this.ctStation2.TabIndex = 8;
            // 
            // ctStation1
            // 
            this.ctStation1.Location = new System.Drawing.Point(12, 12);
            this.ctStation1.Name = "ctStation1";
            this.ctStation1.Size = new System.Drawing.Size(600, 250);
            this.ctStation1.Station = null;
            this.ctStation1.TabIndex = 7;
            // 
            // ctStation3
            // 
            this.ctStation3.Location = new System.Drawing.Point(602, 12);
            this.ctStation3.Name = "ctStation3";
            this.ctStation3.Size = new System.Drawing.Size(558, 254);
            this.ctStation3.Station = null;
            this.ctStation3.TabIndex = 9;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 539);
            this.Controls.Add(this.ctStation3);
            this.Controls.Add(this.ctStation2);
            this.Controls.Add(this.ctStation1);
            this.Name = "fmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private ctStation ctStation1;
        private ctStation ctStation2;
        private ctStation ctStation3;
    }
}


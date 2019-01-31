namespace DesktopWinForms
{
    partial class ctStation
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.ctPlc1 = new DesktopWinForms.ctPlc();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblName.Location = new System.Drawing.Point(145, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(106, 32);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "[Name]";
            // 
            // ctRealPlc1
            // 
            this.ctPlc1.Location = new System.Drawing.Point(0, 53);
            this.ctPlc1.Name = "ctRealPlc1";
            this.ctPlc1.Plc = null;
            this.ctPlc1.Size = new System.Drawing.Size(546, 200);
            this.ctPlc1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stazione:";
            // 
            // ctStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctPlc1);
            this.Controls.Add(this.lblName);
            this.Name = "ctStation";
            this.Size = new System.Drawing.Size(558, 254);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        internal ctPlc ctPlc1;
        private System.Windows.Forms.Label label1;
    }
}

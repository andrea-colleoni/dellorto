namespace DesktopWinForms
{
    partial class ctRealPlc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctRealPlc));
            this.lblName = new System.Windows.Forms.Label();
            this.btnAccendi = new System.Windows.Forms.Button();
            this.btnSpegni = new System.Windows.Forms.Button();
            this.lblBit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // btnAccendi
            // 
            resources.ApplyResources(this.btnAccendi, "btnAccendi");
            this.btnAccendi.Name = "btnAccendi";
            this.btnAccendi.UseVisualStyleBackColor = true;
            this.btnAccendi.Click += new System.EventHandler(this.btnAccendi_Click);
            // 
            // btnSpegni
            // 
            resources.ApplyResources(this.btnSpegni, "btnSpegni");
            this.btnSpegni.Name = "btnSpegni";
            this.btnSpegni.UseVisualStyleBackColor = true;
            this.btnSpegni.Click += new System.EventHandler(this.btnSpegni_Click);
            // 
            // lblBit
            // 
            resources.ApplyResources(this.lblBit, "lblBit");
            this.lblBit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblBit.Name = "lblBit";
            // 
            // ctRealPlc
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBit);
            this.Controls.Add(this.btnSpegni);
            this.Controls.Add(this.btnAccendi);
            this.Controls.Add(this.lblName);
            this.Name = "ctRealPlc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAccendi;
        private System.Windows.Forms.Button btnSpegni;
        private System.Windows.Forms.Label lblBit;
    }
}

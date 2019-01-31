namespace DesktopWinForms
{
    partial class ctPlc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctPlc));
            System.Windows.Forms.AGaugeRange aGaugeRange1 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange2 = new System.Windows.Forms.AGaugeRange();
            this.lblName = new System.Windows.Forms.Label();
            this.btnAccendi = new System.Windows.Forms.Button();
            this.btnSpegni = new System.Windows.Forms.Button();
            this.lblBit = new System.Windows.Forms.Label();
            this.pctStatus = new System.Windows.Forms.PictureBox();
            this.aGauge1 = new System.Windows.Forms.AGauge();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.chkEmulazione = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctStatus)).BeginInit();
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
            // pctStatus
            // 
            resources.ApplyResources(this.pctStatus, "pctStatus");
            this.pctStatus.Name = "pctStatus";
            this.pctStatus.TabStop = false;
            // 
            // aGauge1
            // 
            this.aGauge1.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge1.BaseArcRadius = 65;
            this.aGauge1.BaseArcStart = 210;
            this.aGauge1.BaseArcSweep = 120;
            this.aGauge1.BaseArcWidth = 2;
            this.aGauge1.Center = new System.Drawing.Point(75, 100);
            aGaugeRange1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            aGaugeRange1.EndValue = 30F;
            aGaugeRange1.InnerRadius = 60;
            aGaugeRange1.InRange = false;
            aGaugeRange1.Name = "GaugeRange1";
            aGaugeRange1.OuterRadius = 75;
            aGaugeRange1.StartValue = 0F;
            aGaugeRange2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            aGaugeRange2.EndValue = 50F;
            aGaugeRange2.InnerRadius = 60;
            aGaugeRange2.InRange = false;
            aGaugeRange2.Name = "GaugeRange2";
            aGaugeRange2.OuterRadius = 75;
            aGaugeRange2.StartValue = 30F;
            this.aGauge1.GaugeRanges.Add(aGaugeRange1);
            this.aGauge1.GaugeRanges.Add(aGaugeRange2);
            resources.ApplyResources(this.aGauge1, "aGauge1");
            this.aGauge1.MaxValue = 50F;
            this.aGauge1.MinValue = 0F;
            this.aGauge1.Name = "aGauge1";
            this.aGauge1.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.aGauge1.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aGauge1.NeedleRadius = 75;
            this.aGauge1.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.aGauge1.NeedleWidth = 2;
            this.aGauge1.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleLinesInterInnerRadius = 70;
            this.aGauge1.ScaleLinesInterOuterRadius = 72;
            this.aGauge1.ScaleLinesInterWidth = 1;
            this.aGauge1.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleLinesMajorInnerRadius = 65;
            this.aGauge1.ScaleLinesMajorOuterRadius = 70;
            this.aGauge1.ScaleLinesMajorStepValue = 10F;
            this.aGauge1.ScaleLinesMajorWidth = 2;
            this.aGauge1.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aGauge1.ScaleLinesMinorInnerRadius = 65;
            this.aGauge1.ScaleLinesMinorOuterRadius = 70;
            this.aGauge1.ScaleLinesMinorTicks = 5;
            this.aGauge1.ScaleLinesMinorWidth = 1;
            this.aGauge1.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleNumbersFormat = null;
            this.aGauge1.ScaleNumbersRadius = 80;
            this.aGauge1.ScaleNumbersRotation = 0;
            this.aGauge1.ScaleNumbersStartScaleLine = 0;
            this.aGauge1.ScaleNumbersStepScaleLines = 10;
            this.aGauge1.Value = 0F;
            // 
            // btnMonitor
            // 
            resources.ApplyResources(this.btnMonitor, "btnMonitor");
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // chkEmulazione
            // 
            resources.ApplyResources(this.chkEmulazione, "chkEmulazione");
            this.chkEmulazione.Checked = true;
            this.chkEmulazione.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmulazione.Name = "chkEmulazione";
            this.chkEmulazione.UseVisualStyleBackColor = true;
            this.chkEmulazione.CheckedChanged += new System.EventHandler(this.chkEmulazione_CheckedChanged);
            // 
            // ctPlc
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkEmulazione);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.aGauge1);
            this.Controls.Add(this.pctStatus);
            this.Controls.Add(this.lblBit);
            this.Controls.Add(this.btnSpegni);
            this.Controls.Add(this.btnAccendi);
            this.Controls.Add(this.lblName);
            this.Name = "ctPlc";
            ((System.ComponentModel.ISupportInitialize)(this.pctStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAccendi;
        private System.Windows.Forms.Button btnSpegni;
        private System.Windows.Forms.Label lblBit;
        private System.Windows.Forms.PictureBox pctStatus;
        private System.Windows.Forms.AGauge aGauge1;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.CheckBox chkEmulazione;
    }
}

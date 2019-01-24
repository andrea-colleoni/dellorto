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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnStartLoop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtMessaggio = new System.Windows.Forms.TextBox();
            this.btnInviaMsg = new System.Windows.Forms.Button();
            this.txtMessaggi = new System.Windows.Forms.TextBox();
            this.btnPulisci = new System.Windows.Forms.Button();
            this.ctStation1 = new DesktopWinForms.ctStation();
            this.ctStation2 = new DesktopWinForms.ctStation();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Check SW Ready";
            // 
            // btnStartLoop
            // 
            this.btnStartLoop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartLoop.Location = new System.Drawing.Point(18, 44);
            this.btnStartLoop.Name = "btnStartLoop";
            this.btnStartLoop.Size = new System.Drawing.Size(206, 47);
            this.btnStartLoop.TabIndex = 1;
            this.btnStartLoop.Text = "Premi";
            this.btnStartLoop.UseVisualStyleBackColor = true;
            this.btnStartLoop.Click += new System.EventHandler(this.btnStartLoop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 94);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(134, 32);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "[lblStatus";
            // 
            // txtMessaggio
            // 
            this.txtMessaggio.Location = new System.Drawing.Point(272, 9);
            this.txtMessaggio.Multiline = true;
            this.txtMessaggio.Name = "txtMessaggio";
            this.txtMessaggio.Size = new System.Drawing.Size(249, 73);
            this.txtMessaggio.TabIndex = 3;
            // 
            // btnInviaMsg
            // 
            this.btnInviaMsg.Location = new System.Drawing.Point(272, 88);
            this.btnInviaMsg.Name = "btnInviaMsg";
            this.btnInviaMsg.Size = new System.Drawing.Size(75, 23);
            this.btnInviaMsg.TabIndex = 4;
            this.btnInviaMsg.Text = "Invia messaggio";
            this.btnInviaMsg.UseVisualStyleBackColor = true;
            this.btnInviaMsg.Click += new System.EventHandler(this.btnInviaMsg_Click);
            // 
            // txtMessaggi
            // 
            this.txtMessaggi.Location = new System.Drawing.Point(527, 9);
            this.txtMessaggi.Multiline = true;
            this.txtMessaggi.Name = "txtMessaggi";
            this.txtMessaggi.Size = new System.Drawing.Size(419, 73);
            this.txtMessaggi.TabIndex = 5;
            // 
            // btnPulisci
            // 
            this.btnPulisci.Location = new System.Drawing.Point(527, 88);
            this.btnPulisci.Name = "btnPulisci";
            this.btnPulisci.Size = new System.Drawing.Size(75, 23);
            this.btnPulisci.TabIndex = 6;
            this.btnPulisci.Text = "Pulisci";
            this.btnPulisci.UseVisualStyleBackColor = true;
            this.btnPulisci.Click += new System.EventHandler(this.btnPulisci_Click);
            // 
            // ctStation1
            // 
            this.ctStation1.Location = new System.Drawing.Point(12, 191);
            this.ctStation1.Name = "ctStation1";
            this.ctStation1.Size = new System.Drawing.Size(521, 325);
            this.ctStation1.Station = null;
            this.ctStation1.TabIndex = 7;
            // 
            // ctStation2
            // 
            this.ctStation2.Location = new System.Drawing.Point(589, 191);
            this.ctStation2.Name = "ctStation2";
            this.ctStation2.Size = new System.Drawing.Size(521, 325);
            this.ctStation2.Station = null;
            this.ctStation2.TabIndex = 8;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 557);
            this.Controls.Add(this.ctStation2);
            this.Controls.Add(this.ctStation1);
            this.Controls.Add(this.btnPulisci);
            this.Controls.Add(this.txtMessaggi);
            this.Controls.Add(this.btnInviaMsg);
            this.Controls.Add(this.txtMessaggio);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStartLoop);
            this.Controls.Add(this.lblTitle);
            this.Name = "fmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStartLoop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtMessaggio;
        private System.Windows.Forms.Button btnInviaMsg;
        private System.Windows.Forms.Button btnPulisci;
        private System.Windows.Forms.TextBox txtMessaggi;
        private ctStation ctStation1;
        private ctStation ctStation2;
    }
}


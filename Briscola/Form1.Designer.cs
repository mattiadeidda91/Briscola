namespace Briscola
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxIo1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxIo2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxIo3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxBriscola = new System.Windows.Forms.PictureBox();
            this.pictureBoxAvversario1 = new System.Windows.Forms.PictureBox();
            this.labelPuntiAvv = new System.Windows.Forms.Label();
            this.labelPuntiMiei = new System.Windows.Forms.Label();
            this.pictureBoxAvversario2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxAvversario3 = new System.Windows.Forms.PictureBox();
            this.labelPuntiAvversario = new System.Windows.Forms.Label();
            this.labelPunti = new System.Windows.Forms.Label();
            this.pictureBoxMazzo = new System.Windows.Forms.PictureBox();
            this.labelRetro1 = new System.Windows.Forms.Label();
            this.labelRetro2 = new System.Windows.Forms.Label();
            this.labelRetro3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBriscola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvversario1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvversario2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvversario3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMazzo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIo1
            // 
            resources.ApplyResources(this.pictureBoxIo1, "pictureBoxIo1");
            this.pictureBoxIo1.Name = "pictureBoxIo1";
            this.pictureBoxIo1.TabStop = false;
            this.pictureBoxIo1.Click += new System.EventHandler(this.pictureBoxIo2_Click);
            // 
            // pictureBoxIo2
            // 
            resources.ApplyResources(this.pictureBoxIo2, "pictureBoxIo2");
            this.pictureBoxIo2.Name = "pictureBoxIo2";
            this.pictureBoxIo2.TabStop = false;
            this.pictureBoxIo2.Click += new System.EventHandler(this.pictureBoxIo2_Click);
            // 
            // pictureBoxIo3
            // 
            resources.ApplyResources(this.pictureBoxIo3, "pictureBoxIo3");
            this.pictureBoxIo3.Name = "pictureBoxIo3";
            this.pictureBoxIo3.TabStop = false;
            this.pictureBoxIo3.Click += new System.EventHandler(this.pictureBoxIo2_Click);
            // 
            // pictureBoxBriscola
            // 
            resources.ApplyResources(this.pictureBoxBriscola, "pictureBoxBriscola");
            this.pictureBoxBriscola.Name = "pictureBoxBriscola";
            this.pictureBoxBriscola.TabStop = false;
            // 
            // pictureBoxAvversario1
            // 
            resources.ApplyResources(this.pictureBoxAvversario1, "pictureBoxAvversario1");
            this.pictureBoxAvversario1.Name = "pictureBoxAvversario1";
            this.pictureBoxAvversario1.TabStop = false;
            // 
            // labelPuntiAvv
            // 
            resources.ApplyResources(this.labelPuntiAvv, "labelPuntiAvv");
            this.labelPuntiAvv.BackColor = System.Drawing.Color.White;
            this.labelPuntiAvv.Image = global::Briscola.Properties.Resources.sfondoBriscola;
            this.labelPuntiAvv.Name = "labelPuntiAvv";
            // 
            // labelPuntiMiei
            // 
            resources.ApplyResources(this.labelPuntiMiei, "labelPuntiMiei");
            this.labelPuntiMiei.Image = global::Briscola.Properties.Resources.sfondoBriscola;
            this.labelPuntiMiei.Name = "labelPuntiMiei";
            // 
            // pictureBoxAvversario2
            // 
            resources.ApplyResources(this.pictureBoxAvversario2, "pictureBoxAvversario2");
            this.pictureBoxAvversario2.Name = "pictureBoxAvversario2";
            this.pictureBoxAvversario2.TabStop = false;
            // 
            // pictureBoxAvversario3
            // 
            resources.ApplyResources(this.pictureBoxAvversario3, "pictureBoxAvversario3");
            this.pictureBoxAvversario3.Name = "pictureBoxAvversario3";
            this.pictureBoxAvversario3.TabStop = false;
            // 
            // labelPuntiAvversario
            // 
            resources.ApplyResources(this.labelPuntiAvversario, "labelPuntiAvversario");
            this.labelPuntiAvversario.BackColor = System.Drawing.Color.White;
            this.labelPuntiAvversario.Image = global::Briscola.Properties.Resources.sfondoBriscola;
            this.labelPuntiAvversario.Name = "labelPuntiAvversario";
            // 
            // labelPunti
            // 
            resources.ApplyResources(this.labelPunti, "labelPunti");
            this.labelPunti.BackColor = System.Drawing.Color.White;
            this.labelPunti.Image = global::Briscola.Properties.Resources.sfondoBriscola;
            this.labelPunti.Name = "labelPunti";
            // 
            // pictureBoxMazzo
            // 
            this.pictureBoxMazzo.BackgroundImage = global::Briscola.Properties.Resources.retro;
            resources.ApplyResources(this.pictureBoxMazzo, "pictureBoxMazzo");
            this.pictureBoxMazzo.Name = "pictureBoxMazzo";
            this.pictureBoxMazzo.TabStop = false;
            // 
            // labelRetro1
            // 
            this.labelRetro1.Image = global::Briscola.Properties.Resources.retro;
            resources.ApplyResources(this.labelRetro1, "labelRetro1");
            this.labelRetro1.Name = "labelRetro1";
            // 
            // labelRetro2
            // 
            this.labelRetro2.Image = global::Briscola.Properties.Resources.retro;
            resources.ApplyResources(this.labelRetro2, "labelRetro2");
            this.labelRetro2.Name = "labelRetro2";
            // 
            // labelRetro3
            // 
            this.labelRetro3.Image = global::Briscola.Properties.Resources.retro;
            resources.ApplyResources(this.labelRetro3, "labelRetro3");
            this.labelRetro3.Name = "labelRetro3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Briscola.Properties.Resources.sfondoBriscola;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelRetro3);
            this.Controls.Add(this.labelRetro2);
            this.Controls.Add(this.labelRetro1);
            this.Controls.Add(this.pictureBoxMazzo);
            this.Controls.Add(this.labelPunti);
            this.Controls.Add(this.labelPuntiAvversario);
            this.Controls.Add(this.pictureBoxAvversario3);
            this.Controls.Add(this.pictureBoxAvversario2);
            this.Controls.Add(this.labelPuntiMiei);
            this.Controls.Add(this.labelPuntiAvv);
            this.Controls.Add(this.pictureBoxAvversario1);
            this.Controls.Add(this.pictureBoxBriscola);
            this.Controls.Add(this.pictureBoxIo3);
            this.Controls.Add(this.pictureBoxIo2);
            this.Controls.Add(this.pictureBoxIo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBriscola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvversario1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvversario2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvversario3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMazzo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIo1;
        private System.Windows.Forms.PictureBox pictureBoxIo2;
        private System.Windows.Forms.PictureBox pictureBoxIo3;
        private System.Windows.Forms.PictureBox pictureBoxBriscola;
        private System.Windows.Forms.PictureBox pictureBoxAvversario1;
        private System.Windows.Forms.Label labelPuntiAvv;
        private System.Windows.Forms.Label labelPuntiMiei;
        private System.Windows.Forms.PictureBox pictureBoxAvversario2;
        private System.Windows.Forms.PictureBox pictureBoxAvversario3;
        private System.Windows.Forms.Label labelPuntiAvversario;
        private System.Windows.Forms.Label labelPunti;
        private System.Windows.Forms.PictureBox pictureBoxMazzo;
        private System.Windows.Forms.Label labelRetro1;
        private System.Windows.Forms.Label labelRetro2;
        private System.Windows.Forms.Label labelRetro3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


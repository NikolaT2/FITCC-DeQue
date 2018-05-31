namespace FIT_DQ
{
    partial class Prikaz
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prikaz));
            this.labela = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labela
            // 
            this.labela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labela.Font = new System.Drawing.Font("Microsoft Sans Serif", 128F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labela.ForeColor = System.Drawing.Color.White;
            this.labela.Location = new System.Drawing.Point(12, 9);
            this.labela.Name = "labela";
            this.labela.Size = new System.Drawing.Size(657, 243);
            this.labela.TabIndex = 0;
            this.labela.Text = "--";
            this.labela.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labela.Click += new System.EventHandler(this.labela_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 400;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Prikaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(681, 261);
            this.Controls.Add(this.labela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Prikaz";
            this.Text = "Prikaz";
            this.Load += new System.EventHandler(this.Prikaz_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Prikaz_KeyDown);
            this.Resize += new System.EventHandler(this.Prikaz_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label labela;
        private System.Windows.Forms.Timer timer;
    }
}
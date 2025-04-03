namespace txtConverter
{
    partial class Konvertierer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Konvertieren = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Konvertieren
            // 
            this.Konvertieren.Location = new System.Drawing.Point(317, 215);
            this.Konvertieren.Name = "Konvertieren";
            this.Konvertieren.Size = new System.Drawing.Size(87, 23);
            this.Konvertieren.TabIndex = 0;
            this.Konvertieren.Text = "Konvertieren";
            this.Konvertieren.UseVisualStyleBackColor = true;
            this.Konvertieren.Click += new System.EventHandler(this.button1_Click);
            // 
            // Konvertierer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Konvertieren);
            this.Name = "Konvertierer";
            this.Text = "Konverter";
            this.Load += new System.EventHandler(this.Konverter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button Konvertieren;
    }
}
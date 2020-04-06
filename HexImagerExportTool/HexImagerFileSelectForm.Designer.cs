namespace METEC
{
    partial class HexImagerFileSelectForm
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
            this.hexImagerFileSelectControl = new METEC.HexImagerFileSelectControl();
            this.SuspendLayout();
            // 
            // hexImagerFileSelectControl1
            // 
            this.hexImagerFileSelectControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexImagerFileSelectControl.Location = new System.Drawing.Point(0, 0);
            this.hexImagerFileSelectControl.Name = "hexImagerFileSelectControl1";
            this.hexImagerFileSelectControl.Size = new System.Drawing.Size(577, 376);
            this.hexImagerFileSelectControl.TabIndex = 0;
            // 
            // HexImagerFileSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 376);
            this.Controls.Add(this.hexImagerFileSelectControl);
            this.Name = "HexImagerFileSelectForm";
            this.Text = "HexImagerFileSelectForm";
            this.ResumeLayout(false);

        }

        #endregion

        private HexImagerFileSelectControl hexImagerFileSelectControl;
    }
}
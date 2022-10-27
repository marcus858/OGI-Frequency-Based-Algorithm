namespace METEC
{
    partial class SingleCamera
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
            this.SingleCamFeed = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cameraSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMin = new System.Windows.Forms.Label();
            this.pictureBoxScale = new System.Windows.Forms.PictureBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.flirCameraFocusControlForm1 = new METEC.FLIRCameraFocusControl();
            ((System.ComponentModel.ISupportInitialize)(this.SingleCamFeed)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScale)).BeginInit();
            this.SuspendLayout();
            // 
            // SingleCamFeed
            // 
            this.SingleCamFeed.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SingleCamFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SingleCamFeed.Location = new System.Drawing.Point(106, 106);
            this.SingleCamFeed.Margin = new System.Windows.Forms.Padding(6);
            this.SingleCamFeed.Name = "SingleCamFeed";
            this.tableLayoutPanel1.SetRowSpan(this.SingleCamFeed, 2);
            this.SingleCamFeed.Size = new System.Drawing.Size(939, 672);
            this.SingleCamFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SingleCamFeed.TabIndex = 2;
            this.SingleCamFeed.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripConnectionStatus,
            this.cameraSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1553, 41);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripConnectionStatus
            // 
            this.toolStripConnectionStatus.Name = "toolStripConnectionStatus";
            this.toolStripConnectionStatus.Size = new System.Drawing.Size(160, 32);
            this.toolStripConnectionStatus.Text = "Disconnected";
            // 
            // cameraSettingsToolStripMenuItem
            // 
            this.cameraSettingsToolStripMenuItem.Name = "cameraSettingsToolStripMenuItem";
            this.cameraSettingsToolStripMenuItem.Size = new System.Drawing.Size(201, 37);
            this.cameraSettingsToolStripMenuItem.Text = "Camera Settings";
            this.cameraSettingsToolStripMenuItem.Click += new System.EventHandler(this.cameraSettingsToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Rainbow",
            "Grey",
            "Lava",
            "Iron",
            "Arctic",
            "Cool"});
            this.comboBox1.Location = new System.Drawing.Point(524, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 33);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "Palette";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 502F));
            this.tableLayoutPanel1.Controls.Add(this.labelMin, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.SingleCamFeed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxScale, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelMax, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flirCameraFocusControlForm1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1553, 874);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMin.Location = new System.Drawing.Point(4, 784);
            this.labelMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(92, 25);
            this.labelMin.TabIndex = 10;
            this.labelMin.Text = "777777";
            this.labelMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxScale
            // 
            this.pictureBoxScale.BackColor = System.Drawing.Color.White;
            this.pictureBoxScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxScale.Location = new System.Drawing.Point(0, 100);
            this.pictureBoxScale.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxScale.Name = "pictureBoxScale";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBoxScale, 2);
            this.pictureBoxScale.Size = new System.Drawing.Size(100, 684);
            this.pictureBoxScale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScale.TabIndex = 5;
            this.pictureBoxScale.TabStop = false;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelMax.Location = new System.Drawing.Point(4, 75);
            this.labelMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(92, 25);
            this.labelMax.TabIndex = 9;
            this.labelMax.Text = "777777";
            this.labelMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flirCameraFocusControlForm1
            // 
            this.flirCameraFocusControlForm1.Location = new System.Drawing.Point(1055, 105);
            this.flirCameraFocusControlForm1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flirCameraFocusControlForm1.Name = "flirCameraFocusControlForm1";
            this.flirCameraFocusControlForm1.Size = new System.Drawing.Size(494, 203);
            this.flirCameraFocusControlForm1.TabIndex = 11;
            // 
            // SingleCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1553, 874);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SingleCamera";
            this.Text = "SingleCamera";
            this.Load += new System.EventHandler(this.SingleCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SingleCamFeed)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SingleCamFeed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripConnectionStatus;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem cameraSettingsToolStripMenuItem;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.PictureBox pictureBoxScale;
        private System.Windows.Forms.Label labelMax;
        private FLIRCameraFocusControl flirCameraFocusControlForm1;
    }
}
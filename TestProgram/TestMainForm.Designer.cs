namespace METEC
{
    partial class TestMainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.connectCamera2 = new System.Windows.Forms.Button();
            this.disconnectCamera2 = new System.Windows.Forms.Button();
            this.settingsCamera2 = new System.Windows.Forms.Button();
            this.metecCameraTemperatureControl1 = new global::METEC.FLIRCameraTemperatureControl();
            this.CameraFeed2 = new System.Windows.Forms.PictureBox();
            this.CameraFeed1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.connectCamera1 = new System.Windows.Forms.Button();
            this.disconnectCamera1 = new System.Windows.Forms.Button();
            this.startCamera1 = new System.Windows.Forms.Button();
            this.settingsCamera1 = new System.Windows.Forms.Button();
            this.metecCameraFocusControl1 = new global::METEC.FLIRCameraFocusControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraFeed2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraFeed1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CameraFeed2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CameraFeed1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.69168F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.30832F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 826);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.connectCamera2);
            this.flowLayoutPanel2.Controls.Add(this.disconnectCamera2);
            this.flowLayoutPanel2.Controls.Add(this.settingsCamera2);
            this.flowLayoutPanel2.Controls.Add(this.metecCameraTemperatureControl1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(403, 529);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(394, 294);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // connectCamera2
            // 
            this.connectCamera2.Location = new System.Drawing.Point(3, 3);
            this.connectCamera2.Name = "connectCamera2";
            this.connectCamera2.Size = new System.Drawing.Size(111, 23);
            this.connectCamera2.TabIndex = 0;
            this.connectCamera2.Text = "Connect";
            this.connectCamera2.UseVisualStyleBackColor = true;
            this.connectCamera2.Click += new System.EventHandler(this.connectCamera2_Click);
            // 
            // disconnectCamera2
            // 
            this.disconnectCamera2.Enabled = false;
            this.disconnectCamera2.Location = new System.Drawing.Point(120, 3);
            this.disconnectCamera2.Name = "disconnectCamera2";
            this.disconnectCamera2.Size = new System.Drawing.Size(110, 23);
            this.disconnectCamera2.TabIndex = 1;
            this.disconnectCamera2.Text = "Disconnect";
            this.disconnectCamera2.UseVisualStyleBackColor = true;
            this.disconnectCamera2.Click += new System.EventHandler(this.disconnectCamera2_Click);
            // 
            // settingsCamera2
            // 
            this.settingsCamera2.Enabled = false;
            this.settingsCamera2.Location = new System.Drawing.Point(236, 3);
            this.settingsCamera2.Name = "settingsCamera2";
            this.settingsCamera2.Size = new System.Drawing.Size(139, 23);
            this.settingsCamera2.TabIndex = 4;
            this.settingsCamera2.Text = "Settings";
            this.settingsCamera2.UseVisualStyleBackColor = true;
            this.settingsCamera2.Click += new System.EventHandler(this.settingsCamera2_Click);
            // 
            // metecCameraTemperatureControl1
            // 
            this.metecCameraTemperatureControl1.Location = new System.Drawing.Point(3, 32);
            this.metecCameraTemperatureControl1.Name = "metecCameraTemperatureControl1";
            this.metecCameraTemperatureControl1.Size = new System.Drawing.Size(373, 265);
            this.metecCameraTemperatureControl1.TabIndex = 5;
            // 
            // CameraFeed2
            // 
            this.CameraFeed2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraFeed2.Location = new System.Drawing.Point(403, 3);
            this.CameraFeed2.Name = "CameraFeed2";
            this.CameraFeed2.Size = new System.Drawing.Size(394, 520);
            this.CameraFeed2.TabIndex = 1;
            this.CameraFeed2.TabStop = false;
            // 
            // CameraFeed1
            // 
            this.CameraFeed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraFeed1.Location = new System.Drawing.Point(3, 3);
            this.CameraFeed1.Name = "CameraFeed1";
            this.CameraFeed1.Size = new System.Drawing.Size(394, 520);
            this.CameraFeed1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CameraFeed1.TabIndex = 0;
            this.CameraFeed1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.connectCamera1);
            this.flowLayoutPanel1.Controls.Add(this.disconnectCamera1);
            this.flowLayoutPanel1.Controls.Add(this.startCamera1);
            this.flowLayoutPanel1.Controls.Add(this.settingsCamera1);
            this.flowLayoutPanel1.Controls.Add(this.metecCameraFocusControl1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 529);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(394, 294);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // connectCamera1
            // 
            this.connectCamera1.Location = new System.Drawing.Point(3, 3);
            this.connectCamera1.Name = "connectCamera1";
            this.connectCamera1.Size = new System.Drawing.Size(102, 23);
            this.connectCamera1.TabIndex = 0;
            this.connectCamera1.Text = "Connect";
            this.connectCamera1.UseVisualStyleBackColor = true;
            this.connectCamera1.Click += new System.EventHandler(this.connectCamera1_Click);
            // 
            // disconnectCamera1
            // 
            this.disconnectCamera1.Enabled = false;
            this.disconnectCamera1.Location = new System.Drawing.Point(111, 3);
            this.disconnectCamera1.Name = "disconnectCamera1";
            this.disconnectCamera1.Size = new System.Drawing.Size(118, 23);
            this.disconnectCamera1.TabIndex = 1;
            this.disconnectCamera1.Text = "Disconnect";
            this.disconnectCamera1.UseVisualStyleBackColor = true;
            this.disconnectCamera1.Click += new System.EventHandler(this.disconnectCamera1_Click);
            // 
            // startCamera1
            // 
            this.startCamera1.Enabled = false;
            this.startCamera1.Location = new System.Drawing.Point(235, 3);
            this.startCamera1.Name = "startCamera1";
            this.startCamera1.Size = new System.Drawing.Size(139, 23);
            this.startCamera1.TabIndex = 2;
            this.startCamera1.Text = "Record";
            this.startCamera1.UseVisualStyleBackColor = true;
            this.startCamera1.Click += new System.EventHandler(this.startCamera1_Click);
            // 
            // settingsCamera1
            // 
            this.settingsCamera1.Enabled = false;
            this.settingsCamera1.Location = new System.Drawing.Point(3, 32);
            this.settingsCamera1.Name = "settingsCamera1";
            this.settingsCamera1.Size = new System.Drawing.Size(139, 23);
            this.settingsCamera1.TabIndex = 3;
            this.settingsCamera1.Text = "Settings";
            this.settingsCamera1.UseVisualStyleBackColor = true;
            this.settingsCamera1.Click += new System.EventHandler(this.settingsCamera1_Click);
            // 
            // metecCameraFocusControl1
            // 
            this.metecCameraFocusControl1.Location = new System.Drawing.Point(3, 61);
            this.metecCameraFocusControl1.Name = "metecCameraFocusControl1";
            this.metecCameraFocusControl1.Size = new System.Drawing.Size(363, 130);
            this.metecCameraFocusControl1.TabIndex = 4;
            // 
            // TestMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 826);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TestMainForm";
            this.Text = "FLIR Camera Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CameraFeed2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraFeed1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox CameraFeed2;
        private System.Windows.Forms.PictureBox CameraFeed1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button connectCamera2;
        private System.Windows.Forms.Button disconnectCamera2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button connectCamera1;
        private System.Windows.Forms.Button disconnectCamera1;
        private System.Windows.Forms.Button startCamera1;
        private System.Windows.Forms.Button settingsCamera1;
        private System.Windows.Forms.Button settingsCamera2;
        private FLIRCameraTemperatureControl metecCameraTemperatureControl1;
        private FLIRCameraFocusControl metecCameraFocusControl1;
    }
}
namespace METEC
{
    partial class HexImagerExportForm
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
            this.outputPathGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exportFormatComboBox = new System.Windows.Forms.ComboBox();
            this.stitchCheckBox = new System.Windows.Forms.CheckBox();
            this.selectRecordingButton = new System.Windows.Forms.Button();
            this.browseRecordingButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.recordingTextBox = new System.Windows.Forms.TextBox();
            this.browseOutputPathButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.progressTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.outputPathGroupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.outputPathGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.78022F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.21978F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 233);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // outputPathGroupBox
            // 
            this.outputPathGroupBox.Controls.Add(this.label3);
            this.outputPathGroupBox.Controls.Add(this.exportFormatComboBox);
            this.outputPathGroupBox.Controls.Add(this.stitchCheckBox);
            this.outputPathGroupBox.Controls.Add(this.selectRecordingButton);
            this.outputPathGroupBox.Controls.Add(this.browseRecordingButton);
            this.outputPathGroupBox.Controls.Add(this.label2);
            this.outputPathGroupBox.Controls.Add(this.recordingTextBox);
            this.outputPathGroupBox.Controls.Add(this.browseOutputPathButton);
            this.outputPathGroupBox.Controls.Add(this.label1);
            this.outputPathGroupBox.Controls.Add(this.outputPathTextBox);
            this.outputPathGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputPathGroupBox.Location = new System.Drawing.Point(3, 39);
            this.outputPathGroupBox.Name = "outputPathGroupBox";
            this.outputPathGroupBox.Size = new System.Drawing.Size(478, 140);
            this.outputPathGroupBox.TabIndex = 0;
            this.outputPathGroupBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Format";
            // 
            // exportFormatComboBox
            // 
            this.exportFormatComboBox.FormattingEnabled = true;
            this.exportFormatComboBox.Location = new System.Drawing.Point(91, 93);
            this.exportFormatComboBox.Name = "exportFormatComboBox";
            this.exportFormatComboBox.Size = new System.Drawing.Size(129, 24);
            this.exportFormatComboBox.TabIndex = 7;
            // 
            // stitchCheckBox
            // 
            this.stitchCheckBox.AutoSize = true;
            this.stitchCheckBox.Location = new System.Drawing.Point(355, 104);
            this.stitchCheckBox.Name = "stitchCheckBox";
            this.stitchCheckBox.Size = new System.Drawing.Size(114, 21);
            this.stitchCheckBox.TabIndex = 9;
            this.stitchCheckBox.Text = "Stitch Images";
            this.stitchCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectRecordingButton
            // 
            this.selectRecordingButton.Location = new System.Drawing.Point(319, 23);
            this.selectRecordingButton.Name = "selectRecordingButton";
            this.selectRecordingButton.Size = new System.Drawing.Size(75, 28);
            this.selectRecordingButton.TabIndex = 6;
            this.selectRecordingButton.Text = "Select";
            this.selectRecordingButton.UseVisualStyleBackColor = true;
            this.selectRecordingButton.Click += new System.EventHandler(this.selectRecordingButton_Click);
            // 
            // browseRecordingButton
            // 
            this.browseRecordingButton.Location = new System.Drawing.Point(400, 23);
            this.browseRecordingButton.Name = "browseRecordingButton";
            this.browseRecordingButton.Size = new System.Drawing.Size(75, 28);
            this.browseRecordingButton.TabIndex = 5;
            this.browseRecordingButton.Text = "Browse";
            this.browseRecordingButton.UseVisualStyleBackColor = true;
            this.browseRecordingButton.Click += new System.EventHandler(this.browseRecordingButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Recording";
            // 
            // recordingTextBox
            // 
            this.recordingTextBox.Enabled = false;
            this.recordingTextBox.Location = new System.Drawing.Point(91, 26);
            this.recordingTextBox.Name = "recordingTextBox";
            this.recordingTextBox.Size = new System.Drawing.Size(222, 22);
            this.recordingTextBox.TabIndex = 3;
            // 
            // browseOutputPathButton
            // 
            this.browseOutputPathButton.Location = new System.Drawing.Point(400, 59);
            this.browseOutputPathButton.Name = "browseOutputPathButton";
            this.browseOutputPathButton.Size = new System.Drawing.Size(75, 28);
            this.browseOutputPathButton.TabIndex = 2;
            this.browseOutputPathButton.Text = "Browse";
            this.browseOutputPathButton.UseVisualStyleBackColor = true;
            this.browseOutputPathButton.Click += new System.EventHandler(this.browseOutputPathButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export To";
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(91, 62);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(303, 22);
            this.outputPathTextBox.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.Location = new System.Drawing.Point(40, 6);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(403, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.exportButton);
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Controls.Add(this.progressTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 185);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(478, 45);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(400, 3);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 28);
            this.exportButton.TabIndex = 3;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(319, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // progressTextBox
            // 
            this.progressTextBox.Enabled = false;
            this.progressTextBox.Location = new System.Drawing.Point(15, 3);
            this.progressTextBox.Name = "progressTextBox";
            this.progressTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressTextBox.Size = new System.Drawing.Size(298, 22);
            this.progressTextBox.TabIndex = 5;
            this.progressTextBox.Text = "Exporting 0 out of 0";
            // 
            // HexImagerExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 233);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HexImagerExportForm";
            this.Text = "HexImagerExportForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HexImagerExportForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.outputPathGroupBox.ResumeLayout(false);
            this.outputPathGroupBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox outputPathGroupBox;
        private System.Windows.Forms.Button browseOutputPathButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button selectRecordingButton;
        private System.Windows.Forms.Button browseRecordingButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox recordingTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox exportFormatComboBox;
        private System.Windows.Forms.CheckBox stitchCheckBox;
        private System.Windows.Forms.TextBox progressTextBox;
    }
}
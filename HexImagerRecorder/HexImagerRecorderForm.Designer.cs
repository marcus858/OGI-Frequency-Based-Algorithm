namespace METEC
{
    partial class HexImagerRecorderForm
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
            this.cameraStatusListView = new System.Windows.Forms.ListView();
            this.cameraIndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.connectionStatusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sensitivityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.frameRateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resolutionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.recorderStatusFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imageCountLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lostImagesLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.recSpeedGroupBox = new System.Windows.Forms.GroupBox();
            this.timeSpanTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recSpeedHighestRadioButton = new System.Windows.Forms.RadioButton();
            this.recSpeedIntervalRadioButton = new System.Windows.Forms.RadioButton();
            this.preRecordingGroupBox = new System.Windows.Forms.GroupBox();
            this.numFramesPreRecTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.preRecordingCheckBox = new System.Windows.Forms.CheckBox();
            this.recordingGroupBox = new System.Windows.Forms.GroupBox();
            this.snapshotButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.recordButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.hexImagerFileSelectControl = new METEC.HexImagerFileSelectControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.recorderStatusFlowLayout.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.recSpeedGroupBox.SuspendLayout();
            this.preRecordingGroupBox.SuspendLayout();
            this.recordingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.95765F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.04235F));
            this.tableLayoutPanel1.Controls.Add(this.cameraStatusListView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.hexImagerFileSelectControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cameraStatusListView
            // 
            this.cameraStatusListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cameraIndexColumn,
            this.connectionStatusColumn,
            this.sensitivityColumn,
            this.frameRateColumn,
            this.resolutionColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.cameraStatusListView, 2);
            this.cameraStatusListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraStatusListView.GridLines = true;
            this.cameraStatusListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.cameraStatusListView.Location = new System.Drawing.Point(4, 319);
            this.cameraStatusListView.Margin = new System.Windows.Forms.Padding(4);
            this.cameraStatusListView.Name = "cameraStatusListView";
            this.cameraStatusListView.Size = new System.Drawing.Size(974, 127);
            this.cameraStatusListView.TabIndex = 38;
            this.cameraStatusListView.UseCompatibleStateImageBehavior = false;
            this.cameraStatusListView.View = System.Windows.Forms.View.Details;
            // 
            // cameraIndexColumn
            // 
            this.cameraIndexColumn.Text = "Camera";
            this.cameraIndexColumn.Width = 150;
            // 
            // connectionStatusColumn
            // 
            this.connectionStatusColumn.Text = "Status";
            this.connectionStatusColumn.Width = 80;
            // 
            // sensitivityColumn
            // 
            this.sensitivityColumn.Text = "Sensitivity";
            this.sensitivityColumn.Width = 80;
            // 
            // frameRateColumn
            // 
            this.frameRateColumn.Text = "Frame Rate";
            this.frameRateColumn.Width = 100;
            // 
            // resolutionColumn
            // 
            this.resolutionColumn.Text = "Resolution";
            this.resolutionColumn.Width = 250;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.54478F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.45522F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.recorderStatusFlowLayout, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(572, 309);
            this.tableLayoutPanel2.TabIndex = 40;
            // 
            // recorderStatusFlowLayout
            // 
            this.recorderStatusFlowLayout.Controls.Add(this.label3);
            this.recorderStatusFlowLayout.Controls.Add(this.statusLabel);
            this.recorderStatusFlowLayout.Controls.Add(this.label5);
            this.recorderStatusFlowLayout.Controls.Add(this.imageCountLabel);
            this.recorderStatusFlowLayout.Controls.Add(this.label6);
            this.recorderStatusFlowLayout.Controls.Add(this.lostImagesLabel);
            this.recorderStatusFlowLayout.Controls.Add(this.label9);
            this.recorderStatusFlowLayout.Controls.Add(this.elapsedTimeLabel);
            this.recorderStatusFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recorderStatusFlowLayout.Location = new System.Drawing.Point(3, 3);
            this.recorderStatusFlowLayout.Name = "recorderStatusFlowLayout";
            this.recorderStatusFlowLayout.Size = new System.Drawing.Size(157, 303);
            this.recorderStatusFlowLayout.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusLabel.Location = new System.Drawing.Point(4, 17);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(110, 28);
            this.statusLabel.TabIndex = 33;
            this.statusLabel.Text = "Stopped";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 39;
            this.label5.Text = "Images:";
            // 
            // imageCountLabel
            // 
            this.imageCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.imageCountLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageCountLabel.Location = new System.Drawing.Point(4, 62);
            this.imageCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.imageCountLabel.Name = "imageCountLabel";
            this.imageCountLabel.Size = new System.Drawing.Size(110, 28);
            this.imageCountLabel.TabIndex = 34;
            this.imageCountLabel.Text = "0";
            this.imageCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Lost images:";
            // 
            // lostImagesLabel
            // 
            this.lostImagesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lostImagesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lostImagesLabel.Location = new System.Drawing.Point(4, 107);
            this.lostImagesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lostImagesLabel.Name = "lostImagesLabel";
            this.lostImagesLabel.Size = new System.Drawing.Size(110, 28);
            this.lostImagesLabel.TabIndex = 35;
            this.lostImagesLabel.Text = "0";
            this.lostImagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 135);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 37;
            this.label9.Text = "Elapsed time:";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.elapsedTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(4, 152);
            this.elapsedTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(110, 28);
            this.elapsedTimeLabel.TabIndex = 36;
            this.elapsedTimeLabel.Text = "0";
            this.elapsedTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.recSpeedGroupBox);
            this.flowLayoutPanel2.Controls.Add(this.preRecordingGroupBox);
            this.flowLayoutPanel2.Controls.Add(this.recordingGroupBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(166, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(403, 303);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // recSpeedGroupBox
            // 
            this.recSpeedGroupBox.Controls.Add(this.timeSpanTextBox);
            this.recSpeedGroupBox.Controls.Add(this.label1);
            this.recSpeedGroupBox.Controls.Add(this.recSpeedHighestRadioButton);
            this.recSpeedGroupBox.Controls.Add(this.recSpeedIntervalRadioButton);
            this.recSpeedGroupBox.Enabled = false;
            this.recSpeedGroupBox.Location = new System.Drawing.Point(4, 4);
            this.recSpeedGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.recSpeedGroupBox.Name = "recSpeedGroupBox";
            this.recSpeedGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.recSpeedGroupBox.Size = new System.Drawing.Size(373, 86);
            this.recSpeedGroupBox.TabIndex = 33;
            this.recSpeedGroupBox.TabStop = false;
            this.recSpeedGroupBox.Text = "Recording speed";
            // 
            // timeSpanTextBox
            // 
            this.timeSpanTextBox.Location = new System.Drawing.Point(275, 51);
            this.timeSpanTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.timeSpanTextBox.Name = "timeSpanTextBox";
            this.timeSpanTextBox.Size = new System.Drawing.Size(81, 22);
            this.timeSpanTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time span in seconds:";
            // 
            // recSpeedHighestRadioButton
            // 
            this.recSpeedHighestRadioButton.AutoSize = true;
            this.recSpeedHighestRadioButton.Checked = true;
            this.recSpeedHighestRadioButton.Location = new System.Drawing.Point(16, 23);
            this.recSpeedHighestRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.recSpeedHighestRadioButton.Name = "recSpeedHighestRadioButton";
            this.recSpeedHighestRadioButton.Size = new System.Drawing.Size(77, 21);
            this.recSpeedHighestRadioButton.TabIndex = 2;
            this.recSpeedHighestRadioButton.TabStop = true;
            this.recSpeedHighestRadioButton.Text = "Highest";
            this.recSpeedHighestRadioButton.UseVisualStyleBackColor = true;
            // 
            // recSpeedIntervalRadioButton
            // 
            this.recSpeedIntervalRadioButton.AutoSize = true;
            this.recSpeedIntervalRadioButton.Location = new System.Drawing.Point(16, 52);
            this.recSpeedIntervalRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.recSpeedIntervalRadioButton.Name = "recSpeedIntervalRadioButton";
            this.recSpeedIntervalRadioButton.Size = new System.Drawing.Size(75, 21);
            this.recSpeedIntervalRadioButton.TabIndex = 2;
            this.recSpeedIntervalRadioButton.Text = "Interval";
            this.recSpeedIntervalRadioButton.UseVisualStyleBackColor = true;
            // 
            // preRecordingGroupBox
            // 
            this.preRecordingGroupBox.Controls.Add(this.numFramesPreRecTextBox);
            this.preRecordingGroupBox.Controls.Add(this.label2);
            this.preRecordingGroupBox.Controls.Add(this.preRecordingCheckBox);
            this.preRecordingGroupBox.Enabled = false;
            this.preRecordingGroupBox.Location = new System.Drawing.Point(4, 98);
            this.preRecordingGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.preRecordingGroupBox.Name = "preRecordingGroupBox";
            this.preRecordingGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.preRecordingGroupBox.Size = new System.Drawing.Size(373, 54);
            this.preRecordingGroupBox.TabIndex = 34;
            this.preRecordingGroupBox.TabStop = false;
            this.preRecordingGroupBox.Text = "Pre-recording";
            // 
            // numFramesPreRecTextBox
            // 
            this.numFramesPreRecTextBox.Location = new System.Drawing.Point(275, 23);
            this.numFramesPreRecTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.numFramesPreRecTextBox.Name = "numFramesPreRecTextBox";
            this.numFramesPreRecTextBox.Size = new System.Drawing.Size(81, 22);
            this.numFramesPreRecTextBox.TabIndex = 2;
            this.numFramesPreRecTextBox.Text = "30";
            this.numFramesPreRecTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Frames:";
            // 
            // preRecordingCheckBox
            // 
            this.preRecordingCheckBox.AutoSize = true;
            this.preRecordingCheckBox.Location = new System.Drawing.Point(16, 25);
            this.preRecordingCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.preRecordingCheckBox.Name = "preRecordingCheckBox";
            this.preRecordingCheckBox.Size = new System.Drawing.Size(74, 21);
            this.preRecordingCheckBox.TabIndex = 0;
            this.preRecordingCheckBox.Text = "Enable";
            this.preRecordingCheckBox.UseVisualStyleBackColor = true;
            this.preRecordingCheckBox.CheckStateChanged += new System.EventHandler(this.preRecordingCheckBox_CheckStateChanged);
            // 
            // recordingGroupBox
            // 
            this.recordingGroupBox.Controls.Add(this.snapshotButton);
            this.recordingGroupBox.Controls.Add(this.pauseButton);
            this.recordingGroupBox.Controls.Add(this.outputPathLabel);
            this.recordingGroupBox.Controls.Add(this.recordButton);
            this.recordingGroupBox.Controls.Add(this.browseButton);
            this.recordingGroupBox.Location = new System.Drawing.Point(3, 159);
            this.recordingGroupBox.Name = "recordingGroupBox";
            this.recordingGroupBox.Size = new System.Drawing.Size(377, 89);
            this.recordingGroupBox.TabIndex = 35;
            this.recordingGroupBox.TabStop = false;
            // 
            // snapshotButton
            // 
            this.snapshotButton.Location = new System.Drawing.Point(139, 10);
            this.snapshotButton.Name = "snapshotButton";
            this.snapshotButton.Size = new System.Drawing.Size(89, 28);
            this.snapshotButton.TabIndex = 41;
            this.snapshotButton.Text = "Snapshot";
            this.snapshotButton.UseVisualStyleBackColor = true;
            this.snapshotButton.Click += new System.EventHandler(this.snapshotButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(293, 10);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(4);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(64, 28);
            this.pauseButton.TabIndex = 40;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // outputPathLabel
            // 
            this.outputPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputPathLabel.Location = new System.Drawing.Point(17, 51);
            this.outputPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outputPathLabel.Name = "outputPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(340, 23);
            this.outputPathLabel.TabIndex = 37;
            this.outputPathLabel.Text = "Path";
            // 
            // recordButton
            // 
            this.recordButton.Enabled = false;
            this.recordButton.Location = new System.Drawing.Point(235, 10);
            this.recordButton.Margin = new System.Windows.Forms.Padding(4);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(50, 28);
            this.recordButton.TabIndex = 39;
            this.recordButton.Text = "Rec";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(17, 10);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(80, 28);
            this.browseButton.TabIndex = 38;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // hexImagerFileSelectControl1
            // 
            this.hexImagerFileSelectControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexImagerFileSelectControl.Location = new System.Drawing.Point(581, 3);
            this.hexImagerFileSelectControl.Name = "hexImagerFileSelectControl1";
            this.hexImagerFileSelectControl.Size = new System.Drawing.Size(398, 309);
            this.hexImagerFileSelectControl.TabIndex = 41;
            // 
            // HexImagerRecorderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HexImagerRecorderForm";
            this.Text = "METECRecorderForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.METECRecorderForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.recorderStatusFlowLayout.ResumeLayout(false);
            this.recorderStatusFlowLayout.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.recSpeedGroupBox.ResumeLayout(false);
            this.recSpeedGroupBox.PerformLayout();
            this.preRecordingGroupBox.ResumeLayout(false);
            this.preRecordingGroupBox.PerformLayout();
            this.recordingGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView cameraStatusListView;
        private System.Windows.Forms.ColumnHeader cameraIndexColumn;
        private System.Windows.Forms.ColumnHeader connectionStatusColumn;
        private System.Windows.Forms.ColumnHeader sensitivityColumn;
        private System.Windows.Forms.ColumnHeader frameRateColumn;
        private System.Windows.Forms.ColumnHeader resolutionColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel recorderStatusFlowLayout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label imageCountLabel;
        private System.Windows.Forms.Label lostImagesLabel;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox recSpeedGroupBox;
        private System.Windows.Forms.TextBox timeSpanTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton recSpeedHighestRadioButton;
        private System.Windows.Forms.RadioButton recSpeedIntervalRadioButton;
        private System.Windows.Forms.GroupBox preRecordingGroupBox;
        private System.Windows.Forms.TextBox numFramesPreRecTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox preRecordingCheckBox;
        private System.Windows.Forms.GroupBox recordingGroupBox;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Label outputPathLabel;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button snapshotButton;
        private HexImagerFileSelectControl hexImagerFileSelectControl;
    }
}
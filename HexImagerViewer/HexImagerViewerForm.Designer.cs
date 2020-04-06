namespace METEC
{
    partial class HexImagerViewerForm
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
            this.playbackGroupBox = new System.Windows.Forms.GroupBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.fileGroupBox = new System.Windows.Forms.GroupBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.pictureBoxTable = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.selectedIndexBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setTempButton = new System.Windows.Forms.Button();
            this.maxTempTextBox = new System.Windows.Forms.TextBox();
            this.minTempTextBox = new System.Windows.Forms.TextBox();
            this.rangeSliderControl1 = new IRImageReaderDemo.RangeSliderControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.playbackGroupBox.SuspendLayout();
            this.fileGroupBox.SuspendLayout();
            this.pictureBoxTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedIndexBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.45055F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.54945F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.playbackGroupBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.fileGroupBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxTable, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectedIndexBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rangeSliderControl1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.84F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.76F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 732);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // playbackGroupBox
            // 
            this.playbackGroupBox.Controls.Add(this.nextButton);
            this.playbackGroupBox.Controls.Add(this.stopButton);
            this.playbackGroupBox.Controls.Add(this.playButton);
            this.playbackGroupBox.Controls.Add(this.previousButton);
            this.playbackGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playbackGroupBox.Enabled = false;
            this.playbackGroupBox.Location = new System.Drawing.Point(3, 628);
            this.playbackGroupBox.Name = "playbackGroupBox";
            this.playbackGroupBox.Size = new System.Drawing.Size(692, 101);
            this.playbackGroupBox.TabIndex = 6;
            this.playbackGroupBox.TabStop = false;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(401, 5);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(92, 29);
            this.nextButton.TabIndex = 3;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(303, 5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(92, 29);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(205, 5);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(92, 29);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(107, 5);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(92, 29);
            this.previousButton.TabIndex = 0;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // fileGroupBox
            // 
            this.fileGroupBox.Controls.Add(this.exportButton);
            this.fileGroupBox.Controls.Add(this.selectButton);
            this.fileGroupBox.Controls.Add(this.browseButton);
            this.fileGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileGroupBox.Location = new System.Drawing.Point(701, 628);
            this.fileGroupBox.Name = "fileGroupBox";
            this.fileGroupBox.Size = new System.Drawing.Size(302, 101);
            this.fileGroupBox.TabIndex = 7;
            this.fileGroupBox.TabStop = false;
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(201, 5);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(92, 29);
            this.exportButton.TabIndex = 6;
            this.exportButton.Text = "Export...";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(104, 5);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(92, 29);
            this.selectButton.TabIndex = 5;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(6, 5);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(92, 29);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // pictureBoxTable
            // 
            this.pictureBoxTable.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBoxTable, 2);
            this.pictureBoxTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pictureBoxTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pictureBoxTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pictureBoxTable.Controls.Add(this.pictureBox6, 2, 1);
            this.pictureBoxTable.Controls.Add(this.pictureBox5, 1, 1);
            this.pictureBoxTable.Controls.Add(this.pictureBox4, 0, 1);
            this.pictureBoxTable.Controls.Add(this.pictureBox3, 2, 0);
            this.pictureBoxTable.Controls.Add(this.pictureBox2, 1, 0);
            this.pictureBoxTable.Controls.Add(this.pictureBox1, 0, 0);
            this.pictureBoxTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTable.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxTable.Name = "pictureBoxTable";
            this.pictureBoxTable.RowCount = 2;
            this.pictureBoxTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pictureBoxTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pictureBoxTable.Size = new System.Drawing.Size(1000, 518);
            this.pictureBoxTable.TabIndex = 8;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox6.Location = new System.Drawing.Point(669, 262);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(328, 253);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Location = new System.Drawing.Point(336, 262);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(327, 253);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Location = new System.Drawing.Point(3, 262);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(327, 253);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(669, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(328, 253);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(336, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(327, 253);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 253);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // selectedIndexBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.selectedIndexBar, 2);
            this.selectedIndexBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedIndexBar.Enabled = false;
            this.selectedIndexBar.Location = new System.Drawing.Point(3, 527);
            this.selectedIndexBar.Name = "selectedIndexBar";
            this.selectedIndexBar.Size = new System.Drawing.Size(1000, 34);
            this.selectedIndexBar.TabIndex = 9;
            this.selectedIndexBar.ValueChanged += new System.EventHandler(this.selectedIndexBar_ValueChanged);
            this.selectedIndexBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectedIndexBar_MouseDown);
            this.selectedIndexBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.selectedIndexBar_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.setTempButton);
            this.groupBox1.Controls.Add(this.maxTempTextBox);
            this.groupBox1.Controls.Add(this.minTempTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 567);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 55);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature";
            // 
            // setTempButton
            // 
            this.setTempButton.Location = new System.Drawing.Point(303, 20);
            this.setTempButton.Name = "setTempButton";
            this.setTempButton.Size = new System.Drawing.Size(75, 23);
            this.setTempButton.TabIndex = 2;
            this.setTempButton.Text = "Set";
            this.setTempButton.UseVisualStyleBackColor = true;
            this.setTempButton.Click += new System.EventHandler(this.setTempButton_Click);
            // 
            // maxTempTextBox
            // 
            this.maxTempTextBox.Location = new System.Drawing.Point(205, 21);
            this.maxTempTextBox.Name = "maxTempTextBox";
            this.maxTempTextBox.Size = new System.Drawing.Size(72, 22);
            this.maxTempTextBox.TabIndex = 1;
            // 
            // minTempTextBox
            // 
            this.minTempTextBox.Location = new System.Drawing.Point(127, 21);
            this.minTempTextBox.Name = "minTempTextBox";
            this.minTempTextBox.Size = new System.Drawing.Size(72, 22);
            this.minTempTextBox.TabIndex = 0;
            // 
            // rangeSliderControl1
            // 
            this.rangeSliderControl1.BackColor = System.Drawing.Color.Transparent;
            this.rangeSliderControl1.Location = new System.Drawing.Point(701, 567);
            this.rangeSliderControl1.Name = "rangeSliderControl1";
            this.rangeSliderControl1.Size = new System.Drawing.Size(302, 30);
            this.rangeSliderControl1.TabIndex = 11;
            this.rangeSliderControl1.Text = "rangeSliderControl1";
            // 
            // HexImagerViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 732);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HexImagerViewerForm";
            this.Text = "METECPlaybackForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.METECViewerForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.playbackGroupBox.ResumeLayout(false);
            this.fileGroupBox.ResumeLayout(false);
            this.pictureBoxTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedIndexBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox playbackGroupBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.GroupBox fileGroupBox;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TableLayoutPanel pictureBoxTable;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar selectedIndexBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button setTempButton;
        private System.Windows.Forms.TextBox maxTempTextBox;
        private System.Windows.Forms.TextBox minTempTextBox;
        private IRImageReaderDemo.RangeSliderControl rangeSliderControl1;
        private System.Windows.Forms.Button exportButton;
    }
}
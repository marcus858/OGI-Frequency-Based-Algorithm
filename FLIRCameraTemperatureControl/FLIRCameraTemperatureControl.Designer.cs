namespace METEC
{
    partial class FLIRCameraTemperatureControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxTemperature = new System.Windows.Forms.GroupBox();
            this.comboBoxTemperature = new System.Windows.Forms.ComboBox();
            this.buttonSetTemperatureRange = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaxScale = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxScale = new System.Windows.Forms.GroupBox();
            this.groupBoxManualScale = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSetScale = new System.Windows.Forms.Button();
            this.textBoxMinScale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonManualScale = new System.Windows.Forms.RadioButton();
            this.radioButtonAutoScale = new System.Windows.Forms.RadioButton();
            this.groupBoxRefresh = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBoxTemperature.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxScale.SuspendLayout();
            this.groupBoxManualScale.SuspendLayout();
            this.groupBoxRefresh.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTemperature
            // 
            this.groupBoxTemperature.Controls.Add(this.comboBoxTemperature);
            this.groupBoxTemperature.Controls.Add(this.buttonSetTemperatureRange);
            this.groupBoxTemperature.Controls.Add(this.label2);
            this.groupBoxTemperature.Controls.Add(this.label1);
            this.groupBoxTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTemperature.Enabled = false;
            this.groupBoxTemperature.Location = new System.Drawing.Point(4, 4);
            this.groupBoxTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxTemperature.Name = "groupBoxTemperature";
            this.groupBoxTemperature.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxTemperature.Size = new System.Drawing.Size(365, 55);
            this.groupBoxTemperature.TabIndex = 27;
            this.groupBoxTemperature.TabStop = false;
            this.groupBoxTemperature.Text = "Temperature";
            // 
            // comboBoxTemperature
            // 
            this.comboBoxTemperature.FormattingEnabled = true;
            this.comboBoxTemperature.Location = new System.Drawing.Point(95, 27);
            this.comboBoxTemperature.Name = "comboBoxTemperature";
            this.comboBoxTemperature.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTemperature.TabIndex = 4;
            // 
            // buttonSetTemperatureRange
            // 
            this.buttonSetTemperatureRange.Location = new System.Drawing.Point(272, 27);
            this.buttonSetTemperatureRange.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetTemperatureRange.Name = "buttonSetTemperatureRange";
            this.buttonSetTemperatureRange.Size = new System.Drawing.Size(43, 28);
            this.buttonSetTemperatureRange.TabIndex = 3;
            this.buttonSetTemperatureRange.Text = "Set";
            this.buttonSetTemperatureRange.UseVisualStyleBackColor = true;
            this.buttonSetTemperatureRange.Click += new System.EventHandler(this.buttonSetTemperatureRange_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "K";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Range";
            // 
            // textBoxMaxScale
            // 
            this.textBoxMaxScale.Location = new System.Drawing.Point(58, 58);
            this.textBoxMaxScale.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMaxScale.Name = "textBoxMaxScale";
            this.textBoxMaxScale.Size = new System.Drawing.Size(56, 22);
            this.textBoxMaxScale.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxTemperature, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxScale, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxRefresh, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.42105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.57895F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 224);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // groupBoxScale
            // 
            this.groupBoxScale.Controls.Add(this.groupBoxManualScale);
            this.groupBoxScale.Controls.Add(this.radioButtonManualScale);
            this.groupBoxScale.Controls.Add(this.radioButtonAutoScale);
            this.groupBoxScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxScale.Enabled = false;
            this.groupBoxScale.Location = new System.Drawing.Point(3, 66);
            this.groupBoxScale.Name = "groupBoxScale";
            this.groupBoxScale.Size = new System.Drawing.Size(367, 94);
            this.groupBoxScale.TabIndex = 28;
            this.groupBoxScale.TabStop = false;
            this.groupBoxScale.Text = "Scale";
            // 
            // groupBoxManualScale
            // 
            this.groupBoxManualScale.Controls.Add(this.label4);
            this.groupBoxManualScale.Controls.Add(this.label6);
            this.groupBoxManualScale.Controls.Add(this.textBoxMaxScale);
            this.groupBoxManualScale.Controls.Add(this.label5);
            this.groupBoxManualScale.Controls.Add(this.buttonSetScale);
            this.groupBoxManualScale.Controls.Add(this.textBoxMinScale);
            this.groupBoxManualScale.Controls.Add(this.label3);
            this.groupBoxManualScale.Enabled = false;
            this.groupBoxManualScale.Location = new System.Drawing.Point(101, 11);
            this.groupBoxManualScale.Name = "groupBoxManualScale";
            this.groupBoxManualScale.Size = new System.Drawing.Size(244, 86);
            this.groupBoxManualScale.TabIndex = 12;
            this.groupBoxManualScale.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "K";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max";
            // 
            // buttonSetScale
            // 
            this.buttonSetScale.Location = new System.Drawing.Point(172, 53);
            this.buttonSetScale.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetScale.Name = "buttonSetScale";
            this.buttonSetScale.Size = new System.Drawing.Size(43, 28);
            this.buttonSetScale.TabIndex = 4;
            this.buttonSetScale.Text = "Set";
            this.buttonSetScale.UseVisualStyleBackColor = true;
            this.buttonSetScale.Click += new System.EventHandler(this.buttonSetScale_Click);
            // 
            // textBoxMinScale
            // 
            this.textBoxMinScale.Location = new System.Drawing.Point(58, 22);
            this.textBoxMinScale.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMinScale.Name = "textBoxMinScale";
            this.textBoxMinScale.Size = new System.Drawing.Size(56, 22);
            this.textBoxMinScale.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "K";
            // 
            // radioButtonManualScale
            // 
            this.radioButtonManualScale.AutoSize = true;
            this.radioButtonManualScale.Location = new System.Drawing.Point(20, 71);
            this.radioButtonManualScale.Name = "radioButtonManualScale";
            this.radioButtonManualScale.Size = new System.Drawing.Size(75, 21);
            this.radioButtonManualScale.TabIndex = 9;
            this.radioButtonManualScale.TabStop = true;
            this.radioButtonManualScale.Text = "Manual";
            this.radioButtonManualScale.UseVisualStyleBackColor = true;
            this.radioButtonManualScale.CheckedChanged += new System.EventHandler(this.radioButtonScaleMode_CheckChanged);
            // 
            // radioButtonAutoScale
            // 
            this.radioButtonAutoScale.AutoSize = true;
            this.radioButtonAutoScale.Location = new System.Drawing.Point(20, 38);
            this.radioButtonAutoScale.Name = "radioButtonAutoScale";
            this.radioButtonAutoScale.Size = new System.Drawing.Size(58, 21);
            this.radioButtonAutoScale.TabIndex = 8;
            this.radioButtonAutoScale.TabStop = true;
            this.radioButtonAutoScale.Text = "Auto";
            this.radioButtonAutoScale.UseVisualStyleBackColor = true;
            this.radioButtonAutoScale.CheckedChanged += new System.EventHandler(this.radioButtonScaleMode_CheckChanged);
            // 
            // groupBoxRefresh
            // 
            this.groupBoxRefresh.Controls.Add(this.buttonRefresh);
            this.groupBoxRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRefresh.Location = new System.Drawing.Point(3, 166);
            this.groupBoxRefresh.Name = "groupBoxRefresh";
            this.groupBoxRefresh.Size = new System.Drawing.Size(367, 55);
            this.groupBoxRefresh.TabIndex = 29;
            this.groupBoxRefresh.TabStop = false;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(228, 18);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(88, 28);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // METECCameraTemperatureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "METECCameraTemperatureControl";
            this.Size = new System.Drawing.Size(373, 224);
            this.groupBoxTemperature.ResumeLayout(false);
            this.groupBoxTemperature.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxScale.ResumeLayout(false);
            this.groupBoxScale.PerformLayout();
            this.groupBoxManualScale.ResumeLayout(false);
            this.groupBoxManualScale.PerformLayout();
            this.groupBoxRefresh.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTemperature;
        private System.Windows.Forms.Button buttonSetTemperatureRange;
        private System.Windows.Forms.TextBox textBoxMaxScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxScale;
        private System.Windows.Forms.Button buttonSetScale;
        private System.Windows.Forms.ComboBox comboBoxTemperature;
        private System.Windows.Forms.GroupBox groupBoxManualScale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMinScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonManualScale;
        private System.Windows.Forms.RadioButton radioButtonAutoScale;
        private System.Windows.Forms.GroupBox groupBoxRefresh;
        private System.Windows.Forms.Button buttonRefresh;
    }
}

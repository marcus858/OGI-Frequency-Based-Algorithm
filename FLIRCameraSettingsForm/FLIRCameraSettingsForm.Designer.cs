namespace METEC
{
    partial class FLIRCameraSettingsForm
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
            this.resolutionMenu = new System.Windows.Forms.ComboBox();
            this.frameRateLabel = new System.Windows.Forms.TextBox();
            this.temperatureLabel = new System.Windows.Forms.TextBox();
            this.sensitivityLabel = new System.Windows.Forms.TextBox();
            this.sensitivityGroup = new System.Windows.Forms.GroupBox();
            this.lowSensitivityButton = new System.Windows.Forms.RadioButton();
            this.highSensitivityButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.maxTemperatureBox = new System.Windows.Forms.TextBox();
            this.maxTemperatureLabel = new System.Windows.Forms.TextBox();
            this.minTemperatureLabel = new System.Windows.Forms.TextBox();
            this.minTemperatureBox = new System.Windows.Forms.TextBox();
            this.resolutionLabel = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.frameRateMenu = new System.Windows.Forms.ComboBox();
            this.applyToAllBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.sensitivityGroup.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.93822F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.06178F));
            this.tableLayoutPanel1.Controls.Add(this.resolutionMenu, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.frameRateLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.temperatureLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sensitivityLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sensitivityGroup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.resolutionLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.frameRateMenu, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.applyToAllBox, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 322);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // resolutionMenu
            // 
            this.resolutionMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resolutionMenu.FormattingEnabled = true;
            this.resolutionMenu.Location = new System.Drawing.Point(192, 228);
            this.resolutionMenu.Name = "resolutionMenu";
            this.resolutionMenu.Size = new System.Drawing.Size(98, 24);
            this.resolutionMenu.TabIndex = 10;
            // 
            // frameRateLabel
            // 
            this.frameRateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.frameRateLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.frameRateLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frameRateLabel.Enabled = false;
            this.frameRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameRateLabel.Location = new System.Drawing.Point(4, 177);
            this.frameRateLabel.Name = "frameRateLabel";
            this.frameRateLabel.ReadOnly = true;
            this.frameRateLabel.Size = new System.Drawing.Size(133, 15);
            this.frameRateLabel.TabIndex = 4;
            this.frameRateLabel.Text = "Frame Rate";
            this.frameRateLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // temperatureLabel
            // 
            this.temperatureLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.temperatureLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.temperatureLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.temperatureLabel.Enabled = false;
            this.temperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperatureLabel.Location = new System.Drawing.Point(4, 113);
            this.temperatureLabel.Name = "temperatureLabel";
            this.temperatureLabel.ReadOnly = true;
            this.temperatureLabel.Size = new System.Drawing.Size(133, 15);
            this.temperatureLabel.TabIndex = 2;
            this.temperatureLabel.Text = "Temperature (C)";
            this.temperatureLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sensitivityLabel
            // 
            this.sensitivityLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sensitivityLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sensitivityLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.sensitivityLabel.Enabled = false;
            this.sensitivityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sensitivityLabel.Location = new System.Drawing.Point(4, 34);
            this.sensitivityLabel.Name = "sensitivityLabel";
            this.sensitivityLabel.ReadOnly = true;
            this.sensitivityLabel.Size = new System.Drawing.Size(133, 15);
            this.sensitivityLabel.TabIndex = 0;
            this.sensitivityLabel.Text = "Sensitivity";
            this.sensitivityLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sensitivityGroup
            // 
            this.sensitivityGroup.Controls.Add(this.lowSensitivityButton);
            this.sensitivityGroup.Controls.Add(this.highSensitivityButton);
            this.sensitivityGroup.Location = new System.Drawing.Point(143, 3);
            this.sensitivityGroup.Name = "sensitivityGroup";
            this.sensitivityGroup.Size = new System.Drawing.Size(196, 78);
            this.sensitivityGroup.TabIndex = 1;
            this.sensitivityGroup.TabStop = false;
            // 
            // lowSensitivityButton
            // 
            this.lowSensitivityButton.AutoSize = true;
            this.lowSensitivityButton.Checked = true;
            this.lowSensitivityButton.Location = new System.Drawing.Point(21, 48);
            this.lowSensitivityButton.Name = "lowSensitivityButton";
            this.lowSensitivityButton.Size = new System.Drawing.Size(54, 21);
            this.lowSensitivityButton.TabIndex = 1;
            this.lowSensitivityButton.TabStop = true;
            this.lowSensitivityButton.Text = "Low";
            this.lowSensitivityButton.UseVisualStyleBackColor = true;
            // 
            // highSensitivityButton
            // 
            this.highSensitivityButton.AutoSize = true;
            this.highSensitivityButton.Location = new System.Drawing.Point(21, 21);
            this.highSensitivityButton.Name = "highSensitivityButton";
            this.highSensitivityButton.Size = new System.Drawing.Size(58, 21);
            this.highSensitivityButton.TabIndex = 0;
            this.highSensitivityButton.Text = "High";
            this.highSensitivityButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.65101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.34899F));
            this.tableLayoutPanel2.Controls.Add(this.maxTemperatureBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.maxTemperatureLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.minTemperatureLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.minTemperatureBox, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(143, 87);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(196, 67);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // maxTemperatureBox
            // 
            this.maxTemperatureBox.Location = new System.Drawing.Point(96, 36);
            this.maxTemperatureBox.Name = "maxTemperatureBox";
            this.maxTemperatureBox.Size = new System.Drawing.Size(97, 22);
            this.maxTemperatureBox.TabIndex = 6;
            this.maxTemperatureBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maxTemperatureBox_KeyPress);
            this.maxTemperatureBox.Leave += new System.EventHandler(this.maxTemperatureBox_Leave);
            // 
            // maxTemperatureLabel
            // 
            this.maxTemperatureLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.maxTemperatureLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxTemperatureLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.maxTemperatureLabel.Enabled = false;
            this.maxTemperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxTemperatureLabel.Location = new System.Drawing.Point(22, 42);
            this.maxTemperatureLabel.Name = "maxTemperatureLabel";
            this.maxTemperatureLabel.ReadOnly = true;
            this.maxTemperatureLabel.Size = new System.Drawing.Size(68, 15);
            this.maxTemperatureLabel.TabIndex = 5;
            this.maxTemperatureLabel.Text = "Maximum";
            this.maxTemperatureLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minTemperatureLabel
            // 
            this.minTemperatureLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.minTemperatureLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minTemperatureLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.minTemperatureLabel.Enabled = false;
            this.minTemperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTemperatureLabel.Location = new System.Drawing.Point(21, 9);
            this.minTemperatureLabel.Name = "minTemperatureLabel";
            this.minTemperatureLabel.ReadOnly = true;
            this.minTemperatureLabel.Size = new System.Drawing.Size(69, 15);
            this.minTemperatureLabel.TabIndex = 3;
            this.minTemperatureLabel.Text = "Minimum";
            this.minTemperatureLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minTemperatureBox
            // 
            this.minTemperatureBox.Location = new System.Drawing.Point(96, 3);
            this.minTemperatureBox.Name = "minTemperatureBox";
            this.minTemperatureBox.Size = new System.Drawing.Size(97, 22);
            this.minTemperatureBox.TabIndex = 4;
            this.minTemperatureBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minTemperatureBox_KeyPress);
            this.minTemperatureBox.Leave += new System.EventHandler(this.minTemperatureBox_Leave);
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.resolutionLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resolutionLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.resolutionLabel.Enabled = false;
            this.resolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resolutionLabel.Location = new System.Drawing.Point(4, 233);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.ReadOnly = true;
            this.resolutionLabel.Size = new System.Drawing.Size(133, 15);
            this.resolutionLabel.TabIndex = 6;
            this.resolutionLabel.Text = "Resolution";
            this.resolutionLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.applyButton);
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(143, 271);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(196, 48);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.applyButton.Location = new System.Drawing.Point(118, 3);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 40);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelButton.Location = new System.Drawing.Point(37, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 40);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // frameRateMenu
            // 
            this.frameRateMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.frameRateMenu.FormattingEnabled = true;
            this.frameRateMenu.Location = new System.Drawing.Point(192, 172);
            this.frameRateMenu.Name = "frameRateMenu";
            this.frameRateMenu.Size = new System.Drawing.Size(98, 24);
            this.frameRateMenu.TabIndex = 9;
            // 
            // applyToAllBox
            // 
            this.applyToAllBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.applyToAllBox.AutoSize = true;
            this.applyToAllBox.Location = new System.Drawing.Point(3, 284);
            this.applyToAllBox.Name = "applyToAllBox";
            this.applyToAllBox.Size = new System.Drawing.Size(100, 21);
            this.applyToAllBox.TabIndex = 11;
            this.applyToAllBox.Text = "Apply to All";
            this.applyToAllBox.UseVisualStyleBackColor = true;
            // 
            // METECSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 322);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "METECSettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.sensitivityGroup.ResumeLayout(false);
            this.sensitivityGroup.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox sensitivityLabel;
        private System.Windows.Forms.GroupBox sensitivityGroup;
        private System.Windows.Forms.RadioButton lowSensitivityButton;
        private System.Windows.Forms.RadioButton highSensitivityButton;
        private System.Windows.Forms.TextBox temperatureLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox maxTemperatureBox;
        private System.Windows.Forms.TextBox maxTemperatureLabel;
        private System.Windows.Forms.TextBox minTemperatureLabel;
        private System.Windows.Forms.TextBox minTemperatureBox;
        private System.Windows.Forms.TextBox frameRateLabel;
        private System.Windows.Forms.TextBox resolutionLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox frameRateMenu;
        private System.Windows.Forms.ComboBox resolutionMenu;
        private System.Windows.Forms.CheckBox applyToAllBox;
    }
}
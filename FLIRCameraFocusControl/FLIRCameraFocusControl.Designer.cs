namespace METEC
{
    partial class FLIRCameraFocusControl
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
            this.groupBoxFocus = new System.Windows.Forms.GroupBox();
            this.buttonStopFocus = new System.Windows.Forms.Button();
            this.buttonFocusDistance = new System.Windows.Forms.Button();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFocusFar = new System.Windows.Forms.Button();
            this.buttonFocusAuto = new System.Windows.Forms.Button();
            this.buttonFocusNear = new System.Windows.Forms.Button();
            this.groupBoxFocus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFocus
            // 
            this.groupBoxFocus.Controls.Add(this.buttonStopFocus);
            this.groupBoxFocus.Controls.Add(this.buttonFocusDistance);
            this.groupBoxFocus.Controls.Add(this.textBoxDistance);
            this.groupBoxFocus.Controls.Add(this.label2);
            this.groupBoxFocus.Controls.Add(this.label1);
            this.groupBoxFocus.Controls.Add(this.buttonFocusFar);
            this.groupBoxFocus.Controls.Add(this.buttonFocusAuto);
            this.groupBoxFocus.Controls.Add(this.buttonFocusNear);
            this.groupBoxFocus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFocus.Enabled = false;
            this.groupBoxFocus.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFocus.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxFocus.Name = "groupBoxFocus";
            this.groupBoxFocus.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxFocus.Size = new System.Drawing.Size(363, 130);
            this.groupBoxFocus.TabIndex = 27;
            this.groupBoxFocus.TabStop = false;
            this.groupBoxFocus.Text = "Focus";
            // 
            // buttonStopFocus
            // 
            this.buttonStopFocus.Location = new System.Drawing.Point(231, 83);
            this.buttonStopFocus.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStopFocus.Name = "buttonStopFocus";
            this.buttonStopFocus.Size = new System.Drawing.Size(100, 28);
            this.buttonStopFocus.TabIndex = 4;
            this.buttonStopFocus.Text = "Stop";
            this.buttonStopFocus.UseVisualStyleBackColor = true;
            this.buttonStopFocus.Click += new System.EventHandler(this._camera_StopFocus);
            // 
            // buttonFocusDistance
            // 
            this.buttonFocusDistance.Location = new System.Drawing.Point(165, 82);
            this.buttonFocusDistance.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFocusDistance.Name = "buttonFocusDistance";
            this.buttonFocusDistance.Size = new System.Drawing.Size(43, 28);
            this.buttonFocusDistance.TabIndex = 3;
            this.buttonFocusDistance.Text = "Set";
            this.buttonFocusDistance.UseVisualStyleBackColor = true;
            this.buttonFocusDistance.Click += new System.EventHandler(this.buttonFocusDistance_Click);
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(72, 85);
            this.textBoxDistance.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(71, 22);
            this.textBoxDistance.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "m";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Distance";
            // 
            // buttonFocusFar
            // 
            this.buttonFocusFar.Location = new System.Drawing.Point(231, 43);
            this.buttonFocusFar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFocusFar.Name = "buttonFocusFar";
            this.buttonFocusFar.Size = new System.Drawing.Size(100, 28);
            this.buttonFocusFar.TabIndex = 0;
            this.buttonFocusFar.Text = "Far";
            this.buttonFocusFar.UseVisualStyleBackColor = true;
            this.buttonFocusFar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonFocusFar_MouseDown);
            this.buttonFocusFar.MouseUp += new System.Windows.Forms.MouseEventHandler(this._camera_StopFocus);
            // 
            // buttonFocusAuto
            // 
            this.buttonFocusAuto.Location = new System.Drawing.Point(123, 43);
            this.buttonFocusAuto.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFocusAuto.Name = "buttonFocusAuto";
            this.buttonFocusAuto.Size = new System.Drawing.Size(100, 28);
            this.buttonFocusAuto.TabIndex = 0;
            this.buttonFocusAuto.Text = "Auto";
            this.buttonFocusAuto.UseVisualStyleBackColor = true;
            this.buttonFocusAuto.Click += new System.EventHandler(this.buttonFocusAuto_Click);
            // 
            // buttonFocusNear
            // 
            this.buttonFocusNear.Location = new System.Drawing.Point(15, 43);
            this.buttonFocusNear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFocusNear.Name = "buttonFocusNear";
            this.buttonFocusNear.Size = new System.Drawing.Size(100, 28);
            this.buttonFocusNear.TabIndex = 0;
            this.buttonFocusNear.Text = "Near";
            this.buttonFocusNear.UseVisualStyleBackColor = true;
            this.buttonFocusNear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonFocusNear_MouseDown);
            this.buttonFocusNear.MouseUp += new System.Windows.Forms.MouseEventHandler(this._camera_StopFocus);
            // 
            // METECCameraFocusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxFocus);
            this.Name = "METECCameraFocusControl";
            this.Size = new System.Drawing.Size(363, 130);
            this.groupBoxFocus.ResumeLayout(false);
            this.groupBoxFocus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFocus;
        private System.Windows.Forms.Button buttonFocusDistance;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFocusFar;
        private System.Windows.Forms.Button buttonFocusAuto;
        private System.Windows.Forms.Button buttonFocusNear;
        private System.Windows.Forms.Button buttonStopFocus;
    }
}

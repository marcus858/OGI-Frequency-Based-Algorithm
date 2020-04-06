namespace METEC
{
    partial class HexImagerFileSelectControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.recordingsListView = new System.Windows.Forms.ListView();
            this.timestampColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recordingTypeColum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numCamerasColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.extensionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.10687F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.89313F));
            this.tableLayoutPanel1.Controls.Add(this.recordingsListView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pathLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.browseButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.734513F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.26549F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(568, 339);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // recordingsListView
            // 
            this.recordingsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timestampColumn,
            this.recordingTypeColum,
            this.numCamerasColumn,
            this.extensionColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.recordingsListView, 2);
            this.recordingsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingsListView.GridLines = true;
            this.recordingsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.recordingsListView.Location = new System.Drawing.Point(4, 37);
            this.recordingsListView.Margin = new System.Windows.Forms.Padding(4);
            this.recordingsListView.Name = "recordingsListView";
            this.recordingsListView.Size = new System.Drawing.Size(560, 298);
            this.recordingsListView.TabIndex = 39;
            this.recordingsListView.UseCompatibleStateImageBehavior = false;
            this.recordingsListView.View = System.Windows.Forms.View.Details;
            this.recordingsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.recordingsListView_MouseDoubleClick);
            // 
            // timestampColumn
            // 
            this.timestampColumn.Text = "Time";
            this.timestampColumn.Width = 156;
            // 
            // recordingTypeColum
            // 
            this.recordingTypeColum.Text = "Type";
            this.recordingTypeColum.Width = 105;
            // 
            // numCamerasColumn
            // 
            this.numCamerasColumn.Text = "Cameras";
            this.numCamerasColumn.Width = 80;
            // 
            // extensionColumn
            // 
            this.extensionColumn.Text = "Extension";
            this.extensionColumn.Width = 80;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathLabel.Location = new System.Drawing.Point(3, 0);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(454, 33);
            this.pathLabel.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(463, 3);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(93, 27);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // HexImagerFileSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HexImagerFileSelectControl";
            this.Size = new System.Drawing.Size(568, 339);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView recordingsListView;
        private System.Windows.Forms.ColumnHeader timestampColumn;
        private System.Windows.Forms.ColumnHeader recordingTypeColum;
        private System.Windows.Forms.ColumnHeader numCamerasColumn;
        private System.Windows.Forms.ColumnHeader extensionColumn;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button browseButton;
    }
}

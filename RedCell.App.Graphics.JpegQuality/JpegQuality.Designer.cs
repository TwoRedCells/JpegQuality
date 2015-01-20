namespace RedCell.Apps.Graphics
{
    partial class JpegQuality
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
            System.Windows.Forms.ToolStrip toolStrip1;
            System.Windows.Forms.ToolStripLabel toolStripLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JpegQuality));
            this.QualityBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.DropLabel = new System.Windows.Forms.Label();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel1,
            this.QualityBox});
            toolStrip1.Location = new System.Drawing.Point(9, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(134, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            toolStripLabel1.Text = "Quality";
            // 
            // QualityBox
            // 
            this.QualityBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.QualityBox.Name = "QualityBox";
            this.QualityBox.Size = new System.Drawing.Size(75, 25);
            this.QualityBox.Validated += new System.EventHandler(this.QualityBox_Validated);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.DropLabel);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(284, 90);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(284, 115);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            // 
            // DropLabel
            // 
            this.DropLabel.AllowDrop = true;
            this.DropLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DropLabel.Location = new System.Drawing.Point(0, 0);
            this.DropLabel.Name = "DropLabel";
            this.DropLabel.Size = new System.Drawing.Size(284, 90);
            this.DropLabel.TabIndex = 0;
            this.DropLabel.Text = "Drop JPEG files here to reduce their quality.\r\nA copy will be placed in the same " +
    "directory.";
            this.DropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DropLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropLabel_DragDrop);
            this.DropLabel.DragOver += new System.Windows.Forms.DragEventHandler(this.DropLabel_DragOver);
            // 
            // JpegQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 115);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JpegQuality";
            this.Text = "JPEG Quality";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Label DropLabel;
        private System.Windows.Forms.ToolStripComboBox QualityBox;
    }
}


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
            System.Windows.Forms.ToolStripContainer toolStripContainer1;
            System.Windows.Forms.ToolStrip toolStrip2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JpegQuality));
            this.QualityBox = new System.Windows.Forms.ToolStripComboBox();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.DropLabel = new System.Windows.Forms.Label();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            toolStrip1.SuspendLayout();
            toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel1,
            this.QualityBox});
            toolStrip1.Location = new System.Drawing.Point(3, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(158, 25);
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
            this.QualityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QualityBox.Items.AddRange(new object[] {
            "0",
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
            this.QualityBox.SelectedIndexChanged += new System.EventHandler(this.QualityBox_SelectedIndexChanged);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            toolStripContainer1.BottomToolStripPanel.Controls.Add(toolStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(this.DropLabel);
            toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(284, 65);
            toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new System.Drawing.Size(284, 115);
            toolStripContainer1.TabIndex = 0;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            // 
            // toolStrip2
            // 
            toolStrip2.AutoSize = false;
            toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar});
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new System.Drawing.Size(284, 25);
            toolStrip2.Stretch = true;
            toolStrip2.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.ProgressBar.AutoSize = false;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(280, 22);
            this.ProgressBar.Step = 1;
            // 
            // DropLabel
            // 
            this.DropLabel.AllowDrop = true;
            this.DropLabel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.DropLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DropLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DropLabel.Location = new System.Drawing.Point(0, 0);
            this.DropLabel.Name = "DropLabel";
            this.DropLabel.Size = new System.Drawing.Size(284, 65);
            this.DropLabel.TabIndex = 0;
            this.DropLabel.Text = "Drop JPEG files here to reduce their quality.\r\nA copy will be placed in the same " +
    "directory.";
            this.DropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DropLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropLabel_DragDrop);
            this.DropLabel.DragOver += new System.Windows.Forms.DragEventHandler(this.DropLabel_DragOver);
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProcessImagesAsync);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            // 
            // JpegQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 115);
            this.Controls.Add(toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JpegQuality";
            this.Text = "JPEG Quality";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DropLabel;
        private System.Windows.Forms.ToolStripComboBox QualityBox;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}


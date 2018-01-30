namespace IQadhmaniAssignment3
{
    partial class NPuzzleGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NPuzzleGame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.lblRow = new System.Windows.Forms.Label();
            this.lblColumn = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pnlGamePanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Info;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(864, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsSave,
            this.cmsLoad,
            this.cmsExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // cmsSave
            // 
            this.cmsSave.Name = "cmsSave";
            this.cmsSave.Size = new System.Drawing.Size(135, 30);
            this.cmsSave.Text = "Save";
            this.cmsSave.Click += new System.EventHandler(this.cmsSave_Click);
            // 
            // cmsLoad
            // 
            this.cmsLoad.Name = "cmsLoad";
            this.cmsLoad.Size = new System.Drawing.Size(135, 30);
            this.cmsLoad.Text = "Load";
            this.cmsLoad.Click += new System.EventHandler(this.cmsLoad_Click);
            // 
            // cmsExit
            // 
            this.cmsExit.Name = "cmsExit";
            this.cmsExit.Size = new System.Drawing.Size(135, 30);
            this.cmsExit.Text = "Exit";
            this.cmsExit.Click += new System.EventHandler(this.cmsExit_Click);
            // 
            // txtRow
            // 
            this.txtRow.Location = new System.Drawing.Point(225, 62);
            this.txtRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(148, 26);
            this.txtRow.TabIndex = 1;
            // 
            // txtColumn
            // 
            this.txtColumn.Location = new System.Drawing.Point(225, 92);
            this.txtColumn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.Size = new System.Drawing.Size(148, 26);
            this.txtColumn.TabIndex = 1;
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(18, 66);
            this.lblRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(53, 20);
            this.lblRow.TabIndex = 2;
            this.lblRow.Text = "Rows:";
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(18, 106);
            this.lblColumn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(75, 20);
            this.lblColumn.TabIndex = 2;
            this.lblColumn.Text = "Columns:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(399, 69);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(112, 46);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pnlGamePanel
            // 
            this.pnlGamePanel.Location = new System.Drawing.Point(4, 134);
            this.pnlGamePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlGamePanel.Name = "pnlGamePanel";
            this.pnlGamePanel.Size = new System.Drawing.Size(860, 538);
            this.pnlGamePanel.TabIndex = 5;
            // 
            // NPuzzleGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 666);
            this.Controls.Add(this.pnlGamePanel);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblColumn);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.txtColumn);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NPuzzleGame";
            this.Text = "N Puzzle Game by Ibrahim Qadhmani";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsSave;
        private System.Windows.Forms.ToolStripMenuItem cmsLoad;
        private System.Windows.Forms.ToolStripMenuItem cmsExit;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.TextBox txtColumn;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel pnlGamePanel;
    }
}


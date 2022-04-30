namespace Cobra_Scanner
{
    partial class frmScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScanner));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefreshSubnets = new System.Windows.Forms.Button();
            this.btnSubnets = new System.Windows.Forms.Button();
            this.lstSubnets = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveCSV = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnFullReport = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.lblProg = new System.Windows.Forms.Label();
            this.pgbScanner = new System.Windows.Forms.ProgressBar();
            this.dgvHosts = new System.Windows.Forms.DataGridView();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRefreshSubnets);
            this.groupBox1.Controls.Add(this.btnSubnets);
            this.groupBox1.Controls.Add(this.lstSubnets);
            this.groupBox1.Location = new System.Drawing.Point(18, 292);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(362, 382);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subnets";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(199, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 125);
            this.label2.TabIndex = 4;
            this.label2.Text = "Add \"subnets.txt\" to the folder. Also, subnets should be separated by lines in fo" +
    "rmat \"x.x.x.\".";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 87);
            this.label1.TabIndex = 3;
            this.label1.Text = "Directory for all files is \"C:\\CS\\*\"";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnRefreshSubnets
            // 
            this.btnRefreshSubnets.Location = new System.Drawing.Point(198, 309);
            this.btnRefreshSubnets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefreshSubnets.Name = "btnRefreshSubnets";
            this.btnRefreshSubnets.Size = new System.Drawing.Size(154, 55);
            this.btnRefreshSubnets.TabIndex = 2;
            this.btnRefreshSubnets.Text = "Refresh Subnets";
            this.btnRefreshSubnets.UseVisualStyleBackColor = true;
            this.btnRefreshSubnets.Click += new System.EventHandler(this.btnRefreshSubnets_Click);
            // 
            // btnSubnets
            // 
            this.btnSubnets.Location = new System.Drawing.Point(198, 245);
            this.btnSubnets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubnets.Name = "btnSubnets";
            this.btnSubnets.Size = new System.Drawing.Size(154, 55);
            this.btnSubnets.TabIndex = 1;
            this.btnSubnets.Text = "Edit Subnets";
            this.btnSubnets.UseVisualStyleBackColor = true;
            this.btnSubnets.Click += new System.EventHandler(this.btnSubnets_Click);
            // 
            // lstSubnets
            // 
            this.lstSubnets.FormattingEnabled = true;
            this.lstSubnets.ItemHeight = 20;
            this.lstSubnets.Location = new System.Drawing.Point(9, 29);
            this.lstSubnets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstSubnets.Name = "lstSubnets";
            this.lstSubnets.Size = new System.Drawing.Size(178, 344);
            this.lstSubnets.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnSaveCSV);
            this.groupBox2.Controls.Add(this.btnLog);
            this.groupBox2.Controls.Add(this.btnFullReport);
            this.groupBox2.Controls.Add(this.btnScan);
            this.groupBox2.Controls.Add(this.lblProg);
            this.groupBox2.Controls.Add(this.pgbScanner);
            this.groupBox2.Controls.Add(this.dgvHosts);
            this.groupBox2.Location = new System.Drawing.Point(388, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1382, 655);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Network Data";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1216, 592);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 55);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveCSV
            // 
            this.btnSaveCSV.Location = new System.Drawing.Point(1216, 159);
            this.btnSaveCSV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveCSV.Name = "btnSaveCSV";
            this.btnSaveCSV.Size = new System.Drawing.Size(154, 55);
            this.btnSaveCSV.TabIndex = 7;
            this.btnSaveCSV.Text = "Save CSV";
            this.btnSaveCSV.UseVisualStyleBackColor = true;
            this.btnSaveCSV.Click += new System.EventHandler(this.btnSaveCSV_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(1216, 527);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(154, 55);
            this.btnLog.TabIndex = 6;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnFullReport
            // 
            this.btnFullReport.Location = new System.Drawing.Point(1216, 94);
            this.btnFullReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFullReport.Name = "btnFullReport";
            this.btnFullReport.Size = new System.Drawing.Size(154, 55);
            this.btnFullReport.TabIndex = 4;
            this.btnFullReport.Text = "Full Report";
            this.btnFullReport.UseVisualStyleBackColor = true;
            this.btnFullReport.Click += new System.EventHandler(this.btnFullReport_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(1216, 29);
            this.btnScan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(154, 55);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lblProg
            // 
            this.lblProg.AutoSize = true;
            this.lblProg.Location = new System.Drawing.Point(10, 585);
            this.lblProg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProg.Name = "lblProg";
            this.lblProg.Size = new System.Drawing.Size(141, 20);
            this.lblProg.TabIndex = 2;
            this.lblProg.Text = "(click to start scan)";
            // 
            // pgbScanner
            // 
            this.pgbScanner.Location = new System.Drawing.Point(9, 611);
            this.pgbScanner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pgbScanner.Name = "pgbScanner";
            this.pgbScanner.Size = new System.Drawing.Size(1198, 35);
            this.pgbScanner.TabIndex = 1;
            // 
            // dgvHosts
            // 
            this.dgvHosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.Hostname,
            this.MAC});
            this.dgvHosts.Location = new System.Drawing.Point(9, 29);
            this.dgvHosts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvHosts.Name = "dgvHosts";
            this.dgvHosts.RowHeadersVisible = false;
            this.dgvHosts.RowHeadersWidth = 62;
            this.dgvHosts.Size = new System.Drawing.Size(1198, 545);
            this.dgvHosts.TabIndex = 0;
            this.dgvHosts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHosts_CellContentClick);
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IP.HeaderText = "Active IP Client List";
            this.IP.MinimumWidth = 8;
            this.IP.Name = "IP";
            // 
            // Hostname
            // 
            this.Hostname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Hostname.HeaderText = "Hostname";
            this.Hostname.MinimumWidth = 8;
            this.Hostname.Name = "Hostname";
            // 
            // MAC
            // 
            this.MAC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MAC.HeaderText = "MAC";
            this.MAC.MinimumWidth = 8;
            this.MAC.Name = "MAC";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 266);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1779, 692);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmScanner";
            this.Text = "Cobra Scanner | Scanner";
            this.Load += new System.EventHandler(this.frmScanner_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefreshSubnets;
        private System.Windows.Forms.Button btnSubnets;
        private System.Windows.Forms.ListBox lstSubnets;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvHosts;
        private System.Windows.Forms.ProgressBar pgbScanner;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnFullReport;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label lblProg;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSaveCSV;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


namespace Cobra_Scanner
{
    partial class frmFullReport
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
            this.webFullReport = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webFullReport
            // 
            this.webFullReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webFullReport.Location = new System.Drawing.Point(0, 0);
            this.webFullReport.MinimumSize = new System.Drawing.Size(20, 20);
            this.webFullReport.Name = "webFullReport";
            this.webFullReport.Size = new System.Drawing.Size(800, 1011);
            this.webFullReport.TabIndex = 0;
            // 
            // frmFullReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1011);
            this.Controls.Add(this.webFullReport);
            this.Name = "frmFullReport";
            this.Text = "Cobra Scanner | Full Report";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webFullReport;
    }
}
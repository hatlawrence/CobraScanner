namespace Cobra_Scanner
{
    partial class frmAddSubnet
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
            this.txtAddSubnet = new System.Windows.Forms.TextBox();
            this.btnAddSubnet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAddSubnet
            // 
            this.txtAddSubnet.Location = new System.Drawing.Point(18, 18);
            this.txtAddSubnet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddSubnet.Name = "txtAddSubnet";
            this.txtAddSubnet.Size = new System.Drawing.Size(680, 26);
            this.txtAddSubnet.TabIndex = 0;
            // 
            // btnAddSubnet
            // 
            this.btnAddSubnet.Location = new System.Drawing.Point(18, 58);
            this.btnAddSubnet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddSubnet.Name = "btnAddSubnet";
            this.btnAddSubnet.Size = new System.Drawing.Size(154, 55);
            this.btnAddSubnet.TabIndex = 2;
            this.btnAddSubnet.Text = "Add";
            this.btnAddSubnet.UseVisualStyleBackColor = true;
            this.btnAddSubnet.Click += new System.EventHandler(this.btnAddSubnet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(546, 57);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(154, 55);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddSubnet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 131);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddSubnet);
            this.Controls.Add(this.txtAddSubnet);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddSubnet";
            this.Text = "Cobra Scanner | Add Subnet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddSubnet;
        private System.Windows.Forms.Button btnAddSubnet;
        private System.Windows.Forms.Button btnCancel;
    }
}
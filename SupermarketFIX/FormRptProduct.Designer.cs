
namespace SupermarketFIX
{
    partial class FormRptProduct
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
            this.crvProduct = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtmExpired = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // crvProduct
            // 
            this.crvProduct.ActiveViewIndex = -1;
            this.crvProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvProduct.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crvProduct.Location = new System.Drawing.Point(0, 43);
            this.crvProduct.Name = "crvProduct";
            this.crvProduct.Size = new System.Drawing.Size(1248, 578);
            this.crvProduct.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Expiry Date";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(290, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtmExpired
            // 
            this.dtmExpired.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmExpired.Location = new System.Drawing.Point(79, 7);
            this.dtmExpired.Name = "dtmExpired";
            this.dtmExpired.Size = new System.Drawing.Size(200, 20);
            this.dtmExpired.TabIndex = 7;
            // 
            // FormRptProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 621);
            this.Controls.Add(this.dtmExpired);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.crvProduct);
            this.Name = "FormRptProduct";
            this.Text = "FormRptProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DateTimePicker dtmExpired;
    }
}
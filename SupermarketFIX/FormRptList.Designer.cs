
namespace SupermarketFIX
{
    partial class FormRptList
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
            this.crvList = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnShow = new System.Windows.Forms.Button();
            this.txtTransNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crvList
            // 
            this.crvList.ActiveViewIndex = -1;
            this.crvList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvList.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crvList.Location = new System.Drawing.Point(0, 68);
            this.crvList.Name = "crvList";
            this.crvList.Size = new System.Drawing.Size(1030, 533);
            this.crvList.TabIndex = 0;
            this.crvList.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvList.Load += new System.EventHandler(this.crvList_Load);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(255, 27);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // txtTransNo
            // 
            this.txtTransNo.Location = new System.Drawing.Point(99, 29);
            this.txtTransNo.Name = "txtTransNo";
            this.txtTransNo.Size = new System.Drawing.Size(150, 20);
            this.txtTransNo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Transaction No";
            // 
            // FormRptList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 601);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTransNo);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.crvList);
            this.Name = "FormRptList";
            this.Text = "Report List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvList;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TextBox txtTransNo;
        private System.Windows.Forms.Label label1;
    }
}
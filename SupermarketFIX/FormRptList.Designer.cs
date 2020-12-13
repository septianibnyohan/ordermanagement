
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
            this.SuspendLayout();
            // 
            // crvList
            // 
            this.crvList.ActiveViewIndex = -1;
            this.crvList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvList.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvList.Location = new System.Drawing.Point(0, 0);
            this.crvList.Name = "crvList";
            this.crvList.Size = new System.Drawing.Size(1030, 601);
            this.crvList.TabIndex = 0;
            this.crvList.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvList.Load += new System.EventHandler(this.crvList_Load);
            // 
            // FormRptList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 601);
            this.Controls.Add(this.crvList);
            this.Name = "FormRptList";
            this.Text = "Report List";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvList;
    }
}
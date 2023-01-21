namespace CyberPal.App
{
    partial class ucAuditing
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAuditing));
            this.lvAudits = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.ctxMnuOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.successToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.failureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.successFailureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noAuditingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAudits
            // 
            this.lvAudits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvAudits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAudits.FullRowSelect = true;
            this.lvAudits.GridLines = true;
            this.lvAudits.Location = new System.Drawing.Point(0, 0);
            this.lvAudits.Name = "lvAudits";
            this.lvAudits.Size = new System.Drawing.Size(766, 454);
            this.lvAudits.SmallImageList = this.imageList1;
            this.lvAudits.TabIndex = 0;
            this.lvAudits.UseCompatibleStateImageBehavior = false;
            this.lvAudits.View = System.Windows.Forms.View.Details;
            this.lvAudits.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvAudits_MouseDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Audit Type";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Audit";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "redx-24.png");
            this.imageList1.Images.SetKeyName(1, "checkbox-48.png");
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 10000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // ctxMnuOptions
            // 
            this.ctxMnuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.successToolStripMenuItem,
            this.failureToolStripMenuItem,
            this.successFailureToolStripMenuItem,
            this.noAuditingToolStripMenuItem});
            this.ctxMnuOptions.Name = "ctxMnuOptions";
            this.ctxMnuOptions.Size = new System.Drawing.Size(167, 92);
            // 
            // successToolStripMenuItem
            // 
            this.successToolStripMenuItem.Name = "successToolStripMenuItem";
            this.successToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.successToolStripMenuItem.Text = "Success";
            this.successToolStripMenuItem.Click += new System.EventHandler(this.successToolStripMenuItem_Click);
            // 
            // failureToolStripMenuItem
            // 
            this.failureToolStripMenuItem.Name = "failureToolStripMenuItem";
            this.failureToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.failureToolStripMenuItem.Text = "Failure";
            this.failureToolStripMenuItem.Click += new System.EventHandler(this.failureToolStripMenuItem_Click);
            // 
            // successFailureToolStripMenuItem
            // 
            this.successFailureToolStripMenuItem.Name = "successFailureToolStripMenuItem";
            this.successFailureToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.successFailureToolStripMenuItem.Text = "Success && Failure";
            this.successFailureToolStripMenuItem.Click += new System.EventHandler(this.successFailureToolStripMenuItem_Click);
            // 
            // noAuditingToolStripMenuItem
            // 
            this.noAuditingToolStripMenuItem.Name = "noAuditingToolStripMenuItem";
            this.noAuditingToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.noAuditingToolStripMenuItem.Text = "No Auditing";
            this.noAuditingToolStripMenuItem.Click += new System.EventHandler(this.noAuditingToolStripMenuItem_Click);
            // 
            // ucAuditing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvAudits);
            this.Name = "ucAuditing";
            this.Size = new System.Drawing.Size(766, 454);
            this.ctxMnuOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvAudits;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private System.Windows.Forms.Timer tmrRefresh;
        private ImageList imageList1;
        private ContextMenuStrip ctxMnuOptions;
        private ToolStripMenuItem successToolStripMenuItem;
        private ToolStripMenuItem failureToolStripMenuItem;
        private ToolStripMenuItem successFailureToolStripMenuItem;
        private ToolStripMenuItem noAuditingToolStripMenuItem;
    }
}

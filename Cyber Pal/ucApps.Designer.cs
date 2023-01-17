namespace CyberPal.App
{
    partial class ucApps
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoAppAuditDisable = new System.Windows.Forms.RadioButton();
            this.rdoAppAuditEnable = new System.Windows.Forms.RadioButton();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.426229F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.57377F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 488);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdoAppAuditDisable);
            this.panel1.Controls.Add(this.rdoAppAuditEnable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 39);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "App Audit";
            // 
            // rdoAppAuditDisable
            // 
            this.rdoAppAuditDisable.AutoSize = true;
            this.rdoAppAuditDisable.Location = new System.Drawing.Point(148, 11);
            this.rdoAppAuditDisable.Name = "rdoAppAuditDisable";
            this.rdoAppAuditDisable.Size = new System.Drawing.Size(63, 19);
            this.rdoAppAuditDisable.TabIndex = 1;
            this.rdoAppAuditDisable.TabStop = true;
            this.rdoAppAuditDisable.Text = "Disable";
            this.rdoAppAuditDisable.UseVisualStyleBackColor = true;
            this.rdoAppAuditDisable.CheckedChanged += new System.EventHandler(this.rdoAppAuditDisable_CheckedChanged);
            // 
            // rdoAppAuditEnable
            // 
            this.rdoAppAuditEnable.AutoSize = true;
            this.rdoAppAuditEnable.Location = new System.Drawing.Point(82, 11);
            this.rdoAppAuditEnable.Name = "rdoAppAuditEnable";
            this.rdoAppAuditEnable.Size = new System.Drawing.Size(60, 19);
            this.rdoAppAuditEnable.TabIndex = 0;
            this.rdoAppAuditEnable.TabStop = true;
            this.rdoAppAuditEnable.Text = "Enable";
            this.rdoAppAuditEnable.UseVisualStyleBackColor = true;
            this.rdoAppAuditEnable.CheckedChanged += new System.EventHandler(this.rdoAppAuditEnable_CheckedChanged);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 500;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // ucApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucApps";
            this.Size = new System.Drawing.Size(800, 488);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private RadioButton rdoAppAuditDisable;
        private RadioButton rdoAppAuditEnable;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}

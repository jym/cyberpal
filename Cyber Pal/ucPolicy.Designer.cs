namespace CyberPal.App
{
    partial class ucPolicy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPolicy));
            this.lvPolicies = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lvPolicies
            // 
            this.lvPolicies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvPolicies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPolicies.FullRowSelect = true;
            this.lvPolicies.GridLines = true;
            this.lvPolicies.Location = new System.Drawing.Point(0, 0);
            this.lvPolicies.MultiSelect = false;
            this.lvPolicies.Name = "lvPolicies";
            this.lvPolicies.Size = new System.Drawing.Size(729, 410);
            this.lvPolicies.SmallImageList = this.imageList1;
            this.lvPolicies.TabIndex = 1;
            this.lvPolicies.UseCompatibleStateImageBehavior = false;
            this.lvPolicies.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Policy";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Value";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Notes";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "redx-24.png");
            this.imageList1.Images.SetKeyName(1, "checkbox-24.png");
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 60000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // ucPolicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvPolicies);
            this.Name = "ucPolicy";
            this.Size = new System.Drawing.Size(729, 410);
            this.ResumeLayout(false);

        }

        #endregion
        private ListView lvPolicies;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ImageList imageList1;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}

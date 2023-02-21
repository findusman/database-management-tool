namespace DATA_MS
{
    partial class Export_data
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Export_data));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmb_expot_to = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.textpath = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.textfilename = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_expot_to.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textpath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textfilename.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.cmb_expot_to);
            this.groupControl1.Controls.Add(this.simpleButton4);
            this.groupControl1.Controls.Add(this.textpath);
            this.groupControl1.Controls.Add(this.simpleButton3);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.textfilename);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(504, 166);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Information";
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(-1, 105);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(506, 10);
            this.panelControl1.TabIndex = 7;
            // 
            // cmb_expot_to
            // 
            this.cmb_expot_to.EditValue = "Excel ( Xlsx ) ";
            this.cmb_expot_to.Location = new System.Drawing.Point(99, 43);
            this.cmb_expot_to.Name = "cmb_expot_to";
            this.cmb_expot_to.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_expot_to.Properties.Appearance.Options.UseFont = true;
            this.cmb_expot_to.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmb_expot_to.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.cmb_expot_to.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cmb_expot_to.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_expot_to.Properties.Items.AddRange(new object[] {
            "Excel ( Xlsx ) ",
            "Excel ( Xls )",
            "Text",
            "Html",
            "Adobe Acrobate ( pdf )",
            "Rtf",
            "Excel ( Csv )"});
            this.cmb_expot_to.Size = new System.Drawing.Size(174, 22);
            this.cmb_expot_to.TabIndex = 1;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(228, 127);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(83, 22);
            this.simpleButton4.TabIndex = 4;
            this.simpleButton4.Text = "Export";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // textpath
            // 
            this.textpath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textpath.Enabled = false;
            this.textpath.Location = new System.Drawing.Point(99, 71);
            this.textpath.Name = "textpath";
            this.textpath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textpath.Properties.Appearance.Options.UseFont = true;
            this.textpath.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.textpath.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textpath.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textpath.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textpath.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textpath.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.textpath.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.textpath.Size = new System.Drawing.Size(301, 22);
            this.textpath.TabIndex = 2;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(317, 127);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(83, 22);
            this.simpleButton3.TabIndex = 5;
            this.simpleButton3.Text = "Clear";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(406, 71);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(83, 22);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Tag = "1";
            this.simpleButton1.Text = "Path";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(406, 127);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(83, 22);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "Exit";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // textfilename
            // 
            this.textfilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textfilename.Location = new System.Drawing.Point(99, 15);
            this.textfilename.Name = "textfilename";
            this.textfilename.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textfilename.Properties.Appearance.Options.UseFont = true;
            this.textfilename.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textfilename.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textfilename.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textfilename.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.textfilename.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.textfilename.Size = new System.Drawing.Size(174, 22);
            this.textfilename.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(32, 47);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 14);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Export To :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(61, 74);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Path :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(33, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "File Name :";
            // 
            // Export_data
            // 
            this.AcceptButton = this.simpleButton4;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 166);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Export_data";
            this.Text = "Export Data";
            this.Load += new System.EventHandler(this.Export_data_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Export_data_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Export_data_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_expot_to.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textpath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textfilename.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
   //     private PAK_ASIATableAdapters.sp_SUPPLIERS_OUTSTANDING_BILS_selectionTableAdapter sp_SUPPLIERS_OUTSTANDING_BILS_selectionTableAdapter;
   //     private PAK_ASIATableAdapters.TBL_PARTNERTableAdapter tBL_PARTNERTableAdapter;
    //    private PAK_ASIADataSetTableAdapters.sp_VCOA_SELECTIONTableAdapter sp_VCOA_SELECTIONTableAdapter;
    //    private PAK_ASIADataSetTableAdapters.sp_STOCKS_reportTableAdapter sp_STOCKS_reportTableAdapter;
      //  private PAK_ASIATableAdapters.V_SUMMARY_INVOICETableAdapter v_SUMMARY_INVOICETableAdapter;
     ///   private PAK_ASIATableAdapters.sp_ITEM_TRANSACTION_reportTableAdapter sp_ITEM_TRANSACTION_reportTableAdapter;
     //   private PAK_ASIATableAdapters.V_DEFINATION_ITEMTableAdapter v_DEFINATION_ITEMTableAdapter;
    //    private PAK_ASIATableAdapters.V_MAIN_CUSTOMERTableAdapter v_MAIN_CUSTOMERTableAdapter;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_expot_to;
        private DevExpress.XtraEditors.TextEdit textpath;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit textfilename;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
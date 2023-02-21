namespace DATA_MS.Other_Actions
{
    partial class frm_Reset_identity
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.LOOK_UP_DATABSES_1 = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ch_all_tables_1 = new DevExpress.XtraEditors.CheckEdit();
            this.G_TABLES_1 = new DevExpress.XtraGrid.GridControl();
            this.GV_TABLES_1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOOK_UP_DATABSES_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_all_tables_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_TABLES_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_TABLES_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.spinEdit1);
            this.groupControl1.Controls.Add(this.LOOK_UP_DATABSES_1);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.ch_all_tables_1);
            this.groupControl1.Controls.Add(this.G_TABLES_1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(394, 346);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Tables Having Identity Columns";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(86, 523);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Reseed :";
            // 
            // spinEdit1
            // 
            this.spinEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(135, 320);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.spinEdit1.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.spinEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Properties.Mask.EditMask = "n0";
            this.spinEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spinEdit1.Size = new System.Drawing.Size(78, 22);
            this.spinEdit1.TabIndex = 8;
            // 
            // LOOK_UP_DATABSES_1
            // 
            this.LOOK_UP_DATABSES_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LOOK_UP_DATABSES_1.Location = new System.Drawing.Point(0, 21);
            this.LOOK_UP_DATABSES_1.Name = "LOOK_UP_DATABSES_1";
            this.LOOK_UP_DATABSES_1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.LOOK_UP_DATABSES_1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LOOK_UP_DATABSES_1.Size = new System.Drawing.Size(394, 22);
            this.LOOK_UP_DATABSES_1.TabIndex = 7;
            this.LOOK_UP_DATABSES_1.EditValueChanged += new System.EventHandler(this.LOOK_UP_DATABSES_1_EditValueChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton1.Location = new System.Drawing.Point(5, 319);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Reset";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ch_all_tables_1
            // 
            this.ch_all_tables_1.EditValue = true;
            this.ch_all_tables_1.Location = new System.Drawing.Point(22, 44);
            this.ch_all_tables_1.Name = "ch_all_tables_1";
            this.ch_all_tables_1.Properties.Caption = "checkEdit1";
            this.ch_all_tables_1.Size = new System.Drawing.Size(20, 19);
            this.ch_all_tables_1.TabIndex = 2;
            this.ch_all_tables_1.CheckedChanged += new System.EventHandler(this.ch_all_tables_1_CheckedChanged);
            // 
            // G_TABLES_1
            // 
            this.G_TABLES_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.G_TABLES_1.Location = new System.Drawing.Point(5, 44);
            this.G_TABLES_1.MainView = this.GV_TABLES_1;
            this.G_TABLES_1.Name = "G_TABLES_1";
            this.G_TABLES_1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.G_TABLES_1.Size = new System.Drawing.Size(389, 269);
            this.G_TABLES_1.TabIndex = 1;
            this.G_TABLES_1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GV_TABLES_1});
            // 
            // GV_TABLES_1
            // 
            this.GV_TABLES_1.GridControl = this.G_TABLES_1;
            this.GV_TABLES_1.Name = "GV_TABLES_1";
            this.GV_TABLES_1.OptionsSelection.InvertSelection = true;
            this.GV_TABLES_1.OptionsSelection.MultiSelect = true;
            this.GV_TABLES_1.OptionsView.ShowAutoFilterRow = true;
            this.GV_TABLES_1.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // frm_Reset_identity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 346);
            this.Controls.Add(this.groupControl1);
            this.MinimumSize = new System.Drawing.Size(400, 375);
            this.Name = "frm_Reset_identity";
            this.Text = "Reset Identity ";
            this.Load += new System.EventHandler(this.frm_Reset_identity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOOK_UP_DATABSES_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_all_tables_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_TABLES_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_TABLES_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit ch_all_tables_1;
        private DevExpress.XtraGrid.GridControl G_TABLES_1;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_TABLES_1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LookUpEdit LOOK_UP_DATABSES_1;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
namespace DATA_MS.Main_Screen
{
    partial class frm_checkWhereClause
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
            this.components = new System.ComponentModel.Container();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.G_TABLES_1 = new DevExpress.XtraGrid.GridControl();
            this.GV_TABLES_1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.dM_LUBRICANTSDataSet = new DATA_MS.DM_LUBRICANTSDataSet();
            this.dtcheckWhereClauseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalWhere = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalBRC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalJoin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.G_TABLES_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_TABLES_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dM_LUBRICANTSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcheckWhereClauseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(505, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(82, 30);
            this.simpleButton1.TabIndex = 35;
            this.simpleButton1.Text = "Start";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // G_TABLES_1
            // 
            this.G_TABLES_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.G_TABLES_1.DataSource = this.dtcheckWhereClauseBindingSource;
            this.G_TABLES_1.Location = new System.Drawing.Point(3, 48);
            this.G_TABLES_1.MainView = this.GV_TABLES_1;
            this.G_TABLES_1.Name = "G_TABLES_1";
            this.G_TABLES_1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.G_TABLES_1.Size = new System.Drawing.Size(597, 345);
            this.G_TABLES_1.TabIndex = 36;
            this.G_TABLES_1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GV_TABLES_1});
            // 
            // GV_TABLES_1
            // 
            this.GV_TABLES_1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colTotalWhere,
            this.colTotalBRC,
            this.colTotalDelete,
            this.colTotalJoin,
            this.colStatus});
            this.GV_TABLES_1.GridControl = this.G_TABLES_1;
            this.GV_TABLES_1.Name = "GV_TABLES_1";
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // dM_LUBRICANTSDataSet
            // 
            this.dM_LUBRICANTSDataSet.DataSetName = "DM_LUBRICANTSDataSet";
            this.dM_LUBRICANTSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtcheckWhereClauseBindingSource
            // 
            this.dtcheckWhereClauseBindingSource.DataMember = "dt_checkWhereClause";
            this.dtcheckWhereClauseBindingSource.DataSource = this.dM_LUBRICANTSDataSet;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 96;
            // 
            // colTotalWhere
            // 
            this.colTotalWhere.FieldName = "Total Where";
            this.colTotalWhere.Name = "colTotalWhere";
            this.colTotalWhere.OptionsColumn.FixedWidth = true;
            this.colTotalWhere.Visible = true;
            this.colTotalWhere.VisibleIndex = 1;
            this.colTotalWhere.Width = 100;
            // 
            // colTotalBRC
            // 
            this.colTotalBRC.FieldName = "Total BRC";
            this.colTotalBRC.Name = "colTotalBRC";
            this.colTotalBRC.OptionsColumn.FixedWidth = true;
            this.colTotalBRC.Visible = true;
            this.colTotalBRC.VisibleIndex = 2;
            this.colTotalBRC.Width = 100;
            // 
            // colTotalDelete
            // 
            this.colTotalDelete.FieldName = "Total Delete";
            this.colTotalDelete.Name = "colTotalDelete";
            this.colTotalDelete.OptionsColumn.FixedWidth = true;
            this.colTotalDelete.Visible = true;
            this.colTotalDelete.VisibleIndex = 3;
            this.colTotalDelete.Width = 100;
            // 
            // colTotalJoin
            // 
            this.colTotalJoin.FieldName = "Total Join";
            this.colTotalJoin.Name = "colTotalJoin";
            this.colTotalJoin.OptionsColumn.FixedWidth = true;
            this.colTotalJoin.Visible = true;
            this.colTotalJoin.VisibleIndex = 4;
            this.colTotalJoin.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.FixedWidth = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            this.colStatus.Width = 100;
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit1.EditValue = "C:\\Users\\Raza\\Desktop\\scripts\\Scripts\\Procedures";
            this.textEdit1.Location = new System.Drawing.Point(3, 10);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.textEdit1.Properties.AppearanceDisabled.BorderColor = System.Drawing.Color.Black;
            this.textEdit1.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.textEdit1.Properties.AppearanceDisabled.Options.UseBorderColor = true;
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.textEdit1.Size = new System.Drawing.Size(496, 32);
            this.textEdit1.TabIndex = 37;
            // 
            // frm_checkWhereClause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 393);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.G_TABLES_1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frm_checkWhereClause";
            this.Text = "frm_checkWhereClause";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.G_TABLES_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_TABLES_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dM_LUBRICANTSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtcheckWhereClauseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl G_TABLES_1;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_TABLES_1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private System.Windows.Forms.BindingSource dtcheckWhereClauseBindingSource;
        private DM_LUBRICANTSDataSet dM_LUBRICANTSDataSet;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalWhere;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalBRC;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalJoin;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.TextEdit textEdit1;

    }
}
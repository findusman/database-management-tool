namespace DATA_MS
{
    partial class Copy_Rows
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
            this.G_TABLES = new DevExpress.XtraGrid.GridControl();
            this.tablesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dMLUBRICANTSDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dM_LUBRICANTSDataSet = new DATA_MS.DM_LUBRICANTSDataSet();
            this.GV_TABLES = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNames1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tablesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.tablesTableAdapter = new DATA_MS.DM_LUBRICANTSDataSetTableAdapters.tablesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.G_TABLES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMLUBRICANTSDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dM_LUBRICANTSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_TABLES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // G_TABLES
            // 
            this.G_TABLES.AllowDrop = true;
            this.G_TABLES.DataSource = this.tablesBindingSource1;
            this.G_TABLES.Location = new System.Drawing.Point(8, 8);
            this.G_TABLES.MainView = this.GV_TABLES;
            this.G_TABLES.Name = "G_TABLES";
            this.G_TABLES.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.G_TABLES.Size = new System.Drawing.Size(316, 474);
            this.G_TABLES.TabIndex = 1;
            this.G_TABLES.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GV_TABLES});
            this.G_TABLES.DragOver += new System.Windows.Forms.DragEventHandler(this.G_TABLES_DragOver);
            this.G_TABLES.MouseDown += new System.Windows.Forms.MouseEventHandler(this.G_TABLES_MouseDown);
            // 
            // tablesBindingSource1
            // 
            this.tablesBindingSource1.DataMember = "tables";
            this.tablesBindingSource1.DataSource = this.dMLUBRICANTSDataSetBindingSource;
            // 
            // dMLUBRICANTSDataSetBindingSource
            // 
            this.dMLUBRICANTSDataSetBindingSource.DataSource = this.dM_LUBRICANTSDataSet;
            this.dMLUBRICANTSDataSetBindingSource.Position = 0;
            // 
            // dM_LUBRICANTSDataSet
            // 
            this.dM_LUBRICANTSDataSet.DataSetName = "DM_LUBRICANTSDataSet";
            this.dM_LUBRICANTSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GV_TABLES
            // 
            this.GV_TABLES.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colS1,
            this.colNames1,
            this.colDescription1});
            this.GV_TABLES.GridControl = this.G_TABLES;
            this.GV_TABLES.Name = "GV_TABLES";
            this.GV_TABLES.OptionsBehavior.Editable = false;
            this.GV_TABLES.OptionsSelection.InvertSelection = true;
            this.GV_TABLES.OptionsView.ShowAutoFilterRow = true;
            this.GV_TABLES.OptionsView.ShowGroupPanel = false;
            this.GV_TABLES.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GV_TABLES_MouseDown);
            this.GV_TABLES.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GV_TABLES_MouseMove);
            // 
            // colS1
            // 
            this.colS1.FieldName = "S";
            this.colS1.Name = "colS1";
            this.colS1.OptionsColumn.ReadOnly = true;
            this.colS1.Visible = true;
            this.colS1.VisibleIndex = 0;
            // 
            // colNames1
            // 
            this.colNames1.FieldName = "Names";
            this.colNames1.Name = "colNames1";
            this.colNames1.Visible = true;
            this.colNames1.VisibleIndex = 1;
            // 
            // colDescription1
            // 
            this.colDescription1.FieldName = "Description";
            this.colDescription1.Name = "colDescription1";
            this.colDescription1.OptionsColumn.ReadOnly = true;
            this.colDescription1.Visible = true;
            this.colDescription1.VisibleIndex = 2;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // gridControl1
            // 
            this.gridControl1.AllowDrop = true;
            this.gridControl1.DataSource = this.tablesBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(330, 8);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit2});
            this.gridControl1.Size = new System.Drawing.Size(316, 474);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridControl1_DragDrop);
            // 
            // tablesBindingSource
            // 
            this.tablesBindingSource.DataMember = "tables";
            this.tablesBindingSource.DataSource = this.dMLUBRICANTSDataSetBindingSource;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colS,
            this.colNames,
            this.colDescription});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.InvertSelection = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colS
            // 
            this.colS.FieldName = "S";
            this.colS.Name = "colS";
            this.colS.OptionsColumn.ReadOnly = true;
            this.colS.Visible = true;
            this.colS.VisibleIndex = 0;
            // 
            // colNames
            // 
            this.colNames.FieldName = "Names";
            this.colNames.Name = "colNames";
            this.colNames.Visible = true;
            this.colNames.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            // 
            // tablesTableAdapter
            // 
            this.tablesTableAdapter.ClearBeforeFill = true;
            // 
            // Copy_Rows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 483);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.G_TABLES);
            this.Name = "Copy_Rows";
            this.Text = "Copy_Rows";
            this.Load += new System.EventHandler(this.Copy_Rows_Load);
            ((System.ComponentModel.ISupportInitialize)(this.G_TABLES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMLUBRICANTSDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dM_LUBRICANTSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GV_TABLES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl G_TABLES;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_TABLES;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private System.Windows.Forms.BindingSource dMLUBRICANTSDataSetBindingSource;
        private DM_LUBRICANTSDataSet dM_LUBRICANTSDataSet;
        private System.Windows.Forms.BindingSource tablesBindingSource;
        private DM_LUBRICANTSDataSetTableAdapters.tablesTableAdapter tablesTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colS;
        private DevExpress.XtraGrid.Columns.GridColumn colNames;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private System.Windows.Forms.BindingSource tablesBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colS1;
        private DevExpress.XtraGrid.Columns.GridColumn colNames1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription1;
    }
}
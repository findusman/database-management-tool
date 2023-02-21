namespace DATA_MS
{
    partial class frm_parameters_to
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
                  this.G_PARAMETERS = new DevExpress.XtraGrid.GridControl();
                  this.GV_PARAMETERS = new DevExpress.XtraGrid.Views.Grid.GridView();
                  this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                  this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
                  ((System.ComponentModel.ISupportInitialize)(this.G_PARAMETERS)).BeginInit();
                  ((System.ComponentModel.ISupportInitialize)(this.GV_PARAMETERS)).BeginInit();
                  this.SuspendLayout();
                  // 
                  // G_PARAMETERS
                  // 
                  this.G_PARAMETERS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                  this.G_PARAMETERS.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
                  this.G_PARAMETERS.Location = new System.Drawing.Point(2, 3);
                  this.G_PARAMETERS.MainView = this.GV_PARAMETERS;
                  this.G_PARAMETERS.Margin = new System.Windows.Forms.Padding(4);
                  this.G_PARAMETERS.Name = "G_PARAMETERS";
                  this.G_PARAMETERS.Size = new System.Drawing.Size(804, 466);
                  this.G_PARAMETERS.TabIndex = 0;
                  this.G_PARAMETERS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GV_PARAMETERS});
                  // 
                  // GV_PARAMETERS
                  // 
                  this.GV_PARAMETERS.GridControl = this.G_PARAMETERS;
                  this.GV_PARAMETERS.Name = "GV_PARAMETERS";
                  this.GV_PARAMETERS.OptionsView.ShowGroupPanel = false;
                  this.GV_PARAMETERS.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GV_PARAMETERS_CustomRowCellEdit);
                  // 
                  // simpleButton1
                  // 
                  this.simpleButton1.Location = new System.Drawing.Point(681, 478);
                  this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
                  this.simpleButton1.Name = "simpleButton1";
                  this.simpleButton1.Size = new System.Drawing.Size(112, 34);
                  this.simpleButton1.TabIndex = 1;
                  this.simpleButton1.Text = "Submit";
                  this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                  // 
                  // labelControl1
                  // 
                  this.labelControl1.Location = new System.Drawing.Point(8, 478);
                  this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
                  this.labelControl1.Name = "labelControl1";
                  this.labelControl1.Size = new System.Drawing.Size(94, 19);
                  this.labelControl1.TabIndex = 2;
                  this.labelControl1.Text = "labelControl1";
                  // 
                  // frm_parameters_to
                  // 
                  this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                  this.ClientSize = new System.Drawing.Size(804, 517);
                  this.Controls.Add(this.labelControl1);
                  this.Controls.Add(this.simpleButton1);
                  this.Controls.Add(this.G_PARAMETERS);
                  this.Margin = new System.Windows.Forms.Padding(4);
                  this.MaximizeBox = false;
                  this.MaximumSize = new System.Drawing.Size(826, 572);
                  this.MinimizeBox = false;
                  this.MinimumSize = new System.Drawing.Size(826, 392);
                  this.Name = "frm_parameters_to";
                  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                  this.Text = "Parameters";
                  this.Load += new System.EventHandler(this.frm_parameters_to_Load);
                  ((System.ComponentModel.ISupportInitialize)(this.G_PARAMETERS)).EndInit();
                  ((System.ComponentModel.ISupportInitialize)(this.GV_PARAMETERS)).EndInit();
                  this.ResumeLayout(false);
                  this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl G_PARAMETERS;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_PARAMETERS;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
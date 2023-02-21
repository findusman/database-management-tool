namespace DATA_MS
{
    partial class Print_Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print_Options));
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.text_id = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(null, new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "[Page # of Pages #]",
                "",
                "[Date Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            this.printableComponentLink1.SkipArea = ((DevExpress.XtraPrinting.BrickModifier)((((DevExpress.XtraPrinting.BrickModifier.DetailFooter | DevExpress.XtraPrinting.BrickModifier.ReportFooter)
                        | DevExpress.XtraPrinting.BrickModifier.MarginalFooter)
                        | DevExpress.XtraPrinting.BrickModifier.InnerPageFooter)));
            this.printableComponentLink1.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Exact;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(128, 72);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Create";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // text_id
            // 
            this.text_id.EditValue = "";
            this.text_id.Location = new System.Drawing.Point(52, 17);
            this.text_id.Name = "text_id";
            this.text_id.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.text_id.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.text_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.text_id.Size = new System.Drawing.Size(232, 22);
            this.text_id.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Name :";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.text_id);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(290, 102);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Create Database";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(209, 72);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Exit";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(-3, 52);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(296, 10);
            this.panelControl1.TabIndex = 5;
            // 
            // Print_Options
            // 
            this.AcceptButton = this.simpleButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 102);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Print_Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Database";
            this.Load += new System.EventHandler(this.Print_Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit text_id;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
namespace DATA_MS
{
    partial class frm_sele_db
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.LOOK_UP_DATABSES = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.LOOK_UP_DATABSES.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(158, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(57, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "OK";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // LOOK_UP_DATABSES
            // 
            this.LOOK_UP_DATABSES.Location = new System.Drawing.Point(12, 12);
            this.LOOK_UP_DATABSES.Name = "LOOK_UP_DATABSES";
            this.LOOK_UP_DATABSES.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.LOOK_UP_DATABSES.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LOOK_UP_DATABSES.Size = new System.Drawing.Size(140, 22);
            this.LOOK_UP_DATABSES.TabIndex = 0;
            // 
            // frm_sele_db
            // 
            this.AcceptButton = this.simpleButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 43);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.LOOK_UP_DATABSES);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_sele_db";
            this.ShowIcon = false;
            this.Text = "Select Database";
            this.Load += new System.EventHandler(this.frm_sele_db_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOOK_UP_DATABSES.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LookUpEdit LOOK_UP_DATABSES;
    }
}
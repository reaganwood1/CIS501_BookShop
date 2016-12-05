namespace edu.ksu.cis.masaaki
{
    partial class SelectDialog
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
            this.lbList = new System.Windows.Forms.ListBox();
            this.bnSelect = new System.Windows.Forms.Button();
            this.bnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbList
            // 
            this.lbList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbList.FormattingEnabled = true;
            this.lbList.HorizontalScrollbar = true;
            this.lbList.Location = new System.Drawing.Point(32, 12);
            this.lbList.Name = "lbList";
            this.lbList.ScrollAlwaysVisible = true;
            this.lbList.Size = new System.Drawing.Size(762, 290);
            this.lbList.TabIndex = 0;
            // 
            // bnSelect
            // 
            this.bnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnSelect.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bnSelect.Location = new System.Drawing.Point(105, 335);
            this.bnSelect.Name = "bnSelect";
            this.bnSelect.Size = new System.Drawing.Size(75, 22);
            this.bnSelect.TabIndex = 1;
            this.bnSelect.Text = "Select";
            this.bnSelect.UseVisualStyleBackColor = true;
            // 
            // bnDone
            // 
            this.bnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnDone.Location = new System.Drawing.Point(672, 334);
            this.bnDone.Name = "bnDone";
            this.bnDone.Size = new System.Drawing.Size(75, 23);
            this.bnDone.TabIndex = 3;
            this.bnDone.Text = "Done";
            this.bnDone.UseVisualStyleBackColor = true;
            // 
            // SelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 377);
            this.Controls.Add(this.bnDone);
            this.Controls.Add(this.bnSelect);
            this.Controls.Add(this.lbList);
            this.Font = new System.Drawing.Font("MS Mincho", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SelectDialog";
            this.Text = "ListDialog";
            this.Load += new System.EventHandler(this.SelectDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbList;
        protected System.Windows.Forms.Button bnDone;
        protected System.Windows.Forms.Button bnSelect;
    }
}
namespace edu.ksu.cis.masaaki
{
    partial class ShowCompleteTransactionDialog
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
            this.SuspendLayout();
            // 
            // bnSelect
            // 
            this.bnSelect.Location = new System.Drawing.Point(75, 334);
            this.bnSelect.Size = new System.Drawing.Size(157, 22);
            this.bnSelect.Text = "Remove Transaction";
            // 
            // ShowCompleteTransactionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 377);
            this.Name = "ShowCompleteTransactionDialog";
            this.Text = "Complete Transaction";
            this.Load += new System.EventHandler(this.ShowCompleteTransactionDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
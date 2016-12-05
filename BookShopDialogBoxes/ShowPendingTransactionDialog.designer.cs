namespace edu.ksu.cis.masaaki
{
    partial class ShowPendingTransactionDialog
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
            this.bnReturnBook = new System.Windows.Forms.Button();
            this.bnRemoveTransaction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnSelect
            // 
            this.bnSelect.Location = new System.Drawing.Point(93, 334);
            this.bnSelect.Text = "Approve";
            // 
            // bnReturnBook
            // 
            this.bnReturnBook.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bnReturnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnReturnBook.Location = new System.Drawing.Point(226, 334);
            this.bnReturnBook.Name = "bnReturnBook";
            this.bnReturnBook.Size = new System.Drawing.Size(99, 23);
            this.bnReturnBook.TabIndex = 4;
            this.bnReturnBook.Text = "Return Book";
            this.bnReturnBook.UseVisualStyleBackColor = true;
            // 
            // bnRemoveTransaction
            // 
            this.bnRemoveTransaction.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.bnRemoveTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnRemoveTransaction.Location = new System.Drawing.Point(369, 334);
            this.bnRemoveTransaction.Name = "bnRemoveTransaction";
            this.bnRemoveTransaction.Size = new System.Drawing.Size(145, 23);
            this.bnRemoveTransaction.TabIndex = 5;
            this.bnRemoveTransaction.Text = "Remove Transaction";
            this.bnRemoveTransaction.UseVisualStyleBackColor = true;
            // 
            // ShowPendingTransactionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 377);
            this.Controls.Add(this.bnRemoveTransaction);
            this.Controls.Add(this.bnReturnBook);
            this.Name = "ShowPendingTransactionDialog";
            this.Text = "Pending Transaction";
            this.Load += new System.EventHandler(this.ShowPendingTransaction_Load);
            this.Controls.SetChildIndex(this.bnSelect, 0);
            this.Controls.SetChildIndex(this.bnDone, 0);
            this.Controls.SetChildIndex(this.bnReturnBook, 0);
            this.Controls.SetChildIndex(this.bnRemoveTransaction, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnReturnBook;
        private System.Windows.Forms.Button bnRemoveTransaction;
    }
}
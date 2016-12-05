namespace edu.ksu.cis.masaaki
{
    partial class StaffWindow
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
            this.bnSave = new System.Windows.Forms.Button();
            this.bnRestore = new System.Windows.Forms.Button();
            this.bnListCustomers = new System.Windows.Forms.Button();
            this.bnAddBook = new System.Windows.Forms.Button();
            this.bnListBooks = new System.Windows.Forms.Button();
            this.bnPendingTransactions = new System.Windows.Forms.Button();
            this.bnCompleteTransactions = new System.Windows.Forms.Button();
            this.bnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnSave
            // 
            this.bnSave.Location = new System.Drawing.Point(46, 212);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(75, 23);
            this.bnSave.TabIndex = 3;
            this.bnSave.Text = "Save";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // bnRestore
            // 
            this.bnRestore.Location = new System.Drawing.Point(177, 212);
            this.bnRestore.Name = "bnRestore";
            this.bnRestore.Size = new System.Drawing.Size(75, 23);
            this.bnRestore.TabIndex = 4;
            this.bnRestore.Text = "Restore";
            this.bnRestore.UseVisualStyleBackColor = true;
            this.bnRestore.Click += new System.EventHandler(this.bnRestore_Click);
            // 
            // bnListCustomers
            // 
            this.bnListCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bnListCustomers.Location = new System.Drawing.Point(46, 45);
            this.bnListCustomers.Name = "bnListCustomers";
            this.bnListCustomers.Size = new System.Drawing.Size(114, 23);
            this.bnListCustomers.TabIndex = 6;
            this.bnListCustomers.Text = "List Customers";
            this.bnListCustomers.UseVisualStyleBackColor = true;
            this.bnListCustomers.Click += new System.EventHandler(this.bnListCustomers_Click);
            // 
            // bnAddBook
            // 
            this.bnAddBook.Location = new System.Drawing.Point(46, 143);
            this.bnAddBook.Name = "bnAddBook";
            this.bnAddBook.Size = new System.Drawing.Size(114, 23);
            this.bnAddBook.TabIndex = 24;
            this.bnAddBook.Text = "Add Book";
            this.bnAddBook.UseVisualStyleBackColor = true;
            this.bnAddBook.Click += new System.EventHandler(this.bnAddBook_Click);
            // 
            // bnListBooks
            // 
            this.bnListBooks.Location = new System.Drawing.Point(46, 89);
            this.bnListBooks.Name = "bnListBooks";
            this.bnListBooks.Size = new System.Drawing.Size(114, 23);
            this.bnListBooks.TabIndex = 25;
            this.bnListBooks.Text = "List Books";
            this.bnListBooks.UseVisualStyleBackColor = true;
            this.bnListBooks.Click += new System.EventHandler(this.bnListBooks_Click);
            // 
            // bnPendingTransactions
            // 
            this.bnPendingTransactions.Location = new System.Drawing.Point(211, 45);
            this.bnPendingTransactions.Name = "bnPendingTransactions";
            this.bnPendingTransactions.Size = new System.Drawing.Size(162, 23);
            this.bnPendingTransactions.TabIndex = 27;
            this.bnPendingTransactions.Text = " List Pending Transactions";
            this.bnPendingTransactions.UseVisualStyleBackColor = true;
            this.bnPendingTransactions.Click += new System.EventHandler(this.bnPendingTransactions_Click);
            // 
            // bnCompleteTransactions
            // 
            this.bnCompleteTransactions.Location = new System.Drawing.Point(211, 89);
            this.bnCompleteTransactions.Name = "bnCompleteTransactions";
            this.bnCompleteTransactions.Size = new System.Drawing.Size(162, 23);
            this.bnCompleteTransactions.TabIndex = 28;
            this.bnCompleteTransactions.Text = "List Complete Transactions";
            this.bnCompleteTransactions.UseVisualStyleBackColor = true;
            this.bnCompleteTransactions.Click += new System.EventHandler(this.bnCompleteTransactions_Click);
            // 
            // bnDone
            // 
            this.bnDone.Location = new System.Drawing.Point(298, 212);
            this.bnDone.Name = "bnDone";
            this.bnDone.Size = new System.Drawing.Size(75, 23);
            this.bnDone.TabIndex = 29;
            this.bnDone.Text = "Done";
            this.bnDone.UseVisualStyleBackColor = true;
            this.bnDone.Click += new System.EventHandler(this.bnDone_Click);
            // 
            // StaffWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 284);
            this.Controls.Add(this.bnDone);
            this.Controls.Add(this.bnCompleteTransactions);
            this.Controls.Add(this.bnPendingTransactions);
            this.Controls.Add(this.bnListBooks);
            this.Controls.Add(this.bnAddBook);
            this.Controls.Add(this.bnListCustomers);
            this.Controls.Add(this.bnRestore);
            this.Controls.Add(this.bnSave);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "StaffWindow";
            this.Text = "Staff Window";
            this.Load += new System.EventHandler(this.StaffWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.Button bnRestore;
        private System.Windows.Forms.Button bnListCustomers;
        private System.Windows.Forms.Button bnAddBook;
        private System.Windows.Forms.Button bnListBooks;
        private System.Windows.Forms.Button bnPendingTransactions;
        private System.Windows.Forms.Button bnCompleteTransactions;
        private System.Windows.Forms.Button bnDone;
    }
}
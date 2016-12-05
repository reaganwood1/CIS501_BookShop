namespace edu.ksu.cis.masaaki
{
    partial class CustomerWindow
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
            this.bnAddCustomer = new System.Windows.Forms.Button();
            this.bnLogin = new System.Windows.Forms.Button();
            this.bnEditSelfInfo = new System.Windows.Forms.Button();
            this.bnLogout = new System.Windows.Forms.Button();
            this.bnBook = new System.Windows.Forms.Button();
            this.bnShowWishlist = new System.Windows.Forms.Button();
            this.bnShowCart = new System.Windows.Forms.Button();
            this.bnTransactionHistory = new System.Windows.Forms.Button();
            this.lbLoggedinCustomer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bnAddCustomer
            // 
            this.bnAddCustomer.Location = new System.Drawing.Point(65, 82);
            this.bnAddCustomer.Name = "bnAddCustomer";
            this.bnAddCustomer.Size = new System.Drawing.Size(75, 23);
            this.bnAddCustomer.TabIndex = 25;
            this.bnAddCustomer.Text = "Register";
            this.bnAddCustomer.UseVisualStyleBackColor = true;
            this.bnAddCustomer.Click += new System.EventHandler(this.bnAddCustomer_Click);
            // 
            // bnLogin
            // 
            this.bnLogin.Location = new System.Drawing.Point(65, 146);
            this.bnLogin.Name = "bnLogin";
            this.bnLogin.Size = new System.Drawing.Size(75, 23);
            this.bnLogin.TabIndex = 26;
            this.bnLogin.Text = "Login";
            this.bnLogin.UseVisualStyleBackColor = true;
            this.bnLogin.Click += new System.EventHandler(this.bnLogin_Click);
            // 
            // bnEditSelfInfo
            // 
            this.bnEditSelfInfo.Location = new System.Drawing.Point(65, 215);
            this.bnEditSelfInfo.Name = "bnEditSelfInfo";
            this.bnEditSelfInfo.Size = new System.Drawing.Size(75, 23);
            this.bnEditSelfInfo.TabIndex = 27;
            this.bnEditSelfInfo.Text = "Edit Self Info";
            this.bnEditSelfInfo.UseVisualStyleBackColor = true;
            this.bnEditSelfInfo.Click += new System.EventHandler(this.bnEditSelfInfo_Click);
            // 
            // bnLogout
            // 
            this.bnLogout.Location = new System.Drawing.Point(65, 276);
            this.bnLogout.Name = "bnLogout";
            this.bnLogout.Size = new System.Drawing.Size(75, 23);
            this.bnLogout.TabIndex = 28;
            this.bnLogout.Text = "Logout";
            this.bnLogout.UseVisualStyleBackColor = true;
            this.bnLogout.Click += new System.EventHandler(this.bnLogout_Click);
            // 
            // bnBook
            // 
            this.bnBook.Location = new System.Drawing.Point(189, 82);
            this.bnBook.Name = "bnBook";
            this.bnBook.Size = new System.Drawing.Size(114, 23);
            this.bnBook.TabIndex = 29;
            this.bnBook.Text = "List Books";
            this.bnBook.UseVisualStyleBackColor = true;
            this.bnBook.Click += new System.EventHandler(this.bnBook_Click);
            // 
            // bnShowWishlist
            // 
            this.bnShowWishlist.Location = new System.Drawing.Point(189, 146);
            this.bnShowWishlist.Name = "bnShowWishlist";
            this.bnShowWishlist.Size = new System.Drawing.Size(114, 23);
            this.bnShowWishlist.TabIndex = 31;
            this.bnShowWishlist.Text = "Show Wishlist";
            this.bnShowWishlist.UseVisualStyleBackColor = true;
            this.bnShowWishlist.Click += new System.EventHandler(this.bnShowWishlist_Click);
            // 
            // bnShowCart
            // 
            this.bnShowCart.Location = new System.Drawing.Point(189, 215);
            this.bnShowCart.Name = "bnShowCart";
            this.bnShowCart.Size = new System.Drawing.Size(114, 23);
            this.bnShowCart.TabIndex = 32;
            this.bnShowCart.Text = "Show Cart";
            this.bnShowCart.UseVisualStyleBackColor = true;
            this.bnShowCart.Click += new System.EventHandler(this.bnShowCart_Click);
            // 
            // bnTransactionHistory
            // 
            this.bnTransactionHistory.Location = new System.Drawing.Point(189, 276);
            this.bnTransactionHistory.Name = "bnTransactionHistory";
            this.bnTransactionHistory.Size = new System.Drawing.Size(114, 23);
            this.bnTransactionHistory.TabIndex = 33;
            this.bnTransactionHistory.Text = "Transaction History";
            this.bnTransactionHistory.UseVisualStyleBackColor = true;
            this.bnTransactionHistory.Click += new System.EventHandler(this.bnTransactionHistory_Click);
            // 
            // lbLoggedinCustomer
            // 
            this.lbLoggedinCustomer.AutoSize = true;
            this.lbLoggedinCustomer.Location = new System.Drawing.Point(83, 25);
            this.lbLoggedinCustomer.Name = "lbLoggedinCustomer";
            this.lbLoggedinCustomer.Size = new System.Drawing.Size(0, 13);
            this.lbLoggedinCustomer.TabIndex = 34;
            this.lbLoggedinCustomer.Text = "Loggedin Customer : (none)";
            // 
            // CustomerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 337);
            this.Controls.Add(this.lbLoggedinCustomer);
            this.Controls.Add(this.bnTransactionHistory);
            this.Controls.Add(this.bnShowCart);
            this.Controls.Add(this.bnShowWishlist);
            this.Controls.Add(this.bnBook);
            this.Controls.Add(this.bnLogout);
            this.Controls.Add(this.bnEditSelfInfo);
            this.Controls.Add(this.bnLogin);
            this.Controls.Add(this.bnAddCustomer);
            this.Location = new System.Drawing.Point(200, 100);
            this.Name = "CustomerWindow";
            this.Text = "Customer Window";
            this.Load += new System.EventHandler(this.CustomerWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnAddCustomer;
        private System.Windows.Forms.Button bnLogin;
        private System.Windows.Forms.Button bnEditSelfInfo;
        private System.Windows.Forms.Button bnLogout;
        private System.Windows.Forms.Button bnBook;
        private System.Windows.Forms.Button bnShowWishlist;
        private System.Windows.Forms.Button bnShowCart;
        private System.Windows.Forms.Button bnTransactionHistory;
        private System.Windows.Forms.Label lbLoggedinCustomer;
    }
}
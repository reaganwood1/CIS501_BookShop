namespace edu.ksu.cis.masaaki
{
    partial class BookInformationDialog
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
            this.bnToCart = new System.Windows.Forms.Button();
            this.bnToWishList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnEditDone
            // 
            this.bnEditDone.Location = new System.Drawing.Point(267, 337);
            this.bnEditDone.Text = "Done";
            // 
            // bnToCart
            // 
            this.bnToCart.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bnToCart.Location = new System.Drawing.Point(26, 337);
            this.bnToCart.Name = "bnToCart";
            this.bnToCart.Size = new System.Drawing.Size(101, 23);
            this.bnToCart.TabIndex = 16;
            this.bnToCart.Text = "Add To Cart";
            this.bnToCart.UseVisualStyleBackColor = true;
            // 
            // bnToWishList
            // 
            this.bnToWishList.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bnToWishList.Location = new System.Drawing.Point(145, 337);
            this.bnToWishList.Name = "bnToWishList";
            this.bnToWishList.Size = new System.Drawing.Size(101, 23);
            this.bnToWishList.TabIndex = 17;
            this.bnToWishList.Text = "Add To WishList";
            this.bnToWishList.UseVisualStyleBackColor = true;
            // 
            // BookInformationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 417);
            this.Controls.Add(this.bnToWishList);
            this.Controls.Add(this.bnToCart);
            this.Name = "BookInformationDialog";
            this.Text = "Book Information (Read Only)";
            this.Load += new System.EventHandler(this.BookInformationDialog_Load);
            this.Controls.SetChildIndex(this.tbTitle, 0);
            this.Controls.SetChildIndex(this.tbAuthor, 0);
            this.Controls.SetChildIndex(this.tbPublisher, 0);
            this.Controls.SetChildIndex(this.tbISBN, 0);
            this.Controls.SetChildIndex(this.tbPrice, 0);
            this.Controls.SetChildIndex(this.tbDate, 0);
            this.Controls.SetChildIndex(this.tbStock, 0);
            this.Controls.SetChildIndex(this.bnEditDone, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.bnToCart, 0);
            this.Controls.SetChildIndex(this.bnToWishList, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnToCart;
        private System.Windows.Forms.Button bnToWishList;
    }
}
namespace edu.ksu.cis.masaaki
{
    partial class BookInWishListDialog
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
            this.bnRemoveFromWishList = new System.Windows.Forms.Button();
            this.bnAddToCart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnEditDone
            // 
            this.bnEditDone.Location = new System.Drawing.Point(314, 337);
            this.bnEditDone.Text = "Done";
            // 
            // bnCancel
            // 
            this.bnCancel.Location = new System.Drawing.Point(420, 337);
            // 
            // tbTitle
            // 
            this.tbTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // tbAuthor
            // 
            this.tbAuthor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // tbPublisher
            // 
            this.tbPublisher.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // tbISBN
            // 
            this.tbISBN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // tbPrice
            // 
            this.tbPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // tbDate
            // 
            this.tbDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // tbStock
            // 
            this.tbStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // bnRemoveFromWishList
            // 
            this.bnRemoveFromWishList.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bnRemoveFromWishList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnRemoveFromWishList.Location = new System.Drawing.Point(131, 335);
            this.bnRemoveFromWishList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bnRemoveFromWishList.Name = "bnRemoveFromWishList";
            this.bnRemoveFromWishList.Size = new System.Drawing.Size(149, 27);
            this.bnRemoveFromWishList.TabIndex = 4;
            this.bnRemoveFromWishList.Text = "Remove From WishList";
            this.bnRemoveFromWishList.UseVisualStyleBackColor = true;
            // 
            // bnAddToCart
            // 
            this.bnAddToCart.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bnAddToCart.Location = new System.Drawing.Point(26, 339);
            this.bnAddToCart.Name = "bnAddToCart";
            this.bnAddToCart.Size = new System.Drawing.Size(75, 23);
            this.bnAddToCart.TabIndex = 16;
            this.bnAddToCart.Text = "Add To Cart";
            this.bnAddToCart.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button1.Location = new System.Drawing.Point(26, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Add To Cart";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BookInWishListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 446);
            this.Controls.Add(this.bnAddToCart);
            this.Controls.Add(this.bnRemoveFromWishList);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BookInWishListDialog";
            this.Text = "Book In WishList";
            this.Load += new System.EventHandler(this.BookInWishListDialog_Load);
            this.Controls.SetChildIndex(this.tbTitle, 0);
            this.Controls.SetChildIndex(this.tbAuthor, 0);
            this.Controls.SetChildIndex(this.tbPublisher, 0);
            this.Controls.SetChildIndex(this.tbISBN, 0);
            this.Controls.SetChildIndex(this.tbPrice, 0);
            this.Controls.SetChildIndex(this.tbDate, 0);
            this.Controls.SetChildIndex(this.tbStock, 0);
            this.Controls.SetChildIndex(this.bnEditDone, 0);
            this.Controls.SetChildIndex(this.bnCancel, 0);
            this.Controls.SetChildIndex(this.bnRemoveFromWishList, 0);
            this.Controls.SetChildIndex(this.bnAddToCart, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnRemoveFromWishList;
        private System.Windows.Forms.Button bnAddToCart;
        private System.Windows.Forms.Button button1;
    }
}
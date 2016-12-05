namespace edu.ksu.cis.masaaki
{
    partial class BookShop
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
            this.bnDone = new System.Windows.Forms.Button();
            this.bnLoad = new System.Windows.Forms.Button();
            this.bnStartWithoutLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnDone
            // 
            this.bnDone.Location = new System.Drawing.Point(97, 138);
            this.bnDone.Name = "bnDone";
            this.bnDone.Size = new System.Drawing.Size(75, 23);
            this.bnDone.TabIndex = 0;
            this.bnDone.Text = "Cancel";
            this.bnDone.UseVisualStyleBackColor = true;
            this.bnDone.Click += new System.EventHandler(this.bnDone_Click);
            // 
            // bnLoad
            // 
            this.bnLoad.Location = new System.Drawing.Point(72, 33);
            this.bnLoad.Name = "bnLoad";
            this.bnLoad.Size = new System.Drawing.Size(127, 23);
            this.bnLoad.TabIndex = 1;
            this.bnLoad.Text = "Load and Start";
            this.bnLoad.UseVisualStyleBackColor = true;
            this.bnLoad.Click += new System.EventHandler(this.bnLoadAndStart_Click);
            // 
            // bnStartWithoutLoad
            // 
            this.bnStartWithoutLoad.Location = new System.Drawing.Point(72, 86);
            this.bnStartWithoutLoad.Name = "bnStartWithoutLoad";
            this.bnStartWithoutLoad.Size = new System.Drawing.Size(127, 23);
            this.bnStartWithoutLoad.TabIndex = 2;
            this.bnStartWithoutLoad.Text = "Start without Load";
            this.bnStartWithoutLoad.UseVisualStyleBackColor = true;
            this.bnStartWithoutLoad.Click += new System.EventHandler(this.bnStartWithoutLoad_Click);
            // 
            // BookShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 201);
            this.Controls.Add(this.bnStartWithoutLoad);
            this.Controls.Add(this.bnDone);
            this.Controls.Add(this.bnLoad);
            this.Name = "BookShop";
            this.Text = "BookShop";
            this.Load += new System.EventHandler(this.BookShop_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnDone;
        private System.Windows.Forms.Button bnLoad;
        private System.Windows.Forms.Button bnStartWithoutLoad;
    }
}


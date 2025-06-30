namespace LibrarySystem.UI.Forms
{
    partial class MenuOutlineForm
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
            this.lnkSearchBook = new System.Windows.Forms.LinkLabel();
            this.lnkBooks = new System.Windows.Forms.LinkLabel();
            this.lnkWelcome = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lnkSearchBook
            // 
            this.lnkSearchBook.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(150)))));
            this.lnkSearchBook.AutoSize = true;
            this.lnkSearchBook.BackColor = System.Drawing.Color.Transparent;
            this.lnkSearchBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSearchBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkSearchBook.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSearchBook.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lnkSearchBook.Location = new System.Drawing.Point(109, 258);
            this.lnkSearchBook.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkSearchBook.Name = "lnkSearchBook";
            this.lnkSearchBook.Padding = new System.Windows.Forms.Padding(2);
            this.lnkSearchBook.Size = new System.Drawing.Size(406, 65);
            this.lnkSearchBook.TabIndex = 0;
            this.lnkSearchBook.TabStop = true;
            this.lnkSearchBook.Text = "🔍 Search Book";
            this.lnkSearchBook.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.lnkSearchBook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSearchBook_LinkClicked);
            // 
            // lnkBooks
            // 
            this.lnkBooks.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(150)))));
            this.lnkBooks.AutoSize = true;
            this.lnkBooks.BackColor = System.Drawing.Color.Transparent;
            this.lnkBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkBooks.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkBooks.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lnkBooks.Location = new System.Drawing.Point(109, 120);
            this.lnkBooks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkBooks.Name = "lnkBooks";
            this.lnkBooks.Padding = new System.Windows.Forms.Padding(2);
            this.lnkBooks.Size = new System.Drawing.Size(248, 65);
            this.lnkBooks.TabIndex = 1;
            this.lnkBooks.TabStop = true;
            this.lnkBooks.Text = "📚 Books";
            this.lnkBooks.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.lnkBooks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBooks_LinkClicked);
            // 
            // lnkWelcome
            // 
            this.lnkWelcome.ActiveLinkColor = System.Drawing.Color.Black;
            this.lnkWelcome.AutoSize = true;
            this.lnkWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lnkWelcome.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lnkWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkWelcome.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkWelcome.LinkColor = System.Drawing.Color.Black;
            this.lnkWelcome.Location = new System.Drawing.Point(71, 14);
            this.lnkWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkWelcome.Name = "lnkWelcome";
            this.lnkWelcome.Padding = new System.Windows.Forms.Padding(2);
            this.lnkWelcome.Size = new System.Drawing.Size(470, 41);
            this.lnkWelcome.TabIndex = 3;
            this.lnkWelcome.TabStop = true;
            this.lnkWelcome.Text = "🙍 Hello Ibrahim, How are you today?";
            this.lnkWelcome.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            // 
            // MenuOutlineForm
            // 
            this.AccessibleDescription = "Form for  operations";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 749);
            this.Controls.Add(this.lnkWelcome);
            this.Controls.Add(this.lnkBooks);
            this.Controls.Add(this.lnkSearchBook);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "MenuOutlineForm";
            this.Text = "MainPageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkSearchBook;
        private System.Windows.Forms.LinkLabel lnkBooks;
        private System.Windows.Forms.LinkLabel lnkWelcome;
    }
}
namespace LibrarySystem.App.Forms.Book
{
    partial class BookBorrowManageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lnkTitle = new System.Windows.Forms.LinkLabel();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.txtPublishYear = new System.Windows.Forms.TextBox();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.lblReturndate = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(22, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 50;
            this.label1.Text = "ISBN";
            // 
            // txtPublisher
            // 
            this.txtPublisher.BackColor = System.Drawing.Color.White;
            this.txtPublisher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPublisher.Enabled = false;
            this.txtPublisher.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPublisher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPublisher.Location = new System.Drawing.Point(147, 415);
            this.txtPublisher.Margin = new System.Windows.Forms.Padding(5);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(200, 29);
            this.txtPublisher.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(23, 417);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 21);
            this.label7.TabIndex = 46;
            this.label7.Text = "Publisher";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(23, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 21);
            this.label6.TabIndex = 45;
            this.label6.Text = "Pages";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(23, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 21);
            this.label5.TabIndex = 44;
            this.label5.Text = "Publish Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(23, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 43;
            this.label4.Text = "Language";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(23, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 41;
            this.label2.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(23, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 39;
            this.label3.Text = "Category";
            // 
            // lnkTitle
            // 
            this.lnkTitle.AutoSize = true;
            this.lnkTitle.BackColor = System.Drawing.Color.Transparent;
            this.lnkTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkTitle.LinkColor = System.Drawing.Color.Black;
            this.lnkTitle.Location = new System.Drawing.Point(0, 0);
            this.lnkTitle.Name = "lnkTitle";
            this.lnkTitle.Padding = new System.Windows.Forms.Padding(2);
            this.lnkTitle.Size = new System.Drawing.Size(269, 65);
            this.lnkTitle.TabIndex = 37;
            this.lnkTitle.TabStop = true;
            this.lnkTitle.Text = "Page Title";
            this.lnkTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkTitle.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // btnBorrow
            // 
            this.btnBorrow.AutoSize = true;
            this.btnBorrow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBorrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnBorrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnBorrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(150)))));
            this.btnBorrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(180)))));
            this.btnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.Location = new System.Drawing.Point(247, 452);
            this.btnBorrow.MinimumSize = new System.Drawing.Size(100, 34);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnBorrow.Size = new System.Drawing.Size(100, 39);
            this.btnBorrow.TabIndex = 36;
            this.btnBorrow.Text = "Borrow";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl.Location = new System.Drawing.Point(23, 141);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(91, 21);
            this.lbl.TabIndex = 34;
            this.lbl.Text = "Book Name";
            // 
            // txtPages
            // 
            this.txtPages.BackColor = System.Drawing.Color.White;
            this.txtPages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPages.Enabled = false;
            this.txtPages.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPages.Location = new System.Drawing.Point(146, 376);
            this.txtPages.Margin = new System.Windows.Forms.Padding(5);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(200, 29);
            this.txtPages.TabIndex = 52;
            // 
            // txtPublishYear
            // 
            this.txtPublishYear.BackColor = System.Drawing.Color.White;
            this.txtPublishYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPublishYear.Enabled = false;
            this.txtPublishYear.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPublishYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPublishYear.Location = new System.Drawing.Point(146, 337);
            this.txtPublishYear.Margin = new System.Windows.Forms.Padding(5);
            this.txtPublishYear.Name = "txtPublishYear";
            this.txtPublishYear.Size = new System.Drawing.Size(200, 29);
            this.txtPublishYear.TabIndex = 53;
            // 
            // txtLanguage
            // 
            this.txtLanguage.BackColor = System.Drawing.Color.White;
            this.txtLanguage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLanguage.Enabled = false;
            this.txtLanguage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLanguage.Location = new System.Drawing.Point(146, 290);
            this.txtLanguage.Margin = new System.Windows.Forms.Padding(5);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(200, 29);
            this.txtLanguage.TabIndex = 54;
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.White;
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Enabled = false;
            this.txtCategory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCategory.Location = new System.Drawing.Point(146, 238);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(5);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(200, 29);
            this.txtCategory.TabIndex = 55;
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.Color.White;
            this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthor.Enabled = false;
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAuthor.Location = new System.Drawing.Point(147, 187);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(5);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 29);
            this.txtAuthor.TabIndex = 56;
            // 
            // txtBookName
            // 
            this.txtBookName.BackColor = System.Drawing.Color.White;
            this.txtBookName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookName.Enabled = false;
            this.txtBookName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBookName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBookName.Location = new System.Drawing.Point(146, 141);
            this.txtBookName.Margin = new System.Windows.Forms.Padding(5);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(200, 29);
            this.txtBookName.TabIndex = 57;
            // 
            // txtIsbn
            // 
            this.txtIsbn.BackColor = System.Drawing.Color.White;
            this.txtIsbn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIsbn.Enabled = false;
            this.txtIsbn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtIsbn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIsbn.Location = new System.Drawing.Point(147, 102);
            this.txtIsbn.Margin = new System.Windows.Forms.Padding(5);
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(200, 29);
            this.txtIsbn.TabIndex = 58;
            // 
            // lblReturndate
            // 
            this.lblReturndate.AutoSize = true;
            this.lblReturndate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblReturndate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReturndate.Location = new System.Drawing.Point(22, 63);
            this.lblReturndate.Name = "lblReturndate";
            this.lblReturndate.Size = new System.Drawing.Size(93, 21);
            this.lblReturndate.TabIndex = 59;
            this.lblReturndate.Text = "Return Date";
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(147, 63);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(200, 20);
            this.dtpReturnDate.TabIndex = 61;
            // 
            // BookBorrowManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 503);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.lblReturndate);
            this.Controls.Add(this.txtIsbn);
            this.Controls.Add(this.txtBookName);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.txtPublishYear);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lnkTitle);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.lbl);
            this.Name = "BookBorrowManageForm";
            this.Text = "BookBorrowManageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnkTitle;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.TextBox txtPublishYear;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.Label lblReturndate;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
    }
}
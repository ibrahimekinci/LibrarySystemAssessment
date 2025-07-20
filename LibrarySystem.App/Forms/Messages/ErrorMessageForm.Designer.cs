namespace LibrarySystem.App.Forms.Messages
{
    partial class ErrorMessageForm
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
            this.btnGoHomePage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lnkTitle = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGoHomePage
            // 
            this.btnGoHomePage.Location = new System.Drawing.Point(153, 413);
            this.btnGoHomePage.Name = "btnGoHomePage";
            this.btnGoHomePage.Size = new System.Drawing.Size(495, 20);
            this.btnGoHomePage.TabIndex = 5;
            this.btnGoHomePage.Text = "Go to Home Page";
            this.btnGoHomePage.UseVisualStyleBackColor = true;
            this.btnGoHomePage.Click += new System.EventHandler(this.btnGoHomePage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibrarySystem.App.Properties.Resources.Error;
            this.pictureBox1.Location = new System.Drawing.Point(153, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(495, 380);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lnkTitle
            // 
            this.lnkTitle.AutoSize = true;
            this.lnkTitle.BackColor = System.Drawing.Color.Transparent;
            this.lnkTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lnkTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkTitle.LinkColor = System.Drawing.Color.Black;
            this.lnkTitle.Location = new System.Drawing.Point(0, 0);
            this.lnkTitle.Name = "lnkTitle";
            this.lnkTitle.Padding = new System.Windows.Forms.Padding(2);
            this.lnkTitle.Size = new System.Drawing.Size(645, 43);
            this.lnkTitle.TabIndex = 24;
            this.lnkTitle.TabStop = true;
            this.lnkTitle.Text = "We saved the exception. Please try again";
            this.lnkTitle.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // ErrorMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lnkTitle);
            this.Controls.Add(this.btnGoHomePage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ErrorMessageForm";
            this.Text = "ErrorMessagePage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoHomePage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkTitle;
    }
}
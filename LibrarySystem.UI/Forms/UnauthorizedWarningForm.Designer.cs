namespace LibrarySystem.UI.Forms
{
    partial class UnauthorizedWarningForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGoHomePage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibrarySystem.UI.Properties.Resources._401;
            this.pictureBox1.Location = new System.Drawing.Point(183, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(578, 438);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnGoHomePage
            // 
            this.btnGoHomePage.Location = new System.Drawing.Point(183, 503);
            this.btnGoHomePage.Name = "btnGoHomePage";
            this.btnGoHomePage.Size = new System.Drawing.Size(578, 23);
            this.btnGoHomePage.TabIndex = 1;
            this.btnGoHomePage.Text = "Go to Home Page";
            this.btnGoHomePage.UseVisualStyleBackColor = true;
            this.btnGoHomePage.Click += new System.EventHandler(this.btnGoHomePage_Click);
            // 
            // UnauthorizedWarningForm
            // 
            this.AccessibleDescription = "Form for  operations";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 647);
            this.Controls.Add(this.btnGoHomePage);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(931, 686);
            this.Name = "UnauthorizedWarningForm";
            this.Text = "UnauthorizedWarningForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGoHomePage;
    }
}
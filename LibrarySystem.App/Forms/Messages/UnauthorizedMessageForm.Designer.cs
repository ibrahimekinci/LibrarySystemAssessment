namespace LibrarySystem.App.Forms.Messages
{
    partial class UnauthorizedMessageForm
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGoHomePage
            // 
            this.btnGoHomePage.Location = new System.Drawing.Point(153, 413);
            this.btnGoHomePage.Name = "btnGoHomePage";
            this.btnGoHomePage.Size = new System.Drawing.Size(495, 20);
            this.btnGoHomePage.TabIndex = 3;
            this.btnGoHomePage.Text = "Go to Home Page";
            this.btnGoHomePage.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibrarySystem.App.Properties.Resources._401;
            this.pictureBox1.Location = new System.Drawing.Point(153, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(495, 380);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // UnauthorizedMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGoHomePage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UnauthorizedMessageForm";
            this.Text = "UnauthorizedMessageForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGoHomePage;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
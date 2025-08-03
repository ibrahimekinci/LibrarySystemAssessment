namespace LibrarySystem.App.Forms.Author
{
    partial class AuthorManageForm
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
            this.lbl = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.lnkTitle = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl.Location = new System.Drawing.Point(25, 94);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(52, 21);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Name";
            // 
            // txt
            // 
            this.txt.BackColor = System.Drawing.Color.White;
            this.txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt.Location = new System.Drawing.Point(115, 91);
            this.txt.Margin = new System.Windows.Forms.Padding(5);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(134, 29);
            this.txt.TabIndex = 1;
            // 
            // btn
            // 
            this.btn.AutoSize = true;
            this.btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(150)))));
            this.btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(180)))));
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn.ForeColor = System.Drawing.Color.White;
            this.btn.Location = new System.Drawing.Point(146, 127);
            this.btn.MinimumSize = new System.Drawing.Size(100, 34);
            this.btn.Name = "btn";
            this.btn.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btn.Size = new System.Drawing.Size(100, 39);
            this.btn.TabIndex = 2;
            this.btn.Text = "Save";
            this.btn.UseVisualStyleBackColor = false;
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
            this.lnkTitle.TabIndex = 3;
            this.lnkTitle.TabStop = true;
            this.lnkTitle.Text = "Page Title";
            this.lnkTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkTitle.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // AuthorManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lnkTitle);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lbl);
            this.Name = "AuthorManageForm";
            this.Text = "AuthorManageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.LinkLabel lnkTitle;
    }
}
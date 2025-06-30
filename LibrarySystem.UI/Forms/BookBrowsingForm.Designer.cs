namespace LibrarySystem.UI.Forms
{
    partial class BookBrowsingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvBooks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // gvBooks
            // 
            this.gvBooks.AllowUserToAddRows = false;
            this.gvBooks.AllowUserToDeleteRows = false;
            this.gvBooks.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gvBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvBooks.BackgroundColor = System.Drawing.Color.White;
            this.gvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.gvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvBooks.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvBooks.EnableHeadersVisualStyles = false;
            this.gvBooks.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gvBooks.Location = new System.Drawing.Point(0, 0);
            this.gvBooks.Name = "gvBooks";
            this.gvBooks.ReadOnly = true;
            this.gvBooks.RowTemplate.Height = 28;
            this.gvBooks.ShowCellToolTips = false;
            this.gvBooks.Size = new System.Drawing.Size(800, 561);
            this.gvBooks.TabIndex = 0;
            this.gvBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvBooks_CellContentClick);
            // 
            // BookBrowsingForm
            // 
            this.AccessibleDescription = "Form for  operations";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.gvBooks);
            this.Name = "BookBrowsingForm";
            this.Text = "BookBrowsingForm";
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvBooks;
    }
}
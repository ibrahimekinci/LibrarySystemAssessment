using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.UI.Styles
{
    public static class AppTheme
    {
        // Color Palette
        public static readonly Color PrimaryColor = Color.FromArgb(0, 120, 215); // Modern blue
        public static readonly Color SecondaryColor = Color.FromArgb(240, 240, 240); // Light gray
        public static readonly Color TextColor = Color.FromArgb(64, 64, 64); // Dark gray

        // Font Settings
        public static readonly Font DefaultFont = new Font("Segoe UI", 12f);
        public static readonly Font BoldFont = new Font("Segoe UI", 12f, FontStyle.Bold);

        // Control Padding/Margins
        public static readonly Padding ControlPadding = new Padding(5);
        public static readonly int GridRowHeight = 28;

        /// <summary>
        /// Applies consistent styling to a control and all its children
        /// </summary>
        public static void StyleControl(Control control)
        {
            switch (control)
            {
                case LinkLabel lnk:
                    StyleLinkLabel(lnk);
                    break;
                case Button btn:
                    control.Font = DefaultFont;
                    control.ForeColor = TextColor;
                    StyleButton(btn);
                    break;
                case TextBox txt:
                    control.Font = DefaultFont;
                    control.ForeColor = TextColor;
                    StyleTextBox(txt);
                    break;
                case DataGridView dgv:
                    control.Font = DefaultFont;
                    control.ForeColor = TextColor;
                    StyleDataGrid(dgv);
                    break;
                case Label lbl:
                    control.Font = DefaultFont;
                    control.ForeColor = TextColor;
                    StyleLabel(lbl);
                    break;
                case ComboBox cmb:
                    control.Font = DefaultFont;
                    control.ForeColor = TextColor;
                    StyleComboBox(cmb);
                    break;
                case Panel pnl:
                    control.Font = DefaultFont;
                    control.ForeColor = TextColor;
                    StylePanel(pnl);
                    break;
                case GroupBox gb:
                    control.Font = DefaultFont;
                    control.ForeColor = TextColor;
                    StyleGroupBox(gb);
                    break;
            }

            // Apply to child controls
            foreach (Control child in control.Controls)
            {
                StyleControl(child);
            }
        }

        // Add these to your existing theme class
        public static readonly Size MinimumButtonSize = new Size(100, 34);
        public static readonly Padding ButtonPadding = new Padding(10, 3, 10, 3);
        public static readonly int ButtonTextMargin = 5;

        public static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = PrimaryColor;
            btn.ForeColor = Color.White;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;
            btn.Padding = ButtonPadding;
            btn.MinimumSize = MinimumButtonSize;

            // Auto-size with text margin
            btn.AutoSize = true;
            btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Calculate width based on text
            using (Graphics g = btn.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(btn.Text, btn.Font);
                btn.Width = (int)textSize.Width + (ButtonPadding.Horizontal * 2) + (ButtonTextMargin * 2);
            }

            // Visual states
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = PrimaryColor;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 90, 180);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 60, 150);
        }

        // Link styling method
        // Add these to your existing theme properties
        //public static Color LinkColor = Color.FromArgb(0, 102, 204); // Standard link blue
        //public static Color LinkHoverColor = Color.FromArgb(0, 70, 150); // Darker blue
        //public static Color VisitedLinkColor = Color.FromArgb(128, 0, 128); // Purple
        public static void StyleLinkLabel(LinkLabel link)
        {
            // Basic styling
            link.LinkBehavior = LinkBehavior.HoverUnderline; // Underline only on hover
            //link.ActiveLinkColor = LinkHoverColor;
            //link.LinkColor = LinkColor;
            //link.VisitedLinkColor = VisitedLinkColor;

            // Modern flat appearance
            link.BackColor = Color.Transparent;
            link.BorderStyle = BorderStyle.None;

            // Auto-size with padding
            link.AutoSize = true;
            link.Padding = new Padding(2);
        }
        private static void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.Margin = ControlPadding;
        }

        private static void StyleDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = PrimaryColor,
                ForeColor = Color.White,
                Font = BoldFont,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = GridRowHeight;
            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = TextColor,
                Font = DefaultFont,
                SelectionBackColor = Color.FromArgb(200, 230, 255),
                SelectionForeColor = Color.Black
            };
            dgv.AlternatingRowsDefaultCellStyle.BackColor = SecondaryColor;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static void StyleLabel(Label lbl)
        {
            lbl.Font = DefaultFont;
            lbl.ForeColor = TextColor;
        }

        private static void StyleComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = DefaultFont;
            cmb.DropDownHeight = 200;
        }

        private static void StylePanel(Panel pnl)
        {
            pnl.BackColor = SecondaryColor;
            pnl.BorderStyle = BorderStyle.None;
            pnl.Padding = ControlPadding;
        }

        private static void StyleGroupBox(GroupBox gb)
        {
            gb.Font = BoldFont;
            gb.ForeColor = PrimaryColor;
            gb.Padding = new Padding(5, 10, 5, 5);
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    public partial class Form_monthi : Form
    {
        public Form_monthi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }


        private void BogocPanel(Panel pnl, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            pnl.Region = new Region(path);
        }

        private void Form_monthi_Load(object sender, EventArgs e)
        {
            BogocPanel(panel3, 15);
            BogocPanel(panel4, 15);
            BogocPanel(panel5, 15);
            BogocPanel(panel9, 15);
            BogocPanel(panel10, 15);
            BogocPanel(panel11, 15);
            BogocPanel(panel12, 15);
            BogocPanel(panel13, 15);
            BogocPanel(panel14, 15);
            BogocPanel(panel15, 15);
            BogocPanel(panel16, 15);
            BogocPanel(panel17, 15);
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }


        static string BoDau(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            s = s.Replace('đ', 'd').Replace('Đ', 'D');
            string norm = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in norm)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            return sb.ToString().ToLower();
        }

        static bool KhopDauTu(string ten, string kw)
        {
            if (kw == "") return true;
            string t = BoDau(ten);
            // khớp nếu tên bắt đầu bằng kw, hoặc có từ nào bắt đầu bằng kw
            return t.StartsWith(kw) || t.Contains(" " + kw);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            string kw = BoDau(guna2TextBox1.Text.Trim());

            panel3.Visible = KhopDauTu(label3.Text, kw);
            panel4.Visible = KhopDauTu(label4.Text, kw);

            panel5.Visible = KhopDauTu(label5.Text, kw);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            int maDeThi = 3;
            //int mataikhoan = chamthi.MaTaiKhoan;
            int mataikhoan = 1;

            if (chamthi.batdau(maDeThi, mataikhoan))
            {
                Form_thi f = new Form_thi();
                f.Show();
                
            }
            else
            {
                MessageBox.Show(chamthi.LoiCuoi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
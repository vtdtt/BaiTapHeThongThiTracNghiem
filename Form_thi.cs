using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HeThongThiTracNghiem
{
    public partial class Form_thi : Form
    {
        private const string connectionString = "Data Source=localhost;Initial Catalog=Hethongthitracnghiem;Integrated Security=True;TrustServerCertificate=True";

        private int chiSo = 0;
        private System.Windows.Forms.Timer dongHo = null;
        private Guna2Button[] nutCauHoi;
        private bool dangCapNhat = false;

        private readonly Color MauChuaLam = Color.White;
        private readonly Color MauDaLam = Color.FromArgb(0, 192, 0);
        private readonly Color MauHienTai = Color.FromArgb(94, 148, 255);

        public Form_thi()
        {
            InitializeComponent();
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

        private void CapNhatNutCauHoi()
        {
            for (int i = 0; i < chamthi.Danhsach.Count && i < nutCauHoi.Length; i++)
            {
                Guna2Button btn = nutCauHoi[i];
                if (i == chiSo)
                {
                    btn.FillColor = MauHienTai;
                    btn.ForeColor = Color.White;
                }
                else if (chamthi.DapAn.ContainsKey(i))
                {
                    btn.FillColor = MauDaLam;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.FillColor = MauChuaLam;
                    btn.ForeColor = Color.Black;
                }
                btn.BorderColor = Color.Gray;
                btn.BorderThickness = 1;
            }
        }


        private void Form_thi_Load(object sender, EventArgs e)
        {
            BogocPanel(panel1, 15);
            BogocPanel(panel2, 15);
            BogocPanel(panel3, 15);

            if (chamthi.DeThiHienTai == null || chamthi.Danhsach == null || chamthi.Danhsach.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu bài thi. Vui lòng bắt đầu lại từ Form môn thi.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
                return;
            }

            label1.Text = "Bài thi: " + chamthi.DeThiHienTai.TenDe;
            label2.Text = "Môn: " + chamthi.DeThiHienTai.MaMon;
            label3.Text = "Còn lại: --:--";

            Guna2RadioButton[] radios = new Guna2RadioButton[4]
            {
                guna2RadioButton1, guna2RadioButton2, guna2RadioButton3, guna2RadioButton4
            };
            foreach (Guna2RadioButton r in radios)
            {
                r.AutoSize = false;
                r.Width = panel2.Width - 120;
                r.Height = 34;
            }

            nutCauHoi = new Guna2Button[36]
            {
                guna2Button1, guna2Button2, guna2Button3, guna2Button4, guna2Button5, guna2Button11, guna2Button6, guna2Button7, guna2Button8, guna2Button9,

                guna2Button10, guna2Button15, guna2Button27, guna2Button26, guna2Button25, guna2Button24, guna2Button23, guna2Button17, guna2Button22, guna2Button21,
                guna2Button20, guna2Button19, guna2Button18, guna2Button16, guna2Button39, guna2Button38, guna2Button37, guna2Button36, guna2Button35, guna2Button29,
                guna2Button34, guna2Button33, guna2Button32, guna2Button31, guna2Button30, guna2Button28
            };

            guna2Button5.Click -= guna2Button5_Click;
            guna2RadioButton1.CheckedChanged -= guna2RadioButton1_CheckedChanged;

            for (int j = 0; j < nutCauHoi.Length; j++)
            {
                int idx = j;
                nutCauHoi[j].Click += (s, ev) =>
                {
                    ChuyenCau(idx);
                };
                nutCauHoi[j].Text = (j + 1).ToString();
                nutCauHoi[j].Cursor = Cursors.Hand;
            }

            for (int i2 = chamthi.Danhsach.Count; i2 < nutCauHoi.Length; i2++)
            {
                nutCauHoi[i2].Visible = false;
            }

            guna2RadioButton1.CheckedChanged += Radio_CheckedChanged;
            guna2RadioButton2.CheckedChanged += Radio_CheckedChanged;
            guna2RadioButton3.CheckedChanged += Radio_CheckedChanged;
            guna2RadioButton4.CheckedChanged += Radio_CheckedChanged;

            guna2Button12.Click += (s, ev) =>
            {
                ChuyenCau(chiSo - 1);

            };
            guna2Button13.Click += (s, ev) =>
            {
                ChuyenCau(chiSo + 1);
            };
            guna2Button14.Click += Guna2Button14_Click;

            HienThiCau(0);

            dongHo = new System.Windows.Forms.Timer();
            dongHo.Interval = 1000;
            dongHo.Tick += DongHo_Tick;
            dongHo.Start();
            CapNhatDongHo();
        }

        private void HienThiCau(int index)
        {
            if (index < 0 || index >= chamthi.Danhsach.Count)
            {
                return;
            }

            chiSo = index;
            cauhoi ch = chamthi.Danhsach[index];

            label4.Text = string.Format("Câu {0}: {2}", index + 1, chamthi.Danhsach.Count, ch.NoiDung);
            guna2RadioButton1.Text = "A. " + ch.DapAnA;
            guna2RadioButton2.Text = "B. " + ch.DapAnB;
            guna2RadioButton3.Text = "C. " + ch.DapAnC;
            guna2RadioButton4.Text = "D. " + ch.DapAnD;


            dangCapNhat = true;
            guna2RadioButton1.Checked = false;
            guna2RadioButton2.Checked = false;
            guna2RadioButton3.Checked = false;
            guna2RadioButton4.Checked = false;

            if (chamthi.DapAn.ContainsKey(index))
            {
                switch (chamthi.DapAn[index])
                {
                    case "A":
                        guna2RadioButton1.Checked = true;
                        break;
                    case "B":
                        guna2RadioButton2.Checked = true;
                        break;
                    case "C":
                        guna2RadioButton3.Checked = true;
                        break;
                    case "D":
                        guna2RadioButton4.Checked = true;
                        break;
                }
            }
            dangCapNhat = false;

            CapNhatNutCauHoi();
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!dangCapNhat)

            {
                LuuDapAn();
                CapNhatNutCauHoi();
            }
        }

        private void LuuDapAn()
        {
            string da = null;
            if (guna2RadioButton1.Checked)
            {
                da = "A";
            }
            else if (guna2RadioButton2.Checked)
            {
                da = "B";
            }
            else if (guna2RadioButton3.Checked)
            {
                da = "C";
            }
            else if (guna2RadioButton4.Checked)
            {
                da = "D";
            }
            chamthi.luuCauTraLoi(chiSo, da);
        }

        private void ChuyenCau(int index)
        {
            if (index >= 0 && index < chamthi.Danhsach.Count)
            {

                LuuDapAn();
                HienThiCau(index);
            }
        }

        private void DongHo_Tick(object sender, EventArgs e)
        {
            CapNhatDongHo();
            if (chamthi.HetGio)
            {
                dongHo.Stop();
                LuuDapAn();
                MessageBox.Show("Đã hết giờ! Bài thi sẽ được nộp tự động.", "Hết giờ",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chamthi.nopbai();
                Close();
            }
        }

        private void CapNhatDongHo()
        {
            TimeSpan conlai = chamthi.ThoiGianConLai();
            label3.Text = $"Còn lại: {conlai.Minutes:00}:{conlai.Seconds:00}";
            label3.ForeColor = (conlai.TotalSeconds <= 60.0) ? Color.Red : Color.Black;
        }

        private void Guna2Button14_Click(object sender, EventArgs e)
        {
            LuuDapAn();
            int chuaLam = chamthi.Danhsach.Count - chamthi.DapAn.Count;
            string msg = "Bạn có chắc muốn nộp bài?";
            if (chuaLam > 0)

            {
                msg += $"\n\nCòn {chuaLam} câu chưa làm.";
            }
            DialogResult r = MessageBox.Show(msg, "Xác nhận nộp bài", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (dongHo != null)
                {
                    dongHo.Stop();
                }
                chamthi.nopbai();
                Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!chamthi.DaNop && chamthi.MaBaiThi > 0)
            {
                DialogResult r = MessageBox.Show(
                    "Bạn đang làm bài. Nếu thoát bây giờ, bài thi sẽ bị hủy.\nTiếp tục thoát?",
                    "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (r != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (dongHo != null)
            {
                dongHo.Stop();
                dongHo.Dispose();

                dongHo = null;
            }
            base.OnFormClosing(e);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void Form_thi_Load_1(object sender, EventArgs e)
        {

        }
    }
}
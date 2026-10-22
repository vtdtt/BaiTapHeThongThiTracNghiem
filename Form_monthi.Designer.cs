using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HeThongThiTracNghiem
{
    partial class Form_monthi
    {
        private IContainer components = null;

        private Panel panel1;
        private Guna2Button guna2Button1;
        private Panel panel2;
        private Guna2TextBox guna2TextBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel3;
        private Panel panel6;
        private Panel panel4;
        private Panel panel5;
        private Label label1;
        private Label label2;
        private Panel panel7;
        private Label label3;
        private Panel panel8;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel13;
        private Panel panel12;
        private Panel panel15;
        private Panel panel14;
        private Panel panel10;

        private Label label8;
        private Label label7;
        private Panel panel17;
        private Panel panel16;
        private Panel panel11;
        private Label label15;
        private Label label10;
        private Label label9;
        private Label label16;
        private Label label11;
        private Label label12;
        private Label label17;
        private Label label14;
        private Label label13;
        private PictureBox pictureBox1;
        private Guna2CircleButton guna2CircleButton1;
        private Guna2CircleButton guna2CircleButton2;
        private Guna2CircleButton guna2CircleButton3;
        private Panel panel9;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form_monthi));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel3 = new Panel();
            panel9 = new Panel();
            label6 = new Label();
            guna2CircleButton1 = new Guna2CircleButton();
            label15 = new Label();
            panel13 = new Panel();
            label10 = new Label();
            panel12 = new Panel();
            label9 = new Label();
            label3 = new Label();
            panel6 = new Panel();
            panel4 = new Panel();
            guna2CircleButton2 = new Guna2CircleButton();
            label16 = new Label();
            label11 = new Label();
            panel15 = new Panel();
            label12 = new Label();
            panel14 = new Panel();
            panel10 = new Panel();
            label7 = new Label();
            label4 = new Label();
            panel7 = new Panel();
            panel5 = new Panel();
            guna2CircleButton3 = new Guna2CircleButton();
            label17 = new Label();
            panel17 = new Panel();
            label14 = new Label();
            panel16 = new Panel();
            label13 = new Label();
            panel11 = new Panel();
            label8 = new Label();
            label5 = new Label();
            panel8 = new Panel();
            guna2Button1 = new Guna2Button();
            panel2 = new Panel();
            guna2TextBox1 = new Guna2TextBox();
            panel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel9.SuspendLayout();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            panel4.SuspendLayout();
            panel15.SuspendLayout();
            panel10.SuspendLayout();
            panel5.SuspendLayout();
            panel17.SuspendLayout();
            panel16.SuspendLayout();
            panel11.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(guna2Button1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 426);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(94, 148, 255);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 47);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F);
            label2.Location = new Point(74, 31);
            label2.Name = "label2";
            label2.Size = new Size(212, 17);
            label2.TabIndex = 2;
            label2.Text = "Chọn môn thi để bắt đầu làm bài";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(72, 11);
            label1.Name = "label1";
            label1.Size = new Size(178, 20);
            label1.TabIndex = 1;
            label1.Text = "Danh sách chọn môn thi";
            label1.Click += label1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Controls.Add(panel5);
            flowLayoutPanel1.Location = new Point(9, 130);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(764, 293);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel9);
            panel3.Controls.Add(guna2CircleButton1);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(panel13);
            panel3.Controls.Add(panel12);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(panel6);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(239, 207);
            panel3.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(94, 148, 255);
            panel9.Controls.Add(label6);
            panel9.Location = new Point(182, 13);
            panel9.Name = "panel9";
            panel9.Size = new Size(54, 28);
            panel9.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(52, 152, 219);
            label6.Location = new Point(7, 4);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 6;
            label6.Text = "CNTT";
            label6.Click += label6_Click;
            // 
            // guna2CircleButton1
            // 
            guna2CircleButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButton1.Font = new Font("Segoe UI", 9F);
            guna2CircleButton1.ForeColor = Color.White;
            guna2CircleButton1.Image = (Image)resources.GetObject("guna2CircleButton1.Image");
            guna2CircleButton1.Location = new Point(188, 163);
            guna2CircleButton1.Name = "guna2CircleButton1";
            guna2CircleButton1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButton1.Size = new Size(31, 31);
            guna2CircleButton1.TabIndex = 14;
            guna2CircleButton1.TextAlign = HorizontalAlignment.Left;
            guna2CircleButton1.Click += guna2CircleButton1_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(19, 174);
            label15.Name = "label15";
            label15.Size = new Size(81, 20);
            label15.TabIndex = 13;
            label15.Text = "Bắt đầu thi";
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(94, 148, 255);
            panel13.Controls.Add(label10);
            panel13.Location = new Point(116, 104);
            panel13.Name = "panel13";
            panel13.Size = new Size(103, 30);
            panel13.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(42, 4);
            label10.Name = "label10";
            label10.Size = new Size(59, 20);
            label10.TabIndex = 8;
            label10.Text = "50 phút";
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(94, 148, 255);
            panel12.Controls.Add(label9);
            panel12.Location = new Point(19, 104);
            panel12.Name = "panel12";
            panel12.Size = new Size(91, 30);
            panel12.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 4);
            label9.Name = "label9";
            label9.Size = new Size(52, 20);
            label9.TabIndex = 7;
            label9.Text = "40 câu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 60);
            label3.Name = "label3";
            label3.Size = new Size(123, 20);
            label3.TabIndex = 3;
            label3.Text = "An Toàn Bảo Mật";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ActiveCaptionText;
            panel6.Location = new Point(19, 152);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 1);
            panel6.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(guna2CircleButton2);
            panel4.Controls.Add(label16);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(panel15);
            panel4.Controls.Add(panel14);
            panel4.Controls.Add(panel10);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(panel7);
            panel4.Location = new Point(248, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(236, 207);
            panel4.TabIndex = 1;
            // 
            // guna2CircleButton2
            // 
            guna2CircleButton2.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButton2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButton2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButton2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButton2.Font = new Font("Segoe UI", 9F);
            guna2CircleButton2.ForeColor = Color.White;
            guna2CircleButton2.Image = (Image)resources.GetObject("guna2CircleButton2.Image");
            guna2CircleButton2.Location = new Point(189, 163);
            guna2CircleButton2.Name = "guna2CircleButton2";
            guna2CircleButton2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButton2.Size = new Size(31, 31);
            guna2CircleButton2.TabIndex = 15;
            guna2CircleButton2.TextAlign = HorizontalAlignment.Left;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(23, 174);
            label16.Name = "label16";
            label16.Size = new Size(81, 20);
            label16.TabIndex = 14;
            label16.Text = "Bắt đầu thi";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(94, 148, 255);
            label11.Location = new Point(46, 108);
            label11.Name = "label11";
            label11.Size = new Size(52, 20);
            label11.TabIndex = 9;
            label11.Text = "40 câu";
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(94, 148, 255);
            panel15.Controls.Add(label12);
            panel15.Location = new Point(120, 104);
            panel15.Name = "panel15";
            panel15.Size = new Size(103, 30);
            panel15.TabIndex = 6;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(42, 4);
            label12.Name = "label12";
            label12.Size = new Size(59, 20);
            label12.TabIndex = 10;
            label12.Text = "50 phút";
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(94, 148, 255);
            panel14.Location = new Point(23, 104);
            panel14.Name = "panel14";
            panel14.Size = new Size(91, 30);
            panel14.TabIndex = 6;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(94, 148, 255);
            panel10.Controls.Add(label7);
            panel10.Location = new Point(176, 13);
            panel10.Name = "panel10";
            panel10.Size = new Size(54, 28);
            panel10.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 4);
            label7.Name = "label7";
            label7.Size = new Size(26, 20);
            label7.TabIndex = 7;
            label7.Text = "KT";
            label7.Click += label7_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 60);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 4;
            label4.Text = "Kinh Tế Chính Trị";
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ActiveCaptionText;
            panel7.Location = new Point(23, 152);
            panel7.Name = "panel7";
            panel7.Size = new Size(200, 1);
            panel7.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(guna2CircleButton3);
            panel5.Controls.Add(label17);
            panel5.Controls.Add(panel17);
            panel5.Controls.Add(panel16);
            panel5.Controls.Add(panel11);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(panel8);
            panel5.Location = new Point(490, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(240, 207);
            panel5.TabIndex = 2;
            // 
            // guna2CircleButton3
            // 
            guna2CircleButton3.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButton3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButton3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButton3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButton3.Font = new Font("Segoe UI", 9F);
            guna2CircleButton3.ForeColor = Color.White;
            guna2CircleButton3.Image = (Image)resources.GetObject("guna2CircleButton3.Image");
            guna2CircleButton3.Location = new Point(194, 163);
            guna2CircleButton3.Name = "guna2CircleButton3";
            guna2CircleButton3.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2CircleButton3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButton3.Size = new Size(31, 31);
            guna2CircleButton3.TabIndex = 16;
            guna2CircleButton3.TextAlign = HorizontalAlignment.Left;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(19, 174);
            label17.Name = "label17";
            label17.Size = new Size(81, 20);
            label17.TabIndex = 15;
            label17.Text = "Bắt đầu thi";
            // 
            // panel17
            // 
            panel17.BackColor = Color.FromArgb(94, 148, 255);
            panel17.Controls.Add(label14);
            panel17.Location = new Point(116, 104);
            panel17.Name = "panel17";
            panel17.Size = new Size(103, 30);
            panel17.TabIndex = 7;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(42, 4);
            label14.Name = "label14";
            label14.Size = new Size(59, 20);
            label14.TabIndex = 12;
            label14.Text = "50 phút";
            // 
            // panel16
            // 
            panel16.BackColor = Color.FromArgb(94, 148, 255);
            panel16.Controls.Add(label13);
            panel16.Location = new Point(19, 104);
            panel16.Name = "panel16";
            panel16.Size = new Size(91, 30);
            panel16.TabIndex = 7;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(33, 4);
            label13.Name = "label13";
            label13.Size = new Size(52, 20);
            label13.TabIndex = 11;
            label13.Text = "40 câu";
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(94, 148, 255);
            panel11.Controls.Add(label8);
            panel11.Location = new Point(182, 13);
            panel11.Name = "panel11";
            panel11.Size = new Size(55, 28);
            panel11.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 4);
            label8.Name = "label8";
            label8.Size = new Size(31, 20);
            label8.TabIndex = 8;
            label8.Text = "NN";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 60);
            label5.Name = "label5";
            label5.Size = new Size(176, 20);
            label5.TabIndex = 5;
            label5.Text = "Tiếng Anh Chuyên Ngành";
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.ActiveCaptionText;
            panel8.Location = new Point(19, 152);
            panel8.Name = "panel8";
            panel8.Size = new Size(200, 1);
            panel8.TabIndex = 1;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 13;
            guna2Button1.CustomizableEdges = customizableEdges4;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(693, 64);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2Button1.Size = new Size(71, 46);
            guna2Button1.TabIndex = 1;
            guna2Button1.Text = "Tất cả";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(guna2TextBox1);
            panel2.Location = new Point(6, 64);
            panel2.Name = "panel2";
            panel2.Size = new Size(672, 46);
            panel2.TabIndex = 0;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BorderRadius = 13;
            guna2TextBox1.CustomizableEdges = customizableEdges6;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(3, 4);
            guna2TextBox1.Margin = new Padding(3, 4, 3, 4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "Tìm kiếm môn thi...";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2TextBox1.Size = new Size(666, 38);
            guna2TextBox1.TabIndex = 0;
            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged_1;
            // 
            // Form_monthi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form_monthi";
            Text = "Form_monthi";
            Load += Form_monthi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);

        }
    }
}
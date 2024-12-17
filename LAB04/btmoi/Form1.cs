using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace btmoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Mở văn bản";
            openFile.Filter = "Text Files|*.txt|Rich Text Format|*.rtf"; // Lọc các file văn bản

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Tạo Form mới để hiển thị nội dung văn bản
                Form frmVanBan = new Form();
                frmVanBan.Text = "Văn bản - " + openFile.FileName;
                frmVanBan.Width = 800;
                frmVanBan.Height = 600;

                // Tạo RichTextBox để hiển thị văn bản
                RichTextBox rtbVanBan = new RichTextBox();
                rtbVanBan.Dock = DockStyle.Fill; // Chiếm toàn bộ form
                rtbVanBan.Font = new Font("Tahoma", 12);

                // Đọc nội dung file vào RichTextBox
                if (openFile.FilterIndex == 1) // Nếu là file .txt
                {
                    rtbVanBan.Text = System.IO.File.ReadAllText(openFile.FileName);
                }
                else if (openFile.FilterIndex == 2) // Nếu là file .rtf
                {
                    rtbVanBan.LoadFile(openFile.FileName, RichTextBoxStreamType.RichText);
                }

                // Thêm RichTextBox vào Form và hiển thị
                frmVanBan.Controls.Add(rtbVanBan);
                frmVanBan.MdiParent = this; // Mở trong cửa sổ cha (MDI)
                frmVanBan.Show();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = DateTime.Now.ToString();
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd:MM:yyyy");

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }
        //private void loadFont();
        //        {

        //            foreach(FontFamily in new InstalledFontCollection().Families)
        //            {
        //           cmbFont.Items.Add(FontFamily.Name);

        //            } cmbFont.SelectedItem = "Tahoma";
        //        }
        //private void loadSize()
        //{
        //    int[] sizeValues = new int[] {8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        //    cmbSize.ComboBox.DataSource = sizeValues;
        //    cmbSize.SetectedItem = 14;
        //}
        //     private void Form1_Load(object sender, EventArgs e)
        //{
        //loadFont();
        //loadSize();
        //.Font = new Font("Tahoma",14,FontStyle.Regular);
        //}




        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click_1);

            // Load danh sách Font
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                LoadFont.Items.Add(font.Name);
            }
            LoadFont.SelectedIndexChanged += LoadFont_SelectedIndexChanged;

            // Load danh sách Size
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                LoadSize.Items.Add(s);
            }
            LoadSize.SelectedIndexChanged += LoadSize_SelectedIndexChanged;
        }



        private void ApplyFontChange()
        {
            // Kiểm tra nếu có văn bản được chọn
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;

                // Lấy font từ ComboBox (ToolStripComboBox2 hoặc các combo khác)
                string fontName = LoadFont.SelectedItem?.ToString() ?? currentFont.FontFamily.Name;

                // Lấy size từ ComboBox
                float fontSize = float.TryParse(LoadSize.SelectedItem?.ToString(), out float size) ? size : currentFont.Size;

                // Giữ nguyên FontStyle hiện tại
                FontStyle fontStyle = currentFont.Style;

                // Áp dụng font mới
                richTextBox1.SelectionFont = new Font(fontName, fontSize, fontStyle);
            }
        }


        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily,
                                         float.Parse(LoadFont.Text));

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                LoadSize.ForeColor = fontDlg.Color;
                LoadSize.Font = fontDlg.Font;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void mởToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            // Thiết lập lại Font và Size mặc định
            richTextBox1.Font = new Font("Times New Roman", 12);

        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một Form mới
            Form frmVanBanMoi = new Form();
            frmVanBanMoi.Text = "Văn bản mới";
            frmVanBanMoi.Width = 800;
            frmVanBanMoi.Height = 600;

            // Tạo RichTextBox để soạn văn bản
            RichTextBox rtbVanBan = new RichTextBox();
            rtbVanBan.Dock = DockStyle.Fill; // Chiếm toàn bộ form
            rtbVanBan.Font = new Font("Tahoma", 14); // Font mặc định

            // Thêm RichTextBox vào Form
            frmVanBanMoi.Controls.Add(rtbVanBan);

            // Hiển thị form mới
            frmVanBanMoi.Show();

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dam1_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có văn bản đang được chọn
            if (richTextBox1.SelectionFont != null)
            {
                // Tạo font mới với kiểu in đậm
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Bold; // Toggle kiểu in đậm

                // Áp dụng font mới cho phần văn bản đã chọn
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }


        private void nghien_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có văn bản đang được chọn
            if (richTextBox1.SelectionFont != null)
            {
                // Tạo font mới với kiểu in nghiêng
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Italic; // Toggle kiểu in nghiêng

                // Áp dụng font mới cho phần văn bản đã chọn
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }


        private void gachchan_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có văn bản đang được chọn
            if (richTextBox1.SelectionFont != null)
            {
                // Tạo font mới với kiểu gạch chân
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Underline; // Toggle kiểu gạch chân

                // Áp dụng font mới cho phần văn bản đã chọn
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void toolStripComboBox2_Click_1(object sender, EventArgs e)
        {
            ApplyFontChange();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DinhDangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }
        private void UpdateFont()
        {
            if (richTextBox1.SelectionFont != null)
            {
                // Lấy font hiện tại của văn bản
                Font currentFont = richTextBox1.SelectionFont;

                // Lấy Font Family từ ComboBox
                string fontName = LoadFont.SelectedItem?.ToString() ?? currentFont.FontFamily.Name;

                // Lấy kích thước từ ComboBox
                float fontSize = float.TryParse(LoadSize.SelectedItem?.ToString(), out float size) ? size : currentFont.Size;

                // Áp dụng font mới với FontStyle hiện tại
                richTextBox1.SelectionFont = new Font(fontName, fontSize, currentFont.Style);
            }
        }


        private void LoadFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void LoadSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {

        }

        private void trong_Click(object sender, EventArgs e)
        {

        }

        private void trong1_Click(object sender, EventArgs e)
        {

        }

        private void btnTaoMoi_Click_1(object sender, EventArgs e)
        { MessageBox.Show("Sự kiện Tạo Mới đã được kích hoạt!");
            richTextBox1.Clear();

            // Thiết lập lại Font và Size mặc định
            richTextBox1.Font = new Font("Times New Roman", 12);

        }
        private string _currentFilePath = null; // Holds the file path


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                // First time saving the file: Show SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Lưu nội dung văn bản";
                saveFileDialog.Filter = "Rich Text Format|*.rtf"; // Allow only RTF format
                saveFileDialog.DefaultExt = "rtf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _currentFilePath = saveFileDialog.FileName; // Store file path
                    richTextBox1.SaveFile(_currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Văn bản đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Save to existing file path
                richTextBox1.SaveFile(_currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Văn bản đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}




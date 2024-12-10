using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt4
{

    public partial class FormNhanVien : Form
    {
        public delegate void TruyenDuLieu(NhanVien nhanVien);


        // Sự kiện sử dụng delegate
        public event TruyenDuLieu DuLieuTraVe;

        // Biến lưu trữ thông tin nhân viên hiện tại
        private NhanVien nhanVienHienTai;

     

        // Constructor nhận thông tin nhân viên để sửa
        public FormNhanVien(NhanVien nhanVien)
        {
            InitializeComponent();
            nhanVienHienTai = nhanVien;
            if (nhanVienHienTai != null)
            {
                txtMSNV.Text = nhanVienHienTai.MSNV;
                txtTenNV.Text = nhanVienHienTai.TenNV;
                txtLuongCB.Text = nhanVienHienTai.LuongCB.ToString();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo hoặc cập nhật thông tin nhân viên
                var nhanVienMoi = new NhanVien
                {
                    MSNV = txtMSNV.Text,
                    TenNV = txtTenNV.Text,
                    LuongCB = decimal.Parse(txtLuongCB.Text)
                };

                // Gửi dữ liệu qua delegate
                DuLieuTraVe?.Invoke(nhanVienMoi);

                // Đóng form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }

}

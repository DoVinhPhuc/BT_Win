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
       
    public partial class ListView : Form
    {
        public ListView()
        {
            InitializeComponent();
        }
        List<NhanVien> danhSachNhanVien = new List<NhanVien>();
        private void CapNhatListView()
        {
            listViewNhanVien.Items.Clear();
            foreach (var nv in danhSachNhanVien)
            {
                var item = new ListViewItem(nv.MSNV);
                item.SubItems.Add(nv.TenNV);
                item.SubItems.Add(nv.LuongCB.ToString("C"));
                listViewNhanVien.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Mở form nhân viên để thêm mới
            var nhanVien = new NhanVien(); // Hoặc sử dụng đối tượng đã có
            var formNhanVien = new FormNhanVien(nhanVien);
            // Gắn sự kiện delegate
            formNhanVien.DuLieuTraVe += (nhanVienMoi) =>
            {
                danhSachNhanVien.Add(nhanVienMoi); // Thêm vào danh sách
                CapNhatListView();                // Cập nhật ListView
            };

            formNhanVien.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (listViewNhanVien.SelectedItems.Count > 0)
            {
                // Lấy nhân viên được chọn
                var item = listViewNhanVien.SelectedItems[0];
                var nhanVienHienTai = danhSachNhanVien.FirstOrDefault(nv => nv.MSNV == item.SubItems[0].Text);

                if (nhanVienHienTai != null)
                {
                    // Mở form nhân viên để sửa
                    var formNhanVien = new FormNhanVien(nhanVienHienTai);

                    // Gắn sự kiện delegate
                    formNhanVien.DuLieuTraVe += (nhanVienMoi) =>
                    {
                        // Cập nhật thông tin nhân viên
                        nhanVienHienTai.TenNV = nhanVienMoi.TenNV;
                        nhanVienHienTai.LuongCB = nhanVienMoi.LuongCB;
                        CapNhatListView(); // Cập nhật lại ListView
                    };

                    formNhanVien.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listViewNhanVien.SelectedItems.Count > 0)
            {
                var item = listViewNhanVien.SelectedItems[0];
                var nhanVienCanXoa = danhSachNhanVien.FirstOrDefault(nv => nv.MSNV == item.SubItems[0].Text);

                if (nhanVienCanXoa != null)
                {
                    var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?",
                                                         "Xác nhận xóa",
                                                         MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        danhSachNhanVien.Remove(nhanVienCanXoa);
                        CapNhatListView();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào từ TextBox
            if (string.IsNullOrWhiteSpace(txt_lastName.Text) || string.IsNullOrWhiteSpace(txt_firstName.Text) || string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                MessageBox.Show("Vui lòng điền thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Tạo 1 dòng dữ liệu (ListViewItem)
            ListViewItem it = new ListViewItem(txt_lastName.Text);

            //Thêm các cột còn lại vào dòng it
            it.SubItems.Add(txt_firstName.Text);
            it.SubItems.Add(txt_phone.Text);

            //Đưa dòng dữ liệu lên listView
            listView1.Items.Add(it);

            // Xóa dữ liệu trong TextBox sau khi thêm
            txt_lastName.Clear();
            txt_firstName.Clear();
            txt_phone.Clear();
        }

        private void btn_repair_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Kiểm tra đầu vào
                if (string.IsNullOrWhiteSpace(txt_lastName.Text) || string.IsNullOrWhiteSpace(txt_firstName.Text) || string.IsNullOrWhiteSpace(txt_phone.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật giá trị cho dòng được chọn
                selectedItem.Text = txt_lastName.Text;
                selectedItem.SubItems[1].Text = txt_firstName.Text;
                selectedItem.SubItems[2].Text = txt_phone.Text;

                // Xóa TextBox sau khi sửa
                txt_lastName.Clear();
                txt_firstName.Clear();
                txt_phone.Clear();
                txt_lastName.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (listView1.SelectedItems.Count > 0)
            {
                // Xóa dòng được chọn
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_lastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_firstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

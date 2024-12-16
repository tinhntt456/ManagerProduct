using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerProduct
{
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            //Câu lệnh SQL để lấy dữ liệu
            string query = "SELECT idBill, nameBill, idUser FROM BILL";

            // Xóa các mục cũ trong ListView
            lvViewBill.Items.Clear();

            // Chuỗi kết nối tới cơ sở dữ liệu
            string connectionString = @"Data Source=LAPTOP-9GA3KES4\TINHNTTBC00466;Initial Catalog=ManageProduct;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Tạo một ListViewItem mới
                        ListViewItem item = new ListViewItem(reader["idBill"].ToString());
                        item.SubItems.Add(reader["nameBill"].ToString());
                        item.SubItems.Add(reader["idUser"].ToString());


                        // Thêm item vào ListView
                        lvViewBill.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void frmBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Mở form fraMain khi đăng nhập thành công
            frmManageProduct mainForm = new frmManageProduct();
            mainForm.Show();

            //II Ăn form đăng nhập(LoginForm)
            this.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // xoa
            txtIDBill.Clear();
            txtNameBill.Clear();
            txtIDUser.Clear();

            txtIDBill.Focus();
        }

        private void lvViewBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvViewBill.SelectedItems.Count > 0)
            {
                // Lấy mục được chọn
                var selectedItem = lvViewBill.SelectedItems[0];

                // Hiển thị dữ liệu lên các TextBox
                txtIDBill.Text = selectedItem.SubItems[0].Text;
                txtNameBill.Text = selectedItem.SubItems[1].Text;
                txtIDUser.Text = selectedItem.SubItems[2].Text;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvViewBill.SelectedItems.Count > 0)
            {
                // Lấy mục được chọn
                var selectedItem = lvViewBill.SelectedItems[0];

                // Cập nhật giá trị trong ListView
                selectedItem.SubItems[0].Text = txtIDBill.Text;
                selectedItem.SubItems[1].Text = txtNameBill.Text;
                selectedItem.SubItems[2].Text = txtIDUser.Text;

                // Cập nhật cơ sở dữ liệu
                string connectionString = @"Data Source=LAPTOP-9GA3KES4\TINHNTTBC00466;Initial Catalog=ManageProduct;Integrated Security=True";

                string query = " UPDATE Bill SET NameBill = @NameBill, IDUser = @IDUser WHERE IDBill = @IDBill";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Thêm tham số
                    command.Parameters.AddWithValue("@IDBill", txtIDBill.Text);
                    command.Parameters.AddWithValue("@NameBill", txtNameBill.Text);
                    command.Parameters.AddWithValue("@IDUser", txtIDUser.Text);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Chuỗi kết nối
            string connectionString = @"Data Source=LAPTOP-9GA3KES4\TINHNTTBC00466;Initial Catalog=ManageProduct;Integrated Security=True";

            // Câu lệnh SQL để thêm dữ liệu
            string query = "INSERT INTO Bill (IDBill, NameBill, IDUser) VALUES (@IDBill, @NameBill, @IDUser)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                // Thêm tham số
                command.Parameters.AddWithValue("@IDBill", txtIDBill.Text);
                command.Parameters.AddWithValue("@NameBill", txtNameBill.Text);
                command.Parameters.AddWithValue("@IDUser", txtIDUser.Text);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    // Thêm vào ListView
                    ListViewItem newItem = new ListViewItem(txtIDBill.Text);
                    newItem.SubItems.Add(txtNameBill.Text);
                    newItem.SubItems.Add(txtIDUser.Text);
                    lvViewBill.Items.Add(newItem);

                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa các TextBox sau khi thêm
                    txtIDBill.Clear();
                    txtNameBill.Clear();
                    txtIDUser.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvViewBill.SelectedItems.Count > 0)
            {
                // Lấy mục được chọn
                var selectedItem = lvViewBill.SelectedItems[0];
                string selectedIDBill = selectedItem.SubItems[0].Text;

                // Chuỗi kết nối
                string connectionString = @"Data Source=LAPTOP-9GA3KES4\TINHNTTBC00466;Initial Catalog=ManageProduct;Integrated Security=True";

                // Câu lệnh SQL để xóa
                string query = "DELETE FROM Bill WHERE IDBill = @IDBill";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Thêm tham số
                    command.Parameters.AddWithValue("@IDBill", selectedIDBill);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        // Xóa khỏi ListView
                        lvViewBill.Items.Remove(selectedItem);

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa tìm kiếm
            string searchKeyword = txtSearch.Text.Trim();

            // Chuỗi kết nối
            string connectionString = @"Data Source=LAPTOP-9GA3KES4\TINHNTTBC00466;Initial Catalog=ManageProduct;Integrated Security=True";

            // Câu lệnh SQL để tìm kiếm theo tên Bill
            string query = "SELECT IDBill, NameBill, IDUser FROM Bill WHERE NameBill LIKE @SearchKeyword";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                // Thêm tham số với ký tự đại diện %
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa các mục cũ trong ListView
                    lvViewBill.Items.Clear();

                    while (reader.Read())
                    {
                        // Tạo một ListViewItem mới
                        ListViewItem item = new ListViewItem(reader["IDBill"].ToString());
                        item.SubItems.Add(reader["NameBill"].ToString());
                        item.SubItems.Add(reader["IDUser"].ToString());

                        // Thêm item vào ListView
                        lvViewBill.Items.Add(item);
                    }

                    reader.Close();

                    // Hiển thị thông báo nếu không tìm thấy kết quả
                    if (lvViewBill.Items.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

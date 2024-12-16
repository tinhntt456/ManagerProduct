using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManagerProduct
{
    public partial class ManageCustomerForm : Form
    {
        public ManageCustomerForm()
        {
            InitializeComponent();
        }

        private void ManageCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            string query = "SELECT * FROM Customer";
            string connectionString = @"Data Source=LAPTOP-9GA3KES4\TINHNTTBC00466;Initial Catalog=HouseholdSalesManager;Integrated Security=True";

            lvCustomer.Items.Clear();
            


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Customer_ID"].ToString());
                        item.SubItems.Add(reader["Full_name"].ToString());
                        item.SubItems.Add(reader["Phone_number"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["Earn_points"].ToString());
                        item.SubItems.Add(reader["Sales"].ToString());

                        lvCustomer.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Customer (Customer_ID, Full_name, Phone_number, Address, Earn_points, Sales) VALUES (@Customer_ID, @Full_name, @Phone_number, @Address, @Earn_points, @Sales)";
            string connectionString = @"Data Source=LAPTOP-9GA3KES4\TINHNTTBC00466;Initial Catalog=HouseholdSalesManager;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Customer_ID", txtCustomer_ID.Text);
                command.Parameters.AddWithValue("@Full_name", txtFull_name.Text);
                command.Parameters.AddWithValue("@Phone_number", txtPhone_number.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@Earn_points", txtEarn_points.Text);
                command.Parameters.AddWithValue("@Sales", txtSales.Text);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomerData();

                    txtCustomer_ID.Clear();
                    txtFull_name.Clear();
                    txtPhone_number.Clear();
                    txtAddress.Clear();
                    txtEarn_points.Clear();
                    txtSales.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCustomer.SelectedItems.Count > 0)
            {
                string selectedCustomer_ID = lvCustomer.SelectedItems[0].SubItems[0].Text;
                string query = "DELETE FROM Customer WHERE Customer_ID = @Customer_ID";
                string connectionString = @"Data Source=LAPTOP-9GA3KES4\TINHNTTBC00466;Initial Catalog=HouseholdSalesManager;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@Customer_ID", selectedCustomer_ID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomerData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            string query = "SELECT Customer_ID, Full_name, Phone_number, Address, Earn_points, Sales FROM Customer WHERE Full_name LIKE @SearchKeyword";
            string connectionString = @"Data Source=LAPTOP-9GA3KES4\TINHNTTBC00466;Initial Catalog=HouseholdSalesManager;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Customer_ID"].ToString());
                        item.SubItems.Add(reader["Full_name"].ToString());
                        item.SubItems.Add(reader["Phone_number"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["Earn_points"].ToString());
                        item.SubItems.Add(reader["Sales"].ToString());

                        lvCustomer.Items.Add(item);
                    }

                    reader.Close();

                    if (lvCustomer.Items.Count == 0)
                    {
                        MessageBox.Show("No matching customers found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        lvCustomer.Items.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            {
                // Kiểm tra nếu `txtIDCustomer` không rỗng
                string customerId = txtCustomer_ID.Text;

                if (!string.IsNullOrEmpty(customerId))
                {
                    // Logic tùy chỉnh khi quay lại
                    MessageBox.Show($"Quay lại trạng thái của khách hàng ID: {customerId}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ví dụ: Đóng Form hiện tại
                    this.Close();
                }
                else
                {
                    // Hiển thị thông báo nếu chưa nhập ID khách hàng
                    MessageBox.Show("Không tìm thấy thông tin khách hàng để quay lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
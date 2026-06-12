namespace Democode_DB
{
    public partial class frmManageCategories : Form
    {
        private ManageCategories manageCategories = new ManageCategories();

        public frmManageCategories()
        {
            InitializeComponent();
        }

        private void frmManageCategories_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                dgvCategories.DataSource = null;
                dgvCategories.DataSource = manageCategories.GetCategories();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading categories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            txtCategoryID.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            txtCategoryName.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                {
                    MessageBox.Show("Category Name is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                    return;
                }

                Category category = new Category
                {
                    CategoryName = txtCategoryName.Text.Trim()
                };

                manageCategories.InsertCategory(category);
                MessageBox.Show("Category inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inserting category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
                {
                    MessageBox.Show("Please select a category to update!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                {
                    MessageBox.Show("Category Name is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                    return;
                }

                Category category = new Category
                {
                    CategoryID = int.Parse(txtCategoryID.Text),
                    CategoryName = txtCategoryName.Text.Trim()
                };

                manageCategories.UpdateCategory(category);
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error updating category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
                {
                    MessageBox.Show("Please select a category to delete!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete category '{txtCategoryName.Text}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Category category = new Category
                    {
                        CategoryID = int.Parse(txtCategoryID.Text)
                    };

                    manageCategories.DeleteCategory(category);
                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error deleting category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                    txtCategoryID.Text = row.Cells["CategoryID"].Value?.ToString() ?? string.Empty;
                    txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error selecting category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

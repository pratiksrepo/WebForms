using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Crudin.net
{
    public partial class Crud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO newUsers (Name, Email, Age) VALUES (@Name, @Email, @Age)", connection);
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text.Trim()));

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    lblMessage.Text = "User inserted successfully!";
                    ClearFields();
                }
                else
                {
                    lblMessage.Text = "Failed to insert user.";
                }
            }
        }

        private void ClearFields()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAge.Text = string.Empty;
        }

        protected void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Name, Email, Age FROM newUsers", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            BindGridView();
        }


        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvUsers.Rows[e.RowIndex];
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            TextBox txtName = row.FindControl("txtEditName") as TextBox;
            TextBox txtEmail = row.FindControl("txtEditEmail") as TextBox;
            TextBox txtAge = row.FindControl("txtEditAge") as TextBox;

            UpdateUser(userId, txtName.Text.Trim(), txtEmail.Text.Trim(), Convert.ToInt32(txtAge.Text.Trim()));

            gvUsers.EditIndex = -1;
            BindGridView();
        }

        protected void UpdateUser(int userId, string newName, string newEmail, int newAge)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE newUsers SET Name = @Name, Email = @Email, Age = @Age WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", userId);
                cmd.Parameters.AddWithValue("@Name", newName);
                cmd.Parameters.AddWithValue("@Email", newEmail);
                cmd.Parameters.AddWithValue("@Age", newAge);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    lblMessage.Text = "User updated successfully!";
                }
                else
                {
                    lblMessage.Text = "Failed to update user.";
                }
            }
        }
        protected void gvUsers_RowDeleting(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            BindGridView(); 
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Values["ID"]);

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM newUsers WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", userId);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();


                gvUsers.EditIndex = -1;
                BindGridView();
            }
        }

    }
}

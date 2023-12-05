using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crudin.net
{
    public partial class GridEvents : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }
        protected void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Name, Email FROM Basiccrud", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            InsertData(name, email);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text.Trim());
            string newName = txtNewName.Text.Trim();
            string newEmail = txtNewEmail.Text.Trim();
            UpdateData(id, newName, newEmail);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int idToDelete = Convert.ToInt32(txtDeleteID.Text.Trim());
            DeleteData(idToDelete);
        }

        protected void InsertData(string name, string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Basiccrud (Name, Email) VALUES (@Name, @Email)", connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblMessage.Text = "User inserted successfully!";
                    
                }
                else
                {
                    lblMessage.Text = "User inserted not successfully!";
                   
                }
            }
        }

        protected void UpdateData(int id, string newName, string newEmail)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Basiccrud SET Name = @Name, Email = @Email WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", newName);
                cmd.Parameters.AddWithValue("@Email", newEmail);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }

        protected void DeleteData(int idToDelete)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Basiccrud WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", idToDelete);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

            }
        }

    }
}
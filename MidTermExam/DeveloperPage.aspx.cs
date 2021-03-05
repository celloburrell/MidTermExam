using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace MidTermExam
{
	public partial class DeveloperPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString);
				string query = "select BugID, Subject from Bugs where AssignedTo=@a AND Status='Assigned'";
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@a", Session["UserId"]);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);
				foreach (DataRow dr in dt.Rows)
				{
					ddlBugs.Items.Add(new ListItem(dr["Subject"].ToString(), dr["BugID"].ToString()));
				}
				if (ddlBugs.Items.Count == 1) {
					conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString);
					query = "select * from Bugs where BugID=@b";
					cmd = new SqlCommand(query, conn);
					cmd.Parameters.AddWithValue("@b", ddlBugs.SelectedValue);
					da = new SqlDataAdapter(cmd);
					dt = new DataTable();
					da.Fill(dt);
					gvOutput.DataSource = dt;
					gvOutput.DataBind();
				}
			}
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString);
			string query = "select * from Bugs where BugID=@b";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@b", ddlBugs.SelectedValue);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			gvOutput.DataSource = dt;
			gvOutput.DataBind();
		}

		protected void btnFixed_Click(object sender, EventArgs e)
		{
			if (!tbxChanges.Text.Equals(null))
			{
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString);
				string query = "update Bugs set Status = 'Completed', Changes = @c where BugID = @b";
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@c", tbxChanges.Text);
				cmd.Parameters.AddWithValue("@b", ddlBugs.SelectedValue);
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}
	}
}
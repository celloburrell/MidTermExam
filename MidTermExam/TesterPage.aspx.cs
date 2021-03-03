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
	public partial class TesterPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ddlPriority.Items.Add(new ListItem("High", "High"));
				ddlPriority.Items.Add(new ListItem("Medium", "Medium"));
				ddlPriority.Items.Add(new ListItem("Low", "Low"));
			}
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			//int bugID = 1;
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString);
			//string query = "select BugID from Bugs";
			//SqlCommand cmd = new SqlCommand(query, conn);
			//SqlDataAdapter da = new SqlDataAdapter(cmd);
			//DataTable dt = new DataTable();
			//da.Fill(dt);
			//if (dt.Rows.Equals(null)) {
			//	foreach (DataRow dr in dt.Rows)
			//	{
			//		bugID = Int32.Parse(dr["BugID"].ToString()) + 1;
			//	}
			//}

			string query = "insert into Bugs (EnteredBy, Subject, Priority, Description, Status) VALUES (@e, @s, @p, @d, @st)";
			SqlCommand cmd = new SqlCommand(query, conn);
			//cmd.Parameters.AddWithValue("@b", bugID);
			cmd.Parameters.AddWithValue("@e", Session["UserId"]);
			cmd.Parameters.AddWithValue("@s", tbxSubject.Text);
			cmd.Parameters.AddWithValue("@p", ddlPriority.SelectedValue);
			cmd.Parameters.AddWithValue("@d", tbxDescription.Text);
			cmd.Parameters.AddWithValue("@st", "Open");
			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();
		}
	}
}
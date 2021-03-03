using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MidTermExam
{
	public partial class LoginPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString);
			string query = "select UserID, Password, Type from Users where login = @l";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@l", tbxUsername.Text);
			conn.Open();
			SqlDataReader rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				//How to compute a password to a hashed password (use for admin page)
				SHA1 sha1 = new SHA1CryptoServiceProvider();
				sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(tbxPassword.Text));
				byte[] result = sha1.Hash;
				StringBuilder strBuilder = new StringBuilder();
				for (int i = 0; i < result.Length; i++)
				{
					strBuilder.Append(result[i].ToString("x2"));
				}
				//Response.Write(strBuilder.ToString());
				if (strBuilder.ToString().Equals(rdr["Password"].ToString()))
				{
					Session["UserId"] = rdr["UserID"];
					if (rdr["Type"].Equals("Administrator")) {
						Response.Redirect("AdministratorPage.aspx");
					}
					else if (rdr["Type"].Equals("Developer")) {
						Response.Redirect("DeveloperPage.aspx");
					}
					else if (rdr["Type"].Equals("Manager"))
					{
						Response.Redirect("ManagerPage.aspx");
					}
					else if (rdr["Type"].Equals("Tester"))
					{
						Response.Redirect("TesterPage.aspx");
					}
				}
			} 
			rdr.Close();
			conn.Close();
		}
	}
}
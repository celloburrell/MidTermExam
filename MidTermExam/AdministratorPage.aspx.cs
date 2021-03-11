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
	public partial class AdministratorPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ddlType.Items.Add(new ListItem("Administrator", "Administrator"));
				ddlType.Items.Add(new ListItem("Developer", "Developer"));
				ddlType.Items.Add(new ListItem("Manager", "Manager"));
				ddlType.Items.Add(new ListItem("Tester", "Tester"));
			}
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			bool login = true;
			bool passwordLength = true;
			bool passwordNumber = false;
			bool passwordLetter = false;
			int userIDNumber= -1;
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString);
			string query = "select Login, UserID from Users";
			SqlCommand cmd = new SqlCommand(query, conn);
			conn.Open();
			SqlDataReader rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				if (rdr["Login"].ToString().Equals(tbxLogin.Text)) {
					login = false;
				}
				if (Int32.Parse(rdr["UserID"].ToString()) > userIDNumber) {
					userIDNumber = Int32.Parse(rdr["UserID"].ToString());
				}
			}
			rdr.Close();
			conn.Close();
			userIDNumber++;
			if (tbxPassword.Text.Count() < 8) {
				passwordLength = false;
				Response.Write("Password must be at least 8 character long." + "<br/><br/>");
			}
			else if (tbxPassword.Text.Any(char.IsDigit)) {
				passwordNumber = true;
			}
			for(int i = 0; i < tbxPassword.Text.Length; i++) {
				if (char.IsLetter(tbxPassword.Text[i]))
				{
					passwordLetter = true;
				}
			}
			if (login && passwordLength && passwordLetter && passwordNumber) {
				SHA1 sha1 = new SHA1CryptoServiceProvider();
				sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(tbxPassword.Text));
				byte[] result = sha1.Hash;
				StringBuilder strBuilder = new StringBuilder();
				for (int i = 0; i < result.Length; i++)
				{
					strBuilder.Append(result[i].ToString("x2"));
				}
				query = "insert into Users (UserID, Name, Login, Password, Type) VALUES (@u, @n, @l, @p, @t)";
				cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@u", userIDNumber);
				cmd.Parameters.AddWithValue("@n", tbxName.Text);
				cmd.Parameters.AddWithValue("@l", tbxLogin.Text);
				cmd.Parameters.AddWithValue("@p", strBuilder.ToString());
				cmd.Parameters.AddWithValue("@t", ddlType.SelectedValue);
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}
	}
}
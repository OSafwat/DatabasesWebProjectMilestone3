using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabasesWebProjectMilestone3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_function(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string mobileNo = mobile_number.Text;
            string pass = password.Text;

            string loginQuery = "SELECT dbo.AccountLoginValidation(@MobileNo, @password)";
            SqlCommand loginFunction = new SqlCommand(loginQuery, conn);

            loginFunction.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));
            loginFunction.Parameters.Add(new SqlParameter("@password", pass));


            conn.Open();
            bool success = (bool)loginFunction.ExecuteScalar();
            conn.Close();


            if (success)
            {
                Response.Redirect($"Customer.aspx?mobileNo={Server.UrlEncode(mobileNo)}");

            } else
            {
                if (pass.Equals("admin"))
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    Response.Write("Login Failed");
                }
            }
        }
    }
}
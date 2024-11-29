using System;
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

        protected void login_button(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string mobileNum = mobile_number.Text;
            string pass = password.Text;
            SqlCommand loginproc = new SqlCommand("AccountLoginValidation", conn);
            loginproc.Parameters.Add(new SqlParameter("@MobileNo", mobileNum));
            loginproc.Parameters.Add(new SqlParameter("@password", pass));

            SqlParameter success = loginproc.Parameters.Add("@success", SqlDbType.Int);
        }
    }
}
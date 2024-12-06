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
using Microsoft.SqlServer.Server;

namespace DatabasesWebProjectMilestone3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populate_account_type_dropdown();
            }
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
            bool success;
            try
            {
                conn.Open();
                bool temp = (bool)loginFunction.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Response.Write("An error has occurred due to invalid input. Please put in a proper input and try again.");
                conn.Close();
                return;
            }
            success = (bool)loginFunction.ExecuteScalar();
            conn.Close();
            if (success)
            {
                Response.Redirect($"Customer.aspx?mobileNo={Server.UrlEncode(mobileNo)}");

            } else
            {
                if (pass.Equals("Admin") && mobileNo.Equals("AdminIAmAdminAdmin"))
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    Response.Write("Login failed, mobile number or password is incorrect.");
                }
            }

        }

        protected void create_account_function(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string password = password_input.Text;
            string account_type = account_type_input.SelectedValue;
            string mobile_number = generate_mobile_number();
            string national_ID = national_id_input_2.Text;

            string nationalIDVerification = "SELECT COUNT(*) FROM Customer_profile WHERE nationalID = " + national_ID + ";";
            SqlCommand nationalIDVerificationCommand = new SqlCommand(nationalIDVerification, conn);

            conn.Open();

            bool result = (int)nationalIDVerificationCommand.ExecuteScalar() == 0;

            conn.Close();

            if (result)
            {
                Response.Write("This national ID does not exist. Please sign up to create a new profile.");
                return;
            }




            string createAccountQuery = "INSERT INTO Customer_Account VALUES ('" + mobile_number + "', '" + password + "', 0.0, '" + account_type + "', GETDATE(), 'Active', 0, " + national_ID + ")";
            SqlCommand createAccount = new SqlCommand(createAccountQuery, conn);
            conn.Open();
            try
            {
                createAccount.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                Response.Write("An error has occurred! Here is the error message: " + e1.Message);
                conn.Close();
                return;
            }
            Response.Write("Success!");
            Response.Redirect($"Customer.aspx?mobileNo={Server.UrlEncode(mobile_number)}");
            conn.Close();
        }

        protected void signup_function(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string nationalID = national_id_input.Text;
            string first_name = first_name_input.Text;
            string last_name = last_name_input.Text;
            string email = email_input.Text;
            string date_of_birth = date_of_birth_input.Text;
            string mobile_number = generate_mobile_number();

            if (!verify_date(date_of_birth))
            {
                return;
            }
            
            if (!email.Contains("@"))
            {
                Response.Write("Invalid email, please try again.");
                return;
            }

            string nationalIDVerification = "SELECT COUNT(*) FROM Customer_profile WHERE nationalID = " + nationalID + ";";
            SqlCommand nationalIDVerificationCommand = new SqlCommand(nationalIDVerification, conn);

            conn.Open();

            bool result = (int)nationalIDVerificationCommand.ExecuteScalar() == 0;

            conn.Close();

            if (!result)
            {
                Response.Write("This national ID already exists in our database, please create an account instead of " +
                    "signing up again, or try a different national ID.");
                return;
            }

            string signupQuery = "INSERT INTO Customer_profile VALUES (" + nationalID + ", '" + first_name + "', '" + last_name + "', '" + email + "', '" + date_of_birth + "');";
            SqlCommand signupCommand = new SqlCommand(signupQuery, conn);

            conn.Open();
            try
            {
                signupCommand.ExecuteNonQuery();
            } catch (Exception e1)
            {
                Response.Write("An error has occurred! Here is the error message: " + e1.Message);
                conn.Close();
                return;
            }
            Response.Write("Success!");
            conn.Close();
        }

        protected void populate_account_type_dropdown()
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string optionsQuery = "Select DISTINCT(account_type) As 'Account Types' FROM Customer_Account;";
            SqlCommand options = new SqlCommand(optionsQuery, conn);

            conn.Open();


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(options);
            da.Fill(dt);

            account_type_input.DataSource = dt;
            account_type_input.DataTextField = "Account Types"; 
            account_type_input.DataValueField = "Account Types"; 
            account_type_input.DataBind();


            conn.Close();

        }

        protected bool verify_date(String date_of_birth)
        {
            string format = "yyyy-MM-dd";
            DateTime parsedDate;
            if (!DateTime.TryParseExact(date_of_birth, format, null, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                Response.Write("Invalid date of birth, please try again.");
                return false;
            }
            return true;
        }

        protected String generate_mobile_number()
        {
            bool result = false;
            String mobileNumber = "";
            while (!result)
            {

                //starting string generation

                Random rand = new Random();


                int firstDigit = rand.Next(1, 10);


                string remainingDigits = string.Empty;
                for (int i = 0; i < 10; i++)
                {
                    remainingDigits += rand.Next(0, 10).ToString();
                }


                mobileNumber = firstDigit.ToString() + remainingDigits;

                //string generation done

                //starting string verification

                String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                string verificationQuery = "SELECT Count(*) FROM Customer_Account WHERE mobileNo='" + mobileNumber + "';";
                SqlCommand verification = new SqlCommand(verificationQuery, conn);

                conn.Open();
                result = (int)verification.ExecuteScalar() == 0;
                conn.Close();

                //string verification done
            }
            return mobileNumber;
        }
    }
}
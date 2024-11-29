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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void customer_data_view(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM dbo.allCustomerAccounts";
            SqlCommand customerAccountsView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(customerAccountsView);
            DataTable customerData = new DataTable();
            viewAdapter.Fill(customerData);

            customer_account_data.DataSource = customerData;
            customer_account_data.DataBind();
            conn.Close();
        }

        //PhysicalStoreVouchers

        protected void physical_shop_data_retrieval(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM dbo.PhysicalStoreVouchers";
            SqlCommand physicalStoreVouchersView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(physicalStoreVouchersView);
            DataTable physicalStoreData = new DataTable();
            viewAdapter.Fill(physicalStoreData);

            physical_shop_voucher_data.DataSource = physicalStoreData;
            physical_shop_voucher_data.DataBind();
            conn.Close();
        }

        protected void resolved_tickets_data_retrieval(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM dbo.allResolvedTickets";
            SqlCommand resolvedTicketsView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(resolvedTicketsView);
            DataTable resolvedTicketsData = new DataTable();
            viewAdapter.Fill(resolvedTicketsData);

            resolved_tickets_data.DataSource = resolvedTicketsData;
            resolved_tickets_data.DataBind();
            conn.Close();
        }
        //Account_Plan
        protected void accounts_service_plans_data_retrieval(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Account_Plan";
            SqlCommand account_plan_proc = new SqlCommand(procQuery, conn);

            account_plan_proc.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataAdapter procAdapter = new SqlDataAdapter(account_plan_proc);
            DataTable accountsPlanData = new DataTable();
            procAdapter.Fill(accountsPlanData);

            account_plan_data.DataSource = accountsPlanData;
            account_plan_data.DataBind();
            conn.Close();
        }

        protected void account_plan_date_retrieval(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string functionQuery = "SELECT * FROM dbo.Account_Plan_date(@Subscription_Date, @Plan_id)";
            SqlCommand account_plan_date_function = new SqlCommand(functionQuery, conn);

            int servicePlanId = Int16.Parse(account_plan_date_service_plan_textbox.Text);
            string date = account_plan_date_date_textbox.Text;

            account_plan_date_function.Parameters.Add(new SqlParameter("@Subscription_Date", date));
            account_plan_date_function.Parameters.Add(new SqlParameter("@Plan_id", servicePlanId));
            
            

            conn.Open();
            SqlDataAdapter functionAdapter = new SqlDataAdapter(account_plan_date_function);
            DataTable accountsPlanDateData = new DataTable();
            functionAdapter.Fill(accountsPlanDateData);

            account_plan_date_data.DataSource = accountsPlanDateData;
            account_plan_date_data.DataBind();
            conn.Close();
        }

        /* c) Retrieve the total usage of the input account on each
            subscribed plan from a given input date.
            i) Name: Account_Usage_Plan
            ii) Type: Table Valued Function
            iii) Input: MobileNo char(11), from_date date
            iv) output : Table includes (planID, total data
            consumed, total minutes used, and total SMS).
            @MobileNo CHAR(11), @from_date DATE
 */
        protected void account_usage_plan_retrieval(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string functionQuery = "SELECT * FROM dbo.Account_Usage_Plan(@MobileNo, @from_date)";
            SqlCommand account_usage_plan_function = new SqlCommand(functionQuery, conn);

            string mobileNo = account_usage_plan_mobile_number_textbox.Text;
            string date = account_usage_plan_date_textbox.Text;

            account_usage_plan_function.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));
            account_usage_plan_function.Parameters.Add(new SqlParameter("@from_date", date));



            conn.Open();
            SqlDataAdapter functionAdapter = new SqlDataAdapter(account_usage_plan_function);
            DataTable accountsPlanDateData = new DataTable();
            functionAdapter.Fill(accountsPlanDateData);

            account_usage_plan_data.DataSource = accountsPlanDateData;
            account_usage_plan_data.DataBind();
            conn.Close();
        }
    }
}
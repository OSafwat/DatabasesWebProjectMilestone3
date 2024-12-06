using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DatabasesWebProjectMilestone3
{
   
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mobileNo = Request.QueryString["mobileNo"];
                HiddenFieldMobileNo.Value = mobileNo;

                string nationalIDQuery = "SELECT nationalID FROM Customer_Account WHERE mobileNo = '" + mobileNo +"'";
                
                String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                
                SqlCommand cmd = new SqlCommand(nationalIDQuery, conn);
                
                conn.Open();

                string nationalID = "" + cmd.ExecuteScalar();
                string nameQuery = "SELECT first_name + ' ' + last_name FROM Customer_profile WHERE nationalID = " + nationalID + ";";

                HiddenFieldNationalID.Value = nationalID;

                cmd = new SqlCommand(nameQuery, conn);

                string name = (String)cmd.ExecuteScalar();
                customer_intro_label.Text = $"Welcome, {name}, {nationalID}!";

                conn.Close();
            }
        }

        protected void service_plan_view(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM dbo.allServicePlans";
            SqlCommand servicePlansView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(servicePlansView);
            DataTable servicePlanData = new DataTable();
            viewAdapter.Fill(servicePlanData);

            service_plan_data.DataSource = servicePlanData;
            service_plan_data.DataBind();
            conn.Close();
        }

        protected void consumption_display(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string funcQuery = "SELECT * FROM dbo.Consumption";
            SqlCommand consumptionFunction = new SqlCommand(funcQuery, conn);

            SqlParameter plan_name = new SqlParameter("@Plan_Name", consumption_display_plan_name_input.Text);
            SqlParameter start_date = new SqlParameter("@start_date", consumption_display_start_date_input);
            SqlParameter end_date = new SqlParameter("@end_date", consumption_display_end_date_input);

            consumptionFunction.Parameters.Add(plan_name);
            consumptionFunction.Parameters.Add(start_date);
            consumptionFunction.Parameters.Add(end_date);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(consumptionFunction);
            DataTable customerData = new DataTable();
            viewAdapter.Fill(customerData);

            consumption_data.DataSource = customerData;
            consumption_data.DataBind();
            conn.Close();
        }

        protected void unsubscribed_plans_view(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string procQuery = "Unsubscribed_Plans";
            SqlCommand unsubscribedPlansProc = new SqlCommand(procQuery, conn);

            unsubscribedPlansProc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));

            unsubscribedPlansProc.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(unsubscribedPlansProc);
            DataTable unsubscribedPlansData = new DataTable();
            viewAdapter.Fill(unsubscribedPlansData);

            unsubscribed_plans_data.DataSource = unsubscribedPlansData;
            unsubscribed_plans_data.DataBind();
            conn.Close();
        }

        protected void active_plans_usage_data_retrieval(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string funcQuery = "Select * FROM dbo.Usage_Plan_CurrentMonth(@MobileNo)";
            SqlCommand activePlansUsageFunc = new SqlCommand(funcQuery, conn);

            activePlansUsageFunc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(activePlansUsageFunc);
            DataTable activePlansConsumptionData = new DataTable();
            viewAdapter.Fill(activePlansConsumptionData);

            active_plans_usage_data.DataSource = activePlansConsumptionData;
            active_plans_usage_data.DataBind();
            conn.Close();
        }

        protected void cashback_customer_wallet_data_retrieval(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string funcQuery = "SELECT * FROM dbo.Cashback_Wallet_Customer(@NationalID)";
            SqlCommand cashbackCustomerWalletFunc = new SqlCommand(funcQuery, conn);
            Int64 nationalID = Int64.Parse(HiddenFieldNationalID.Value);
            cashbackCustomerWalletFunc.Parameters.Add(new SqlParameter("@NationalID", nationalID));

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(cashbackCustomerWalletFunc);
            DataTable cashbackCustomerWalletData= new DataTable();
            viewAdapter.Fill(cashbackCustomerWalletData);

            cashback_customer_wallet_data.DataSource = cashbackCustomerWalletData;
            cashback_customer_wallet_data.DataBind();
            conn.Close();
        }

        protected void active_benefits_view(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM dbo.allBenefits";
            SqlCommand allBenefitsView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(allBenefitsView);
            DataTable allBenefitsData = new DataTable();
            viewAdapter.Fill(allBenefitsData);

            active_benefits_data.DataSource = allBenefitsData;
            active_benefits_data.DataBind();
            conn.Close();
        }



        protected void ticket_amount_customer(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Ticket_Account_Customer";
            SqlCommand ticketAmountCustomerProc = new SqlCommand(procQuery, conn);

            Int64 nationalID = Int64.Parse(HiddenFieldNationalID.Value);

            ticketAmountCustomerProc.Parameters.Add(new SqlParameter("@NationalID", nationalID));

            ticketAmountCustomerProc.CommandType = CommandType.StoredProcedure;

            SqlParameter ticketNumber = new SqlParameter("@SupportTickets", SqlDbType.Int);
            ticketNumber.Direction = ParameterDirection.Output;
            ticketAmountCustomerProc.Parameters.Add(ticketNumber);

            conn.Open();

            ticketAmountCustomerProc.ExecuteNonQuery();
            tickets_amount_customer_result.Text = "Result: " + ticketNumber.Value;

            conn.Close();
        }


        protected void account_highest_voucher(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Account_Highest_Voucher";
            SqlCommand accountHighestVoucherProc = new SqlCommand(procQuery, conn);

            accountHighestVoucherProc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));

            accountHighestVoucherProc.CommandType = CommandType.StoredProcedure;

            Response.Write(HiddenFieldMobileNo.Value);

            SqlParameter voucherID = new SqlParameter("@VoucherID", SqlDbType.Int);
            voucherID.Direction = ParameterDirection.Output;
            accountHighestVoucherProc.Parameters.Add(voucherID);

            conn.Open();

            accountHighestVoucherProc.ExecuteNonQuery();
            account_highest_voucher_result.Text = "Result: " + voucherID.Value;

            conn.Close();
        }


        protected void remaining_plan_amount(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string funcQuery = "SELECT * FROM Remaining_plan_amount(@MobileNo, @plan_name)";
            SqlCommand remainingPlanAmountFunc = new SqlCommand(funcQuery, conn);
            remainingPlanAmountFunc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));
            remainingPlanAmountFunc.Parameters.Add(new SqlParameter("@plan_name", remaining_plan_amount_plan_name_input.Text));
            conn.Open();

            int result = (int)remainingPlanAmountFunc.ExecuteNonQuery();
            remaining_plan_amount_result.Text = "Result: " + result;

            conn.Close();
        }


        protected void extra_plan_amount(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string funcQuery = "SELECT * FROM Extra_plan_amount(@MobileNo, @plan_name)";
            SqlCommand extraPlanAmountFunc = new SqlCommand(funcQuery, conn);
            extraPlanAmountFunc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));
            extraPlanAmountFunc.Parameters.Add(new SqlParameter("@plan_name", extra_plan_amount_plan_name_input.Text));
            conn.Open();

            int result = (int)extraPlanAmountFunc.ExecuteNonQuery();
            extra_plan_amount_result.Text = "Result: " + result;

            conn.Close();
        }


        protected void top_successful_payments(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Top_Successful_Payments";
            SqlCommand topSuccessfulPaymentsProc = new SqlCommand(procQuery, conn);

            topSuccessfulPaymentsProc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));

            topSuccessfulPaymentsProc.CommandType = CommandType.StoredProcedure;

            conn.Open();

            SqlDataAdapter viewAdapter = new SqlDataAdapter(topSuccessfulPaymentsProc);
            DataTable topSuccessfulPaymentsData = new DataTable();
            viewAdapter.Fill(topSuccessfulPaymentsData);

            top_successful_payments_data.DataSource = topSuccessfulPaymentsData;
            top_successful_payments_data.DataBind();

            conn.Close();
        }


        protected void shop_data_retrieval(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM dbo.allShops";
            SqlCommand allShopsView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(allShopsView);
            DataTable all_StoreData = new DataTable();
            viewAdapter.Fill(all_StoreData);

            all_shop_data.DataSource = all_StoreData;
            all_shop_data.DataBind();
            conn.Close();
        }



        protected void subscribed_plans_months(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string funcQuery = "SELECT * FROM dbo.Subscribed_plans_5_Months(@MobileNo)";
            SqlCommand subscribedPlanMonthsFunc = new SqlCommand(funcQuery, conn);

            subscribedPlanMonthsFunc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));

            conn.Open();

            SqlDataAdapter viewAdapter = new SqlDataAdapter(subscribedPlanMonthsFunc);
            DataTable subscribedPlansMonthsData = new DataTable();
            viewAdapter.Fill(subscribedPlansMonthsData);

            subscribed_plans_months_data.DataSource = subscribedPlansMonthsData;
            subscribed_plans_months_data.DataBind();

            conn.Close();
        }


        protected void initiate_plan_payment(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Initiate_plan_payment";
            SqlCommand initiatePlanPaymentProc = new SqlCommand(procQuery, conn);

            initiatePlanPaymentProc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));
            initiatePlanPaymentProc.Parameters.Add(new SqlParameter("@amount", Double.Parse(initiate_plan_payment_amount_input.Text)));
            initiatePlanPaymentProc.Parameters.Add(new SqlParameter("@payment_method", initiate_plan_payment_payment_method_input.Text));
            initiatePlanPaymentProc.Parameters.Add(new SqlParameter("@plan_id", initiate_plan_payment_plan_ID_input.Text));

            initiatePlanPaymentProc.CommandType = CommandType.StoredProcedure;

            conn.Open();

            initiatePlanPaymentProc.ExecuteNonQuery();

            conn.Close();
        }


        protected void initiate_balance_payment(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Initiate_balance_payment";
            SqlCommand initiateBalancePaymentProc = new SqlCommand(procQuery, conn);

            initiateBalancePaymentProc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));
            initiateBalancePaymentProc.Parameters.Add(new SqlParameter("@amount", Double.Parse(initiate_balance_payment_amount_input.Text)));
            initiateBalancePaymentProc.Parameters.Add(new SqlParameter("@payment_method", initiate_balance_payment_payment_method_input.Text));

            initiateBalancePaymentProc.CommandType = CommandType.StoredProcedure;

            conn.Open();

            initiateBalancePaymentProc.ExecuteNonQuery();

            conn.Close();
        }


        protected void redeem_voucher_points(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Redeem_voucher_points";
            SqlCommand redeemVoucherPaymentsProc = new SqlCommand(procQuery, conn);

            redeemVoucherPaymentsProc.Parameters.Add(new SqlParameter("@MobileNo", HiddenFieldMobileNo.Value));
            redeemVoucherPaymentsProc.Parameters.Add(new SqlParameter("@voucher_id", redeem_voucher_points_voucher_id_input.Text));

            redeemVoucherPaymentsProc.CommandType = CommandType.StoredProcedure;

            conn.Open();

            redeemVoucherPaymentsProc.ExecuteNonQuery();

            conn.Close();
        }

    }
}
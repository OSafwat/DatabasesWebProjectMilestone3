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
            if (!IsPostBack)
            {
                all_customer_accounts(sender, e);
                physical_store_vouchers(sender, e);
                all_resolved_tickets(sender, e);
                account_plan(sender, e);
                customer_wallet(sender, e);
                e_store_vouchers(sender, e);
                account_payments(sender, e);
                num_of_cashback(sender, e);
            }
        }

        protected void all_customer_accounts(object sender, EventArgs e)
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

        protected void physical_store_vouchers(object sender, EventArgs e)
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

        protected void all_resolved_tickets(object sender, EventArgs e)
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
        protected void account_plan(object sender, EventArgs e)
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

        protected void account_plan_date(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string functionQuery = "SELECT * FROM dbo.Account_Plan_date(@Subscription_Date, @Plan_id)";
            SqlCommand account_plan_date_function = new SqlCommand(functionQuery, conn);
            try
            {
                int z = Int16.Parse(account_plan_date_service_plan_textbox.Text);
            }
            catch (Exception e1)
            {
                Label29.Text = "The sevice plan ID input should be an integer. Please try again.";
                return;
            }
            int servicePlanId = Int16.Parse(account_plan_date_service_plan_textbox.Text);
            string date = account_plan_date_date_textbox.Text;

            account_plan_date_function.Parameters.Add(new SqlParameter("@Subscription_Date", date));
            account_plan_date_function.Parameters.Add(new SqlParameter("@Plan_id", servicePlanId));


            try
            {
                conn.Open();
                SqlDataAdapter functionAdapter = new SqlDataAdapter(account_plan_date_function);
                DataTable accountsPlanDateData = new DataTable();
                functionAdapter.Fill(accountsPlanDateData);

                account_plan_date_data.DataSource = accountsPlanDateData;
                account_plan_date_data.DataBind();

                if (date.Equals(""))
                    throw new Exception();
            } catch (Exception e1)
            {
                if (account_plan_date_service_plan_textbox.Text.Equals("") || date.Equals("")) {
                    Label29.Text = "An error has occurred. This is most probably due to your inputs being invalid (empty). Please put in proper" +
                        " inputs then try again.";
                }
                else
                {
                    Label29.Text = "An error has occurred. Please check that the database is deployed and that the inputs are valid. If there is a valid " +
                        "error message, it will be displayed here: " + e1.Message;
                }
                conn.Close();
                return;
            }
            Label29.Text = "Success!";
            conn.Close();
        }

        protected void account_usage_plan(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string functionQuery = "SELECT * FROM dbo.Account_Usage_Plan(@MobileNo, @from_date)";
            SqlCommand account_usage_plan_function = new SqlCommand(functionQuery, conn);

            string mobileNo = account_usage_plan_mobile_number_textbox.Text;
            string date = account_usage_plan_date_textbox.Text;

            account_usage_plan_function.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));
            account_usage_plan_function.Parameters.Add(new SqlParameter("@from_date", date));


            try
            {
                conn.Open();
                if (mobileNo.Length != 0)
                    throw new Exception();
                SqlDataAdapter functionAdapter = new SqlDataAdapter(account_usage_plan_function);
                DataTable accountsPlanDateData = new DataTable();
                functionAdapter.Fill(accountsPlanDateData);

                account_usage_plan_data.DataSource = accountsPlanDateData;
                account_usage_plan_data.DataBind();
            } catch (Exception e1)
            {
                if (mobileNo.Length < 11)
                {
                    Label30.Text = "An error has occurred. The mobile number input should be at least 11 digits, and the date input should not be empty. Please put in proper" +
                        " inputs then try again.";
                }
                else if (mobileNo.Length > 11)
                {
                    Label30.Text = "An error has occurred. The mobile number input should be at most 11 digits, and the date input should not be empty. Please put in proper" +
                        " inputs then try again.";
                }
                else
                {
                    Label30.Text = "An error has occurred. Please check that the database is deployed and that the inputs are valid. If there is a valid " +
                        "error message, it will be displayed here: " + e1.Message;
                }
                conn.Close();
                return;
            }
            Label30.Text = "Success!";
            conn.Close();
        }

        protected void benefits_account(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Benefits_Account";
            SqlCommand benefits_account_proc = new SqlCommand(procQuery, conn);

            benefits_account_proc.CommandType = CommandType.StoredProcedure;

            try
            {
                int z = Int16.Parse(benefits_account_planID_textbox.Text);
            } catch (Exception e1)
            {
                Label31.Text = "The sevice plan ID input should be an integer. Please try again.";
                return;
            }

            string mobileNo = benefits_account_mobile_number_textbox.Text;
            int ID = Int16.Parse(benefits_account_planID_textbox.Text);

            benefits_account_proc.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));
            benefits_account_proc.Parameters.Add(new SqlParameter("@planID", ID));

            try
            {
                conn.Open();
                benefits_account_proc.ExecuteNonQuery();
                if (mobileNo.Length != 0)
                    throw new Exception();

            } catch (Exception e1)
            {
                if (mobileNo.Length < 11)
                {
                    Label31.Text = "An error has occurred. The mobile number input should be at least 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else if (mobileNo.Length > 11)
                {
                    Label31.Text = "An error has occurred. The mobile number input should be at most 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else
                {
                    Label31.Text = "An error has occurred. Please check that the database is deployed and that the input is valid. If there is a valid " +
                        "error message, it will be displayed here: " + e1.Message;
                }
                conn.Close();
                return;
            }
            conn.Close();
            Label31.Text = "Success!";
        }

        protected void Account_SMS_Offers(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string functionQuery = "SELECT * FROM dbo.Account_SMS_Offers(@MobileNo)";
            SqlCommand SMS_offers_for_account_function = new SqlCommand(functionQuery, conn);

            string mobileNo = SMS_offers_for_account_mobile_number_textbox.Text;

            SMS_offers_for_account_function.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));

            conn.Open();
            try
            {
                SqlDataAdapter functionAdapter = new SqlDataAdapter(SMS_offers_for_account_function);
                DataTable SMSoffersForAccountData = new DataTable();
                functionAdapter.Fill(SMSoffersForAccountData);

                SMS_offers_for_account_data.DataSource = SMSoffersForAccountData;
                SMS_offers_for_account_data.DataBind();
                if (mobileNo.Length != 0)
                    throw new Exception();
            }
            catch (Exception e1)
            {
                if (mobileNo.Length < 11)
                {
                    Label32.Text = "An error has occurred. The mobile number input should be at least 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else if (mobileNo.Length > 11)
                {
                    Label32.Text = "An error has occurred. The mobile number input should be at most 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else
                {
                    Label32.Text = "An error has occurred. Please check that the database is deployed and that the input is valid. If there is a valid " +
                        "error message, it will be displayed here: " + e1.Message;
                }

                conn.Close();
                return;
            }
            Label32.Text = "Success";
            conn.Close();
        }

        protected void customer_wallet(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM dbo.CustomerWallet";
            SqlCommand customerWalletAccountsView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(customerWalletAccountsView);
            DataTable walletData = new DataTable();
            viewAdapter.Fill(walletData);

            customer_wallet_account_data.DataSource = walletData;
            customer_wallet_account_data.DataBind();
            conn.Close();
        }
        
        protected void e_store_vouchers(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM dbo.E_shopVouchers";
            SqlCommand E_StoreVouchersView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(E_StoreVouchersView);
            DataTable E_StoreData = new DataTable();
            viewAdapter.Fill(E_StoreData);

            E_shop_voucher_data.DataSource = E_StoreData;
            E_shop_voucher_data.DataBind();
            conn.Close();
        }

        
        protected void account_payments(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM accountPayments";
            SqlCommand accountPaymentsView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(accountPaymentsView);
            DataTable accountPaymentData = new DataTable();
            viewAdapter.Fill(accountPaymentData);

            account_payment_data.DataSource = accountPaymentData;
            account_payment_data.DataBind();
            conn.Close();
        }

        protected void num_of_cashback(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string viewQuery = "SELECT * FROM Num_of_cashback";
            SqlCommand cashbackTransactionsPerWalletView = new SqlCommand(viewQuery, conn);

            conn.Open();
            SqlDataAdapter viewAdapter = new SqlDataAdapter(cashbackTransactionsPerWalletView);
            DataTable cashbackTransactionsPerWalletData = new DataTable();
            viewAdapter.Fill(cashbackTransactionsPerWalletData);

            cashback_transactions_per_wallet_data.DataSource = cashbackTransactionsPerWalletData;
            cashback_transactions_per_wallet_data.DataBind();
            conn.Close();
        }

        
        protected void account_payment_points(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Account_Payment_Points";

            SqlCommand acceptedPaymentsAndTotalPointsForAccountInLastYear = new SqlCommand(procQuery, conn);
            acceptedPaymentsAndTotalPointsForAccountInLastYear.CommandType = CommandType.StoredProcedure;

            string mobileNo = account_accepted_payments_input.Text;

            acceptedPaymentsAndTotalPointsForAccountInLastYear.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));


            SqlParameter totalNumberOfAcceptedTransactions = new SqlParameter("@TotalTransactions", SqlDbType.Int);
            SqlParameter totalNumberOfPoints = new SqlParameter("@TotalPoints", SqlDbType.Int);

            totalNumberOfAcceptedTransactions.Direction = ParameterDirection.Output;
            totalNumberOfPoints.Direction = ParameterDirection.Output;

            acceptedPaymentsAndTotalPointsForAccountInLastYear.Parameters.Add(totalNumberOfAcceptedTransactions);
            acceptedPaymentsAndTotalPointsForAccountInLastYear.Parameters.Add(totalNumberOfPoints);

            try
            {

                conn.Open();
                acceptedPaymentsAndTotalPointsForAccountInLastYear.ExecuteNonQuery();
                if (mobileNo.Length != 0)
                    throw new Exception();

            } catch (Exception e1)
            {
                if (mobileNo.Length < 11)
                {
                    Label37.Text = "An error has occurred. The mobile number input should be at least 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else if (mobileNo.Length > 11)
                {
                    Label37.Text = "An error has occurred. The mobile number input should be at most 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else
                {
                    Label37.Text = "An error has occurred. Please check that the database is deployed and that the input is valid. If there is a valid " +
                        "error message, it will be displayed here: " + e1.Message;
                }
                conn.Close();
                return;
            }
            Label37.Text = "Success!";
            conn.Close();
            account_accepted_payments_number.Text = "Number of accepted payment transactions: " + totalNumberOfAcceptedTransactions.Value;
            account_accepted_payments_total_points.Text = "Total number of earned points: " + totalNumberOfPoints.Value;
        }

        
        protected void wallet_cashback_amount(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string functionQuery = "SELECT dbo.Wallet_Cashback_Amount(@WalletId, @PlanId)";
            SqlCommand wallet_cashback_amount_function = new SqlCommand(functionQuery, conn);

            try
            {
                int x = Int16.Parse(wallet_cashback_wallet_id_input.Text);
                int z = Int16.Parse(wallet_cashback_plan_id_input.Text);
            } catch (Exception e1)
            {
                Label38.Text = "The wallet ID and plan ID inputs should be integers. Please try again.";
                return;
            }


            int walletID = Int16.Parse(wallet_cashback_wallet_id_input.Text);
            int planID = Int16.Parse(wallet_cashback_plan_id_input.Text);

            wallet_cashback_amount_function.Parameters.Add(new SqlParameter("@WalletId", walletID));
            wallet_cashback_amount_function.Parameters.Add(new SqlParameter("@PlanId", planID));

            conn.Open();
            try
            {

                int res = (int)wallet_cashback_amount_function.ExecuteScalar();
                Label15.Text = "Result: " + res;
            }
            catch (Exception e1)
            {
                Label38.Text = "An error has occurred. Please check that the database is deployed and that the inputs are valid. If there is a valid " +
                    "error message, it will be displayed here: " + e1.Message;
                conn.Close();
                return;
            }
            Label38.Text = "Success!";
            conn.Close();
        }

        //continue from here
        protected void wallet_transfer_amount(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string functionQuery = "SELECT dbo.Wallet_Transfer_Amount(@WalletId, @PlanId)";
            SqlCommand wallet_transfer_amount_function = new SqlCommand(functionQuery, conn);

            try
            {
                int z = Int16.Parse(wallet_cashback_wallet_id_input.Text);
            } catch (Exception e1)
            {
                Label39.Text = "The Wallet Id input should be an integer. Please try again.";
                return;
            }


            int walletID = Int16.Parse(wallet_cashback_wallet_id_input.Text);
            String start_date = wallet_transfer_amount_start_date_input.Text;
            String end_date = wallet_transfer_amount_end_date_input.Text;

            wallet_transfer_amount_function.Parameters.Add(new SqlParameter("@WalletId", walletID));
            wallet_transfer_amount_function.Parameters.Add(new SqlParameter("@start_date", start_date));
            wallet_transfer_amount_function.Parameters.Add(new SqlParameter("@end_date", end_date));

            conn.Open();
            try
            {
                double res = (double)wallet_transfer_amount_function.ExecuteScalar();
                Label18.Text = "Result: " + res;
            }
            catch (Exception e1)
            {
                if (start_date.Length == 0 || end_date.Length == 0)
                {
                    Label39.Text = "An error has occurred. This is most probably due to your inputs being invalid (empty). Please put in proper" +
                        " inputs then try again.";
                }
                else
                {
                    Label39.Text = "An error has occurred. Please check that the database is deployed and that the inputs are valid. If there is a valid " +
                        "error message, it will be displayed here: " + e1.Message;
                }
                conn.Close();
                return;
            }
            Label39.Text = "Success!";
            conn.Close();
        }


        protected void Wallet_MobileNo(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string functionQuery = "SELECT dbo.Wallet_MobileNo(@MobileNo)";
            SqlCommand wallet_mobileNo_verification_function = new SqlCommand(functionQuery, conn);

            String mobileNo = wallet_mobileNo_verification_input.Text;

            wallet_mobileNo_verification_function.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));

            conn.Open();
            try
            {

                bool res = ((int)wallet_mobileNo_verification_function.ExecuteScalar() == 1);
                Label24.Text = "Result: " + (res ? "It is linked." : "It is not linked.");
                if (mobileNo.Length != 0)
                    throw new Exception();
            }
            catch (Exception e1)
            {
                if (mobileNo.Length < 11)
                {
                    Label40.Text = "An error has occurred. The mobile number input should be at least 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else if (mobileNo.Length > 11)
                {
                    Label40.Text = "An error has occurred. The mobile number input should be at most 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else
                {
                    Label40.Text = "An error has occurred. Please check that the database is deployed and that the input is valid. If there is a valid " +
                        "error message, it will be displayed here: " + e1.Message;
                }
                conn.Close();
                return;
            }
            Label40.Text = "Success!";
            conn.Close();
        }

        protected void total_points_account(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DatabasesWebsite"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string procQuery = "Total_Points_Account";
            SqlCommand total_points_account_proc = new SqlCommand(procQuery, conn);

            total_points_account_proc.CommandType = CommandType.StoredProcedure;

            string mobileNo = total_points_account_textbox.Text;

            total_points_account_proc.Parameters.Add(new SqlParameter("@MobileNo", mobileNo));

            try
            {
                conn.Open();
                total_points_account_proc.ExecuteNonQuery();
                if (mobileNo.Length != 0)
                    throw new Exception();
            }
            catch (Exception e1)
            {
                if (mobileNo.Length < 11)
                {
                    Label41.Text = "An error has occurred. The mobile number input should be at least 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else if (mobileNo.Length > 11)
                {
                    Label41.Text = "An error has occurred. The mobile number input should be at most 11 digits. Please put in a proper" +
                        " input then try again.";
                }
                else
                {
                    Label41.Text = "An error has occurred. Please check that the database is deployed and that the input is valid. If there is a valid " +
                        "error message, it will be displayed here: " + e1.Message;
                }
                conn.Close();
            }
            Label41.Text = "Success!";
            conn.Close ();  
        }

    }
}
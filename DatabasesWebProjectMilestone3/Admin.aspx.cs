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
    }
}
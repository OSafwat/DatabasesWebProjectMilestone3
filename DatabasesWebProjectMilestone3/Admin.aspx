<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="DatabasesWebProjectMilestone3.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Welcome to the admin page!" ID="admin_intro_label"></asp:Label>
        </div>
        <br />
        <div class="">
            <asp:Label runat="server" Text="If you would like to view all customer accounts and their customer profiles, press this button. The result will be shown in a table below!" ID="customer_account_label"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View All Customer Accounts" OnClick="customer_data_view"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:GridView ID="customer_account_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />

        <div class="">
            <asp:Label runat="server" Text="If you would like to view all physical shops along with their redeemed vouchers, press this button. The result will be shown in a table below!" ID="physical_shops_label"></asp:Label>
            <br />
        <asp:Button runat="server" Text="View All Shops" OnClick="physical_shop_data_retrieval"></asp:Button>&nbsp;</div>
        <br />

        <div class="">
            <asp:GridView ID="physical_shop_voucher_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />

        <div class="">
            <asp:Label runat="server" Text="If you would like to view details for all resolved tickets, press this button. The result will be shown in a table below!" ID="resolved_tickets_label"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View All Resolved Tickets" OnClick="resolved_tickets_data_retrieval"></asp:Button>&nbsp;</div>

        <div class="">&nbsp;
            <asp:GridView ID="resolved_tickets_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

        <div class="">
            <asp:Label runat="server" Text="If you would like to view details for all accounts along with their service plans, press this button. The result will be shown in a table below!" ID="accounts_plan_label"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View All Account-ServicePlan Tuples" OnClick="accounts_service_plans_data_retrieval"></asp:Button>&nbsp;</div>

        <div class="">&nbsp;
            <asp:GridView ID="account_plan_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

        <div class="">
            <asp:Label runat="server" Text="If you would like to view details of accounts that are subscribed to some service plan on some date, please input the required service plan and the date, then press this button. The result will be shown in a table below!" ID="account_plan_date_label"></asp:Label>
            <br />
            <!--Put service plan id textbox-->
            <asp:Label runat="server" Text="Plan ID: " ID="plan_id_input_label"></asp:Label>
            <asp:TextBox ID="account_plan_date_service_plan_textbox" runat="server"></asp:TextBox>
            <br />
            <!--Put date textbox-->
            <asp:Label runat="server" Text="Date: " ID="date_input_label"></asp:Label>
            <asp:TextBox ID="account_plan_date_date_textbox" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="account_plan_date_retrieval"></asp:Button>&nbsp;</div>

        <div class="">&nbsp;
            <asp:GridView ID="account_plan_date_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

        <div class="">
            <asp:Label runat="server" Text="If you would like to view the total usage of a certain account on each subscribed plan from a certain date, please input the required account's phone number and the date, then press this button. The result will be shown in a table below!" ID="Label1"></asp:Label>
            <br />
            <!--Put mobile number textbox-->
            <asp:Label runat="server" Text="Mobile Number: " ID="Label2"></asp:Label>
            <asp:TextBox ID="account_usage_plan_mobile_number_textbox" runat="server"></asp:TextBox>
            <br />
            <!--Put date textbox-->
            <asp:Label runat="server" Text="Date: " ID="Label3"></asp:Label>
            <asp:TextBox ID="account_usage_plan_date_textbox" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="account_usage_plan_retrieval"></asp:Button>&nbsp;</div>

        <div class="">&nbsp;
            <asp:GridView ID="account_usage_plan_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

        <div class="">
            <asp:Label runat="server" Text="If you would like to remove all benefits offered to the input account for a certain input plan ID, please input the required account's phone number and the required plan ID, then press this button. The result will be shown in a table below!" ID="Label4"></asp:Label>
            <br />
            <!--Put mobile number textbox-->
            <asp:Label runat="server" Text="Mobile Number: " ID="Label5"></asp:Label>
            <asp:TextBox ID="benefits_account_mobile_number_textbox" runat="server"></asp:TextBox>
            <br />
            <!--Put plan ID textbox-->
            <asp:Label runat="server" Text="Plan ID: " ID="Label6"></asp:Label>
            <asp:TextBox ID="benefits_account_planID_textbox" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="remove_plan_benefits_from_account"></asp:Button>&nbsp;</div>

        <br />

        <div class="">
            <asp:Label runat="server" Text="If you would like to retrieve all SMS offers for a certain account, please input the required account's phone number, then press this button. The result will be shown in a table below!" ID="Label7"></asp:Label>
            <br />
            <!--Put mobile number textbox-->
            <asp:Label runat="server" Text="Mobile Number: " ID="Label8"></asp:Label>
            <asp:TextBox ID="SMS_offers_for_account_mobile_number_textbox" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="SMS_offers_for_account"></asp:Button>&nbsp;</div>
            <br />
            <asp:Label runat="server" ID="Label100"></asp:Label>
        <div class="">&nbsp;
            <asp:GridView ID="SMS_offers_for_account_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>


        <div class="">
            <asp:Label runat="server" Text="If you would like to retrieve details of all wallets along with their customer
            names, then press this button. The result will be shown in a table below!" ID="customer_wallet_label"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="customer_wallet_account_view"></asp:Button>&nbsp;</div>
            <br />
            <asp:Label runat="server" ID="Label11"></asp:Label>
        <div class="">&nbsp;
            <asp:GridView ID="customer_wallet_account_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>


        <div class="">
            <asp:Label runat="server" Text="If you would like to view all E shops along with their redeemed vouchers, press this button. The result will be shown in a table below!" ID="Label9"></asp:Label>
            <br />
        <asp:Button runat="server" Text="View All Shops" OnClick="E_shop_data_retrieval"></asp:Button>&nbsp;</div>
        <br />

        <div class="">
            <asp:GridView ID="E_shop_voucher_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to view details for all payments along with their
 corresponding accounts, press this button. The result will be shown in a table below!" ID="Label10"></asp:Label>
            <br />
        <asp:Button runat="server" Text="View Data" OnClick="account_payment_data_retrieval"></asp:Button>&nbsp;</div>
        <br />

        <div class="">
            <asp:GridView ID="account_payment_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to view the number of cashback transactions per each wallet, press this button. The result will be shown in a table below!" ID="Label12"></asp:Label>
            <br />
        <asp:Button runat="server" Text="View Data" OnClick="cashback_transactions_per_wallet_data_retrieval"></asp:Button>&nbsp;</div>
        <br />

        <div class="">
            <asp:GridView ID="cashback_transactions_per_wallet_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />


    </form>
</body>
</html>

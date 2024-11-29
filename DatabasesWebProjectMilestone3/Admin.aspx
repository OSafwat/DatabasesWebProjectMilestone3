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
        <div class="wlp-whitespace-only-element-expansion">
            <asp:GridView ID="customer_account_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="If you would like to view all physical shops along with their redeemed vouchers, press this button. The result will be shown in a table below!" ID="physical_shops_label"></asp:Label>
            <br />
        <asp:Button runat="server" Text="View All Shops" OnClick="physical_shop_data_retrieval"></asp:Button>&nbsp;</div>
        <br />

        <div class="">
            <asp:GridView ID="physical_shop_voucher_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />

        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="If you would like to view details for all resolved tickets, press this button. The result will be shown in a table below!" ID="resolved_tickets_label"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View All Resolved Tickets" OnClick="resolved_tickets_data_retrieval"></asp:Button>&nbsp;</div>

        <div class="wlp-whitespace-only-element-expansion">&nbsp;
            <asp:GridView ID="resolved_tickets_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="If you would like to view details for all accounts along with their service plans, press this button. The result will be shown in a table below!" ID="accounts_plan_label"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View All Account-ServicePlan Tuples" OnClick="accounts_service_plans_data_retrieval"></asp:Button>&nbsp;</div>

        <div class="wlp-whitespace-only-element-expansion">&nbsp;
            <asp:GridView ID="account_plan_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

        <div class="wlp-whitespace-only-element-expansion">
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

        <div class="wlp-whitespace-only-element-expansion">&nbsp;
            <asp:GridView ID="account_plan_date_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="If you would like to view the total usage of a certain account on each subscribed plan from a certain date, please input the required account's phone number and the date, then press this button. The result will be shown in a table below!" ID="Label1"></asp:Label>
            <br />
            <!--Put service plan id textbox-->
            <asp:Label runat="server" Text="Mobile Number: " ID="Label2"></asp:Label>
            <asp:TextBox ID="account_usage_plan_mobile_number_textbox" runat="server"></asp:TextBox>
            <br />
            <!--Put date textbox-->
            <asp:Label runat="server" Text="Date: " ID="Label3"></asp:Label>
            <asp:TextBox ID="account_usage_plan_date_textbox" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="account_usage_plan_retrieval"></asp:Button>&nbsp;</div>

        <div class="wlp-whitespace-only-element-expansion">&nbsp;
            <asp:GridView ID="account_usage_plan_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>



    </form>
</body>
</html>

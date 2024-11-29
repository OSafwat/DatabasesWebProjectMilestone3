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
            <asp:Label runat="server" Text="If you would like to view all customer accounts and their customer profiles, press this button. The result will be shown in a table below!" ID="ctl28"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View All Customer Accounts" OnClick="customer_data_view"></asp:Button>&nbsp;</div>
        <br />
        <div class="wlp-whitespace-only-element-expansion">
            <asp:GridView ID="customer_account_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="If you would like to view all physical shops along with their redeemed vouchers, press this button. The result will be shown in a table below!" ID="ctl31"></asp:Label>
            <br />
        <asp:Button runat="server" Text="View All Shops" OnClick="physical_shop_data_retrieval"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:GridView ID="physical_shop_voucher_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />
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
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>



    </form>
</body>
</html>

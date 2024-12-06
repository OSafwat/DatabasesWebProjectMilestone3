<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="DatabasesWebProjectMilestone3.Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Welcome to the customer page!" ID="customer_intro_label"></asp:Label>
        </div>
        <br />

        <asp:HiddenField ID="HiddenFieldMobileNo" runat="server" />
        <asp:HiddenField ID="HiddenFieldNationalID" runat="server" />
        
            <asp:Label runat="server" Text="Service Plan Data" ID="service_plans_label"></asp:Label>
            <br />
        <div class="">
            <asp:GridView ID="service_plan_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to view all consumption details for a certain plan during a certain duration, please input the required plan's name, the start date, and the end date, then press this button. The result will be shown in a table below!" ID="consumption_display_label"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Plan Name: " ID="label1"></asp:Label>
            <asp:TextBox runat="server" ID="consumption_display_plan_name_input"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Start Date: " ID="label2"></asp:Label>
            <asp:TextBox runat="server" ID="consumption_display_start_date_input"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="End Date: " ID="label3"></asp:Label>
            <asp:TextBox runat="server" ID="consumption_display_end_date_input"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Consumption" OnClick="consumption_display"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:GridView ID="consumption_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />

        <div class="">
            <asp:Label runat="server" Text="Unsubscribed Plans Data" ID="unsubscribed_plans_label"></asp:Label>
            <br />
        <div class="">
            <asp:GridView ID="unsubscribed_plans_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="Current Month Active Plans' Usage Data" ID="Label4"></asp:Label>
            <br />
        <div class="">
            <asp:GridView ID="active_plans_usage_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to view all of your cashback transactions, press this button. The result will be shown in a table below!" ID="Label5"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View Cashback Transactions" OnClick="cashback_customer_wallet_data_retrieval"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:GridView ID="cashback_customer_wallet_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to view all active benefits and their details, press this button. The result will be shown in a table below!" ID="Label6"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View All Active Benefits" OnClick="active_benefits_view"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:GridView ID="active_benefits_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />



        <div class="">
            <asp:Label runat="server" Text="If you would like to view the number of your unresolved tickets, press this button. The result will be shown in a table below!" ID="Label7"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View Number Of Unresolved Tickets" OnClick="ticket_amount_customer"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:Label runat="server" Text="Result:" ID="tickets_amount_customer_result"></asp:Label> 
            &nbsp;
        </div>
        <br />



        <div class="">
            <asp:Label runat="server" Text="If you would like to view the voucher ID of the highest value voucher that you own, press this button. The result will be shown in a table below!" ID="Label8"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View VoucherID Of Highest Value" OnClick="account_highest_voucher"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:Label runat="server" Text="Result:" ID="account_highest_voucher_result"></asp:Label> 
            &nbsp;
        </div>
        <br />



        <div class="">
            <asp:Label runat="server" Text="If you would like to view the remaining amount of a certain plan based on the payment initiated by you, press this button. The result will be shown in a table below!" ID="Label9"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Plan Name: " ID="remaining_plan_amount_plan_name_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="remaining_plan_amount_plan_name_input"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Remaining Amount" OnClick="remaining_plan_amount"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:Label runat="server" Text="Result:" ID="remaining_plan_amount_result"></asp:Label> 
            &nbsp;
        </div>
        <br />



        <div class="">
            <asp:Label runat="server" Text="If you would like to view the extra amount of a certain plan based on the payment initiated by you, press this button. The result will be shown in a table below!" ID="Label10"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Plan Name: " ID="extra_plan_amount_plan_name_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="extra_plan_amount_plan_name_input"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Extra Amount" OnClick="extra_plan_amount"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:Label runat="server" Text="Result:" ID="extra_plan_amount_result"></asp:Label> 
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to view your top 10 successful payments with the highest value, press this button. The result will be shown in a table below!" ID="Label11"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View Top 10 Payments" OnClick="top_successful_payments"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:GridView ID="top_successful_payments_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to view details for all shops, press this button. The result will be shown in a table below!" ID="Label12"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View All Shops" OnClick="shop_data_retrieval"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:GridView ID="all_shop_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to view all service plans you've subscribed to in the past 5 months, press this button. The result will be shown in a table below!" ID="Label13"></asp:Label>
            <br />
            <asp:Button runat="server" Text="View Service Plans" OnClick="subscribed_plans_months"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:GridView ID="subscribed_plans_months_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to initiate a payment for plan renewal, press this button." ID="Label14"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Amount Input: " ID="initiate_plan_payment_amount_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="initiate_plan_payment_amount_input"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Payment Method: " ID="initiate_plan_payment_payment_method_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="initiate_plan_payment_payment_method_input"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Plan ID: " ID="initiate_plan_payment_plan_ID_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="initiate_plan_payment_plan_ID_input"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="Initiate Payment" OnClick="initiate_plan_payment"></asp:Button>&nbsp;</div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to initiate a payment for balance recharge, press this button." ID="Label15"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Amount Input: " ID="initiate_balance_payment_amount_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="initiate_balance_payment_amount_input"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Payment Method: " ID="initiate_balance_payment_payment_method_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="initiate_balance_payment_payment_method_input"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="Initiate Payment" OnClick="initiate_balance_payment"></asp:Button>&nbsp;</div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to redeem a voucher, press this button." ID="Label16"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Voucher ID: " ID="redeem_voucher_points_voucher_id_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="redeem_voucher_points_voucher_id_input"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="Initiate Payment" OnClick="initiate_balance_payment"></asp:Button>&nbsp;</div>
        <br />



    </form>
</body>
</html>

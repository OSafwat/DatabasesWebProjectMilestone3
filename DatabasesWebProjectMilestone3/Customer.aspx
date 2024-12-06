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
            <br /> <br />
        <div class="">
            <asp:GridView ID="service_plan_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to view all consumption details for a certain plan during a certain duration, please input the required plan's name, the start date, and the end date, then press this button. The result will be shown in a table below!" ID="consumption_display_label"></asp:Label>
            <br />
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
            <br />
            <asp:Label runat="server" ID="consumption_data_response"></asp:Label> <br />
            <asp:Button runat="server" Text="View Consumption" OnClick="consumption_display"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:GridView ID="consumption_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />

        <div class="">
            <asp:Label runat="server" Text="Unsubscribed Plans Data" ID="unsubscribed_plans_label"></asp:Label>
            <br /> <br />
        <div class="">
            <asp:GridView ID="unsubscribed_plans_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="Current Month Active Plans' Usage Data" ID="Label4"></asp:Label>
            <br /> <br />
        <div class="">
            <asp:GridView ID="active_plans_usage_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="Wallet Cashback Data" ID="Label5"></asp:Label>
            <br /> <br />
        <div class="">
            <asp:GridView ID="cashback_customer_wallet_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="All Benefits Data" ID="Label6"></asp:Label>
            <br /> <br />
        <div class="">
            <asp:GridView ID="active_benefits_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />



        <div class="">
        
        <br />
        <div class="">
            <asp:Label runat="server" Text="Number Of Unresolved Tickets:" ID="tickets_amount_customer_result"></asp:Label> 
            &nbsp;
        </div>
        <br />



        <div class="">
        <br />
        <div class="">
            <asp:Label runat="server" Text="Highest Voucher Value Available To You:" ID="account_highest_voucher_result"></asp:Label> 
            &nbsp;
        </div>
        <br />
            <br />



        <div class="">
            <asp:Label runat="server" Text="If you would like to view the remaining amount of a certain plan based on the payment initiated by you, then input the required plan name and press this button." ID="Label9"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" Text="Plan Name: " ID="remaining_plan_amount_plan_name_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="remaining_plan_amount_plan_name_input"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" ID="remaining_plan_amount_response"></asp:Label> <br />
            <asp:Button runat="server" Text="View Remaining Amount" OnClick="remaining_plan_amount"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:Label runat="server" Text="Remaining Amount: " ID="remaining_plan_amount_result"></asp:Label> 
            &nbsp;
        </div>
        <br />
            <br />



        <div class="">
            <asp:Label runat="server" Text="If you would like to view the extra amount of a certain plan based on the payment initiated by you, then input the required plan name and press this button. The result will be shown in a table below!" ID="Label10"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" Text="Plan Name: " ID="extra_plan_amount_plan_name_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="extra_plan_amount_plan_name_input"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" ID="extra_plan_amount_response"></asp:Label> <br />
            <asp:Button runat="server" Text="View Extra Amount" OnClick="extra_plan_amount"></asp:Button>&nbsp;</div>
        <br />
        <div class="">
            <asp:Label runat="server" Text="Extra Amount:" ID="extra_plan_amount_result"></asp:Label> 
            &nbsp;
        </div>
        <br />
            <br />

        <div class="">
            <asp:Label runat="server" Text="Top 10 Successful Payments" ID="Label11"></asp:Label>
            <br /> <br />
        <div class="">
            <asp:GridView ID="top_successful_payments_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="All Shops Data" ID="Label12"></asp:Label>
            <br /> 
        <br />
        <div class="">
            <asp:GridView ID="all_shop_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="Subscribed Plans Data" ID="Label13"></asp:Label>
            <br /> <br />
        <div class="">
            <asp:GridView ID="subscribed_plans_months_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to initiate a payment for plan renewal, input the payment amount, the payment method, and the plan ID, then press this button." ID="Label14"></asp:Label>
            <br />
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
            <br />
            <asp:Label runat="server" ID="initiate_plan_payment_response"></asp:Label> <br />
            <asp:Button runat="server" Text="Initiate Payment" OnClick="initiate_plan_payment"></asp:Button>&nbsp;</div>
        <br />
            <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to initiate a payment for balance recharge, input the amount and the payment method, then press this button." ID="Label15"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" Text="Amount Input: " ID="initiate_balance_payment_amount_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="initiate_balance_payment_amount_input"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Payment Method: " ID="initiate_balance_payment_payment_method_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="initiate_balance_payment_payment_method_input"></asp:TextBox>
            <br />
            <br /> 
            <asp:Label runat="server" ID="initiate_balance_payment_response"></asp:Label>  <br />
            <asp:Button runat="server" Text="Initiate Payment" OnClick="initiate_balance_payment"></asp:Button>&nbsp;</div>
        <br />
            <br />


        <div class="">
            <asp:Label runat="server" Text="If you would like to redeem a voucher, input the voucher's ID, then press this button." ID="Label16"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" Text="Voucher ID: " ID="redeem_voucher_points_voucher_id_input_label"></asp:Label>
            <asp:TextBox runat="server" ID="redeem_voucher_points_voucher_id_input"></asp:TextBox>
            <br />
           <br />
            <asp:Label runat="server" ID="redeem_voucher_points_response"></asp:Label> <br />
            <asp:Button runat="server" Text="Redeem Voucher" OnClick="redeem_voucher_points"></asp:Button>&nbsp;</div>
        <br />
            <br />




        <div class="">
            <asp:Label runat="server" Text="If you would like to get the amount of cashback 
                that will be returned to your wallet, then input the payment ID and the benefit ID, then press this button. The result will be shown below!" ID="Label7"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" Text="Payment ID: " ID="Label8"></asp:Label>
            <asp:TextBox runat="server" ID="payment_wallet_cashback_payment_ID_input"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Benefit ID: " ID="Label18"></asp:Label>
            <asp:TextBox runat="server" ID="payment_wallet_cashback_benefit_ID_input"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" ID="payment_wallet_cashback_response"></asp:Label> <br />
            <asp:Button runat="server" Text="Obtain Amount" OnClick="payment_wallet_cashback"></asp:Button>&nbsp;</div>
            <br />
            <asp:Label runat="server" Text="Result:" ID="payment_wallet_cashback_result"></asp:Label>
        <br />
            <br />

    </form>
</body>
</html>

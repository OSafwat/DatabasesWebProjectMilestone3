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
        <asp:Label runat="server" Text="Customer Account Data" ID="grid_title"></asp:Label>
        <br />
        <br />
        <div class="">
            <asp:GridView ID="customer_account_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;
        </div>
        <br />

        <div class="">
        <asp:Label runat="server" Text="Physical Store Data" ID="Label26"></asp:Label>
            <br />
        <br />
        <div class="">
            <asp:GridView ID="physical_shop_voucher_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />

        <asp:Label runat="server" Text="Resolved Tickets Data" ID="Label27"></asp:Label>
        <br />

        <div class="">&nbsp;
            <asp:GridView ID="resolved_tickets_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>
        
        <asp:Label runat="server" Text="Account Plan Data" ID="Label28"></asp:Label>
        <br />

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
            <asp:Button runat="server" Text="View Data" OnClick="account_plan_date"></asp:Button>&nbsp;</div>

        <asp:Label runat="server" Text="" ID="Label29"></asp:Label>
        <br />

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
            <asp:Button runat="server" Text="View Data" OnClick="account_usage_plan"></asp:Button>&nbsp;</div>

        <asp:Label runat="server" Text="" ID="Label30"></asp:Label>
        <br />

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
            <asp:Button runat="server" Text="Remove All Benefits" OnClick="benefits_account"></asp:Button>&nbsp;</div>
        <asp:Label runat="server" Text="" ID="Label31"></asp:Label>
        <br />

        <br />

        <div class="">
            <asp:Label runat="server" Text="If you would like to retrieve all SMS offers for a certain account, please input the required account's phone number, then press this button. The result will be shown in a table below!" ID="Label7"></asp:Label>
            <br />
            <!--Put mobile number textbox-->
            <asp:Label runat="server" Text="Mobile Number: " ID="Label8"></asp:Label>
            <asp:TextBox ID="SMS_offers_for_account_mobile_number_textbox" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="Account_SMS_Offers"></asp:Button>&nbsp;</div>
            <br />

        <asp:Label runat="server" Text="" ID="Label32"></asp:Label>
        <br />

        <div class="">&nbsp;
            <asp:GridView ID="SMS_offers_for_account_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

            <br />

            <asp:Label runat="server" Text="Customer Wallet Account Data" ID="customer_wallet_account_data_label"></asp:Label> <br /><br />
        <div class="">&nbsp;
            <asp:GridView ID="customer_wallet_account_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>

        <asp:Label runat="server" Text="E Store Data" ID="Label34"></asp:Label>
        <br />
        <br />
        <div class="">
            <asp:GridView ID="E_shop_voucher_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />


        <asp:Label runat="server" Text="Account Payment Data" ID="Label35"></asp:Label>
        <br /> <br />

        <div class="">
            <asp:GridView ID="account_payment_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />

        <asp:Label runat="server" Text="Number Of Cashbacks Data" ID="Label36"></asp:Label>
        <br />

        <div class="">
            <asp:GridView ID="cashback_transactions_per_wallet_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            &nbsp;</div>
        <br />



        <div class="">
            <asp:Label runat="server" Text="If you would like to view the number of accepted payment transactions initiated by a certain account
 during the last year along with the total amount of earned points, press this button. The results will be shown next to their respective labels below!" ID="accepted_payment_transactions_for_account_label"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Mobile Number: " ID="account_accepted_payments_input"></asp:Label>
            <asp:TextBox ID="account_accepted_payments_text" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Number of accepted payment transactons: " ID = "account_accepted_payments_number"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Total number of earned points: " ID = "account_accepted_payments_total_points"></asp:Label>
            <br />
        <asp:Label runat="server" Text="" ID="Label37"></asp:Label>
        <br />
        <asp:Button runat="server" Text="View Data" OnClick="account_payment_points"></asp:Button>&nbsp;</div>
        <br />



        <div class="">
            <asp:Label runat="server" Text="If you would like to retrieve the amount of cashback returned for a certain wallet and a certain plan, please input the required wallet ID and plan ID, then press this button. The result will be shown in a table below!" ID="Label13"></asp:Label>
            <br />
            <!--Put mobile number textbox-->
            <asp:Label runat="server" Text="Wallet ID: " ID="wallet_cashback_wallet_id"></asp:Label>
            <asp:TextBox ID="wallet_cashback_wallet_id_input" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Plan ID: " ID="wallet_cashback_plan_id"></asp:Label>
            <asp:TextBox ID="wallet_cashback_plan_id_input" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="wallet_cashback_amount_data_retrieval"></asp:Button>&nbsp;</div>
            <br />
            <asp:Label runat="server" ID="Label15"></asp:Label>

        <asp:Label runat="server" Text="" ID="Label38"></asp:Label>
        <br />
        <div class="">&nbsp;
            <asp:GridView ID="wallet_cashback_data" runat="server" AutoGenerateColumns="true" CssClass="table"></asp:GridView>
            <br />
        </div>



        <div class="">
            <asp:Label runat="server" Text="If you would like to show the average of the sent transaction amounts for a certain wallet within
 a certain duration, please input the required wallet ID along with the start and end dates of the duration, then press this button. The result will be shown in a table below!" ID="Label14"></asp:Label>
            <br />
            <!--Put mobile number textbox-->
            <asp:Label runat="server" Text="Start Date: " ID="Label16"></asp:Label>
            <asp:TextBox ID="wallet_transfer_amount_start_date_input" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="End Date: " ID="Label17"></asp:Label>
            <asp:TextBox ID="wallet_transfer_amount_end_date_input" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Wallet ID: " ID="Label19"></asp:Label>
            <asp:TextBox ID="wallet_transfer_amount_wallet_id_input" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="wallet_transfer_amount_data_retrieval"></asp:Button>&nbsp;</div>
            <br />
            <asp:Label runat="server" ID="Label18" Text="Result: "></asp:Label>
        <asp:Label runat="server" Text="" ID="Label39"></asp:Label>
        <br />
        <div class="">&nbsp;
        </div>


        <div class="">
            <asp:Label runat="server" Text="If you would like to show if a certain mobile number is linked to a wallet or not, please input the required phone number, then press this button. The result will be shown in a table below!" ID="Label20"></asp:Label>
            <br />
            <!--Put mobile number textbox-->
            <asp:Label runat="server" Text="Mobile Number: " ID="Label23"></asp:Label>
            <asp:TextBox ID="wallet_mobileNo_verification_input" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="View Data" OnClick="wallet_mobileNo_verification"></asp:Button>&nbsp;</div>
            <br />
            <asp:Label runat="server" ID="Label24"></asp:Label>
        <asp:Label runat="server" Text="" ID="Label40"></asp:Label>
        <br />
        <div class="">&nbsp;
        </div>


        <div class="">
            <asp:Label runat="server" Text="If you would like to update the total number of earned points of a certain phone number, please input the required phone number, then press this button. The result will be shown in a table below!" ID="Label21"></asp:Label>
            <br />
            <!--Put mobile number textbox-->
            <asp:Label runat="server" Text="Mobile Number: " ID="Label22"></asp:Label>
            <asp:TextBox ID="total_points_account_textbox" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="Execute Command" OnClick="total_points_account"></asp:Button>&nbsp;</div>
            <br />
            <asp:Label runat="server" ID="Label25"></asp:Label>
        <asp:Label runat="server" Text="" ID="Label41"></asp:Label>
        <br />
        <div class="">&nbsp;
        </div>


    </form>
</body>
</html>

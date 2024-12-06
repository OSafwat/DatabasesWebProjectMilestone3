<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DatabasesWebProjectMilestone3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            If you would like to log in, fill in the following boxes, then press the "Log In" button.<br /> <br />
            Mobile Number:
            <asp:TextBox ID="mobile_number" runat="server"></asp:TextBox> <br />
            <br />
            Password:
            <asp:TextBox ID="password" runat="server"></asp:TextBox> <br />
            <br />
        </div>
        <asp:Button ID="login_button" runat="server" OnClick="login_function" Text="Log In" />
        <br /> <br /><br /> <br />
        If you would like to sign up (create a new profile), please fill in the following textboxes, then press the "Sign In" button. You will
        then be automatically logged in to our system, and your mobile number will be displayed on the new page. <br /><br />

        National ID:
        <asp:TextBox ID ="national_id_input" runat="server"></asp:TextBox> <br /><br />
        First Name:
        <asp:TextBox ID ="first_name_input" runat="server"></asp:TextBox> <br /><br />
        Last Name:
        <asp:TextBox ID ="last_name_input" runat="server"></asp:TextBox> <br /><br />
        Email:
        <asp:TextBox ID ="email_input" runat="server"></asp:TextBox> <br /><br />
        Date Of Birth:
        <asp:TextBox ID ="date_of_birth_input" runat="server"></asp:TextBox> <br /><br />
        <asp:Button ID="signup_button" runat="server" OnClick="signup_function" Text="Sign Up" />
        <br /><br /><br /><br />

        If you would like to create a new account (obtain a new mobile number), please fill in the following textboxes, then press the "Create Account" button. <br /><br />
        Password:
        <asp:TextBox ID ="password_input" runat="server"></asp:TextBox> <br /><br /> 
        Account Type:
        <asp:DropDownList ID="account_type_input" runat="server"></asp:DropDownList> <br /> <br />
        National ID:
        <asp:TextBox ID="national_id_input_2" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="create_account_button" runat="server" OnClick="create_account_function" Text="Create Account" />

    </form>
</body>
</html>

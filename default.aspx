<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApp_44905165._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | Brighton Medical</title>
    <link href="global.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="frmLogin" runat="server" class="login-page">
        <div runat="server" class="login-container">
            <h1>Login</h1>
            <div class="card">
                <%-- Dynamic login error --%>
                <asp:Label ID="lblLoginError" runat="server" Text="Incorrect email or password*" ForeColor="Red" Visible="false"></asp:Label>
                <%-- Email --%>
                <div class="text-input">
                    <div class="input-validation">
                        <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label>
                        <div class="multiple-validation">
                            <asp:RequiredFieldValidator ID="requiredValidatorEmail" runat="server" ErrorMessage="Required*" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexValidatorEmail" runat="server" ForeColor="Red" ErrorMessage="Invalid format*" ControlToValidate="txtEmail" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter your email here"></asp:TextBox>
                </div>
                <%-- Password --%>
                <div class="text-input">
                    <div class="input-validation">
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                        <asp:RequiredFieldValidator ID="requiredValidatorPassword" runat="server" ErrorMessage="Required*" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter your password here" type="password"></asp:TextBox>
                </div>  
                <asp:Button ID="btnLogin" CssClass="button" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <%-- Redirect to register --%>
                <a class="link" href="/register">New Patient? Finish your account setup here</a>            
            </div>            
        </div>      
    </form>
</body>
</html>

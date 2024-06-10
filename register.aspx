<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApp_44905165.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register | Brighton Medical</title>
    <link href="global.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="frmRegister" runat="server" class="login-page">
        <div runat="server" class="login-container">
            <h1>Register</h1>
            <div class="card">
                <%-- Dynamic error message --%>
                <asp:Label ID="lblRegisterError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
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
                        <div class="multiple-validation">
                            <asp:RequiredFieldValidator ID="requiredValidatorPassword" runat="server" ErrorMessage="Required*" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexValidatorPassword" runat="server" ErrorMessage="Must be at least 8 characters*" ControlToValidate="txtPassword" ForeColor="Red" ValidationExpression=".{8,}"></asp:RegularExpressionValidator>
                        </div>                     
                    </div>
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter your password here" type="password"></asp:TextBox>
                </div>  
                <%-- Confirm Password --%>
                <div class="text-input">
                    <div class="input-validation">
                        <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password"></asp:Label>
                        <div class="multiple-validation">
                            <asp:RequiredFieldValidator ID="requiredValidatorConfirm" runat="server" ErrorMessage="Required*" ControlToValidate="txtConfirm" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="compareValidatorConfirm" runat="server" ErrorMessage="Passwords don't match*" ForeColor="Red" ControlToValidate="txtConfirm" ControlToCompare="txtPassword"></asp:CompareValidator>
                        </div>                      
                    </div>
                    <asp:TextBox ID="txtConfirm" runat="server" placeholder="Confirm your password" type="password"></asp:TextBox>
                </div> 
                <asp:Button ID="btnRegister" CssClass="button" runat="server" Text="Register" OnClick="btnRegister_Click" />
                <%-- Redirect to login --%>
                <a class="link" href="/">Already have an account? Login here</a>
            </div>            
        </div> 
    </form>
</body>
</html>

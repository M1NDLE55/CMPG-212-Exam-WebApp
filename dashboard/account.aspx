<%@ Page Title="" Language="C#" MasterPageFile="~/dashboard/dashboard.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="WebApp_44905165.dashboard.account" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
    <title>Account | Brighton Medical</title>
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="masterContent" runat="server">
    <div class="dashboard-form">
        <h2>Personal Details</h2>
        <div class="card">           
            <div class="horizontal-input">
                <%-- Name --%>
                <div class="text-input">
                    <div class="input-validation">
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                        <asp:RequiredFieldValidator ID="requiredValidatorName" runat="server" ValidationGroup="personal" ErrorMessage="Required*" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:TextBox ID="txtName" runat="server" placeholder="Enter your name here"></asp:TextBox>
                </div>
                <%-- Surname --%>
                <div class="text-input">
                    <div class="input-validation">
                        <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
                        <asp:RequiredFieldValidator ID="requiredValidatorSurname" runat="server" ValidationGroup="personal" ErrorMessage="Required*" ControlToValidate="txtSurname" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:TextBox ID="txtSurname" runat="server" placeholder="Enter your surname here"></asp:TextBox>
                </div>
            </div>
            <div class="horizontal-input">
                <%-- Contact --%>
                <div class="text-input">
                    <div class="input-validation">
                        <asp:Label ID="lblContact" runat="server" Text="Contact Number"></asp:Label>
                        <div class="multiple-validation">
                            <asp:RequiredFieldValidator ID="requiredValidatorNumber" runat="server" ValidationGroup="personal" ErrorMessage="Required*" ControlToValidate="txtNumber" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexValidatorNumber" runat="server" ValidationGroup="personal" ErrorMessage="Invalid format*" ControlToValidate="txtNumber" ForeColor="Red" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <asp:TextBox ID="txtNumber" runat="server" placeholder="Enter your number here"></asp:TextBox>
                </div>
                <%-- Emergency contact --%>
                <div class="text-input">
                    <div class="input-validation">
                        <asp:Label ID="lblEmergency" runat="server" Text="Emergency Contact"></asp:Label>
                        <div class="multiple-validation">
                            <asp:RequiredFieldValidator ID="requiredValidatorEmergency" runat="server" ValidationGroup="personal" ErrorMessage="Required*" ControlToValidate="txtEmergency" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexValidatorEmergency" runat="server" ValidationGroup="personal" ErrorMessage="Invalid format*" ControlToValidate="txtEmergency" ForeColor="Red" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <asp:TextBox ID="txtEmergency" runat="server" placeholder="Enter emergency contact here"></asp:TextBox>
                </div>
            </div>     
            <%-- Email --%>
            <div class="text-input">
                <div class="input-validation">
                    <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label>
                    <div class="multiple-validation">
                        <asp:RequiredFieldValidator ID="requiredValidatorEmail" runat="server" ValidationGroup="personal" ErrorMessage="Required*" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexValidatorEmail" runat="server" ValidationGroup="personal" ErrorMessage="Invalid format*" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter your email here"></asp:TextBox>
            </div>  
            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="personal" Text="Update Details" CssClass="button" OnClick="btnUpdate_Click"/>
        </div>
        <h2>Allergies</h2>
        <div class="card">
            <%-- Add allergy --%>
            <div class="text-input">
                <div class="input-validation">
                    <asp:Label ID="lblAllergy" runat="server" Text="Allergy"></asp:Label>
                    <div class="multiple-validation">
                        <asp:RequiredFieldValidator ID="requiredValidatorAllergy" runat="server" ValidationGroup="addAllergy" ErrorMessage="Required*" ForeColor="Red" ControlToValidate="txtAllergy"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblAllergyError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </div>                   
                </div>
                <asp:TextBox ID="txtAllergy" runat="server" placeholder="Enter an allergy here"></asp:TextBox>
            </div>
            <asp:Button ID="btnAddAllergy" runat="server" ValidationGroup="addAllergy" Text="Add Allergy" CssClass="button" OnClick="btnAddAllergy_Click"/>
            <%-- Remove allergies --%>
            <div class="text-input dropdown list"">
                <div class="input-validation">
                    <asp:Label ID="lblAllergyList" runat="server" Text="Your allergies"></asp:Label>
                    <div class="multiple-validation">
                        <asp:RequiredFieldValidator ID="requiredValidatorAllergyList" runat="server" ValidationGroup="removeAllergy" ErrorMessage="Required*" ForeColor="Red" ControlToValidate="lstAllergies" InitialValue=""></asp:RequiredFieldValidator>
                        <asp:Label ID="lblListError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </div>                  
                </div>
                <asp:ListBox ID="lstAllergies" runat="server"></asp:ListBox>
            </div>           
            <asp:Button ID="btnRemoveAllergy" runat="server" ValidationGroup="removeAllergy" Text="Remove Allergy" CssClass="button button-cancel" OnClick="btnRemoveAllergy_Click"/>
        </div>        
        <h2>Password</h2>
        <div class="card">
            <%-- Dynamic message --%>
            <asp:Label ID="lblPasswordMessage" runat="server" Visible="false"></asp:Label>
            <%-- Current password --%>
            <div class="text-input">
                <div class="input-validation">
                    <asp:Label ID="lblPassword" runat="server" Text="Current Password"></asp:Label>
                    <asp:RequiredFieldValidator ID="requiredValidatorPassword" runat="server" ValidationGroup="password" ErrorMessage="Required*" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </div>
                <asp:TextBox ID="txtPassword" runat="server" type="password" placeholder="Enter your current password here"></asp:TextBox>
            </div>
            <%-- New password --%>
            <div class="text-input">
                <div class="input-validation">
                    <asp:Label ID="lblNewPassword" runat="server" Text="New Password"></asp:Label>
                    <div class="multiple-validation">
                        <asp:RequiredFieldValidator ID="requiredValidatorNewPassword" runat="server" ValidationGroup="password" ErrorMessage="Required*" ForeColor="Red" ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexValidatorNewPassword" runat="server" ValidationGroup="password" ErrorMessage="Must be at least 8 characters*" ControlToValidate="txtNewPassword" ForeColor="Red" ValidationExpression=".{8,}"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <asp:TextBox ID="txtNewPassword" runat="server" type="password" placeholder="Enter your new password here"></asp:TextBox>
            </div>
            <%-- Confirm new password --%>
            <div class="text-input">
                <div class="input-validation">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm New Password"></asp:Label>
                    <div class="multiple-validation">
                        <asp:RequiredFieldValidator ID="requiredValidatorConfirm" runat="server" ValidationGroup="password" ErrorMessage="Required*" ForeColor="Red" ControlToValidate="txtConfirm"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="compareValidatorConfirm" runat="server" ValidationGroup="password" ErrorMessage="Passwords don't match*" ForeColor="Red" ControlToValidate="txtConfirm" ControlToCompare="txtNewPassword"></asp:CompareValidator>
                    </div>
                </div>
                <asp:TextBox ID="txtConfirm" runat="server" type="password" placeholder="Confirm your new password here"></asp:TextBox>
            </div>
            <asp:Button ID="btnChangePassword" runat="server" ValidationGroup="password" Text="Change Password" CssClass="button" OnClick="btnChangePassword_Click" />
        </div>
    </div>
</asp:Content>

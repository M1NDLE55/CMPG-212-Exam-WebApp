<%@ Page Title="" Language="C#" MasterPageFile="~/dashboard/dashboard.Master" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="WebApp_44905165.dashboard.booking" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
    <title>Booking | Brighton Medical</title>
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="masterContent" runat="server">
    <div class="dashboard-form">
        <%-- Main content --%>
        <div id="content" runat="server">
            <h2>Book an Appointment</h2>
            <div class="card">
                <%-- Dynamic error message --%>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <%-- Procedure --%>
                <div class="text-input dropdown">
                    <div class="input-validation">
                        <asp:Label ID="lblProcedure" runat="server" Text="Procedure"></asp:Label>
                        <asp:RequiredFieldValidator ID="requiredValidatorProcedure" runat="server" ErrorMessage="Required*" ForeColor="Red" ControlToValidate="ddlProcedure"></asp:RequiredFieldValidator>
                    </div>
                    <asp:DropDownList ID="ddlProcedure" runat="server"></asp:DropDownList>
                </div>
                <%-- Date --%>
                <div class="text-input">
                    <div class="input-validation">
                        <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                        <div class="multiple-validation">
                            <asp:RequiredFieldValidator ID="requiredValidatorDate" runat="server" ErrorMessage="Required*" ControlToValidate="txtDate" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rangeValidatorDate" runat="server" Type="Date" ErrorMessage="Select an upcoming date*" ForeColor="Red" ControlToValidate="txtDate"></asp:RangeValidator>
                        </div>
                    </div>
                    <asp:TextBox ID="txtDate" runat="server" type="date"></asp:TextBox>
                </div>
                <%-- Time --%>
                <div class="text-input dropdown">
                    <div class="input-validation">
                        <asp:Label ID="lblTime" runat="server" Text="Time"></asp:Label>
                        <asp:RequiredFieldValidator ID="requiredValidatorTime" runat="server" ErrorMessage="Required*" ForeColor="Red" ControlToValidate="ddlTime"></asp:RequiredFieldValidator>
                    </div>
                    <asp:DropDownList ID="ddlTime" runat="server"></asp:DropDownList>
                </div>
                <asp:Button ID="btnBook" runat="server" Text="Book Appointment" CssClass="button" OnClick="btnBook_Click" />
            </div>
        </div>
        <%-- Confirmation popup --%>
        <div id="confirmation" runat="server" visible="false">
            <h2>Appointment Booked</h2>
            <div class="card">
                <asp:Button ID="btnView" runat="server" Text="View Appointments" CssClass="button button-outline" OnClick="btnView_Click"/>
                <asp:Button ID="btnBookAnother" runat="server" Text="Book Another Appointment" CssClass="button" OnClick="btnBookAnother_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/dashboard/dashboard.Master" AutoEventWireup="true" CodeBehind="appointments.aspx.cs" Inherits="WebApp_44905165.dashboard.appointments" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
    <title>Appointments | Brighton Medical</title>
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="masterContent" runat="server">
    <div class="dashboard-form">
        <div id="content" runat="server">
            <h2>Upcoming Appointments</h2>
            <div class="card table-container">               
                <asp:GridView ID="gvAppointments" runat="server" AutoGenerateColumns="false" DataKeyNames="ID,Procedure,DateTime,Fee" Width="100%" CellPadding="8" HeaderStyle-BackColor="#7AE582" BorderWidth="0" GridLines="None" HeaderStyle-HorizontalAlign="Left" AlternatingRowStyle-BackColor="WhiteSmoke" OnRowCommand="gvAppointments_RowCommand" HeaderStyle-Wrap="false" HeaderStyle-Height="40">
                    <Columns>
                        <asp:BoundField DataField="Procedure" HeaderText="Procedure"/>
                        <asp:BoundField DataField="DateTime" HeaderText="Date and Time" />
                        <asp:BoundField DataField="Fee" HeaderText="Fee (R)" />
                        <asp:ButtonField ButtonType="Button" Text="Cancel" CommandName="Cancel_Click" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="button button-cancel table-button" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="details" runat="server" visible="false">
            <h2 style="margin-bottom: 16px;">Confirm Cancellation</h2>
            <div class="card">
                <asp:Literal ID="litDetails" runat="server"></asp:Literal>
                <asp:Button ID="btnKeep" runat="server" Text="Keep Appointment" CssClass="button button-outline" OnClick="btnKeep_Click"/>
                <asp:Button ID="btnConfirm" runat="server" Text="Cancel Appointment" CssClass="button button-cancel" OnClick="btnConfirm_Click"/>
            </div>
        </div>
        <div id="message" runat="server" visible="false" style="text-align:center">
            <h2>No Upcomming Appointments</h2>
        </div>
    </div>    
</asp:Content>

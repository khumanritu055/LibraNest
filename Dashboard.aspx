<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Dashboard</h2>
    <div class="stats">
        <div class="stat"><b><asp:Label ID="lblTitles" runat="server" /></b>Total Book Titles</div>
        <div class="stat"><b><asp:Label ID="lblStudents" runat="server" /></b>Registered Students</div>
        <div class="stat"><b><asp:Label ID="lblIssued" runat="server" /></b>Books Currently Issued</div>
        <div class="stat"><b><asp:Label ID="lblReturned" runat="server" /></b>Books Returned</div>
    </div>
    <br />
    <div class="card">
        <h2>Recent Activity</h2>
        <asp:GridView ID="gvRecent" runat="server" AutoGenerateColumns="false" CssClass="grid" GridLines="None" EmptyDataText="Abhi koi record nahi hai.">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="Student" />
                <asp:BoundField DataField="Title" HeaderText="Book" />
                <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" DataFormatString="{0:dd-MMM-yyyy}" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

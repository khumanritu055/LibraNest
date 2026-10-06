<%@ Page Title="Search Books" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2>Search Books</h2>
        <label>Title, Author ya Category likho</label>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click" />
        <asp:Button ID="btnAll" runat="server" Text="Show All" CssClass="btn btn-grey" OnClick="btnAll_Click" />
    </div>
    <div class="card">
        <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="false" CssClass="grid" GridLines="None" EmptyDataText="Koi book nahi mili.">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="Availability" HeaderText="Availability" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

<%@ Page Title="My Books" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyBooks.aspx.cs" Inherits="MyBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2>My Issued Books</h2>
        <asp:GridView ID="gvMy" runat="server" AutoGenerateColumns="false" CssClass="grid" GridLines="None" EmptyDataText="Aapne abhi tak koi book issue nahi ki.">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Book" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="IssueDate" HeaderText="Issued" DataFormatString="{0:dd-MMM-yyyy}" />
                <asp:BoundField DataField="DueDate" HeaderText="Due" DataFormatString="{0:dd-MMM-yyyy}" />
                <asp:BoundField DataField="ReturnDate" HeaderText="Returned" DataFormatString="{0:dd-MMM-yyyy}" NullDisplayText="-" />
                <asp:BoundField DataField="Fine" HeaderText="Fine (Rs.)" DataFormatString="{0:0.00}" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

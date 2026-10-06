<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Students.aspx.cs" Inherits="Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2>Registered Students</h2>
        <asp:Label ID="lblMsg" runat="server" CssClass="msg"></asp:Label>
        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="false" CssClass="grid" GridLines="None"
            OnRowCommand="gvStudents_RowCommand" EmptyDataText="Abhi koi student registered nahi hai.">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="ID" />
                <asp:BoundField DataField="FullName" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" Text="Delete" CommandName="DeleteStudent" CommandArgument='<%# Eval("UserId") %>'
                            OnClientClick="return confirm('Is student ko delete karna hai?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

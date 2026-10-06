<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card small-form">
        <h2>Student Registration</h2>
        <label>Full Name</label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="Name required" CssClass="error" Display="Dynamic" />
        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" CssClass="error" Display="Dynamic" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Valid email likho" CssClass="error" Display="Dynamic" />
        <label>Password</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="Password required" CssClass="error" Display="Dynamic" />
        <label>Confirm Password</label>
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator runat="server" ControlToValidate="txtConfirm" ControlToCompare="txtPassword" ErrorMessage="Passwords match nahi kar rahe" CssClass="error" Display="Dynamic" />
        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
        <asp:Label ID="lblMsg" runat="server" CssClass="msg"></asp:Label>
    </div>
</asp:Content>

<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card small-form">
        <h2>Login</h2>
        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" CssClass="error" Display="Dynamic" />
        <label>Password</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="Password required" CssClass="error" Display="Dynamic" />
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
        <asp:Label ID="lblMsg" runat="server" CssClass="msg error"></asp:Label>
        <p style="font-size:13px;color:#555;margin-top:18px;">
            Naye student ho? <a href="Register.aspx">Yahan register karo</a>
        </p>
    </div>
</asp:Content>

<%@ Page Title="Manage Books" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2>Add / Edit Book</h2>
        <asp:HiddenField ID="hfBookId" runat="server" />
        <div class="row2">
            <div>
                <label>Title</label>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle" ErrorMessage="Title required" CssClass="error" Display="Dynamic" />
            </div>
            <div>
                <label>Author</label>
                <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAuthor" ErrorMessage="Author required" CssClass="error" Display="Dynamic" />
            </div>
        </div>
        <div class="row2">
            <div>
                <label>Category</label>
                <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Quantity</label>
                <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtQty" ErrorMessage="Quantity required" CssClass="error" Display="Dynamic" />
            </div>
        </div>
        <asp:Button ID="btnSave" runat="server" Text="Save Book" CssClass="btn" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="btn btn-grey" CausesValidation="false" OnClick="btnCancel_Click" />
        <asp:Label ID="lblMsg" runat="server" CssClass="msg"></asp:Label>
    </div>

    <div class="card">
        <h2>All Books</h2>
        <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="false" CssClass="grid" GridLines="None"
            OnRowCommand="gvBooks_RowCommand" EmptyDataText="Koi book nahi mili.">
            <Columns>
                <asp:BoundField DataField="BookId" HeaderText="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="Quantity" HeaderText="Qty" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" Text="Edit" CommandName="EditBook" CommandArgument='<%# Eval("BookId") %>' CausesValidation="false" />
                        <asp:LinkButton runat="server" Text="Delete" CommandName="DeleteBook" CommandArgument='<%# Eval("BookId") %>' CausesValidation="false"
                            OnClientClick="return confirm('Kya aap ye book delete karna chahte ho?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

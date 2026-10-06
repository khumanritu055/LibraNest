<%@ Page Title="Issue / Return" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Issue.aspx.cs" Inherits="Issue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <h2>Issue a Book</h2>
        <div class="row2">
            <div>
                <label>Student</label>
                <asp:DropDownList ID="ddlStudent" runat="server"></asp:DropDownList>
            </div>
            <div>
                <label>Book (sirf available books)</label>
                <asp:DropDownList ID="ddlBook" runat="server"></asp:DropDownList>
            </div>
        </div>
        <asp:Button ID="btnIssue" runat="server" Text="Issue Book (14 days)" CssClass="btn" OnClick="btnIssue_Click" />
        <asp:Label ID="lblMsg" runat="server" CssClass="msg"></asp:Label>
    </div>

    <div class="card">
        <h2>Issue / Return Records</h2>
        <p style="font-size:13px;color:#555;">Late return par fine: Rs. 2 per day (due date ke baad).</p>
        <asp:GridView ID="gvIssued" runat="server" AutoGenerateColumns="false" CssClass="grid" GridLines="None"
            OnRowCommand="gvIssued_RowCommand" EmptyDataText="Abhi koi record nahi hai.">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="Student" />
                <asp:BoundField DataField="Title" HeaderText="Book" />
                <asp:BoundField DataField="IssueDate" HeaderText="Issued" DataFormatString="{0:dd-MMM-yyyy}" />
                <asp:BoundField DataField="DueDate" HeaderText="Due" DataFormatString="{0:dd-MMM-yyyy}" />
                <asp:BoundField DataField="ReturnDate" HeaderText="Returned" DataFormatString="{0:dd-MMM-yyyy}" NullDisplayText="-" />
                <asp:BoundField DataField="Fine" HeaderText="Fine (Rs.)" DataFormatString="{0:0.00}" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" Text="Return" CommandName="ReturnBook" CommandArgument='<%# Eval("IssueId") %>'
                            Visible='<%# Eval("Status").ToString() == "Issued" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

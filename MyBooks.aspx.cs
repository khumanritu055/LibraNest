using System;

public partial class MyBooks : UserPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        gvMy.DataSource = Db.GetTable(
            "SELECT b.Title, b.Author, i.IssueDate, i.DueDate, i.ReturnDate, i.Fine, i.Status " +
            "FROM IssuedBooks i JOIN Books b ON i.BookId=b.BookId " +
            "WHERE i.UserId=@u ORDER BY i.IssueId DESC",
            Db.P("@u", Convert.ToInt32(Session["UserId"])));
        gvMy.DataBind();
    }
}

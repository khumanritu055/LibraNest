using System;

public partial class Dashboard : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        lblTitles.Text = Convert.ToString(Db.Scalar("SELECT COUNT(*) FROM Books"));
        lblStudents.Text = Convert.ToString(Db.Scalar("SELECT COUNT(*) FROM Users WHERE Role='Student'"));
        lblIssued.Text = Convert.ToString(Db.Scalar("SELECT COUNT(*) FROM IssuedBooks WHERE Status='Issued'"));
        lblReturned.Text = Convert.ToString(Db.Scalar("SELECT COUNT(*) FROM IssuedBooks WHERE Status='Returned'"));

        gvRecent.DataSource = Db.GetTable(
            "SELECT TOP 10 u.FullName, b.Title, i.IssueDate, i.Status " +
            "FROM IssuedBooks i JOIN Users u ON i.UserId=u.UserId JOIN Books b ON i.BookId=b.BookId " +
            "ORDER BY i.IssueId DESC");
        gvRecent.DataBind();
    }
}

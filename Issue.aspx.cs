using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Issue : AdminPage
{
    const decimal FinePerDay = 2m;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropdowns();
            LoadRecords();
        }
    }

    void LoadDropdowns()
    {
        ddlStudent.DataSource = Db.GetTable("SELECT UserId, FullName + ' (' + Email + ')' AS Name FROM Users WHERE Role='Student' ORDER BY FullName");
        ddlStudent.DataTextField = "Name";
        ddlStudent.DataValueField = "UserId";
        ddlStudent.DataBind();
        ddlStudent.Items.Insert(0, new ListItem("-- Select Student --", ""));

        ddlBook.DataSource = Db.GetTable("SELECT BookId, Title + ' - ' + Author + ' (Available: ' + CAST(Quantity AS VARCHAR(10)) + ')' AS Name FROM Books WHERE Quantity > 0 ORDER BY Title");
        ddlBook.DataTextField = "Name";
        ddlBook.DataValueField = "BookId";
        ddlBook.DataBind();
        ddlBook.Items.Insert(0, new ListItem("-- Select Book --", ""));
    }

    void LoadRecords()
    {
        gvIssued.DataSource = Db.GetTable(
            "SELECT i.IssueId, u.FullName, b.Title, i.IssueDate, i.DueDate, i.ReturnDate, i.Fine, i.Status " +
            "FROM IssuedBooks i JOIN Users u ON i.UserId=u.UserId JOIN Books b ON i.BookId=b.BookId " +
            "ORDER BY i.IssueId DESC");
        gvIssued.DataBind();
    }

    void ShowMsg(string text, bool ok)
    {
        lblMsg.CssClass = ok ? "msg success" : "msg error";
        lblMsg.Text = text;
    }

    protected void btnIssue_Click(object sender, EventArgs e)
    {
        if (ddlStudent.SelectedValue == "" || ddlBook.SelectedValue == "")
        {
            ShowMsg("Pehle student aur book select karo.", false);
            return;
        }

        int userId = Convert.ToInt32(ddlStudent.SelectedValue);
        int bookId = Convert.ToInt32(ddlBook.SelectedValue);

        int already = Convert.ToInt32(Db.Scalar(
            "SELECT COUNT(*) FROM IssuedBooks WHERE UserId=@u AND BookId=@b AND Status='Issued'",
            Db.P("@u", userId), Db.P("@b", bookId)));
        if (already > 0)
        {
            ShowMsg("Ye book is student ko pehle se issue hai.", false);
            return;
        }

        Db.Execute(
            "INSERT INTO IssuedBooks (UserId, BookId, IssueDate, DueDate, Status) " +
            "VALUES (@u, @b, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE)), 'Issued')",
            Db.P("@u", userId), Db.P("@b", bookId));
        Db.Execute("UPDATE Books SET Quantity = Quantity - 1 WHERE BookId=@b", Db.P("@b", bookId));

        ShowMsg("Book issue ho gayi. Due date: 14 din baad.", true);
        LoadDropdowns();
        LoadRecords();
    }

    protected void gvIssued_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "ReturnBook") return;
        int issueId = Convert.ToInt32(e.CommandArgument);

        DataTable dt = Db.GetTable("SELECT BookId, DueDate FROM IssuedBooks WHERE IssueId=@i AND Status='Issued'", Db.P("@i", issueId));
        if (dt.Rows.Count == 0) return;

        int bookId = Convert.ToInt32(dt.Rows[0]["BookId"]);
        DateTime due = Convert.ToDateTime(dt.Rows[0]["DueDate"]);
        int lateDays = (DateTime.Today - due.Date).Days;
        decimal fine = lateDays > 0 ? lateDays * FinePerDay : 0m;

        Db.Execute("UPDATE IssuedBooks SET ReturnDate = CAST(GETDATE() AS DATE), Fine=@f, Status='Returned' WHERE IssueId=@i",
            Db.P("@f", fine), Db.P("@i", issueId));
        Db.Execute("UPDATE Books SET Quantity = Quantity + 1 WHERE BookId=@b", Db.P("@b", bookId));

        ShowMsg(fine > 0 ? "Book return ho gayi. Fine: Rs. " + fine.ToString("0.00") : "Book return ho gayi. Koi fine nahi.", true);
        LoadDropdowns();
        LoadRecords();
    }
}

using System;
using System.Web.UI.WebControls;

public partial class Students : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadStudents();
    }

    void LoadStudents()
    {
        gvStudents.DataSource = Db.GetTable("SELECT UserId, FullName, Email FROM Users WHERE Role='Student' ORDER BY FullName");
        gvStudents.DataBind();
    }

    protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "DeleteStudent") return;
        int id = Convert.ToInt32(e.CommandArgument);

        int used = Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM IssuedBooks WHERE UserId=@id", Db.P("@id", id)));
        if (used > 0)
        {
            lblMsg.CssClass = "msg error";
            lblMsg.Text = "Is student ka issue record maujood hai, isliye delete nahi ho sakta.";
            return;
        }

        Db.Execute("DELETE FROM Users WHERE UserId=@id AND Role='Student'", Db.P("@id", id));
        lblMsg.CssClass = "msg success";
        lblMsg.Text = "Student delete ho gaya.";
        LoadStudents();
    }
}

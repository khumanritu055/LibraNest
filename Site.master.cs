using System;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string role = Session["Role"] as string;
        string menu = "";

        if (role == "Admin")
        {
            menu += "<a href='Dashboard.aspx'>Dashboard</a>";
            menu += "<a href='Books.aspx'>Manage Books</a>";
            menu += "<a href='Students.aspx'>Students</a>";
            menu += "<a href='Issue.aspx'>Issue / Return</a>";
            menu += "<a href='Search.aspx'>Search Books</a>";
        }
        else if (role == "Student")
        {
            menu += "<a href='Search.aspx'>Search Books</a>";
            menu += "<a href='MyBooks.aspx'>My Books</a>";
        }
        else
        {
            menu += "<a href='Login.aspx'>Login</a>";
            menu += "<a href='Register.aspx'>Register</a>";
        }

        if (role != null)
            menu += "<a href='Logout.aspx'>Logout (" + Server.HtmlEncode(Convert.ToString(Session["FullName"])) + ")</a>";

        litMenu.Text = menu;
    }
}

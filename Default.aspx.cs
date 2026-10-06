using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string role = Session["Role"] as string;
        if (role == "Admin") Response.Redirect("Dashboard.aspx");
        else if (role == "Student") Response.Redirect("Search.aspx");
        else Response.Redirect("Login.aspx");
    }
}

using System;

// Sirf Admin ke liye pages
public class AdminPage : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        string role = Session["Role"] as string;
        if (role != "Admin") Response.Redirect("~/Login.aspx");
        base.OnInit(e);
    }
}

// Login kiye hue kisi bhi user ke liye pages
public class UserPage : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        if (Session["Role"] == null) Response.Redirect("~/Login.aspx");
        base.OnInit(e);
    }
}

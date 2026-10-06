using System;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        DataTable dt = Db.GetTable(
            "SELECT UserId, FullName, Role FROM Users " +
            "WHERE Email=@e AND Password=@p COLLATE Latin1_General_CS_AS",
            Db.P("@e", txtEmail.Text.Trim()),
            Db.P("@p", txtPassword.Text));

        if (dt.Rows.Count == 1)
        {
            Session["UserId"] = Convert.ToInt32(dt.Rows[0]["UserId"]);
            Session["FullName"] = dt.Rows[0]["FullName"].ToString();
            Session["Role"] = dt.Rows[0]["Role"].ToString();

            if (Session["Role"].ToString() == "Admin")
                Response.Redirect("Dashboard.aspx");
            else
                Response.Redirect("Search.aspx");
        }
        else
        {
            lblMsg.Text = "Invalid email or password.";
        }
    }
}

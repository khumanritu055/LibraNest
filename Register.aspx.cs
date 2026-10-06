using System;

public partial class Register : System.Web.UI.Page
{
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        string email = txtEmail.Text.Trim();
        int exists = Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM Users WHERE Email=@e", Db.P("@e", email)));

        if (exists > 0)
        {
            lblMsg.CssClass = "msg error";
            lblMsg.Text = "Ye email pehle se registered hai.";
            return;
        }

        Db.Execute("INSERT INTO Users (FullName, Email, Password, Role) VALUES (@n, @e, @p, 'Student')",
            Db.P("@n", txtName.Text.Trim()),
            Db.P("@e", email),
            Db.P("@p", txtPassword.Text));

        lblMsg.CssClass = "msg success";
        lblMsg.Text = "Registration successful! Ab <a href='Login.aspx'>login</a> karo.";
    }
}

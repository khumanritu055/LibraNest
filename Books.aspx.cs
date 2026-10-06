using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Books : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadBooks();
    }

    void LoadBooks()
    {
        gvBooks.DataSource = Db.GetTable("SELECT BookId, Title, Author, Category, Quantity FROM Books ORDER BY BookId DESC");
        gvBooks.DataBind();
    }

    void ShowMsg(string text, bool ok)
    {
        lblMsg.CssClass = ok ? "msg success" : "msg error";
        lblMsg.Text = text;
    }

    void ClearForm()
    {
        hfBookId.Value = "";
        txtTitle.Text = txtAuthor.Text = txtCategory.Text = txtQty.Text = "";
        btnSave.Text = "Save Book";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        int qty;
        if (!int.TryParse(txtQty.Text.Trim(), out qty) || qty < 0)
        {
            ShowMsg("Quantity ek valid number honi chahiye.", false);
            return;
        }

        if (hfBookId.Value == "")
        {
            Db.Execute("INSERT INTO Books (Title, Author, Category, Quantity) VALUES (@t, @a, @c, @q)",
                Db.P("@t", txtTitle.Text.Trim()), Db.P("@a", txtAuthor.Text.Trim()),
                Db.P("@c", txtCategory.Text.Trim()), Db.P("@q", qty));
            ShowMsg("Book add ho gayi.", true);
        }
        else
        {
            Db.Execute("UPDATE Books SET Title=@t, Author=@a, Category=@c, Quantity=@q WHERE BookId=@id",
                Db.P("@t", txtTitle.Text.Trim()), Db.P("@a", txtAuthor.Text.Trim()),
                Db.P("@c", txtCategory.Text.Trim()), Db.P("@q", qty),
                Db.P("@id", Convert.ToInt32(hfBookId.Value)));
            ShowMsg("Book update ho gayi.", true);
        }

        ClearForm();
        LoadBooks();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearForm();
        lblMsg.Text = "";
    }

    protected void gvBooks_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "EditBook" && e.CommandName != "DeleteBook") return;
        int id = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "EditBook")
        {
            DataTable dt = Db.GetTable("SELECT * FROM Books WHERE BookId=@id", Db.P("@id", id));
            if (dt.Rows.Count == 1)
            {
                hfBookId.Value = id.ToString();
                txtTitle.Text = dt.Rows[0]["Title"].ToString();
                txtAuthor.Text = dt.Rows[0]["Author"].ToString();
                txtCategory.Text = dt.Rows[0]["Category"].ToString();
                txtQty.Text = dt.Rows[0]["Quantity"].ToString();
                btnSave.Text = "Update Book";
                lblMsg.Text = "";
            }
        }
        else
        {
            int used = Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM IssuedBooks WHERE BookId=@id", Db.P("@id", id)));
            if (used > 0)
            {
                ShowMsg("Ye book delete nahi ho sakti kyunki iska issue record maujood hai.", false);
                return;
            }
            Db.Execute("DELETE FROM Books WHERE BookId=@id", Db.P("@id", id));
            ShowMsg("Book delete ho gayi.", true);
            LoadBooks();
        }
    }
}

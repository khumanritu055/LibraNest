using System;

public partial class Search : UserPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadBooks("");
    }

    void LoadBooks(string term)
    {
        gvBooks.DataSource = Db.GetTable(
            "SELECT Title, Author, Category, " +
            "CASE WHEN Quantity > 0 THEN 'Available (' + CAST(Quantity AS VARCHAR(10)) + ')' ELSE 'Not Available' END AS Availability " +
            "FROM Books WHERE Title LIKE @t OR Author LIKE @t OR Category LIKE @t ORDER BY Title",
            Db.P("@t", "%" + term + "%"));
        gvBooks.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadBooks(txtSearch.Text.Trim());
    }

    protected void btnAll_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        LoadBooks("");
    }
}

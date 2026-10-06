<%@ Application Language="C#" %>
<script runat="server">
    void Application_Start(object sender, EventArgs e)
    {
        // Pehli baar run par database + tables apne aap ban jayenge
        Db.EnsureDatabase();
    }
</script>

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

// Database helper class: saari pages isi se database use karti hain
public static class Db
{
    static string ConnStr
    {
        get { return ConfigurationManager.ConnectionStrings["LibraNestDB"].ConnectionString; }
    }

    public static SqlParameter P(string name, object value)
    {
        return new SqlParameter(name, value ?? DBNull.Value);
    }

    public static DataTable GetTable(string sql, params SqlParameter[] p)
    {
        using (SqlConnection con = new SqlConnection(ConnStr))
        using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
        {
            if (p != null) da.SelectCommand.Parameters.AddRange(p);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public static int Execute(string sql, params SqlParameter[] p)
    {
        using (SqlConnection con = new SqlConnection(ConnStr))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            if (p != null) cmd.Parameters.AddRange(p);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }

    public static object Scalar(string sql, params SqlParameter[] p)
    {
        using (SqlConnection con = new SqlConnection(ConnStr))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            if (p != null) cmd.Parameters.AddRange(p);
            con.Open();
            return cmd.ExecuteScalar();
        }
    }

    // Database aur tables na ho to apne aap bana deta hai (sample data ke saath)
    // LocalDB pehli baar start hone me der laga sakta hai, isliye 3 baar try karte hain
    public static void EnsureDatabase()
    {
        for (int attempt = 1; attempt <= 3; attempt++)
        {
            try { EnsureDatabaseOnce(); return; }
            catch (SqlException)
            {
                if (attempt == 3) throw;
                System.Threading.Thread.Sleep(3000);
            }
        }
    }

    static void EnsureDatabaseOnce()
    {
        SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(ConnStr);
        string dbName = b.InitialCatalog;
        b.InitialCatalog = "master";

        using (SqlConnection con = new SqlConnection(b.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("IF DB_ID(@n) IS NULL EXEC('CREATE DATABASE [' + @n + ']')", con))
        {
            cmd.Parameters.AddWithValue("@n", dbName);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        string setup = @"
IF OBJECT_ID('Users') IS NULL
BEGIN
    CREATE TABLE Users (
        UserId INT IDENTITY(1,1) PRIMARY KEY,
        FullName VARCHAR(100) NOT NULL,
        Email VARCHAR(100) NOT NULL UNIQUE,
        Password VARCHAR(50) NOT NULL,
        Role VARCHAR(10) NOT NULL);
    CREATE TABLE Books (
        BookId INT IDENTITY(1,1) PRIMARY KEY,
        Title VARCHAR(150) NOT NULL,
        Author VARCHAR(100) NOT NULL,
        Category VARCHAR(50),
        Quantity INT NOT NULL DEFAULT 1);
    CREATE TABLE IssuedBooks (
        IssueId INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
        BookId INT NOT NULL FOREIGN KEY REFERENCES Books(BookId),
        IssueDate DATE NOT NULL,
        DueDate DATE NOT NULL,
        ReturnDate DATE NULL,
        Fine DECIMAL(8,2) NOT NULL DEFAULT 0,
        Status VARCHAR(20) NOT NULL);
    INSERT INTO Users (FullName, Email, Password, Role) VALUES
        ('Library Admin','admin@libranest.com','admin123','Admin'),
        ('Riya Sharma','riya@gmail.com','riya123','Student'),
        ('Amit Patel','amit@gmail.com','amit123','Student');
    INSERT INTO Books (Title, Author, Category, Quantity) VALUES
        ('Programming in C','E. Balagurusamy','Programming',5),
        ('Let Us C','Yashavant Kanetkar','Programming',4),
        ('Database System Concepts','Silberschatz','Database',3),
        ('Computer Networks','Andrew Tanenbaum','Networking',2),
        ('ASP.NET Complete Reference','Matthew MacDonald','Web Development',3),
        ('Operating System Concepts','Galvin','Operating System',3),
        ('Data Structures Using C','Reema Thareja','Programming',4),
        ('Wings of Fire','A. P. J. Abdul Kalam','Biography',2);
END";
        Execute(setup);
    }
}

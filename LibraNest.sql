-- LibraNest : Library Management System (Database Script)
IF DB_ID('LibraNest') IS NULL CREATE DATABASE LibraNest;
GO
USE LibraNest;
GO
IF OBJECT_ID('IssuedBooks') IS NOT NULL DROP TABLE IssuedBooks;
IF OBJECT_ID('Books') IS NOT NULL DROP TABLE Books;
IF OBJECT_ID('Users') IS NOT NULL DROP TABLE Users;
GO
CREATE TABLE Users (
    UserId   INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email    VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(50)  NOT NULL,
    Role     VARCHAR(10)  NOT NULL   -- 'Admin' or 'Student'
);

CREATE TABLE Books (
    BookId   INT IDENTITY(1,1) PRIMARY KEY,
    Title    VARCHAR(150) NOT NULL,
    Author   VARCHAR(100) NOT NULL,
    Category VARCHAR(50),
    Quantity INT NOT NULL DEFAULT 1
);

CREATE TABLE IssuedBooks (
    IssueId    INT IDENTITY(1,1) PRIMARY KEY,
    UserId     INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    BookId     INT NOT NULL FOREIGN KEY REFERENCES Books(BookId),
    IssueDate  DATE NOT NULL,
    DueDate    DATE NOT NULL,
    ReturnDate DATE NULL,
    Fine       DECIMAL(8,2) NOT NULL DEFAULT 0,
    Status     VARCHAR(20) NOT NULL    -- 'Issued' or 'Returned'
);
GO
-- Sample data
INSERT INTO Users (FullName, Email, Password, Role) VALUES
('Library Admin', 'admin@libranest.com', 'admin123', 'Admin'),
('Riya Sharma',   'riya@gmail.com',      'riya123',  'Student'),
('Amit Patel',    'amit@gmail.com',      'amit123',  'Student');

INSERT INTO Books (Title, Author, Category, Quantity) VALUES
('Programming in C',            'E. Balagurusamy', 'Programming', 5),
('Let Us C',                    'Yashavant Kanetkar', 'Programming', 4),
('Database System Concepts',    'Silberschatz', 'Database', 3),
('Computer Networks',           'Andrew Tanenbaum', 'Networking', 2),
('ASP.NET Complete Reference',  'Matthew MacDonald', 'Web Development', 3),
('Operating System Concepts',   'Galvin', 'Operating System', 3),
('Data Structures Using C',     'Reema Thareja', 'Programming', 4),
('Wings of Fire',               'A. P. J. Abdul Kalam', 'Biography', 2);
GO

# LibraNest - Library Management System

A library management website for admins and students.

**Built with:** ASP.NET Web Forms (C#), SQL Server LocalDB

## Features
- Admin and student login, student registration
- Add and manage books, search books
- Issue and return books, "My books" page for students
- Student list and dashboard with counts

## How to run (Visual Studio)
1. Open Visual Studio and choose **File > Open > Web Site**.
2. Select this folder (the one that contains `Default.aspx` and `Web.config`).
3. Open `Default.aspx` and press **Ctrl + F5**.

The database `LibraNestDB` and its sample data are created automatically on the first run.
You need SQL Server LocalDB (it comes with the Visual Studio "ASP.NET and web development" workload).
The script `Database/LibraNest.sql` can also be run manually in SQL Server.

## Sample logins
| Role | Email | Password |
|---|---|---|
| Admin | admin@libranest.com | admin123 |
| Student | riya@gmail.com | riya123 |

Developed by Khuman Ritu

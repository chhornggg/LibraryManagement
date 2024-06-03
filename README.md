Since this project is created with the local SQL Server database. In order to run the project, We need to setup the local SQL Server Database on our own PC first.

1. In each of the .net windows form file, we need to edit the connection string to match our local SSMS.
2. Make sure the database 'library' is created and we need to run the SQL Scripts below to generate the corresponding tables inside our database:

  create table NewBook(
    bid int not null IDENTITY(1,1) primary key,
    bName varchar(250) not null,
    bAuthor varchar(250) not null,
    bPubl varchar(250) not null,
    bPDate varchar(250) not null,
    bPrice varchar(250) not null,
    bQuan bigint not null
    );

  create table IRBook(
    id int not null IDENTITY(1,1) primary key,
    std_enroll varchar(250) not null,
    std_name varchar(250) not null,
    std_dep varchar(250) not null,
    std_sem varchar(250) not null,
    std_contact bigint not null,
    std_email varchar(250) not null,
    book_name varchar(250) not null,
    book_issue_date varchar(250) not null,
    book_return_date varchar(250)
    )

3. Install the required packages in Visual Studio such as
   i, Microsoft.EntityFrameworkCore.SqlServer
   ii, System.Data.SqlClient
   iii, Microsoft.Data.SqlClient

4. Once all is done, We can now run the application without errors.
    

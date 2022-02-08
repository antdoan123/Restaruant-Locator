# Restaruant-Locator
A window application that allow users to create an account and search for food nearby.

![Woofr Snippet](https://github.com/antdoan123/Restaruant-Locator/blob/main/WoofrSnippet.png)

## Project Description

This project is mainly built using [C#](https://www.w3schools.com/cs/cs_intro.php) and [.NET framework](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet-framework). The following functionality are completed:

- Users may **create their own personal account**
- Users may **upload profile pictures, change password, and delete account**
- Users may **search for restaraunts nearby based on their prefercences**

The following functionality are still in progress:

- Users may **order delivery through 3rd-party**
- Users may **save their favorite restaurants** 

## Getting Started

To get started, we must install the following:

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)  - Ideal IDE for [C#](https://www.w3schools.com/cs/cs_intro.php) and [.NET framework](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet-framework)
- [LocalDB](https://www.sqlshack.com/install-microsoft-sql-server-express-localdb/) - Local database 

## Login Page

The login GUI was created with [C# Window Form Application](https://www.bing.com/search?q=c%23+window+form&qs=n&form=QBRE&sp=-1&pq=c%23+window+form&sc=5-14&sk=&cvid=AE1852B373264B22A778FF88CE3968A1). This allow us to easily design a Window user interface with the toolbox it provided. 

![login page](https://github.com/antdoan123/Restaruant-Locator/blob/main/WoofrLogin.png) 
![registratio page](https://github.com/antdoan123/Restaruant-Locator/blob/main/WoofrRegistration.png)

After creating the user interfaces, we had to add codes to make it functional. Now we had to set up our [LocalDB](https://www.sqlshack.com/install-microsoft-sql-server-express-localdb/). [LocalDB](https://www.sqlshack.com/install-microsoft-sql-server-express-localdb/) is a databased that starts on demand and runs in user mode. To set this up we had to create a table using [Microsoft Access](https://www.microsoft.com/en-us/microsoft-365/access
) Database. In order to do that we must initizaled an OleDBConnection as seen below:

`using System.Data.OleDb;`

OleDB is simply an open standard data access methodology which utilizes a set of Component Object Model (COM) interfaces for accessing and manipulating different types of data."[1](https://docs.oracle.com/en/database/oracle/oracle-data-access-components/19.3/oledb/introduction-to-oracle-provider-for-oledb.html#:~:text=Table%20of%20Contents%201%201.1%20Overview%20of%20OLE,OraOLEDB%20Installation.%20...%205%201.5%20Component%20Certifications.%20) With this, we are now able to store any type of binary data in the [Microsoft Access](https://www.microsoft.com/en-us/microsoft-365/access
) Table

![databased](https://github.com/antdoan123/Restaruant-Locator/blob/main/WoofrDB.png)

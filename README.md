# CRM Desktop Application

(Customer Relationship Management)

A simple CRM desktop application built using **C# Windows Forms** and **SQL Server**, following a basic **3-Tier Architecture** structure.

---

# Overview

This project is a **Customer Relationship Management (CRM) desktop application** designed to manage clients and system users.

The system allows users to store client information and control access to different parts of the application through user permissions.

The project was built **entirely by me from start to finish**, including:

* Database design
* Application architecture
* Business logic implementation
* Windows Forms user interface

The goal of this project was to practice **designing and implementing a structured desktop application using a multi-layer architecture**, while improving **backend development skills** and strengthening **problem-solving abilities when building multi-layered systems**.

---

# Architecture

The application follows a **3-Tier Architecture** to separate responsibilities between different layers.

## Presentation Layer (Windows Forms)

Handles the user interface and user interaction.

Examples include:

* Login screen
* Client management forms
* User management screens
* Basic validation before sending data to the business layer

The UI communicates with the database **only through the Business Layer**.

---

## Business Layer

Contains the core application logic.

Responsibilities include:

* Validating client data
* Managing application operations
* Handling permission checks
* Coordinating communication between UI and database

---

## Data Access Layer

Responsible for communicating with the **SQL Server database**.

Responsibilities include:

* Executing SQL queries
* Reading and writing data
* Managing database connections

This layer isolates database operations from the rest of the system.

---

# Main Features

## Login System

* User authentication
* Login validation using database records
* Permission-based access control

---

## User Management

* Add users
* Delete users
* Manage user permissions

---

## Client Management

* Add new clients
* Update client information
* Delete clients
* Search for clients

---

## Data Validation

* Basic input validation
* Prevent storing invalid data

---

# Database

The application uses a **SQL Server database**.

Main tables include:

## Clients

Stores customer information such as:

* ClientID
* ClientName
* Phone
* Email
* TotalOrders
* TotalPurchaseValue

---

## Users

Stores system users and their permissions:

* UserID
* UserName
* FullName
* Email
* Password
* Permissions

---

The database schema and sample data are included in:

```
Database/CRMproject.sql
```

Running this script will automatically create:

* The database
* All required tables
* Sample data for testing

---

# Technologies Used

* C#
* .NET Framework
* Windows Forms
* SQL Server
* ADO.NET
* 3-Tier Architecture

---

# Project Structure

The project is organized into multiple modules that separate UI forms, business logic, data access, settings, and database scripts.

```text
CRM Desktop Application
│
├── BusinessLayer
│   ├── ClsBusinessLayer.cs
│   └── BusinessLayer.csproj
│
├── ClsClient
│   ├── ClsClient.cs
│   └── ClsClient.csproj
│
├── ClsDataAccessSettings
│   ├── ClsDataAccessSettings.cs
│   └── ClsDataAccessSettings.csproj
│
├── ClsDataLayer
│   ├── ClsDataLayer.cs
│   └── ClsDataLayer.csproj
│
├── ClsUser_Person
│   ├── ClsUser.cs
│   └── related project files
│
├── Database
│   └── CRMproject.sql
│
├── Screenshots
│   ├── login.png
│   ├── add_user.png
│   ├── client_list.png
│   ├── remove_user.png
│   ├── search_client.png
│   └── user_roles.png
│
├── Settings
│   ├── Settings.cs
│   └── Settings.csproj
│
├── frmAddNewClient
├── frmAddNewUser
├── frmDeleteUser
├── frmFindUser
├── frmMainScreen
├── frmManageUsers
├── frmPermissions0
├── frmRemoveClient
├── frmSearchClient
├── frmUpdateClient(FindUser First)
├── frmUpdateClient
├── frmUpdateUser0
├── frmViewClients
├── frmViewUsers
│
├── App.config
├── CRM.sln
└── README.md
````

This structure reflects the project’s modular organization, where each form or functional area is separated into its own project or folder, while business logic and data access are isolated in dedicated layers.

````

# How to Run the Project

## 1. Clone the Repository

```
git clone https://github.com/TheNawafTech/CRM-WinForms-App.git
```

or download the project as a ZIP file.

---

## 2. Create the Database

Open **SQL Server Management Studio (SSMS)**.

Open the script located in:

```
Database/CRMproject.sql
```

Run the script to create the database and tables.

---

## 3. Configure the Connection String

Open:

```
App.config
```

Update the connection string according to your SQL Server configuration.

Example:

```xml
<connectionStrings>
  <add name="CRMConnection"
       connectionString="Server=.;Database=CRMproject;Trusted_Connection=True;"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

---

## 4. Open the Solution

Open the project in **Visual Studio**:

```
CRM.sln
```

---

## 5. Set the Startup Project

Inside **Visual Studio**:

1. Right click on:

```
CRM.WinForms
```

2. Select:

```
Set as Startup Project
```

---

## 6. Run the Application

Press:

```
F5
```

or click **Start** in Visual Studio.

---
## Screenshots

![Login](./Screenshots/login.png)

![Add User](./Screenshots/add_user.png)

![User Roles](./Screenshots/user_roles.png)

![Client List](./Screenshots/client_list.png)

![Search Client](./Screenshots/search_client.png)

![Remove User](./Screenshots/remove_user.png)
---

# Demo Video

https://bit.ly/CRM-System-Demo

---

# Troubleshooting

## Application cannot connect to database

Make sure:

* SQL Server is running
* The connection string in **App.config** is correct
* The database script was executed successfully

---

## Startup project error

If Visual Studio shows:

```
Class Library cannot be started directly
```

Set the startup project to:

```
CRM.WinForms
```

---

# Future Improvements

Possible future enhancements include:

* Implementing password hashing for improved security
* Expanding the permission management system
* Adding more advanced client search and filtering
* Improving the user interface design

---

# Developed By

**Nawaf Altowairqi**

GitHub
https://github.com/TheNawafTech

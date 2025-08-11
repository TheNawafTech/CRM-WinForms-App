# CRM System – Basic Version

This desktop application is designed to manage customer information and control user access through defined roles.  
The system was developed entirely from scratch without using any third-party libraries.

## Project Objective
To provide an organized and efficient way to manage customer data within teams, while implementing role-based access control to ensure proper authorization.

## Technologies Used
- Language: C# (.NET Framework)  
- User Interface: Windows Forms  
- Database: SQL Server  
- Platform: Windows Desktop Application  

## Screenshots
![Login](screenshots/login.png)  
![Add User](screenshots/add_user.png)  
![User Roles](screenshots/user_roles.png)  
![Client List](screenshots/client_list.png)  
![Search Client](screenshots/search_client.png)  
![Remove User](screenshots/remove_user.png)

## Demo Video
[Watch the demo](https://bit.ly/CRM-System-Demo)

## Project Structure
```
CRM-System/
├── Forms/              # Windows Forms (Login, Dashboard, Add Customer, User Roles, etc.)
├── DataAccess/         # SQL operations and database connection
├── Models/             # Data models (Customer, User, Role, etc.)
├── Helpers/            # Helper classes, enums for permissions, and utilities
├── Properties/         # Application settings and resources
├── screenshots/        # Screenshots used in the README
├── README.md           # Project documentation
├── CRM-System.sln      # Visual Studio solution file
├── CRM-System.csproj   # Project file
└── App.config          # Database connection string and settings
```

## Getting Started
1. Clone the repository.  
2. Open the `.sln` file in Visual Studio (2019 or later recommended).  
3. Update the SQL Server connection in `App.config`.  
4. Build and run the project.

## Feedback
For suggestions or feedback, please open an issue or contact directly.

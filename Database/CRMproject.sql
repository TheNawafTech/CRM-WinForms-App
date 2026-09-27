USE master;
GO

IF DB_ID('CRMproject') IS NULL
BEGIN
    CREATE DATABASE CRMproject;
END
GO

USE CRMproject;
GO

IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL
    DROP TABLE dbo.Orders;
GO

IF OBJECT_ID('dbo.Clients', 'U') IS NOT NULL
    DROP TABLE dbo.Clients;
GO

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
    DROP TABLE dbo.Users;
GO

CREATE TABLE dbo.Clients
(
    ClientID INT IDENTITY(1,1) NOT NULL,
    ClientName VARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    TotalOrders INT NOT NULL DEFAULT 0,
    TotalPurchaseValue DECIMAL(10,2) NOT NULL DEFAULT 0,
    CONSTRAINT PK_Clients PRIMARY KEY CLUSTERED (ClientID ASC),
    CONSTRAINT CK_Clients_Phone CHECK (Phone NOT LIKE '%[^0-9+() -]%')
);
GO

CREATE TABLE dbo.Users
(
    UserID INT IDENTITY(1,1) NOT NULL,
    UserName VARCHAR(30) NOT NULL,
    FullName NVARCHAR(50) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    [Password] VARCHAR(256) NOT NULL,
    Permissions VARCHAR(100) NOT NULL,
    CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (UserID ASC)
);
GO

CREATE TABLE dbo.Orders
(
    OrderID INT IDENTITY(1,1) NOT NULL,
    ClientID INT NOT NULL,
    UserID INT NOT NULL,
    OrderDate DATE NOT NULL,
    OrderName VARCHAR(100) NOT NULL,
    PurchaseAmount DECIMAL(10,2) NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT PK_Orders PRIMARY KEY CLUSTERED (OrderID ASC),
    CONSTRAINT FK_Orders_Clients FOREIGN KEY (ClientID) REFERENCES dbo.Clients(ClientID),
    CONSTRAINT FK_Orders_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID)
);
GO

SET IDENTITY_INSERT dbo.Clients ON;
GO

-- Fictitious demo records (example.com addresses, placeholder phone numbers).
INSERT INTO dbo.Clients (ClientID, ClientName, Phone, Email, TotalOrders, TotalPurchaseValue) VALUES
(1,   'Ahmed Demo',     '+966500000101', 'ahmed.demo@example.com',     4, 1850.00),
(2,   'Sara Demo',      '+966500000102', 'sara.demo@example.com',      2, 720.50),
(3,   'Khalid Sample',  '+966500000103', 'khalid.sample@example.com',  7, 3240.00),
(4,   'Noura Test',     '+966500000104', 'noura.test@example.com',     1, 150.00),
(5,   'Omar Demo',      '+966500000105', 'omar.demo@example.com',      3, 990.75),
(6,   'Layla Sample',   '+966500000106', 'layla.sample@example.com',   0, 0.00),
(7,   'Faisal Test',    '+966500000107', 'faisal.test@example.com',    5, 2100.00),
(8,   'Huda Demo',      '+966500000108', 'huda.demo@example.com',      2, 480.00),
(9,   'Yousef Sample',  '+966500000109', 'yousef.sample@example.com',  6, 2675.25),
(10,  'Reem Test',      '+966500000110', 'reem.test@example.com',      1, 300.00);

SET IDENTITY_INSERT dbo.Clients OFF;
GO

SET IDENTITY_INSERT dbo.Users ON;
GO

-- Demo accounts. Every demo account's password is Demo1234; only its PBKDF2-SHA256 hash is stored.
INSERT INTO dbo.Users (UserID, UserName, FullName, Email, [Password], Permissions) VALUES
(1, 'admin.demo',    N'Admin Demo',           'admin@example.com',    'PBKDF2-SHA256$100000$K1X+CW+h9F5NDdFEklkW0Q==$96pVr5BB7NUslQwhtgAMsWX5LBwI8ivUE/hmzPJ1s94=', 'All'),
(2, 'manager.demo',  N'Sara Manager Demo',    'manager@example.com',  'PBKDF2-SHA256$100000$EMMX844NFVaR7x0eqgq+rw==$vkaSnsi9TrmlRDyy1ThFfoTQHDd0bdxtED4bwrkEikE=', 'ListClients, AddNewClient, DeleteClient, UpdateClients, FindClient'),
(3, 'sales.demo',    N'Khalid Sales Sample',  'sales@example.com',    'PBKDF2-SHA256$100000$l3L2fC+DXoGNwv+ssOcc3g==$GVLPBLIPL2vK5AD2IjgUZPtNE3I/GiXIVOOiDxQrJ3k=', 'ListClients, AddNewClient, UpdateClients, FindClient'),
(4, 'viewer.demo',   N'Noura Viewer Test',    'viewer@example.com',   'PBKDF2-SHA256$100000$R9xIxvDEz8UvcAbVkQffsg==$8TAflx1X2HrnLeQaBm8WZ++qxMImjTLk58Ai9dDPxx4=', 'ListClients, FindClient'),
(5, 'support.demo',  N'Omar Support Demo',    'support@example.com',  'PBKDF2-SHA256$100000$wrCIgnEYrhtLmVslsdcPxA==$IypcDRuVCrix+q9iURpA0m6luj0Qm2f2O9ua1pZpqZs=', 'FindClient, ManageUsers');

SET IDENTITY_INSERT dbo.Users OFF;
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Addresses] (
    [Id] int NOT NULL IDENTITY,
    [Street1] nvarchar(max) NOT NULL,
    [Street2] nvarchar(max) NULL,
    [City] nvarchar(max) NOT NULL,
    [Zipcode] nvarchar(max) NOT NULL,
    [State] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([Id])
);

CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Profile_PIC] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);

CREATE TABLE [Payment_Type] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Payment_Type] PRIMARY KEY ([Id])
);

CREATE TABLE [ShoppingCarts] (
    [Id] int NOT NULL IDENTITY,
    [CustomerId] int NOT NULL,
    CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ShoppingCarts_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [User_Address] (
    [Id] int NOT NULL IDENTITY,
    [Customer_Id] int NOT NULL,
    [Address_Id] int NOT NULL,
    [IsDefaultAddress] bit NOT NULL,
    CONSTRAINT [PK_User_Address] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_User_Address_Addresses_Address_Id] FOREIGN KEY ([Address_Id]) REFERENCES [Addresses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_User_Address_Customers_Customer_Id] FOREIGN KEY ([Customer_Id]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [PaymentMethods] (
    [Id] int NOT NULL IDENTITY,
    [Payment_Type_Id] int NOT NULL,
    [Provider] nvarchar(max) NOT NULL,
    [AccountNumber] nvarchar(max) NOT NULL,
    [Expiry] nvarchar(max) NOT NULL,
    [IsDefault] bit NOT NULL,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PaymentMethods_Payment_Type_Payment_Type_Id] FOREIGN KEY ([Payment_Type_Id]) REFERENCES [Payment_Type] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Shopping_Cart_Item] (
    [Id] int NOT NULL IDENTITY,
    [Cart_Id] int NOT NULL,
    [ProductId] int NOT NULL,
    [ProductName] nvarchar(max) NOT NULL,
    [Qty] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Shopping_Cart_Item] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Shopping_Cart_Item_ShoppingCarts_Cart_Id] FOREIGN KEY ([Cart_Id]) REFERENCES [ShoppingCarts] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [Order_Date] datetime2 NOT NULL,
    [CustomerId] int NOT NULL,
    [CustomerName] nvarchar(max) NOT NULL,
    [PaymentMethodId] int NOT NULL,
    [PaymentName] nvarchar(max) NOT NULL,
    [ShippingAddress] nvarchar(max) NOT NULL,
    [ShippingMethod] nvarchar(max) NOT NULL,
    [BillAmount] decimal(18,2) NOT NULL,
    [Order_Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_PaymentMethods_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethods] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [OrderDetails] (
    [Id] int NOT NULL IDENTITY,
    [Order_Id] int NOT NULL,
    [Product_Id] int NOT NULL,
    [Product_Name] nvarchar(max) NOT NULL,
    [Qty] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Discount] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderDetails_Orders_Order_Id] FOREIGN KEY ([Order_Id]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_OrderDetails_Order_Id] ON [OrderDetails] ([Order_Id]);

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);

CREATE INDEX [IX_Orders_PaymentMethodId] ON [Orders] ([PaymentMethodId]);

CREATE INDEX [IX_PaymentMethods_Payment_Type_Id] ON [PaymentMethods] ([Payment_Type_Id]);

CREATE INDEX [IX_Shopping_Cart_Item_Cart_Id] ON [Shopping_Cart_Item] ([Cart_Id]);

CREATE INDEX [IX_ShoppingCarts_CustomerId] ON [ShoppingCarts] ([CustomerId]);

CREATE INDEX [IX_User_Address_Address_Id] ON [User_Address] ([Address_Id]);

CREATE INDEX [IX_User_Address_Customer_Id] ON [User_Address] ([Customer_Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609020458_InitialMigration', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609024600_InitialMigration-addforeign', N'9.0.5');

COMMIT;
GO


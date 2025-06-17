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
CREATE TABLE [Customer_Review] (
    [Id] int NOT NULL IDENTITY,
    [Customer_Id] int NOT NULL,
    [Customer_Name] nvarchar(max) NOT NULL,
    [Order_Id] int NOT NULL,
    [Order_Date] datetime2 NOT NULL,
    [Product_Id] int NOT NULL,
    [Product_Name] nvarchar(max) NOT NULL,
    [Rating_value] int NOT NULL,
    [Comment] nvarchar(max) NOT NULL,
    [Review_Date] datetime2 NOT NULL,
    CONSTRAINT [PK_Customer_Review] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609093631_ReviewInit', N'9.0.5');

COMMIT;
GO


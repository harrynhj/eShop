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
CREATE TABLE [promotionSales] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Discount] decimal(3,2) NOT NULL,
    [Start_Date] datetime2 NOT NULL,
    [End_Date] datetime2 NOT NULL,
    CONSTRAINT [PK_promotionSales] PRIMARY KEY ([Id])
);

CREATE TABLE [Promotion_Details] (
    [Id] int NOT NULL IDENTITY,
    [Promotion_Id] int NOT NULL,
    [Product_Category_Id] int NOT NULL,
    [Product_Category_Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Promotion_Details] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Promotion_Details_promotionSales_Promotion_Id] FOREIGN KEY ([Promotion_Id]) REFERENCES [promotionSales] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Promotion_Details_Promotion_Id] ON [Promotion_Details] ([Promotion_Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609100424_Init', N'9.0.5');

COMMIT;
GO


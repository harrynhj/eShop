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
CREATE TABLE [Regions] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY ([Id])
);

CREATE TABLE [Shippers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [EmailId] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Contact_Person] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Shippers] PRIMARY KEY ([Id])
);

CREATE TABLE [Shipper_Region] (
    [Region_Id] int NOT NULL,
    [Shipper_Id] int NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Shipper_Region] PRIMARY KEY ([Region_Id], [Shipper_Id]),
    CONSTRAINT [FK_Shipper_Region_Regions_Region_Id] FOREIGN KEY ([Region_Id]) REFERENCES [Regions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Shipper_Region_Shippers_Shipper_Id] FOREIGN KEY ([Shipper_Id]) REFERENCES [Shippers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Shipping_Details] (
    [Id] int NOT NULL IDENTITY,
    [Order_Id] int NOT NULL,
    [Shipper_Id] int NOT NULL,
    [Shipping_Status] nvarchar(max) NOT NULL,
    [Shipping_Number] nvarchar(max) NOT NULL,
    [ShipperId] int NULL,
    CONSTRAINT [PK_Shipping_Details] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Shipping_Details_Shippers_ShipperId] FOREIGN KEY ([ShipperId]) REFERENCES [Shippers] ([Id])
);

CREATE INDEX [IX_Shipper_Region_Shipper_Id] ON [Shipper_Region] ([Shipper_Id]);

CREATE INDEX [IX_Shipping_Details_ShipperId] ON [Shipping_Details] ([ShipperId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609091238_ShippingInit', N'9.0.5');

ALTER TABLE [Shipping_Details] DROP CONSTRAINT [FK_Shipping_Details_Shippers_ShipperId];

DROP INDEX [IX_Shipping_Details_ShipperId] ON [Shipping_Details];

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Shipping_Details]') AND [c].[name] = N'ShipperId');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Shipping_Details] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Shipping_Details] DROP COLUMN [ShipperId];

CREATE INDEX [IX_Shipping_Details_Shipper_Id] ON [Shipping_Details] ([Shipper_Id]);

ALTER TABLE [Shipping_Details] ADD CONSTRAINT [FK_Shipping_Details_Shippers_Shipper_Id] FOREIGN KEY ([Shipper_Id]) REFERENCES [Shippers] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609092025_ShippingInit1', N'9.0.5');

COMMIT;
GO


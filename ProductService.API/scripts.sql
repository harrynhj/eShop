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
CREATE TABLE [Product_Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Parent_Category_Id] int NULL,
    CONSTRAINT [PK_Product_Category] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Category_Product_Category_Parent_Category_Id] FOREIGN KEY ([Parent_Category_Id]) REFERENCES [Product_Category] ([Id])
);

CREATE TABLE [Category_Variation] (
    [Id] int NOT NULL IDENTITY,
    [Category_Id] int NOT NULL,
    [Variation_Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Category_Variation] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Category_Variation_Product_Category_Category_Id] FOREIGN KEY ([Category_Id]) REFERENCES [Product_Category] ([Id])
);

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [CategoryId] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Qty] int NOT NULL,
    [Product_Image] nvarchar(max) NOT NULL,
    [SKU] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Product_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Product_Category] ([Id])
);

CREATE TABLE [Variation_Value] (
    [Id] int NOT NULL IDENTITY,
    [VariationId] int NOT NULL,
    [Value] nvarchar(max) NOT NULL,
    [CategoryVariationId] int NOT NULL,
    CONSTRAINT [PK_Variation_Value] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Variation_Value_Category_Variation_CategoryVariationId] FOREIGN KEY ([CategoryVariationId]) REFERENCES [Category_Variation] ([Id])
);

CREATE TABLE [Product_variation_values] (
    [Product_Id] int NOT NULL,
    [Variation_value_id] int NOT NULL,
    [Product_Id1] int NOT NULL,
    CONSTRAINT [PK_Product_variation_values] PRIMARY KEY ([Product_Id], [Variation_value_id]),
    CONSTRAINT [FK_Product_variation_values_Products_Product_Id1] FOREIGN KEY ([Product_Id1]) REFERENCES [Products] ([Id]),
    CONSTRAINT [FK_Product_variation_values_Variation_Value_Variation_value_id] FOREIGN KEY ([Variation_value_id]) REFERENCES [Variation_Value] ([Id])
);

CREATE INDEX [IX_Category_Variation_Category_Id] ON [Category_Variation] ([Category_Id]);

CREATE INDEX [IX_Product_Category_Parent_Category_Id] ON [Product_Category] ([Parent_Category_Id]);

CREATE INDEX [IX_Product_variation_values_Product_Id1] ON [Product_variation_values] ([Product_Id1]);

CREATE INDEX [IX_Product_variation_values_Variation_value_id] ON [Product_variation_values] ([Variation_value_id]);

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);

CREATE INDEX [IX_Variation_Value_CategoryVariationId] ON [Variation_Value] ([CategoryVariationId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609084801_ProductInit', N'9.0.5');

ALTER TABLE [Product_variation_values] DROP CONSTRAINT [FK_Product_variation_values_Products_Product_Id1];

DROP INDEX [IX_Product_variation_values_Product_Id1] ON [Product_variation_values];

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Product_variation_values]') AND [c].[name] = N'Product_Id1');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Product_variation_values] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Product_variation_values] DROP COLUMN [Product_Id1];

ALTER TABLE [Product_variation_values] ADD CONSTRAINT [FK_Product_variation_values_Products_Product_Id] FOREIGN KEY ([Product_Id]) REFERENCES [Products] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609084911_ProductInit1', N'9.0.5');

EXEC sp_rename N'[Variation_Value].[VariationId]', N'Variation_Id', 'COLUMN';

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609090229_ProductInit2', N'9.0.5');

ALTER TABLE [Variation_Value] DROP CONSTRAINT [FK_Variation_Value_Category_Variation_CategoryVariationId];

EXEC sp_rename N'[Variation_Value].[CategoryVariationId]', N'Variation_Id1', 'COLUMN';

EXEC sp_rename N'[Variation_Value].[IX_Variation_Value_CategoryVariationId]', N'IX_Variation_Value_Variation_Id1', 'INDEX';

ALTER TABLE [Variation_Value] ADD CONSTRAINT [FK_Variation_Value_Category_Variation_Variation_Id1] FOREIGN KEY ([Variation_Id1]) REFERENCES [Category_Variation] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609090434_ProductInit3', N'9.0.5');

ALTER TABLE [Variation_Value] DROP CONSTRAINT [FK_Variation_Value_Category_Variation_Variation_Id1];

DROP INDEX [IX_Variation_Value_Variation_Id1] ON [Variation_Value];

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Variation_Value]') AND [c].[name] = N'Variation_Id1');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Variation_Value] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Variation_Value] DROP COLUMN [Variation_Id1];

CREATE INDEX [IX_Variation_Value_Variation_Id] ON [Variation_Value] ([Variation_Id]);

ALTER TABLE [Variation_Value] ADD CONSTRAINT [FK_Variation_Value_Category_Variation_Variation_Id] FOREIGN KEY ([Variation_Id]) REFERENCES [Category_Variation] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250609090509_ProductInit4', N'9.0.5');

COMMIT;
GO


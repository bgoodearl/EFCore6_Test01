USE EFCore6_test01_dev; --Database used for Migrations
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
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220520141506_CU6_M01_Courses')
BEGIN
    CREATE TABLE [Courses] (
        [CourseID] int NOT NULL IDENTITY,
        [Title] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Courses] PRIMARY KEY ([CourseID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220520141506_CU6_M01_Courses')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220520141506_CU6_M01_Courses', N'6.0.2');
END;
GO

COMMIT;
GO


USE EFCore6_test01; --Database used for tests - NOT for migrations
GO
Declare @UseMigrationHistory bit = 0;
--Declare @UseMigrationHistory bit = 1;

If ISNULL(@UseMigrationHistory,0) = 1 Begin

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
End;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Course] (
    [CourseID] int NOT NULL,
    [Title] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([CourseID])
);
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NOT NULL BEGIN
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220520145013_CU6_M01_Courses', N'6.0.2');
END;
GO

COMMIT;
GO


USE EFCore6_test01_dev; --Database used for Migrations
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220520151447_CU6_M02_AddCoursePresLookupPlus')
BEGIN
    CREATE TABLE [xLookups2cKey] (
        [Code] nvarchar(2) NOT NULL,
        [LookupTypeId] smallint NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [_SubType] smallint NOT NULL,
        CONSTRAINT [PK_xLookups2cKey] PRIMARY KEY ([LookupTypeId], [Code])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220520151447_CU6_M02_AddCoursePresLookupPlus')
BEGIN
    CREATE TABLE [xLookupTypes] (
        [Id] smallint NOT NULL,
        [TypeName] nvarchar(50) NOT NULL,
        [BaseTypeName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_xLookupTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220520151447_CU6_M02_AddCoursePresLookupPlus')
BEGIN
    CREATE TABLE [_coursesPresentationTypes] (
        [CourseID] int NOT NULL,
        [CoursePresentationTypesLookupTypeId] smallint NOT NULL,
        [CoursePresentationTypesCode] nvarchar(2) NOT NULL,
        CONSTRAINT [PK__coursesPresentationTypes] PRIMARY KEY ([CourseID], [CoursePresentationTypesLookupTypeId], [CoursePresentationTypesCode]),
        CONSTRAINT [FK__coursesPresentationTypes_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Course] ([CourseID]) ON DELETE CASCADE,
        CONSTRAINT [FK__coursesPresentationTypes_xLookups2cKey_CoursePresentationTypesLookupTypeId_CoursePresentationTypesCode] FOREIGN KEY ([CoursePresentationTypesLookupTypeId], [CoursePresentationTypesCode]) REFERENCES [xLookups2cKey] ([LookupTypeId], [Code]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220520151447_CU6_M02_AddCoursePresLookupPlus')
BEGIN
    CREATE INDEX [IX__coursesPresentationTypes_CoursePresentationTypesLookupTypeId_CoursePresentationTypesCode] ON [_coursesPresentationTypes] ([CoursePresentationTypesLookupTypeId], [CoursePresentationTypesCode]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220520151447_CU6_M02_AddCoursePresLookupPlus')
BEGIN
    CREATE UNIQUE INDEX [LookupTypeAndName] ON [xLookups2cKey] ([LookupTypeId], [Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220520151447_CU6_M02_AddCoursePresLookupPlus')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220520151447_CU6_M02_AddCoursePresLookupPlus', N'6.0.2');
END;
GO

COMMIT;
GO


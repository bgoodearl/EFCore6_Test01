USE EFCore6_test01; --Database used for tests - NOT for migrations
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [xLookups10cKey] (
    [Code] nvarchar(10) NOT NULL,
    [LookupTypeId] smallint NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [SortOrder] int NULL,
    [_SubType] smallint NOT NULL,
    CONSTRAINT [PK_xLookups10cKey] PRIMARY KEY ([LookupTypeId], [Code]),
    CONSTRAINT [FK_xLookups10cKey_xLookupTypes_LookupTypeId] FOREIGN KEY ([LookupTypeId]) REFERENCES [xLookupTypes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [_coursesTopics] (
    [CourseID] int NOT NULL,
    [CourseTopicsLookupTypeId] smallint NOT NULL,
    [CourseTopicsCode] nvarchar(10) NOT NULL,
    CONSTRAINT [PK__coursesTopics] PRIMARY KEY ([CourseID], [CourseTopicsLookupTypeId], [CourseTopicsCode]),
    CONSTRAINT [FK__coursesTopics_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Course] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK__coursesTopics_xLookups10cKey_CourseTopicsLookupTypeId_CourseTopicsCode] FOREIGN KEY ([CourseTopicsLookupTypeId], [CourseTopicsCode]) REFERENCES [xLookups10cKey] ([LookupTypeId], [Code]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX__coursesTopics_CourseTopicsLookupTypeId_CourseTopicsCode] ON [_coursesTopics] ([CourseTopicsLookupTypeId], [CourseTopicsCode]);
GO

CREATE UNIQUE INDEX [LookupTypeAndName] ON [xLookups10cKey] ([LookupTypeId], [Name]);
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NOT NULL BEGIN
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220527101710_CU6_M03_AddCourseTopicLookupPlus', N'6.0.2');
END;
GO

COMMIT;
GO


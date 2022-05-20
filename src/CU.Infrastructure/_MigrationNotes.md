# EF Core 6 Migrations Test Platform #1 - Migration Notes

## Migrations

Before running any migrations, copy appSettings.migrations.json from
`...\_configSource\src\CU.EFDataApp`
to `...\src\CU.EFDataApp` and update the connection string to point to
the test database used for building migrations.

### .NET EF Core 6 Package Manager Console

[Entity Framework Core tools reference - Package Manager Console in Visual Studio](https://docs.microsoft.com/en-us/ef/core/cli/powershell)

```powershell
get-help about_EntityFrameworkCore
```

Quick check of environment for Package Manager Console
```powershell
Get-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp
```
(add -verbose to the end of the command above to confirm the correct database and server)


### First Migration

#### CU6_M01_Courses
```powershell
Add-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp CU6_M01_Courses
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From 0 -To CU6_M01_Courses -output .\SqlScripts\Schema\CU6_M01_Courses_idempotent.sql -Idempotent
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From 0 -To CU6_M01_Courses -output .\SqlScripts\Schema\CU6_M01_Courses_2022.sql
```

#### CU6_M02_AddCoursePresLookupPlus
```powershell
Add-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp CU6_M02_AddCoursePresLookupPlus
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M01_Courses -To CU6_M02_AddCoursePresLookupPlus -output .\SqlScripts\Schema\CU6_M02_AddCoursePresLookupPlus_idempotent.sql -Idempotent
Script-Migration -Project CU.Infrastructure -StartupProject CU.EFDataApp -From CU6_M01_Courses -To CU6_M02_AddCoursePresLookupPlus -output .\SqlScripts\Schema\CU6_M02_AddCoursePresLookupPlus.sql
```


#### What's in Migrations

Migration                       | Details
-------------                   | ------------
CU6_M01_Courses                 | First migration - adds model Course, table Courses
CU6_M02_AddCoursePresLookupPlus | Added CoursePresentationType lookup for Course plus RandomLookupType

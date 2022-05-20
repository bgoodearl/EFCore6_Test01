# EF Core 6 Migrations Test Platform #1

This solution is a test platform for migrations with Entity Framework Core 6.

It uses an object model that is based on small parts of the object model found
in the repo [ContosoU_dn6_MVCB_Clean](https://github.com/bgoodearl/ContosoU_dn6_MVCB_Clean),
and in particular, from the branch "with_lookups2" [ContosoU_dn6_MVCB_Clean - with_lookups2](https://github.com/bgoodearl/ContosoU_dn6_MVCB_Clean/tree/with_lookups2).

## Developer Notes

[Dev Notes](./_docs/EFC6__DevNotes.md)<br/>

## IMPORTANT NOTES

### Initial setup after cloning repo or getting code in zip

Create an empty database.  This solution uses the name "EFCore6_test01_dev".

Copy `...\_ConfigSource\src\CU.EFDataApp\appsettings.migrations.json`
to `...\src\CU.EFDataApp` and modify connection string for your environment.

## Projects

Project Name                    | Description
-------------                   | ------------
ContosoUniversity.Models        | Persistent Data Object Models (Domain)
CU.EFDataApp                    | ASP.NET Core Web App used to run migrations
CU.Infrastructure               | Infrastructure, including Entity Framework DbContext, Repositories, and Migrations

# PoC

###
To Run the application, do the following steps:

1. Change the connection string to your Postgres database
2. Restore the packages and build the project
3. Run the migration: `dotnet ef database update --project src/Infrastructure/Infrastructure.csproj --startup-project src/Presentation/Presentation.csproj
`

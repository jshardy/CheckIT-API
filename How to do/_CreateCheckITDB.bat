@ECHO OFF
ECHO "Rebuilding CheckIT.db file only based on C# migration files."
..\dotnet ef database update
ECHO "Done"
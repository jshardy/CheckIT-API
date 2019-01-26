@ECHO OFF
SETLOCAL

SET COMMENT=%1

IF "%COMMENT%" == "" (
  GOTO usage
)
ECHO "Destroying and recreating C# DB Classes and Database."
..\dotnet ef database update 0
..\dotnet ef migrations remove
..\dotnet ef migrations add %COMMENT%
..\dotnet ef database update
ECHO "Done."

usage:
ECHO "ERROR:"
ECHO "Example: _Rebuild-DB.bat Comment_To_Add_For_C#_DB_Classes"
ECHO "This will rebuild the database from scratch."
@ECHO OFF
SETLOCAL

SET COMMENT=%1

IF "%COMMENT%" == "" (
  GOTO usage
)
ECHO "Adding model to C# Class migrations."
..\dotnet ef migrations add %COMMENT%
..\dotnet ef database update
ECHO "Done."

usage:
ECHO "ERROR:"
ECHO "Example: _Update-DB.bat Comment_To_Add_For_C#_DB_Classes"
ECHO "This should be run anytime models have changed."
ECHO "This is for adding colums and adding tables."
ECHO "If models have changed completely, meaning that whole tables"
ECHO "need to be dropped and recreated then run _Rebuild-DB.bat"
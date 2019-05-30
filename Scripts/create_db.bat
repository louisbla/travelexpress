@ECHO OFF

echo -------execution scripts create-------
cd Create
Sqlcmd -i .\CreateDatabase.sql .\CreateTable.sql
cd ../

echo -------execution scripts inserts-------
cd Inserts

for %%X in (*.sql) do (Sqlcmd -i .\%%X)
cd ../

echo ------execution scripts constraints-------
cd Constraints
Sqlcmd -i .\PrimaryKeys.sql .\ForeignKeys.sql
cd ../


pause




OSUSVT
======

This is the code for the Oregon State University Solar Vehicle Team's Racecar.
To-Do List:

  1) Sit down with Body Control Team and see what ports they're looking to use
  
  2) Start designing actual Interface
  
  3) Bring in Camera Feed
  
  4) Implement SQL shenanigans


How to Setup MySQL
------------------
*Just install with all the defaults, we probably do not need all of it but...
*When you are asked for the root password make it whatever you want.
*Running the main program will prompt you for the root password and try to configure the database.
**If it fails modify one of the files in the scripts folder and run it like so where 'OSUSVT' is root password.
[code]
	>>"C:\Program Files\MySQL\MySQL Server 5.6\bin\mysql.exe" -uroot -pOSUSVT < resetSQLtables.sql
[/code]
NOTE: Changing the name of the database at the top of the sql.cs file will not delete the database, thus you can keep separate copies (i.e. TELEMETRY_RACE1, TELEMETRY_TESTRACE...)
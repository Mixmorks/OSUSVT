OSUSVT
======
This is the code for the Oregon State University Solar Vehicle Team's Racecar.
To-Do List:

  1. Sit down with Body Control Team and see what the Arduino needs to do.
  2. Start designing actual Interface
  3. Create web interface for SQL data

How to Setup MySQL
------------------
* Install [MySQL](http://dev.mysql.com/downloads/windows/installer/) with all default settings.
* When asked for the root password, use 'OSUSVT' or whatevery password you want
* Running the main program for the first time will prompt you for the root password and try to configure the database.
  * If it fails modify one of the files in the scripts folder and run it like so where 'OSUSVT' is root password.
    ```
    "C:\Program Files\MySQL\MySQL Server 5.6\bin\mysql.exe" -uroot -pOSUSVT < resetSQLtables.sql
    ```

NOTE: Changing the name of the database at the top of the sql.cs file will not delete the database, thus you can keep separate copies (i.e. `TELEMETRY_RACE1`, `TELEMETRY_TEST_RACE`)

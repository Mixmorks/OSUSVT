# mysql -uroot -ppassword < resetSQLtables.sql
DROP USER 'OSUSVT';
DROP DATABASE telemetry;
FLUSH PRIVILEGES;
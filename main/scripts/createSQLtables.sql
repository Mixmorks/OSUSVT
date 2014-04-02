# mysql -uroot -ppassword < createSQLtables.sql
DROP DATABASE IF EXISTS telemetry;
CREATE DATABASE telemetry;
CREATE USER 'OSUSVT'@'%' IDENTIFIED BY 'ManBearPig';
GRANT ALL PRIVILEGES ON telemetry.* TO 'OSUSVT'@'%';
FLUSH PRIVILEGES;
#USE telemetry;
#CREATE TABLE IF NOT EXISTS gpsdata (RecDateTime DATETIME, Longitude TEXT, Latitude TEXT, Altitude TEXT);
OSUSVT Telemetry Server
=======================
##Link with MASTER Solar Car Database
1. Insure that the following settings are set in the Solar Car's MySQL config (Restart MySQL if you made changes)
  * Use MySQL Workbench or try `C:\ProgramData\MySQL\MySQL Server 5.6\my.ini`
```
log-bin = mysql-bin
server-id = 1
```
2. Insure that the USER and PASSWORD declared at the top of resetdatabase.bash match the remoteuser variables at the top of SQL.cs
3. Set a Static IP or get a work out a [Dynamic DNS](http://www.dnsdynamic.org/)
4. Run the code on the Solar Car at least once to create the user
```bash
sudo bash config-files/resetdatabase.bash [Hostname/IP of Solar Car]
```

##Setup New Server
This was mad for CentOS 6.5
###Install Packages
```
vim httpd git php-mysql php-devel php-gd php-pecl-memcache php-pspell php-snmp php-xmlrpc php-xml mod_ssl mysql-server wget unzip zip
```
###Do Basic Configuration
Make sure to install the same version that you have on the Master. To get the latest version [use the mysql yum repo](http://dev.mysql.com/doc/mysql-repo-excerpt/5.6/en/updating-yum-repo.html)
Open the Firewall for Web
```bash
sudo iptables -I INPUT -p tcp --dport 80 -j ACCEPT
sudo service iptables save
```
Turn on Important Services
```bash
chkconfig httpd on
chkconfig sshd on
chkconfig mysqld on
```
Clone the git repo (don't forget to setup a key `ssh-keygen -t rsa -C "Telemetry Server"`
```bash
# git clone https://github.com/Mixmorks/OSUSVT.git
git clone git@github.com:Mixmorks/OSUSVT.git
cd OSUSVT/server
```
Run the Setup Script
```bash
sudo bash config-files/setup.bash
```
Reboot The Server

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
###Force restart of Replication
The following commands stop the Slave IO Thread and Restart it, this might be useful if the car computer has been restarted or they have gotten out of sync.
```sql
STOP SLAVE IO_THREAD;
START SLAVE IO_THREAD;
```

##Setup New Server
This was made for CentOS 6.5
###Install Packages
```
vim httpd httpd-devel git mod_ssl wget unzip zip mod_wsgi python-devel python-virtualenv
```
Also Install the MySQL version that matches the car using [these instructions](https://www.digitalocean.com/community/articles/how-to-install-mysql-5-6-from-official-yum-repositories).

###OpenVPN
[This](https://www.digitalocean.com/community/articles/how-to-setup-and-configure-an-openvpn-server-on-centos-6) guide was followed almost to the letter. However, easy-rsa must be installed separately now.
1. Remember that OpenVPN GUI must be run as admin on clients
2. [Change Windows Firewall to allow ICMP Pings](http://technet.microsoft.com/en-us/library/cc749323(v=ws.10).aspx)

###Do Basic Configuration
Make sure to install the same version of MySQL that you have on the car. To get the latest version [use the mysql yum repo](http://dev.mysql.com/doc/mysql-repo-excerpt/5.6/en/updating-yum-repo.html)
Open the Firewall for Web
```bash
iptables -I INPUT -p tcp --dport 80 -j ACCEPT

# OpenVPN
iptables -A INPUT -i eth0 -m state --state NEW -p udp --dport 1194 -j ACCEPT
 
# Allow TUN interface connections to OpenVPN server
iptables -A INPUT -i tun+ -j ACCEPT
 
# Allow TUN interface connections to be forwarded through other interfaces
iptables -A FORWARD -i tun+ -j ACCEPT
iptables -A FORWARD -i tun+ -o eth0 -m state --state RELATED,ESTABLISHED -j ACCEPT
iptables -A FORWARD -i eth0 -o tun+ -m state --state RELATED,ESTABLISHED -j ACCEPT
 
# NAT the VPN client traffic to the internet
iptables -t nat -A POSTROUTING -s 10.8.0.0/24 -o eth0 -j MASQUERADE

service iptables save
vim /etc/sysctl.conf # net.ipv4.ip_forward = 1
sysctl -p
```
Turn on Important Services
```bash
chkconfig httpd on
chkconfig sshd on
chkconfig mysqld on
chkconfig openvpn on
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
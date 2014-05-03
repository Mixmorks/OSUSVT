#!/usr/bin/env bash
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )" &&
echo $DIR

mkdir -p /var/www/html/solarcar/ &&
chown solar:solar /var/www/html/solarcar/ &&
rsync -av $DIR/../solarcar-html-source/ /var/www/html/solarcar/ &&
ln -s /var/www/html/solarcar/ $DIR/../solarcar-html &&
echo "Web Directory Configured..." ||
echo "Failed to configure Web Directory..."

rm /etc/httpd/conf/httpd.conf &&
touch /etc/httpd/conf/httpd.conf &&
cat $DIR/httpd.conf >> /etc/httpd/conf/httpd.conf &&
echo "httpd.conf Coppied to /etc/httpd/conf/httpd.conf"

rm /etc/my.cnf &&
touch /etc/my.cnf &&
cat $DIR/my.cnf >> /etc/my.cnf &&
echo "my.cnf Coppied to /etc/my.cnf"



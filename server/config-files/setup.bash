#!/usr/bin/env bash
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )" &&
echo $DIR

rm /etc/my.cnf &&
touch /etc/my.cnf &&
cat $DIR/my.cnf >> /etc/my.cnf &&
echo "my.cnf Coppied to /etc/my.cnf"
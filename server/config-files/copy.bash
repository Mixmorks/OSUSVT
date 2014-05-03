#!/usr/bin/env bash
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )" &&
echo $DIR
rsync -av $DIR/../solarcar-html-source/ $DIR/../solarcar-html/ &&
echo "Directory Updated..."

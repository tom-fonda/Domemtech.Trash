#!/usr/bin/bash
version=""
version="--prerelease"
cd src
exes=`find . -name 'tr*.exe' | grep -v publish`
for i in $exes
do
	d=`echo $i | awk -F '/' '{print $2}'`
	cd $d
	tool=$d
	dotnet tool uninstall -g $tool $version > /dev/null 2>&1
	dotnet tool install -g $tool $version > /dev/null 2>&1
	$tool --version
	cd ..
done

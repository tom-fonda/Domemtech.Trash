#!/usr/bin/bash
version="0.20.13"
cd src
directories=`find . -maxdepth 1 -type d -name "tr*"`
cwd=`pwd`
dotnet tool install -g trxml2
for i in $directories
do
	echo $i
	if [ "$i" == "." ]
	then
		continue
	fi
	cd $cwd/$i
	if [[ "$?" != "0" ]]
	then
		continue
	fi
	csproj=`find . -maxdepth 1 -name '*.csproj'`
	if [[ "$csproj" == "" ]]
	then
		cd ..
		continue
	fi
	if [[ ! -f "$i.csproj" ]]
	then
		continue
	fi
	trxml2 "$i.csproj" | grep -i PackAsTool 2> /dev/null 1> /dev/null
	if [[ "$?" != "0" ]]
	then
		continue
	fi
	if [[ ! -f "readme.md" ]]
	then
		continue;
	fi
	echo $i
	rm -f asdfasdf
	cat *.csproj | sed -e "s%[<][Vv]ersion[>].*[<][/][Vv]ersion[>]%<Version\>$version</Version>%" > asdfasdf
	mv asdfasdf *.csproj	
	rm -f asdfasdf2
	touch readme.md
	cat readme.md | sed -e 's%^0[.][0-9]*[.][0-9]*.*$'"%$version"' Add performance testing to templates. Add -force option to trgen to generate a target. Dotnet 7.0 dependency; desc.xml replacement for pom.xml. NB: not all Trash tools supported yet.%' > asdfasdf2
	mv asdfasdf2 readme.md
	cd ..
done

for i in tragl
do
	echo $i
	if [ "$i" == "." ]
	then
		continue
	fi
	cd $cwd/$i
	if [[ "$?" != "0" ]]
	then
		continue
	fi
	csproj=`find . -maxdepth 1 -name '*.csproj'`
	if [[ "$csproj" == "" ]]
	then
		cd ..
		continue
	fi
	if [[ ! -f "$i.csproj" ]]
	then
		continue
	fi
	if [[ ! -f "readme.md" ]]
	then
		continue;
	fi
	echo $i
	rm -f asdfasdf
	cat *.csproj | sed -e "s%[<][Vv]ersion[>].*[<][/][Vv]ersion[>]%<Version\>$version</Version>%" > asdfasdf
	mv asdfasdf *.csproj	
	rm -f asdfasdf2
	touch readme.md
	cat readme.md | sed -e 's%^0[.][0-9]*[.][0-9]*.*$'"%$version"' Add performance testing to templates. Add -force option to trgen to generate a target. Dotnet 7.0 dependency; desc.xml replacement for pom.xml. NB: not all Trash tools supported yet.%' > asdfasdf2
	mv asdfasdf2 readme.md
	cd ..
done

for i in trgen trgen2
do
    pushd $i
	rm -f asdfasdf
	cat Command.cs | sed -e 's%public static string version = "[^"]*";%public static string version = "'$version'";%' > asdfasdf
	mv asdfasdf Command.cs
	popd
done

#!/bin/bash
# "Setting MSYS2_ARG_CONV_EXCL so that Trash XPaths do not get mutulated."
where=`dirname -- "$0"`
cd "$where"
rm -rf Generated
mkdir Generated
if [ "$#" -eq 1 ]; then
	what=$1
else
	what=.
fi
for i in `find $what -name '*.g4' | grep -v Generated | grep -v examples`
do
	echo $i
	bash find-non-frag-ref.sh $i >> Generated/output
done
dos2unix Generated/output
diff -r Gold Generated
if [ "$?" != "0" ]
then
	echo Test failed.
	exit 1
else
	echo Test succeeded.
fi

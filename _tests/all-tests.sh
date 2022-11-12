#!/bin/bash

#set +e
#set -x
export TERM=xterm-mono
export MSYS2_ARG_CONV_EXCL="*"
where=`dirname -- "$0"`
tests=`find "$where" -name test.sh | grep -v Generated | sort`
echo Tests in Trash: $tests
failed=()
for i in $tests
do
	bash $i
	result=$?
	if [ "$result" != 0 ]
	then
		failed+=($i)
	fi
done
if (( ${#failed[@]} != 0 ))
then
	echo Tests failed: $failed.
	exit 1
else
	echo Tests succeeded.
	exit 0
fi


#!/bin/bash

version=""
#version="--version 0.8.1"

for i in tranalyze trcombine trconvert trdelabel trdelete trdot trfold trfoldlit trformat trgen trgroup trinsert trjson trkleene trmvsr trparse trprint trrename trrup trsplit trsponge trst trstrip trtext trthompson trtokens trtree trunfold trungroup trwdog trxgrep trxml trxml2
do
	echo $i
	dotnet tool install -g $i $version
done

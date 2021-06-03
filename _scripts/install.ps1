# $version = "--version 0.8.1"
$apps = @('tranalyze','trcombine','trconvert','trdelabel','trdelete','trfold','trfoldlit','trgen','trgroup','trjson','trkleene','trmvsr','trparse','trprint','trrename','trst','trstrip','trtext','trtokens','trtree','trunfold','trungroup','trwdog','trxgrep','trxml','trxml2')
foreach ($i in $apps) {
	dotnet tool install -g $i $version
}

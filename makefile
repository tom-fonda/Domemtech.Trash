build:
	rm -rf */obj
	dotnet restore
	dotnet build

install:
	bash _scripts/uninstall.sh
	bash _scripts/install.sh

clean:
	rm -rf */obj */bin


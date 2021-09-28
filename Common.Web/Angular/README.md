# Sample Angular and .Net Core Web API Template

This is a template I use to quickly get projects going. The Authentication is derived from the .Net Identity library and integrated so I don't have to use the entire Identity Core SDK.

##

If you have Docker installed you can run the following command to get a SQL Server Database up and running:

    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123." --name db -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
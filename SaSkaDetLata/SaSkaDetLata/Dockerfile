FROM mcr.microsoft.com/dotnet/core/aspnet

WORKDIR /app
COPY /bin/Debug/netcoreapp2.2/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet SaSkaDetLata.dll
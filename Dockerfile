FROM mcr.microsoft.com/dotnet/sdk:6.0

EXPOSE 80

ENV HOME=/app

WORKDIR /app

COPY ./Bicistock/Bicistock/bin/Release/net6.0/linux-x64/ ./
COPY ./Bicistock/Bicistock/wwwroot/ ./wwwroot
COPY ./Bicistock/Bicistock/Rotativa ./Rotativa

ENTRYPOINT ["dotnet", "Bicistock.dll"]

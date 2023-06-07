FROM mcr.microsoft.com/dotnet/sdk:6.0

EXPOSE 80

ENV HOME=/app

WORKDIR /app

COPY ./Bicistock/Bicistock/bin/Release/net6.0/linux-x64/ ./
COPY ./Bicistock/Bicistock/wwwroot/ ./wwwroot

RUN git clone https://github.com/MatheusNCarvalho/wkhtmltox-0.12.4.git ./
RUN apt-get update && apt-get install -y \
    libxrender1 \
    libfontconfig1 \
    libxext6
RUN chmod 755 -R ./Rotativa

ENTRYPOINT ["dotnet", "Bicistock.dll"]

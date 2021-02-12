FROM mcr.microsoft.com/dotnet/core/sdk:3.1

ENV DEBIAN_FRONTEND=noninteractive
ENV APACHE_RUN_USER www-data
ENV APACHE_RUN_GROUP www-data
ENV APACHE_LOG_DIR /var/log/apache2
ENV APACHE_PID_FILE /var/run/apache2/apache2.pid
ENV APACHE_RUN_DIR /var/run/apache2
ENV APACHE_LOCK_DIR /var/lock/apache2
ENV APACHE_LOG_DIR /var/log/apache2
ENV ASPNETCORE_URLS=http://+:80

#install dependencies
RUN apt-get update && \
apt-get -y install apache2

#copy Tgimba .conf file to apache availab Tle site list
COPY Containerization/TgimbaApache.conf /etc/apache2/sites-available/
COPY . /build/
RUN cd /build && \
dotnet restore && \
dotnet build && \
dotnet publish -c Release -o /var/TgimbaApache -r win-x64 --self-contained false

#create some directories for environment variables (set in environment above)
RUN mkdir -p $APACHE_RUN_DIR
RUN mkdir -p $APACHE_LOCK_DIR
RUN mkdir -p $APACHE_LOG_DIR

RUN service apache2 restart

EXPOSE 80

CMD ["/usr/sbin/apache2", "-D", "FOREGROUND"]
WORKDIR /var/TgimbaApache/
ENTRYPOINT ["dotnet", "TgimbaNetCoreWeb.dll"]
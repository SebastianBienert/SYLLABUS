FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . /src
RUN chmod +x entrypoint.sh
RUN apt-get update
RUN apt-get install curl
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash
RUN apt-get install nodejs
RUN dotnet restore
RUN dotnet build
RUN dotnet publish --output app
RUN ls
RUN dotnet tool install --global dotnet-ef
RUN export PATH="$PATH:/root/.dotnet/tools"
RUN cat << \EOF >> ~/.bash_profile
ENV PATH "$PATH:/root/.dotnet/tools"
RUN echo "export PATH=/root/.dotnet/tools:${PATH}" >> /root/.bashrc
CMD /bin/bash entrypoint.sh

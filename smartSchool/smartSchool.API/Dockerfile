FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "smartSchool.API.dll"]



#docker build -t smartschool .  -> no diretorio
#docker run -d -p 5000:80 --name smartschool smartschool

# criando docker mysql com alguns param associando o container a um VOLUME (-v) | Em exercicio so funcionou sem o param "-e MYSQL_USER=root" -- não inserindo no docker-compose environment: - MYSQL_USER=root 
            
# docker container run -d --name mysql -p 3306:3306 -v dadosdb:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=senha -e bind-address:0.0.0.0 -e MYSQL_USER=root -e MYSQL_PASSWORD=senha -e MYSQL_ROOT_HOST=% mysql:5.7
# docker container start mysql   # se tiver mais, espeficiar.
#docker container exec -it mysql bash
# Assim inicializa via terminal
# mysql -u root -p
#Digite senha: senha
#> show databases;


###

# docker-compose up -d

# Apos gerar containers
# -> Inspecionar container do mysql e ir em "IPAddress": "x.x.x.x". Para checar em qual ip a rede do docker está usando para conectar, para assim, rodar o migrations neste ip para popular o BD.
# -> Deleta o container .NET e gere-o novamente docker-compose up -d para que assim o container tenha o IP correto e posteriormente pode-se gerar o dotnet migration databaseupdate (alterando string de conexao para localhost)
# e/ou rodar script para popular o BD.

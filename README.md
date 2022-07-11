# Arq-net-core
Projeto de bloco que reproduz uma pequena API Spotify. Autenticado por um IdentityServer.
Para utilização, inicialmente é necessário realizar a autenticação com as credenciais abaixo no IdentityServer (https://spotify-identity-server.azurewebsites.net/)

Usuário default:

Usr: admin@admin.com.br
Psw: 123123

Após recuperar o token válido, adicionar como Bearer no Postman para utilizar os endpoints da API (https://spotify-api-server.azurewebsites.net/swagger)

#Arquitetura utilizada:
• .NET 5
• DDD
• CQRS
• Entity Framework Core
• DevOps GitHub
• Azure Web Apps
• Azure SQL Server

#Diagrama de interfaces

![image](https://user-images.githubusercontent.com/10901140/178180730-f1a505a0-b9af-4df3-85b9-a34c96642247.png)

#Diagrama de classes

![image](https://user-images.githubusercontent.com/10901140/178180755-e1506ae5-0cfa-42ee-8308-946d5d70841a.png)



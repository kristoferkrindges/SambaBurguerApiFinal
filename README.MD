# Documentação API SambaBurguer

## Documentação

Api criada para a realização de um trabalho, solicitado na cadeira de Frameworks para Desenvolvimento Web 1, com a finalidade de manipular e fornecer dados a um Client criado em ReactJS.
[Link para acessar o Client(FrontEnd) da aplicação](https://github.com/kristoferkrindges/SambaBurguerClient)

## Breve Resumo:
O projeto será desenvolvido em formato de site corporativo na qual um usuário ADMIN irá realizar os cadastros, atualizações exclusões e exibições parciais dos dados
da respectiva empresa SambaBurguer.

## ENTIDADES da Api

1. Customer (Cliente) <br>
2. Employee (Funcionário) <br>
3. Product (Produto) <br>
4. Shop (Franquia) <br>
5. Sale (Venda)  <br>

## Relacionamentos e seus atributos das Entidades.
![Informações sobre Entidades](https://cdn.discordapp.com/attachments/1038889467689304137/1049055332716003429/relation_tables.png)

## Stack Tecnológico
Api criada em C# com uso do framework web ASPNET CORE 7
- ASPNET CORE 7
- C#
- SQLServer
- EntityFrameWorkCore
- Swagger

## Pacotes NuGets instalados
- Microsoft.EntityFrameworkCore (7.0.0)
- Microsoft.EntityFrameworkCore.Design (7.0.0)
- Microsoft.EntityFrameworkCore.SqlServer (7.0.0)
- Microsoft.EntityFrameworkCore.Tools (7.0.0)

## Url base com documentação no swagger
- https://localhost:7010/swagger/index.html
- https://localhost:7010/api/

## ENDPOINTS da API
Cada uma das entidades terá 5 endpoints que irão representar o CRUD ( GET, POST, PUT, DELETE)
- GET: https://localhost:7010/api/[NomeDaEntidade] (GetAll)
- GET: https://localhost:7010/api/[NomeDaEntidade]/id (GetForId)
- POST: https://localhost:7010/api/[NomeDaEntidade] (Add)
- PUT: https://localhost:7010/api/[NomeDaEntidade]/id (Update)
- DELETE: https://localhost:7010/api/[NomeDaEntidade]/id (Delete)

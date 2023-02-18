## Web API de Registro de Vendas, Produtos e Vendedores
Este é um projeto de Web API em .NET Core 6.0 que permite o registro de vendas, produtos e vendedores em um banco de dados MySQL. O projeto também utiliza Docker e conceitos de Domain Driven Design (DDD) para a organização do código.
## Funcionalidades
- Registro de vendas
- Registro de produtos
- Registro de vendedores
##  Configuração
- 1.Executar o comando no terminal na pasta raiz do projeto : 'docker-compose up -d'
- 2.Entrar na pasta Desafio.Infra e executar o comando : 'dotnet ef database update'
- 3.Remover o container apipayment_desafioapi e sua imagem.
- 4.Inspencionar o container do mysql e copiar o seu IpAdress.
- 5.Modificar a string de conexão da linha 23 do arquivo AppDbContext do projeto Desafio.Infra para  "Server=IpAdress da imagem do mysql; Port=3306; Database=LocalDatabase; User=root; Password=1234;"
- 6.Modificar a string de conexão da linha 24 do arquivo DependencyInjection do projeto Desafio.Infra para  "Server=IpAdress da imagem do mysql; Port=3306; Database=LocalDatabase; User=root; Password=1234;"
- 7.Executar o comando no terminal na pasta raiz do projeto : 'docker-compose up -d'

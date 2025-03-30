# Projeto Cadastro de Fornecedores (CRUD em C#) - By Vitor Siqueira

## Descrição do Projeto
Este projeto é um sistema de cadastro de fornecedores, onde é possível realizar as operações de CRUD
(Create, Read, Update e Delete) em um banco de dados MySQL. O projeto foi desenvolvido em C# e utiliza o
Windows Forms para a interface gráfica, além de realizar chamadas para a API ReceitaWS para buscar automaticamente
informações sobre os CNPJ dos fornecedores. O projeto foi desenvolvido como parte do processo seletivo da empresa
**Visual Software**.

## Instruções para Configuração e Execução

### Pré-requisitos
- .NET Framework 4.7.2
- Visual Studio 2022
- MySQL Server
- Acesso à Internet para consulta da API ReceitaWS

### Configuração

1. Clone o repositório: 
``` bash
	git clone https://github.com/VitorSiqueirr/avaliacao-tecnica-visualsoft
	cd avaliacao-tecnica-visualsoft
```

2. Configure o banco de dados MySQL:

    - Crie um banco de dados no MySQL. 
	- Caso queira utilizar as mesmas configurações do banco de dados que utilizei aqui esta o comando docker: `docker run -d --name mysql -e MYSQL_ROOT_PASSWORD=visualsoft -p 3306:3306 mysql:9.1.0`
    - Atualize a string de conexão no arquivo `Infrasctucture/SingletonDB.cs` com as informações do seu banco de dados, caso utilize um diferente do que eu fiz.
	- Execute o SQL que esta no arquivo `Database.sql` para criar a tabela de fornecedores.

3. Abra o projeto no Visual Studio 2022 e restaure as dependências:
```bash
	dotnet restore
	OU
	nuget restore
```

4. Compile o projeto:
```bash
	dotnet build
```

5. Execute o projeto:
```bash
	dotnet run
```


## Justificativa dos Padrões de Projeto Utilizados

### Factory Method
O padrão Factory Method é utilizado para encapsular a lógica de criação de objetos. No projeto, ele é usado na interface `IServiceAbstractFactory` e na classe `ServiceFactory`, que centralizam a criação das instâncias dos serviços de consulta de CNPJ e de banco de dados. Escolhi este padrão porque ele permite a criação isolada dos serviços, facilitando a manutenção e testes futuros.

### Padrão Repository
O padrão Repository é implementado na classe `FornecedorRepository`, que abstrai a lógica de acesso aos dados e fornece uma interface para interagir com o banco de dados. Escolhi este padrão porque ele separa a lógica de manipulação dos dados do restante da lógica de negócio, facilitando a compreensão do fluxo da aplicação e futuras alterações e testes do código.

### Padrão Singleton
O padrão Singleton é utilizado na classe `SingletonDB`, que garante que apenas uma instância da conexão com o banco de dados seja criada e compartilhada entre os serviços. Escolhi este padrão porque ele garante que a conexão seja reutilizada e evita a criação de múltiplas conexões, o que pode causar problemas de performance e concorrência.

## Vídeo Explicativo
[Link para o vídeo explicativo](https://link-para-o-video.com)

Neste vídeo, você encontrará:
- Uma visão geral do projeto
- Demonstração das funcionalidades implementadas
- Explicação sobre os padrões de projeto utilizados e justificativa para a escolha
- Instruções de configuração e execução

## Logging e Tratamento de Erros
O projeto utiliza a biblioteca **Serilog** para implementação de logs,
que são gravados em um arquivo e também exibidos na tela pelo MessageBox.
Os logs registram operações de consulta e cadastro, além de tratar erros de conexão 
com a API e exibir mensagens adequadas ao usuário.
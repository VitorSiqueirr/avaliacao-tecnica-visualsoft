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
	- Caso queira utilizar as mesmas configurações do banco de dados que utilizei, aqui está o comando Docker:  `docker run -d --name mysql -e MYSQL_ROOT_PASSWORD=visualsoft -p 3306:3306 mysql:9.1.0`
    - Atualize a string de conexão no arquivo `Connection/SingletonDB.cs` com as informações do seu banco de dados, caso utilize um diferente do que eu fiz.
	- Execute o seguinte SQL para criar as tabelas e banco de dados.
```sql
    -- Cria o banco de dados (se ainda não existir) utilizando backticks para identificar o nome com hífen
    CREATE DATABASE IF NOT EXISTS `avaliacao-tecnica`;
    USE `avaliacao-tecnica`;

    -- Cria a tabela de fornecedor
    CREATE TABLE fornecedor (
        id INT AUTO_INCREMENT PRIMARY KEY,
        razao_social VARCHAR(255) NOT NULL,
        cnpj VARCHAR(20) NOT NULL,
        telefone VARCHAR(20),
        email VARCHAR(100),
        responsavel VARCHAR(255)
    );

    -- Cria a tabela de endereços vinculada aos fornecedores
    CREATE TABLE endereco (
        id INT AUTO_INCREMENT PRIMARY KEY,
        fornecedor_id INT NOT NULL,
        logradouro VARCHAR(255),
        numero VARCHAR(20),
        bairro VARCHAR(100),
        cidade VARCHAR(100),
        estado VARCHAR(2),
        cep VARCHAR(20),
        CONSTRAINT fk_endereco_fornecedor FOREIGN KEY (fornecedor_id)
            REFERENCES fornecedor(id)
            ON DELETE CASCADE
    );
```

3. Abra o projeto no Visual Studio 2022 e restaure as dependências:
    - No Gerenciador de Soluções, clique com o botão direito no projeto e selecione `Restaurar Pacotes NuGet`.

4. Compile o projeto:
    - No Gerenciador de Soluções, clique com o botão direito no projeto e selecione `Compilar`.

5. Execute o projeto:
    - No Gerenciador de Soluções, clique com o botão direito no projeto e selecione `Depurar` > `Iniciar Sem Depuração`.


## Justificativa dos Padrões de Projeto Utilizados

### Factory Method
O padrão Factory Method é utilizado para encapsular a lógica de criação de objetos. No projeto, ele é usado na interface `IServiceAbstractFactory` e na classe `ServiceFactory`, que centralizam a criação das instâncias dos serviços de consulta de CNPJ e de banco de dados. Escolhi este padrão porque ele permite a criação isolada dos serviços, facilitando a manutenção e testes futuros.

### Repository
O padrão Repository é implementado na classe `FornecedorRepository`, que abstrai a lógica de acesso aos dados e fornece uma interface para interagir com o banco de dados. Escolhi este padrão porque ele separa a lógica de manipulação dos dados do restante da lógica de negócio, facilitando a compreensão do fluxo da aplicação e futuras alterações e testes do código.

### Singleton
O padrão Singleton é utilizado na classe `SingletonDB`, que garante que apenas uma instância da conexão com o banco de dados seja criada e compartilhada entre os serviços. Escolhi este padrão porque ele garante que a conexão seja reutilizada e evita a criação de múltiplas conexões, o que pode causar problemas de performance e concorrência.

## Vídeo Explicativo
[Link para o vídeo explicativo](https://drive.google.com/drive/folders/1Fe_EPdnRWB0kLJcj2tRKFgl9rY74w65w?usp=sharing)

Peço desculpas se a gravação do vídeo ficou um pouco travada. Meu computador não é otimizado para gravações de tela e sempre fica um pouco travado quando gravo pelo OBS.

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
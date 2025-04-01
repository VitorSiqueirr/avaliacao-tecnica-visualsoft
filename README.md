# Projeto Cadastro de Fornecedores (CRUD em C#) - By Vitor Siqueira

## Descri��o do Projeto
Este projeto � um sistema de cadastro de fornecedores, onde � poss�vel realizar as opera��es de CRUD
(Create, Read, Update e Delete) em um banco de dados MySQL. O projeto foi desenvolvido em C# e utiliza o
Windows Forms para a interface gr�fica, al�m de realizar chamadas para a API ReceitaWS para buscar automaticamente
informa��es sobre os CNPJ dos fornecedores. O projeto foi desenvolvido como parte do processo seletivo da empresa
**Visual Software**.

## Instru��es para Configura��o e Execu��o

### Pr�-requisitos
- .NET Framework 4.7.2
- Visual Studio 2022
- MySQL Server
- Acesso � Internet para consulta da API ReceitaWS

### Configura��o

1. Clone o reposit�rio: 
``` bash
	git clone https://github.com/VitorSiqueirr/avaliacao-tecnica-visualsoft
	cd avaliacao-tecnica-visualsoft
```

2. Configure o banco de dados MySQL:

    - Crie um banco de dados no MySQL. 
	- Caso queira utilizar as mesmas configura��es do banco de dados que utilizei, aqui est� o comando Docker:  `docker run -d --name mysql -e MYSQL_ROOT_PASSWORD=visualsoft -p 3306:3306�mysql:9.1.0`
    - Atualize a string de conex�o no arquivo `Connection/SingletonDB.cs` com as informa��es do seu banco de dados, caso utilize um diferente do que eu fiz.
	- Execute o seguinte SQL para criar as tabelas e banco de dados.
```sql
    -- Cria o banco de dados (se ainda n�o existir) utilizando backticks para identificar o nome com h�fen
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

    -- Cria a tabela de endere�os vinculada aos fornecedores
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

3. Abra o projeto no Visual Studio 2022 e restaure as depend�ncias:
    - No Gerenciador de Solu��es, clique com o bot�o direito no projeto e selecione `Restaurar Pacotes NuGet`.

4. Compile o projeto:
    - No Gerenciador de Solu��es, clique com o bot�o direito no projeto e selecione `Compilar`.

5. Execute o projeto:
    - No Gerenciador de Solu��es, clique com o bot�o direito no projeto e selecione `Depurar` > `Iniciar Sem Depura��o`.


## Justificativa dos Padr�es de Projeto Utilizados

### Factory Method
O padr�o Factory Method � utilizado para encapsular a l�gica de cria��o de objetos. No projeto, ele � usado na interface `IServiceAbstractFactory` e na classe `ServiceFactory`, que centralizam a cria��o das inst�ncias dos servi�os de consulta de CNPJ e de banco de dados. Escolhi este padr�o porque ele permite a cria��o isolada dos servi�os, facilitando a manuten��o e testes futuros.

### Repository
O padr�o Repository � implementado na classe `FornecedorRepository`, que abstrai a l�gica de acesso aos dados e fornece uma interface para interagir com o banco de dados. Escolhi este padr�o porque ele separa a l�gica de manipula��o dos dados do restante da l�gica de neg�cio, facilitando a compreens�o do fluxo da aplica��o e futuras altera��es e testes do c�digo.

### Singleton
O padr�o Singleton � utilizado na classe `SingletonDB`, que garante que apenas uma inst�ncia da conex�o com o banco de dados seja criada e compartilhada entre os servi�os. Escolhi este padr�o porque ele garante que a conex�o seja reutilizada e evita a cria��o de m�ltiplas conex�es, o que pode causar problemas de performance e concorr�ncia.

## V�deo Explicativo
[Link para o v�deo explicativo](https://drive.google.com/drive/folders/1Fe_EPdnRWB0kLJcj2tRKFgl9rY74w65w?usp=sharing)

Pe�o desculpas se a grava��o do v�deo ficou um pouco travada. Meu computador n�o � otimizado para grava��es de tela e sempre fica um pouco travado quando gravo pelo OBS.

Neste v�deo, voc� encontrar�:
- Uma vis�o geral do projeto
- Demonstra��o das funcionalidades implementadas
- Explica��o sobre os padr�es de projeto utilizados e justificativa para a escolha
- Instru��es de configura��o e execu��o

## Logging e Tratamento de Erros
O projeto utiliza a biblioteca **Serilog** para implementa��o de logs,
que s�o gravados em um arquivo e tamb�m exibidos na tela pelo MessageBox.
Os logs registram opera��es de consulta e cadastro, al�m de tratar erros de conex�o 
com a API e exibir mensagens adequadas ao usu�rio.
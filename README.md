# Desenvolvimento de Software III - Grupo 002

Repositório central do projeto

## Projeto: *4Web & Tabajara*
O presente projeto visa apresentar os casos de uso: 
- [T] UC001 - Realizar Compra;
- [T] UC002 - Receber Mercadoria;
- [D] UC003 - Realizar Venda;
- [D] UC004 - Controlar Faturamento;
- [A] UC005 - Gerar Ordem de Serviço;

*A = Aguardando, T = Teste, D = Desenvolvimento, E = Entregue*

### Membros do grupo:
* Aline Favretto
* Jonatan Carneiro da Silva
* Leonardo dos Santos Paula
* Samuel Locatelli

## Requisitos
- Microsoft Visual Studio (2015 ou 2017);
- Microsoft SQL Server

*Para esta documentação estou utilizando VS 2015 for Web e SQL Server 2014*

## Rodando a aplicação
Para executar o projeto, você deve:

1. Clonar este repositório utilizando a ferramenta git de sua preferência (estou utilizando o Team Explorer do próprio VS);
1. Abrir o arquivo do projeto (Dominio.sln);
1. Alterar a string de conexão com o MS SQLServer:
	1. Arquivos *Infraestrutura > App.config*, *Migrations > App.config* e **Web > Web.config**;
	1. Editar a "connectionString" conforme a configuração do banco local;
	1. É possível localizar o ServerName através do menu Tools > Add SQL Server, escolher "Local".
1. Rodar as migrations, que criará a base de dados, as tabelas e irá inserir os dados de teste:
	1. Acessar Tools > NuGet Package Manager > Package Manager Console;
	1. No terminal que abrirá, em Default project escolher "Migrations";
	1. Utilizar o comando PM>Update-Database -Verbose
1. Feito isto basta ~~cruzar os dedos~~ e rodar a aplicação;


![Logo da Unisinos](https://unisinosggj.files.wordpress.com/2015/01/logotipounisinos.png?w=222&h=152)

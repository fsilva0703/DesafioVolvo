# Projeto

DESAFIO VOLVO

## Descrição

- Controle e gerenciamento de caminhões VOLVO.
- O sistema está dividido em dois menus conforme imagem abaixo. 
  - No primeiro menu: "Cadastro de caminhõs" é possível fazer o cadastro de determinados modelos de caminhões VOLVO de acordo os critérios de aceite;
  - No segundo menu: "Gerenciamento de caminhões" é possível visualizar todos os caminhões cadastrados além de realizar edição e deleção dos mesmos;

![image](https://user-images.githubusercontent.com/2862975/125217273-9fdd8a00-e296-11eb-99e7-29dc9d345c02.png)

![image](https://user-images.githubusercontent.com/2862975/125217380-de734480-e296-11eb-980a-738d13162625.png)

![image](https://user-images.githubusercontent.com/2862975/125217394-e7641600-e296-11eb-80a4-98c01e9c8992.png)


### Pré-requisitos

Para executar o projeto, será necessário seguir os procedimentos abaixo:

- [Visual Studio: Para execução do projeto](https://visualstudio.microsoft.com/pt-br/vs/community/)

### Instalação

- Fazer um clone do repositório https://github.com/fsilva0703/DesafioVolvo/ e já com o projeto aberto no Visual Studio atualizar alguns componentes via Nuget caso necessário.

Por exemplo:

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Tools
```

## Recuros e funcionalidades

- O sistema foi desenvolvido exclusivamente em .NET Core 3.1;

- Base de dados local (SQLite);

- ORM para mapear as tabelas de base de dados;
  - "Migrations" para criação da base de dados; 
  - Criação da base de dados automática (sem a necessidade de utilizar algum comando adicional);

- Boas práticas de desenvolvimento

- Clean code.

## Testes Unitários

- Existe um projeto de teste unitário chamado DesafioVolvoTest, este faz o teste de algumas validações requerentes.
  - Validação da listagem dos modelos;
  - Validação da regra do ano atual para a fabricação;
  - Validação do ano/modelo; 

## Versão

1.0

## Autor

* **Fábio de Paula Silva** - [DesafioVolvo](https://github.com/fsilva0703/DesafioVolvo)

## Agradecimentos

- Gostaria de agradecer a oportunidade de poder participar do processo seletivo de uma empresa tão conceituada mundialmente.

## Licença

Não necessário


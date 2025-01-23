# Gestão Financeira : Controle Financeiro para um comerciante local

## Descrição
Este projeto tem como objetivo desenvolver o Backend de uma aplicação web para auxiliar comerciantes locais a terem um melhor controle do seu fluxo de caixa.

A solução oferece: Cadastro de lançamentos (débitos e créditos) e o cálculo do saldo consolidado diário.

## Funcionalidades
* **Cadastro de lançamentos:** Permite adicionar novos lançamentos, especificando o valor, data e tipo (débito ou crédito).
* **Consulta de lançamentos:** Permite filtrar e visualizar os lançamentos realizados.
* **Cálculo do saldo diário:** Calcula automaticamente o saldo final de cada dia com base nos lançamentos realizados.

## Tecnologias Utilizadas
* **Backend:** .NET 8, C#
* **Banco de dados:** PostgreSQL
* **Padrões de projeto:** Clean Architecture
* **Design Patterns:** Mediator, Repository
* **Outras tecnologias:** Docker, Postman

## Desenho da solução
![image](https://github.com/user-attachments/assets/1a27faf9-1b01-463d-bfca-4561991f67d3)

## Requisitos para a execução:
1. .NET 8 instalado na máquina
2. Docker instalado na máquina

## Execução
1. **Clone o repositório:**
   git clone https://github.com/gabrieldesantana/challenge-comerciante-arch-ms.git
2. **Acesse o diretorio:**
   challenge-comerciante-arch-ms
3. **Execute o comando:**
   docker-compose up -d
4. **Acesse o serviço de gerenciamento de lançamentos em:**
   [localhost:5001](http://localhost:5001/swagger/index.html)
5. **Acesse o serviço de consolidado diário em:**
   [localhost:5002](http://localhost:5001/swagger/index.html)   

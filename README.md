# Sobre

# 

Microserviço desenvolvido em .NET para automatizar o empacotamento de pedidos de uma loja de jogos, utilizando caixas pré-definidas e otimizando o uso do espaço.

---

## ✅ Funcionalidades

- Recebe pedidos com produtos e suas dimensões
- Calcula as caixas necessárias e quais produtos vão em cada uma
- Suporte a múltiplos pedidos por requisição
- Autenticação via JWT
- Documentação interativa com Swagger
- API e SQL Server rodando em Docker com `docker-compose`
- Testes automatizados com xUnit

---

## 📦 Caixas Disponíveis

- **Caixa 1:** 30 x 40 x 80 cm  
- **Caixa 2:** 80 x 50 x 40 cm  
- **Caixa 3:** 50 x 80 x 60 cm

---

## ⚙️ Pré-requisitos

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

---

## 🚀 Como rodar o projeto

### 1. Clone o repositório

```bash
git clone git@github.com:benicio227/Easybox-Code-Challenge.git
cd Easybox-Code-Challenge
```

---

## Rode o projeto com Docker
Execute o comando abaixo para construir e iniciar a aplicação com o banco de dados:
```bash
docker-compose up --build
```
- A API estará disponível em: http://localhost:5000
- A documentação Swagger estará em: http://localhost:5000/swagger

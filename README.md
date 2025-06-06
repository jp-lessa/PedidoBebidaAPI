# API de Pedidos de Bebidas

Esta API simula o fluxo de pedidos realizados por revendas de bebidas. Ela permite cadastrar revendas, registrar pedidos de clientes e gerar pedidos enviados ao fabricante.
## Como rodar

1. Clone o repositório:

```bash
git clone https://github.com/jp-lessa/PedidoBebidaAPI.git
```

2. Rode a aplicação.

3. Acesse o Swagger pra testar:
[https://localhost:7220/swagger/index.html](https://localhost:7220/swagger/index.html)

---

## Exemplos pra testar no Swagger

### POST /api/revenda

Cadastra uma revenda:

```json
{
  "cnpj": "08.456.123/0001-90",
  "razaoSocial": "Revenda Tropical Nordeste LTDA",
  "nomeFantasia": "Tropical Bebidas",
  "email": "contato@tropicalbebidas.com.br",
  "telefones": ["(85) 99876-1234", "(85) 98765-4321"],
  "contatos": [
    {
      "nome": "Marcos Almeida",
      "principal": true
    },
    {
      "nome": "Juliana Rocha",
      "principal": false
    }
  ],
  "enderecosEntrega": [
    {
      "rua": "Rua Professor Otávio Lobo",
      "numero": "256",
      "cidade": "Fortaleza",
      "estado": "CE",
      "cep": "60410-370"
    }
  ]
}

```

---

### GET /api/revenda

Lista todas as revendas cadastradas.

---

### POST /api/pedido/cliente

Cria um pedido de cliente:

```json
{
  "clienteId": "13245768",
  "itens": [
    {
      "produto": "Cerveja",
      "quantidade": 50
    },
    {
      "produto": "Refrigerante",
      "quantidade": 70
    }
  ]
}
```

---

### POST /api/pedido/revenda

Envia pedido da revenda pra API externa:

```json
{
  "cnpjRevenda": "08.456.123/0001-90",
  "itens": [
    {
      "produto": "Cerveja",
      "quantidade": 50
    },
    {
      "produto": "Refrigerante",
      "quantidade": 80
    }
  ]
}
```

Esse último faz chamada externa. Se a outra API, como é um endpoint que não existe, vai falhar mesmo. Então tem retry configurado com Polly para mostrar resiliencia e log com Serilog para observabilidade, feito apenas nos Services, mas posso incluir também nos controller, etc..

---

## Logs e Resiliencia

- Os logs da aplicação são feitos com Serilog e ficam salvos na pasta `/Logs`
- As requisições externas contam com política de retry usando Polly (3 tentativas automáticas em caso de falha)
---


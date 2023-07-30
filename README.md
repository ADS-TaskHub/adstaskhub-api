
# API ADS Task Hub

API da plataforma para gerenciar as tarefas dos alunos do Curso de Análise e Desenvolvimento de Sistemas da PUC Minas


## Instalação

##### 1. Clone o projeto:

```bash
  git clone https://github.com/kaykiletieri/adstaskhub-api.git
```
##### 2. Acesse o diretório do projeto:
```bash
cd Regulatorio
```

##### 3. Restaure as dependências:
```bash
dotnet restore
```

##### 4. Execute as migrações para criar o banco de dados:
```bash
dotnet ef database update
```

##### 5. Inicie a aplicação:
```bash
dotnet run
```
    
## Variáveis de Ambiente

Para rodar esse projeto, você vai precisar adicionar as seguintes variáveis de ambiente no seu appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=myserver;Database=mydatabase;User=myuser;Password=mypassword;"
  },
  "TokenSettings": {
    "HashKey": "yourhash"
  }
}
```


## Endpoints

#### Retorna todos os itens

```http
  GET /api/items
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `string` | **Obrigatório**. A chave da sua API |

#### Retorna um item

```http
  GET /api/items/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID do item que você quer |

#### add(num1, num2)

Recebe dois números e retorna a sua soma.


## Contribuindo

Se você deseja contribuir com este projeto, fique à vontade para enviar pull requests ou reportar problemas através das issues.

Esperamos que este projeto seja útil e que possamos melhorá-lo juntos. Obrigado por utilizar a API ADS TaskHub!


## Feedback

Se você tiver algum feedback, por favor nos deixe saber por meio de https://forms.gle/atdQrtPhvRC2rXAe7


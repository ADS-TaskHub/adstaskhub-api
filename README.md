
# API ADS Task Hub

API da plataforma para gerenciar as tarefas dos alunos do Curso de An�lise e Desenvolvimento de Sistemas da PUC Minas


## Instala��o

##### 1. Clone o projeto:

```bash
  git clone https://github.com/kaykiletieri/adstaskhub-api.git
```
##### 2. Acesse o diret�rio do projeto:
```bash
cd Regulatorio
```

##### 3. Restaure as depend�ncias:
```bash
dotnet restore
```

##### 4. Execute as migra��es para criar o banco de dados:
```bash
dotnet ef database update
```

##### 5. Inicie a aplica��o:
```bash
dotnet run
```
    
## Vari�veis de Ambiente

Para rodar esse projeto, voc� vai precisar adicionar as seguintes vari�veis de ambiente no seu appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=myserver;Database=mydatabase;User=myuser;Password=mypassword;"
  },
  "TokenSettings": {
      "HashKey": "yourhash"
    }
  }
}
```


## Endpoints

#### Retorna todos os itens

```http
  GET /api/items
```

| Par�metro   | Tipo       | Descri��o                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `string` | **Obrigat�rio**. A chave da sua API |

#### Retorna um item

```http
  GET /api/items/${id}
```

| Par�metro   | Tipo       | Descri��o                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigat�rio**. O ID do item que voc� quer |

#### add(num1, num2)

Recebe dois n�meros e retorna a sua soma.


## Contribuindo

Se voc� deseja contribuir com este projeto, fique � vontade para enviar pull requests ou reportar problemas atrav�s das issues.

Esperamos que este projeto seja �til e que possamos melhor�-lo juntos. Obrigado por utilizar a API ADS TaskHub!


## Feedback

Se voc� tiver algum feedback, por favor nos deixe saber por meio de https://forms.gle/atdQrtPhvRC2rXAe7


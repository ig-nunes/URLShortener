# URL Shortener

O URL Shortener é um projeto ASP.NET que permite encurtar URLs longas em URLs mais curtas, facilitando o compartilhamento e a memorização de links.

## Funcionalidades

- **Encurtamento de URLs**: O projeto permite que você envie uma URL longa e receba uma URL encurtada única.
- **Redirecionamento**: A URL encurtada redireciona automaticamente para a URL original.
- **Expiração de URLs**: As URLs encurtadas têm um prazo de validade e expiram após um período especificado.
- **Gerenciamento de URLs**: É possível listar todas as URLs encurtadas, bem como excluir URLs específicas.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construção de aplicativos web.
- **Entity Framework Core SQLite**: Biblioteca para acesso a banco de dados SQLite.
- **Swagger**: Ferramenta para documentação e teste de APIs.
- **C#**: Linguagem de programação utilizada no projeto.

## Configuração do Projeto

1. **Clonar o repositório**:
   ```bash
   git clone https://github.com/ig-nunes/URLShortener.git


## Instalação e Execução

### Instalar as dependências:

    ```bash
    cd url-shortener
    dotnet restore
    ```

## Executar o projeto

    ```bash
    dotnet run
    ```

## Acessar o Swagger

Abra o navegador e vá para [http://localhost:5048/swagger](http://localhost:5048/swagger) para acessar a documentação da API e testar os endpoints.

## Exemplo de Uso

- **POST /shorturl**: Envia uma URL longa e recebe uma URL encurtada.

  ```json
  {
    "url": "https://www.google.com"
  }

## Redirecionamento e Exclusão de URL

- **GET /shorturl/{urlRequest}**: Redireciona para a URL original a partir da URL encurtada.

- **DELETE /shorturl/{urlRequest}**: Deleta a URL encurtada especificada.

## Contribuição

Contribuições são bem-vindas! Para sugestões, melhorias ou correções, por favor, abra uma issue ou envie um pull request.

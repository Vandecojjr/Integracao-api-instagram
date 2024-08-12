# Integração com a API do instagram

Um API que integra com a Graph API do instagram e facilita a publicação e visualização de conteudos
no instagram.

## Instalação

Antes de suber o container configure as variaveis de ambiente do arquivo .ENV

```
GRAPHAPI_TOKEN=seu_token
GRAPHAPI_USERID=seu_userid
```
Para rodar a API basta seguir os comandos abaixo
e ela ficara disponivel na porta 8080.

Para acessar o swagger basta acessar a rota localhost/:8080/swagger/index.html

```sh
docker compose up -d
```
caso nao queria que a API tenha acesso ao swagger basta remover o seguinte comando do docker-compose.yml
```
- ASPNETCORE_ENVIRONMENT=Development
```
meu contato
(67) 9 9837-9388

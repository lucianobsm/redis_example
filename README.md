# redis_example

Este projeto é um exemplo simples de integração com o Redis usando C# (.NET), com suporte a Docker para facilitar o ambiente de desenvolvimento.


## 🧠 Como funciona?

A aplicação:


1. Verifica se tem dados no cache.
2. Faz uma chamada à API externa para buscar uma lista de dados (pokémons).
3. Salva a resposta no Redis com uma chave e um tempo de expiração de **5 minutos**.
4. Na próxima requisição, retorna os dados diretamente do cache se ainda estiverem válidos.
5. Após 5 minutos, revalida os dados com a API externa e atualiza o cache.

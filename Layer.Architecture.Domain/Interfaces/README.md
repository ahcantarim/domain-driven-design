## Interfaces

> Vamos declarar interfaces genéricas, as quais receberão um Generics para identificar a classe de domínio que está sendo tratada no momento, onde serão referente ao repositório de acesso a base de dados e ao serviço que conterá algumas regras de negócio.

> Na pasta destinada as interfaces, desenvolve-se as mesmas referentes a implementação de repositórios e serviços.

### IBaseRepository

Na interface IBaseRepository, é necessário informar apenas a entidade de domínio (TEntity).

### IBaseService

Já na interface IBaseService, além de informarmos a classe de domínio (TEntity) alguns métodos (Add, Update e Get) receberão mais alguns Generics, sendo:

- `TInputModel`: classe modelo responsável por receber os dados de entrada da API
- `TOutputModel`: classe modelo responsável por retornar os dados de uma requisição
- `TValidator`: classe que contém as validações necessárias para o nosso domínio específico
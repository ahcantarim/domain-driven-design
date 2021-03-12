## Infrastructure

> Camada para comunicação externa.

### Infrastructure.Data

> Responsável pela comunicação com banco de dados, realizando operações.

#### Context

Classe de contexto, responsável por conectar no banco de dados e, também, por fazer o mapeamento das tabelas do banco de dados nas entidades.

#### Mapping

Responsável pelo mapeamento, customizado, de entidade para o banco de dados. Podendo especificar o nome da tabela, campos, tipo de cada campo, etc.

#### Repository

Responsável por realizar operações no banco de dados (CRUD).
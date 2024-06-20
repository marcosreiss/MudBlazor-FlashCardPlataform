# Plataforma de Estudos com Flashcards

## Visão Geral
Este projeto é uma Plataforma de Estudos com Flashcards construída usando ASP.NET Minimal APIs e MudBlazor. A plataforma permite que os usuários criem, leiam, atualizem e excluam (CRUD) decks e cards (dentro dos decks). Esta aplicação foi projetada para ajudar os usuários a estudar e gerenciar seus flashcards de forma eficiente.

## Funcionalidades
- **Operações CRUD para Decks**: Criar, Ler, Atualizar e Excluir decks.
- **Operações CRUD para Cards**: Criar, Ler, Atualizar e Excluir cards dentro dos decks.
- **Interface Amigável**: Construída usando MudBlazor para um design moderno e responsivo.
- **API Minimalista**: Backend leve e eficiente usando ASP.NET Minimal APIs.

## Começando

### Pré-requisitos
- .NET 6.0 SDK ou superior
- Node.js (para dependências do frontend)
- Visual Studio ou qualquer outro IDE de sua preferência

## Tecnologias Utilizadas
- **Backend**: ASP.NET Minimal APIs, Entity Framework Core
- **Frontend**: MudBlazor
- **Banco de Dados**: MySql (ou qualquer banco de dados de sua preferência)

### Projeto Core
O projeto core está dividido nas seguintes partes:

- **Modelos**: Contém as definições das entidades do domínio, como Deck e Card.
- **Requests**: Contém classes específicas para cada entidade, usadas para receber dados nas operações de criação e atualização.
- **Responses**: Contém classes genéricas para respostas, incluindo mensagem, código de status e o dado em si.
- **Interfaces**: Define os contratos para os handlers, especificando as operações que podem ser realizadas em cada entidade.

### Projeto API
No projeto API temos:

- **Handlers**: Implementação das lógicas de negócio para lidar com o banco de dados e executar as operações definidas nas interfaces.
- **Endpoints**: Definição dos endpoints das APIs que expõem os serviços aos clientes. Cada endpoint é associado a um handler específico.

### Projeto Web
No projeto web temos:

- **Handlers**: Implementação de lógica para fazer requisições à API. Esses handlers consomem os endpoints da API para obter, criar, atualizar e deletar dados.
- **Páginas**: Contém os componentes e páginas da interface do usuário usando MudBlazor. Cada página é responsável por uma funcionalidade específica da aplicação.
- **Services**: Serviços auxiliares para a comunicação entre as páginas e os handlers.

## Contribuindo
1. Faça um fork do repositório.
2. Crie uma nova branch: `git checkout -b feature/sua-funcionalidade`.
3. Faça suas alterações e comite-as: `git commit -m 'Adicionar nova funcionalidade'`.
4. Envie para a branch: `git push origin feature/sua-funcionalidade`.
5. Envie um pull request.

## Contato
Para quaisquer dúvidas ou sugestões, entre em contato pelo e-mail [m.vinicius.sr11@gmail.com](mailto:m.vinicius.sr11@gmail.com).

---

Obrigado por usar nossa Plataforma de Estudos com Flashcards! Bons estudos!

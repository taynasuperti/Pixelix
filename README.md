# Pixelix – Loja Virtual de Sprites e Recursos para Jogos 
**ASP.NET Core · MVC · API REST · MySQL**

O Pixelix é uma loja virtual desenvolvida em ASP.NET Core MVC + API REST para a venda de sprites e assets nacionais.
A ideia surgiu durante o desenvolvimento do nosso TCC, quando percebemos a falta de sites brasileiros confiáveis, organizados e visualmente agradáveis para buscar referências ou comprar sprites.
Enquanto as plataformas internacionais eram confusas e visualmente poluídas, vimos a oportunidade de criar algo moderno, claro e acessível — valorizando artistas e facilitando o acesso a sprites de qualidade.

Assim nasceu o Pixelix — uma plataforma clara, moderna e dedicada ao universo de games, valorizando artistas e facilitando o acesso a sprites de qualidade.

---

## Funcionalidades

### CRUD Completo de Produtos
- **Create** – Cadastro de sprites com nome, descrição, preço, categoria e imagem  
- **Read** – Listagem pública e área administrativa  
- **Update** – Edição completa do produto 
- **Delete** – Exclusão do catálogo

### CRUD Completo de Categorias
- **Create** – Cadastro de novas categorias
- **Read** – Listagem com produtos associados 
- **Update** – Edição de categorias cadastradas
- **Delete** – Exclusão das categorias cadastradas

### Recursos Adicionais
- Sistema de autenticação com JWT (API)  
- Login, registro e sessões (MVC)  
- Área administrativa com controle de acesso  
- Upload de imagens via API  
- Visualização de sprites com detalhes
- Carrinho de compras (versão inicial) 
- Middleware de autenticação por sessão
- Consumo de API via HttpClient
- Layout moderno e organizado
- Documentação completa (Passos API.txt e Passos MVC.txt)
---

## Tecnologias Utilizadas

### Backend (API)

- **ASP.NET Core Web API 9.0**
- **Entity Framework Core 9.0** 
- **Pomelo.EntityFrameworkCore.MySql** 
- **JWT Authentication**
- **AutoMapper**
- **Middleware customizado de erros** 

### Frontend (MVC)

- **ASP.NET Core MVC 9.0**
- **Bootstrap 5** 
- **Razor Views** 
- **HttpClient**
- **Session Middleware**

### Outros

- **Upload via FileStream**
- **DTOs** 
- **Services com injeção de dependência** 

---

## Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- .NET SDK 9.0 ou superior
- MySQL Server 8.0+  
- MySQL Workbench – opcional  
- Visual Studio 2022 ou VS Code

---

## Instalação e Configuração

### 1. Clone o Repositório

```bash
git clone <url-do-repositorio>
cd Pixelix
```
#### Configurando a API

### 2. Configure a Connection String
No arquivo **Pixelix.API/appsettings.json**, ajuste de acordo com seu MySQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=pixelixdb;User=root;Password=suasenha;SslMode=None;"
  }
}
```

### Opções de Connection String:

Para MySQL local com root: 

```bash
Server=localhost;Database=pixelixdb;User=root;Password=1234;SslMode=None;
```

Para MySQL com outro usuário: 

```bash
Server=localhost;Database=pixelixdb;User=pixelix;Password=senha;SslMode=None;
```

Para MySQL remoto: 

```bash
Server=seu_servidor;Port=3306;Database=pixelixdb;User=usuario;Password=senha;
```


### Instale as Dependências
```bash
dotnet restore
```

### Instale a Ferramenta EF Core (se ainda não tiver)
```bash
dotnet tool install --global dotnet-ef
```

Ou atualize se já tiver instalado:

```bash
dotnet tool update --global dotnet-ef
```


### Criar migrations da API (MySQL):

```bash
dotnet ef migrations add InitialCreate
```

Aplique as migrations ao banco de dados:

```bash
dotnet ef database update
```

Este comando irá:

- Criar automaticamente o banco de dados pixelixdb no MySQL
- Criar todas as tabelas necessárias
- Popular o banco com dados iniciais (um usuário admin padrão)

### Execute a API

```bash
cd Pixelix.API
dotnet run
```
Ou, se estiver usando Visual Studio, pressione F5 para executar em modo debug.

A aplicação estará disponível em:
HTTPS: ```https://localhost:7058```

http: ```//localhost:5001```

(As portas exatas serão exibidas no console ao iniciar)

### Configurando o MVC

### 2. Configure a Connection String
No arquivo **Pixelix.UI/appsettings.json**, configure o endpoint da API:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7260/api"
  }
}
```

### Executar o MVC

```bash
cd Pixelix.UI
dotnet run
```

---

## Acesso Administrativo


### Credenciais Padrão
O sistema tem automaticamente um usuário administrador:

- Email: ```taynasuperti@gmail.com```
- Senha: ```123456```

### Acessar Área Administrativa

1- Acesse a aplicação

2- Clique em "Login" no menu superior

3- Use as credenciais acima

4- Você terá acesso ao painel administrativo

---

## Estrutura do Projeto


```
Pixelix/
│
├── Docs/
│   ├── Diagrama.png – Diagrama do banco e fluxo geral da aplicação
│   ├── Passos API.txt – Guia completo de configuração da API
│   └── Passos MVC.txt – Guia completo de configuração do projeto MVC (UI)
│
├── Pixelix.API/
│
│ ├── Controllers/
│ │   ├── AuthController.cs – Endpoints de autenticação, login e registro
│ │   ├── CategoriasController.cs – CRUD de categorias via API
│ │   └── ProdutosController.cs – CRUD de produtos via API
│
│ ├── DTOs/
│ │   ├── CategoriaDtos.cs – Modelos de transferência de dados para categorias
│ │   ├── ProdutoDtos.cs – Modelos de transferência de dados para produtos
│ │   └── UserDtos.cs – DTOs relacionados a usuários e autenticação
│
│ ├── Data/
│ │   └── AppDbContext.cs – Contexto do Entity Framework Core configurado para MySQL
│
│ ├── Helpers/
│ │   └── TranslateIdentityErrors.cs – Traduz erros do Identity para português
│
│ ├── Middleware/
│ │   └── ErrorHandlingMiddleware.cs – Captura exceções e retorna respostas JSON padronizadas
│
│ ├── Migrations/ – Migrations geradas pelo Entity Framework Core
│
│ ├── Models/
│ │   ├── Categoria.cs – Entidade Categoria (nome, imagem, produtos)
│ │   ├── Produto.cs – Entidade Produto com nome, descrição, preço e categoria
│ │   └── Usuario.cs – Entidade de usuário com suporte a autenticação JWT
│
│ ├── Properties/
│ │   └── launchSettings.json – Perfis de execução da API
│
│ ├── Services/
│ │   ├── Implementations/
│ │   │   ├── AuthService.cs – Registra, autentica e gera tokens para usuários
│ │   │   ├── FileService.cs – Upload e remoção de arquivos (imagens)
│ │   │   └── JwtService.cs – Gera tokens JWT com claims e configurações de segurança
│ │   │
│ │   └── Interfaces/
│ │       ├── IAuthService.cs – Contrato do serviço de autenticação
│ │       ├── IFileService.cs – Contrato do serviço de arquivos
│ │       └── IJwtService.cs – Contrato do gerador de tokens JWT
│
│ ├── wwwroot/
│ │   └── img/ – Diretório onde as imagens enviadas pela API são armazenadas
│
│ ├── Pixelix.API.csproj – Configurações e dependências do projeto API
│ ├── Pixelix.Api.http – Arquivo para testar endpoints diretamente via REST Client
│ ├── Program.cs – Configurações iniciais da API e registro de serviços
│ ├── appsettings.json – Configurações da aplicação, banco e JWT
│ └── appsettings.Development.json – Versão de desenvolvimento das configs
│
│
├── Pixelix.UI/
│
│ ├── Controllers/
│ │   ├── AdminController.cs – Painel administrativo e visão geral do sistema
│ │   ├── AuthController.cs – Login, registro, logout e validação
│ │   ├── CategoriasController.cs – Consome API para gerenciar categorias
│ │   ├── HomeController.cs – Páginas públicas (index, sprites, sobre)
│ │   └── ProdutosController.cs – Consome API para gerenciar produtos
│
│ ├── DTOs/
│ │   ├── AuthResponseDto.cs – Resposta de login contendo token e usuário
│ │   ├── CategoriaDto.cs – Dados recebidos da API sobre categorias
│ │   ├── ProdutoDto.cs – Dados recebidos da API sobre produtos
│ │   └── UserDto.cs – Dados do usuário autenticado
│
│ ├── Middleware/
│ │   └── SessionAuthMiddleware.cs – Protege rotas exigindo usuário logado
│
│ ├── Models/
│ │   ├── ApiSettings.cs – Configurações gerais da API consumida
│ │   └── ErrorViewModel.cs – Modelo para páginas de erro
│
│ ├── Properties/
│ │   └── launchSettings.json – Perfis de execução do projeto MVC
│
│ ├── Services/
│ │   ├── Implementations/
│ │   │   ├── AuthService.cs – Chama endpoints de autenticação da API
│ │   │   ├── BaseApiService.cs – Serviço base para chamadas HttpClient
│ │   │   ├── CategoriaService.cs – Consome API para categorias
│ │   │   ├── LojaService.cs – Lógica da loja (listagem de sprites)
│ │   │   ├── ProdutoService.cs – Consome API para produtos
│ │   │   └── UserContextService.cs – Armazena e acessa dados do usuário logado
│ │   │
│ │   └── Interfaces/
│ │       ├── IAuthService.cs – Contrato para autenticação do usuário no MVC
│ │       ├── ICategoriaService.cs – Contrato para operações de categorias via API
│ │       ├── ILojaService.cs – Contrato para lógica de exibição e listagem da loja
│ │       └── IProdutoService.cs – Interfaces dos serviços API
│
│ ├── ViewModels/
│ │   ├── CarrinhoVM.cs – Estrutura inicial do carrinho de compras
│ │   ├── CategoriaVM.cs – Dados formatados para exibição de categorias
│ │   ├── HomeVM.cs – Dados da página inicial
│ │   ├── LoginVM.cs – Dados da tela de login
│ │   ├── ProdutoVM.cs – Modelo exibido nas páginas de produtos
│ │   ├── RecuperarSenhaVM.cs – Dados da tela de recuperação de senha
│ │   ├── RegistroVM.cs – Dados da tela de registro de usuário
│ │   └── SpritesPageVm.cs – Dados da página de listagem de sprites
│
│ ├── Views/
│ │   ├── Admin/ – Painel administrativo
│ │   ├── Auth/ – Login, registro e recuperação de senha
│ │   ├── Categorias/ – Telas de criação, edição, listagem e exclusão
│ │   ├── Home/ – Páginas públicas (Index, Sobre, Sprites, Detalhes, Carrinho)
│ │   ├── Produtos/ – CRUD completo dos produtos
│ │   └── Shared/ – Layouts, partials e scripts de validação
│
│ ├── wwwroot/ – Arquivos estáticos do MVC (CSS, JS, imagens)
│
│ ├── MappingConfig.cs – Configura mapeamentos AutoMapper entre DTOs e VMs
│ ├── Pixelix.UI.csproj – Configurações e dependências do projeto MVC
│ ├── Program.cs – Configuração inicial e registro de serviços MVC
│ ├── appsettings.json – Configurações principais do MVC
│ └── appsettings.Development.json – Versão de desenvolvimento
│
└── Pixelix.sln – Solução principal contendo API + UI
└── README.md – Este arquivo
```
---

## Estrutura do Banco de Dados

**Categorias**

- Id (PK) 
- Nome
- CaminhoImagem
- Produtos (1:N)
  

**Produtos**

- Id (PK)
- Nome
- Descricao
- Preco
- CaminhoImagem
- CategoriaId (FK → Categorias)
- DataCadastro


**Usuarios**

- Id (PK)
- Nome
- Email
- SenhaHash
- Role (Admin/User)


---

## Como Usar

### Criar uma Nova Categoria

1- Faça login como administrador

2- No painel admin, clique em "Criar Nova Categoria"

3- Preencha os campos:
- Nome
- Imagem

4- Clique em "Criar"

### Criar um Novo Produto

1- Faça login como administrador

2- No painel admin, clique em "Criar Novo Produto"

3- Preencha os campos:
- Nome
- Imagem
- Descrição
- Preço
- Categoria

4- Clique em "Criar"


### Editar ou Excluir uma Categoria ou Produto

1- No painel admin, localize a categoria ou produto que deseja excluir

2- Clique em "Editar" ou "Excluir"

3- Confirme a ação

---

## Solução de Problemas

### Erro de Conexão com o MySQL
Problema: Unable to connect to MySQL
- Confirme User, Password e Database
- Verifique se o MySQL está rodando
- Tente:
``` bash
mysql -u root -p
```

- Verifique se o MySQL Server está rodando
- Confirme a connection string no ```appsettings.json```

### Erro ao executar migrations (utilizando o pomelo)

**Problema:** ```The model for context has pending changes```

**Solução:**

``` bash
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Imagens não aparecem
- Confirme o caminho salvo no banco
- Verifique wwwroot/img na API
- Confirme que o FileService está devolvendo o caminho correto

  
---

## Metodologia e Arquitetura

Desenvolvido utilizando:

- Metodologia **SCRUM** de desenvolvimento ágil  
- Arquitetura **MVC (Model-View-Controller)** + **API REST**
- **DTOs** entre API ↔ MVC
- **HttpClient Services**
- **JWT** para autenticação
- **Injeção de Dependência**
- Separação em camadas seguindo boas práticas do ASP.NET Core

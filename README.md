# 🍕 ContosoPizza API

![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-10.0-blue)
![License](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-Em_Desenvolvimento-yellow)

Uma API Web moderna construída com ASP.NET Core 10.0 que fornece previsões do tempo e serve como base para o sistema ContosoPizza.

## 📋 Sobre o Projeto

Este projeto é uma aplicação ASP.NET Core que demonstra:
- Criação de APIs Web com controladores
- Documentação automática com OpenAPI/Swagger
- Consumo de API via frontend Razor Pages
- Configurações diferenciadas por ambiente (Development/Production)

### ✨ Funcionalidades Principais

- **API WeatherForecast**: Endpoint RESTful que retorna previsões do tempo simuladas
- **Documentação OpenAPI**: Documentação interativa disponível via Swagger UI
- **Página Web Frontend**: Interface amigável para consumir e visualizar os dados da API
- **Configuração Multi-Ambiente**: Configurações específicas para desenvolvimento e produção
- **HTTPS Redirection**: Segurança com redirecionamento automático para HTTPS

## 🚀 Começando

### Pré-requisitos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0)
- IDE (Visual Studio 2022+, VS Code, ou JetBrains Rider)
- Git (para controle de versão)

### Instalação

1. **Clone o repositório**
   ```bash
   git clone https://github.com/seu-usuario/ContosoPizza.git
   cd ContosoPizza
   ```

2. **Restaurar pacotes NuGet**
   ```bash
   dotnet restore
   ```

3. **Execute a aplicação**
   ```bash
   dotnet run
   ```
   Ou, para desenvolvimento com recarga automática:
   ```bash
   dotnet watch run
   ```

4. **Acesse os endpoints:**
   - 🌐 **Página Web**: `https://localhost:7229` ou `http://localhost:5225`
   - 📖 **Swagger UI**: `https://localhost:7229/swagger`
   - 📡 **API Direct**: `https://localhost:7229/WeatherForecast`

## 🏗️ Estrutura do Projeto

```
ContosoPizza/
├── Controllers/           # Controladores da API
│   └── WeatherForecastController.cs
├── Pages/                 # Páginas Razor (Frontend)
│   └── Home/
│       ├── Index.cshtml
│       └── Index.cshtml.cs
├── wwwroot/               # Arquivos estáticos (CSS, JS, imagens)
│   └── css/
│       └── site.css
├── Program.cs             # Ponto de entrada e configuração
├── appsettings.json       # Configurações gerais
├── appsettings.Development.json # Configurações de desenvolvimento
├── ContosoPizza.csproj    # Arquivo de projeto
└── README.md              # Este arquivo
```

## 🔧 Configuração

### Ambientes
- **Development**: Configurações locais com logging detalhado
- **Production**: Configurações otimizadas para produção

### Arquivos de Configuração
- `appsettings.json`: Configurações base aplicáveis a todos os ambientes
- `appsettings.Development.json`: Configurações específicas para desenvolvimento

### Variáveis de Ambiente
| Variável | Valor Padrão | Descrição |
|----------|--------------|-----------|
| `ASPNETCORE_ENVIRONMENT` | `Development` | Define o ambiente de execução |
| `ASPNETCORE_URLS` | `http://localhost:5225;https://localhost:7229` | URLs onde a aplicação escuta |

## 📡 API Endpoints

### WeatherForecast
- **GET** `/WeatherForecast`
- **Descrição**: Retorna uma lista de 5 previsões do tempo simuladas
- **Resposta**: Array de objetos `WeatherForecast`
- **Exemplo de Resposta**:
  ```json
  [
    {
      "date": "2024-01-15",
      "temperatureC": 22,
      "temperatureF": 71,
      "summary": "Quente"
    }
  ]
  ```

### Documentação OpenAPI
- **Swagger UI**: `/swagger`
- **OpenAPI Spec**: `/openapi/v1.json`

## 🖥️ Interface Web

A aplicação inclui uma página web responsiva que consome a API WeatherForecast:

### Funcionalidades do Frontend
- ✅ Botão para buscar previsões do tempo
- ✅ Visualização dos dados em cards estilizados
- ✅ Indicador de carregamento durante requisições
- ✅ Tratamento de erros com feedback visual
- ✅ Design responsivo com Bootstrap 5
- ✅ Informações do projeto e ambiente

### Como Usar a Interface
1. Acesse a página inicial (`/` ou `/Home`)
2. Clique em "Get Weather Forecast"
3. Visualize as previsões exibidas em cards coloridos
4. Use "Clear Results" para limpar a visualização

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core 10.0** - Framework web
- **C# 10** - Linguagem de programação
- **OpenAPI/Swagger** - Documentação de API
- **Razor Pages** - Frontend web
- **Bootstrap 5** - Framework CSS
- **Bootstrap Icons** - Biblioteca de ícones

## 📦 Dependências

| Pacote | Versão | Finalidade |
|--------|--------|------------|
| Microsoft.AspNetCore.OpenApi | 10.0.0 | Suporte a OpenAPI/Swagger |
| Bootstrap.Icons | 1.11.3 | Ícones para a interface |

## 🧪 Testando a API

### Usando o Arquivo HTTP
O projeto inclui `ContosoPizza.http` para testar a API com o cliente HTTP do Visual Studio:

```http
GET http://localhost:5225/WeatherForecast
Accept: application/json
```

### Usando cURL
```bash
curl -X GET "https://localhost:7229/WeatherForecast" -H "accept: application/json"
```

### Usando Swagger UI
Acesse `https://localhost:7229/swagger` para:
- Ver todos os endpoints disponíveis
- Testar requisições diretamente na interface
- Examinar modelos de dados

## 🐛 Solução de Problemas

### Erros Comuns

| Problema | Solução |
|----------|---------|
| Porta já em uso | Altere as portas em `launchSettings.json` ou `appsettings.json` |
| Certificado HTTPS inválido | Aceite o certificado de desenvolvimento ou execute em HTTP |
| Erro de compilação | Execute `dotnet restore` e `dotnet build` |

### Logs
Os logs são configurados por ambiente:
- **Development**: Log level Information para a aplicação, Warning para Microsoft.*
- **Production**: Apenas logs importantes

## 🤝 Contribuindo

1. Faça um Fork do projeto
2. Crie uma Branch para sua Feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a Branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Distribuído sob licença MIT. Veja `LICENSE` para mais informações.

## 👤 Autor

**Wagner Teles Alvaro*
- GitHub: [@wtalvaro](https://github.com/wtalvaro)

## 🙏 Agradecimentos

- [Microsoft Docs](https://docs.microsoft.com/pt-br/aspnet/core) - Documentação oficial do ASP.NET Core
- [Bootstrap](https://getbootstrap.com) - Framework CSS
- [Swagger](https://swagger.io) - Ferramentas de documentação de API

---

**⭐️ Se este projeto foi útil, considere dar uma estrela no repositório!**

> **Nota**: Este é um projeto de demonstração. Em um ambiente de produção, configure adequadamente segurança, logging e monitoramento.

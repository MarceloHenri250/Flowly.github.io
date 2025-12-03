# Flowly — Plano de 1 semana

> Plano diário para construir o projeto Flowly (back-end em C# / front-end em React + Vite + Tailwind).

<!-- Badges (preencha os URLs/IDs quando disponíveis) -->
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Issues](https://img.shields.io/badge/issues-welcome-brightgreen.svg)](https://github.com/MarceloHenri250/Flowly.github.io/issues)

## Índice

- [Sobre](#sobre)
- [Resumo do Plano (7 dias)](#resumo-do-plano-7-dias)
- [Stack recomendada](#stack-recomendada)
- [Como rodar (exemplo)](#como-rodar-exemplo)
- [Repositórios sugeridos](#repositórios-sugeridos)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Sobre

Este repositório contém um plano detalhado para implementar o projeto Flowly em 1 semana. O objetivo é guiar a implementação das partes essenciais: autenticação, dashboard, quadros Kanban, anexos e colaboração.

## Resumo do Plano (7 dias)

### DIA 1 — Figma & Estrutura Inicial

- [x] Criar o layout completo no Figma
- [ ] Definir tema claro/escuro
- [ ] Criar a logo “Flowly”
- [ ] Planejar navegação: Landing, Login, Cadastro, Dashboard, Página do Quadro, Modais, Configurações, Compartilhar quadro
- [x] Criar repositórios: `flowly-api` (ASP.NET Core) e `flowly-web` (React + Vite + Tailwind)

### DIA 2 — Banco de Dados & API Base

- [ ] Criar banco e tabelas via EF Core + Migrations (SQL Server / MySQL)
- [ ] Criar Models, DTOs e Repositories
- [ ] Endpoints iniciais: `/auth/register`, `/auth/login`, `/auth/google`, `/boards`, `/columns`, `/cards`
- [ ] Implementar JWT

### DIA 3 — Login, Cadastro e Landing Page (Front-end)

- [ ] Criar Landing Page
- [ ] Componentizar Navbar (toggle de tema)
- [ ] Implementar Login (manual, Google, convidado)
- [ ] Implementar Cadastro
- [ ] Conectar com API e salvar token em `localStorage`

### DIA 4 — Dashboard + Criar Quadro + Templates

- [ ] Página Dashboard
- [ ] Modal “Novo quadro”
- [ ] Templates básicos (estudos, empresarial)
- [ ] Rotas e requisições para criar/listar quadros

### DIA 5 — Página Kanban + Cards + Colunas

- [ ] Implementar página do quadro (colunas, cards)
- [ ] Drag & drop com SortableJS
- [ ] Modais para criar/editar card e coluna
- [ ] Persistir posições no banco

### DIA 6 — Anexos, Colaboração e Tema

- [ ] Upload local no backend (`/uploads`), validações e registro no DB
- [ ] UI de anexos (listar, baixar, excluir)
- [ ] Modal de compartilhamento (adicionar colaborador por e-mail, permissões)
- [ ] Modo claro/escuro com Tailwind

### DIA 7 — Finalização, Documentação e Apresentação

- [ ] Criar README no GitHub
- [ ] Documentação (arquitetura, ER, telas do Figma, rotas da API)
- [ ] Revisar responsividade e fluxo
- [ ] Criar vídeo curto de apresentação
- [ ] Fazer deploy (opcional)

## Stack recomendada

- Backend: ASP.NET Core, Entity Framework Core, JWT, SQL Server / MySQL
- Frontend: React, Vite, Tailwind CSS, SortableJS
- Deploy suggestions: Render (API), Vercel (Front)

## Como rodar (exemplo)

> Os comandos abaixo são exemplos; ajuste caminhos e nomes de projeto conforme seus repositórios `flowly-api` e `flowly-web`.

PowerShell (backend):

```powershell
cd flowly-api
dotnet restore
dotnet ef database update
dotnet run
```

PowerShell (frontend):

```powershell
cd flowly-web
npm install
npm run dev
```

## Repositórios sugeridos

- `flowly-api` — ASP.NET Core Web API (models, controllers, EF Core, auth)
- `flowly-web` — React + Vite + Tailwind (UI, auth, dashboard, kanban)

## Contribuição

- Fork → branch `feature/<nome>` → PR com descrição clara
- Siga padrões de código e escreva testes básicos para novas features

## Licença

Arquivo de licença: `LICENSE`.

## Contato / Design

- Design no Figma: (cole aqui o link do arquivo Figma)
- Autor: `MarceloHenri250` — abra issues para dúvidas ou sugestões

---

Se quiser, eu posso:

- Atualizar este arquivo com mais detalhes de execução (scripts, env vars).
- Gerar um `README_sugerido.md` em inglês.
- Adicionar badges/links finais quando os repositórios estiverem criados.

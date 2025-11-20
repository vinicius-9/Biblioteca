# 📚 Biblioteca API ⚠️ Atualização em breve!

API RESTful de uma **biblioteca digital**, construída com **C# .NET 8** e **SQL Server**, usando **Entity Framework Core** para persistência de dados.
Permite gerenciamento completo de **livros**, **membros** e **empréstimos**, com documentação interativa via **Swagger**.

---

## 🚀 Tecnologias Utilizadas

* **C# / .NET 8**
* **Entity Framework Core 8**
* **SQL Server**
* **ASP.NET Core Web API**
* **Swagger / Swashbuckle** (documentação interativa)
* **Postman** (testes externos)

---

## 📁 Estrutura do Projeto

```
Biblioteca/
│
├─ Controllers/
│   ├─ LivroController.cs
│   ├─ MembroController.cs
│   └─ EmprestimoController.cs
│
├─ Data/
│   └─ AppDbContext.cs
│
├─ Models/
│   ├─ Livro.cs
│   ├─ Membro.cs
│   └─ Emprestimo.cs
│
├─ Program.cs
└─ Biblioteca.csproj
```

---

## ⚙️ Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
* Ferramenta de testes: **Swagger** ou **Postman**

---

## 🔧 Configuração e Instalação

1. Clone o projeto:

```bash
git clone <seu-repositorio>
cd Biblioteca
```

2. Ajuste a **connection string** em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=BibliotecaDB;Trusted_Connection=True;"
}
```

3. Restaure pacotes e compile:

```bash
dotnet restore
dotnet build
```

4. Crie o banco de dados e aplique migrações:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

5. Execute a API:

```bash
dotnet run
```

A API ficará disponível em:

```
http://localhost:5097
```

---

## 🧩 Endpoints

### 📖 Livros

* **GET /api/livro** → Lista todos os livros
* **GET /api/livro/{id}** → Busca livro por ID
* **POST /api/livro** → Cria um livro

Exemplo JSON:

```json
{
  "titulo": "Dom Casmurro",
  "autor": "Machado de Assis"
}
```

* **PUT /api/livro/{id}** → Atualiza livro existente
* **DELETE /api/livro/{id}** → Remove livro

---

### 👤 Membros

* **GET /api/membro** → Lista todos os membros
* **GET /api/membro/{id}** → Busca membro por ID
* **POST /api/membro** → Cria um membro

Exemplo JSON:

```json
{
  "nome": "Rafael",
  "cpf": "555-000",
  "numero": "61 98228051"
}
```

* **PUT /api/membro/{id}** → Atualiza membro existente
* **DELETE /api/membro/{id}** → Remove membro

---

### 📝 Empréstimos

* **GET /api/emprestimo** → Lista todos os empréstimos
* **GET /api/emprestimo/{id}** → Busca empréstimo por ID
* **POST /api/emprestimo** → Cria empréstimo

Exemplo JSON:

```json
{
  "livroId": 1,
  "membroId": 1,
  "dataEmprestimo": "2025-11-20T10:00:00",
  "dataPrevista": "2025-12-04T10:00:00"
}
```

* **PUT /api/emprestimo/{id}** → Atualiza empréstimo
* **DELETE /api/emprestimo/{id}** → Remove empréstimo

---

## 🛠 Testando a API

### Swagger (recomendado para desenvolvimento):

```
http://localhost:5097/swagger
```

### Postman / CURL (exemplo de atualização de membro):

```bash
curl -X PUT \
  'http://localhost:5097/api/membro/1' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
        "id": 1,
        "nome": "Rafael",
        "cpf": "666-000",
        "numero": "61 98228051"
      }'
```

---

## ⚠️ Observações Importantes

* **IDs são chave primária** e não devem ser alterados manualmente.
* Atualizações devem manter o mesmo ID da URL.
* Ao criar empréstimos, a API valida se **Livro e Membro existem**.
* Para alterações parciais, considere criar endpoints específicos ou DTOs.

---



## 🖊 Autor

##Vinicius Pereira

📧 [vinicius.pereiragoncalves.online@gmail.com](mailto:vinicius.pereiragoncalves.online@gmail.com)

📅 2025

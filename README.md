# 📚 Biblioteca API

API RESTful de uma **biblioteca**, construída com **C# .NET 8** e **SQL Server**, usando **Entity Framework Core** para persistência de dados.

O sistema permite o gerenciamento de:

* **Clientes**
* **Funcionários**
* **Livros**
* **Empréstimos**

Com documentação interativa via **Swagger**.

---

## 🚀 Tecnologias Utilizadas

* **C# / .NET 8**
* **Entity Framework Core 8**
* **SQL Server**
* **ASP.NET Core Web API**
* **Swagger / Swashbuckle**
* **Postman / Curl**

##

---

## ⚙️ Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* SQL Server instalado
* Ferramenta de teste: Swagger, Postman ou CURL

---

## 🔧 Configuração e Instalação

1. Clone o repositório:

```bash
git clone https://github.com/vinicius-9/Biblioteca
cd Biblioteca
```

2. Ajuste a **connection string** em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=BibliotecaDB;Trusted_Connection=True;Encrypt=False"
}
```

3. Restaure pacotes e compile:

```bash
dotnet restore
dotnet build
```

4. Crie o banco e aplique migrações:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

5. Execute o projeto:

```bash
dotnet run
```

API disponível em:

```
http://localhost:5097
```

---

# 🧩 Endpoints

---

# 👥 Clientes

### **GET /api/Cliente**

Lista todos os clientes.

### **GET /api/Cliente/{id}**

Busca cliente por ID.

### **POST /api/Cliente**

Cria um cliente.

```json
{
  "nome": "Maria Oliveira",
  "cpf": "00000-00000"
}
```

### **PUT /api/Cliente/{id}**

Atualiza cliente.

### **DELETE /api/Cliente/{id}**

Remove um cliente.

---

# 🧑‍💼 Funcionários

### **GET /api/Funcionario**

Lista funcionários.

### **GET /api/Funcionario/{id}**

Busca funcionário por ID.

### **POST /api/Funcionario**

Cria um funcionário.

```json
{
  "nome": "Bruno Goncalves",
  "cpf": "12345678900",
  "numero": "3358-7917",
  "cargo": "Bibliotecário"
}
```

### **PUT /api/Funcionario/{id}**

Atualiza.

### **DELETE /api/Funcionario/{id}**

Remove.

---

# 📖 Livros

### **GET /api/Livro**

Lista livros.

### **GET /api/Livro/{id}**

Busca livro.

### **POST /api/Livro**

```json
{
  "titulo": "O Senhor dos Anéis",
  "autor": "J.R.R. Tolkien",
  "ano": 1954
}
```

### **PUT /api/Livro/{id}**

Atualiza.

### **DELETE /api/Livro/{id}**

Remove livro.

---

# 📝 Empréstimos

### **GET /api/Emprestimo**

Lista empréstimos com dados completos.

### **GET /api/Emprestimo/{id}**

Busca por ID.

### **POST /api/Emprestimo**

```json
{
  "livroId": 1,
  "clienteId": 1,
  "funcionarioId": 1,
  "dataEmprestimo": "2025-11-20",
  "dataPrevista": "2025-11 21"
}
```

### **PUT /api/Emprestimo/{id}**

Atualiza empréstimo.

### **DELETE /api/Emprestimo/{id}**

Remove empréstimo.

---

## 👨‍💻 Autor

Vinicius Pereira
📧 [vinicius.pereiragoncalves.online@gmail.com](mailto:vinicius.pereiragoncalves.online@gmail.com)
📅 2025

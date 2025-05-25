# 🔐 EncryptedDataExample

This is a minimal but complete example of how to **store encrypted data** securely in a database using **.NET 8**, **EF Core**, and **SQLite**.

---

## ✅ Features

- Application-level encryption using `Aes`.
- Key and IV configured via `appsettings.json` (or environment variables).
- `ValueConverter` for transparent encryption/decryption.
- SQLite database integration.
- Fully working API with sample endpoints.

---

## 🧪 How to Run

1. **Clone the repo**

```bash
git clone https://github.com/adrianbailador/EncryptedDataExample.git
cd EncryptedDataExample
````

2. **Run the app**

```bash
dotnet run
```

The API will start on:

```
http://localhost:5290
```

---

## 🔐 Security Note

In this demo, encryption keys are stored in `appsettings.json` for simplicity.
**In production**, use one of the following instead:

* [Azure Key Vault](https://learn.microsoft.com/en-us/azure/key-vault/)
* [AWS Secrets Manager](https://aws.amazon.com/secrets-manager/)
* Environment variables
* User Secrets for development

Example using environment variables:

```csharp
_key = Convert.FromBase64String(Environment.GetEnvironmentVariable("ENCRYPTION_KEY")!);
_iv = Convert.FromBase64String(Environment.GetEnvironmentVariable("ENCRYPTION_IV")!);
```

Make sure your secrets are never committed to source control.

---

## 📬 Example Requests

### Create user

```bash
curl -X POST http://localhost:5290/api/users \
-H "Content-Type: application/json" \
-d '{"name": "Alice", "ssn": "123-45-6789"}'
```

### Get users

```bash
curl http://localhost:5290/api/users
```

---

## 💡 How It Works

* The `EncryptionHelper` class handles AES encryption and decryption.
* EF Core's `ValueConverter` automatically encrypts the `SSN` field before saving and decrypts it when reading.
* The encryption logic is completely transparent to the rest of the app.

---

## 📦 Tech Stack

* .NET 8 Web API
* Entity Framework Core
* SQLite
* AES Encryption
* Minimal APIs

---

## 📄 License

MIT © [Adrián Bailador](https://adrianbailador.github.io/)




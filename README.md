# Makapi

A simple C# client library for accessing the [Mackerel API](https://mackerel.io/ja/api-docs/).  
It offers a similar interface to the [Mackerel API Client for Python](https://github.com/cm-watanabeseigo/mackerel-api-client-python) aka makapi.py 

---

## 📦 Installation

Makapi is available on NuGet:  
👉 [https://www.nuget.org/packages/Makapi](https://www.nuget.org/packages/Makapi)

Install via .NET CLI:

```bash
dotnet add package Makapi
```

Or via Visual Studio’s NuGet Package Manager:  
**Search:** `Makapi`

---

## 🚀 Usage

```csharp
using WebAPI;

var apiKey = "<YOUR API KEY>";
var m = new Makapi(apiKey);

// GET example
m.get("org");

// PUT example
m.put("hosts/<hostId>");

// POST example
m.post("hosts/<hostId>/status", "{"status":"standby"}");

// DELETE example
m.delete("services/<serviceName>");
```

---

## 📘 Documentation

For full API details, see the official [Mackerel API docs](https://mackerel.io/ja/api-docs/).

---

## 🧾 License

MIT License.

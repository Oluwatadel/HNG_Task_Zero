# 🧠 Backend Wizards — Stage 0 Task  
### 🚀 Build a Dynamic Profile Endpoint (C# / ASP.NET Core Web API)

---

## 📜 Overview

This project implements a **RESTful API** with a single dynamic endpoint:  
`GET /me`

The endpoint returns your **profile information** along with a **random cat fact** fetched from the [Cat Facts API](https://catfact.ninja/fact).  
It demonstrates your ability to:
- Consume third-party APIs  
- Format JSON responses  
- Handle errors gracefully  
- Return dynamic, real-time data  

---

## 🧩 Features

✅ Dynamic `/me` endpoint  
✅ Real-time UTC timestamp in ISO 8601 format  
✅ Random cat fact from Cat Facts API on every request  
✅ Proper `application/json` response header  
✅ Structured and readable code  
✅ Robust error handling for API failures  
✅ Easy local setup and deployment guide  

---

## 🏗️ Tech Stack

| Component | Technology |
|------------|-------------|
| **Language** | C# |
| **Framework** | ASP.NET Core 8.0 (Web API) |
| **External API** | [Cat Facts API](https://catfact.ninja/fact) |
| **IDE** | Visual Studio / Rider / VS Code |
| **Runtime** | .NET SDK 8.0+ |
| **Deployment Options** | Railway, Render, AWS, Heroku, PXXL App *(Vercel not allowed)* |

---

## 🗂️ Project Structure


├── Controllers/
│ └── ProfileController.cs # Main controller handling the /me endpoint
├── Program.cs # Application entry point
├── appsettings.json # App configuration
├── Properties/
│ └── launchSettings.json
└── README.md # Project documentation


---

## ⚙️ Setup Instructions

### 1️⃣ Prerequisites

Before running this project, ensure you have installed:

- [.NET 8 SDK or later](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git
- Internet connection (for fetching cat facts)

---

### 2️⃣ Clone the Repository

```bash
git clone https://github.com/<your-username>/<your-repo-name>.git
cd <your-repo-name>

3️⃣ Install Dependencies

Restore required NuGet packages:

dotnet restore

4️⃣ Run the Application Locally

Start the web server:

dotnet run


Your API will be available at:

http://localhost:5000/me

Headers:
Content-Type: application/json

✅ Example Successful Response
{
  "status": "success",
  "user": {
    "email": "your.email@example.com",
    "name": "Your Full Name",
    "stack": "C# / ASP.NET Core Web API"
  },
  "timestamp": "2025-10-17T12:45:30.123Z",
  "fact": "Cats have five toes on their front paws, but only four on their back paws."
}

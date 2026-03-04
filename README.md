# 🩸 Blood Donation Management System – Backend API

**Secure RESTful API** built with ASP.NET Core 9 for managing blood donation operations: donors, requests, campaigns, blog, notifications, and admin controls.

<p align="center">
  <a href="https://dotnet.microsoft.com">
    <img src="https://img.shields.io/badge/.NET_9-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 9" />
  </a>
  <a href="https://learn.microsoft.com/aspnet/core">
    <img src="https://img.shields.io/badge/ASP.NET_Core-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt="ASP.NET Core" />
  </a>
  <a href="https://learn.microsoft.com/ef/core">
    <img src="https://img.shields.io/badge/EF_Core-0078D4?style=for-the-badge&logo=dotnet&logoColor=white" alt="EF Core" />
  </a>
  <a href="https://jwt.io">
    <img src="https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=json-web-tokens" alt="JWT" />
  </a>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/34_Endpoints-blueviolet?style=for-the-badge" alt="34 Endpoints" />
  <img src="https://img.shields.io/badge/3_Roles-red?style=for-the-badge" alt="Admin • Donor • Receiver" />
  <img src="https://img.shields.io/badge/Image_Upload-green?style=for-the-badge" alt="Image Upload" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/RTL_Arabic_Support-success?style=for-the-badge" alt="RTL Support" />
  <img src="https://img.shields.io/badge/license-MIT-yellow?style=for-the-badge" alt="MIT License" />
  <img src="https://img.shields.io/github/last-commit/Ibrahim-Suker/blood-donation-docs?style=for-the-badge&color=blue" alt="Last Commit" />
</p>

## Current Status

- **Backend (API)** → completed and ready
- **Frontend (React)** → in progress / planned
- **Documentation** → available for frontend developers

## ✨ Main Features (API)

- JWT Authentication + Role-based Authorization (Admin / Donor / Receiver)
- 34 RESTful Endpoints covering:
  - Authentication & Profile
  - Blood Donations & Requests
  - Campaigns CRUD
  - Blog Posts & Comments
  - Notifications (global / targeted)
  - Image Upload endpoint
- Admin Dashboard Statistics
- Full support for Arabic RTL in future frontend
- Scalar API documentation (`/scalar/v1`)

## 📖 Frontend Integration Guide (Very Important)

Frontend developers can start building the React interface using this comprehensive handoff document:

→ **[Blood Donation Frontend Handoff Documentation](https://htmlpreview.github.io/?https://raw.githubusercontent.com/Ibrahim-Suker/blood-donation-docs/main/BloodDonation_Frontend_Handoff_FINAL.html)**  
(contains Axios setup, auth flow, enums, all endpoints with examples, image upload, error handling...)

This is currently the **single source of truth** for connecting any frontend to this API.

## 🛠 Technology Stack (Backend)

- ASP.NET Core 9 Web API
- Entity Framework Core 9
- ASP.NET Core Identity
- JWT Bearer Authentication
- SQL Server
- Scalar UI for API documentation

## 🏁 Quick Start (Backend Only)

### Prerequisites

- .NET 9 SDK
- SQL Server (Express or Developer Edition)
- Visual Studio 2022/2025 or VS Code + C# Dev Kit

### Run the API

```bash
# Navigate to the API project
cd backend/BloodDonation.API

# Restore packages
dotnet restore

# Apply migrations (first time only)
dotnet ef database update

# Start the server
dotnet run
# or press F5 in Visual Studio

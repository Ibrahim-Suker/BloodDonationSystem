# 🩸 Blood Donation Management System

**A full-stack web application** designed to connect blood donors, hospitals, patients, and administrators in an efficient and secure way.

<p align="center">
  <a href="https://dotnet.microsoft.com">
    <img src="https://img.shields.io/badge/.NET_9-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 9" />
  </a>
  <a href="https://react.dev">
    <img src="https://img.shields.io/badge/React-18-61DAFB?style=for-the-badge&logo=react&logoColor=black" alt="React 18" />
  </a>
  <a href="https://vitejs.dev">
    <img src="https://img.shields.io/badge/Vite-%23646CFF?style=for-the-badge&logo=vite&logoColor=white" alt="Vite" />
  </a>
  <a href="https://mui.com">
    <img src="https://img.shields.io/badge/MUI-%230081FF?style=for-the-badge&logo=mui&logoColor=white" alt="Material UI" />
  </a>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=json-web-tokens" alt="JWT Authentication" />
  <img src="https://img.shields.io/badge/Entity_Framework_Core-0078D4?style=for-the-badge&logo=dotnet" alt="EF Core" />
  <img src="https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/ASP.NET_Core-5C2D91?style=for-the-badge&logo=.net" alt="ASP.NET Core" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/RTL_Support-Arabic-success?style=for-the-badge" alt="Arabic RTL" />
  <img src="https://img.shields.io/badge/34_Endpoints-blueviolet?style=for-the-badge" alt="34 API Endpoints" />
  <img src="https://img.shields.io/badge/3_Roles-red?style=for-the-badge" alt="Admin • Donor • Receiver" />
  <img src="https://img.shields.io/badge/Image_Upload-green?style=for-the-badge" alt="Image Upload Supported" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/license-MIT-yellow.svg?style=for-the-badge" alt="MIT License" />
  <img src="https://img.shields.io/github/last-commit/Ibrahim-Suker/blood-donation-docs?style=for-the-badge&color=blue" alt="Last Commit" />
</p>

## ✨ Overview

A modern, secure, and user-friendly **blood donation platform** that streamlines the process of blood donation requests, donor registration, campaign organization, and content management.

### Supported Roles

- **Administrator** 👑 — complete system control  
- **Donor** 🩸 — donate blood & track donation history  
- **Receiver / Hospital** 🏥 — request blood & follow request status

## 🚀 Key Features

- Secure JWT-based authentication & role-based access control
- Full Arabic language support with RTL layout
- Image upload for user profiles, campaigns, and blog posts
- Campaign creation & management
- Educational blog with comment system
- Real-time notifications (global, per-user, blood-type targeted)
- Rich admin dashboard with key statistics
- 34 well-documented API endpoints

## 📖 Frontend → Backend Integration Guide (Most Important)

All the information a frontend developer needs is in **one document**:

→ **[Blood Donation Frontend Handoff Documentation](https://htmlpreview.github.io/?https://raw.githubusercontent.com/Ibrahim-Suker/blood-donation-docs/main/BloodDonation_Frontend_Handoff_FINAL.html)**  
*(rendered version – includes Axios setup, auth flow, enums, all endpoints, examples & notes)*

This is the **single source of truth** for connecting the React frontend to the ASP.NET Core backend.

## 🛠 Technology Stack

| Layer       | Technologies                              |
|-------------|-------------------------------------------|
| **Backend** | ASP.NET Core 9 • EF Core 9 • SQL Server • ASP.NET Identity • JWT |
| **Frontend**| React 18 • Vite • Material UI • Axios • react-router-dom |
| **API Docs**| Scalar UI (`/scalar/v1`)                 |
| **Other**   | Role-based Authorization • Image Upload • RTL Support |

## 🏁 Quick Start

### Prerequisites

- .NET 9 SDK
- Node.js 18+ & npm
- SQL Server (Express or Developer Edition)
- Visual Studio 2022/2025 or VS Code + C# extensions

### Backend

```bash
# Navigate to API project
cd backend/BloodDonation.API

# Restore dependencies
dotnet restore

# Apply database migrations (first time only)
dotnet ef database update

# Launch the API
dotnet run

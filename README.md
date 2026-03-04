# 🩸 Blood Donation Management System

Full-stack platform connecting **blood donors**, **hospitals / patients**, and **administrators**.

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 9" />
  <img src="https://img.shields.io/badge/React-18-61DAFB?style=for-the-badge&logo=react&logoColor=black" alt="React 18" />
  <img src="https://img.shields.io/badge/Vite-B73BFE?style=for-the-badge&logo=vite&logoColor=white" alt="Vite" />
  <img src="https://img.shields.io/badge/Material%20UI-007FFF?style=for-the-badge&logo=mui&logoColor=white" alt="MUI" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=json-web-tokens" alt="JWT" />
  <img src="https://img.shields.io/badge/Entity%20Framework%20Core-0078D4?style=for-the-badge&logo=dotnet" alt="EF Core" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/ASP.NET%20Core-5C2D91?style=for-the-badge&logo=.net" alt="ASP.NET Core" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Arabic%20Support-RTL-success?style=for-the-badge" alt="RTL Support" />
  <img src="https://img.shields.io/badge/34%20Endpoints-blueviolet?style=for-the-badge" alt="34 Endpoints" />
  <img src="https://img.shields.io/badge/3%20Roles-red?style=for-the-badge" alt="3 Roles" />
  <img src="https://img.shields.io/badge/Image%20Upload-green?style=for-the-badge" alt="Image Upload" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge" alt="MIT License" />
  <img src="https://img.shields.io/github/last-commit/Ibrahim-Suker/blood-donation-docs?style=for-the-badge" alt="Last Commit" />
  <img src="https://img.shields.io/github/repo-size/Ibrahim-Suker/blood-donation-docs?style=for-the-badge" alt="Repo Size" />
</p>

## Overview

Complete blood donation management system with three main roles:

- **Admin** 👑 — full control (users, requests, donations, campaigns, blog, notifications)
- **Donor** 🩸 — register donations & view personal history
- **Receiver** 🏥 — create urgent / regular blood requests & track status

### Key Features

- JWT authentication & role-based authorization
- 3 user roles with strict permission separation
- Campaign management + image uploads
- Educational blog posts + comment system
- Notifications (global / per-user / blood-type specific)
- Admin dashboard with live statistics
- Profile picture, campaign & blog image uploads
- Full Arabic RTL support in the frontend

## 📚 Most Important Document for Frontend Developers

**Everything a frontend developer needs to connect React to the backend is in this single file:**

**[BloodDonation_Frontend_Handoff_FINAL.html](https://htmlpreview.github.io/?https://raw.githubusercontent.com/Ibrahim-Suker/blood-donation-docs/main/BloodDonation_Frontend_Handoff_FINAL.html)**  
*(click to view rendered documentation page)*

### This handoff document contains:

- Axios setup + interceptors (auto token + 401 → login redirect)
- Complete Auth flow (login/register → decode JWT → role-based routing)
- All Enums (BloodType, UserRole, RequestStatus, DonationStatus, DonationType)
- Error response format
- Image upload guide (multipart/form-data)
- **All 34 endpoints** documented with:
  - HTTP method + path
  - Required role
  - Request body (when applicable)
  - Example 200 response
  - Important notes & warnings

→ **This is the single source of truth** for frontend → backend integration.

## 🛠 Tech Stack

### Backend
- ASP.NET Core 9 Web API
- Entity Framework Core 9 + SQL Server
- ASP.NET Core Identity + JWT Bearer Authentication
- Scalar API documentation (`/scalar/v1`)
- Role-based authorization policies

### Frontend
- React 18 + Vite
- Material UI (MUI) + MUI Icons
- Axios + react-router-dom
- jwt-decode

## 🚀 Getting Started

### Prerequisites

- .NET 9 SDK
- Node.js 18+ & npm / pnpm / yarn
- SQL Server (Express or Developer edition)
- Visual Studio 2022/2025 or VS Code + C# Dev Kit

### Backend Setup

```bash
cd backend/BloodDonation.API

# Restore packages
dotnet restore

# Apply migrations (first time only)
dotnet ef database update

# Run
dotnet run
# or press F5 in Visual Studio
 

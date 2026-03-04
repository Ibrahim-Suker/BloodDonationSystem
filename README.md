# 🩸 Blood Donation Management System

Full-stack platform connecting **blood donors**, **hospitals / patients**, and **administrators**.

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com)
[![React](https://img.shields.io/badge/React-18-61DAFB?style=for-the-badge&logo=react)](https://react.dev)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

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


### خطوة واحدة فقط دلوقتي:

انسخ الكود أعلاه كله → روح على الـ repository بتاعك<a href="https://github.com/Ibrahim-Suker/blood-donation-docs" target="_blank" rel="noopener noreferrer nofollow"></a>  
→ اضغط على **README.md** (لو موجود) أو **Add file → Create new file** وسميه `README.md`  
→ الصق الكود كله → Commit changes

خلاص — الـ README هيظهر بشكل احترافي جدًا، والرابط بتاع الـ handoff هيفتح الصفحة المنسقة مباشرة.

لو عايز تضيف صور (screenshots) بعدين، قولي وأساعدك نضيفهم في الـ README.

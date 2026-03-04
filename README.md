# 🩸 Blood Donation Management System  
**نظام إدارة التبرع بالدم** — منصة تربط بين المتبرعين والمستشفيات/المرضى

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com)
[![React](https://img.shields.io/badge/React-18-61DAFB?style=for-the-badge&logo=react)](https://react.dev)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

## نظرة عامة على المشروع

نظام كامل (Backend + Frontend) لإدارة عمليات **التبرع بالدم** يدعم ثلاثة أدوار رئيسية:

- **Admin** 👑 — إدارة كاملة (مستخدمين، طلبات، تبرعات، حملات، مدونة، إشعارات)
- **Donor** 🩸 — تسجيل تبرعات + متابعة السجل الشخصي
- **Receiver** 🏥 — تقديم طلبات دم عاجلة / عادية + متابعة حالة الطلب

### المميزات الرئيسية

- تسجيل / تسجيل دخول باستخدام **JWT**
- 3 أدوار مع صلاحيات منفصلة تمامًا
- إدارة حملات التبرع + رفع صور
- مدونة تعليمية + نظام تعليقات
- إشعارات (عامة / لمستخدم معين / حسب فصيلة الدم)
- لوحة تحكم إدارية بإحصائيات حية
- رفع صور لـ (الملف الشخصي / الحملات / المدونة)
- دعم كامل للغة العربية (RTL) في الواجهة الأمامية

## 📚 التوثيق الرئيسي للمطورين (Frontend Handoff)

كل ما تحتاجه لربط الـ **React Frontend** بالـ **Backend** موجود في الملف التالي:

**[BloodDonation_Frontend_Handoff_FINAL.html](BloodDonation_Frontend_Handoff_FINAL.html)**

### يحتوي الملف على:

- إعداد Axios + Interceptors (token تلقائي + 401 redirect)
- Auth Flow كامل (login / register / decode JWT / redirect حسب الـ role)
- جميع الـ **Enums** (BloodType, UserRole, RequestStatus, DonationStatus, DonationType)
- شكل الـ Error Responses
- كيفية رفع الصور (multipart/form-data)
- وصف **كل endpoint** من الـ 34 endpoint مع:
  - Method + Path
  - الصلاحيات المطلوبة
  - Request Body (إن وجد)
  - Response مثالية
  - ملاحظات خاصة

→ **هذا الملف هو المرجع الوحيد** الذي يجب على مطور الـ frontend الاعتماد عليه.

## 🛠 التقنيات المستخدمة

### Backend
- ASP.NET Core 9 Web API
- Entity Framework Core 9 + SQL Server
- ASP.NET Core Identity + JWT Authentication
- Scalar UI لتوثيق الـ API (`/scalar/v1`)
- Role-based Authorization

### Frontend
- React 18 + Vite
- Material UI (MUI) + MUI Icons
- Axios + react-router-dom
- jwt-decode

## 🚀 كيفية التشغيل (Backend + Frontend)

### المتطلبات

- .NET 9 SDK
- Node.js 18+ و npm / pnpm / yarn
- SQL Server (Express أو Developer)
- Visual Studio 2022/2025 أو VS Code + C# extensions

### تشغيل الـ Backend

```bash
cd backend/BloodDonation.API

# استعادة الحزم
dotnet restore

# (أول مرة فقط) تطبيق الـ migrations
dotnet ef database update

# تشغيل
dotnet run
# أو اضغط F5 في Visual Studio

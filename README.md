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

**[BloodDonation_Frontend_Handoff_FINAL.html](<!DOCTYPE html>
<html lang="ar" dir="rtl">
<head>
<meta charset="UTF-8"/>
<meta name="viewport" content="width=device-width,initial-scale=1"/>
<title>Blood Donation API — Frontend Handoff</title>
<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Mono:wght@400;600&family=Cairo:wght@400;600;700;900&display=swap" rel="stylesheet"/>
<style>
:root{
  --red:#e53935;--red2:#b71c1c;--red3:#7f0000;
  --bg:#070707;--bg2:#0f0f0f;--bg3:#161616;--bg4:#1e1e1e;
  --border:#1e1e1e;--border2:#2a2a2a;
  --text:#f0f0f0;--muted:#666;--muted2:#444;
  --green:#00c853;--gbg:#001a0a;--gborder:#003a1a;
  --blue:#448aff;--bbg:#001233;--bborder:#1a3a6a;
  --orange:#ff6d00;--obg:#1a0e00;--oborder:#7f3000;
  --mono:'IBM Plex Mono',monospace;
  --body:'Cairo',sans-serif;
}
*{box-sizing:border-box;margin:0;padding:0;}
html{scroll-behavior:smooth;}
body{background:var(--bg);color:var(--text);font-family:var(--body);font-size:14px;line-height:1.7;}

/* SIDEBAR */
.sidebar{position:fixed;top:0;right:0;width:230px;height:100vh;background:var(--bg2);border-left:1px solid var(--border);overflow-y:auto;z-index:100;}
.sb-logo{padding:18px 14px;border-bottom:1px solid var(--border);}
.sb-logo .t{font-size:16px;font-weight:900;color:#fff;}
.sb-logo .s{font-size:10px;color:var(--red);margin-top:2px;font-family:var(--mono);}
.sb-sec{padding:6px 0;border-bottom:1px solid var(--border);}
.sb-lbl{font-size:10px;color:var(--muted2);padding:6px 14px 3px;text-transform:uppercase;letter-spacing:.1em;}
.sb-a{display:block;padding:6px 14px;color:#777;font-size:12px;text-decoration:none;transition:.15s;}
.sb-a:hover,.sb-a.act{color:var(--red);background:#0a0000;}

/* MAIN */
.main{margin-right:230px;padding:44px 48px;max-width:900px;}

/* HERO */
.hero{background:linear-gradient(135deg,#1a0000 0%,#0d0000 50%,#0d0020 100%);border:1px solid #2a0000;border-radius:12px;padding:36px;margin-bottom:44px;position:relative;overflow:hidden;}
.hero::after{content:'';position:absolute;top:-60px;left:-60px;width:240px;height:240px;background:radial-gradient(circle,rgba(229,57,53,.12) 0%,transparent 70%);pointer-events:none;}
.hero-eye{font-size:10px;color:var(--red);letter-spacing:.2em;text-transform:uppercase;margin-bottom:8px;font-family:var(--mono);}
.hero h1{font-size:28px;font-weight:900;color:#fff;line-height:1.2;margin-bottom:8px;}
.hero-sub{color:#888;font-size:14px;margin-bottom:22px;}
.tags{display:flex;gap:7px;flex-wrap:wrap;}
.tag{background:rgba(229,57,53,.1);border:1px solid rgba(229,57,53,.22);color:#ef9a9a;padding:3px 12px;border-radius:20px;font-size:11px;}

/* SECTION */
.sec{margin-bottom:48px;scroll-margin-top:20px;}
.sec-title{font-size:18px;font-weight:900;color:#fff;border-bottom:1px solid var(--border2);padding-bottom:10px;margin-bottom:18px;display:flex;align-items:center;gap:8px;}

/* BOXES */
.box{border-radius:8px;padding:12px 14px;margin:10px 0;display:flex;gap:9px;font-size:13px;}
.bi{background:var(--bbg);border:1px solid var(--bborder);color:#90caf9;}
.bw{background:var(--obg);border:1px solid var(--oborder);color:#ffb74d;}
.bg{background:var(--gbg);border:1px solid var(--gborder);color:#a5d6a7;}

/* CODE */
pre,code{font-family:var(--mono);}
.pre-wrap{margin:10px 0;}
.pre-top{display:flex;justify-content:space-between;align-items:center;margin-bottom:4px;}
.pre-lbl{font-size:10px;color:var(--muted);text-transform:uppercase;letter-spacing:.07em;}
pre{background:#060606;border:1px solid var(--border2);border-radius:8px;padding:14px;overflow-x:auto;font-size:12px;line-height:1.75;color:#e0e0e0;}
code{background:var(--bg4);border:1px solid var(--border2);padding:1px 6px;border-radius:3px;font-size:11.5px;color:#ef9a9a;}
.cpbtn{background:transparent;border:1px solid var(--border2);color:var(--muted);padding:2px 10px;border-radius:4px;cursor:pointer;font-size:10px;font-family:var(--body);transition:.2s;}
.cpbtn:hover{border-color:var(--red);color:var(--red);}
.cpbtn.ok{border-color:var(--green);color:var(--green);}

/* TABLE */
table{width:100%;border-collapse:collapse;margin:10px 0;font-size:13px;}
th{background:var(--bg3);color:var(--muted);font-weight:700;text-align:right;padding:8px 12px;font-size:10px;text-transform:uppercase;letter-spacing:.07em;border-bottom:1px solid var(--border2);}
td{padding:8px 12px;border-bottom:1px solid #0f0f0f;color:#ccc;vertical-align:top;}
tr:last-child td{border-bottom:none;}
tr:hover td{background:#0a0a0a;}

/* METHOD BADGES */
.m{font-family:var(--mono);font-size:10px;font-weight:700;padding:2px 7px;border-radius:3px;display:inline-block;min-width:50px;text-align:center;}
.GET   {background:#001a2e;color:#64b5f6;border:1px solid #1565c0;}
.POST  {background:#0a1a00;color:#81c784;border:1px solid #2e7d32;}
.PUT   {background:#1a0e00;color:#ffb74d;border:1px solid #e65100;}
.DELETE{background:#1a0000;color:#ef9a9a;border:1px solid #c62828;}

/* ROLE CHIPS */
.role{font-size:10px;padding:1px 8px;border-radius:10px;white-space:nowrap;font-weight:700;}
.pub{background:#1a1a00;color:#fff59d;border:1px solid #f9a825;}
.all{background:#001a1a;color:#80deea;border:1px solid #00838f;}
.adm{background:#1a0000;color:#ef9a9a;border:1px solid #7f0000;}
.don{background:#001a00;color:#a5d6a7;border:1px solid #1b5e20;}
.rec{background:#001233;color:#90caf9;border:1px solid #0d47a1;}

/* ENDPOINT */
.ep{background:var(--bg2);border:1px solid var(--border);border-radius:8px;margin-bottom:8px;overflow:hidden;}
.ep-h{display:flex;align-items:center;gap:8px;padding:11px 14px;cursor:pointer;flex-wrap:wrap;}
.ep-h:hover{background:var(--bg3);}
.ep-path{font-family:var(--mono);font-size:12px;flex:1;color:#ddd;}
.ep-desc{font-size:11px;color:var(--muted);}
.ep-b{padding:14px;border-top:1px solid var(--border);display:none;}
.ep-b.open{display:block;}

/* ENUMS */
.enum-grid{display:grid;grid-template-columns:repeat(auto-fill,minmax(185px,1fr));gap:10px;margin:12px 0;}
.ec{background:var(--bg2);border:1px solid var(--border);border-radius:8px;padding:12px;}
.ec h4{color:var(--red);font-family:var(--mono);font-size:12px;margin-bottom:8px;}
.ev{display:flex;justify-content:space-between;padding:3px 0;border-bottom:1px solid #111;font-size:11px;}
.ev:last-child{border-bottom:none;}
.ev .n{color:var(--muted);font-family:var(--mono);}
.ev .v{color:#ccc;}

/* STATUS */
.s200{color:#81c784;font-family:var(--mono);font-weight:700;}
.s400{color:#ffb74d;font-family:var(--mono);font-weight:700;}
.s401{color:#ef9a9a;font-family:var(--mono);font-weight:700;}
.s403{color:#ce93d8;font-family:var(--mono);font-weight:700;}

/* SCROLLBAR */
::-webkit-scrollbar{width:5px;}
::-webkit-scrollbar-track{background:#080808;}
::-webkit-scrollbar-thumb{background:#222;border-radius:3px;}

@media(max-width:768px){.sidebar{display:none;}.main{margin-right:0;padding:20px 14px;}}
</style>
</head>
<body>

<!-- ═══ SIDEBAR ═══ -->
<nav class="sidebar">
  <div class="sb-logo">
    <div class="t">🩸 Blood Donation</div>
    <div class="s">Frontend Handoff · API v1.0</div>
  </div>
  <div class="sb-sec">
    <div class="sb-lbl">البداية</div>
    <a class="sb-a" href="#setup">إعداد Axios</a>
    <a class="sb-a" href="#auth-flow">Auth Flow</a>
    <a class="sb-a" href="#enums">Enums</a>
    <a class="sb-a" href="#errors">Errors</a>
    <a class="sb-a" href="#images">Image Upload</a>
  </div>
  <div class="sb-sec">
    <div class="sb-lbl">Public</div>
    <a class="sb-a" href="#auth">Login / Register</a>
  </div>
  <div class="sb-sec">
    <div class="sb-lbl">All Roles</div>
    <a class="sb-a" href="#profile">Profile</a>
    <a class="sb-a" href="#campaigns-pub">Campaigns</a>
    <a class="sb-a" href="#blog-pub">Blog & Comments</a>
    <a class="sb-a" href="#notif-pub">Notifications</a>
    <a class="sb-a" href="#upload">Upload Image</a>
  </div>
  <div class="sb-sec">
    <div class="sb-lbl">Donor 🩸</div>
    <a class="sb-a" href="#donor">Donor</a>
  </div>
  <div class="sb-sec">
    <div class="sb-lbl">Receiver 🏥</div>
    <a class="sb-a" href="#receiver">Receiver</a>
  </div>
  <div class="sb-sec">
    <div class="sb-lbl">Admin 👑</div>
    <a class="sb-a" href="#adm-dash">Dashboard</a>
    <a class="sb-a" href="#adm-users">Users</a>
    <a class="sb-a" href="#adm-blood">Blood Requests</a>
    <a class="sb-a" href="#adm-don">Donations</a>
    <a class="sb-a" href="#adm-camp">Campaigns CRUD</a>
    <a class="sb-a" href="#adm-blog">Blog CRUD</a>
    <a class="sb-a" href="#adm-notif">Notifications</a>
  </div>
</nav>

<!-- ═══ MAIN ═══ -->
<main class="main">

<!-- HERO -->
<div class="hero">
  <div class="hero-eye">Frontend Handoff Document · ASP.NET Core 9 · .NET 9</div>
  <h1>🩸 Blood Donation<br>Management API</h1>
  <div class="hero-sub">كل اللي محتاجه تربط الـ React Frontend بالـ Backend — Base URL · Axios · Auth · Enums · 34 Endpoint</div>
  <div class="tags">
    <span class="tag">React + Vite</span><span class="tag">MUI Material</span>
    <span class="tag">JWT Auth</span><span class="tag">3 Roles</span>
    <span class="tag">34 Endpoints</span><span class="tag">Image Upload</span>
    <span class="tag">CORS ✅</span><span class="tag">.NET 9</span>
  </div>
</div>

<!-- ══ SETUP ══ -->
<div class="sec" id="setup">
  <div class="sec-title">⚙️ إعداد المشروع — أول حاجة تعملها</div>

  <div class="pre-wrap">
    <div class="pre-top"><span class="pre-lbl">1. install packages</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>npm create vite@latest blood-donation-frontend -- --template react
cd blood-donation-frontend
npm install axios react-router-dom @mui/material @mui/icons-material @emotion/react @emotion/styled jwt-decode</pre>
  </div>

  <div class="pre-wrap">
    <div class="pre-top"><span class="pre-lbl">2. src/services/api.js — أنشئ هذا الملف أول حاجة</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:{PORT}',  // ← غيّر الـ PORT
});

// بيبعت الـ token تلقائياً مع كل request
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

// لو الـ token انتهى — يروّح على Login
api.interceptors.response.use(
  (res) => res,
  (err) => {
    if (err.response?.status === 401) {
      localStorage.removeItem('token');
      window.location.href = '/login';
    }
    return Promise.reject(err);
  }
);

export default api;</pre>
  </div>
  <div class="box bg"><span>✅</span><span>كل الـ services هتعمل <code>import api from '../services/api'</code> وهيبعت الـ token تلقائي مع كل request.</span></div>
</div>

<!-- ══ AUTH FLOW ══ -->
<div class="sec" id="auth-flow">
  <div class="sec-title">🔐 Auth Flow — ازاي يشتغل</div>

  <table>
    <tr><th>#</th><th>الخطوة</th><th>الكود</th></tr>
    <tr><td>1</td><td>Login أو Register</td><td><code>POST /api/auth/login</code> → يرجع <code>token</code></td></tr>
    <tr><td>2</td><td>احفظ الـ token</td><td><code>localStorage.setItem('token', token)</code></td></tr>
    <tr><td>3</td><td>افك الـ token</td><td><code>jwt-decode</code> → تاخد role, userId, fullName, bloodType</td></tr>
    <tr><td>4</td><td>وجّه حسب الـ role</td><td>Admin → /admin/dashboard | Donor → /donor/donate | Receiver → /receiver</td></tr>
    <tr><td>5</td><td>Logout</td><td><code>localStorage.removeItem('token')</code> ثم navigate('/login')</td></tr>
  </table>

  <div class="pre-wrap">
    <div class="pre-top"><span class="pre-lbl">مثال كامل — handleLogin</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>import { jwtDecode } from 'jwt-decode';
import api from '../services/api';

const handleLogin = async (email, password) => {
  const res = await api.post('/api/auth/login', { email, password });
  const { token } = res.data;

  localStorage.setItem('token', token);

  const decoded = jwtDecode(token);

  // ⚠️ الـ role مش في decoded.role — لازم الـ claim الطويل ده
  const role = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
  const userId   = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
  const fullName = decoded['fullName'];
  const bloodType = decoded['bloodType'];

  if (role === 'Admin')    navigate('/admin/dashboard');
  if (role === 'Donor')    navigate('/donor/donate');
  if (role === 'Receiver') navigate('/receiver/new-request');
};</pre>
  </div>
  <div class="box bw"><span>⚠️</span><span>الـ role في الـ JWT مش في <code>decoded.role</code> — لازم تستخدم الـ claim الطويل اللي فوق.</span></div>
</div>

<!-- ══ ENUMS ══ -->
<div class="sec" id="enums">
  <div class="sec-title">🔢 Enums — ابعتها كأرقام دايماً</div>
  <div class="box bw"><span>⚠️</span><span>ابعت الـ enum كـ integer مش string — <code>"bloodType": 0</code> مش <code>"bloodType": "APositive"</code></span></div>
  <div class="enum-grid">
    <div class="ec"><h4>BloodType</h4>
      <div class="ev"><span class="n">0</span><span class="v">APositive (A+)</span></div>
      <div class="ev"><span class="n">1</span><span class="v">ANegative (A-)</span></div>
      <div class="ev"><span class="n">2</span><span class="v">BPositive (B+)</span></div>
      <div class="ev"><span class="n">3</span><span class="v">BNegative (B-)</span></div>
      <div class="ev"><span class="n">4</span><span class="v">ABPositive (AB+)</span></div>
      <div class="ev"><span class="n">5</span><span class="v">ABNegative (AB-)</span></div>
      <div class="ev"><span class="n">6</span><span class="v">OPositive (O+)</span></div>
      <div class="ev"><span class="n">7</span><span class="v">ONegative (O-)</span></div>
    </div>
    <div class="ec"><h4>UserRole</h4>
      <div class="ev"><span class="n">0</span><span class="v">Admin</span></div>
      <div class="ev"><span class="n">1</span><span class="v">Donor</span></div>
      <div class="ev"><span class="n">2</span><span class="v">Receiver</span></div>
    </div>
    <div class="ec"><h4>RequestStatus</h4>
      <div class="ev"><span class="n">0</span><span class="v">Pending</span></div>
      <div class="ev"><span class="n">1</span><span class="v">Approved</span></div>
      <div class="ev"><span class="n">2</span><span class="v">Rejected</span></div>
      <div class="ev"><span class="n">3</span><span class="v">Completed</span></div>
    </div>
    <div class="ec"><h4>DonationStatus</h4>
      <div class="ev"><span class="n">0</span><span class="v">Pending</span></div>
      <div class="ev"><span class="n">1</span><span class="v">Approved</span></div>
      <div class="ev"><span class="n">2</span><span class="v">Rejected</span></div>
    </div>
    <div class="ec"><h4>DonationType</h4>
      <div class="ev"><span class="n">0</span><span class="v">Blood</span></div>
      <div class="ev"><span class="n">1</span><span class="v">Plasma</span></div>
    </div>
  </div>
</div>

<!-- ══ ERRORS ══ -->
<div class="sec" id="errors">
  <div class="sec-title">⚠️ Error Handling</div>
  <table>
    <tr><th>Status</th><th>المعنى</th><th>السبب</th></tr>
    <tr><td><span class="s200">200</span></td><td>نجح</td><td>كل حاجة تمام</td></tr>
    <tr><td><span class="s400">400</span></td><td>Bad Request</td><td>بيانات غلط، email موجود، ملف مش صورة</td></tr>
    <tr><td><span class="s401">401</span></td><td>Unauthorized</td><td>مفيش token، token انتهى، password غلط، account معطّل</td></tr>
    <tr><td><span class="s403">403</span></td><td>Forbidden</td><td>الـ role مش عنده صلاحية على الـ endpoint ده</td></tr>
    <tr><td><span class="s400">404</span></td><td>Not Found</td><td>الـ ID مش موجود</td></tr>
  </table>
  <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">شكل الـ error response دايماً</span></div>
  <pre>{ "message": "وصف المشكلة هنا" }</pre></div>
</div>

<!-- ══ IMAGE UPLOAD ══ -->
<div class="sec" id="images">
  <div class="sec-title">🖼 Image Upload</div>
  <div class="box bi"><span>ℹ️</span><span>3 entities بيها صور: <code>BlogPost.ImageUrl</code> · <code>Campaign.ImageUrl</code> · <code>User.ProfilePicture</code> — كلهم نفس الـ endpoint.</span></div>

  <table>
    <tr><th>Method</th><th>Endpoint</th><th>الوصف</th></tr>
    <tr><td><span class="m POST">POST</span></td><td><code>/api/upload/image</code></td><td>ارفع صورة → يرجع imageUrl كامل · Max 5MB · jpg,png,webp,gif</td></tr>
  </table>

  <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request — form-data مش JSON</span></div>
  <pre>Body: form-data
Key:  file
Type: File  ← مهم تختار File مش Text
Value: [اختار الصورة]</pre></div>

  <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Response</span></div>
  <pre>{ "imageUrl": "https://localhost:{PORT}/images/abc123.jpg" }</pre></div>

  <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">React — مثال كامل</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
  <pre>const [imageUrl, setImageUrl] = useState('');

const handleUpload = async (e) => {
  const file = e.target.files[0];
  const formData = new FormData();
  formData.append('file', file);

  const res = await api.post('/api/upload/image', formData, {
    headers: { 'Content-Type': 'multipart/form-data' }
  });
  setImageUrl(res.data.imageUrl);
};

// لما تبعت الـ form
await api.post('/api/admin/blog', { title, content, imageUrl });

// عرض الصورة
&lt;input type="file" accept="image/*" onChange={handleUpload} /&gt;
{imageUrl &amp;&amp; &lt;img src={imageUrl} alt="preview" width={200} /&gt;}</pre></div>
</div>

<!-- ══ AUTH ENDPOINTS ══ -->
<div class="sec" id="auth">
  <div class="sec-title">🔑 Auth — Login & Register</div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m POST">POST</span><span class="ep-path">/api/auth/register</span>
      <span class="role pub">Public</span><span class="ep-desc">تسجيل مستخدم جديد</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
      <pre>{
  "fullName":    "Ahmed Mohamed",
  "email":       "ahmed@test.com",
  "password":    "Test1234@",     <span style="color:#333">// min 8 chars + uppercase + digit</span>
  "phoneNumber": "01012345678",
  "bloodType":   0,               <span style="color:#333">// BloodType enum</span>
  "role":        1                <span style="color:#333">// 0=Admin 1=Donor 2=Receiver</span>
}</pre></div>
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response</span></div>
      <pre>{
  "token":     "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "userId":    "8e76ed2d-dfdf-46c6-beca-9d2ded5b9a1d",
  "fullName":  "Ahmed Mohamed",
  "email":     "ahmed@test.com",
  "role":      "Donor",
  "expiresAt": "2026-03-09T10:21:16Z"
}</pre></div>
    </div>
  </div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m POST">POST</span><span class="ep-path">/api/auth/login</span>
      <span class="role pub">Public</span><span class="ep-desc">تسجيل الدخول</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
      <pre>{ "email": "ahmed@test.com", "password": "Test1234@" }</pre></div>
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — نفس شكل Register</span></div>
      <pre>{ "token": "eyJ...", "userId": "...", "fullName": "...", "role": "Donor", "expiresAt": "..." }</pre></div>
    </div>
  </div>
</div>

<!-- ══ PROFILE ══ -->
<div class="sec" id="profile">
  <div class="sec-title">👤 Profile</div>
  <div class="box bi"><span>ℹ️</span><span>الـ userId بيتاخد من الـ token تلقائي — مش محتاج تبعته في الـ body.</span></div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m GET">GET</span><span class="ep-path">/api/profile</span>
      <span class="role all">All Roles</span><span class="ep-desc">بيانات الـ user الحالي</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response</span></div>
      <pre>{
  "id":             "8e76ed2d-...",
  "fullName":       "Ahmed Mohamed",
  "email":          "ahmed@test.com",
  "phoneNumber":    "01012345678",
  "bloodType":      0,
  "role":           1,
  "isActive":       true,
  "createdAt":      "2026-03-01T10:00:00Z",
  "profilePicture": null
}</pre></div>
    </div>
  </div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m PUT">PUT</span><span class="ep-path">/api/profile</span>
      <span class="role all">All Roles</span><span class="ep-desc">تعديل بيانات الـ user</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
      <pre>{
  "fullName":       "Ahmed New Name",
  "phoneNumber":    "01099999999",
  "bloodType":      0,
  "profilePicture": "https://localhost:{PORT}/images/avatar.jpg"  <span style="color:#333">// أو null</span>
}</pre></div>
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — نفس شكل GET profile</span></div>
      <pre>{ "id": "...", "fullName": "Ahmed New Name", ... }</pre></div>
    </div>
  </div>
</div>

<!-- ══ CAMPAIGNS PUBLIC ══ -->
<div class="sec" id="campaigns-pub">
  <div class="sec-title">📣 Campaigns — للكل</div>
  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m GET">GET</span><span class="ep-path">/api/campaigns</span>
      <span class="role all">All Roles</span><span class="ep-desc">الـ Active campaigns فقط</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — Array</span></div>
      <pre>[{
  "id": 1, "title": "Cairo Blood Drive",
  "description": "...", "location": "Cairo Medical Center",
  "latitude": 30.0444, "longitude": 31.2357,
  "startDate": "2026-04-01T09:00:00Z",
  "endDate":   "2026-04-01T17:00:00Z",
  "isActive":  true,
  "imageUrl":  "https://localhost:{PORT}/images/campaign.jpg"
}]</pre></div>
    </div>
  </div>
</div>

<!-- ══ BLOG PUBLIC ══ -->
<div class="sec" id="blog-pub">
  <div class="sec-title">📝 Blog & Comments — للكل</div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m GET">GET</span><span class="ep-path">/api/blog</span>
      <span class="role all">All Roles</span><span class="ep-desc">كل البوستات</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — Array</span></div>
      <pre>[{ "id": 1, "title": "...", "content": "...", "imageUrl": "https://...", "createdAt": "...", "comments": [] }]</pre></div>
    </div>
  </div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m GET">GET</span><span class="ep-path">/api/blog/{id}</span>
      <span class="role all">All Roles</span><span class="ep-desc">تفاصيل بوست + comments</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response</span></div>
      <pre>{
  "id": 1, "title": "...", "content": "...",
  "imageUrl": "https://...", "createdAt": "...",
  "comments": [
    { "id": 1, "userId": "...", "userName": "Ahmed", "content": "تعليق", "createdAt": "..." }
  ]
}</pre></div>
    </div>
  </div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m POST">POST</span><span class="ep-path">/api/blog/comment</span>
      <span class="role all">All Roles</span><span class="ep-desc">إضافة تعليق</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
      <pre>{ "blogPostId": 1, "content": "تعليق رائع!" }</pre></div>
    </div>
  </div>
</div>

<!-- ══ NOTIFICATIONS PUBLIC ══ -->
<div class="sec" id="notif-pub">
  <div class="sec-title">🔔 Notifications — للكل</div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m GET">GET</span><span class="ep-path">/api/notifications/my</span>
      <span class="role all">All Roles</span><span class="ep-desc">notifications الـ user الحالي</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — Array</span></div>
      <pre>[{ "id": 1, "message": "تبرعك اتوافق!", "isRead": false, "createdAt": "..." }]</pre></div>
    </div>
  </div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m PUT">PUT</span><span class="ep-path">/api/notifications/{id}/read</span>
      <span class="role all">All Roles</span><span class="ep-desc">Mark as read</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response</span></div>
      <pre>{ "message": "Marked as read" }</pre></div>
    </div>
  </div>
</div>

<!-- ══ UPLOAD ══ -->
<div class="sec" id="upload">
  <div class="sec-title">📤 Upload Image</div>
  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m POST">POST</span><span class="ep-path">/api/upload/image</span>
      <span class="role all">All Roles</span><span class="ep-desc">رفع صورة — راجع قسم Image Upload فوق</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response</span></div>
      <pre>{ "imageUrl": "https://localhost:{PORT}/images/guid.jpg" }</pre></div>
    </div>
  </div>
</div>

<!-- ══ DONOR ══ -->
<div class="sec" id="donor">
  <div class="sec-title">🩸 Donor Endpoints</div>
  <div class="box bi"><span>ℹ️</span><span>محتاج token بـ Role = <strong>Donor</strong> — الـ donorId بيتاخد من الـ token تلقائي.</span></div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m POST">POST</span><span class="ep-path">/api/donor/donate</span>
      <span class="role don">Donor</span><span class="ep-desc">تسجيل تبرع جديد</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
      <pre>{ "bloodType": 0, "type": 0, "donationDate": "2026-03-02T10:00:00" }</pre></div>
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response</span></div>
      <pre>{ "id": 1, "donorId": "...", "donorName": "Ahmed", "bloodType": 0, "type": 0, "status": 0, "donationDate": "...", "approvedByAdminId": null }</pre></div>
    </div>
  </div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m GET">GET</span><span class="ep-path">/api/donor/history</span>
      <span class="role don">Donor</span><span class="ep-desc">سجل تبرعاتي</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — Array بنفس شكل donate</span></div>
      <pre>[{ "id": 1, "status": 1, "donationDate": "...", ... }]</pre></div>
    </div>
  </div>
</div>

<!-- ══ RECEIVER ══ -->
<div class="sec" id="receiver">
  <div class="sec-title">🏥 Receiver Endpoints</div>
  <div class="box bi"><span>ℹ️</span><span>محتاج token بـ Role = <strong>Receiver</strong>.</span></div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m POST">POST</span><span class="ep-path">/api/receiver/request</span>
      <span class="role rec">Receiver</span><span class="ep-desc">طلب دم جديد</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
      <pre>{ "bloodType": 0, "quantity": 2, "hospitalName": "Cairo Hospital", "city": "Cairo", "isUrgent": true }</pre></div>
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response</span></div>
      <pre>{ "id": 1, "receiverId": "...", "receiverName": "Sara", "bloodType": 0, "quantity": 2, "hospitalName": "Cairo Hospital", "city": "Cairo", "isUrgent": true, "status": 0, "createdAt": "..." }</pre></div>
    </div>
  </div>

  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m GET">GET</span><span class="ep-path">/api/receiver/my-requests</span>
      <span class="role rec">Receiver</span><span class="ep-desc">طلباتي</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — Array بنفس شكل request</span></div>
      <pre>[{ "id": 1, "status": 0, "isUrgent": true, ... }]</pre></div>
    </div>
  </div>
</div>

<!-- ══ ADMIN DASHBOARD ══ -->
<div class="sec" id="adm-dash">
  <div class="sec-title">📊 Admin — Dashboard</div>
  <div class="ep">
    <div class="ep-h" onclick="tog(this)">
      <span class="m GET">GET</span><span class="ep-path">/api/admin/dashboard</span>
      <span class="role adm">Admin</span><span class="ep-desc">إحصائيات النظام</span>
    </div>
    <div class="ep-b">
      <div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response</span></div>
      <pre>{
  "totalUsers": 25, "totalDonors": 18, "totalReceivers": 6,
  "totalDonations": 42, "pendingDonations": 5, "approvedDonations": 35,
  "totalBloodRequests": 20, "pendingBloodRequests": 3, "urgentBloodRequests": 2,
  "activeCampaigns": 4, "totalBlogPosts": 10
}</pre></div>
    </div>
  </div>
</div>

<!-- ══ ADMIN USERS ══ -->
<div class="sec" id="adm-users">
  <div class="sec-title">👥 Admin — Users</div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m GET">GET</span><span class="ep-path">/api/admin/users</span><span class="role adm">Admin</span><span class="ep-desc">كل المستخدمين</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — Array</span></div>
    <pre>[{ "id": "...", "fullName": "...", "email": "...", "phoneNumber": "...", "bloodType": 0, "role": 1, "isActive": true, "createdAt": "...", "profilePicture": null }]</pre></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m PUT">PUT</span><span class="ep-path">/api/admin/users/{id}/disable</span><span class="role adm">Admin</span><span class="ep-desc">تعطيل مستخدم</span></div>
    <div class="ep-b"><pre>{ "message": "User disabled successfully" }</pre></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m PUT">PUT</span><span class="ep-path">/api/admin/users/{id}/enable</span><span class="role adm">Admin</span><span class="ep-desc">تفعيل مستخدم</span></div>
    <div class="ep-b"><pre>{ "message": "User enabled successfully" }</pre></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m PUT">PUT</span><span class="ep-path">/api/admin/users/change-role</span><span class="role adm">Admin</span><span class="ep-desc">تغيير الـ role</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>{ "userId": "8e76ed2d-...", "newRole": 0 }</pre></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m DELETE">DELETE</span><span class="ep-path">/api/admin/users/{id}</span><span class="role adm">Admin</span><span class="ep-desc">حذف مستخدم نهائي</span></div>
    <div class="ep-b"><pre>{ "message": "User deleted successfully" }</pre></div>
  </div>
</div>

<!-- ══ ADMIN BLOOD REQUESTS ══ -->
<div class="sec" id="adm-blood">
  <div class="sec-title">📋 Admin — Blood Requests</div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m GET">GET</span><span class="ep-path">/api/admin/bloodrequests</span><span class="role adm">Admin</span><span class="ep-desc">كل الطلبات</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — Array</span></div>
    <pre>[{ "id": 1, "receiverName": "Sara", "bloodType": 0, "quantity": 2, "hospitalName": "...", "city": "...", "isUrgent": true, "status": 0, "createdAt": "..." }]</pre></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m PUT">PUT</span><span class="ep-path">/api/admin/bloodrequests/{id}/status</span><span class="role adm">Admin</span><span class="ep-desc">تغيير الحالة</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>{ "status": 1 }  <span style="color:#333">// 0=Pending 1=Approved 2=Rejected 3=Completed</span></pre></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m DELETE">DELETE</span><span class="ep-path">/api/admin/bloodrequests/{id}</span><span class="role adm">Admin</span><span class="ep-desc">حذف طلب</span></div>
    <div class="ep-b"><pre>{ "message": "Blood request deleted successfully" }</pre></div>
  </div>
</div>

<!-- ══ ADMIN DONATIONS ══ -->
<div class="sec" id="adm-don">
  <div class="sec-title">🩸 Admin — Donations</div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m GET">GET</span><span class="ep-path">/api/admin/donations</span><span class="role adm">Admin</span><span class="ep-desc">كل التبرعات</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">200 Response — Array</span></div>
    <pre>[{ "id": 1, "donorName": "Ahmed", "bloodType": 0, "type": 0, "status": 0, "donationDate": "...", "approvedByAdminId": null }]</pre></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m PUT">PUT</span><span class="ep-path">/api/admin/donations/{id}/approve</span><span class="role adm">Admin</span><span class="ep-desc">موافقة — بدون body</span></div>
    <div class="ep-b"><div class="box bi"><span>ℹ️</span><span>مفيش body — الـ adminId بيتاخد من الـ token تلقائي.</span></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m PUT">PUT</span><span class="ep-path">/api/admin/donations/{id}/reject</span><span class="role adm">Admin</span><span class="ep-desc">رفض — بدون body</span></div>
    <div class="ep-b"><div class="box bi"><span>ℹ️</span><span>مفيش body.</span></div></div>
  </div>
</div>

<!-- ══ ADMIN CAMPAIGNS ══ -->
<div class="sec" id="adm-camp">
  <div class="sec-title">📣 Admin — Campaigns CRUD</div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m POST">POST</span><span class="ep-path">/api/admin/campaigns</span><span class="role adm">Admin</span><span class="ep-desc">إنشاء campaign</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>{ "title": "Cairo Blood Drive", "description": "...", "location": "...", "latitude": 30.04, "longitude": 31.23, "startDate": "2026-04-01T09:00:00", "endDate": "2026-04-01T17:00:00", "imageUrl": "https://..." }</pre></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m PUT">PUT</span><span class="ep-path">/api/admin/campaigns/{id}</span><span class="role adm">Admin</span><span class="ep-desc">تعديل — نفس body الـ Create</span></div>
    <div class="ep-b"><pre>نفس شكل Create بالظبط</pre></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m PUT">PUT</span><span class="ep-path">/api/admin/campaigns/{id}/toggle</span><span class="role adm">Admin</span><span class="ep-desc">تفعيل / تعطيل — بدون body</span></div>
    <div class="ep-b"><div class="box bi"><span>ℹ️</span><span>مفيش body — بيقلب الـ isActive بين true و false.</span></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m DELETE">DELETE</span><span class="ep-path">/api/admin/campaigns/{id}</span><span class="role adm">Admin</span><span class="ep-desc">حذف campaign</span></div>
    <div class="ep-b"><pre>{ "message": "Campaign deleted successfully" }</pre></div>
  </div>
</div>

<!-- ══ ADMIN BLOG ══ -->
<div class="sec" id="adm-blog">
  <div class="sec-title">📝 Admin — Blog CRUD</div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m POST">POST</span><span class="ep-path">/api/admin/blog</span><span class="role adm">Admin</span><span class="ep-desc">إنشاء بوست</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>{ "title": "عنوان البوست", "content": "المحتوى...", "imageUrl": "https://..." }</pre></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m PUT">PUT</span><span class="ep-path">/api/admin/blog/{id}</span><span class="role adm">Admin</span><span class="ep-desc">تعديل بوست — نفس body الـ Create</span></div>
    <div class="ep-b"><pre>نفس شكل Create بالظبط</pre></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m DELETE">DELETE</span><span class="ep-path">/api/admin/blog/{id}</span><span class="role adm">Admin</span><span class="ep-desc">حذف بوست</span></div>
    <div class="ep-b"><pre>{ "message": "Blog post deleted successfully" }</pre></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m DELETE">DELETE</span><span class="ep-path">/api/admin/comments/{id}</span><span class="role adm">Admin</span><span class="ep-desc">حذف تعليق</span></div>
    <div class="ep-b"><pre>{ "message": "Comment deleted successfully" }</pre></div>
  </div>
</div>

<!-- ══ ADMIN NOTIFICATIONS ══ -->
<div class="sec" id="adm-notif">
  <div class="sec-title">🔔 Admin — Notifications</div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m POST">POST</span><span class="ep-path">/api/admin/notifications/global</span><span class="role adm">Admin</span><span class="ep-desc">إرسال لكل المستخدمين</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>{ "message": "صيانة الموقع الليلة الساعة 10" }</pre></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m POST">POST</span><span class="ep-path">/api/admin/notifications/user</span><span class="role adm">Admin</span><span class="ep-desc">إرسال لمستخدم محدد</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>{ "userId": "8e76ed2d-...", "message": "تبرعك اتوافق!" }</pre></div></div>
  </div>
  <div class="ep"><div class="ep-h" onclick="tog(this)"><span class="m POST">POST</span><span class="ep-path">/api/admin/notifications/bloodtype</span><span class="role adm">Admin</span><span class="ep-desc">إرسال بفصيلة الدم</span></div>
    <div class="ep-b"><div class="pre-wrap"><div class="pre-top"><span class="pre-lbl">Request Body</span><button class="cpbtn" onclick="cp(this)">نسخ</button></div>
    <pre>{ "bloodType": 6, "message": "محتاجين متبرعين O+ في Cairo Hospital!" }</pre></div></div>
  </div>
</div>

<!-- FOOTER -->
<div style="margin-top:56px;padding:22px 0;border-top:1px solid #111;text-align:center;color:#222;font-size:11px;font-family:var(--mono);">
  🩸 Blood Donation Management System · API v1.0 · ASP.NET Core 9 · JWT · EF Core · SQL Server
</div>

</main>

<script>
function tog(h){ const b=h.nextElementSibling; b.classList.toggle('open'); }

function cp(btn){
  const wrap = btn.closest('.pre-wrap');
  const pre = wrap ? wrap.querySelector('pre') : null;
  if(!pre) return;
  navigator.clipboard.writeText(pre.innerText.trim());
  btn.textContent='✓ تم';
  btn.classList.add('ok');
  setTimeout(()=>{ btn.textContent='نسخ'; btn.classList.remove('ok'); },2000);
}

// active nav
const secs = document.querySelectorAll('.sec');
const links = document.querySelectorAll('.sb-a');
window.addEventListener('scroll',()=>{
  let cur='';
  secs.forEach(s=>{ if(window.scrollY>=s.offsetTop-120) cur=s.id; });
  links.forEach(l=>{
    const active = l.getAttribute('href')==='#'+cur;
    l.style.color = active?'var(--red)':'';
    l.style.background = active?'#0a0000':'';
  });
});
</script>
</body>
</html>
[BloodDonation_Frontend_Handoff_FINAL.html](https://github.com/user-attachments/files/25734235/BloodDonation_Frontend_Handoff_FINAL.html)
)**

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

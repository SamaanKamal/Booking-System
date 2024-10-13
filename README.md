# Booking-System

## Overview

The Booking System is a simple application that allows users to book resources for specific time periods. It manages various resources, such as laptops and projectors, ensuring availability and preventing booking conflicts.

## Features

- View available resources
- Book resources based on availability
- Simple conflict validation
- Seeded initial data for testing
- Display success and error messages based on booking status


## Prerequisites

Make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (version 8.0 or later)
- SQLite (for database storage)
- NodeJs
- [npm](https://www.npmjs.com/) (Node package manager, usually comes with Node.js)
  
## Getting Started

Follow these steps to set up and run the application.

### 1. Clone the Repository

```bash
git clone https://github.com/SamaanKamal/Booking-System.git
cd Booking-System
```

### For Backend:
### 1. Navigate to the Backend Directory
Change to the directory where the backend code is located:

```bash
cd Backend
cd Booking System
cd Booking Sysetm
```
### 2. Restore NuGet Packages

```bash
dotnet restore
```
### 3.Apply Database Migrations

```bash
dotnet ef database update
```
### 4.run the project
```bash
dotnet run
```

### For Frontend:
### 1. Navigate to the Frontend Directory
Change to the directory where the frontend code is located:

```bash
cd Frontend
cd Booking-System
```
### 2. Install Dependencies
Run the following command to install the necessary packages:
```bash
npm install
```
### 3. Run the Application
You can now run the application with:
```bash
npm run dev
```

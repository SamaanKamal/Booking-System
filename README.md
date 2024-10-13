# Booking-System

## Overview

The Booking System is a simple application that allows users to book resources for specific time periods. It manages various resources, such as laptops and projectors, ensuring availability and preventing booking conflicts.

## Features

- View available resources
- Book resources based on availability
- Simple conflict validation
- Seeded initial data for testing

## Prerequisites

Make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (version 8.0 or later)
- SQLite (for database storage)

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


# BrewScout
🍺 BrewScout — A .NET MAUI app to discover breweries, log your beer tasting notes, and keep track of brewery events.

# 🍺 BrewScout — Brewery Finder & Event Journal (built with .NET MAUI)

[![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-Cross%20Platform-blue)](https://learn.microsoft.com/dotnet/maui/what-is-maui)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)
[![Platform](https://img.shields.io/badge/platforms-Android%20%7C%20iOS-orange.svg)]()

**BrewScout** is a cross-platform mobile app for brewery enthusiasts.  
Log your tasting notes, explore local breweries, and track upcoming events like trivia nights, food trucks, and beer releases.

---

## ✨ Features
- 📍 **Brewery Finder**  
  - Browse breweries from seed data or [Open Brewery DB](https://www.openbrewerydb.org/).  
  - View details, addresses, and open links in maps.  

- 📝 **Tasting Notes**  
  - Add and store personal beer tasting notes (beer name, style, rating, notes).  
  - Persisted locally using SQLite.  

- 🎉 **Event Finder**  
  - Add & browse brewery events (e.g. trivia, food trucks, live music).  
  - Export to calendar (.ics) for reminders.  
  - Map integration for event pins.  

- 🗺️ **Interactive Map**  
  - Display breweries and events on a map.  
  - Show user’s current location.  

---

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022 (latest) with **.NET MAUI workload** installed
- .NET 8 SDK
- Android Emulator or iOS Simulator

### Setup
```bash
# create project scaffold
dotnet new maui -n BrewScout

# copy this repo’s /src folder into your project, overwriting


# 🎮 Gacha Character Tracker

<div align="center">

![Status](https://img.shields.io/badge/status-active-success.svg)
![.NET](https://img.shields.io/badge/.NET-6.0+-512BD4.svg)
![License](https://img.shields.io/badge/license-MIT-blue.svg)

**A comprehensive ASP.NET Core MVC web application to track and manage your beloved characters from multiple gacha games!**

*Supporting Genshin Impact • Honkai: Star Rail • Zenless Zone Zero • Wuthering Waves*

</div>

---

## ✨ Features

- 🎯 **Multi-Game Support** - Track characters across four major gacha games in one place
- 📊 **Detailed Character Management** - Monitor levels, weapons, talents, artifacts, and equipment
- 🎨 **Beautiful UI** - Clean and intuitive interface with progress tracking
- 💾 **Persistent Storage** - All your data safely stored in SQL Server
- 🔍 **Smart Filtering** - Easily find and organize your character roster
- 📈 **Progress Visualization** - See your character development at a glance

---

## 🎮 Supported Games

| Game | Max Level | Special Features |
|------|-----------|------------------|
| ⚔️ **Genshin Impact** | 1-90 | Talents (Max 10), Artifacts (0-5 pieces) |
| 🚂 **Honkai: Star Rail** | 1-80 | Traces, Relics (0-6 pieces) |
| 🎸 **Zenless Zone Zero** | 1-60 | Skills (Max 12), Drive Discs (0-6) |
| 🌊 **Wuthering Waves** | 1-90 | Resonance Skills, Echoes (0-5 pieces) |

---

## 🚀 Installation & Setup

### Prerequisites

Before you begin, ensure you have the following installed:
- **.NET 6.0 SDK** or higher ([Download here](https://dotnet.microsoft.com/download))
- **SQL Server** (Express Edition or higher)
- **Visual Studio 2022** or **VS Code** (optional but recommended)

---

## 📦 Install Required NuGet Packages

### Package Manager Console
```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

### .NET CLI
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

## 🔄 Restore Dependencies

After adding the packages, restore all project dependencies:

```bash
dotnet restore
```

---

## 🗄️ Database Setup

Choose one of the following methods to set up your database:

### Option 1: SQL Server Management Studio (SSMS)

Open SSMS and execute the following SQL script to create the database and tables:

```sql
CREATE DATABASE GachaTrackers;
GO
USE GachaTrackers;
GO

-- Genshin Impact Characters Table
CREATE TABLE GenshinCharacters (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Element NVARCHAR(50) NOT NULL,
    Rarity INT DEFAULT 5,
    CurrentLevel INT DEFAULT 1,
    WeaponType NVARCHAR(50),
    WeaponName NVARCHAR(100),
    WeaponLevel INT DEFAULT 1,
    TalentBasicAttack INT DEFAULT 1,
    TalentSkill INT DEFAULT 1,
    TalentUltimate INT DEFAULT 1,
    ArtifactSet NVARCHAR(100),
    ArtifactsPieces INT DEFAULT 0
);

-- Honkai: Star Rail Characters Table
CREATE TABLE StarRailCharacters (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Element NVARCHAR(50) NOT NULL,
    Path NVARCHAR(50),
    Rarity INT DEFAULT 5,
    CurrentLevel INT DEFAULT 1,
    LightconeName NVARCHAR(100),
    LightconeLevel INT DEFAULT 1,
    TalentBasicAttack INT DEFAULT 1,
    TalentSkill INT DEFAULT 1,
    TalentUltimate INT DEFAULT 1,
    TalentTalent INT DEFAULT 1,
    RelicSet NVARCHAR(100),
    RelicPieces INT DEFAULT 0
);

-- Zenless Zone Zero Characters Table
CREATE TABLE ZZZCharacters (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Element NVARCHAR(50) NOT NULL,
    Faction NVARCHAR(50),
    Rank NVARCHAR(10) DEFAULT 'S',
    CurrentLevel INT DEFAULT 1,
    WEngineName NVARCHAR(100),
    WEngineLevel INT DEFAULT 1,
    SkillBasicAttack INT DEFAULT 1,
    SkillDodge INT DEFAULT 1,
    SkillAssist INT DEFAULT 1,
    SkillSpecialAttack INT DEFAULT 1,
    SkillChainAttack INT DEFAULT 1,
    SkillTalent INT DEFAULT 1,
    CoreSkillsCompleted INT DEFAULT 0
);

-- Wuthering Waves Characters Table
CREATE TABLE WutheringCharacters (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Element NVARCHAR(50) NOT NULL,
    Rarity INT DEFAULT 5,
    CurrentLevel INT DEFAULT 1,
    WeaponType NVARCHAR(50),
    WeaponName NVARCHAR(100),
    WeaponLevel INT DEFAULT 1,
    SkillNormalAttack INT DEFAULT 1,
    SkillResonanceSkill INT DEFAULT 1,
    SkillForteCircuit INT DEFAULT 1,
    SkillResonanceLiberation INT DEFAULT 1,
    SkillIntroSkill INT DEFAULT 1,
    StatNodesCompleted INT DEFAULT 0,
    InherentSkillsCompleted INT DEFAULT 1,
    EchoSet NVARCHAR(100),
    EchoPieces INT DEFAULT 0
);
```

### Option 2: Entity Framework Migrations (Recommended)

Use EF Core migrations to automatically create and manage your database:

```bash
# Install EF Core tools globally (one-time setup)
dotnet tool install --global dotnet-ef

# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migration to database
dotnet ef database update
```

---

## ⚙️ Configuration

Update your **appsettings.json** file with your SQL Server connection details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GachaTrackers;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> 💡 **Tip:** If your SQL Server instance has a different name, replace `localhost` with your server name (e.g., `.\SQLEXPRESS`)

---

## ▶️ Running the Application

Start the application using the .NET CLI:

```bash
dotnet run
```

Once started, navigate to one of the following URLs in your browser:

- 🔒 **HTTPS:** https://localhost:5001
- 🌐 **HTTP:** http://localhost:5000

---

## 🎮 Game-Specific Details

### ⚔️ Genshin Impact
- **Character Levels:** 1–90
- **Talent Levels:** 1–10 (Normal Attack, Elemental Skill, Elemental Burst)
- **Weapon Levels:** 1–90
- **Artifact Pieces:** 0–5 pieces per set
- **Elements:** Pyro, Hydro, Anemo, Electro, Dendro, Cryo, Geo
- **Weapon Types:** Sword, Claymore, Polearm, Bow, Catalyst

### 🚂 Honkai: Star Rail
- **Character Levels:** 1–80
- **Trace Levels:** Basic Attack, Skill, Ultimate, Talent
- **Light Cone Levels:** 1–80
- **Relic Pieces:** 0–6 pieces (4-piece set + 2-piece set)
- **Elements:** Physical, Fire, Ice, Lightning, Wind, Quantum, Imaginary
- **Paths:** Destruction, Hunt, Erudition, Harmony, Nihility, Preservation, Abundance

### 🎸 Zenless Zone Zero
- **Agent Levels:** 1–60
- **Skill Levels:** 1–12 (Basic Attack, Dodge, Assist, Special, Chain, Talent)
- **W-Engine Levels:** 1–60
- **Core Skills:** 0–6 completed
- **Ranks:** S-Rank, A-Rank
- **Factions:** Various (Cunning Hares, Victoria Housekeeping, etc.)

### 🌊 Wuthering Waves
- **Resonator Levels:** 1–90
- **Skill Levels:** 1–10 (Normal Attack, Resonance Skill, Forte Circuit, Liberation, Intro)
- **Weapon Levels:** 1–90
- **Echo Pieces:** 0–5 pieces per set
- **Stat Nodes:** Track completed stat node upgrades
- **Inherent Skills:** Track skill unlock progress

---

## 📁 Project Structure

```
GachaTracker/
│
├── 📂 Controllers/              # MVC Controllers for each game
│   ├── GenshinController.cs
│   ├── StarRailController.cs
│   ├── ZZZController.cs
│   └── WutheringController.cs
│
├── 📂 Data/                     # Database Context & Configuration
│   └── ApplicationDbContext.cs
│
├── 📂 Models/                   # Character Models for each game
│   ├── GenshinCharacter.cs
│   ├── StarRailCharacter.cs
│   ├── ZZZCharacter.cs
│   └── WutheringCharacter.cs
│
├── 📂 Views/                    # Razor Views
│   ├── Genshin/
│   ├── StarRail/
│   ├── ZZZ/
│   ├── Wuthering/
│   └── Shared/
│
├── 📂 wwwroot/                  # Static Files
│   ├── css/
│   ├── js/
│   └── images/
│
├── 📄 appsettings.json          # Application Configuration
├── 📄 Program.cs                # Application Entry Point
└── 📄 GachaTracker.csproj       # Project File
```

---

## 🐛 Troubleshooting

### Database Connection Issues

**Problem:** Cannot connect to SQL Server

**Solutions:**
- ✅ Verify SQL Server is running (check Services)
- ✅ Confirm connection string in `appsettings.json` is correct
- ✅ Test connection using SSMS first
- ✅ Ensure database `GachaTrackers` exists
- ✅ Check Windows/SQL Server authentication mode
- ✅ Verify firewall settings aren't blocking the connection

### Port Already in Use

**Problem:** Port 5000 or 5001 is already occupied

**Solution:**
Edit `Properties/launchSettings.json` and change the port numbers:

```json
"applicationUrl": "https://localhost:5002;http://localhost:5001"
```

### Migration Errors

**Problem:** EF Core migrations fail

**Solutions:**
```bash
# Remove all migrations
dotnet ef migrations remove

# Clean and rebuild
dotnet clean
dotnet build

# Recreate migrations
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Missing Packages

**Problem:** Build errors about missing packages

**Solution:**
```bash
dotnet restore
dotnet build
```

---

## 📸 Screenshots

*Coming soon! Screenshots will showcase:*

- 🏠 Home page with beautiful game selection cards
- 📋 Character list views with filtering and sorting
- ➕ Add/Edit character forms with validation
- 📊 Individual character detail pages with progress bars
- 🎨 Responsive design for mobile and desktop

---

## 🤝 Contributing

We welcome contributions from the community! Here's how you can help:

1. 🍴 **Fork the repository**
2. 🌿 **Create a feature branch:** `git checkout -b feature/AmazingFeature`
3. 💻 **Make your changes** and commit: `git commit -m 'Add some AmazingFeature'`
4. 📤 **Push to your branch:** `git push origin feature/AmazingFeature`
5. 🔀 **Open a Pull Request**

### Contribution Ideas
- 🎨 UI/UX improvements
- 🐛 Bug fixes and error handling
- 📱 Mobile responsiveness enhancements
- 🌍 Localization/translation support
- 📊 New tracking features
- 🎮 Support for additional gacha games

---

## 📝 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

This means you are free to:
- ✅ Use commercially
- ✅ Modify
- ✅ Distribute
- ✅ Private use

---

## 📊 Database Schema

### 🗂️ GenshinCharacters Table

Complete schema for tracking Genshin Impact characters:

| Column | Type | Description | Constraints |
|--------|------|-------------|-------------|
| Id | INT | Primary Key | IDENTITY, NOT NULL |
| Name | NVARCHAR(100) | Character name (e.g., "Raiden Shogun") | NOT NULL |
| Element | NVARCHAR(50) | Character element | NOT NULL |
| Rarity | INT | Character rarity stars | DEFAULT 5 |
| CurrentLevel | INT | Current character level | DEFAULT 1, Range: 1-90 |
| WeaponType | NVARCHAR(50) | Weapon category | NULL |
| WeaponName | NVARCHAR(100) | Equipped weapon name | NULL |
| WeaponLevel | INT | Current weapon level | DEFAULT 1, Range: 1-90 |
| TalentBasicAttack | INT | Normal attack talent level | DEFAULT 1, Range: 1-10 |
| TalentSkill | INT | Elemental skill level | DEFAULT 1, Range: 1-10 |
| TalentUltimate | INT | Elemental burst level | DEFAULT 1, Range: 1-10 |
| ArtifactSet | NVARCHAR(100) | Main artifact set name | NULL |
| ArtifactsPieces | INT | Number of set pieces equipped | DEFAULT 0, Range: 0-5 |

### 🗂️ StarRailCharacters Table

| Column | Type | Description | Range |
|--------|------|-------------|-------|
| Path | NVARCHAR(50) | Character path (Hunt, Destruction, etc.) | — |
| LightconeName | NVARCHAR(100) | Equipped Light Cone | — |
| TalentTalent | INT | Character passive talent level | 1-10 |
| RelicSet | NVARCHAR(100) | Main relic set | — |
| RelicPieces | INT | Relic pieces equipped | 0-6 |

### 🗂️ ZZZCharacters Table

| Column | Type | Description | Range |
|--------|------|-------------|-------|
| Faction | NVARCHAR(50) | Agent faction affiliation | — |
| Rank | NVARCHAR(10) | Agent rank | S, A |
| WEngineName | NVARCHAR(100) | Equipped W-Engine | — |
| SkillDodge | INT | Dodge skill level | 1-12 |
| SkillAssist | INT | Assist skill level | 1-12 |
| SkillSpecialAttack | INT | Special attack level | 1-12 |
| SkillChainAttack | INT | Chain attack level | 1-12 |
| CoreSkillsCompleted | INT | Completed core skills | 0-6 |

### 🗂️ WutheringCharacters Table

| Column | Type | Description | Range |
|--------|------|-------------|-------|
| SkillForteCircuit | INT | Forte Circuit skill level | 1-10 |
| SkillResonanceLiberation | INT | Resonance Liberation level | 1-10 |
| SkillIntroSkill | INT | Intro skill level | 1-10 |
| StatNodesCompleted | INT | Completed stat node upgrades | 0-∞ |
| InherentSkillsCompleted | INT | Unlocked inherent skills | 0-5 |
| EchoSet | NVARCHAR(100) | Main echo set | — |

---

## 🔮 Future Enhancements

Exciting features planned for future releases:

- 🔐 **User Authentication** - Multi-user support with personal accounts
- 📤 **Import/Export** - Backup and restore your data (JSON, CSV formats)
- 📊 **Analytics Dashboard** - Visualize your collection statistics
- 🌙 **Dark Mode** - Eye-friendly theme for night gamers
- 📱 **Mobile App** - Native iOS and Android applications
- ☁️ **Cloud Sync** - Sync your data across multiple devices
- 🎨 **Character Portraits** - Display character artwork and images
- 🔔 **Build Reminders** - Get notified about resin/stamina caps
- 📈 **Wish History Import** - Import gacha history from game logs
- 🎯 **Build Templates** - Share and import character builds
- 🌍 **Localization** - Multi-language support

---

## 📞 Support

Need help? We're here for you!

- 📖 **Documentation:** Check the [Troubleshooting](#-troubleshooting) section above
- 🐛 **Bug Reports:** [Open an Issue](https://github.com/yourusername/gacha-tracker/issues)
- 💬 **Questions:** [Start a Discussion](https://github.com/yourusername/gacha-tracker/discussions)
- 📧 **Email:** maxinepalm450@gmail.com
- 💡 **Feature Requests:** We'd love to hear your ideas!

---

## 🙏 Acknowledgments

- 🎮 Game assets and character names are property of their respective developers:
  - **Genshin Impact** © miHoYo/HoYoverse
  - **Honkai: Star Rail** © miHoYo/HoYoverse
  - **Zenless Zone Zero** © miHoYo/HoYoverse
  - **Wuthering Waves** © Kuro Games
- 🌟 Thanks to the amazing gacha gaming community for inspiration
- 💻 Built with ASP.NET Core and Entity Framework Core
- ❤️ Special thanks to all contributors and testers

---

## 📈 Project Stats

- ⭐ **Lines of Code:** 2,000+
- 🎮 **Games Supported:** 4
- 📊 **Database Tables:** 4
- 🔧 **Features:** 10+
- 💙 **Made with Love:** 100%

---

<div align="center">

**Made with ❤️ for Gacha Game Players**

*Happy Tracking! May your pulls be blessed!* ✨🎲

[⬆ Back to Top](#-gacha-character-tracker)

</div>

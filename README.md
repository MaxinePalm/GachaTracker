# 🎮 Gacha Character Tracker

<div align="center">

![Status](https://img.shields.io/badge/status-active-success.svg)
![.NET](https://img.shields.io/badge/.NET-6.0+-512BD4.svg)
![License](https://img.shields.io/badge/license-MIT-blue.svg)

**A comprehensive ASP.NET Core MVC web application to track and manage your beloved characters from multiple gacha games!**

*Supporting Genshin Impact • Honkai: Star Rail • Zenless Zone Zero • Wuthering Waves • Arknights: Endfield*

</div>

---

## ✨ Features

- 🎯 **Multi-Game Support** - Track characters across five major gacha games in one place
- 📊 **Detailed Character Management** - Monitor levels, weapons, talents, artifacts, and equipment
- 🎨 **Beautiful UI** - Clean and intuitive interface with game-specific themes and progress tracking
- 💾 **Persistent Storage** - All your data safely stored in SQL Server
- 🔍 **Smart Filtering** - Easily find and organize your character roster by element, class, or faction
- 📈 **Progress Visualization** - See your character development at a glance with color-coded progress bars
- 🎮 **Game-Specific Mechanics** - Each game has unique tracking features tailored to its progression systems

---

## 🎮 Supported Games

| Game | Max Level | Special Features | Status |
|------|-----------|------------------|--------|
| ⚔️ **Genshin Impact** | 1-90 | Talents (Max 10), Artifacts (0-5 pieces) | ✅ Active |
| 🚂 **Honkai: Star Rail** | 1-80 | Traces, Relics (0-6 pieces) | ✅ Active |
| 🎸 **Zenless Zone Zero** | 1-60 | Skills (Max 12), Drive Discs (0-6) | ✅ Active |
| 🌊 **Wuthering Waves** | 1-90 | Resonance Skills, Echoes (0-5 pieces) | ✅ Active |
| 🛡️ **Arknights: Endfield** | 1-90 | Promotions, Talents, Ship Systems | ✅ Active |

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
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Element NVARCHAR(50) NOT NULL,
    Rarity INT NOT NULL,
    CurrentLevel INT NOT NULL,
    WeaponType NVARCHAR(50),
    WeaponName NVARCHAR(100),
    WeaponLevel INT NOT NULL,
    TalentBasicAttack INT NOT NULL,
    TalentSkill INT NOT NULL,
    TalentUltimate INT NOT NULL,
    ArtifactSet NVARCHAR(100),
    ArtifactsPieces INT NOT NULL
);

-- Honkai: Star Rail Characters Table
CREATE TABLE StarRailCharacters (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Element NVARCHAR(50) NOT NULL,
    Path NVARCHAR(50),
    Rarity INT NOT NULL,
    CurrentLevel INT NOT NULL,
    LightconeName NVARCHAR(100),
    LightconeLevel INT NOT NULL,
    TalentBasicAttack INT NOT NULL,
    TalentSkill INT NOT NULL,
    TalentUltimate INT NOT NULL,
    TalentTalent INT NOT NULL,
    RelicSet NVARCHAR(100),
    RelicPieces INT NOT NULL
);

-- Zenless Zone Zero Characters Table
CREATE TABLE ZZZCharacters (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Element NVARCHAR(50) NOT NULL,
    Faction NVARCHAR(50),
    Rank NVARCHAR(10),
    CurrentLevel INT NOT NULL,
    WEngineName NVARCHAR(100),
    WEngineLevel INT NOT NULL,
    SkillBasicAttack INT NOT NULL,
    SkillDodge INT NOT NULL,
    SkillAssist INT NOT NULL,
    SkillSpecialAttack INT NOT NULL,
    SkillChainAttack INT NOT NULL,
    SkillTalent INT NOT NULL,
    CoreSkillsCompleted INT NOT NULL
);

-- Wuthering Waves Characters Table
CREATE TABLE WutheringCharacters (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Element NVARCHAR(50) NOT NULL,
    Rarity INT NOT NULL,
    CurrentLevel INT NOT NULL,
    WeaponType NVARCHAR(50),
    WeaponName NVARCHAR(100),
    WeaponLevel INT NOT NULL,
    SkillNormalAttack INT NOT NULL,
    SkillResonanceSkill INT NOT NULL,
    SkillForteCircuit INT NOT NULL,
    SkillResonanceLiberation INT NOT NULL,
    SkillIntroSkill INT NOT NULL,
    StatNodesCompleted INT NOT NULL,
    InherentSkillsCompleted INT NOT NULL,
    EchoSet NVARCHAR(100),
    EchoPieces INT NOT NULL
);

-- Arknights: Endfield Characters Table
CREATE TABLE EndfieldCharacters (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    ElementType NVARCHAR(50) NOT NULL,
    SubClass NVARCHAR(50) NOT NULL,
    WeaponType NVARCHAR(50) NOT NULL,
    CharacterLevel INT NOT NULL DEFAULT 1,
    WeaponLevel INT NOT NULL DEFAULT 1,
    
    -- Trust Talents (4 nodes)
    TrustTalent1 BIT NOT NULL DEFAULT 0,
    TrustTalent2 BIT NOT NULL DEFAULT 0,
    TrustTalent3 BIT NOT NULL DEFAULT 0,
    TrustTalent4 BIT NOT NULL DEFAULT 0,
    
    -- Talents Under Trust (4 talents)
    UnderTrustTalent1 BIT NOT NULL DEFAULT 0,
    UnderTrustTalent2 BIT NOT NULL DEFAULT 0,
    UnderTrustTalent3 BIT NOT NULL DEFAULT 0,
    UnderTrustTalent4 BIT NOT NULL DEFAULT 0,
    
    -- Ship Talents (4 talents)
    ShipTalent1 BIT NOT NULL DEFAULT 0,
    ShipTalent2 BIT NOT NULL DEFAULT 0,
    ShipTalent3 BIT NOT NULL DEFAULT 0,
    ShipTalent4 BIT NOT NULL DEFAULT 0,
    
    -- Promotion and Outfitting
    PromotionLevel INT NOT NULL DEFAULT 0,
    OutfittingLevel INT NOT NULL DEFAULT 0,
    
    -- Main Talents (4 talents, rank 1-9)
    MainTalent1 INT NOT NULL DEFAULT 1,
    MainTalent2 INT NOT NULL DEFAULT 1,
    MainTalent3 INT NOT NULL DEFAULT 1,
    MainTalent4 INT NOT NULL DEFAULT 1,
    
    CONSTRAINT CHK_CharacterLevel CHECK (CharacterLevel >= 1 AND CharacterLevel <= 90),
    CONSTRAINT CHK_WeaponLevel CHECK (WeaponLevel >= 1 AND WeaponLevel <= 90),
    CONSTRAINT CHK_PromotionLevel CHECK (PromotionLevel >= 0 AND PromotionLevel <= 4),
    CONSTRAINT CHK_OutfittingLevel CHECK (OutfittingLevel >= 0 AND OutfittingLevel <= 4),
    CONSTRAINT CHK_MainTalent1 CHECK (MainTalent1 >= 1 AND MainTalent1 <= 9),
    CONSTRAINT CHK_MainTalent2 CHECK (MainTalent2 >= 1 AND MainTalent2 <= 9),
    CONSTRAINT CHK_MainTalent3 CHECK (MainTalent3 >= 1 AND MainTalent3 <= 9),
    CONSTRAINT CHK_MainTalent4 CHECK (MainTalent4 >= 1 AND MainTalent4 <= 9)
);

-- Create indexes for better query performance
CREATE INDEX IX_EndfieldCharacters_ElementType ON EndfieldCharacters(ElementType);
CREATE INDEX IX_EndfieldCharacters_SubClass ON EndfieldCharacters(SubClass);
CREATE INDEX IX_EndfieldCharacters_WeaponType ON EndfieldCharacters(WeaponType);

-- Display all tables to confirm creation
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
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

> 💡 **Tip:** If your SQL Server instance has a different name, replace `localhost` with your server name (e.g., `.\SQLEXPRESS` or `localhost\SQLEXPRESS`)

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
- **Rarity:** 4★, 5★
- **Color Theme:** Amber/Orange gradient

### 🚂 Honkai: Star Rail
- **Character Levels:** 1–80
- **Trace Levels:** Basic Attack, Skill, Ultimate, Talent (1-10 each)
- **Light Cone Levels:** 1–80
- **Relic Pieces:** 0–6 pieces (4-piece set + 2-piece set)
- **Elements:** Physical, Fire, Ice, Lightning, Wind, Quantum, Imaginary
- **Paths:** Destruction, Hunt, Erudition, Harmony, Nihility, Preservation, Abundance
- **Rarity:** 4★, 5★
- **Color Theme:** Yellow/Purple gradient

### 🎸 Zenless Zone Zero
- **Agent Levels:** 1–60
- **Skill Levels:** 1–12 (Basic Attack, Dodge, Assist, Special, Chain, Talent)
- **W-Engine Levels:** 1–60
- **Core Skills:** 0–6 completed
- **Drive Discs:** 0-6 pieces
- **Ranks:** S-Rank, A-Rank
- **Elements:** Physical, Fire, Ice, Electric, Ether
- **Factions:** Cunning Hares, Victoria Housekeeping, Belobog Heavy Industries, Sons of Calydon, OBOLS Squad, Section 6
- **Color Theme:** Cyan/Blue gradient

### 🌊 Wuthering Waves
- **Resonator Levels:** 1–90
- **Skill Levels:** 1–10 (Normal Attack, Resonance Skill, Forte Circuit, Liberation, Intro)
- **Weapon Levels:** 1–90
- **Echo Pieces:** 0–5 pieces per set
- **Stat Nodes:** Track completed stat node upgrades (unlimited)
- **Inherent Skills:** Track skill unlock progress (0-5)
- **Elements:** Glacio, Fusion, Electro, Aero, Spectro, Havoc
- **Weapon Types:** Sword, Broadblade, Pistols, Gauntlets, Rectifier
- **Rarity:** 4★, 5★
- **Color Theme:** Emerald/Teal gradient

### 🛡️ Arknights: Endfield (NEW!)
- **Character Levels:** 1–90
- **Weapon Levels:** 1–90
- **Promotion System:** 4 levels (0-4)
  - Level 0: Max Character Level 30
  - Level 1: Max Character Level 45
  - Level 2: Max Character Level 60
  - Level 3: Max Character Level 75
  - Level 4: Max Character Level 90
- **Outfitting System:** 4 levels (0-4) - Enables higher-level artifacts
- **Talent Systems:**
  - **Trust Talent Nodes:** 4 nodes activated through trust progression
  - **Under Trust Talents:** 4 additional talents beneath trust system
  - **Ship Talents:** 4 talents used on the ship/base
  - **Main Talents:** 4 core talents, each with ranks 1-9
- **Element Types:** Cryo ❄️, Heat 🔥, Physical ⚔️, Nature 🍃, Electric ⚡
- **Sub Classes:** Guard, Caster, Striker, Vanguard, Defender, Supporter
- **Weapon Types:** Sword, Greatsword, Polearm, Handcannon, Arts Unit
- **Color Theme:** Blue/Slate gradient
- **Special Features:**
  - Multiple interconnected talent systems
  - Promotion-based level caps
  - Complex progression tracking
  - Ship/base management integration

---

## 📁 Project Structure

```
GachaTracker/
│
├── 📂 Controllers/              # MVC Controllers for each game
│   ├── GenshinController.cs
│   ├── StarRailController.cs
│   ├── ZZZController.cs
│   ├── WutheringController.cs
│   └── EndfieldController.cs   # NEW
│
├── 📂 Data/                     # Database Context & Configuration
│   └── ApplicationDbContext.cs
│
├── 📂 Models/                   # Character Models for each game
│   ├── GenshinCharacter.cs
│   ├── StarRailCharacter.cs
│   ├── ZZZCharacter.cs
│   ├── WutheringCharacter.cs
│   └── EndfieldCharacter.cs    # NEW
│
├── 📂 Views/                    # Razor Views
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Genshin/
│   │   └── Index.cshtml
│   ├── StarRail/
│   │   └── Index.cshtml
│   ├── ZZZ/
│   │   └── Index.cshtml
│   ├── Wuthering/
│   │   └── Index.cshtml
│   ├── Endfield/                # NEW
│   │   └── Index.cshtml
│   └── Shared/
│       └── _Layout.cshtml
│
├── 📂 wwwroot/                  # Static Files
│   ├── css/
│   ├── js/
│   └── images/
│
├── 📂 Migrations/               # EF Core Migrations
│   └── (auto-generated)
│
├── 📄 appsettings.json          # Application Configuration
├── 📄 appsettings.Development.json
├── 📄 Program.cs                # Application Entry Point
├── 📄 GachaTracker.csproj       # Project File
└── 📄 README.md                 # This file
```

---

## 🐛 Troubleshooting

### Database Connection Issues

**Problem:** Cannot connect to SQL Server

**Solutions:**
- ✅ Verify SQL Server is running (check Services: SQL Server (MSSQLSERVER) or SQL Server (SQLEXPRESS))
- ✅ Confirm connection string in `appsettings.json` is correct
- ✅ Test connection using SSMS first
- ✅ Ensure database `GachaTrackers` exists
- ✅ Check Windows/SQL Server authentication mode
- ✅ Verify firewall settings aren't blocking port 1433
- ✅ If using named instance, include instance name: `Server=localhost\\SQLEXPRESS`

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

### Lucide Icons Not Displaying

**Problem:** Icons appear as broken or missing

**Solutions:**
- ✅ Check internet connection (icons loaded from CDN)
- ✅ Verify `lucide.createIcons()` is called after DOM loads
- ✅ Check browser console for JavaScript errors
- ✅ Try clearing browser cache

### Modal Not Opening

**Problem:** Add/Edit modal doesn't appear

**Solutions:**
- ✅ Check JavaScript console for errors
- ✅ Verify `characterModal` element exists in DOM
- ✅ Ensure CSS class `.modal.active` has `display: flex`
- ✅ Check z-index values aren't conflicting

---

## 📸 Screenshots

*Coming soon! Screenshots will showcase:*

- 🏠 Home page with beautiful game selection cards (5 games)
- 📋 Character list views with element/class filtering
- ➕ Add/Edit character forms with comprehensive validation
- 📊 Individual character cards with detailed progress tracking
- 🎨 Responsive design optimized for mobile, tablet, and desktop
- 🌈 Game-specific color themes and visual identity
- 📈 Progress bars with dynamic color coding

---

## 🤝 Contributing

We welcome contributions from the community! Here's how you can help:

1. 🍴 **Fork the repository**
2. 🌿 **Create a feature branch:** `git checkout -b feature/AmazingFeature`
3. 💻 **Make your changes** and commit: `git commit -m 'Add some AmazingFeature'`
4. 📤 **Push to your branch:** `git push origin feature/AmazingFeature`
5. 🔀 **Open a Pull Request**

### Contribution Ideas
- 🎨 UI/UX improvements and theme enhancements
- 🐛 Bug fixes and error handling
- 📱 Mobile responsiveness enhancements
- 🌍 Localization/translation support
- 📊 New tracking features and statistics
- 🎮 Support for additional gacha games
- 🖼️ Character portrait/image upload system
- 📈 Data visualization and analytics
- 🔍 Advanced search and filter options
- 💾 Import/Export functionality

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
| Name | NVARCHAR(100) | Character name | NOT NULL |
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
| Id | INT | Primary Key | IDENTITY |
| Name | NVARCHAR(100) | Character name | NOT NULL |
| Element | NVARCHAR(50) | Character element | NOT NULL |
| Path | NVARCHAR(50) | Character path | NULL |
| Rarity | INT | Character rarity | DEFAULT 5 |
| CurrentLevel | INT | Current level | 1-80 |
| LightconeName | NVARCHAR(100) | Equipped Light Cone | NULL |
| LightconeLevel | INT | Light Cone level | 1-80 |
| TalentBasicAttack | INT | Basic attack trace | 1-10 |
| TalentSkill | INT | Skill trace | 1-10 |
| TalentUltimate | INT | Ultimate trace | 1-10 |
| TalentTalent | INT | Passive talent trace | 1-10 |
| RelicSet | NVARCHAR(100) | Main relic set | NULL |
| RelicPieces | INT | Relic pieces equipped | 0-6 |

### 🗂️ ZZZCharacters Table

| Column | Type | Description | Range |
|--------|------|-------------|-------|
| Id | INT | Primary Key | IDENTITY |
| Name | NVARCHAR(100) | Agent name | NOT NULL |
| Element | NVARCHAR(50) | Agent element | NOT NULL |
| Faction | NVARCHAR(50) | Agent faction | NULL |
| Rank | NVARCHAR(10) | Agent rank | S, A |
| CurrentLevel | INT | Current level | 1-60 |
| WEngineName | NVARCHAR(100) | Equipped W-Engine | NULL |
| WEngineLevel | INT | W-Engine level | 1-60 |
| SkillBasicAttack | INT | Basic attack skill | 1-12 |
| SkillDodge | INT | Dodge skill | 1-12 |
| SkillAssist | INT | Assist skill | 1-12 |
| SkillSpecialAttack | INT | Special attack | 1-12 |
| SkillChainAttack | INT | Chain attack | 1-12 |
| SkillTalent | INT | Talent skill | 1-6 |
| CoreSkillsCompleted | INT | Completed core skills | 0-6 |

### 🗂️ WutheringCharacters Table

| Column | Type | Description | Range |
|--------|------|-------------|-------|
| Id | INT | Primary Key | IDENTITY |
| Name | NVARCHAR(100) | Resonator name | NOT NULL |
| Element | NVARCHAR(50) | Resonator element | NOT NULL |
| Rarity | INT | Resonator rarity | DEFAULT 5 |
| CurrentLevel | INT | Current level | 1-90 |
| WeaponType | NVARCHAR(50) | Weapon type | NULL |
| WeaponName | NVARCHAR(100) | Equipped weapon | NULL |
| WeaponLevel | INT | Weapon level | 1-90 |
| SkillNormalAttack | INT | Normal attack skill | 1-10 |
| SkillResonanceSkill | INT | Resonance skill | 1-10 |
| SkillForteCircuit | INT | Forte Circuit | 1-10 |
| SkillResonanceLiberation | INT | Liberation skill | 1-10 |
| SkillIntroSkill | INT | Intro skill | 1-10 |
| StatNodesCompleted | INT | Completed stat nodes | 0-∞ |
| InherentSkillsCompleted | INT | Unlocked inherent skills | 0-5 |
| EchoSet | NVARCHAR(100) | Main echo set | NULL |
| EchoPieces | INT | Echo pieces equipped | 0-5 |

### 🗂️ EndfieldCharacters Table (NEW!)

Complete schema for tracking Arknights: Endfield Endfielders:

| Column | Type | Description | Range/Values |
|--------|------|-------------|--------------|
| Id | INT | Primary Key | IDENTITY, NOT NULL |
| Name | NVARCHAR(100) | Endfielder name | NOT NULL |
| ElementType | NVARCHAR(50) | Element type | Cryo, Heat, Physical, Nature, Electric |
| SubClass | NVARCHAR(50) | Character class | Guard, Caster, Striker, Vanguard, Defender, Supporter |
| WeaponType | NVARCHAR(50) | Weapon category | Sword, Greatsword, Polearm, Handcannon, Arts Unit |
| CharacterLevel | INT | Current character level | 1-90 |
| WeaponLevel | INT | Current weapon level | 1-90 |
| **Trust System** | | | |
| TrustTalent1-4 | BIT | Trust talent nodes | Boolean (0/1) |
| UnderTrustTalent1-4 | BIT | Talents under trust | Boolean (0/1) |
| **Ship System** | | | |
| ShipTalent1-4 | BIT | Ship talents | Boolean (0/1) |
| **Progression** | | | |
| PromotionLevel | INT | Promotion level (affects max level) | 0-4 |
| OutfittingLevel | INT | Outfitting level (artifact tier) | 0-4 |
| **Main Talents** | | | |
| MainTalent1-4 | INT | Core talent ranks | 1-9 each |

**Calculated Properties (in C# Model):**
- `TotalTrustTalentsUnlocked` - Count of active trust talents (0-4)
- `TotalUnderTrustTalentsUnlocked` - Count of active under-trust talents (0-4)
- `TotalShipTalentsUnlocked` - Count of active ship talents (0-4)
- `TotalMainTalentRanks` - Sum of all main talent ranks (4-36)
- `MaxCharacterLevel` - Max level based on promotion (30/45/60/75/90)

---

## 🔮 Future Enhancements

Exciting features planned for future releases:

### Priority Features
- 🔐 **User Authentication** - Multi-user support with personal accounts and role-based access
- 📤 **Import/Export** - Backup and restore your data (JSON, CSV, Excel formats)
- 📊 **Analytics Dashboard** - Visualize collection statistics, completion rates, resource needs
- 🖼️ **Character Portraits** - Upload and display character artwork/images
- 🔔 **Build Reminders** - Notifications for resin/stamina caps and daily tasks

### Enhanced Functionality
- 🌙 **Dark Mode** - Eye-friendly theme toggle for night gaming sessions
- 📱 **Mobile App** - Native iOS and Android applications with offline support
- ☁️ **Cloud Sync** - Synchronize data across multiple devices
- 🎯 **Build Templates** - Share and import character builds with the community
- 🌍 **Localization** - Multi-language support (English, Chinese, Japanese, Korean, etc.)
- 📈 **Wish History Import** - Import gacha history directly from game logs

### Advanced Features
- 🤖 **AI Build Suggestions** - Smart recommendations based on your roster
- 📅 **Event Calendar** - Track banner schedules and in-game events
- 💰 **Resource Calculator** - Calculate materials needed for character upgrades
- 🏆 **Achievement System** - Track collection milestones and goals
- 📊 **Comparison Tool** - Compare multiple characters side-by-side
- 🎨 **Custom Themes** - User-created color schemes and layouts
- 🔍 **Advanced Filtering** - Multi-criteria search with saved filters
- 📝 **Notes System** - Add personal notes and ratings to characters
- 🎮 **Additional Games** - Blue Archive, Nikke, Tower of Fantasy, etc.

---

## 📞 Support

Need help? We're here for you!

- 📖 **Documentation:** Check the [Troubleshooting](#-troubleshooting) section above
- 🐛 **Bug Reports:** [Open an Issue](https://github.com/yourusername/gacha-tracker/issues)
- 💬 **Questions:** [Start a Discussion](https://github.com/yourusername/gacha-tracker/discussions)
- 📧 **Email:** maxinepalm450@gmail.com
- 💡 **Feature Requests:** We'd love to hear your ideas!
- 📱 **Community:** Join our Discord server (coming soon!)

---

## 🛠️ Technology Stack

- **Backend Framework:** ASP.NET Core 6.0+ MVC
- **Database:** SQL Server (2016+)
- **ORM:** Entity Framework Core 6.0+
- **Frontend:** 
  - HTML5, CSS3 (Tailwind CSS via CDN)
  - JavaScript (ES6+)
  - Lucide Icons
- **Authentication:** (Planned) ASP.NET Core Identity
- **Architecture:** Model-View-Controller (MVC)
- **Development Environment:** Visual Studio 2022 / VS Code

---

## 🙏 Acknowledgments

- 🎮 Game assets and character names are property of their respective developers:
  - **Genshin Impact** © miHoYo/HoYoverse
  - **Honkai: Star Rail** © miHoYo/HoYoverse
  - **Zenless Zone Zero** © miHoYo/HoYoverse
  - **Wuthering Waves** © Kuro Games
  - **Arknights: Endfield** © Hypergryph/Studio Montagne
- 🌟 Thanks to the amazing gacha gaming community for inspiration and feedback
- 💻 Built with ASP.NET Core and Entity Framework Core
- 🎨 UI components inspired by modern game launchers
- 🖼️ Icons provided by Lucide Icons
- ❤️ Special thanks to all contributors, testers, and gacha game enthusiasts

---

## 📈 Project Stats

- ⭐ **Lines of Code:** 3,500+
- 🎮 **Games Supported:** 5
- 📊 **Database Tables:** 5
- 🔧 **Features:** 15+
- 📱 **Responsive Breakpoints:** 4
- 🎨 **Color Themes:** 5 (game-specific)
- 💙 **Made with Love:** 100%

---

## 🔄 Version History

### v1.2.0 (Latest) - Arknights: Endfield Support
- ✅ Added complete Arknights: Endfield tracking system
- ✅ Implemented promotion system with level caps
- ✅ Added multiple talent systems (Trust, Ship, Main)
- ✅ Created outfitting system for artifact tiers
- ✅ Updated home page with new game card
- ✅ Enhanced database schema with indexes

### v1.1.0 - Enhanced Features
- ✅ Improved UI/UX with game-specific themes
- ✅ Added element/faction filtering for all games
- ✅ Implemented progress bars with color coding
- ✅ Enhanced modal forms with better validation
- ✅ Optimized database queries

### v1.0.0 - Initial Release
- ✅ Support for Genshin Impact, Star Rail, ZZZ, Wuthering Waves
- ✅ CRUD operations for all characters
- ✅ SQL Server database integration
- ✅ Responsive design
- ✅ Basic filtering and search

---

## 🎯 Roadmap

### Q1 2025
- [ ] User authentication system
- [ ] Character image upload
- [ ] Dark mode implementation
- [ ] Export to JSON/CSV

### Q2 2025
- [ ] Analytics dashboard
- [ ] Resource calculator
- [ ] Mobile app development
- [ ] Cloud sync beta

### Q3 2025
- [ ] Build template sharing
- [ ] Wish history import
- [ ] Advanced filtering
- [ ] Community features

### Q4 2025
- [ ] AI build suggestions
- [ ] Additional game support
- [ ] Localization (5+ languages)
- [ ] Mobile app release

---

<div align="center">

**Made with ❤️ for Gacha Game Players**

*Happy Tracking! May your pulls be blessed and your artifacts be perfect!* ✨🎲

---

### Quick Links
[🏠 Home](#-gacha-character-tracker) • [📦 Installation](#-installation--setup) • [🎮 Games](#-supported-games) • [🐛 Issues](#-troubleshooting) • [🤝 Contribute](#-contributing)

---

⭐ If you find this project helpful, please consider giving it a star on GitHub!

</div>

# BulkyWebApp


নিচের short note-টা তোমার `.md` file-এ add করতে পারো।

## EF Core Migration (Windows & Ubuntu)

### 1. Install EF Core Tool
```bash
dotnet tool install --global dotnet-ef
```

Update if already installed:
```bash
dotnet tool update --global dotnet-ef
```

### 2. Create Migration
```bash
dotnet ef migrations add InitialCreate
```

### 3. Apply Migration to Database
```bash
dotnet ef database update
```

### 4. Windows vs Ubuntu

| Task | Windows (CLI) | Ubuntu |
|---|---|---|
| Create Migration | `dotnet ef migrations add MigrationName` | Same |
| Update Database | `dotnet ef database update` | Same |
| Remove Last Migration | `dotnet ef migrations remove` | Same |

**Visual Studio Package Manager Console:**
```powershell
Add-Migration InitialCreate
Update-Database
```

### 5. Use Migration Across Operating Systems

1. Create migration on Windows or Ubuntu.
2. Commit migration files to Git.
3. Push changes to GitHub.
4. Pull the project on the other OS.
5. Run `dotnet restore`.
6. Run `dotnet ef database update`.

### Important Notes
- Migration files are shared through Git.
- Keep EF Core package and SDK versions compatible.
- Check the connection string before updating the database.
- The same migration should not be recreated on the other OS.
- `dotnet ef database update` applies pending migrations to the configured database.
- Review migrations before applying them to production.
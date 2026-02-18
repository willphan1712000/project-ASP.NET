# Project_ASP.NET_Web
- Build a MVC web app using ASP.NET

### Create a MVC weeb app
```bash
dotnet new mvc -n [project_name]
```

### Run the app in watch mode
```bash
dotnet watch run
```

### Create database context - If models not exist, it creates models from existing database

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=ASP_NET_Web;User=root;Password=;" Pomelo.EntityFrameworkCore.MySql -o Models
```

### Run migration to generate migration file

```bash
dotnet ef migrations add [name_of_migration]
```

### Remove the last migration that was created

```bash
dotnet ef migrations remove
```

### Apply migration to sync models with database

```bash
dotnet ef database update
```

### Revert migration

```bash
dotnet ef database update [name_of_migration]
```

### Export SQL Script from Migrations

```bash
dotnet ef migrations script -o deploy.sql
```
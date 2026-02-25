# Project_ASP.NET_Web
- This helps me understand how every component is working together under the hood using ASP.NET Core Framework.

## What I've built 
- Build a web app using ASP.NET MVC
- Build APIs using ASP.NET Web API
- Build Database using Entity Framework Core

> [!NOTE]
> I've built a little frontend but not focused because I am concentrating on the server logic and server side rendering for HTML markup done by the server that will be sent to the client.

## Try the project
- First, you need to have a local database ready for running this application with connection string and save it in .env file

- Second, your machine needs to have dotnet runtime installed

- Third, run all migrations
```bash
dotnet ef database update
```

- Fourth, Run this command to start the application
```bash
dotnet run
```
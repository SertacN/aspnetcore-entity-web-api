## CRUD prosses with Entity Framework Core and SQL Server

Simple way to create Web API and SQL Database Use EntityFrameWorkCore and SQL Server.

### IDEs and Packages

- Microsoft Visual Studio
- ASP.Net Core 7 Web Api
- Entity Framework Core
- SQL Server (Im using dev version)
- SQL Server Manager

#### 1- Added Packages in Project

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.SqlServer

#### 2- Configure "appsettings.json" file

Add DevConnection to ConnectionStrings

- Example:

```js
"ConnectionStrings": {
  "DevConnection": "Server=(local);DataBase=UsersDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
  }
```

Server= Use **your** server name what ever you use

#### 3- Create C# class for data

_Check my Users.cs file for information._

#### 4- Create DbContext with Entity Framework

Add all models in _DbContext_
Dont forget using EntityFrameworkCore **DbContext**

Example:

```js
using Microsoft.EntityFrameworkCore;

namespace EntitySQLApiStudy.ApiStudy.Models
{
    public class APIDbContext: DbContext
    {
        public APIDbContext(DbContextOptions option):base(option)
        {

        }
        public DbSet<Users> Users { get; set; }

    }
}
```

#### 5- Add DbContext to Program.cs file

```js
builder.Services.AddDbContext <
  APIDbContext >
  ((options) =>
    options.UseSqlServer(
      builder.Configuration.GetConnectionString("DevConnection")
    ));
```

**Note:**
Dont forget import using _Microsoft.EntityFrameworkCore_;

- APIDbContext this is what i call. If you give different name, change <APIDbContext>
- "DevConnection" if you set different name in appsettings.json, change this.

#### 6- Build project for errors

Before migration try to build project for error. If get any error fix it first.

#### 7- Migration and Update Database

Go to _tools > NuGet Package Manager > Package Manager Console_

- Execute migration command and push Database to SQL server

In Package Manager Console , execute `Add-Migration "(give migration name here)"`
When migration succesfull execute `Update-Database`

#### 8- Create Web Api with EntityFrameWork Core

In Controller folder _add Controller_ and select _API_ then _"API Controller with actions, using Entity Framework"_

#### 9- Select Model Class and DbContext Class

In my case model class is _Users.cs_ and DbContext Class is _APIDbContext_

#### 10- Open end Point with swashbuckle

After create controller with entityframework we have end point web api. Can _get,post,delete,update_ methods using end point.

**Note:**
Create table in Visiual Studio (Users.cs example) then Migration then Update Database
Use SQL Server Manager for check Database.Can added new table item in server manager.

#### Bonus: CORS Error Solution

If you get CORS error when trying fetch data, added this line of code in Program.cs

```js
builder.Services.AddCors((options) => {
  options.AddPolicy("AllowAnyOrigin", (builder) => {
    builder
      .AllowAnyOrigin() // Allow all resources
      .AllowAnyMethod()
      .AllowAnyHeader();
  });
});
```

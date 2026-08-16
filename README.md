# Car Rental App

A full-stack project including:
- Frontend in Angular
- Backend in ASP.NET Web API
- SQL Server LocalDB database

The app includes vehicle listing, car booking, registration, login, payments, and rental history.

## Technologies

- Angular 17
- TypeScript
- ASP.NET Web API 2
- Entity Framework 6
- SQL Server LocalDB
- Bootstrap

## Project Structure

- `Frontend/` - Angular application
- `Backend/` - .NET solution containing:
  - `API/` - Web API project
  - `BL/` - Business Logic Layer
  - `DAL/` - Data Access Layer
  - `Cars.sln` - Visual Studio solution

## System Requirements

Before running the project, make sure you have installed:
- Node.js 18+
- npm
- Visual Studio 2022 / Visual Studio 2019
- SQL Server LocalDB
- .NET Framework 4.7.2

## Run the Frontend

1. Open a terminal in the `Frontend` folder.
2. Install dependencies:

```bash
npm install
```

3. Start the application:

```bash
npm start
```

4. Open the browser at:

```text
http://localhost:4200
```

## Run the Backend

1. Open the solution file:

```text
Backend/Cars.sln
```

2. In Visual Studio:
   - set `API` as the startup project
   - ensure NuGet packages are restored
   - run the app with F5

3. The Web API usually runs at:

```text
http://localhost:xxxxx/api
```

## Database Connection

The project uses LocalDB with an `.mdf` file. Check the connection configuration in:

- `Backend/API/Web.config`

> Important: if the project was moved to a different machine or folder, the `CarsDB.mdf` path may need to be updated.

The current connection may point to an older path such as:

```text
C:\Users\user1\Downloads\פרויקט אנגולר\CarsTamar2\DAL\CarsDB.mdf
```

In that case, update it to the correct path in your current project, for example:

```text
Backend/DAL/CarsDB.mdf
```

## Run the Project Together

- Frontend: http://localhost:4200
- Backend API: http://localhost:<port>/api

## Main Features

- Car listing
- Car details
- Rental process
- Payment flow
- Login and registration
- Rental history

## Notes

This project is a legacy ASP.NET Web API application and is best run through Visual Studio for the backend.

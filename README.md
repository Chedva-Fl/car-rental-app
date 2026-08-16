# פרויקט השכרת רכבים

פרויקט Full-Stack הכולל:
- Frontend ב-Angular
- Backend ב-ASP.NET Web API
- מסד נתונים SQL Server LocalDB

הפרויקט כולל תצוגת רכבים, הזמנת רכב, הרשמה, התחברות, תשלום, והיסטוריית השכרות.

## טכנולוגיות

- Angular 17
- TypeScript
- ASP.NET Web API 2
- Entity Framework 6
- SQL Server LocalDB
- Bootstrap

## מבנה הפרויקט

- `Frontend/` - אפליקציית Angular
- `Backend/` - פתרון .NET הכולל:
  - `API/` - Web API
  - `BL/` - Business Logic Layer
  - `DAL/` - Data Access Layer
  - `Cars.sln` - פתרון Visual Studio

## דרישות מערכת

לפני הפעלה, וודא שהתקנת:
- Node.js 18+ 
- npm
- Visual Studio 2022 / Visual Studio 2019
- SQL Server LocalDB
- .NET Framework 4.7.2

## הפעלת Frontend

1. פתח terminal ב-Frontend
2. התקן חבילות:

```bash
npm install
```

3. הפעל את השרת:

```bash
npm start
```

4. פתוח את הדפדפן בכתובת:

```text
http://localhost:4200
```

## הפעלת Backend

1. פתח את קובץ הפתרון:

```text
Backend/Cars.sln
```

2. ב-Visual Studio:
   - בחר את הפרויקט `API` כפרויקט התחלה
   - ודא שה-NuGet packages מותקנים
   - הפעל את היישום (F5)

3. Web API יתנגן בדרך כלל בכתובת:

```text
http://localhost:xxxxx/api
```

## חיבור למסד הנתונים

הפרויקט משתמש ב-LocalDB עם קובץ MDB/ MDF. יש לבדוק את קובץ החיבור ב:

- `Backend/API/Web.config`

> חשוב: אם עברתם את הפרויקט למיקום אחר ב-PC, ייתכן שהנתיב ל-`CarsDB.mdf` לא עודכן. יש לעדכן את connection string כך שיצביע למסד הנכון.

החיבור הנוכחי מכוון לנתיב ישן יחסית, לדוגמה:

```text
C:\Users\user1\Downloads\פרויקט אנגולר\CarsTamar2\DAL\CarsDB.mdf
```

במקרה כזה, יש להחליף לנתיב החדש של התיקייה `Backend/DAL/CarsDB.mdf` במחשב שלך.

## הרצת הפרויקט יחד

- Frontend: http://localhost:4200
- Backend API: http://localhost:<port>/api

## תכונות עיקריות

- רשימת רכבים
- פרטי רכב
- שיתוף/ביצוע השכרה
- תהליך תשלום
- התחברות והרשמה
- היסטוריית הזמנות

## הערות

אם ברצונך, אוכל גם להוסיף:
- README באנגלית
- תמונת מצב מסך של הממשק
- הסבר על כל API endpoint
- קובץ .gitignore מתאים לפרויקט
- הרצת פרויקט דרך Docker

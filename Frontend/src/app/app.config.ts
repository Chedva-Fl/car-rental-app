// import { BrowserModule } from '@angular/platform-browser';
// import { NgModule } from '@angular/core';
// import { AppComponent } from './app.component';
// import { AppRoutingModule } from './app.routes'; // 🔹 ייבוא

// @NgModule({
//   declarations: [AppComponent],
//   imports: [BrowserModule, AppRoutingModule], // 🔹 כאן
//   bootstrap: [AppComponent]
// })
// export class AppModule { }


import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http'; // 👈 זה מה שהיה חסר!
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient() // 👈 זה מחליף את ה-HttpClientModule של פעם
  ]
};
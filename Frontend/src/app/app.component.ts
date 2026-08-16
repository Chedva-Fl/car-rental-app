import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DesplayCarsComponent } from './desplay-cars/desplay-cars.component';
import { LoginComponent } from './login/login.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DesplayCarsComponent, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'cars-rental';
}
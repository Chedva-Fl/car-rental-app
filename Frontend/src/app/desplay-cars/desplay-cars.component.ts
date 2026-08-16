import { Component, OnInit } from '@angular/core';
import { CarsService, CarsDTO } from '../Services/cars.service';
import { Router } from '@angular/router'; // ייבוא הראוטר
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-desplay-cars',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './desplay-cars.component.html',
  styleUrls: ['./desplay-cars.component.css']
})
export class DesplayCarsComponent implements OnInit {
  arr: CarsDTO[] = [];

  // הוספנו את הראוטר כאן ב-Constructor
  constructor(private service: CarsService, private router: Router) { }

  ngOnInit(): void {
    // בדיקה שהמשתמש שמור
    console.log("המשתמש ששמור ב-LocalStorage הוא:", localStorage.getItem('currentUser'));
    
    // הבאת הרכבים מהשרת
    this.service.getAll().subscribe(cars => {
      this.arr = cars;
    });
  }

  rentCar(car: CarsDTO) {
    console.log('המשתמש בחר להשכיר רכב שמספרו:', car.IdCar);
    
    // עכשיו זה לא יהיה אדום!
    this.router.navigate(['/rent', car.IdCar]); 
  }
}
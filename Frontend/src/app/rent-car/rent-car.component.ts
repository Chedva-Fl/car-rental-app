import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarsService, CarsDTO } from '../Services/cars.service'; // ייבוא השירות וה-DTO
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-rent-car',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './rent-car.component.html',
  styleUrls: ['./rent-car.component.css']
})
export class RentCarComponent implements OnInit {
  carId: number = 0;
  selectedCar?: CarsDTO; // כאן נשמור את כל נתוני הרכב
  startDate: string = '';
  endDate: string = '';
  totalPrice: number = 0;

  constructor(
    private route: ActivatedRoute, 
    private carService: CarsService
  ) { }

  ngOnInit(): void {
    // 1. קבלת ה-ID מהכתובת
    const idParam = this.route.snapshot.paramMap.get('id');
    this.carId = Number(idParam);

    // 2. שליפת פרטי הרכב המלאים מהשירות (כדי לקבל את המחיר האמיתי)
    this.carService.getAll().subscribe(allCars => {
      this.selectedCar = allCars.find(c => c.IdCar === this.carId);
    });
  }

  calculatePrice() {
    if (this.startDate && this.endDate && this.selectedCar) {
      const start = new Date(this.startDate);
      const end = new Date(this.endDate);
      
      // 1. חישוב סך כל הימים (הפרש בין תאריכים)
      const diffTime = Math.abs(end.getTime() - start.getTime());
      const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)); 
  
      if (diffDays <= 0) {
        this.totalPrice = 0;
        return;
      }
  
      // 2. חישוב חבילות של 3 ימים (כמה פעמים נכנס 3 בתוך מספר הימים)
      const threeDayPackages = Math.floor(diffDays / 3); 
      
      // 3. חישוב הימים שנשארו (שארית מחלוקה ב-3)
      const remainingDays = diffDays % 3; 
  
      // 4. חישוב המחיר הסופי:
      // (מספר החבילות * מחיר מבצע ל-3 ימים) + (שארית הימים * מחיר ליום רגיל)
      this.totalPrice = (threeDayPackages * this.selectedCar.priceThreeDays) + 
                         (remainingDays * this.selectedCar.priseDay);
                         
      console.log(`חישוב: ${threeDayPackages} חבילות מבצע ו-${remainingDays} ימים רגילים`);
    }
  }

  confirmOrder() {
    console.log('הזמנה בוצעה עבור רכב:', this.carId);
    alert(`הזמנה נקלטה! סה"כ לתשלום: ${this.totalPrice} ₪`);
    
    // כאן בהמשך תוכלי להוסיף ניתוב לעמוד תשלום
  }

} // זה הסוגר שסוגר את כל ה-Class. הוא חייב להיות האחרון בקובץ!
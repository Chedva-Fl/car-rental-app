import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RentalsService } from '../Services/rentals.service';
import { CustomerDTO } from '../Models/custemers.dto'; 

@Component({
  selector: 'app-payment',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  // נתוני השכרה ומערכת
  rentData: any; 
  currentUser: CustomerDTO | null = null;
  carId: string = ''; 
  totalPrice: number = 0;
  startDate: string = '';
  endDate: string = '';
  today: string = new Date().toISOString().split('T')[0];

  
  showPaymentForm: boolean = false; 
  isProcessing: boolean = false;
  errorMessage: string = '';


  creditCard: string = '';
  validity: string = ''; 
  cvc: string = '';

  constructor(
    private router: Router,
    private rentalsService: RentalsService
  ) {
    const navigation = this.router.getCurrentNavigation();
    this.rentData = navigation?.extras.state;
  }

  ngOnInit(): void {
    // אתחול נתונים
    if (this.rentData) {
      this.carId = this.rentData.carId;
      this.startDate = this.rentData.startDate;
      this.endDate = this.rentData.endDate;
      this.totalPrice = this.rentData.totalPrice;
    }

    // שליפת משתמש מחובר מה-Session
    const userJson = sessionStorage.getItem('currentUser');
    if (userJson) {
      this.currentUser = JSON.parse(userJson);
    }
  }

  confirmOrder() {
    if (this.totalPrice > 0) {
      this.showPaymentForm = true;
      window.scrollTo({ top: 0, behavior: 'smooth' });
    } else {
      this.errorMessage = "אנא בחר תאריכים תקינים לפני המשך";
    }
  }

  calculatePrice() {
    if (this.startDate && this.endDate) {
      const start = new Date(this.startDate);
      const end = new Date(this.endDate);
      const diffTime = end.getTime() - start.getTime();
      const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
      
      const pricePerDay = 250; 
      this.totalPrice = diffDays > 0 ? diffDays * pricePerDay : 0;
    }
  }

  submitPayment() {
    if (!this.currentUser) {
      alert("נא להתחבר למערכת כדי לבצע הזמנה");
      this.router.navigate(['/login']);
      return;
    }

    this.isProcessing = true;
    this.errorMessage = '';

    // בניית האובייקט לשמירה בטבלת Payments
    const paymentToSave: any = {
      IdPay: 0,
      creditCard: this.creditCard,
      validity: this.validity,
      cvc: Number(this.cvc),
      idCars: Number(this.carId), 
      idCustemers: this.currentUser?.Id || (this.currentUser as any)?.id || 0,
      startDate: this.startDate,
      endDate: this.endDate,
      goalRent: String(this.totalPrice) 
    };

   
    const userId = this.currentUser?.Id || (this.currentUser as any)?.id || 0;

    console.log("שולח נתונים לשרת עבור משתמש:", userId, paymentToSave);

    // שליחת הנתונים ל-Service עם ה-UserId
    this.rentalsService.addRental(paymentToSave, userId).subscribe({
      next: (res: any) => {
        alert("התשלום בוצע בהצלחה!.");
        
        this.isProcessing = false;
        this.router.navigate(['/history']); 
      },
      error: (err: any) => {
        console.error("שגיאה בשמירת התשלום:", err);
        this.errorMessage = "חלה שגיאה בשמירת הנתונים. וודא שהשרת פועל.";
        this.isProcessing = false;
      }
    });
  }

  cancel() {
    if (this.showPaymentForm) {
      this.showPaymentForm = false; 
    } else {
      this.router.navigate(['/cars']); 
    }
  }
}
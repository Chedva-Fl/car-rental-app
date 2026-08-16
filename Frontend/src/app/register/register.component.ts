import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CustomerService, CustomerDTO } from '../Services/customers.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule], // חייב FormsModule כדי להשתמש ב-ngModel
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  // משתנים שיחוברו ל-HTML בעזרת ngModel
  firstName: string = '';
  lastName: string = '';
  Id: string = '';
  email: string = '';
  cityId: number = 1; // ערך ברירת מחדל

  constructor(private customerService: CustomerService, private router: Router) {}

  onSubmit() {
    const newCustomer: CustomerDTO = {
      Id: Number(this.Id),
      firstName: this.firstName,
      lastName: this.lastName,
      idCity: Number(this.cityId),
      email: this.email,
      numOfLendings: 0 
      // idPayment: 1  <-- מחקנו את השורה הזאת!
    };
  
    this.customerService.register(newCustomer).subscribe({
      next: (res) => {
        if (res) {
          alert('נרשמת בהצלחה!');
          this.router.navigate(['/login']);
        } else {
          alert('הרישום נכשל - ייתכן שה-ID כבר קיים במערכת');
        }
      },
      error: (err) => console.error(err)
    });
  }
   
  }
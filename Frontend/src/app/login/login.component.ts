import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule, Router } from '@angular/router'; 
import { CustomerService, CustomerDTO } from '../Services/customers.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule], 
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  email: string = '';
  password: string = ''; // המשתמש מזין כאן את ה-ID שלו כסיסמה

  customers: CustomerDTO[] = [];
  loggedInCustomer?: CustomerDTO;

  loading: boolean = false;
  error: string = '';

  constructor(
    private customerService: CustomerService, 
    private router: Router
  ) {}

  login() {
    this.loading = true;
    this.error = '';

    // מביאים את כל הלקוחות מהשרת
    this.customerService.getAll().subscribe({
      next: (data: CustomerDTO[]) => {
        this.customers = data;

        // חיפוש משתמש שגם האימייל שלו וגם ה-ID שלו (בתור סיסמה) תואמים
        const user = this.customers.find(c => 
          c.email.toLowerCase() === this.email.trim().toLowerCase() && 
          c.Id.toString() === this.password.trim()
        );

        if (!user) {
          // אם לא נמצא שילוב כזה של אימייל וסיסמה
          this.error = 'אימייל או סיסמה שגויים. נסו שוב.';
          this.loading = false;
        } else {
          // --- כאן קורה הקסם: שמירת המשתמש בזיכרון של הדפדפן ---
          localStorage.setItem('currentUser', JSON.stringify(user));
          
          this.loggedInCustomer = user;
          console.log('Login successful! Welcome:', user.firstName);
          
          this.loading = false;

          // מעבר לעמוד המכוניות (כפי שמופיע בדרישות הפרויקט )
          this.router.navigate(['/cars']); 
        }
      },
      error: (err) => {
        console.error('Connection error:', err);
        this.error = 'לא ניתן להתחבר לשרת. ודאו ש-Visual Studio רץ.';
        this.loading = false;
      }
    });
  }
}
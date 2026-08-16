
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  // 1. הוספנו // אחרי ה-https
  // 2. הוספנו / בסוף הכתובת כדי שהחיבור יצליח
  url = "https://localhost:44353/api/custemers/"; 

  constructor(private http: HttpClient) { }
// פונקציה עזר לשמירת משתמש
saveUser(user: any) {
  localStorage.setItem('currentUser', JSON.stringify(user));
}

// פונקציה לקבלת המשתמש המחובר כרגע
getCurrentUser() {
  const user = localStorage.getItem('currentUser');
  return user ? JSON.parse(user) : null;
}

// פונקציית התנתקות (חשוב שיהיה)
logout() {
  localStorage.removeItem('currentUser');
}
  getAll(): Observable<CustomerDTO[]> {
    // עכשיו זה יצא: https://localhost:44353/api/custemers/getall
    return this.http.get<CustomerDTO[]>(this.url + 'getall');
  }

  register(customer: CustomerDTO): Observable<boolean> {
    // עכשיו זה יצא: https://localhost:44353/api/custemers/add
    return this.http.post<boolean>(this.url + 'add', customer);
  }
}

export interface CustomerDTO {
  Id: number;
  firstName: string;
  lastName: string;
  idCity: number;
  email: string;
  numOfLendings: number; 
  idPayment?: number;   
}


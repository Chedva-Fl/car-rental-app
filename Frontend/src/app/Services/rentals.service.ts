
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RenlsDTO } from '../Models/renls.dto';

@Injectable({
  providedIn: 'root'
})
export class RentalsService {
  private baseUrl: string = 'http://localhost:50552/api'; 

  constructor(private http: HttpClient) { }

  /**
   * הוספת השכרה ועדכון אוטומטי של אמצעי תשלום ללקוח
   * @param rental אובייקט נתוני התשלום וההשכרה
   * @param customerId מזהה הלקוח לעדכון ב-DB
   */
  addRental(rental: any, customerId: number): Observable<any> {
    // אנחנו שולחים את ה-customerId כחלק מהנתיב (Route) כפי שהגדרנו ב-C#
    return this.http.post<any>(`${this.baseUrl}/payments/add/${customerId}`, rental);
  }
  
  getHistoryByUserId(userId: any): Observable<RenlsDTO[]> {
    const idStr = String(userId).split(':')[0];
    const cleanId = parseInt(idStr, 10);
    return this.http.get<RenlsDTO[]>(`${this.baseUrl}/rentals/gethistorybyuser/${cleanId}`);
  }
}
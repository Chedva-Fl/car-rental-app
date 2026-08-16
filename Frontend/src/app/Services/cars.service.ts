import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  url="https://localhost:44353/api/cars/";
  constructor(private bhttp:HttpClient) { }
  getAll():Observable<CarsDTO[]>{
    return this.bhttp.get<CarsDTO[]>(this.url+'getall')
  }
}
export interface CarsDTO {
  IdCar: number;         // במקום carCode
  numPlace: number;      
  level: number;
  priseDay: number;      // במקום priceOfDay (שימי לב ל-s במקור)
  priceThreeDays: number; // במקום priceOfWeek
  }

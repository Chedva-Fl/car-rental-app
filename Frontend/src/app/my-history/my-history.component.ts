import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RentalsService } from '../Services/rentals.service';
import { RenlsDTO } from '../Models/renls.dto';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-my-history',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './my-history.component.html',
  styleUrls: ['./my-history.component.css']
})
export class MyHistoryComponent implements OnInit {
  ordersList: RenlsDTO[] = [];
  errorMessage: string = '';

  constructor(private rentalsService: RentalsService) { }

  ngOnInit(): void {
    const userJson = sessionStorage.getItem('currentUser');
    if (userJson) {
      const user = JSON.parse(userJson);
      // שליפה בטוחה של ה-ID
      const userId = user.Id || user.id; 
      if (userId) {
        this.loadHistory(userId);
      }
    } else {
      this.errorMessage = "אינך מחובר למערכת.";
    }
  }

  loadHistory(userId: any) {
    this.rentalsService.getHistoryByUserId(userId).subscribe({
      next: (res) => {
        this.ordersList = res;
        console.log("היסטוריה נטענה בהצלחה:", res);
      },
      error: (err) => {
        console.error('שגיאה בטעינה:', err);
        this.errorMessage = "לא ניתן לטעון את ההיסטוריה כרגע.";
      }
    });
  }
}
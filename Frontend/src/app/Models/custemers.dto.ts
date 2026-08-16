
  export interface CustomerDTO {
    Id: number;
    firstName: string;
    lastName: string;
    idCity: number;
    email: string;
    numOfLendings: number;
    idPayment?: number;
    Payments?: any; 
}
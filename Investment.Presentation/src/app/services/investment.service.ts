import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InvestmentRequest } from '../model/InvestmentRequest';
import { InvestmentResponse } from '../model/InvestmentResponse';

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {

  private apiUrl = 'https://localhost:44380/run-calculate-cdb';

  constructor(private http: HttpClient) { }

  OnCalculate(investmentRequest: InvestmentRequest): Observable<InvestmentResponse> {
    return this.http.post<InvestmentResponse>(this.apiUrl, investmentRequest);
  }
}

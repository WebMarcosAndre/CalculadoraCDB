import { Component } from '@angular/core';
import { InvestmentService } from '../../services/investment.service';
import { InvestmentRequest } from '../../model/InvestmentRequest';



@Component({
  selector: 'app-calculate-cdb',
  templateUrl: './calculate-cdb.component.html',
  styleUrl: './calculate-cdb.component.css'
})
export class CalculateCdbComponent {
  investmentRequest: InvestmentRequest = {
    initialAmount: 0,
    termInMonths: 0
  };

  initialAmount: number = 0;
  termInMonths: number = 0;
  grossAmount: number = 0;
  netAmount: number = 0;
  errorResponse: string = "";
  hasSuccess: boolean = true;
  showResponse: boolean = false;

  constructor(private investmentService: InvestmentService) { }

  OnCalculate() {

    this.errorResponse = "";
    this.investmentRequest.initialAmount = this.initialAmount;
    this.investmentRequest.termInMonths = this.termInMonths;

    this.investmentService.OnCalculate(this.investmentRequest).subscribe(
      response => {
        console.log(response);
        this.grossAmount = response.GrossAmount;
        this.netAmount = response.NetAmount;
        this.hasSuccess = true;
        this.showResponse = true;
      },
      error => {
        console.log(error);
        this.errorResponse = error.error;
        this.hasSuccess = false;
        this.showResponse = true;
      });
  }
}

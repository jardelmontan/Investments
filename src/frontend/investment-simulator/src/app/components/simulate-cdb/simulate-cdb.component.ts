import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { environment } from '../../../environments/environment';
import { SimulateCdbResponse } from '../../interfaces/simulate-cdb-response';
import { CommonModule } from '@angular/common';
import { formatCurrencyToBrl } from '../../utils/format';

@Component({
  selector: 'app-simulate-cdb',
  standalone: true,
  imports: [CommonModule, FormsModule, NgxMaskDirective, NgxMaskPipe],
  templateUrl: './simulate-cdb.component.html',
  providers: [provideNgxMask()],
  styleUrl: './simulate-cdb.component.css',
})
export class SimulateCdbComponent {
  readonly apiUrl: string = environment.apiUrl;
  errorMessage: string | null = null;

  initialAmount?: number;
  totalMonths?: number;
  resultSimulateCdb?: SimulateCdbResponse;

  formatToBrl = formatCurrencyToBrl;

  isAmountValid(amount?: number): boolean {
    return amount != undefined && amount > 0;
  }

  constructor(private http: HttpClient) {}

  simulate() {
    const payload = {
      initialAmount: this.initialAmount,
      totalMonths: this.totalMonths,
    };

    this.http
      .post<SimulateCdbResponse>(
        `${this.apiUrl}/simulate-investment/cdb`,
        payload
      )
      .subscribe({
        next: (res) => {
          this.resultSimulateCdb = res;
          this.errorMessage = null;
        },
        error: () => {
          this.errorMessage = 'Erro ao simular investimento. Tente novamente.';
        },
      });
  }
}

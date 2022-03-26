import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from 'src/models/Book';
import { Loan } from 'src/models/Loan';
import { ServiceBase } from './servicebase';


@Injectable()
export class LoanService {
    pathBase: string = "/loan";

    constructor(private http: HttpClient) { }


    public saveLoan(loan: Loan): Observable<Loan> {
        return this.http.post<Loan>(ServiceBase.urlPadrao + this.pathBase, loan);
    }

    public updateLoan(loan: Loan|undefined): Observable<Loan> {
        return this.http.put<Loan>(`${ServiceBase.urlPadrao}${this.pathBase}`,loan);
    }


}
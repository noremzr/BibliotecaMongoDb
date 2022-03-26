import { Loan } from "./Loan";

export class Book {
    public bookId: number;
    public title: string;
    public autor: string;
    public listLoan: Loan[];
    public lastLoan:Loan|undefined;

    constructor(bookId: number, title: string, autor: string, listLoan: Loan[],lastLoan:Loan|undefined) {
        this.bookId = bookId;
        this.title = title;
        this.autor = autor;
        this.listLoan = listLoan;
        this.lastLoan = this.lastLoan;
    }
}
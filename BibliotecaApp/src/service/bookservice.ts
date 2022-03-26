import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from 'src/models/Book';
import { ServiceBase } from './servicebase';


@Injectable()
export class BookService {
    pathBase: string = "/book";

    constructor(private http: HttpClient) { }

    public GetBooks(): Observable<Book[]> {
        return this.http.get<Book[]>(ServiceBase.urlPadrao + this.pathBase);
    }

    public saveBook(book: Book): Observable<Book> {
        return this.http.post<Book>(ServiceBase.urlPadrao + this.pathBase, book);
    }

    public deleteBook(book: Book): Observable<Book> {
        return this.http.delete<Book>(`${ServiceBase.urlPadrao}${this.pathBase}/${book.bookId}`);
    }


}
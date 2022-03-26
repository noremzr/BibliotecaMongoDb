export class Loan {
    public bookId: number;
    public userId: String;
    public returned: Date|null;
    public borrowed: Date;

    constructor(bookId: number, userId: String, returned:Date|null, borrowed:Date) {
        this.bookId = bookId;
        this.userId = userId;
        this.returned = returned;
        this.borrowed = borrowed;
    }
}
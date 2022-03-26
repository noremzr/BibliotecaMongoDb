import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { Book } from 'src/models/Book';
import { Loan } from 'src/models/Loan';
import { BookService } from 'src/service/bookservice';
import { LoanService } from 'src/service/loanservice';
import Swal from 'sweetalert2';
import { LoanRegisterDialogCompoent } from '../loan-register-dialog/loan-register-dialog.component';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {

  constructor(private bookService: BookService,
    private loanService:LoanService,
    private toastr: ToastrService,
    private dialog: MatDialog) { }

  dataSource: Book[] = [];
  filterDataSource:Book[]=[];

  displayedColumns: string[] = ['title', 'autor','lastLoanStart','lastLoanUser','countLoans', 'actions'];

  title: string = "";
  autor: string = "";
  id: number = 0;

  ngOnInit(): void {
    this.bookService.GetBooks().subscribe(x =>{
       this.dataSource = x;
       this.filterDataSource=x;
    });
    
  }
  saveBook() {
    if (this.title.replace(" ","").length==0){
      this.toastr.error("Informe o titulo");
    }else if (this.autor.replace(" ","").length==0){
      this.toastr.error("Informe o autor");
    }
    let book: Book = new Book(this.id, this.title, this.autor, [],undefined);
      this.bookService.saveBook(book).subscribe((book)=>{
        let newDataSource: Book[] = [];
      this.dataSource.forEach(x => {
        if (this.id!=x.bookId){
          newDataSource.push(x)
        }
      });
      newDataSource.push(book);
      this.dataSource = newDataSource;
      this.filterDataSource=this.dataSource;
      this.toastr.success("Livro cadastrado com sucesso");
        });
  }

  editarLivro(book:Book){
    this.title=book.title;
    this.autor=book.autor;
    this.id=book.bookId;
  }

  limpaCampos(){
    this.title="";
    this.id=0;
    this.autor="";
  }

  emprestarLivro(book:Book){
    const dialogRef = this.dialog.open(LoanRegisterDialogCompoent, {
      width: '300px',
      data: {userId: ""},
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if (result==undefined || result.replace(" ","").length==0){
        return;
      }
      let loan:Loan = new Loan(book.bookId,result,null,new Date());
      this.loanService.saveLoan(loan).subscribe(x=>{
        this.dataSource.forEach(book=>{
          if (book.bookId==x.bookId){
            book.listLoan.push(x);
            book.lastLoan=x;
          }
          let newDataSource:Book[]=[];
          this.dataSource.forEach(book=>{newDataSource.push(book)});
          this.dataSource=newDataSource;

        });
        Swal.fire(
          'Livro emprestado com sucesso!',
          "",
          'success',
        )
      });
    });
  }

  filtrar(event: Event) {
    console.log(1);
    let filterValue = (event.target as HTMLInputElement).value;
    filterValue = filterValue.trim().toLowerCase();
    if (filterValue.trim().length==0){
      this.filterDataSource=this.dataSource;
    }else{
      this.filterDataSource = this.dataSource.filter(x=>x.autor.toLowerCase().includes(filterValue)
      ||x.bookId.toString().includes(filterValue)
      ||x.title.toLowerCase().includes(filterValue));
    }
}

  devolverLivro(book:Book){
    Swal.fire({
      title: 'Você confirma a devolução deste livro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Confirmar!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.value) {
        let loan:Loan|undefined = book.lastLoan;
        if (loan==undefined){
          return;
        }
        loan.returned=new Date();
        this.loanService.updateLoan(loan).subscribe((loan)=>{
          this.dataSource.forEach(book=>{
            if (book.bookId==loan.bookId){
              book.lastLoan=loan;
              book.listLoan.forEach(loans=>{
                if (loans.returned==null){
                  loans=loan;
                }
              })
            }
          })
        });
        Swal.fire(
          'Livro devolvido com sucesso!',
          "",
          'success',
        )
      }
    })
  }

  removeBook(book: Book) {
    Swal.fire({
      title: 'Você confirma a remoção deste livro?',
      text: 'Isso vai remover todos os empréstimos vinculados a ele também!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Deletar!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.value) {
        this.bookService.deleteBook(book).subscribe((book)=>{
          this.dataSource.splice(this.dataSource.indexOf(book), 1);
          let newDataSource: Book[] = [];
          this.dataSource.forEach(x => newDataSource.push(x));
          this.dataSource = newDataSource;
          Swal.fire(
            'Ação realizada com sucesso!',
            "",
            'success',
          )
        })
      }
    })
  }
}

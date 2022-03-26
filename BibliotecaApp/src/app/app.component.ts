import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Biblioteca';


  constructor(private router: Router) { }

  goToBook() {
    this.router.navigateByUrl('/books')
  }

  goToHome() {
    this.router.navigateByUrl('/home')
  }
}

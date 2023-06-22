import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CrudApp';
  constructor(private router: Router){}
  goToCategories(){
    this.router.navigate(['category'])
  }
  goToProducts(){
    this.router.navigate(['product'])
  }
}

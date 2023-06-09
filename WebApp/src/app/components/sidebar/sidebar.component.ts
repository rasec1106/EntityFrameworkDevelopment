import { Component } from '@angular/core';
import { Category } from 'src/app/model/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  // categories = ["Option 1", "Option 2", "Option 3"]
  categories: Category[] = []
  constructor(private categoryService:CategoryService){
    // We are using reactive programming, so we need to subscribe to the publisher
    categoryService.getCategories().subscribe(res => {
      this.categories = res
    })
  }
}

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/model/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent {
  currentCategory: Category = {}
  
  constructor(private categoryService: CategoryService, private router: Router){
    this.currentCategory = this.categoryService.currentCategory
  }

  submit(category: Category){
    if(category.categoryId == 0) this.addCategory(category)
    else this.updateCategory(category)
  }
  
  addCategory(category: Category){
    this.categoryService.addCategory(category).subscribe(res=>{
      this.router.navigate(['/category'])
    })
  }
  
  updateCategory(category: Category){
    category.categoryId = this.currentCategory.categoryId
    this.categoryService.updateCategory(category).subscribe(res=>{
      this.router.navigate(['/category'])
    })
  }

}

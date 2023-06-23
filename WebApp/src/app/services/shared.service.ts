import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Category } from '../model/category';
@Injectable({
providedIn: 'root'
})
export class SharedService {
private subject = new Subject<any>();
currentCategory: Category = {}

sendClickEvent(category: Category) {
  this.currentCategory = category
  this.subject.next(true);
}
getClickEvent(): Observable<any>{ 
  return this.subject.asObservable();
}
}
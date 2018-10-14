import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  name : string;
  age : number = 21;
  users : any[] = [
    {
      id : 1,
      name : "nhan",
      age : 21,
      job: "student"
    },
    {
      id : 2,
      name : "thanh",
      age: 21,
      job: "student"

    },
    {
      id : 3,
      name : "ga",
      age: 21,     
       job: "student"

    }
  ];  

  txtName : string = '';

  onGetFullName(value)
  {
    this.txtName = value;
  }
}

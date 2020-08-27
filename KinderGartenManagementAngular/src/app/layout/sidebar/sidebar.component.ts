import { Component, OnInit } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  items: NbMenuItem[] = [
    {
      title: 'Home',
      link: '/'
    },
    {
      title: 'Employees',
      expanded : false,
      children : [
        {
          title : 'EmployeeList',
          link : '/employees'
        },
        {
          title : 'Add',
          link : '/employees/add'
        }
      ]
    },
    {
      title: 'Eleves',
      link:"/eleves/list"
    }
   ];
  constructor() { }

  ngOnInit(): void {
  }

}

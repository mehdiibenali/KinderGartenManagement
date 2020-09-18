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
      title: 'Employers',
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
    },
    {
      title: 'Parents',
      link:"/parents/list"
    },
    {
      title:'Conventions',
      link:"/conventions/list"
    },
   ];
  constructor() { }

  ngOnInit(): void {
  }

}

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
      title: 'Employés',
      link:"/employees",
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
    {
      title:'Clubs d\'été',
      link:'/summerclubs/list'
    },
    {
      title:'Clubs d\'hiver',
      link:'/winterclubs/list'
    },
    {
      title:'Groupes',
      link:'/groupes/list'
    },
    {
      title:'Imprimer',
      link:'/print'
    }
   ];
  constructor() { }

  ngOnInit(): void {
  }

}

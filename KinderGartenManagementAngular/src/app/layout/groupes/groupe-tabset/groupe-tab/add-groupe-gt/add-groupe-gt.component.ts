import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-groupe-gt',
  templateUrl: './add-groupe-gt.component.html',
  styleUrls: ['./add-groupe-gt.component.css']
})
export class AddGroupeGtComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  GroupeAdded(){
    this.router.navigate(['groupes/list'])
  }
  CancelAdd(){
    this.router.navigate(['groupes/list'])
  }
}

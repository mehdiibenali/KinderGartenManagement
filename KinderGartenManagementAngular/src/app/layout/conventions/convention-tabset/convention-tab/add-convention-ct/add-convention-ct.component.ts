import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-convention-ct',
  templateUrl: './add-convention-ct.component.html',
  styleUrls: ['./add-convention-ct.component.css']
})
export class AddConventionCtComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  ConventionAdded(){
    this.router.navigate(['conventions/list'])
  }
  CancelAdd(){
    this.router.navigate(['conventions/list'])
  }
}

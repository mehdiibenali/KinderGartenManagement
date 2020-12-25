import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-winter-club-wct',
  templateUrl: './add-winter-club-wct.component.html',
  styleUrls: ['./add-winter-club-wct.component.css']
})
export class AddWinterClubWctComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  ClubAdded(){
    this.router.navigate(['winterclubs/list'])
  }
  CancelAdd(){
    this.router.navigate(['winterclubs/list'])
  }
}

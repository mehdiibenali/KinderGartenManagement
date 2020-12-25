import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-summer-club-sct',
  templateUrl: './add-summer-club-sct.component.html',
  styleUrls: ['./add-summer-club-sct.component.css']
})
export class AddSummerClubSctComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  ClubAdded(){
    this.router.navigate(['summerclubs/list'])
  }
  CancelAdd(){
    this.router.navigate(['summerclubs/list'])
  }
}

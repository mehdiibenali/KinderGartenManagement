import { Component, OnInit } from '@angular/core';
import { Club } from 'src/app/_core/_models/club';
import { WinterClubService } from 'src/app/_core/_services/winter-club.service';

@Component({
  selector: 'app-winter-clublist',
  templateUrl: './winter-clublist.component.html',
  styleUrls: ['./winter-clublist.component.css']
})
export class WinterClublistComponent implements OnInit {
  Clubs : Club[] = [];
  constructor(
    private winterClubService:WinterClubService,
  ) { }

  ngOnInit(): void {
    this.winterClubService.GetAll().subscribe(
      data=>{this.Clubs=data},
      err=>{console.log(err)}
    )
  }

}

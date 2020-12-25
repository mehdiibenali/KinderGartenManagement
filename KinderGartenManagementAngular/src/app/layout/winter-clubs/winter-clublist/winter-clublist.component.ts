import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Club } from 'src/app/_core/_models/club';
import { WinterClubService } from 'src/app/_core/_services/winter-club.service';

@Component({
  selector: 'app-winter-clublist',
  templateUrl: './winter-clublist.component.html',
  styleUrls: ['./winter-clublist.component.css']
})
export class WinterClublistComponent implements OnInit {
  Clubs:Club[]=[]
  constructor(private clubService:WinterClubService,private router:Router) { }
  ngOnInit(): void {
    this.GetAll();
  }
  GetAll(){
    this.clubService.GetAll().subscribe(
      data=>{this.Clubs=data},
      err=>{console.log(err)}
    )
  }
  Delete(id){

  }
  Edit(id){

  }
  CheckDisabled(ee){
    return ee.length>0
  }
  AddClub(){
    this.router.navigate(['winterclubs/fiche/winterclub/add'])
  }
}

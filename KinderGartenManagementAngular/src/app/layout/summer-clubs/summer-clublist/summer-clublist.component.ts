import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Club } from 'src/app/_core/_models/club';
import { SummerClubService } from 'src/app/_core/_services/summer-club.service';

@Component({
  selector: 'app-summer-clublist',
  templateUrl: './summer-clublist.component.html',
  styleUrls: ['./summer-clublist.component.css']
})
export class SummerClublistComponent implements OnInit {
  Clubs:Club[]=[]
  constructor(private clubService:SummerClubService,private router:Router) { }
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
    this.router.navigate(['summerclubs/fiche/summerclub/add'])
  }
}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Groupe } from 'src/app/_core/_models/groupe';
import { GroupeService } from 'src/app/_core/_services/groupe.service';

@Component({
  selector: 'app-groupelist',
  templateUrl: './groupelist.component.html',
  styleUrls: ['./groupelist.component.css']
})
export class GroupelistComponent implements OnInit {

  Groupes:Groupe[]=[]
  constructor(private groupeService:GroupeService,private router:Router) { }
  ngOnInit(): void {
    this.GetAll();
  }
  GetAll(){
    this.groupeService.GetAll().subscribe(
      data=>{this.Groupes=data},
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
  AddGroupe(){
    this.router.navigate(['groupes/fiche/groupe/add'])
  }
}

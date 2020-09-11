import { Component, OnInit } from '@angular/core';
import { EleveService } from 'src/app/_core/_services/eleve.service';
import { NbToastrService } from '@nebular/theme';
import { Router } from '@angular/router';
import { Eleve } from 'src/app/_core/_models/eleve';
import { SearchEleve } from 'src/app/_core/_models/search-eleve';
import { GroupeService } from 'src/app/_core/_services/groupe.service';

@Component({
  selector: 'app-elevelist',
  templateUrl: './elevelist.component.html',
  styleUrls: ['./elevelist.component.css']
})
export class ElevelistComponent implements OnInit {
  Eleves:Eleve[]=[];
  search:SearchEleve=new SearchEleve();
  Classes:Object[]=[]
  constructor(
    private groupeService:GroupeService,
    private eleveService:EleveService,
    private toastrService: NbToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.GetAll();
    this.GetAllClasses();
  }
  GetAll(){
    this.eleveService.GetAll()
    .subscribe(data => {
      this.Eleves = data;
    },
    error => {  
      console.log(error);
    })
  }
  GetAllClasses(){
    this.groupeService.GetAllClasses().subscribe(
      data=>this.Classes=data,
      err=>console.log(err)
    )
  }
  Delete(id){
    return this.eleveService.DeleteEleve(id).subscribe(
      (success)=>{
        this.toastrService.show('User deleted successfully', 'Delete',{status: 'success'});
        this.GetAll();
      },
      (error)=>{
        this.toastrService.show('Server error', 'Delete',{status: 'danger'});
      }
    )
  }
  Edit(id){
    this.router.navigate(['/eleves/fiche/eleve/'+id])
  }
  AddEleve(){
    this.router.navigate(["eleves/fiche/eleve/add"])
  }
  Search(){
    this.eleveService.Search(this.search).subscribe(
      data=>{this.Eleves=data},
      err=>console.log(err)
    )
  }
}

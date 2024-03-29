import { Component, OnInit } from '@angular/core';
import { EleveService } from 'src/app/_core/_services/eleve.service';
import { NbToastrService } from '@nebular/theme';
import { Router } from '@angular/router';
import { Eleve } from 'src/app/_core/_models/eleve';
import { SearchEleve } from 'src/app/_core/_models/search-eleve';
import { GroupeService } from 'src/app/_core/_services/groupe.service';
import { Groupe } from 'src/app/_core/_models/groupe';
import { SummerClubService } from 'src/app/_core/_services/summer-club.service';
import { Convention } from 'src/app/_core/_models/convention';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { ParameterService } from 'src/app/_core/_services/parameter.service';
import { SearchGroupe } from 'src/app/_core/_models/search-groupe';

@Component({
  selector: 'app-elevelist',
  templateUrl: './elevelist.component.html',
  styleUrls: ['./elevelist.component.css']
})
export class ElevelistComponent implements OnInit {
  Eleves:Eleve[]=[];
  search:SearchEleve=new SearchEleve();
  searchgroupe:SearchGroupe=new SearchGroupe();
  Classes:Object[]=[];
  Groupes:Groupe[]=[];
  Clubs:Groupe[]=[];
  Conventions:Convention[]=[];
  constructor(
    private groupeService:GroupeService,
    private summerClubService:SummerClubService,
    private eleveService:EleveService,
    private parentService:ParentService,
    private parameterService:ParameterService,
    private toastrService: NbToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.parameterService.GetByCode('CurrentScolarYear').subscribe(
      data=>{this.searchgroupe.annees=data[0].value.split('-')},
      err=>console.log(err)
    )
    this.Search();
    this.GetAllClasses();
    this.SearchGroupe();
    this.GetAllSummerClubs();
    this.GetAllConventions();
  }
  // GetAll(){
  //   this.eleveService.GetAll()
  //   .subscribe(data => {
  //     this.Eleves = data;
  //     console.log(this.Eleves)
  //   },
  //   error => {  
  //     console.log(error);
  //   })
  // }
  GetAllClasses(){
    this.groupeService.GetAllClasses().subscribe(
      data=>this.Classes=data,
      err=>console.log(err)
    )
  }
  GetAllSummerClubs(){
    this.summerClubService.GetAll().subscribe(
      data=>this.Clubs=data,
      err=>console.log(err)
    )
  }
  GetAllConventions(){
    this.parentService.GetAllConventions().subscribe(
      data=>{this.Conventions=data},
      err=>console.log(err)
    )
  }
  Delete(id){
    return this.eleveService.DeleteEleve(id).subscribe(
      (success)=>{
        this.toastrService.show('Eleve supprimé', 'Suppression',{status: 'success'});
        this.Search();
      },
      (error)=>{
        this.toastrService.show('Une erreur est survenue', 'Suppression',{status: 'danger'});
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
  SearchGroupe(){
    this.searchgroupe.classeid=this.search.classeid;
    this.groupeService.Search(this.searchgroupe).subscribe(
      data=>this.Groupes=data,
      err=>console.log(err)
    )
  }
  CheckParentSearch(){
    if (this.search.parentsearch == ''){this.search.parentsearch=null};
    this.Search();
  }
}

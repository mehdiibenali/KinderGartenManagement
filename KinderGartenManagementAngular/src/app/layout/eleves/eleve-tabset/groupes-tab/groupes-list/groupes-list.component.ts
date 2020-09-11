import { Component, OnInit } from '@angular/core';
import { GroupeService } from 'src/app/_core/_services/groupe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { Groupe } from 'src/app/_core/_models/groupe';
import { EleveGroupe } from 'src/app/_core/_models/eleve-groupe';
import { SearchGroupe } from 'src/app/_core/_models/search-groupe';
import { Classe } from 'src/app/_core/_models/classe';

@Component({
  selector: 'app-groupes-list',
  templateUrl: './groupes-list.component.html',
  styleUrls: ['./groupes-list.component.css']
})
export class GroupesListComponent implements OnInit {
  eleveid:number;
  eleveId:any;
  Groupes:Groupe[]=[];
  searchresult:Groupe[]=[];
  groupeid:number;
  search:SearchGroupe=new SearchGroupe()
  Years:Object[];
  SelectedYear:any=new Object;
  Classes:Classe[]=[];
  elevegroupe:EleveGroupe = new EleveGroupe();
  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private groupeService:GroupeService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.eleveId=this._Activatedroute.snapshot.paramMap.get("eleveid");
    this.eleveid=this.eleveId;
    this.GetByEleveId();
    this.groupeService.GetYears().subscribe(
      data=>{
        this.SelectedYear.CurrentYear=data.filter(y=>y.current==true)[0].debut+'-'+data.filter(y=>y.current==true)[0].fin;
        this.Years=data},
      err=>console.log(err)
    )
    this.groupeService.GetAllClasses().subscribe(
      data=>{this.Classes=data},
      err=>console.log(err)
    )
  };
  GetByEleveId(){
    this.groupeService.GetGroupesByEleveId(this.eleveid).subscribe(data => {
      this.Groupes = data;
    },
    error => {  
      console.log(error);
    });
  };
  AddGroupe(){
    this.router.navigate(["eleves/fiche/"+this.eleveid+"/groupes/add"])
  }
  DeleteEleveGroupe(groupeid:number){
    this.groupeService.DeleteEleveGroupe(this.eleveid,groupeid).subscribe(
      (success) => {
        this.toastrService.show('Groupe Supprimé De L\'éleve', 'Delete', { status: 'success' });
        this.GetByEleveId();
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
          console.log(error);
      } 
    );
  }
  Search(){
    this.search.annees=this.SelectedYear.CurrentYear.split('-');
    this.groupeService.Search(this.search).subscribe(
      data=>{this.searchresult=data},
      err=>console.log(err)
    )
  }
  AddEleveGroupe(groupeid,name){
    this.search.enrollementsearch=name;
    this.groupeid=groupeid
  }
  SubmitEleveGroupe(){
    if (this.groupeid==null){return}
    this.elevegroupe.eleveid=this.eleveid;
    this.elevegroupe.enrollementid=this.groupeid;
    this.elevegroupe.subscriptiontype="Groupe";
    this.groupeService.AddEleveGroupe(this.elevegroupe).subscribe(
      (success) => {
        this.toastrService.show('Groupe added successfully', 'Add', { status: 'success' });
        this.groupeid=null;
        this.search=new SearchGroupe();
        this.searchresult=[];
        this.GetByEleveId();
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
          console.log(error);
      } 
    )
  }

}

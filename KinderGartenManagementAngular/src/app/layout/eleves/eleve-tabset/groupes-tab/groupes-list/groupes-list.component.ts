import { Component, OnInit } from '@angular/core';
import { GroupeService } from 'src/app/_core/_services/groupe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { Groupe } from 'src/app/_core/_models/groupe';
import { EleveGroupe } from 'src/app/_core/_models/eleve-groupe';

@Component({
  selector: 'app-groupes-list',
  templateUrl: './groupes-list.component.html',
  styleUrls: ['./groupes-list.component.css']
})
export class GroupesListComponent implements OnInit {
  eleveid:any;
  Groupes:Groupe[]=[];
  groupesearch:string;
  searchresult:Groupe[]=[];
  groupeid:number;
  elevegroupe:EleveGroupe = new EleveGroupe();
  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private groupeService:GroupeService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
    this.GetByEleveId();
  };
  GetByEleveId(){
    this.groupeService.GetGroupesByEleveId(this.eleveid).subscribe(data => {
      this.Groupes = data;
      console.log(this.Groupes);
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
  GroupeExistant(){
    if (this.groupesearch!==''){
      this.groupeService.SearchByName(this.groupesearch).subscribe(
        data=>{this.searchresult=data},
      )
    }

  }
  CheckGroupe(result){
    return this.Groupes.filter(e=>e.id===result.id).length==0;
  }
  AddEleveGroupe(groupeid,name){
    this.groupesearch=name;
    this.groupeid=groupeid
  }
  SubmitEleveGroupe(){
    if (this.groupeid==null){return}
    this.elevegroupe.EleveId=this.eleveid;
    this.elevegroupe.GroupeId=this.groupeid;
    this.groupeService.AddEleveGroupe(this.elevegroupe).subscribe(
      (success) => {
        this.toastrService.show('Groupe added successfully', 'Add', { status: 'success' });
        this.groupeid=null;
        this.groupesearch=null;
        this.GetByEleveId();
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
          console.log(error);
      } 
    )
  }
}

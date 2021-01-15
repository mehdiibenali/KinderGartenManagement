import { Component, OnInit, TemplateRef } from '@angular/core';
import { GroupeService } from 'src/app/_core/_services/groupe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { Groupe } from 'src/app/_core/_models/groupe';
import { EleveGroupe } from 'src/app/_core/_models/eleve-groupe';
import { SearchGroupe } from 'src/app/_core/_models/search-groupe';
import { Classe } from 'src/app/_core/_models/classe';
import { ParameterService } from 'src/app/_core/_services/parameter.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-groupes-list',
  templateUrl: './groupes-list.component.html',
  styleUrls: ['./groupes-list.component.css'],
  providers: [DatePipe],
})
export class GroupesListComponent implements OnInit {
  eleveid:number;
  eleveId:any;
  Groupes:Groupe[]=[];
  searchresult:Groupe[]=[];
  groupeid:number;
  search:SearchGroupe=new SearchGroupe()
  Years:Object[];
  dialog:any;
  SelectedYear:any=new Object();
  searcheleveenrollement:any=new Object();
  Classes:Classe[]=[];
  elevegroupe:EleveGroupe = new EleveGroupe();
  constructor(private datePipe:DatePipe,private router:Router,private dialogService: NbDialogService,private parameterService:ParameterService,private _Activatedroute:ActivatedRoute,private groupeService:GroupeService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.eleveId=this._Activatedroute.snapshot.paramMap.get("eleveid");
    this.eleveid=this.eleveId;
    this.GetByEleveId();
    this.groupeService.GetYears().subscribe(
      data=>{
        this.Years=data;
        this.parameterService.GetByCode('CurrentScolarYear').subscribe(
          data=>{this.SelectedYear.CurrentYear=data[0].value},
          err=>console.log(err)
        )
      },
      err=>console.log(err)
    )
    this.groupeService.GetAllClasses().subscribe(
      data=>{this.Classes=data},
      err=>console.log(err)
    )
  };
  GetByEleveId(){
    this.groupeService.GetGroupesByEleveId(this.eleveid).subscribe(data => {
      console.log(data);
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
        this.toastrService.show('Groupe Supprimé De L\'éleve', 'Suppression', { status: 'success' });
        this.GetByEleveId();
      },
      (error) => {
          this.toastrService.show('Une erreur est survenue', 'Suppression', { status: 'danger' });
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
    console.log(this.elevegroupe)
      this.groupeService.AddEleveGroupe(this.elevegroupe).subscribe(
      (success) => {
        this.toastrService.show('Groupe ajouté à l\'éleve', 'Ajout', { status: 'success' });
        this.groupeid=null;
        this.search=new SearchGroupe();
        this.searchresult=[];
        this.GetByEleveId();
      },
      (error) => {
          this.toastrService.show('Une erreur est survenue', 'Ajout', { status: 'danger' });
          console.log(error);
      } 
    )
    this.close()
  }
  open(dialog: TemplateRef<any>) {
    this.searcheleveenrollement.date = this.elevegroupe.datededebut;
    this.searcheleveenrollement.eleveid=this.eleveid
    this.groupeService.GetCurrentEleveGroupe(this.searcheleveenrollement).subscribe(
      data=>{if(data!=null){this.searcheleveenrollement.date=this.datePipe.transform(data,'yyyy-MM-dd')};console.log(data)},
      err=>{console.log(err)}
    )
    this.dialog=this.dialogService.open(dialog,
      {
      closeOnBackdropClick:true,
      })
    }
  close(){
      this.dialog.close();
    }
}

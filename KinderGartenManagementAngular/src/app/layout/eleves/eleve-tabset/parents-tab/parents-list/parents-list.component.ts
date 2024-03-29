import { Component, OnInit } from '@angular/core';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { NbToastrService } from '@nebular/theme';
import { ActivatedRoute, Router } from '@angular/router';
import { Parent } from 'src/app/_core/_models/parent';
import { EleveParent } from 'src/app/_core/_models/eleve-parent';
import { Convention } from 'src/app/_core/_models/convention';
import { ConventionService } from 'src/app/_core/_services/convention.service';

@Component({
  selector: 'app-parents-list',
  templateUrl: './parents-list.component.html',
  styleUrls: ['./parents-list.component.css']
})
export class ParentsListComponent implements OnInit {
  eleveid:any;
  ParentsAndConventions:{p:Parent[],nameOfConvention:string}[]=[];
  Parents:Parent[]=[];
  parentsearch:string;
  parents:any;
  searchresult:Parent[]=[];
  eleveparent:EleveParent=new EleveParent();
  parentid:number;
  conventionname:string;
  parenttuteur:number;
  split:string;
  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private parentService:ParentService, private toastrService: NbToastrService,private conventionService:ConventionService) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
    this.GetByEleveId();   
  }
  GetByEleveId(){
    this.parentService.GetParentByEleveId(this.eleveid).subscribe(data => {
      this.ParentsAndConventions=data;
      this.Parents=data.map(d=>d.p);
      this.split="col-"+(12/(this.Parents.length+1));
      this.parentService.GetEleveParentByParentTuteur(this.eleveid).subscribe(
        data=>{this.parenttuteur=data.parentId},
        err=>console.log(err)
      )
    },
    error => {  
      console.log(error);
    });
  };
  EditParent(ParentId){
    this.router.navigate(["eleves/fiche/"+this.eleveid+"/parents/"+ParentId])
  };
  AddParent(){
    this.router.navigate(["eleves/fiche/"+this.eleveid+"/parents/add"])
  };
  ParentExistant(){
    if (this.parentsearch!==''){
      this.parentService.SearchByName(this.parentsearch).subscribe(
        data=>{this.searchresult=data},
      )
    }

  }
  DeleteEleveParent(parentid:number){
    this.parentService.DeleteEleveParent(this.eleveid,parentid).subscribe(
      (success) => {
        this.toastrService.show('Parent Supprimé De L\'éleve', 'Suppression', { status: 'success' });
        this.GetByEleveId();
      },
      (error) => {
          this.toastrService.show('Une erreur est survenue', 'Suppression', { status: 'danger' });
          console.log(error);
      } 
    );
  }
  AddEleveParent(parentid,nom,prenom){
    this.parentsearch=nom+" "+prenom;
    this.parentid=parentid
  }
  SubmitEleveParent(){
    if (this.parentid==null){return}
    this.eleveparent.EleveId=this.eleveid;
    this.eleveparent.ParentId=this.parentid
    this.parentService.AddEleveParent(this.eleveparent).subscribe(
      (success) => {
        this.toastrService.show('Parent ajouté à l\'éleve', 'Ajout', { status: 'success' });
        this.parentid=null;
        this.parentsearch=null;
        this.GetByEleveId();
      },
      (error) => {
          this.toastrService.show('Une erreur est survenue', 'Ajout', { status: 'danger' });
          console.log(error);
      } 
    )
  }
  CheckParent(result){
    return this.Parents.filter(p=>p.id === result.id).length==0
  }
  ChangeParentTuteur(parentid: any) {
    this.parentService.UpdateEleveParent(this.eleveid,parentid).subscribe(
      data=>{
        this.parentService.GetEleveParentByParentTuteur(this.eleveid).subscribe(
        data=>{
          this.parenttuteur=data.parentId;
          this.toastrService.show('Parent Tuteur Changé', 'Mise à jour', { status: 'success' })
        },
        err=>console.log(err)
      )
        },
      err=>console.log(err)
    )

  }
  checkpt(parentid){return this.parenttuteur==parentid}
}

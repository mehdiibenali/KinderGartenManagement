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
  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private parentService:ParentService, private toastrService: NbToastrService,private conventionService:ConventionService) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
    this.GetByEleveId();   
  }
  GetByEleveId(){
    this.parentService.GetParentByEleveId(this.eleveid).subscribe(data => {
      this.ParentsAndConventions=data;
      this.Parents=data.map(d=>d.p);
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
        this.toastrService.show('Parent Supprimé De L\'éleve', 'Delete', { status: 'success' });
        this.GetByEleveId();
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
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
    this.eleveparent.ParentId=this.parentid;
    this.parentService.AddEleveParent(this.eleveparent).subscribe(
      (success) => {
        this.toastrService.show('Parent added successfully', 'Add', { status: 'success' });
        this.parentid=null;
        this.parentsearch=null;
        this.GetByEleveId();
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
          console.log(error);
      } 
    )
  }
  CheckParent(result){
    return this.Parents.filter(p=>p.id === result.id).length==0
  }
}

import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { NbToastrService } from '@nebular/theme';
import { ConventionService } from 'src/app/_core/_services/convention.service';
import { Convention } from 'src/app/_core/_models/convention';
import { Parent } from 'src/app/_core/_models/parent';
import { ParentConvention } from 'src/app/_core/_models/parent-convention';
import { formatDate } from '@angular/common';
import { AddParentConvention } from 'src/app/_core/_models/add-parent-convention';
import { ParameterService } from 'src/app/_core/_services/parameter.service';
import { SearchConvention } from 'src/app/_core/_models/search-convention';

@Component({
  selector: 'app-edit-parent',
  templateUrl: './edit-parent.component.html',
  styleUrls: ['./edit-parent.component.css']
})
export class EditParentComponent implements OnInit {
  @Output("OnCancelEditParent") cancel:EventEmitter<String>=new EventEmitter<String>();
  @Output("OnUpdateEleve") updateeleve:EventEmitter<String>=new EventEmitter<String>();
  parentid:any;
  ParentConvention:any=new Object();
  ParentConventionToAdd:AddParentConvention=new AddParentConvention();
  Conventions:Convention[]=[];
  Parent:any=new Object();
  Convention:any=new Object();
  CurrentYear:string;
  Years:Object[];
  GetActive:any=new Object();
  DisableConvention:boolean=false;
  search:SearchConvention=new SearchConvention();
  constructor(private _Activatedroute:ActivatedRoute,private parameterService:ParameterService,private parentService:ParentService, private toastrService: NbToastrService,private conventionService:ConventionService) { }

  ngOnInit(): void {
    this.conventionService.GetYears().subscribe(
      data=>{this.Years=data;
        this.parameterService.GetByCode('CurrentScolarYear').subscribe(
          data=>{this.CurrentYear=data[0].value;
          this.SearchConvention()},
          err=>console.log(err)
        );
      },
      err=>console.log(err)
    )
    this.Convention.name="Aucune Convention"
    this.parentid=this._Activatedroute.snapshot.paramMap.get("parentid");
    this.GetById();
  }
  GetById(){
    this.parentService.GetById(this.parentid).subscribe(
      data=>{
        this.Parent=data;
        if (data.parentConventions.length>0){this.ParentConvention=data.parentConventions[0];
        this.Convention=this.ParentConvention.convention;}
        },
      err=>{
        console.log(err);
      }
    )
  }
  CancelEditParent(){
    this.cancel.emit();
  }
  UpdateParent(){
    this.GetActive.parentid=this.parentid;
    this.conventionService.GetActive(this.GetActive).subscribe(
      data=>{
        console.log(data);
        if (data==null){
          // this.parentService.UpdateParent(this.Parent,this.parentid).subscribe(
          //   (success) => {
          //     this.toastrService.show('Parent mis à jour', 'Mise à jour', { status: 'success' });
          //     this.ParentConventionToAdd.parentid=this.Parent.id;
          //     if(this.Convention.id!=null){this.ParentConventionToAdd.newconventionid=this.Convention.id};
          //   },
          //   (error) => {
          //     this.toastrService.show('Une erreur est survenue', 'Mise à jour', { status: 'danger' });
          //   }
          // )
        }
        else{
          if( data.id == this.Convention.id){
            console.log('1')
            this.parentService.UpdateParent(this.Parent,this.parentid).subscribe(
              (success) => {
                this.toastrService.show('Parent mis à jour', 'Mise à jour', { status: 'success' });
                this.ParentConventionToAdd.parentid=this.Parent.id;
                if(this.Convention.id!=null){this.ParentConventionToAdd.newconventionid=this.Convention.id};
                if (data.id != this.Convention.id){
                console.log('doesnt make sense')
                this.parentService.AddParentConvention(this.ParentConventionToAdd).subscribe(
                  data=>{this.updateeleve.emit()},
                  err=>console.log(err));
                }
              },
              (error) => {
                this.toastrService.show('Une erreur est survenue', 'Mise à jour', { status: 'danger' });
              }
            )
          }
          else{
          if(confirm(this.Parent.prenom+" "+this.Parent.nomDeFamille+" a déja une convention à cette date \n Voulez vous y mettre fin ?")) {
            this.DisableConvention=true;
          }
          }
        }
      },
      err=>{
        console.log(err)
      }
    )
  }
  
  SearchConvention(){
    this.search.annees=this.CurrentYear.split('-');
    this.conventionService.Search(this.search).subscribe(
      data=>{this.Conventions=data},
      err=>{console.log(err)}
    );
  }
  conventionsnull(){this.Conventions=null;this.ParentConvention.conventionid=null}
}

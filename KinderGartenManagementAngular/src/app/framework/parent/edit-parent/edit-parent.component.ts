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

@Component({
  selector: 'app-edit-parent',
  templateUrl: './edit-parent.component.html',
  styleUrls: ['./edit-parent.component.css']
})
export class EditParentComponent implements OnInit {
  @Output("OnCancelEditParent") cancel:EventEmitter<String>=new EventEmitter<String>();
  @Output("OnUpdateEleve") updateeleve:EventEmitter<String>=new EventEmitter<String>();
  parentid:any;
  conventionyear:number;
  ParentConvention:any=new Object();
  ParentConventionToAdd:AddParentConvention=new AddParentConvention();
  Conventions:Convention[]=[];
  Parent:any=new Object();
  Convention:any=new Object();
  today:string=formatDate(new Date(), 'yyyy-MM-dd', 'en');
  time:string=formatDate(new Date(), 'hh:mm:ss', 'en');
  constructor(private _Activatedroute:ActivatedRoute,private parentService:ParentService, private toastrService: NbToastrService,private conventionService:ConventionService) { }

  ngOnInit(): void {
    this.today=this.today+'T'+this.time;
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
    this.parentService.UpdateParent(this.Parent,this.parentid).subscribe(
      (success) => {
        this.toastrService.show('Parent Updated successfully', 'Update', { status: 'success' });
        this.ParentConventionToAdd.parentid=this.Parent.id;
        if(this.Convention.id!=null){this.ParentConventionToAdd.newconventionid=this.Convention.id};
        this.parentService.AddParentConvention(this.ParentConventionToAdd).subscribe(
          data=>{this.updateeleve.emit()},
          err=>console.log(err));

      },
      (error) => {
        this.toastrService.show('Server error', 'Update', { status: 'danger' });
      }
    )
  }
  SearchConventionByYear(){
    this.conventionService.SearchByYear(this.conventionyear).subscribe(
      data=>{this.Conventions=data},
      err=>{console.log(err)}
    
    );
  }
  conventionsnull(){this.Conventions=null;this.ParentConvention.conventionid=null}
}

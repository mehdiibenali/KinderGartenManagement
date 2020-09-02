import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Parent } from 'src/app/_core/_models/parent';
import { Router, ActivatedRoute, NavigationEnd, ActivationEnd, RoutesRecognized } from '@angular/router';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { NbToastrService } from '@nebular/theme';
import { filter } from 'rxjs/operators';
import { ConventionService } from 'src/app/_core/_services/convention.service';
import { Convention } from 'src/app/_core/_models/convention';
import { ParentConvention } from 'src/app/_core/_models/parent-convention';
import { formatDate } from '@angular/common';
import { AddParentConvention } from 'src/app/_core/_models/add-parent-convention';

@Component({
  selector: 'app-add-parent',
  templateUrl: './add-parent.component.html',
  styleUrls: ['./add-parent.component.css']
})
export class AddParentComponent implements OnInit {
  @Output("OnRegisterParent") parentid:EventEmitter<String>=new EventEmitter<String>();
  @Output("OnCancelAddParent") cancel:EventEmitter<String>=new EventEmitter<String>();
  previousUrl:any;
  test:any;
  parent:any = new Object();
  parentconvention:AddParentConvention=new AddParentConvention();
  conventionyear:number;
  conventionid:number;
  Conventions:Convention[]=[];
  today:string=formatDate(new Date(), 'yyyy/MM/dd', 'en');
  constructor(private router:Router,private parentService:ParentService, private toastrService: NbToastrService,private conventionService:ConventionService) {   }
  ngOnInit(): void {
  }
  RegisterParent(){
    this.parentService.AddParent(this.parent).subscribe(
      (data) => {
        if (this.conventionid !=null){
          this.parentconvention.newconventionid=this.conventionid;
          this.parentconvention.parentid=data.id;
          this.parentService.AddParentConvention(this.parentconvention).subscribe(
            (success) => { this.parentid.emit(data.id); },
            (error) => {
                this.toastrService.show('Server error', 'Add', { status: 'danger' });
                console.log(error);
            }   
          )
        }
        else{
          this.parentid.emit(data.id);
        }
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
          console.log(error);
      }   
    )
  };
  CancelAddParent(){
    this.cancel.emit();
  }
  SearchConventionByYear(){
    this.conventionService.SearchByYear(this.conventionyear).subscribe(
      data=>{this.Conventions=data;
      console.log(this.Conventions)},
      err=>{console.log(err)}
    );
  }
  conventionsnull(){this.Conventions=null;this.conventionid=null}
}

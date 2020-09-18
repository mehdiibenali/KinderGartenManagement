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
import { SearchConvention } from 'src/app/_core/_models/search-convention';
import { ParameterService } from 'src/app/_core/_services/parameter.service';

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
  search:SearchConvention=new SearchConvention();
  conventionid:number;
  Conventions:Convention[]=[];
  Years:Object[];
  CurrentYear:string;
  today:string=formatDate(new Date(), 'yyyy/MM/dd', 'en');
  constructor(private router:Router,private parentService:ParentService, private parameterService:ParameterService, private toastrService: NbToastrService,private conventionService:ConventionService) {   }
  ngOnInit(): void {
    this.conventionService.GetYears().subscribe(
      data=>{this.Years=data;
        this.parameterService.GetByCode('CurrentScholarYear').subscribe(
          data=>{this.CurrentYear=data.value;
          this.SearchConvention()
          },
          err=>console.log(err))
      err=>console.log(err)
  })}
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
  GetYears
  CancelAddParent(){
    this.cancel.emit();
  }
  SearchConvention(){
    this.search.annees=this.CurrentYear.split('-');
    this.conventionService.Search(this.search).subscribe(
      data=>{this.Conventions=data;},
      err=>{console.log(err)}
    );
  }
  conventionsnull(){this.Conventions=null;this.conventionid=null}
}

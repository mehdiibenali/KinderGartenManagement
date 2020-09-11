import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { NbToastrService } from '@nebular/theme';
import { ConventionService } from 'src/app/_core/_services/convention.service';
import { Parent } from 'src/app/_core/_models/parent';
import { ParentConvention } from 'src/app/_core/_models/parent-convention';
import { AddParentConvention } from 'src/app/_core/_models/add-parent-convention';

@Component({
  selector: 'app-parents-list',
  templateUrl: './parents-list.component.html',
  styleUrls: ['./parents-list.component.css']
})
export class ParentsListComponent implements OnInit {
  conventionid:any;
  Parents:Parent[]= [];
  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private parentService:ParentService, private toastrService: NbToastrService,private conventionService:ConventionService) { }

  ngOnInit(): void {
    this.conventionid=this._Activatedroute.snapshot.paramMap.get("conventionid");
    this.GetByConventionId(); 
  }
  GetByConventionId(){
    this.parentService.GetParentsByConventionId(this.conventionid).subscribe(data => {
      this.Parents=data;
    },
    error => {  
      console.log(error);
    });
  };
  EditParent(id){}
  AddParent(){}
}

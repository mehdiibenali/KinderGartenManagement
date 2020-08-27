import { Component, OnInit } from '@angular/core';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { NbToastrService } from '@nebular/theme';
import { ActivatedRoute, Router } from '@angular/router';
import { Parent } from 'src/app/_core/_models/parent';

@Component({
  selector: 'app-parents-list',
  templateUrl: './parents-list.component.html',
  styleUrls: ['./parents-list.component.css']
})
export class ParentsListComponent implements OnInit {
  eleveid:any;
  Parents:Parent[] = [];
  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private parentService:ParentService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
    this.GetByEleveId();
  }
  GetByEleveId(){
    this.parentService.GetParentByEleveId(this.eleveid).subscribe(data => {
      this.Parents = data;
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
  ParentExistant(){}
}

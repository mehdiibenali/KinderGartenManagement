import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { NbToastrService } from '@nebular/theme';
import { Parent } from 'src/app/_core/_models/parent';

@Component({
  selector: 'app-edit-parent',
  templateUrl: './edit-parent.component.html',
  styleUrls: ['./edit-parent.component.css']
})
export class EditParentComponent implements OnInit {
  CheckForUpdate:string="Cancel";
  parentid:any;
  eleveid:any;
  Parent:any = new Object();
  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private parentService:ParentService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
    this.parentid=this._Activatedroute.snapshot.paramMap.get("parentid");
    this.GetById();
  }
  GetById(){
    this.parentService.GetById(this.parentid).subscribe(
      data=>{
        this.Parent=data;
        },
      err=>{
        console.log(err);
      }
    )
  }
  CancelEditParent(){
    this.router.navigate(['eleves/fiche/'+this.eleveid+'/parents/list'])
  }
  UpdateParent(){
    this.parentService.UpdateParent(this.Parent,this.parentid).subscribe(
      (success) => {
        this.toastrService.show('Parent Updated successfully', 'Update', { status: 'success' });
        this.CheckForUpdate = "Go Back"
      },
      (error) => {
        this.toastrService.show('Server error', 'Update', { status: 'danger' });
      }
    )
  }

}

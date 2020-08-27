import { Component, OnInit } from '@angular/core';
import { Parent } from 'src/app/_core/_models/parent';
import { EleveParent } from 'src/app/_core/_models/eleve-parent';
import { Router, ActivatedRoute } from '@angular/router';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'app-add-parent',
  templateUrl: './add-parent.component.html',
  styleUrls: ['./add-parent.component.css']
})
export class AddParentComponent implements OnInit {
  eleveid:any;
  eleveparent : EleveParent = new EleveParent();
  parent:Parent = new Parent();
  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private parentService:ParentService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
  }
  RegisterParent(){
    this.parentService.AddParent(this.parent).subscribe(
      (data) => {
        this.eleveparent.EleveId = this.eleveid;
        this.eleveparent.ParentId = data.id;
        this.parentService.AddEleveParent(this.eleveparent).subscribe(
          (success) => {
            this.toastrService.show('Parent added successfully', 'Add', { status: 'success' });
            this.router.navigate(["eleves/fiche/"+this.eleveid+"/parents/list"]);
          },
          (error) => {
              this.toastrService.show('Server error', 'Add', { status: 'danger' });
              console.log(error);
          } 
        )
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
          console.log(error);
      }   
    ) 
  };
  CancelAddParent(){
    this.router.navigate(["eleves/fiche/"+this.eleveid+"/parents/list"])
  }
}

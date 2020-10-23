import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { NbToastrService } from '@nebular/theme';
import { EleveParent } from 'src/app/_core/_models/eleve-parent';

@Component({
  selector: 'app-add-parent-te',
  templateUrl: './add-parent-te.component.html',
  styleUrls: ['./add-parent-te.component.css']
})
export class AddParentTeComponent implements OnInit {
  eleveid:any;
  eleveparent : EleveParent = new EleveParent();
  constructor(private _Activatedroute:ActivatedRoute,private router:Router,private parentService:ParentService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
  }
  AddEleveParent(parentid){
    this.eleveparent.EleveId = this.eleveid;
    this.eleveparent.ParentId = parentid;
    this.parentService.AddEleveParent(this.eleveparent).subscribe(
      (success) => {
        this.toastrService.show('Parent ajouté', 'Ajout', { status: 'success' });
        this.router.navigate(["eleves/fiche/"+this.eleveid+"/parents/list"]);
      },
      (error) => {
          this.toastrService.show('Une erreur est survenue', 'Ajout', { status: 'danger' });
          console.log(error);
      } 
    )
  }
  CancelAddParent(){
    this.router.navigate(["eleves/fiche/"+this.eleveid+"/parents/list"])
  }
}

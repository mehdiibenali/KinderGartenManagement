import { Component, OnInit } from '@angular/core';
import { GroupeService } from 'src/app/_core/_services/groupe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { Groupe } from 'src/app/_core/_models/groupe';

@Component({
  selector: 'app-groupes-list',
  templateUrl: './groupes-list.component.html',
  styleUrls: ['./groupes-list.component.css']
})
export class GroupesListComponent implements OnInit {
  eleveid:any;
  Groupes:Groupe[]=[];
  constructor(private router:Router,private _Activatedroute:ActivatedRoute,private groupeService:GroupeService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
    this.GetByEleveId();
  };
  GetByEleveId(){
    this.groupeService.GetGroupesByEleveId(this.eleveid).subscribe(data => {
      this.Groupes = data;
      console.log(this.Groupes);
    },
    error => {  
      console.log(error);
    });
  };
  AddGroupe(){
    this.router.navigate(["eleves/fiche/"+this.eleveid+"/groupes/add"])
  }

}

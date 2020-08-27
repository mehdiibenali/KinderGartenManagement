import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EleveService } from 'src/app/_core/_services/eleve.service';
import { NbToastrService } from '@nebular/theme';
import { Eleve } from 'src/app/_core/_models/eleve';

@Component({
  selector: 'app-edit-eleve',
  templateUrl: './edit-eleve.component.html',
  styleUrls: ['./edit-eleve.component.css']
})
export class EditEleveComponent implements OnInit {
  eleve:Eleve=new Eleve();
  eleveid:any;
  edit:boolean;
  submitted = false;
  CheckForUpdate : string = "Cancel";
  constructor(private _Activatedroute:ActivatedRoute,private eleveService:EleveService, private toastrService: NbToastrService) {
   }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
    this.GetById();
  }
  GetById(){
    this.eleveService.GetById(this.eleveid)
    .subscribe(data => {
      this.eleve.prenom= data.prenom;
      this.eleve.nom = data.nom;
      this.eleve.datedenaissance = data.dateDeNaissance;
      this.eleve.lieudenaissance = data.lieuDeNaissance;
      this.eleve.adresse = data.adresse;
      this.eleve.sexe = data.sexe;
    },
    error => {
      console.log(error);
    });
  }
  EditEleve(){
    this.edit=true;
  }
  CancelEditEleve(){
    this.edit=false;
    this.GetById()
    this.CheckForUpdate = "Cancel"
  }
  UpdateEleve(){
    this.eleveService.UpdateEleve(this.eleve,this.eleveid).subscribe(
      (success) => {
        this.toastrService.show('User Updated successfully', 'Update', { status: 'success' });
        this.CheckForUpdate = "Go Back"
      },
      (error) => {
        this.toastrService.show('Server error', 'Update', { status: 'danger' });
      }
    )
  }
}

import { Component, OnInit, Output, Input } from '@angular/core';
import { Eleve } from 'src/app/_core/_models/eleve';
import { ActivatedRoute } from '@angular/router';
import { EleveService } from 'src/app/_core/_services/eleve.service';
import { NbToastrService } from '@nebular/theme';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-edit-eleve',
  templateUrl: './edit-eleve.component.html',
  styleUrls: ['./edit-eleve.component.css']
})
export class EditEleveComponent implements OnInit {
  @Output("CancelEdit") CancelEdit:EventEmitter<String>=new EventEmitter<String>();
  @Input() FormEnabled:boolean;
  eleve:Eleve=new Eleve();
  eleveid:any;
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
    this.FormEnabled=true;
  }
  CancelEditEleve(){
    this.GetById();
    this.CancelEdit.emit("Update completed");
    this.FormEnabled=false;
  }
  UpdateEleve(){
    this.eleveService.UpdateEleve(this.eleve,this.eleveid).subscribe(
      (success) => {
        this.toastrService.show('User Updated successfully', 'Update', { status: 'success' })
        this.CancelEdit.emit("Update completed");
      },
      (error) => {
        this.toastrService.show('Server error', 'Update', { status: 'danger' });
      }
    )
  }
}

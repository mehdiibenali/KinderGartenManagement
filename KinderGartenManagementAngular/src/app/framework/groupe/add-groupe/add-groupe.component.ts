import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import { Classe } from 'src/app/_core/_models/classe';
import { Groupe } from 'src/app/_core/_models/groupe';
import { GroupeService } from 'src/app/_core/_services/groupe.service';

@Component({
  selector: 'app-add-groupe',
  templateUrl: './add-groupe.component.html',
  styleUrls: ['./add-groupe.component.css']
})
export class AddGroupeComponent implements OnInit {
  @Output("OnCancelAdd") CancelAdd:EventEmitter<String>=new EventEmitter<String>();
  @Output("OnAdd") Add:EventEmitter<String>=new EventEmitter<String>();
  Groupe:Groupe= new Groupe();
  Classes:Classe[]=[];
  constructor(private groupeService:GroupeService,private toastrService:NbToastrService) { }

  ngOnInit(): void {
    this.groupeService.GetAllClasses().subscribe(
      data=>{this.Classes=data},
      err=>{console.log(err)}
    )
  }
  AddGroupe(){
    console.log(this.Groupe);
    this.groupeService.AddGroupe(this.Groupe).subscribe(
      data=>{
        this.toastrService.show('Groupe Ajouté', 'Ajout', { status: 'success' });
        this.Add.emit(data.id);
      },
      err=>{
        this.toastrService.show('Une erreur est survenue', 'Ajout', { status: 'danger' });
        console.log(err);
      }
    )
  }
  CancelAddGroupe(){
    this.CancelAdd.emit();
  }
}

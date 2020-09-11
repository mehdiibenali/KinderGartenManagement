import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Eleve } from 'src/app/_core/_models/eleve';
import { Router } from '@angular/router';
import { EleveService } from 'src/app/_core/_services/eleve.service';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'app-add-eleve',
  templateUrl: './add-eleve.component.html',
  styleUrls: ['./add-eleve.component.css']
})
export class AddEleveComponent implements OnInit {
  @Output("OnCancelAdd") CancelAdd:EventEmitter<String>=new EventEmitter<String>();
  @Output("OnRegister") Register:EventEmitter<String>=new EventEmitter<String>();
  eleve : Eleve = new Eleve();
  submitted = false;
  showelevefiche:string="nav-link disabled";
  showparentfiche:string="nav-link";
  showgroupefiche:string = "nav-link";
  elevefiche:boolean = true;
  parentfiche:boolean = false;
  groupefiche:boolean = false;
  constructor(private eleveService: EleveService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
  }
  RegisterEleve(){
    this.eleveService.AddEleve(this.eleve).subscribe(
      (success) => {
        this.toastrService.show('Eleve added successfully', 'Add', { status: 'success' });
        this.Register.emit(success.id)
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
          console.log(error);
      }   
    ) 
    this.submitted = true;
    
  }
  CancelAddEleve(){
    this.CancelAdd.emit("canceled")
  }
}

import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
import { Modalite } from 'src/app/_core/_models/modalite';
import { trigger, state, style, transition, animate } from '@angular/animations'
import { PayementEnrollement } from 'src/app/_core/_models/payement-enrollement';
import { ParameterService } from 'src/app/_core/_services/parameter.service';
import { Payement } from 'src/app/_core/_models/payement';
import { DatePipe } from '@angular/common';
import { PayementService } from 'src/app/_core/_services/payement.service';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { AddParentComponent } from '../../parent/add-parent/add-parent.component';
import { PayementRecapComponent } from '../payement-recap/payement-recap.component';
import { SummerClubService } from 'src/app/_core/_services/summer-club.service';
import { Groupe } from 'src/app/_core/_models/groupe';
import { Club } from 'src/app/_core/_models/club';
  
  
@Component({
  selector: 'app-add-payement',
  templateUrl: './add-payement.component.html',
  styleUrls: ['./add-payement.component.css'],
  providers:[DatePipe],
  animations: [
    trigger('collapse', [
      state('small', style({ height: '0px' })),
      state('large', style({ height: "*" }),),
      transition('small <=> large', animate('600ms ease-out'))
    ])
  ]
})
export class AddPayementComponent implements OnInit {
  @Output("OnRegisterPayement") payementid:EventEmitter<String>=new EventEmitter<String>();
  @Output("OnCancelAddPayement") cancel:EventEmitter<String>=new EventEmitter<String>()
  @Input() eleveids:any;
  state: string[] = ['small', 'small'];
  chevrondirection: string[] = ["col-2 fa fa-chevron-down", "col-2 fa fa-chevron-down"];
  sections: string[] = [];
  payement:Payement=new Payement();
  scholaryears: string[] = [];
  scholaryearbeginning:string;  
  scholaryearend:string;
  clubs:Club[] = [];
  dialog:any;
  constructor(private summerClubService: SummerClubService,private dialogService: NbDialogService,private toastrService: NbToastrService,private datePipe:DatePipe,private parameterService: ParameterService,private payementService:PayementService) { }

  ngOnInit(): void {
  }
  AddPayement() {
    this.payementService.AddPayement(this.payement).subscribe(
      data=>{
        console.log(data)
        this.payementid.emit(data.id);
      },
      err=>{
        console.log(err);
        this.toastrService.show('Une erreur est survenue',"Ajout",{status:"danger"})
      }
    )
    this.close();
   }
   CancelAddPayement(){this.cancel.emit();}
  AddMethodForm() {this.payement.modalitemodels.push(new Modalite())}
  CollapseMethode() {
    this.state[0] = (this.state[0] === 'small' ? 'large' : 'small');
    this.state[1] = "small";
    this.chevrondirection[1] = "col-2 fa fa-chevron-down";
    if (this.state[0] == "small") { this.chevrondirection[0] = "col-2 fa fa-chevron-down" }
    else { this.chevrondirection[0] = "col-2 fa fa-chevron-up" }
  }
  DeleteMethod(i) {
    this.payement.modalitemodels.splice(i, 1);
  }
  CollapseRubrique() {
    this.state[1] = (this.state[1] === 'small' ? 'large' : 'small');
    this.state[0] = "small";
    this.chevrondirection[0] = "col-2 fa fa-chevron-down";
    if (this.state[1] == "small") { this.chevrondirection[1] = "col-2 fa fa-chevron-down" }
    else { this.chevrondirection[1] = "col-2 fa fa-chevron-up" }
  }

  open(dialog: TemplateRef<any>) {
    this.dialog=this.dialogService.open(dialog,
      {
      closeOnBackdropClick:false,
      context:this.payement
      })
    }
    close(){
      this.dialog.close();
    }
}

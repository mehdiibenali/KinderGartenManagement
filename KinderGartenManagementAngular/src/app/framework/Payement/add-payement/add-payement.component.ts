import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
import { Modalite } from 'src/app/_core/_models/modalite';
import { trigger, state, style, transition, animate } from '@angular/animations'
import { PayementEnrollement } from 'src/app/_core/_models/payement-enrollement';
import { ParameterService } from 'src/app/_core/_services/parameter.service';
import { Payement } from 'src/app/_core/_models/payement';
import { DatePipe } from '@angular/common';
import { PayementDates } from 'src/app/_core/_models/payement-dates';
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
  @Input() eleveid:number;;
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
    this.summerClubService.ByEleveId(this.eleveid).subscribe(
      data => { this.clubs = data },
      err => { console.log(err)}
    )
    // this.payement.eleveid=this.eleveid
    this.parameterService.GetByCode("Section").subscribe(
      data => { this.sections = data },
      err => { console.log(err) }
    );
    this.parameterService.GetByCode("CurrentScholarYear").subscribe(
      data => { this.scholaryears = data[0].value.split('-'); },
      err => console.log(err)
    );
    this.parameterService.GetByCode("ScholarYearBeginning").subscribe(
      data=>{ this.scholaryearbeginning=data[0].value},
      err=>{console.log(err)}
    );
    this.parameterService.GetByCode("ScholarYearEnd").subscribe(
      data=>{ this.scholaryearend=data[0].value},
      err=>{console.log(err)}
    );
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
  AddPayementEnrollementForm() { 
    this.payement.payementenrollementmodels.push(new PayementEnrollement());
   }
   AddPayementDatesForm(i){
     this.payement.payementenrollementmodels[i].payementdatesmodels.push(new PayementDates());
     this.parameterService.GetDates(this.payement.payementenrollementmodels[i].payementdatesmodels[this.payement.payementenrollementmodels[i].payementdatesmodels.length-1].year).subscribe(
      data => {
        this.payement.payementenrollementmodels[i].payementdatesmodels[this.payement.payementenrollementmodels[i].payementdatesmodels.length-1].ListOfMonths = data;
        this.ChangeDates(i,this.payement.payementenrollementmodels[i].payementdatesmodels.length-1);
      },
      err => { console.log(err) }
    );
   }
   DeletePayementDates(i,j){
     this.payement.payementenrollementmodels[i].payementdatesmodels.splice(j,1);
   }
  DeletePayementEnrollement(i) {
    this.payement.payementenrollementmodels.splice(i, 1);
  }
  GetExpected(i) {
    var payementenrollement = this.payement.payementenrollementmodels[i].section;
    this.payement.payementenrollementmodels[i] = new PayementEnrollement();
    this.payement.payementenrollementmodels[i].section = payementenrollement;
    if (this.payement.payementenrollementmodels[i].section === "Frais d'inscription") {
      this.payement.payementenrollementmodels[i].paid = 360;
      this.payement.payementenrollementmodels[i].payementdatesmodels.push(new PayementDates());
      this.payement.payementenrollementmodels[i].payementdatesmodels[0].datededebut=this.scholaryearbeginning+' '+this.scholaryears[0];
      this.payement.payementenrollementmodels[i].payementdatesmodels[0].datedefin=this.scholaryearend+' '+this.scholaryears[1];
    }
    else {
      this.AddPayementDatesForm(i)
    }
  }
  ChangeMonths(i,j) {
    this.parameterService.GetDates(this.payement.payementenrollementmodels[i].payementdatesmodels[j].year).subscribe(
      data => {
        this.payement.payementenrollementmodels[i].payementdatesmodels[j].ListOfMonths = data;
        this.payement.payementenrollementmodels[i].payementdatesmodels[j].month=data[0].month;
        this.ChangeDates(i,j);
      },
      err => { console.log(err) }
    )

  }
  ChangeDates(i,j) {
    this.payement.payementenrollementmodels[i].payementdatesmodels[j].datedefin=this.datePipe.transform(this.payement.payementenrollementmodels[i].payementdatesmodels[j].ListOfMonths.find(e => e.month == this.payement.payementenrollementmodels[i].payementdatesmodels[j].month).end,"yyyy-MM-dd")
    this.payement.payementenrollementmodels[i].payementdatesmodels[j].datededebut=this.datePipe.transform(this.payement.payementenrollementmodels[i].payementdatesmodels[j].ListOfMonths.find(e => e.month == this.payement.payementenrollementmodels[i].payementdatesmodels[j].month).start,"yyyy-MM-dd")
  }
  open(dialog: TemplateRef<any>) {
    this.dialog=this.dialogService.open(dialog,
      {
      closeOnBackdropClick:false,
      context:this.payement
      // .onClose.subscribe(data=>console.log(data));
      })
    }
    close(){
      this.dialog.close();
    }
}

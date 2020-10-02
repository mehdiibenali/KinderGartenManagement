import { Component, OnInit } from '@angular/core';
import { Modalite } from 'src/app/_core/_models/modalite';
import {trigger,state,style,transition,animate,keyframes} from '@angular/animations'
import { PayementEnrollement } from 'src/app/_core/_models/payement-enrollement';
import { ParameterService } from 'src/app/_core/_services/parameter.service';
import { formatDate } from '@angular/common';
@Component({
  selector: 'app-add-payement',
  templateUrl: './add-payement.component.html',
  styleUrls: ['./add-payement.component.css'],
  animations:[
    trigger('collapse',[
      state('small',style({height:'0px'})),
      state('large',style({height:"*"}), ),
      transition('small <=> large',animate('600ms ease-out'))
    ])
  ]
})
export class AddPayementComponent implements OnInit {
  modalites:Modalite[]=[new Modalite()];
  state:string[]=['small','small'];
  payementenrollements:PayementEnrollement[]=[new PayementEnrollement()];
  chevrondirection:string[]=["col-2 fa fa-chevron-down","col-2 fa fa-chevron-down"];
  sections:string[]=[];
  annees:string[]=[];
  annee:number=new Date().getFullYear();
  constructor(private parameterService:ParameterService) { }

  ngOnInit(): void {
    this.parameterService.GetByCode("Section").subscribe(
      data=>{this.sections=data},
      err=>{console.log(err)}
    )
    this.parameterService.GetByCode('CurrentScholarYear').subscribe(
      data=>{this.annees=data[0].value.split('-');},
      err=>console.log(err)
    );
  }
  AddPayement(){}
  AddMethodForm(){this.modalites.push(new Modalite())}
  CollapseMethode(){
    this.state[0]=(this.state[0] === 'small' ? 'large':'small');
    this.state[1]="small";
    this.chevrondirection[1]="col-2 fa fa-chevron-down";
    if (this.state[0]=="small"){this.chevrondirection[0]="col-2 fa fa-chevron-down"}
    else{this.chevrondirection[0]="col-2 fa fa-chevron-up"}
  }
  DeleteMethod(i){
    this.modalites.splice(i,1);
  }
  CollapseRubrique(){
    this.state[1]=(this.state[1] === 'small' ? 'large':'small');
    this.state[0]="small";
    this.chevrondirection[0]="col-2 fa fa-chevron-down";
    if (this.state[1]=="small"){this.chevrondirection[1]="col-2 fa fa-chevron-down"}
    else{this.chevrondirection[1]="col-2 fa fa-chevron-up"}
  }
  AddPayementEnrollementForm(){this.payementenrollements.push(new PayementEnrollement())}
  DeletePayementEnrollement(i){
    this.payementenrollements.splice(i,1);
  }
  GetExpected(i){
    if (this.payementenrollements[i].section=="Frais d'inscription"){
      this.payementenrollements[i].paid=360;
    }
    else{
      this.payementenrollements[i].paid=null;
    }
  }
  ChangeMonth(){

  }
}

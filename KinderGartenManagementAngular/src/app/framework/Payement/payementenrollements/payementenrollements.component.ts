import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { PayementService } from 'src/app/_core/_services/payement.service';

@Component({
  selector: 'app-payementenrollements',
  templateUrl: './payementenrollements.component.html',
  styleUrls: ['./payementenrollements.component.css']
})
export class PayementenrollementsComponent implements OnInit {
  @Input() eleveids:string;
  @Input() getpayementenrollements:boolean;
  @Output("SendPayementEnrollements") SendPayementEnrollements:EventEmitter<any>=new EventEmitter<any>();
  // a="2020-11-19"; 
  unpaid:[string,any[]][];
  constructor(
    private datePipe:DatePipe,
    private payementService:PayementService,
  ) { }
  ngOnInit(): void {
    this.payementService.GetUnpaid(this.eleveids).subscribe(
      data => {console.log(data);this.unpaid=data },
      err => {console.log(err)} 
    );
  }
  ngOnChanges(changes:SimpleChanges):void{
    if (this.getpayementenrollements){
      this.SendPayementEnrollements.emit(this.unpaid)
    }
  }
  CheckDisabled(i){
    return i.filter(i=>i[0].section == 'Scolarité' || i[0].section=="Club d'hiver").length>0
  }
}

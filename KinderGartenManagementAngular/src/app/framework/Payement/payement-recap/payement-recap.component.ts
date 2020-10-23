import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { Payement } from 'src/app/_core/_models/payement';

@Component({
  selector: 'app-payement-recap',
  templateUrl: './payement-recap.component.html',
  styleUrls: ['./payement-recap.component.css']
})
export class PayementRecapComponent implements OnInit {
  @Output('close') close :EventEmitter<String>=new EventEmitter<String>();
  @Input() payement=new Payement();
  constructor(private dialogService: NbDialogService) { }
  ngOnInit(){
    console.log(this.payement);
  }
  CloseDialog(){
    this.close.emit();
  }
}

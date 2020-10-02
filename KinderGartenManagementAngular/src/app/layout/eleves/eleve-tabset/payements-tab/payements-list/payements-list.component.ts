import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-payements-list',
  templateUrl: './payements-list.component.html',
  styleUrls: ['./payements-list.component.css']
})
export class PayementsListComponent implements OnInit {
  eleveid:any;
  constructor(private router:Router,private _Activatedroute:ActivatedRoute) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
  }
  AddPayement(){
    this.router.navigate(["eleves/fiche/"+this.eleveid+"/paiements/add"])
  }
}

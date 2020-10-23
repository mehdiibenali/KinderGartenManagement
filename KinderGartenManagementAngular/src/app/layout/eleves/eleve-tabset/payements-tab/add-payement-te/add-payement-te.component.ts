import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'app-add-payement-te',
  templateUrl: './add-payement-te.component.html',
  styleUrls: ['./add-payement-te.component.css']
})
export class AddPayementTeComponent implements OnInit {
  eleveid:any;
  constructor(private _Activatedroute:ActivatedRoute,private router:Router,private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
  }
  CancelAddPayement(){
    this.router.navigate(["eleves/fiche/"+this.eleveid+"/paiements/list"])
  }
  PayementRegistered(){
    this.toastrService.show('Payement Ajouté','Ajout',{status:"success"});
    this.router.navigate(["eleves/fiche/"+this.eleveid+"/paiements/list"])
  }
}

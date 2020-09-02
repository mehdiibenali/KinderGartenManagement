import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-parent-te',
  templateUrl: './edit-parent-te.component.html',
  styleUrls: ['./edit-parent-te.component.css']
})
export class EditParentTeComponent implements OnInit {
  eleveid:any;
  constructor(private _Activatedroute:ActivatedRoute,private router:Router,) { }

  ngOnInit(): void {
    this.eleveid=this._Activatedroute.snapshot.paramMap.get("eleveid");
  }
  CancelEditParent(){
    this.router.navigate(['eleves/fiche/'+this.eleveid+'/parents/list'])
  }
  UpdateFinished(){
    this.router.navigate(['eleves/fiche/'+this.eleveid+'/parents/list'])
  }
}

import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-eleve-tabset',
  templateUrl: './eleve-tabset.component.html',
})
export class EleveTabsetComponent implements OnInit {
  eleveid:any;
  test:boolean=false;
  url:any;
  disabled:boolean=true;
  constructor(private router: Router,private _Activatedroute:ActivatedRoute) {
    this.CheckUrl();
   }

  ngOnInit(): void {
    this.CheckUrl();
  };
  changeTab(tab:string){
    if (this.url[4]=="add"){
      return;
     };
    tab=tab.toLowerCase();
    if (tab=="eleve"){
      this.router.navigate(['/eleves/fiche/eleve/'+this.eleveid]);
      return;
    }
    this.router.navigate(['/eleves/fiche/'+this.eleveid+'/'+tab+'/list']);
  }
  CheckUrl(){
    this._Activatedroute.url.subscribe(activeUrl=>{
      this.url=window.location.pathname.split("/");
    });
    if (this.url[4] != "add"){
      this.disabled=false;
      this._Activatedroute.firstChild.firstChild.paramMap.subscribe(
        (params) => 
        { 
          this.eleveid = params.get("eleveid");
         });
    };
  }
}

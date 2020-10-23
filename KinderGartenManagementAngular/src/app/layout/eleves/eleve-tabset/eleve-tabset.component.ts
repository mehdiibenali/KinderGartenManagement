import { ifStmt } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-eleve-tabset',
  templateUrl: './eleve-tabset.component.html',
})
export class EleveTabsetComponent implements OnInit {
  changetab=false;
  eleveid:any;
  url:any;
  disabled:boolean=true;
  activetab="eleve";
  constructor(private router: Router,private _Activatedroute:ActivatedRoute) {
    router.events.subscribe((val) => {
      this.CheckUrl();
  });
   }

  ngOnInit(): void {
    this.CheckUrl();
  };
  changeTab(tab:string){
    if(this.changetab==true){
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
    else{
      this.activetab=this.url[4];
      if(Number(this.activetab)){this.activetab="eleve"};
      this.changetab=true;
    }
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

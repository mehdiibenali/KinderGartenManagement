import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-parent-tabset',
  templateUrl: './parent-tabset.component.html',
  styleUrls: []
})
export class ParentTabsetComponent implements OnInit {
  parentid:any;
  url:any;
  disabled:boolean=true;
  constructor(private router: Router,private _Activatedroute:ActivatedRoute) {
    router.events.subscribe((val) => {
      this.CheckUrl();
  })
  };

  ngOnInit(): void {
  };
  changeTab(tab:string){
    if (this.url[4]=="add"){
      return;
     };
    tab=tab.toLowerCase();
    if (tab=="parent"){
      this.router.navigate(['/parents/fiche/parent/'+this.parentid]);
      return;
    }
    this.router.navigate(['/parents/fiche/'+this.parentid+'/'+tab+'/list']);
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
          this.parentid = params.get("parentid");
         });
    };
  }
}

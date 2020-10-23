import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-parent-tabset',
  templateUrl: './parent-tabset.component.html',
  styleUrls: []
})
export class ParentTabsetComponent implements OnInit {
  changetab=false;
  parentid:any;
  url:any;
  activetab:any;
  disabled:boolean=true;
  constructor(private router: Router,private _Activatedroute:ActivatedRoute) {
    router.events.subscribe((val) => {
      this.CheckUrl();
  })
  };

  ngOnInit(): void {
  };
  changeTab(tab:string){
    if (this.changetab){
      if (this.url[4]=="add"){
        return;
      };
      tab=tab.toLowerCase();
      if (tab=="parent"){
        this.router.navigate(['/parents/fiche/parent/'+this.parentid]);
        return;
      }
      this.router.navigate(['/parents/fiche/'+this.parentid+'/'+tab+'/list'])
    }
    else{
      this.activetab=this.url[4];
      if(Number(this.activetab)){this.activetab="parent"};
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
          this.parentid = params.get("parentid");
         });
    };
  }
}

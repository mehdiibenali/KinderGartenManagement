import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-convention-tabset',
  templateUrl: './convention-tabset.component.html',
  styleUrls: ['./convention-tabset.component.css']
})
export class ConventionTabsetComponent implements OnInit {
  conventionid:any;
  test:boolean=false;
  url:any;
  disabled:boolean=true;
  constructor(private router: Router,private _Activatedroute:ActivatedRoute) { 
    router.events.subscribe((val) => {
      this.CheckUrl();
  })};

  ngOnInit(): void {
    this.CheckUrl();
  }
  changeTab(tab){
    if (this.url[4]=="add"){
      return;
     };
    tab=tab.toLowerCase();
    if (tab=="convention"){
      this.router.navigate(['/conventions/fiche/convention/'+this.conventionid]);
      return;
    }
    this.router.navigate(['/conventions/fiche/'+this.conventionid+'/'+tab+'/list']);
  };
  CheckUrl(){
    this._Activatedroute.url.subscribe(activeUrl=>{
      this.url=window.location.pathname.split("/");
    });
    if (this.url[4] != "add"){
      this.disabled=false;
      this._Activatedroute.firstChild.firstChild.paramMap.subscribe(
        (params) => 
        { 
          this.conventionid = params.get("conventionid");
         });
    };
  }
}

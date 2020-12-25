import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-summer-club-tabset',
  templateUrl: './summer-club-tabset.component.html',
  styleUrls: ['./summer-club-tabset.component.css']
})
export class SummerClubTabsetComponent implements OnInit {
  clubid:any;

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
    if (tab=="groupe"){
      this.router.navigate(['/groupes/fiche/groupe/'+this.clubid]);
      return;
    }
    this.router.navigate(['/groupes/fiche/'+this.clubid+'/'+tab+'/list']);
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
          this.clubid = params.get("groupeid");
         });
    };
  }
}

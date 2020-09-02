import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-eleve-te',
  templateUrl: './add-eleve-te.component.html',
  styleUrls: ['./add-eleve-te.component.css']
})
export class AddEleveTeComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  NavigateToList(){
    this.router.navigate(["eleves/list"])
  }
  EleveRegistered(event){
    this.router.navigate(['eleves/fiche/eleve/'+event]);
  }
}

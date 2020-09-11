import { Component, OnInit } from '@angular/core';
import { Convention } from 'src/app/_core/_models/convention';
import { ConventionService } from 'src/app/_core/_services/convention.service';
import { ConventionFee } from 'src/app/_core/_models/convention-fee';
import { Router } from '@angular/router';

@Component({
  selector: 'app-convention-list',
  templateUrl: './convention-list.component.html',
  styleUrls: ['./convention-list.component.css']
})
export class ConventionListComponent implements OnInit {
  Conventions:Convention[]=[];
  ConventionFees:ConventionFee[]=[];
  constructor(private conventionService:ConventionService,private router:Router) { }

  ngOnInit(): void {
    this.conventionService.GetAll().subscribe(
      data=>{
        this.Conventions=data;
        this.ConventionFees=data.map(d=>d.conventionFees)
      },
      err=>console.log(err)
    )
  }
  EditConvention(id){
    this.router.navigate(['conventions/fiche/convention/'+id])
  }
  AddConvention(){
    this.router.navigate(['conventions/fiche/convention/add'])
  }
}

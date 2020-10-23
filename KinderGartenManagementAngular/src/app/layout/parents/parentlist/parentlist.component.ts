import { Component, OnInit } from '@angular/core';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { Parent } from 'src/app/_core/_models/parent';
import { Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'app-parentlist',
  templateUrl: './parentlist.component.html',
  styleUrls: ['./parentlist.component.css']
})
export class ParentlistComponent implements OnInit {
  ParentsAndConventions:{p:Parent[],nameOfConvention:string}[]=[];
  Parents:Parent[]=[];
  constructor(private parentService:ParentService,private router:Router,private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.GetAll();
  }
  GetAll(){
    this.parentService.GetAll().subscribe(data => {
      this.ParentsAndConventions=data;
      this.Parents=data.map(d=>d.p);
    },
    error => {  
      console.log(error);
    });
  };
  Edit(id){
    this.router.navigate(['/parents/fiche/parent/'+id])
  }
  Delete(id){
    this.parentService.DeleteParent(id).subscribe(
      data=>{
        this.toastrService.show('Parent Supprimé','Suppression',{status:"success"});
        this.parentService.GetAll().subscribe(data => {
          this.ParentsAndConventions=data;
          this.Parents=data.map(d=>d.p);
        });
      },
      err=>{this.toastrService.show("Une erreur est survenue",'Suppression',{status:"danger"})}
    );
  }
  AddParent(  ){
    this.router.navigate(['/parents/fiche/parent/add'])
  }
}

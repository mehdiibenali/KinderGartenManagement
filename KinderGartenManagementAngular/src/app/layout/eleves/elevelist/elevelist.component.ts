import { Component, OnInit } from '@angular/core';
import { EleveService } from 'src/app/_core/_services/eleve.service';
import { NbToastrService } from '@nebular/theme';
import { Router } from '@angular/router';
import { Eleve } from 'src/app/_core/_models/eleve';

@Component({
  selector: 'app-elevelist',
  templateUrl: './elevelist.component.html',
  styleUrls: ['./elevelist.component.css']
})
export class ElevelistComponent implements OnInit {
  Eleves:Eleve[]=[];
  constructor(
    private eleveService:EleveService,
    private toastrService: NbToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.GetAll();
  }
  GetAll(){
    this.eleveService.GetAll()
    .subscribe(data => {
      this.Eleves = data;
    },
    error => {  
      console.log(error);
    })
  }
  Delete(id){
    return this.eleveService.DeleteEleve(id).subscribe(
      (success)=>{
        this.toastrService.show('User deleted successfully', 'Delete',{status: 'success'});
        this.GetAll();
      },
      (error)=>{
        this.toastrService.show('Server error', 'Delete',{status: 'danger'});
      }
    )
  }
  Edit(id){
    this.router.navigate(['/eleves/fiche/eleve/'+id])
  }
  AddEleve(){
    this.router.navigate(["eleves/fiche/eleve/add"])
  }
}

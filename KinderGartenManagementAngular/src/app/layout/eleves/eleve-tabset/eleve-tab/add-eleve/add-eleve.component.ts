import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Eleve } from 'src/app/_core/_models/eleve';
import { EleveService } from 'src/app/_core/_services/eleve.service';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'app-add-eleve',
  templateUrl: './add-eleve.component.html',
  styleUrls: ['./add-eleve.component.css']
})
export class AddEleveComponent implements OnInit {
  eleve : Eleve = new Eleve();
  submitted = false;
  showelevefiche:string="nav-link disabled";
  showparentfiche:string="nav-link";
  showgroupefiche:string = "nav-link";
  elevefiche:boolean = true;
  parentfiche:boolean = false;
  groupefiche:boolean = false;
  constructor(private router: Router,private eleveService: EleveService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
  }
  RegisterEleve(){
    this.eleveService.AddEleve(this.eleve).subscribe(
      (success) => {
        this.toastrService.show('Eleve added successfully', 'Add', { status: 'success' });
        console.log(success)
        this.router.navigate(['eleves/fiche/eleve/'+success.id]);
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
          console.log(error);
      }   
    ) 
    this.submitted = true;
  }
}

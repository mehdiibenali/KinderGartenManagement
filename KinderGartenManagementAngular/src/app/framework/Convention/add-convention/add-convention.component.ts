import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Convention } from 'src/app/_core/_models/convention';
import { ConventionFee } from 'src/app/_core/_models/convention-fee';
import { ConventionService } from 'src/app/_core/_services/convention.service';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'app-add-convention',
  templateUrl: './add-convention.component.html',
  styleUrls: ['./add-convention.component.css']
})
export class AddConventionComponent implements OnInit {
  @Output("OnCancelAdd") CancelAdd:EventEmitter<String>=new EventEmitter<String>();
  @Output("OnAdd") Add:EventEmitter<String>=new EventEmitter<String>();
  convention:Convention= new Convention();
  conventionfee:ConventionFee=new ConventionFee();
  conventionfeewithguard:ConventionFee=new ConventionFee();
  constructor(private conventionService: ConventionService,private toastrService: NbToastrService) { } 

  ngOnInit(): void {
  }
  AddConvention(){
    this.conventionService.AddConvention(this.convention).subscribe(
      (success) => {
        this.conventionfee.code="GroupeWithGuard";
        this.conventionfee.conventionid=success.id;
        this.conventionService.AddConventionFee(this.conventionfee).subscribe(
          data=>{
            this.conventionfeewithguard=this.conventionfee;
            this.conventionfeewithguard.code="GroupewithoutGuard";
            this.conventionService.AddConventionFee(this.conventionfeewithguard).subscribe(
              data=>{
                this.toastrService.show('Convention Ajoutée', 'Ajout', { status: 'success' });
                this.Add.emit(success.id);
              },
              err=>console.log(err)
            )
          },
          err=>console.log(err)
        )
      },
      (error) => {
          this.toastrService.show('Servor Error', 'Ajout', { status: 'danger' });
          console.log(error);
      }   
    ) 
  }
  CancelAddConvention(){
    this.CancelAdd.emit();
  }
}

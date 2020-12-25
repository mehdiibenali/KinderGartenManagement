import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import { Club } from 'src/app/_core/_models/club';
import { SummerClubService } from 'src/app/_core/_services/summer-club.service';
import { WinterClubService } from 'src/app/_core/_services/winter-club.service';

@Component({
  selector: 'app-add-club',
  templateUrl: './add-club.component.html',
  styleUrls: ['./add-club.component.css']
})
export class AddClubComponent implements OnInit {
  @Output("OnCancelAdd") CancelAdd:EventEmitter<String>=new EventEmitter<String>();
  @Output("OnAdd") Add:EventEmitter<String>=new EventEmitter<String>();
  @Input() ClubType:string;
  Club:Club= new Club();
  constructor(private summerClubService:SummerClubService,private winterClubService:WinterClubService,private toastrService:NbToastrService) { }

  ngOnInit(): void {
  }
  AddClub(){
    if (this.ClubType=="SummerClub"){
      this.summerClubService.AddClub(this.Club).subscribe(
        data=>{
          this.toastrService.show('Club Ajouté', 'Ajout', { status: 'success' });
          this.Add.emit(data.id);
        },
        err=>{
          this.toastrService.show('Une erreur est survenue', 'Ajout', { status: 'danger' });
          console.log(err);
        }
      )
    }
    if (this.ClubType=="WinterClub"){
      this.winterClubService.AddClub(this.Club).subscribe(
        data=>{
          this.toastrService.show('Club Ajouté', 'Ajout', { status: 'success' });
          this.Add.emit(data.id);
        },
        err=>{
          this.toastrService.show('Une erreur est survenue', 'Ajout', { status: 'danger' });
          console.log(err);
        }
      )
    }

  }
  CancelAddClub(){
    this.CancelAdd.emit();
  }
}

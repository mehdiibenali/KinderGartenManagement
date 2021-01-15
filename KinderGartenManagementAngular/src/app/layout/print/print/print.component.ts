import { Component, OnInit, ViewChild } from '@angular/core';
import { Eleve } from 'src/app/_core/_models/eleve';
import { MonthEnrollementid } from 'src/app/_core/_models/month-enrollementid';
import { SearchEnrollement } from 'src/app/_core/_models/search-enrollement';
import { EleveService } from 'src/app/_core/_services/eleve.service';
import { GroupeService } from 'src/app/_core/_services/groupe.service';
import { ParameterService } from 'src/app/_core/_services/parameter.service';
import { SummerClubService } from 'src/app/_core/_services/summer-club.service';
import { WinterClubService } from 'src/app/_core/_services/winter-club.service';

@Component({
  selector: 'app-print',
  templateUrl: './print.component.html',
  styleUrls: ['./print.component.css']
})
export class PrintComponent implements OnInit {
  EnrollementType: string;
  Enrollements: any[];
  search: SearchEnrollement = new SearchEnrollement();
  monthenrollementid: MonthEnrollementid = new MonthEnrollementid();
  Eleves: Eleve[] = [];
  Dates: Date[] = [];
  date: any;
  month: number;
  year: number;
  Array = Array(12);
  show = false;
  enrollementtypes = ['Club d\'été', 'Club d\'hiver', 'Groupe']
  constructor(private groupeService: GroupeService, private summerClubService: SummerClubService, private winterClubService: WinterClubService, private parameterService: ParameterService, private eleveService: EleveService) { }
  ngOnInit(): void {
    this.year = (new Date()).getFullYear();
    this.month = (new Date()).getMonth()+1;
  }
  SearchEnrollement() {
    this.search.year = this.year;
    this.search.month = this.month;
    if (this.EnrollementType == "Club d'été") {
      this.summerClubService.Search(this.search).subscribe(
        data => { this.Enrollements = data; console.log(data) },
        err => console.log(err)
      )
    }
    else {
      if (this.EnrollementType == "Club d'hiver") {
        this.winterClubService.Search(this.search).subscribe(
          data => { this.Enrollements = data; console.log(data) },
          err => { console.log(err) }
        )
      }
      else {
        this.groupeService.Search(this.search).subscribe(
          data => { this.Enrollements = data; console.log(data) },
          err => { console.log(err) }
        )

      }
    }
  }
  Print() {
    this.show=true;
    this.search.year = this.year;
    this.monthenrollementid.month = this.month;
    this.monthenrollementid.year = this.search.year;
    this.eleveService.GetByMonthAndEnrollementId(this.monthenrollementid).subscribe(
      data => { this.Eleves = data; console.log(data) },
      err => { console.log(err) }
    )
    this.parameterService.GetMonthDates(this.monthenrollementid).subscribe(
      data => { this.Dates = data; console.log(this.Dates) },
      err => { console.log(err) }
    )
  }
  CheckClass(day){
    if (day != "Saturday" && day!="Sunday"){
      return "tablecolumn"
    }
    return "weekend"
  }
}

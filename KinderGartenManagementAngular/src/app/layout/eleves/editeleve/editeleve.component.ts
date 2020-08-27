import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EleveService } from 'src/app/_core/_services/eleve.service';
import { NbToastrService } from '@nebular/theme';
import { Eleve } from 'src/app/_core/_models/eleve';

@Component({
  selector: 'app-editeleve',
  templateUrl: './editeleve.component.html',
  styleUrls: ['./editeleve.component.css']
})
export class EditeleveComponent implements OnInit {
  edit:boolean;
  eleve : Eleve = new Eleve();
  groupes:any;
  id:any;
  submitted = false;
  constructor(private _Activatedroute:ActivatedRoute,private eleveService:EleveService, private toastrService: NbToastrService) { }

  ngOnInit(): void {
    this.id=this._Activatedroute.snapshot.paramMap.get("id");

  }
}

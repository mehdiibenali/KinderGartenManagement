import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbToastrService } from '@nebular/theme';
import { ParentService } from 'src/app/_core/_services/parent.service';

@Component({
  selector: 'app-add-parent-tp',
  templateUrl: './add-parent-tp.component.html',
  styleUrls: ['./add-parent-tp.component.css']
})
export class AddParentTpComponent implements OnInit {

  constructor(private _Activatedroute:ActivatedRoute,private router:Router,private parentService:ParentService, private toastrService: NbToastrService) { }
  ngOnInit(): void {
  }
  CancelAddParent(){
    this.router.navigate(["parents/list"])
  }
  ParentAdded(event){}
}

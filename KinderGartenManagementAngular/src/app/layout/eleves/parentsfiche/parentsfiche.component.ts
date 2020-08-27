import { Component, OnInit, Input } from '@angular/core';
import { Parent } from 'src/app/_core/_models/parent';
import { ParentService } from 'src/app/_core/_services/parent.service';
import { NbToastrService } from '@nebular/theme';
import { EleveParent } from 'src/app/_core/_models/eleve-parent';

@Component({
  selector: 'app-parentsfiche',
  templateUrl: './parentsfiche.component.html',
  styleUrls: ['./parentsfiche.component.css']
})
export class ParentsficheComponent implements OnInit {
  @Input() eleveId:number;
  eleveparent : EleveParent = new EleveParent();
  parent:Parent = new Parent();
  Parents:Parent[] = [];
  state:string = "list";
  CheckForAdd:string="Cancel"
  constructor(private parentService:ParentService, private toastrService: NbToastrService) { }
  ngOnInit(): void {
    this.GetByEleveId();
  }
  RegisterParent(){
    this.parentService.AddParent(this.parent).subscribe(
      (data) => {
        this.eleveparent.EleveId = this.eleveId;
        this.eleveparent.ParentId = data.id;
        this.parentService.AddEleveParent(this.eleveparent).subscribe(
          (success) => {
            this.toastrService.show('Parent added successfully', 'Add', { status: 'success' });
              
          },
          (error) => {
              this.toastrService.show('Server error', 'Add', { status: 'danger' });
              console.log(error);
          } 
        )
      },
      (error) => {
          this.toastrService.show('Server error', 'Add', { status: 'danger' });
          console.log(error);
      }   
    ) 
  }
  GetById(id:number){
    return this.parentService.GetById(id);
  }
  GetByEleveId(){
    this.parentService.GetParentByEleveId(this.eleveId).subscribe(data => {
      this.Parents = data;
    },
    error => {  
      console.log(error);
    });
  }
  AddParent(){
    this.state = "add";
    this.CheckForAdd = "Cancel";
  }
  EditParent(id:number){
    this.state = "edit";
  }
  CancelAddParent(){
    this.state="list";
    this.CheckForAdd="Go Back";
  }
}

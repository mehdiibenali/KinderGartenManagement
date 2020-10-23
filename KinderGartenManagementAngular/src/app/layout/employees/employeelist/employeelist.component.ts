import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/_core/_models/Employee';
import { EmployeeService } from 'src/app/_core/_services/employee.service';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { Router } from '@angular/router';
import { Userforedit } from 'src/app/_core/_models/userforedit';
import { Payload } from 'src/app/_core/_models/payload';
import { NbAuthJWTToken, NbAuthService } from '@nebular/auth';
@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.css']
  
})
export class EmployeelistComponent implements OnInit {

  constructor(
    private employeeService:EmployeeService,
    private toastrService: NbToastrService,
    private router: Router,
    private authService: NbAuthService,
    private dialogService: NbDialogService
    ) { }
  Employees:Employee[]=[];
  user:Payload;
  dialog:any;
  ngOnInit(): void {
    this.authService.onTokenChange()
    .subscribe((token: NbAuthJWTToken) => {
        if (token.isValid()) {
            this.user = token.getPayload();
        }
    });
   this.GetAll();
  }
  Delete(username){
    this.dialog=this.dialogService.open(this.dialog,
      {
      closeOnBackdropClick:false,
      // .onClose.subscribe(data=>console.log(data));
      })
       return this.employeeService.DeleteEmployee(username).subscribe(
      (success)=>{
        this.toastrService.show('Utilisateur supprimé', 'Suppression',{status: 'success'});
        this.GetAll();
      },
      (error)=>{
        this.toastrService.show('Une erreur est survenue', 'Suppression',{status: 'danger'});
      }
    )
  }
  Edit(username:string){
    this.router.navigate(['/employees/edit/'+username])
  }
  GetAll(){
    console.log(this.user.username)
    this.employeeService.GetAll(this.user.username)
    .subscribe(data => {
      this.Employees = data;
    },
    error => {
      console.log(error);
    })
  }
  AddEmployee(){
    this.router.navigate(['/employees/add'])
  }

}

import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/_core/_models/Employee';
import { EmployeeService } from 'src/app/_core/_services/employee.service';
import { NbToastrService } from '@nebular/theme';
import { Router } from '@angular/router';
import { Userforedit } from 'src/app/_core/_models/userforedit';
@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.css']
  
})
export class EmployeelistComponent implements OnInit {

  constructor(
    private employeeService:EmployeeService,
    private toastrService: NbToastrService,
    private router: Router
    ) { }
  Employees:Employee[]=[];

  ngOnInit(): void {
   this.GetAll();
  }
  Delete(username){
    return this.employeeService.DeleteEmployee(username).subscribe(
      (success)=>{
        this.toastrService.show('User deleted successfully', 'Delete',{status: 'success'});
        this.GetAll();
      },
      (error)=>{
        this.toastrService.show('Server error', 'Delete',{status: 'danger'});
      }
    )
  }
  Edit(username:string){
    this.router.navigate(['/employees/edit/'+username])
  }
  GetAll(){
    this.employeeService.GetAll()
    .subscribe(data => {
      this.Employees = data;
    },
    error => {
      console.log(error);
    })
  }

}

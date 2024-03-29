import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/_core/_services/employee.service';
import { Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { User } from 'src/app/_core/_models/user';
import { async } from '@angular/core/testing';
import { NbToastrService } from '@nebular/theme';
import { Router } from '@angular/router';
@Component({
  selector: 'app-addemployee',
  templateUrl: './addemployee.component.html',
  styleUrls: ['./addemployee.component.css']
})
export class AddemployeeComponent implements OnInit {
  progress: number;
  confirmPassword: string;
  message: string;
  user: User = new User();
  response: { dbPath: '' };
  constructor(private router:Router,private employeeService: EmployeeService, private toastrService: NbToastrService) { }
  FileToUpload: File = null;
  file: any;
  submitted = false;
  ngOnInit(): void {
  }
  AddEmployee() {
    if (this.file == null){this.registerEmployee();return};
    let fileToUpload = this.file;
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.employeeService.AddPicture(formData)
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Success';
          this.uploadFinished(event.body);
          this.registerEmployee();
        }
      });
  }
  uploadFinished = (event) => {
    this.response = event;
    this.user.profilepicture = this.response.dbPath;
  }
  SaveFile($event) {
    this.file = $event.target.files[0];
  }
  registerEmployee() {
    this.employeeService.AddEmployee(this.user).subscribe(
      (success) => {
        this.toastrService.show('Utilisateur Ajouté', 'Ajout', { status: 'success' });
        this.router.navigate(['/employees'])
      },
      (error) => {
        if (error == null){
          this.toastrService.show('Permission refusée', 'Ajout', { status: 'danger' });
        }
        else{
          this.toastrService.show('Une erreur est survenue', 'Ajout', { status: 'danger' });
          console.log(error);
        }
      }   
    )
    this.submitted = true;
  }
  CancelAddEmployee(){
    this.router.navigate(['/employees'])
  }
}

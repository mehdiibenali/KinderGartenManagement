import { Component, OnInit, Input } from '@angular/core';
import { Userforedit } from 'src/app/_core/_models/userforedit';
import { EmployeeService } from 'src/app/_core/_services/employee.service';
import { NbToastrService } from '@nebular/theme';
import { HttpEventType } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editemployee',
  templateUrl: './editemployee.component.html',
  styleUrls: ['./editemployee.component.css']
})
export class EditemployeeComponent implements OnInit {
  progress: number;
  message: string;
  user: Userforedit = new Userforedit() ;
  imageUrl: string = "assets/img/Default.jpg";
  FileToUpload: File = null;
  file: any;
  username : string;
  submitted = false;
  response: { dbPath: '' };
  constructor(private _Activatedroute:ActivatedRoute,private employeeService:EmployeeService, private toastrService: NbToastrService) { }
  ngOnInit(): void {
    this.username=this._Activatedroute.snapshot.paramMap.get("username");
    this.employeeService.GetByUserName(this.username)
    .subscribe(data => {
      this.user.firstname = data.firstName;
      this.user.lastname = data.lastName;
      this.user.email = data.email;
      this.user.username = data.userName;
      this.user.profilepicture = data.profilePicture;
      this.user.role = data.role;
    },
    error => {
      console.log(error);
    });
  }
  SaveFile($event) {
    this.file = $event.target.files[0];
  }
  UpdateEmployee(){
    if (this.file == null){this.RefreshEmployee();return};
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
          this.RefreshEmployee();
        }
      });
  }
  uploadFinished(event){
    this.response = event;
    this.user.profilepicture = this.response.dbPath;
  };
  RefreshEmployee(){
    this.employeeService.UpdateEmployee(this.user,this.user.username).subscribe(
      (success) => {
        this.toastrService.show('User Updated successfully', 'Update', { status: 'success' });
      },
      (error) => {
        this.toastrService.show('Server error', 'Update', { status: 'danger' });
      }   
    )
  };

}

import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Employee } from '../_models/Employee';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Userforedit } from '../_models/userforedit';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(
    private api : ApiService,
  ) { }
  AddEmployee(user:User){
    return this.api.post('/api/ApplicationUser/Register',user);
  }
  AddPicture(formData){
    return this.api.postfile('/api/ApplicationUser/Upload', formData)
  }
  GetAll(){
    return this.api.get('/api/ApplicationUser/GetAll')
  }
  DeleteEmployee(username){
    return this.api.delete('/api/ApplicationUser/Delete/'+username)
  }
  UpdateEmployee(user,username){
    return this.api.put('/api/ApplicationUser/Update/'+username,user)
  }
  GetByUserName(username:string){
    return this.api.get('/api/ApplicationUser/GetByUserName/'+username)
  }
}

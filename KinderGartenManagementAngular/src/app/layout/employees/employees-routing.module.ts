import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeelistComponent } from './employeelist/employeelist.component';
import { EditemployeeComponent } from './editemployee/editemployee.component';
import { AddemployeeComponent } from './addemployee/addemployee.component';
import { User } from 'src/app/_core/_models/user';
import { AuthGuard } from 'src/app/auth/auth-guard.service';


const routes: Routes = [
  {
    path:'',
    component: EmployeelistComponent,
  },
  {
    path:'edit/:username',
    component: EditemployeeComponent, 
  },
  {
    path:'add',
    component: AddemployeeComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeesRoutingModule { }

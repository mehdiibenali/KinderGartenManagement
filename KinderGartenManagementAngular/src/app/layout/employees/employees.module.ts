import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeesRoutingModule } from './employees-routing.module';
import { EmployeelistComponent } from './employeelist/employeelist.component';
import { EditemployeeComponent } from './editemployee/editemployee.component';
import { AddemployeeComponent } from './addemployee/addemployee.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonComponent, NbButtonModule, NbMenuComponent, NbMenuModule, NbSidebarModule, NbDialogModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [EmployeelistComponent, EditemployeeComponent, AddemployeeComponent],
  imports: [
    CommonModule,
    EmployeesRoutingModule,
    NbCardModule,
    NbSelectModule,
    NbIconModule,
    NbAlertModule,
    NbInputModule,
    RouterModule,
    FormsModule,
    NbButtonModule,
    NbDialogModule.forRoot(),
  ]
})
export class EmployeesModule { }

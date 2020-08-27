import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { NbLayoutModule, NbSidebarModule, NbButtonModule, NbContextMenuModule, NbMenuModule } from '@nebular/theme';
import { LayoutComponent } from './layout.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { NavComponent } from './nav/nav.component';;
// import { EmployeelistComponent } from './employees/employeelist/employeelist.component';


@NgModule({
  declarations: [LayoutComponent, SidebarComponent, NavComponent],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    NbLayoutModule,
    NbSidebarModule.forRoot(), // NbSidebarModule.forRoot(), //if this is your app.module
    NbButtonModule,
    NbContextMenuModule,
    NbMenuModule.forRoot(),
  ]
})
export class LayoutModule { }

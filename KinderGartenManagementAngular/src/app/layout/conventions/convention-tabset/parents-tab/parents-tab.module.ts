import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParentsTabRoutingModule } from './parents-tab-routing.module';
import { ParentsListComponent } from './parents-list/parents-list.component';
import { NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule, NbCheckboxModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FrameworkModule } from 'src/app/framework/framework.module';


@NgModule({
  declarations: [ParentsListComponent],
  imports: [
    CommonModule,
    ParentsTabRoutingModule,
    NbSelectModule,
    NbIconModule,
    NbAlertModule,
    NbInputModule,
    RouterModule,
    FormsModule,
    NbButtonModule,
    NbTabsetModule,
    NbSpinnerModule,
    FrameworkModule,
    NbCheckboxModule,
  ]
})
export class ParentsTabModule { }

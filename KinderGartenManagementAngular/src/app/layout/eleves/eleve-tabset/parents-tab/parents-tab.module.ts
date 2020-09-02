import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParentsTabRoutingModule } from './parents-tab-routing.module';
import { ParentsListComponent } from './parents-list/parents-list.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AddParentTeComponent } from './add-parent-te/add-parent-te.component';
import { FrameworkModule } from 'src/app/framework/framework.module';
import { EditParentTeComponent } from './edit-parent-te/edit-parent-te.component';


@NgModule({
  declarations: [ParentsListComponent, AddParentTeComponent, EditParentTeComponent],
  imports: [
    CommonModule,
    ParentsTabRoutingModule,
    NbCardModule,
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
  ]
})
export class ParentsTabModule { }

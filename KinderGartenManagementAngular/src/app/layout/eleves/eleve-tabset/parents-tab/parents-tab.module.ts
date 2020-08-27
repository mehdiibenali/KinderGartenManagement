import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParentsTabRoutingModule } from './parents-tab-routing.module';
import { ParentsListComponent } from './parents-list/parents-list.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { EditParentComponent } from './edit-parent/edit-parent.component';
import { AddParentComponent } from './add-parent/add-parent.component';


@NgModule({
  declarations: [ParentsListComponent, EditParentComponent, AddParentComponent],
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
  ]
})
export class ParentsTabModule { }

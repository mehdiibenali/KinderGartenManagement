import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GroupesTabRoutingModule } from './groupes-tab-routing.module';
import { GroupesListComponent } from './groupes-list/groupes-list.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [GroupesListComponent],
  imports: [
    CommonModule,
    GroupesTabRoutingModule,
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
export class GroupesTabModule { }

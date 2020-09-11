import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParentTabsetRoutingModule } from './parent-tabset-routing.module';
import { ParentTabsetComponent } from './parent-tabset.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ParentTabsetComponent],
  imports: [
    CommonModule,
    ParentTabsetRoutingModule,
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
export class ParentTabsetModule { }

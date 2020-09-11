import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConventionTabsetRoutingModule } from './convention-tabset-routing.module';
import { ConventionTabsetComponent } from './convention-tabset.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ConventionTabsetComponent],
  imports: [
    CommonModule,
    ConventionTabsetRoutingModule,
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
export class ConventionTabsetModule { }

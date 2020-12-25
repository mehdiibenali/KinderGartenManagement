import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SummerClubTabsetRoutingModule } from './summer-club-tabset-routing.module';
import { SummerClubTabsetComponent } from './summer-club-tabset.component';
import { NbAlertModule, NbButtonModule, NbCardModule, NbIconModule, NbInputModule, NbSelectModule, NbSpinnerModule, NbTabsetModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [SummerClubTabsetComponent],
  imports: [
    CommonModule,
    SummerClubTabsetRoutingModule,
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
export class SummerClubTabsetModule { }

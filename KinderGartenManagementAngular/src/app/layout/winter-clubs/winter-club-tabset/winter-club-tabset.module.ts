import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WinterClubTabsetRoutingModule } from './winter-club-tabset-routing.module';
import { WinterClubTabsetComponent } from './winter-club-tabset.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';


@NgModule({
  declarations: [WinterClubTabsetComponent],
  imports: [
    CommonModule,
    WinterClubTabsetRoutingModule,
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
export class WinterClubTabsetModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ElevesRoutingModule } from './eleves-routing.module';
import { ElevelistComponent } from './elevelist/elevelist.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule, NbCheckboxModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ElevelistComponent],
  imports: [
    CommonModule,
    ElevesRoutingModule,
    NbAlertModule,
    RouterModule,
    NbButtonModule,
    NbInputModule,
    FormsModule,
    NbCardModule,
    NbSelectModule,
    NbIconModule,
    NbAlertModule,
    NbTabsetModule,
    NbSpinnerModule,
    NbCheckboxModule,
  ],
})
export class ElevesModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ElevesRoutingModule } from './eleves-routing.module';
import { ElevelistComponent } from './elevelist/elevelist.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ElevelistComponent],
  imports: [
    CommonModule,
    ElevesRoutingModule,
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
  ],
})
export class ElevesModule { }

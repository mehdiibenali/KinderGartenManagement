import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrintRoutingModule } from './print-routing.module';
import { PrintComponent } from './print/print.component';
import { RouterModule } from '@angular/router';
import { NbAlertModule, NbButtonModule, NbCalendarComponent, NbCalendarModule, NbCardModule, NbCheckboxModule, NbIconModule, NbInputModule, NbSelectModule, NbSpinnerModule, NbTabsetModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';
import { NgxPrintModule } from 'ngx-print';


@NgModule({
  declarations: [PrintComponent],
  imports: [
    CommonModule,
    PrintRoutingModule,
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
    NbCalendarModule,
    NgxPrintModule,
  ]
})
export class PrintModule { }

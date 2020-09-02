import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EleveTabsetRoutingModule } from './eleve-tabset-routing.module';
import { EleveTabsetComponent } from './eleve-tabset.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { LayoutModule } from '../../layout.module';


@NgModule({
  declarations: [EleveTabsetComponent],
  imports: [
    CommonModule,
    EleveTabsetRoutingModule,
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
export class EleveTabsetModule { }

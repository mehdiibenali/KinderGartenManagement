import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EleveTabsetRoutingModule } from './eleve-tabset-routing.module';
import { EleveTabsetComponent } from './eleve-tabset/eleve-tabset.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AddEleveComponent } from './eleve-tab/add-eleve/add-eleve.component';
import { EditEleveComponent } from './eleve-tab/edit-eleve/edit-eleve.component';


@NgModule({
  declarations: [EleveTabsetComponent,AddEleveComponent,EditEleveComponent],
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

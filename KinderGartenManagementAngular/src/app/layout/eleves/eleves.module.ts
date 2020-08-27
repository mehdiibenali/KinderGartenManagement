import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ElevesRoutingModule } from './eleves-routing.module';
import { EditeleveComponent } from './editeleve/editeleve.component';
import { ElevelistComponent } from './elevelist/elevelist.component';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ParentsficheComponent } from './parentsfiche/parentsfiche.component';
import { GroupesficheComponent } from './groupesfiche/groupesfiche.component';
import { EleveComponent } from './eleve/eleve.component';


@NgModule({
  declarations: [EditeleveComponent, ElevelistComponent, ParentsficheComponent, GroupesficheComponent, EleveComponent,],
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

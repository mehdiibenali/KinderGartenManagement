import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConventionsRoutingModule } from './conventions-routing.module';
import { ConventionListComponent } from './convention-list/convention-list.component';
import { NbButtonModule, NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbTabsetModule, NbSpinnerModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ConventionListComponent],
  imports: [
    CommonModule,
    ConventionsRoutingModule,
    NbAlertModule,
    RouterModule,
    NbButtonModule,
   ]
})
export class ConventionsModule { }

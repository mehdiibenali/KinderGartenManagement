import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GroupeTabsetRoutingModule } from './groupe-tabset-routing.module';
import { GroupeTabsetComponent } from './groupe-tabset.component';
import { NbAlertModule, NbButtonModule, NbCardModule, NbIconModule, NbInputModule, NbSelectModule, NbSpinnerModule, NbTabsetModule } from '@nebular/theme';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [GroupeTabsetComponent],
  imports: [
    CommonModule,
    GroupeTabsetRoutingModule,
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
export class GroupeTabsetModule { }

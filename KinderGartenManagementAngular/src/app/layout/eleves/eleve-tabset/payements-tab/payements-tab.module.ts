import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PayementsTabRoutingModule } from './payements-tab-routing.module';
import { PayementsListComponent } from './payements-list/payements-list.component';
import { AddPayementTeComponent } from './add-payement-te/add-payement-te.component';
import { EditPayementTeComponent } from './edit-payement-te/edit-payement-te.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NbCardModule, NbSelectModule, NbIconModule, NbAlertModule, NbInputModule, NbButtonModule, NbTabsetModule, NbSpinnerModule, NbCheckboxModule } from '@nebular/theme';
import { FrameworkModule } from 'src/app/framework/framework.module';


@NgModule({
  declarations: [PayementsListComponent, AddPayementTeComponent, EditPayementTeComponent],
  imports: [
    CommonModule,
    PayementsTabRoutingModule,
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
    FrameworkModule,
    NbCheckboxModule,
  ]
})
export class PayementsTabModule { }

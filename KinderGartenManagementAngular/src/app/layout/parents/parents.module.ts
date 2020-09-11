import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParentsRoutingModule } from './parents-routing.module';
import { ParentlistComponent } from './parentlist/parentlist.component';
import { NbAlertModule, NbButtonModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [ParentlistComponent],
  imports: [
    CommonModule,
    ParentsRoutingModule,
    NbAlertModule,
    RouterModule,
    NbButtonModule,
  ]
})
export class ParentsModule { }

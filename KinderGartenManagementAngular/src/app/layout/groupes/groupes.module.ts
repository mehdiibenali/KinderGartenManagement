import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GroupesRoutingModule } from './groupes-routing.module';
import { GroupelistComponent } from './groupelist/groupelist.component';
import { RouterModule } from '@angular/router';
import { NbAlertModule, NbButtonModule } from '@nebular/theme';


@NgModule({
  declarations: [GroupelistComponent],
  imports: [
    CommonModule,
    GroupesRoutingModule,
    NbAlertModule,
    RouterModule,
    NbButtonModule,
  ]
})
export class GroupesModule { }

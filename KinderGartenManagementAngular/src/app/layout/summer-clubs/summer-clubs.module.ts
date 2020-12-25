import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SummerClubsRoutingModule } from './summer-clubs-routing.module';
import { SummerClublistComponent } from './summer-clublist/summer-clublist.component';
import { RouterModule } from '@angular/router';
import { NbAlertModule, NbButtonModule } from '@nebular/theme';


@NgModule({
  declarations: [SummerClublistComponent],
  imports: [
    CommonModule,
    SummerClubsRoutingModule,
    NbAlertModule,
    RouterModule,
    NbButtonModule,
  ]
})
export class SummerClubsModule { }

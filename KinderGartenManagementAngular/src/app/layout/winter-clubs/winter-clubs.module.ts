import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WinterClubsRoutingModule } from './winter-clubs-routing.module';
import { WinterClublistComponent } from './winter-clublist/winter-clublist.component';
import { RouterModule } from '@angular/router';
import { NbAlertModule, NbButtonModule } from '@nebular/theme';


@NgModule({
  declarations: [WinterClublistComponent],
  imports: [
    CommonModule,
    WinterClubsRoutingModule,
    NbAlertModule,
    RouterModule,
    NbButtonModule,
  ]
})
export class WinterClubsModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WinterClubsRoutingModule } from './winter-clubs-routing.module';
import { WinterClublistComponent } from './winter-clublist/winter-clublist.component';


@NgModule({
  declarations: [WinterClublistComponent],
  imports: [
    CommonModule,
    WinterClubsRoutingModule
  ]
})
export class WinterClubsModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SummerClubsRoutingModule } from './summer-clubs-routing.module';
import { SummerClublistComponent } from './summer-clublist/summer-clublist.component';


@NgModule({
  declarations: [SummerClublistComponent],
  imports: [
    CommonModule,
    SummerClubsRoutingModule
  ]
})
export class SummerClubsModule { }

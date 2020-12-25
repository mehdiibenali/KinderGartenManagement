import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WinterClubTabRoutingModule } from './winter-club-tab-routing.module';
import { AddWinterClubWctComponent } from './add-winter-club-wct/add-winter-club-wct.component';
import { FrameworkModule } from 'src/app/framework/framework.module';


@NgModule({
  declarations: [AddWinterClubWctComponent],
  imports: [
    CommonModule,
    WinterClubTabRoutingModule,
    FrameworkModule,
  ]
})
export class WinterClubTabModule { }

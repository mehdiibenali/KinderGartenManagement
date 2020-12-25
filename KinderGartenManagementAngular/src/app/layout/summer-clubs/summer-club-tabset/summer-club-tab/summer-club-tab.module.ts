import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SummerClubTabRoutingModule } from './summer-club-tab-routing.module';
import { AddSummerClubSctComponent } from './add-summer-club-sct/add-summer-club-sct.component';
import { FrameworkModule } from 'src/app/framework/framework.module';


@NgModule({
  declarations: [AddSummerClubSctComponent],
  imports: [
    CommonModule,
    SummerClubTabRoutingModule,
    FrameworkModule
  ]
})
export class SummerClubTabModule { }

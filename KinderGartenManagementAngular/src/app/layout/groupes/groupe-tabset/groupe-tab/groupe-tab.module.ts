import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GroupeTabRoutingModule } from './groupe-tab-routing.module';
import { AddGroupeGtComponent } from './add-groupe-gt/add-groupe-gt.component';
import { FrameworkModule } from 'src/app/framework/framework.module';


@NgModule({
  declarations: [AddGroupeGtComponent],
  imports: [
    CommonModule,
    GroupeTabRoutingModule,
    FrameworkModule,
  ]
})
export class GroupeTabModule { }

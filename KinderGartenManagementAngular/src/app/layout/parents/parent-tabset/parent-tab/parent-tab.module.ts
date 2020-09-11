import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParentTabRoutingModule } from './parent-tab-routing.module';
import { AddParentTpComponent } from './add-parent-tp/add-parent-tp.component';


@NgModule({
  declarations: [AddParentTpComponent],
  imports: [
    CommonModule,
    ParentTabRoutingModule
  ]
})
export class ParentTabModule { }

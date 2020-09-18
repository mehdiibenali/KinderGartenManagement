import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParentTabRoutingModule } from './parent-tab-routing.module';
import { AddParentTpComponent } from './add-parent-tp/add-parent-tp.component';
import { FrameworkModule } from 'src/app/framework/framework.module';
import { EditParentTpComponent } from './edit-parent-tp/edit-parent-tp.component';


@NgModule({
  declarations: [AddParentTpComponent, EditParentTpComponent],
  imports: [
    CommonModule,
    ParentTabRoutingModule,
    FrameworkModule,
  ]
})
export class ParentTabModule { }

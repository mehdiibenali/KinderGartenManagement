import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConventionTabRoutingModule } from './convention-tab-routing.module';
import { AddConventionCtComponent } from './add-convention-ct/add-convention-ct.component';
import { FrameworkModule } from 'src/app/framework/framework.module';
import { EditConventionCtComponent } from './edit-convention-ct/edit-convention-ct.component';


@NgModule({
  declarations: [AddConventionCtComponent, EditConventionCtComponent],
  imports: [
    CommonModule,
    ConventionTabRoutingModule,
    FrameworkModule
  ]
})
export class ConventionTabModule { }

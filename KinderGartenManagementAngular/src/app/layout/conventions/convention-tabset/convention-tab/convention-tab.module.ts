import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConventionTabRoutingModule } from './convention-tab-routing.module';
import { AddConventionCtComponent } from './add-convention-ct/add-convention-ct.component';
import { FrameworkModule } from 'src/app/framework/framework.module';


@NgModule({
  declarations: [AddConventionCtComponent,],
  imports: [
    CommonModule,
    ConventionTabRoutingModule,
    FrameworkModule
  ]
})
export class ConventionTabModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConventionsRoutingModule } from './conventions-routing.module';
import { ConventionListComponent } from './convention-list/convention-list.component';


@NgModule({
  declarations: [ConventionListComponent],
  imports: [
    CommonModule,
    ConventionsRoutingModule
  ]
})
export class ConventionsModule { }

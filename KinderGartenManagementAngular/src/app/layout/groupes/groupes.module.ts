import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GroupesRoutingModule } from './groupes-routing.module';
import { GroupelistComponent } from './groupelist/groupelist.component';


@NgModule({
  declarations: [GroupelistComponent],
  imports: [
    CommonModule,
    GroupesRoutingModule
  ]
})
export class GroupesModule { }

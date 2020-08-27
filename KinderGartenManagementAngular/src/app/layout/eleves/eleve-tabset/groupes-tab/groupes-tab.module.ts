import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GroupesTabRoutingModule } from './groupes-tab-routing.module';
import { GroupesListComponent } from './groupes-list/groupes-list.component';
import { AddGroupeComponent } from './add-groupe/add-groupe.component';


@NgModule({
  declarations: [GroupesListComponent, AddGroupeComponent],
  imports: [
    CommonModule,
    GroupesTabRoutingModule
  ]
})
export class GroupesTabModule { }

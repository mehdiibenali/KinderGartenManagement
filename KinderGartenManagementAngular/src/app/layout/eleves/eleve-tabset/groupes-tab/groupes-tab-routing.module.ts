import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupesListComponent } from './groupes-list/groupes-list.component';
import { AddParentComponent } from '../parents-tab/add-parent/add-parent.component';


const routes: Routes = [
  {
    path:"list",
    component:GroupesListComponent
  },
  {
    path:"add",
    component:AddParentComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupesTabRoutingModule { }

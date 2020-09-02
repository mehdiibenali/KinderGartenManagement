import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupesListComponent } from './groupes-list/groupes-list.component';


const routes: Routes = [
  {
    path:"list",
    component:GroupesListComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupesTabRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentsListComponent } from './parents-list/parents-list.component';
import { EditParentComponent } from './edit-parent/edit-parent.component';
import { AddParentComponent } from './add-parent/add-parent.component';


const routes: Routes = [
  {
    path:"list",
    component:ParentsListComponent
  },
  {
    path:"add",
    component:AddParentComponent
  },
  {
    path:":parentid",
    component:EditParentComponent
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParentsTabRoutingModule { }

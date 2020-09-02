import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentsListComponent } from './parents-list/parents-list.component';
import { AddParentTeComponent } from './add-parent-te/add-parent-te.component';
import { EditParentTeComponent } from './edit-parent-te/edit-parent-te.component';


const routes: Routes = [
  {
    path:"list",
    component:ParentsListComponent
  },
  {
    path:"add",
    component:AddParentTeComponent
  },
  {
    path:":parentid",
    component:EditParentTeComponent,
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParentsTabRoutingModule { }

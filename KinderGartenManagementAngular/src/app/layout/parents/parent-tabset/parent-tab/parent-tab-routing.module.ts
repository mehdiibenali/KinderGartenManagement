import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddParentTpComponent } from './add-parent-tp/add-parent-tp.component';
import { EditParentTpComponent } from './edit-parent-tp/edit-parent-tp.component';


const routes: Routes = [
  {
    path:'add',
    component:AddParentTpComponent
  },
  {
    path:':parentid',
    component:EditParentTpComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParentTabRoutingModule { }

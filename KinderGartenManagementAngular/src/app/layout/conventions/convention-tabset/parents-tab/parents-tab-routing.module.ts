import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentsListComponent } from './parents-list/parents-list.component';


const routes: Routes = [
  {
    path:"list",
    component:ParentsListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParentsTabRoutingModule { }

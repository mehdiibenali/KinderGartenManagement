import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ParentlistComponent } from './parentlist/parentlist.component';


const routes: Routes = [
  {
    path:'list',
    component:ParentlistComponent
  },
  {
    path:'fiche',
    loadChildren: () => import('./parent-tabset/parent-tabset.module').then(m=>m.ParentTabsetModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParentsRoutingModule { }

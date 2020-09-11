import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConventionListComponent } from './convention-list/convention-list.component';


const routes: Routes = [
  {
    path:'list',
    component:ConventionListComponent
  },
  {
    path:'fiche',
    loadChildren: () => import('./convention-tabset/convention-tabset.module').then(m=>m.ConventionTabsetModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConventionsRoutingModule { }

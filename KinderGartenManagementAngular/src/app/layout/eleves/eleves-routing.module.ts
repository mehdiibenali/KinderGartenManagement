import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ElevelistComponent } from './elevelist/elevelist.component';
const routes: Routes = [
  {
    path:'fiche',
    loadChildren: () => import('./eleve-tabset/eleve-tabset.module').then(m=>m.EleveTabsetModule)
  },
  {
    path:'list',
    component: ElevelistComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ElevesRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ElevelistComponent } from './elevelist/elevelist.component';
import { EditeleveComponent } from './editeleve/editeleve.component';
const routes: Routes = [
  {
    path:'fiche',
    loadChildren: () => import('./eleve-tabset/eleve-tabset.module').then(m=>m.EleveTabsetModule)
  },
  {
    path:'list',
    component: ElevelistComponent,
  },
  {
    path:'edit/:id',
    component: EditeleveComponent, 
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ElevesRoutingModule { }

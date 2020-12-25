import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupelistComponent } from './groupelist/groupelist.component';


const routes: Routes = [
  {
    path:'list',
    component:GroupelistComponent,
  },
  {
    path:'fiche',
    loadChildren: () => import('./groupe-tabset/groupe-tabset.module').then(m=>m.GroupeTabsetModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupesRoutingModule { }

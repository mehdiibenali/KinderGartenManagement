import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SummerClublistComponent } from './summer-clublist/summer-clublist.component';


const routes: Routes = [
  {
    path:'list',
    component:SummerClublistComponent
  },
  {
    path:'fiche',
    loadChildren: () => import('./summer-club-tabset/summer-club-tabset.module').then(m=>m.SummerClubTabsetModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SummerClubsRoutingModule { }

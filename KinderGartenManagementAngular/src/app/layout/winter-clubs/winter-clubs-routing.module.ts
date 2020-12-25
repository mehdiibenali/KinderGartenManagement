import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WinterClublistComponent } from './winter-clublist/winter-clublist.component';


const routes: Routes = [
  {
    path:'list',
    component: WinterClublistComponent,
  },
  {
    path:'fiche',
    loadChildren: () => import('./winter-club-tabset/winter-club-tabset.module').then(m=>m.WinterClubTabsetModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WinterClubsRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WinterClublistComponent } from './winter-clublist/winter-clublist.component';


const routes: Routes = [
  {
    path:'list',
    component: WinterClublistComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WinterClubsRoutingModule { }

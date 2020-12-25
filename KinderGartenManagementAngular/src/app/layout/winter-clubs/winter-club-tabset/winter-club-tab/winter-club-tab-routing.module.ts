import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddWinterClubWctComponent } from './add-winter-club-wct/add-winter-club-wct.component';


const routes: Routes = [
  {
    path:'add',
    component:AddWinterClubWctComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WinterClubTabRoutingModule { }
